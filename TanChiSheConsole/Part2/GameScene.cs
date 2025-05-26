using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TanChiSheConsole.Part4;
using TanChiSheConsole.Part5;
using TanChiSheConsole.Part6;
using TanChiSheConsole.PartOne;

namespace TanChiSheConsole.PartTwo
{
    internal class GameScene : ISceneUpdate
    {
        Map map;
        Snak snak;
        Food food;

        int updateIndex=0;

        public GameScene()
        {
            map = new Map();
            snak = new Snak(30,15);
            food = new Food(snak);
        }
        public void Update()
        {

            if (updateIndex % 22222 == 0)
            {
                map.Draw();

                food.Draw();    

                //检测是否撞墙
                if (snak.CheckEnd(map))
                {
                    Game.ChangeScene(E_SceneType.End);
                    return;
                }

                snak.CheckEatFood(food);

                snak.Move();
                

                snak.Draw();

                updateIndex = 0;
            }
            updateIndex++;

            if (Console.KeyAvailable) 
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:

                        snak.ChangeDir(E_SnakMoveType.UpMove);
                        break;
                    case ConsoleKey.S:
                        snak.ChangeDir(E_SnakMoveType.DownMove);
                        break;
                    case ConsoleKey.A:
                        snak.ChangeDir(E_SnakMoveType.LeftMove);
                        break;
                    case ConsoleKey.D:
                        snak.ChangeDir(E_SnakMoveType.RightMove);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
