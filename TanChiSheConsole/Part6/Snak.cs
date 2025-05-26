using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanChiSheConsole.Part3;
using TanChiSheConsole.Part4;
using TanChiSheConsole.Part5;

namespace TanChiSheConsole.Part6
{
    enum E_SnakMoveType
    {
        UpMove,
        DownMove,
        LeftMove,
        RightMove
    }

    internal class Snak : IDraw
    {
        SnakBody[] snakBody;
        int nowSnakNum=0;

        E_SnakMoveType snakMoveType;

        public Snak(int x,int y) 
        { 
            snakBody = new SnakBody[200];

            snakBody[0] = new SnakBody(E_SnakBodyTyppe.Head,x,y);

            nowSnakNum=1;

            snakMoveType = E_SnakMoveType.RightMove;    
        }

        //绘制蛇的身体
        public void Draw()
        {
            for (int i = 0; i < nowSnakNum; i++) 
            {
                snakBody[i].Draw();
            }
        }


        #region  移动
        //蛇头移动
        public void Move()
        {

            

            //移动之前需要对最后一个位置进行擦除
            SnakBody lastBody = snakBody[nowSnakNum - 1];
            Console.SetCursorPosition(lastBody.pos.x, lastBody.pos.y);
            Console.Write("  ");

            //在蛇头移动之前 从蛇尾开始 不停的 让后一个的位置等于前一个的位置
            for (int i = nowSnakNum - 1; i > 0; i--)
            {
                snakBody[i].pos = snakBody[i - 1].pos;
            }

            switch (snakMoveType)
            {
                case E_SnakMoveType.UpMove:
                    snakBody[0].pos.y--;
                    break;
                case E_SnakMoveType.DownMove:
                    snakBody[0].pos.y++;
                    break;
                case E_SnakMoveType.LeftMove:
                    snakBody[0].pos.x -= 2;
                    break;
                case E_SnakMoveType.RightMove:
                    snakBody[0].pos.x+=2;
                    break;
                default:
                    break;
            }

          
        }
        #endregion

        #region 改变方向
        public void ChangeDir(E_SnakMoveType dir)
        {
            //只有头部的时候 可以直接左转右 右转左 上转下 下转上
            //有身体的时候，这种情况下就不可以直接转向
            if (dir == this.snakMoveType ||
                nowSnakNum > 1 &&
                    (this.snakMoveType == E_SnakMoveType.LeftMove && dir == E_SnakMoveType.RightMove||
                    this.snakMoveType == E_SnakMoveType.RightMove && dir == E_SnakMoveType.LeftMove||
                    this.snakMoveType == E_SnakMoveType.UpMove && dir == E_SnakMoveType.DownMove||
                    this.snakMoveType == E_SnakMoveType.DownMove && dir == E_SnakMoveType.UpMove
                    )
                )
            {
                return;
            }
            this.snakMoveType=dir;
        }
        #endregion

        #region //检测蛇是否撞墙，和身体 判断游戏是否结束
        public bool CheckEnd(Map map)
        {
            if( map == null ) return false;

            for (int i = 0; i < map.walls.Length; i++) 
            {
               if( snakBody[0].pos == map.walls[i].pos)
                {
                    return true;
                }
            }

            for (int i = 1; i < nowSnakNum; i++)
            {
                if (snakBody[0].pos == snakBody[i].pos)
                    return true;    
            }
                
            return false;
        }





        #endregion


        #region 吃食物相关

        public bool CheckSamePos(Position p)
        {
            for (int i = 0;i<nowSnakNum;i++)
            {
                {
                    if (snakBody[i].pos == p)
                    {
                        return true;
                    }
                }
            }
           
            return false;
        }

        public void CheckEatFood(Food food)
        {
            if (snakBody[0].pos == food.pos)
            {
                food.RandomPos(this);

                //长身体
                AddBody();
            }
        }


        #endregion

        #region 长身体
        public void AddBody()
        {
            SnakBody frontBody = snakBody[nowSnakNum-1];
            //先长
            snakBody[nowSnakNum] = new SnakBody(E_SnakBodyTyppe.Body, frontBody.pos.x,frontBody.pos.y);
            nowSnakNum++;
        }


        #endregion

    }
}
