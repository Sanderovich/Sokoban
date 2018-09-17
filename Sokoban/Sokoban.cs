using Sokoban.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Sokoban
    {
        public void Start()
        {
            new StartView().PrintStart();

            Console.ReadLine();
        }
    }
}
