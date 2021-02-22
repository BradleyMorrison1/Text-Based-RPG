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
        public static int mapWidth = 60;
        public static int mapHeight= 61;
        public static char[,] map = new char[mapWidth, mapHeight];


        

        public Map()
        {
            
        }
        
        public void Draw()
        {
            Console.SetWindowSize(60, 61);
            Console.SetCursorPosition(0, 0);

            var file = new StreamReader("Map.txt");

            

            string line;

            int lineCount = 0;

            while((line = file.ReadLine()) != null)
            {
                if(lineCount < mapHeight)
                {
                    for(int i = 0; i < mapWidth/* && i < line.Length*/; i++)
                    {
                        map[i, lineCount] = line[i];
                        Console.Write(map[i, lineCount]);
                    }
                    Console.WriteLine();
                    lineCount++;
                }
            }
        }
        
    }
}
