using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanChiSheConsole.Part3
{
    internal abstract class GameObj : IDraw
    {
        public Position pos;
       
        //因为是抽象行为，所以子类中是必须去实现的
        public abstract void Draw();
    }
}
