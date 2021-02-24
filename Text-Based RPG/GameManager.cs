    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GameManager
    {

        Player player = new Player();
        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();
        Enemy enemy3 = new Enemy();
        Map map = new Map();
        Item healthPack = new Item();
        Item shield = new Item();
        Item sword = new Item();

        public void Game()
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


            enemy1.moveType = 0;
            enemy1.name = "Enemy 1";
            enemy1.avatar = "0";
            enemy1.Update(player);
            if (enemy1.isAttacking) player.BeAttacked(enemy1.AttackDamage());

            enemy2.moveType = 1;
            enemy2.name = "Enemy 2";
            enemy2.avatar = "&";
            enemy2.Update(player);
            if (enemy2.isAttacking) player.BeAttacked(enemy2.AttackDamage());

            enemy3.moveType = 2;
            enemy3.name = "Enemy 3";
            enemy3.avatar = ".";
            enemy3.Update(player);
            if (enemy3.isAttacking) player.BeAttacked(enemy3.AttackDamage());

            player.Update(enemy1, enemy2, enemy3, healthPack, shield, sword);
            if (player.isAttacking) enemy1.BeAttacked(player.AttackDamage());
        }
    }
}
