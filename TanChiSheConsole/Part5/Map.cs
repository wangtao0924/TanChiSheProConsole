using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanChiSheConsole.Part3;
using TanChiSheConsole.Part4;
using TanChiSheConsole.PartOne;

namespace TanChiSheConsole.Part5
{
    internal class Map:IDraw
    {
        public Wall[] walls;
        int index = 0;

        public Map()
        {

            walls = new Wall[Game.GameWindowWidth+(Game.GameWindowHeight-3)*2];
            //绘制横向第一排的墙,循环控制绘制的个数，i控制绘制墙的坐标
            for (int i = 0; i < Game.GameWindowWidth; i+=2) 
            {
                walls[index] = new Wall(i, 0);
                index++;
            }
            //绘制横向最后一排的墙
            for (int i = 0; i < Game.GameWindowWidth; i += 2)
            {
                walls[index] = new Wall(i, Game.GameWindowHeight-2);
                index++;
            }
            //绘制纵向第一排的墙
            for (int i = 1; i < Game.GameWindowHeight-2; i++)
            {
                walls[index] = new Wall(0, i);
                index++;
            }
            //绘制纵向最后一排的墙
            for (int i = 1; i < Game.GameWindowHeight - 2; i++)
            {
                walls[index] = new Wall(Game.GameWindowWidth - 2, i);
                index++;
            }
        }

        

        public void Draw()
        {
            for (int i = 0;i < walls.Length; i++)
            {
                if (walls[i]!=null)
                 walls[i].Draw();
            }
        }
    }
}
