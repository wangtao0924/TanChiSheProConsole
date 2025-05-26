using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanChiSheConsole.PartTwo;

namespace TanChiSheConsole.PartOne
{
    /// <summary>
    /// 场景类型枚举
    /// </summary>
    enum E_SceneType
    {
        Begin,
        Game,
        End,
    }
    internal class Game
    {
        public const int GameWindowWidth = 80;
        public const int GameWindowHeight = 20;

        //当前选中的场景
        public static ISceneUpdate nowScene;


        public Game()
        {
            
        }

        public void  Inint()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(GameWindowWidth, GameWindowHeight);

            //设置缓冲区的大小，即控制台可打印的区域
            Console.SetBufferSize(GameWindowWidth, GameWindowHeight);

            ChangeScene(E_SceneType.Begin);
        }


        public void Start()
        {

            Inint();
            while (true)
            {
                if (nowScene != null)
                {
                   nowScene.Update();
                }
            }
        }

        public static void ChangeScene(E_SceneType type)
        {
            Console.Clear();

            switch (type)
            {
                case E_SceneType.Begin:
                    nowScene = new BeginSence();
                    
                    break;
                case E_SceneType.Game:
                   nowScene = new GameScene();
                   
                    break;
                case E_SceneType.End:
                    nowScene = new EndSence();

                    break;
                default:
                    break;
            }
            
        }
        
    }
}
