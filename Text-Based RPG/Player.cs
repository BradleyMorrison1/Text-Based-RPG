using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player : GameCharacter
    {


        public Player()
        {
            // Starting Position
            x = 1;
            y = 1;
            // Variable initalization
            maxHealth = 100;
            health = maxHealth;
            damageMult = 4;

            name = "Player";
            avatarColor = ConsoleColor.Cyan;
        }

        public void Update()
        {
        }

        public void Move(int enemyX, int enemyY, char[,] map)
        {
            while (Console.KeyAvailable) Console.ReadKey(false); // Adds a buffer to prevent stacked movement

            ConsoleKeyInfo userInput = Console.ReadKey(true);
            switch (userInput.KeyChar)
            {
                case 'w':
                    y--;
                    if (enemyX == x && enemyY == y) Attack();
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) y++;
                    break;

                case 's':
                    y++;
                    if (enemyX == x && enemyY == y) Attack();
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) y--;
                    break;

                case 'a':
                    x--;
                    if (enemyX == x && enemyY == y) Attack();
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) x++;
                    break;

                case 'd':
                    x++;
                    if (enemyX == x && enemyY == y) Attack();
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) x--;
                    break;
            }
        }

        public void ShowHud()
        {
            RangeCheckHealth();
            Console.SetCursorPosition(1, Console.WindowHeight - 1);
            Console.ForegroundColor = avatarColor;
            Console.Write("| " + name + " |  Health: " + health + " |");
            Console.ResetColor();
        }
    }
}
