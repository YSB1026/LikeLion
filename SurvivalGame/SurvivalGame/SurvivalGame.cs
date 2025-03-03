using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using SurvivalGame;

namespace SurvivalGame
{
    public enum TileType
    {
        None,       //
        Hide,       //나무, 밝혀지지 않은 맵
        Shelter,    //동굴, 은신처
        Item,       //Item(음식, 무기)
        WildAnimal, //야생동물
        Radio       //무전기
    }

    public enum EventResult
    {
        None,               //None
        ArrivedAtShelter,   //플레이어가 쉘터 도착
        TookDamage,         //플레이어 데미지 받음
        EvadedWildAnimal,   //플레이어가 야생동물로부터 도망
        MapExpansion,       //Active영역 증가
        MaxStaminaIncreased,//플레이어 최대 스태미나 증가
        MaxHealthIncreased, //플레이어 최대 체력 증가
        HealthRecovered,    //플레이어 체력 회복
        StaminaRecovered,   //플레이어 스태미나 회복
        RadioAcquired       //라디오 획득
    }

    public class SurvivalGame
    {
        const int MAX_MAP_SIZE = 7;//홀수만 넣어 :)
        public static Random random = new Random();
        private Player _player;
        private MapManager _mapManager;
        private EventMnager _eventMnager;
        private bool _isGameOver, _isGetMapExpansion,_isPlayerWon;
        private int _directionX, _directionY;
        private EventResult _curEventResult;
        public SurvivalGame()
        {
            _player = new Player(MAX_MAP_SIZE);
            _mapManager = new MapManager(MAX_MAP_SIZE);
            _eventMnager = new EventMnager();
            _isGameOver = false;
            _isGetMapExpansion = false;
            _isPlayerWon = false;
            _directionX = _directionY = 0;
            _curEventResult = EventResult.None;
        }
        
        void RenderStartScreen()
        {
            Renderer.DrawBoard();
            DrawUIAndMap();
            Renderer.DrawMessage("🌿야생 멋사에서 살아남기🌿", "ℹ️Move : WASDℹ️", "ℹ️멋사에서 갓겜을 만들어보세요!ℹ️", "ℹ️skills가 3이 되면 갓겜을 만들 수 있습니다.ℹ️");
        }
        void DrawUIAndMap()
        {
            Renderer.DrawMap(_mapManager.Map, _player);
            Renderer.DrawUI(_player, _mapManager.GetHalfActiveRange());
        }

        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.SetWindowSize(50, 25);
            Console.SetBufferSize(50, 25);

            RenderStartScreen();

            while (!_isPlayerWon && !_isGameOver)
            {
                ReadInput();
                ProcessPlayerInput();
                CheckGameOver();
            }

            Console.Clear();
            Renderer.DrawMessage("🦁Thank You!🦁","Press Any Key");
            Console.ReadKey();
        }

        void ReadInput()//사용자 입력 받는 함수.
        {
            _directionX = _directionY = 0;
            if (!Console.KeyAvailable) return;

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (_curEventResult==EventResult.ArrivedAtShelter)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Y: RestAtShelter(); break;
                    case ConsoleKey.N: _curEventResult = EventResult.None; break;
                }
            }
            else
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W: _directionY--; break;
                    case ConsoleKey.S: _directionY++; break;
                    case ConsoleKey.A: _directionX--; break;
                    case ConsoleKey.D: _directionX++; break;
                    case ConsoleKey.Escape: _isGameOver = true; return;
                    default: break;
                }
            }
        }
        void RestAtShelter()
        {
            if (_isGetMapExpansion)
            {
                _isGetMapExpansion =false; 
                _mapManager.IncreaseHalfActiveRange();
                _player.IncreaseMaxStamina();
            }
            _mapManager.ResetMap();
            _player.Rest();
            DrawUIAndMap();
            Renderer.DrawMessage("💤휴식을 취했습니다!💤","다음날이 되었습니다.");
            _curEventResult = EventResult.None;
        }

        void ProcessPlayerInput()
        {
            if (_directionX==0 && _directionY == 0) return;

            int nx = _player.X + _directionX, ny = _player.Y + _directionY;
            if (_mapManager.IsMoveable(nx, ny))
            {
                _mapManager.GenRandomEvent(nx, ny);
                HandleEvent(_mapManager.Map[nx, ny].TileType);
                PlayerMove(in nx, in ny);

                if (_curEventResult != EventResult.ArrivedAtShelter)
                    _mapManager.Map[nx, ny].TileType = TileType.None;
            }
        }
        void HandleEvent(TileType tileType)
        {
            _curEventResult = _eventMnager.HandleEvent(tileType);
            switch (_curEventResult)
            {
                case EventResult.None:
                    Renderer.DrawMessage("🤷 ‍아무일도 일어나지 않았습니다.. 🤷‍");
                    break;
                case EventResult.ArrivedAtShelter:
                    Renderer.DrawMessage("  🛏️ 휴식 취하기 🛏️", "O - Press Y", "X - Press N","공부도 쉬면서!");
                    break;
                case EventResult.TookDamage:
                    int dmg = random.Next(1, _mapManager.GetHalfActiveRange()+1);//halfActiveRange 1~3 사이 값
                    Renderer.DrawMessage("💻 과제와 조우! 💻", $"🥱 체력이 {dmg}감소했습니다. 🥱");
                    _player.GetDamage(dmg);
                    break;
                case EventResult.EvadedWildAnimal:
                    Renderer.DrawMessage("💻 과제와 조우! 💻","💪 과제를 무사히 해냈습니다.. ✅");
                    break;
                case EventResult.MapExpansion:
                    if (_isGetMapExpansion || _mapManager.GetHalfActiveRange() >= MAX_MAP_SIZE / 2) Renderer.DrawMessage("더 이상 스킬을 증가 할 수 없습니다.");
                    else
                        Renderer.DrawMessage("입벌려 지식 들어간다!","💡 스킬 + 1 💡", "범위 확장(최대 스태미너 증가,맵확장)", "==휴식시 적용==");
                    _isGetMapExpansion = true;
                    break;
                case EventResult.MaxStaminaIncreased:
                    Renderer.DrawMessage("최대 스태미나가 증가합니다.", "⚡ 내일은 더 잘할 수 있어 ⚡");
                    _player.IncreaseMaxStamina();
                    break;
                case EventResult.MaxHealthIncreased:
                    Renderer.DrawMessage("🔥 최대 체력이 증가합니다. 🔥", "📌 개발도 체력이 중요 📌");
                    _player.IncreaseMaxHealth();
                    break;
                case EventResult.HealthRecovered:
                    if (_player.RecoveryHealth()) Renderer.DrawMessage("공부도 먹으면서..","❤️ 체력이 차오릅니다.. ❤️‍");
                    else Renderer.DrawMessage("이미 최대 체력입니다..TT");
                        break;
                case EventResult.StaminaRecovered:
                    if (_player.RecoveryStamina()) Renderer.DrawMessage("☕️ 카페인 수혈. .☕️", "현재 스태미나 + 1");
                    else Renderer.DrawMessage("이미 최대 스태미나입니다..TT", "☕️ 카페인은 적당히 :) ☕️");
                    break;
                case EventResult.RadioAcquired:
                    Renderer.DrawMessage("🎮 갓겜을 만들었습니다! 🎮", "🎓 이제 졸업할 준비가 됐습니다! 🎓");
                    _isPlayerWon = true;
                    Thread.Sleep(1000);
                    break;
            }
        }

        void PlayerMove(in int nx, in int ny)
        {
            DrawUIAndMap();//플레이어 이동 전에 어떤 이벤트인지 보여주기 위해서.
            Thread.Sleep(500);

            _player.Move(nx, ny);
            DrawUIAndMap();
        }

        // 게임 오버 로직
        void CheckGameOver()
        {
            if (_player.Health <= 0)
            {
                _isGameOver = true;
            }
            else if (_player.Stamina < 0)
            {
                _isGameOver = true;
            }
        }

    }
}
