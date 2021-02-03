using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player
    {
        string playerAvatar = "■";

        public int playerX = Console.CursorLeft;
        public int playerY = Console.CursorTop;

        public Player()
        {
            
        }

        public void DrawCharacter()
        {
            Console.SetCursorPosition(playerX, playerY);
            RangeCheckBorder();
            Console.Write(playerAvatar);
        }

        public void MovePlayer()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            switch (userInput.KeyChar)
            {
                case 'w':
                    playerY--;
                    break;

                case 's':
                    playerY++;
                    break;

                case 'a':
                    playerX--;
                    break;

                case 'd':
                    playerX++;
                    break;
            }
        }

        private void RangeCheckBorder()
        {
            if (playerX <= 0) playerX++;
            if (playerY <= 0) playerY++;
        }
    }
}
