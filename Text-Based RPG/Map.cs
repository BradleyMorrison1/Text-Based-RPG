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
            mapWidth = 100;
            mapHeight = 100;
        }
        
        public void Draw()
        {
            for (int i = 0; i < mapArray.Length; i++)
            {
                Console.Write(mapArray[i]);
            }
        }
    }
}
