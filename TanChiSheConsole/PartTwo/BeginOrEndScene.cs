using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanChiSheConsole.PartOne;

namespace TanChiSheConsole.PartTwo
{
    internal abstract class BeginOrEndScene : ISceneUpdate
    {
        protected int nowSelIndex = 0;
        protected string strTile;
        protected string strOne;

        public abstract void EnterJDoSomething();
        public void Update()
        {
            //开始和结束场景的游戏逻辑
            //选择当前的选项 然后 监听 键盘输入 wasd j
            Console.ForegroundColor = ConsoleColor.White;
            //显示标题
            Console.SetCursorPosition(Game.GameWindowWidth/2-strTile.Length,5);
            Console.Write(strTile);
            //显示下方的选项
            Console.SetCursorPosition(Game.GameWindowWidth / 2 - strOne.Length, 8);
            Console.ForegroundColor = nowSelIndex==0?ConsoleColor.Red:ConsoleColor.White;
            Console.Write(strOne);
            Console.SetCursorPosition(Game.GameWindowWidth/2-4,8);
            Console.ForegroundColor = nowSelIndex == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write("结束游戏");

            //检测输入
            switch (Console.ReadKey(true).Key) 
            {
                case ConsoleKey.W:
                    nowSelIndex--;
                    if (nowSelIndex < 0)
                    {
                        nowSelIndex = 0;
                    }
                    break;
                case ConsoleKey.A:

                    break;
                case ConsoleKey.S:
                    nowSelIndex++;
                    if (nowSelIndex > 1)
                    {
                        nowSelIndex = 1;
                    }
                    break;
                case ConsoleKey.D:

                    break;
                case ConsoleKey.J:
                    EnterJDoSomething();
                    break;
                default: Console.WriteLine("");
                    break;

            }

        }
    }
}
