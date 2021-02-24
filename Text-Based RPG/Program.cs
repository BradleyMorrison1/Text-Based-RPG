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

            GameManager gameManager = new GameManager();

            // --------------------------- Game Loop 
            while(isRunning)
            {
                gameManager.Game();
            }
        }
    }
}
