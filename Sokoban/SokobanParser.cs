using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Field
{
    class SokobanParser
    {   
        public void Parse(int idMaze)
        {
            String[] lines = System.IO.File.ReadAllLines($@"./Mazes/maze_{idMaze}.txt");
        } 
        
    }
}
