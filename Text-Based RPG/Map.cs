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

        int mapWidth = 61;
        int mapHeight= 60;


        public Map()
        {
            
        }
        
        public void Draw()
        {
            //Console.SetWindowSize(60, 66);
            Console.SetCursorPosition(0, 0);

            var map = new char[mapWidth, mapHeight];
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
                        //Console.Write(map[1,1]);
                    }
                    Console.WriteLine();
                    lineCount++;
                }
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
            for (int j = 0; j < (Console.WindowHeight - 6); j++)
            {
                Console.WriteLine("║");
            }
            for (int j = 0; j < (Console.WindowHeight - 6); j++)
            {
                Console.SetCursorPosition(Console.WindowWidth-1, j+1);
                Console.Write("║");
            }
            Console.Write("╚");
            for (int j = 0; j < (Console.WindowWidth - 2); j++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
        }
    }
}
