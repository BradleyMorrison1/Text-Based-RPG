using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {
        int mapWidth;
        int mapHeight;
        static string[] mapArray = File.ReadAllLines("Map.txt");
        public Map()
        {
            mapWidth = 60;
            mapHeight = 30;
        }
        
        public void Draw()
        {
            for (int i = 0; i < mapArray.Length; i++)
            {
                Console.Write(mapArray[i]);
            }
        }
        public void DrawBorder()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("╔");
            for (int i = 0; i < (Console.WindowWidth - 2); i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
        }
    }
}
