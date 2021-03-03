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
        public int moveType;

        private bool firstRun = false;


        public Enemy(int thisMoveType, string thisName, string thisAvatar)
        {
            moveType = thisMoveType;
            name = thisName;
            avatar = thisAvatar;

            // Variable Initalization
            maxHealth = 50;
            health = maxHealth;
            maxShield = 50;
            shield = maxShield;
            damageMult = 3;

            avatarColor = ConsoleColor.Red;
        }

        public void Update(Player player)
        {
            if (isDead) return;
            isAttacking = false;
            Move(player.x, player.y, Map.map);
            if (x - player.x < 5 && y - player.y < 5) ShowHud();
            Attack(player.x, player.y);
            if (health <= 0)
            {
                isDead = true;
                x = 40;
                y = 0;
                avatar = "";
                return;
            }
        }

        public void Move(int playerX, int playerY, char[,] map)
        {
            int enemyXY = x + y;  
            int playerXY = playerX + playerY;
            int playerDistance = enemyXY - playerXY;



            switch (moveType)
            {
                case 0: // Enemy Wanders then chases player
                    // Starting Position
                    if (!firstRun) // only sets x and y on start
                    {
                        x = 50;
                        y = 5;
                        firstRun = true;
                    }
                   
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

                case 1: // Enemy wanders

                    if (!firstRun) // only sets x and y on start
                    {
                        x = 12;
                        y = 45;
                        firstRun = true;
                    }

                    moveChance = rand.Next(4);
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
                    break;

                case 2: // enemy chases player

                    if (!firstRun)
                    {
                        x = 50;
                        y = 51;
                        firstRun = true;
                    }
                    
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

                    else if (y != playerY)
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
