using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanChiSheConsole.PartOne;

namespace TanChiSheConsole.PartTwo
{
    internal class BeginSence :BeginOrEndScene
    {
        public BeginSence() 
        {
            strTile = "贪吃蛇";
            strOne = "开始游戏";
        }
        public override void EnterJDoSomething()
        {
            if (nowSelIndex == 0)
            {
               
                Game.ChangeScene(E_SceneType.Game);
            }
            else 
            {
                Environment.Exit(0);
            }
        }

        public void Update()
        {
            
        }
    }
}
