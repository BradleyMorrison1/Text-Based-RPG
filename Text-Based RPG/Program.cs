using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            Player player = new Player();
            Map map = new Map();


            // --------------------------- Game Loop 
            while(isRunning)
            {
                // ----------------- Map 
                // map.DrawBorder(); Needs Work

                // ----------------- Player 
                player.MovePlayer();
                Console.Clear();
                player.DrawCharacter();
            }
        }
    }
}
