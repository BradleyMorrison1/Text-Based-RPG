using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy
    {
        string enemyAvatar = "■";
        string enemyName = "";

        Random rand = new Random();

        public int enemyX = 10;
        public int enemyY = 5;

        public int maxHealth;
        public int health;
        public int damageMult; // Multiplier for damage

        public int moveChance; // Used to decide if enemy will move

        public Enemy()
        {
            // Variable Initalization
            maxHealth = 100;
            health = maxHealth;
            damageMult = 4;

            enemyName = "Enemy";
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(enemyX, enemyY);
            RangeCheckBorder();
            Console.Write(enemyAvatar);
            Console.ResetColor();
        }

        public void Move(int playerX, int playerY)
        {
            int enemyXY = enemyX + enemyY;  
            int playerXY = playerX + playerY;
            int playerDistance = enemyXY - playerXY;

            moveChance = rand.Next(5) + 1;

            if (playerDistance > 3)
            {
                if (moveChance == 3)
                {
                    enemyX += rand.Next(3);
                }
                else if (moveChance == 4)
                {
                    enemyY += rand.Next(3);
                }
            }
            else if (moveChance == 1 || moveChance == 2) // Makes the enemy not move at player every turn
            {
                // moves enemy toward player
                if (enemyX != playerX)
                {
                    if (playerX > enemyX) enemyX++;
                    else enemyX--;
                }
                if (enemyY != playerY)
                {
                    if (playerY > enemyY) enemyY++;
                    else enemyY--;
                }
            }
        }
        private void RangeCheckBorder()
        {
            if (enemyX <= 0) enemyX++;
            if (enemyY <= 0) enemyY++;
        }

        public int Attack(int externalHealth)
        {
            int damagedHealth;
            damagedHealth = externalHealth - (rand.Next(10) * damageMult);
            return damagedHealth;
        }
        public void ShowHud()
        {
            string enemyHUD = ("| " + enemyName + " |  Health: " + health + " |");
            Console.SetCursorPosition((Console.WindowWidth - enemyHUD.Length), Console.WindowHeight);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(enemyHUD);
            Console.ResetColor();
        }
        public void RangeCheck()
        {
            if (health <= 0) health = 0;
            if (health >= maxHealth) health = maxHealth;
        }
    }
}
