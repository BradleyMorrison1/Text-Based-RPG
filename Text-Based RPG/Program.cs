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
                map.Draw();
                enemy.Draw();
                player.Draw();

                player.ShowHud();
                enemy.ShowHud();


                player.Move(enemy.x, enemy.y, Map.map);
                if (player.isAttacking) enemy.BeAttacked(player.AttackDamage());

                enemy.Move(player.x, player.y, Map.map);
                if (enemy.isAttacking) player.BeAttacked(enemy.AttackDamage());

                Console.Clear();
                player.Draw();
                enemy.Draw();
            }
        }
    }
}
