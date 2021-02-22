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
            bool playerAttacked = false;

            Player player = new Player();
            Enemy enemy = new Enemy();
            Map map = new Map();

            //map.DrawBorder();
            map.Draw();
            player.Draw();
            enemy.Draw();
            // --------------------------- Game Loop 
            while(isRunning)
            {
                //map.DrawBorder();
                map.Draw();
                enemy.Draw();
                player.Draw();
                player.ShowHud();
                enemy.ShowHud();
                player.Move();
                if (player.x == enemy.x && player.y == enemy.y)
                {
                    int newHealth = player.Attack(enemy.health);
                    enemy.health = newHealth;
                    playerAttacked = true;
                }
                enemy.Move(player.x, player.y);
                if (player.x == enemy.x && player.y == enemy.y && !playerAttacked) // Attacks if player and enemy are on top of each other
                {
                    int newHealth = enemy.Attack(player.health);
                    player.health = newHealth;
                    player.RangeCheckHealth();
                }
                playerAttacked = false;
                Console.Clear();
                enemy.Draw();
                player.Draw();
            }
        }
    }
}
