using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_BrickGame
{
    public class Ball
    {
        BallData ballData = new BallData();

        //C#공의 방향 배열 정의
        int[,] wallCollision = new int[4, 6]
        {
            {  3,  2, -1, -1, -1, 4 },
            { -1, -1, -1, -1,  2, 1 },
            { -1,  5,  4, -1, -1,-1 },
            { -1, -1,  1,  0,  5,-1 }
        };

        Bar m_pBar;
        public void SetBar(Bar bar) => m_pBar = bar;
        public BallData GetBall() { return ballData; }
        public void SetX(int x) => ballData.x += x;
        public void SetY(int y) => ballData.y += y;
        public void SetReady(int ready) => ballData.ready = ready;
        public void SetBall(BallData ballData) => this.ballData = ballData;

        public int Collision(int x, int y)
        {
            //벽 충돌
            if (y==0)
            {
                ballData.direct = wallCollision[0, ballData.direct];
                return 1;
            }

            if (x==1)
            {
                ballData.direct = wallCollision[1, ballData.direct];
                return 1;
            }

            if (x==77)
            {
                ballData.direct = wallCollision[2, ballData.direct];
                return 1;
            }

            if (y==23)
            {
                ballData.direct = wallCollision[3, ballData.direct];
                return 1;
            }

            if (x >= m_pBar.m_tBar.nX[0] && x <= m_pBar.m_tBar.nX[2] +1 &&
                y== (m_pBar.m_tBar.nY)) //바 위 충돌
            {
                if (ballData.direct == 1)
                    ballData.direct = 2;
                else if (ballData.direct == 2)
                    ballData.direct = 1;
                else if (ballData.direct == 5)
                    ballData.direct = 4;
                else if (ballData.direct == 4)
                    ballData.direct = 5;

                return 1; //방향이 바뀐다.
            }

            if (x >= m_pBar.m_tBar.nX[0] && x <= m_pBar.m_tBar.nX[2] + 1 &&
              y == (m_pBar.m_tBar.nY+1)) //바 아래 충돌
            {
                if (ballData.direct == 1)
                    ballData.direct = 2;
                else if (ballData.direct == 2)
                    ballData.direct = 1;
                else if (ballData.direct == 5)
                    ballData.direct = 4;
                else if (ballData.direct == 4)
                    ballData.direct = 5;

                return 1; //방향이 바뀐다.
            }

            return 0;
        }
        public void Initialize()
        {
            ballData.ready = 0;//공 움직이면 0, 안 움직이면 1
            ballData.direct = 1;
            ballData.x = 30;
            ballData.y = 10;
        }

        public void MoveBall()
        {
            if (ballData.ready == 0)//공이 움직이면
            {
                //공의 방향에 따른 스위치문
                switch (ballData.direct)
                {
                    case 0://위
                        if (Collision(ballData.x, ballData.y - 1)==0)
                            ballData.y--;
                        break;
                    case 1://오른쪽 위
                        if (Collision(ballData.x+1, ballData.y - 1)==0)
                        {
                            ballData.x++;
                            ballData.y--;
                        }
                        break;
                    case 2://오른쪽 아래
                        if (Collision(ballData.x+1, ballData.y + 1)==0)
                        {
                            ballData.x++;
                            ballData.y++;
                        }
                        break;
                    case 3: //아래
                        if (Collision(ballData.x, ballData.y + 1)==0)
                            ballData.y++;
                        break;
                    case 4: //왼쪽 아래
                        if (Collision(ballData.x-1, ballData.y + 1)==0)
                        {
                            ballData.x--;
                            ballData.y++;
                        }
                        break;
                    case 5://왼쪽 위
                        if (Collision(ballData.x-1, ballData.y - 1)==0)
                        {
                            ballData.x--;
                            ballData.y--;
                        }
                        break;
                }//switch casae
            }
        }//MoveBall

        public void Render()
        {
            Program.gotoxy(ballData.x, ballData.y);
            Console.Write("●");
        }

        public void Release()
        {

        }
    }
}
