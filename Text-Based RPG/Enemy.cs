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
            maxHealth = 50;
            health = maxHealth;
            maxShield = 50;
            shield = maxShield;
            damageMult = 3;

            // Starting Position
            x = 50;
            y = 5;

            name = "Enemy";
            avatar = "0";
            avatarColor = ConsoleColor.Red;
        }

        public void Update(Player player)
        {
            if (isDead) return;
            isAttacking = false;
            if (((x + y) - (player.x + player.y)) < 5) ShowHud();
            Move(player.x, player.y, Map.map);
            Attack(player.x, player.y);
            Draw();
            if (health <= 0)
            {
                isDead = true;
                Console.Clear();
                return;
            }
        }

        public void Move(int playerX, int playerY, char[,] map)
        {
            int enemyXY = x + y;  
            int playerXY = playerX + playerY;
            int playerDistance = enemyXY - playerXY;

            int moveType = 0;


            switch (moveType)
            {
                case 0:
                if (playerDistance > 5) // Enemy wanders
                {
                    moveChance = rand.Next(10);
                    switch (moveChance)
                        {
                            case 1:
                                x++;
                                if (map[x, y] != ' ' || playerX == x && playerY == y) x--;
                                break;

                            case 2:
                                x--;
                                if (map[x, y] != ' ' || playerX == x && playerY == y) x++;
                                break;

                            case 3:
                                y++;
                                if (map[x, y] != ' ' || playerX == x && playerY == y) y--;
                                break;

                            case 4:
                                y--;
                                if (map[x, y] != ' ' || playerX == x && playerY == y) y++;
                                break;
                        }
                    }
                else if (moveChance < 5) // Makes the enemy move at player every other turn
                {
                    // moves enemy toward player
                    if (x != playerX)
                    {
                        if (playerX > x)
                        {
                            x++;
                            if (map[x, y] != ' ' || playerX == x && playerY == y) x--;
                        }
                        else
                        {
                            x--;
                            if (map[x, y] != ' ' || playerX == x && playerY == y) x++;
                        }
                    }

                    if (y != playerY)
                    {
                        if (playerY > y) 
                        {
                            y++;
                            if (map[x, y] != ' ' || playerX == x && playerY == y) y--;
                        }
                        else
                        {
                            y--;
                            if (map[x, y] != ' ' || playerX == x && playerY == y) y++;
                        }
                    }
                }
                break;


            }
            

        }
        public void ShowHud()
        {
            RangeCheckHealth();
            string enemyHUD = ("| " + name + " |  Health: " + health + " |  Shield: " + shield + " |");
            Console.SetCursorPosition((Console.WindowWidth - enemyHUD.Length - 1), Console.WindowHeight - 1);
            Console.ForegroundColor = avatarColor;
            Console.Write(enemyHUD);
            Console.ResetColor();
        }
    }
}
