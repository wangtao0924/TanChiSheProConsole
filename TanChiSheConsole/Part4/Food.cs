using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanChiSheConsole.Part3;
using TanChiSheConsole.Part6;
using TanChiSheConsole.PartOne;

namespace TanChiSheConsole.Part4
{
    internal class Food : GameObj
    {
        public Food(int x,int y)
        { 
            pos = new Position(x,y);
        }

        public Food(Snak snak) 
        {
            RandomPos(snak);
        }


        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("◆");
        }

        //随机位置的行为 行为和蛇的位置有关系 有了蛇再考虑
        public void RandomPos(Snak snak) 
        {
            //随机位置
            Random random = new Random();
            int x= random.Next(2,Game.GameWindowWidth/2-1) * 2; 
            int y= random.Next(1,Game.GameWindowHeight-4); 
            pos = new Position(x,y);

            //得到蛇 判断这个位置是不是蛇的位置
            if (snak.CheckSamePos(pos))
            {
                RandomPos(snak);    
            }
        }
    }
}
