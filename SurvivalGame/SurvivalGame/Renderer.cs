using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace SurvivalGame
{
    static class Renderer
    {
        readonly static string[] curby1 =
{
                "⢀⠔⠡⢑⠑⡄⠀⡀⡀⣀⢀⡀⠀⠀",
                "⠬⡨⠨⡠⢑⠌⠕⡐⠨⠐⡐⡈⠍⠢⢄⠀⠀",
                "⢇⢪⠨⡂⠕⡈⠴⢰⠁⡁⡒⢢⠡⢑⢐⢑⠩⢈⠒⡄",
                "⢱⢑⢌⠢⢁⠂⢧⣴⡃⠠⣻⣴⡇⢅⠢⢑⠌⠔⡡⢪",
                "⠀⢣⢑⠌⡐⢌⠺⣻⠂⡡⢘⠽⡑⠔⡌⡢⡑⢕⢬⠂",
                "⠀⢸⡐⢅⢊⠢⡁⡂⢳⢯⡳⢐⠌⡌⡢⡒⡜⡎⠀",
                "⠀⠈⢎⠢⠢⡑⡐⢌⢂⠕⡨⢢⢱⡪⣣⡫⣪⢝⣆⠀",
                "⠀⠀⠈⣇⢇⢎⢔⠡⡢⡑⢬⢎⣗⣝⢮⢞⣗⢯⠖⠀",
                "⠀⠀⠀⡳⡵⣕⢜⢜⢔⢕⢵⡫⣮⡺⡽⡵⣳⠋",
                "⠀⠀⠀⢹⣪⢳⡫⣟⢮⣗⡟⣮⡳⡽⣝⠞⠁",
                "⠀⠀⠀⠀⢳⢕⢕⢕⣝⢮⡇⠀⠈⠈⠀⠀",
                "⠀⠀⠀⠀⠀⠙⠵⣳⢵⠏⠀⠀⠀     "
        };

        readonly static string[] curby2 =
{
                "⠀⠀⠀⠀⠀⠀⠀⠀⡀⣀⠠⡀⡀⡀⢀⠆⡑⢑⠰⡀",
                "⠀⠀⠀⠀⠀⡠⢂⠣⠨⢐⠨⠐⠨⢐⠱⠨⡐⠡⡂⢕",
                "⠠⡂⠍⠌⡪⢐⠡⢨⠊⢢⠂⠡⡱⢔⢈⠪⢨⠨⢢⢹",
                "⢎⠄⢅⠕⡐⠅⠌⢜⣶⣗⠈⢸⣤⣞⠄⠌⠢⡑⡅⡇",
                "⠘⡬⢢⢑⠌⡜⢌⠜⠽⡂⢅⠸⡝⡇⠌⢌⠌⠜⡜⠀",
                "⠀⠈⡱⡥⡱⡨⡂⡪⢐⢝⣗⢗⢐⠨⡘⠔⡡⡑⡅⠀",
                "⠀⢜⢮⣪⡪⡺⡜⣆⢕⢐⠌⢔⠐⢌⠔⡡⢢⢱⠁⠀",
                "⠀⢹⡳⣳⢽⢕⡯⡺⡼⡰⡑⠔⡅⢕⢌⢜⢜⠀",
                "⠀⠀⠹⢮⣳⡻⣺⢝⡮⡇⡇⡇⡇⣇⢧⡳⡳⠀",
                "⠀⠀⠀⠁⠳⣝⢗⡯⣞⢽⣺⢽⡺⣕⢯⡺⡕",
                "⠀⠀⠀⠀⠀⠀⠁⠁⠀⢸⡺⣕⢇⢇⢧⠳⠁⠀",
                "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣎⣗⠽⠊⠀"
        };
        public static void DrawCurby(int i)
        {
            for (int _ = 0; _<curby1.Length; _++)
            {
                Console.SetCursorPosition(26, 1+_);
                Console.Write(new string(' ', 21));
            }
            if (i==0) DrawCurby1();
            else DrawCurby2();
        }
        public static void DrawCurby1()
        {
            for (int i = 0; i<curby1.Length; i++)
            {
                Console.SetCursorPosition(26, 1+i);
                Console.Write(curby1[i]);
            }
        }
        public static void DrawCurby2()
        {
            for (int i = 0; i<curby2.Length; i++)
            {
                Console.SetCursorPosition(26, 1+i);
                Console.Write(curby2[i]);
            }
        }
        public static void DrawMap(MapTile[,] map, Player player)
        {
            //EraseConsoleArea(0, 0, 20);
            DrawGrid(map.GetLength(0));

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.SetCursorPosition(x * 3 + 2, y * 2 + 2);
                    map[x, y].DrawTile();

                    if (x == player.X && y == player.Y)
                    {
                        Console.SetCursorPosition(x * 3 + 2, y * 2 + 2);
                        player.Draw();
                    }
                }
            }
        }

        public static void DrawBoard()
        {
            string bar0 = new string('─', 48);
            string bar1 = '┌' + bar0 + '┐';
            string bar2 = '│' + new string(' ', 48) + '│';
            string bar3 = '└' + bar0 + '┘';

            Console.SetCursorPosition(0, 0);
            Console.Write(bar1);
            for (int i=1; i<24; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(bar2);
            }
            Console.SetCursorPosition(0, 24);
            Console.Write(bar3);
        }

        private static void DrawGrid(int size)
        {
            //가로줄
            for (int y = 0; y < size + 1; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Console.SetCursorPosition(x * 3 + 2, y * 2 + 1);
                    Console.Write("──");//─ 두개 출력, 유니코드가 2칸씩차지 (2바이트라 그런가)
                }
            }
            //세로줄
            for (int y = 0; y < size * 2 + 1; y++)
            {
                for (int x = 0; x < size + 1; x++)
                {
                    Console.SetCursorPosition(x * 3 + 1, y + 1);
                    Console.Write(y % 2 == 0 ? "┼" : "│");
                }
            }
        }
        public static void DrawUI(Player player, in int skills)
        {
            //// UI 관련 코드 추가
            ///
            int y = 13;
            Console.SetCursorPosition(26, y);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━┓");
            y++;

            Console.SetCursorPosition(26, y);
            Console.Write("┃                   ┃");
            Console.SetCursorPosition(28, y);
            Console.Write($"Health  : {player.Health,2} / {player.MaxHealth}");
            y++;

            Console.SetCursorPosition(26, y);
            Console.Write("┃                   ┃");
            Console.SetCursorPosition(28, y);
            Console.Write($"Stamina : {player.Stamina} / {player.MaxStamina}");
            y++;

            Console.SetCursorPosition(26, y);
            Console.Write("┃                   ┃");
            Console.SetCursorPosition(28, y);
            Console.Write($"skills  : {skills,2}");
            y++;

            Console.SetCursorPosition(26, y);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━┛");
        }

        /// <summary>
        /// startY 디폴트 값 17
        /// </summary>
        /// <param name="messages"></param>
        public static void DrawMessage(params string[] messages) 
        {
            int startY = 18;
            if (startY + messages.Length >= Console.WindowHeight - 2) return;

            for (int i = 0; i<6; i++)
            {
                Console.SetCursorPosition(1, startY+i);
                Console.Write($"{' ',48}");
            }
            for (int i = 0; i<messages.Length; i++)
            {
                //GPT 도움!!
                //유니코드인경우에 2칸을 차지함, 따라서 유니코드(이모지,한글)이면 글자수 +2로 카운트
                // 유니코드 한글과 이모지를 모두 처리
                int msgLength = messages[i].Sum(c =>
                    (c >= 0xAC00 && c <= 0xD7A3) ||   // 한글 범위
                    (c >= 0x1F600 && c <= 0x1F64F) || // 이모지 범위 (일부)
                    (c >= 0x1F300 && c <= 0x1F5FF)   // 기호 및 물체 이모지 등
                    ? 2 : 1); // 유니코드 문자는 +2, 아스키 문자는 +1
                int alignX = (50 - msgLength) / 2;
                alignX = (alignX<0) ? 0 : alignX;
                Console.SetCursorPosition(alignX, startY+i);
                Console.Write($"{messages[i]}");
            }
        }

    }
}
