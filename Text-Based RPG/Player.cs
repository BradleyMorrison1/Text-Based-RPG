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

        Random rand = new Random();

        public int playerX = Console.CursorLeft;
        public int playerY = Console.CursorTop;

        public int maxHealth;
        public int health;
        public int damageMult; // Multiplier for damage

        public Player()
        {
            // Starting Position
            playerX = 1;
            playerY = 1;
            // Variable initalization
            maxHealth = 100;
            health = maxHealth;
            damageMult = 4;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(playerX, playerY);
            RangeCheckBorder();
            Console.Write(playerAvatar);
            Console.ResetColor();
        }

        public void Move()
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

        public int Attack(int externalHealth)
        {
            int damagedHealth;
            damagedHealth = externalHealth - (rand.Next(10) * damageMult);
            return damagedHealth;
        }

        public void ShowHud()
        {
            Console.SetCursorPosition(0, Console.WindowHeight);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("| Health: " + health + " |");
            Console.ResetColor();
        }

        public void RangeCheck()
        {
            if (health <= 0) health = 0;
            if (health >= maxHealth) health = maxHealth;
        }
    }
}
