using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurvivalGame
{
    /// <summary>
    /// 맵 초기화, 할당하는 클래스
    /// </summary>
    public class MapManager
    {
        readonly int MAX_MAP_SIZE;
        readonly int MAX_HALF_ACTIVE_SIZE;
        Random _rand;
        public MapTile[,] Map { get; private set; }
        int _halfActiveRange;//맵 활성화되는 범위
        public MapManager(int maxSize)
        {
            MAX_MAP_SIZE = maxSize;
            MAX_HALF_ACTIVE_SIZE = maxSize/2;
            _rand = SurvivalGame.random;
            Map = new MapTile[MAX_MAP_SIZE, MAX_MAP_SIZE];
            _halfActiveRange = 1;
            InitializeMap();
        }

        public void ResetMap()
        {
            for (int i = 0; i < MAX_MAP_SIZE; i++)
            {
                for (int j = 0; j < MAX_MAP_SIZE; j++)
                {
                    Map[i, j].TileType = TileType.Hide;
                }
            }
            int center = MAX_MAP_SIZE / 2;
            Map[center, center].TileType = TileType.Shelter;
            UpdateMapActivation();
        }

        void InitializeMap()
        {
            for (int i = 0; i < MAX_MAP_SIZE; i++)
            {
                for (int j = 0; j < MAX_MAP_SIZE; j++)
                {
                    Map[i, j] = new MapTile();
                }
            }
            int center = MAX_MAP_SIZE / 2;
            Map[center, center].TileType = TileType.Shelter;

            UpdateMapActivation();
        }
        void UpdateMapActivation()
        {
            int center = MAX_MAP_SIZE/2;

            int activeStart = Math.Max(0, center - _halfActiveRange);
            int activeEnd = Math.Min(MAX_MAP_SIZE - 1, center + _halfActiveRange);

            for (int i = activeStart; i <= activeEnd; i++)
            {
                for (int j = activeStart; j <= activeEnd; j++)
                {
                    Map[i, j].IsActive = true;
                }
            }
        }

        public bool IsMoveable(int nextX, int nextY)
        {
            int center = MAX_MAP_SIZE/2;
            int activeStart = center - _halfActiveRange;
            int activeEnd = center + _halfActiveRange;

            if (nextX < activeStart || nextX > activeEnd || nextY < activeStart || nextY > activeEnd)//활성화 안된 맵으로 갈때 
            {
                return false;
            }
            return true;
        }

        public void GenRandomEvent(int nx, int ny)
        {
            if (Map[nx, ny].TileType != TileType.Hide) return;//Revealed되지 않은 곳에서만 이벤트 발생.

            int randomEvent = _rand.Next(1, 101);
            TileType eventType;
            //_halfActiveRange가 MAX_HALF_ACTIVE_SIZE 일때만 5퍼센트 확률로 라디오 생성.
            if(_halfActiveRange==MAX_HALF_ACTIVE_SIZE && randomEvent <= 5)
            {
                eventType = TileType.Radio;
            }
            else
            {
                randomEvent = _rand.Next(1, 101);
                if (randomEvent <= 20)//야생동물 20퍼센트
                {
                    eventType = TileType.WildAnimal;
                }
                else if(randomEvent<=70)//아이템 50퍼센트
                {
                    eventType = TileType.Item;
                }
                else//이벤트 없음 30퍼센트
                {
                    eventType = TileType.None;
                }
            }
            Map[nx, ny].TileType = eventType;
        }

        //public MapTile[,] GetMap() => _map;

        public void IncreaseHalfActiveRange(){
            if (_halfActiveRange >= MAX_HALF_ACTIVE_SIZE) return;
            _halfActiveRange++; 
        }

        public int GetHalfActiveRange() => _halfActiveRange;
    }

}
