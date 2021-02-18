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

        public void Move()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            switch (userInput.KeyChar)
            {
                case 'w':
                    y--;
                    break;

                case 's':
                    y++;
                    break;

                case 'a':
                    x--;
                    break;

                case 'd':
                    x++;
                    break;
            }
        }

        public void ShowHud()
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 2);
            Console.ForegroundColor = avatarColor;
            Console.Write("| " + name + " |  Health: " + health + " |");
            Console.ResetColor();
        }

    }
}
