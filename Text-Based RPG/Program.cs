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

            //map.Draw();
            //player.Draw();
            //enemy.Draw();
            // --------------------------- Game Loop 
            while(isRunning)
            {
                map.Draw();

                enemy.Draw();
                player.Update(enemy);
                if (player.isAttacking) enemy.BeAttacked(player.AttackDamage());

                enemy.Update(player);
                if (enemy.isAttacking) player.BeAttacked(enemy.AttackDamage());
            }
        }
    }
}
