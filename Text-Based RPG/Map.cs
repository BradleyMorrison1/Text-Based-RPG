using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Map
    {
        public Map()
        {

        }
        public void DrawBorder()
        {
            // Draws Top Border
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("═");
            }
        }
    }
}
