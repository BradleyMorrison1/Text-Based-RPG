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
            Item healthPack = new Item();
            Item shield = new Item();
            Item sword = new Item();

            //map.Draw();
            //player.Draw();
            //enemy.Draw();
            // --------------------------- Game Loop 
            while(isRunning)
            {
                map.Draw();

                healthPack.itemType = Item.ITEM_HEALTH;
                healthPack.x = 40;
                healthPack.y = 14;
                healthPack.Update(player);

                shield.itemType = Item.ITEM_SHIELD;
                shield.x = 45;
                shield.y = 16;
                shield.Update(player);

                sword.itemType = Item.ITEM_SWORD;
                sword.x = 5;
                sword.y = 2;
                sword.Update(player);


                enemy.Update(player);
                if (enemy.isAttacking) player.BeAttacked(enemy.AttackDamage());


                player.Update(enemy, healthPack, shield, sword);
                if (player.isAttacking) enemy.BeAttacked(player.AttackDamage());
            }
        }
    }
}
