using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Players;
using Sokoban.Tiles;
using Sokoban.Crates;
using System.Reflection;

namespace Sokoban
{
    class SokobanParser
    {   
        public Maze Parse(int idMaze)
        {
            String[] lines;

            try
            {
                lines = File.ReadAllLines($@"C:\Users\yolob\Documents\Doolhof\maze_{idMaze}.txt");
            } catch (Exception)
            {
                return null;
            }

            if (lines == null || lines.Length == 0)
            {
                return null;
            }

            return InitMaze(lines, getLongestLine(lines));
        }

        private Maze InitMaze(string[] lines, int length)
        {
            Maze maze = new Maze();
            Tile[,] tiles = new Tile[lines.Length, length];

            int x , y;
            x = y = 0;

            foreach (String line in lines)
            {

                y = 0;
                foreach (char character in line.ToCharArray())
                {

                    Tile tile = null;
                    switch(character)
                    {
                        case 'x':
                            tile = new Destination();
                            break;
                        case '.':
                            tile = new Normal();
                            break;
                        case 'o':
                            tile = new Normal();

                            maze.Crates.Add(new Crate(tile));
                            break;
                        case '@':
                            tile = new Normal();

                            maze.Player = new Player(tile);
                            break;
                        case '█':
                            tile = new Wall();
                            break;
                        case '0':
                            tile = new Destination();
                            break;
                    }

                    tiles[x, y] = tile;
                    y++;
                }

                x++;
            }
            
            for(int i = 0; i < tiles.GetLength(0); i++)
            {
                for(int j = 0; j < tiles.GetLength(1); j++)
                {
                    Tile tile = tiles[i, j];

                    tile.North = getTile(tiles, i - 1, j);
                    tile.East = getTile(tiles, i, j + 1);
                    tile.South = getTile(tiles, i + 1, j);
                    tile.West = getTile(tiles, i, j - 1);

                    if (i == 0 && j == 0)
                    {
                        maze.First = tile;
                    }
                }
            }

            return maze;
        }

        private Tile getTile(Tile[,] tiles, int x, int y)
        {
            Tile tile;

            try
            {
                tile = tiles[x, y];
            } catch (Exception)
            {
                return null;
            }

            return tile;
        }

        private int getLongestLine(String[] array)
        {
            int longestLine = 0;

            foreach (String line in array)
            {
                if (line.Length > longestLine)
                {
                    longestLine = line.Length;
                }
            }

            return longestLine;
        }
    }
}
