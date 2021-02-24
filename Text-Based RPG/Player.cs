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
            maxShield = 100;
            shield = maxShield;
            damageMult = 2;

            name = "Player";
            avatarColor = ConsoleColor.Cyan;
        }

        public void Update(Enemy enemy, Item healthPack, Item shield, Item sword)
        {
            if (isDead) return;
            isAttacking = false;
            Draw();
            ShowHud();
            Move(enemy.x, enemy.y, Map.map);
            PickUpItem(healthPack.itemType, healthPack.value, healthPack.x, healthPack.y);
            PickUpItem(shield.itemType, shield.value, shield.x, shield.y);
            PickUpItem(sword.itemType, sword.value, sword.x, sword.y);
            Attack(enemy.x, enemy.y);
            Draw();
            if (health <= 0)
            {
                isDead = true;
                return;
            }
        }

        public void Move(int enemyX, int enemyY, char[,] map)
        {
            while (Console.KeyAvailable) Console.ReadKey(false); // Adds a buffer to prevent stacked movement

            ConsoleKeyInfo userInput = Console.ReadKey(true);
            switch (userInput.KeyChar)
            {
                case 'w':
                    y--;
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) y++;
                    break;

                case 's':
                    y++;
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) y--;
                    break;

                case 'a':
                    x--;
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) x++;
                    break;

                case 'd':
                    x++;
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) x--;
                    break;
            }

            switch (userInput.Key)
            {
                case ConsoleKey.UpArrow:
                    y--;
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) y++;
                    break;

                case ConsoleKey.DownArrow:
                    y++;
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) y--;
                    break;

                case ConsoleKey.LeftArrow:
                    x--;
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) x++;
                    break;

                case ConsoleKey.RightArrow:
                    x++;
                    if (map[x, y] != ' ' || enemyX == x && enemyY == y) x--;
                    break;
            }
        }

        public void ShowHud()
        {
            RangeCheckHealth();
            Console.SetCursorPosition(1, Console.WindowHeight - 1);
            Console.ForegroundColor = avatarColor;
            Console.Write("| " + name + " |  Health: " + health + " |  Shield: " + shield + " |");
            Console.ResetColor();
        }

        public void Heal(int healAmount)
        {
            health += healAmount;
        }

        public void RegenShield(int regenAmount)
        {
            shield += regenAmount;
        }

        public void DamageIncrease(int damIncrease)
        {
            damageMult += damIncrease;
        }

        public void PickUpItem(int itemType, int value, int itemX, int itemY)
        {
            if (itemX == x && itemY == y)
            {
                switch (itemType)
                {
                    case 0:
                        Heal(value);
                        break;

                    case 1:
                        RegenShield(value);
                        break;

                    case 2:
                        DamageIncrease(value);
                        break;
                }
            }
            
        }
    }
}
