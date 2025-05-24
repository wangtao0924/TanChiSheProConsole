using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanChiSheConsole.PartTwo
{
    internal class EndSence :BeginOrEndScene
    {
        public override void EnterJDoSomething()
        {
           
        }

        public void Update()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("结束场景 ");

        }
    }
}
