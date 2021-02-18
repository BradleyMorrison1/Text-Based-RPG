using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : GameCharacter
    {
        public int moveChance; // Used to decide if enemy will move

        public Enemy()
        {
            // Variable Initalization
            maxHealth = 100;
            health = maxHealth;
            damageMult = 4;

            name = "Enemy";
            avatarColor = ConsoleColor.Red;
        }

        public void Move(int playerX, int playerY)
        {
            int enemyXY = x + y;  
            int playerXY = playerX + playerY;
            int playerDistance = enemyXY - playerXY;

            moveChance = rand.Next(5) + 1;

            if (playerDistance > 3)
            {
                if (moveChance == 3)
                {
                    x += rand.Next(3);
                }
                else if (moveChance == 4)
                {
                    y += rand.Next(3);
                }
            }
            else if (moveChance == 1 || moveChance == 2) // Makes the enemy not move at player every turn
            {
                // moves enemy toward player
                if (x != playerX)
                {
                    if (playerX > x) x++;
                    else x--;
                }
                if (y != playerY)
                {
                    if (playerY > y) y++;
                    else y--;
                }
            }

        }
        public void ShowHud()
        {
            string enemyHUD = ("| " + name + " |  Health: " + health + " |");
            Console.SetCursorPosition((Console.WindowWidth - enemyHUD.Length - 1), Console.WindowHeight - 2);
            Console.ForegroundColor = avatarColor;
            Console.Write(enemyHUD);
            Console.ResetColor();
        }
    }
}
