using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanChiSheConsole.Part3;
using TanChiSheConsole.PartOne;

namespace TanChiSheConsole.Part4
{

    enum E_SnakBodyTyppe
    {
        Head,
        Body
    }
    internal class SnakBody : GameObj
    {

        public E_SnakBodyTyppe type;

        public SnakBody(E_SnakBodyTyppe type,int x,int y)
        {
            this.type = type;
            this.pos = new Position(x,y);
        }
        public override void Draw()
        {
            if(pos.x>Game.GameWindowWidth||pos.y>Game.GameWindowHeight||pos.x<0||pos.y<0) return;
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = type == E_SnakBodyTyppe.Head ? ConsoleColor.Yellow : ConsoleColor.Green;
            Console.ForegroundColor = type == E_SnakBodyTyppe.Body ? ConsoleColor.Yellow : ConsoleColor.Green;
            Console.Write(type== E_SnakBodyTyppe.Body? "○" : "●");
        }
    }
}
