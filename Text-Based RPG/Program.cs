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
            bool enemyAttacked = false;

            Player player = new Player();
            Enemy enemy = new Enemy();
            Map map = new Map();

            map.Draw();
            player.Draw();
            enemy.Draw();
            // --------------------------- Game Loop 
            while(isRunning)
            {
                player.ShowHud();
                enemy.ShowHud();
                enemy.Move(player.playerX, player.playerY);
                if (player.playerX == enemy.enemyX && player.playerY == enemy.enemyY && !enemyAttacked) // Attacks if player and enemy are on top of each other
                {
                    int newHealth = enemy.Attack(player.health);
                    player.health = newHealth;
                    player.RangeCheck();
                    enemyAttacked = true;
                }
                player.Move();
                if (player.playerX == enemy.enemyX && player.playerY == enemy.enemyY)
                {
                    int newHealth = player.Attack(enemy.health);
                    enemy.RangeCheck();
                    enemy.health = newHealth;
                }
                enemyAttacked = false;
                Console.Clear();
                map.Draw();
                enemy.Draw();
                player.Draw();
            }
        }
    }
}
