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
        Enemy enemy1 = new Enemy(0, "Enemy 1", "0");
        Enemy enemy2 = new Enemy(1, "Enemy 2", "&");
        Enemy enemy3 = new Enemy(2, "Enemy 3", ".");
        Map map = new Map();
        Item healthPack = new Item(Item.ITEM_HEALTH, 40, 14);
        Item shield = new Item(Item.ITEM_SHIELD, 45, 16);
        Item sword = new Item(Item.ITEM_SWORD, 5, 2);

        public void Game()
        {
            Console.CursorVisible = false;

            healthPack.Update(player);
            shield.Update(player);
            sword.Update(player);
            
            player.Update(enemy1, enemy2, enemy3, healthPack, shield, sword);
            if (player.isAttacking && (player.x + 1) == enemy1.x && player.y == enemy1.y) enemy1.BeAttacked(player.AttackDamage());
            else if (player.isAttacking && (player.x - 1) == enemy1.x && player.y == enemy1.y) enemy1.BeAttacked(player.AttackDamage());
            else if (player.isAttacking && (player.y + 1) == enemy1.y && player.x == enemy1.x) enemy1.BeAttacked(player.AttackDamage());
            else if (player.isAttacking && (player.y - 1) == enemy1.y && player.x == enemy1.x) enemy1.BeAttacked(player.AttackDamage());

            if (player.isAttacking && (player.x + 1) == enemy2.x && player.y == enemy2.y) enemy2.BeAttacked(player.AttackDamage());
            else if (player.isAttacking && (player.x - 1) == enemy2.x && player.y == enemy2.y) enemy2.BeAttacked(player.AttackDamage());
            else if (player.isAttacking && (player.y + 1) == enemy2.y && player.x == enemy2.x) enemy2.BeAttacked(player.AttackDamage());
            else if (player.isAttacking && (player.y - 1) == enemy2.y && player.x == enemy2.x) enemy2.BeAttacked(player.AttackDamage());

            if (player.isAttacking && (player.x + 1) == enemy3.x && player.y == enemy3.y) enemy3.BeAttacked(player.AttackDamage());
            else if (player.isAttacking && (player.x - 1) == enemy3.x && player.y == enemy3.y) enemy3.BeAttacked(player.AttackDamage());
            else if (player.isAttacking && (player.y + 1) == enemy3.y && player.x == enemy3.x) enemy3.BeAttacked(player.AttackDamage());
            else if (player.isAttacking && (player.y - 1) == enemy3.y && player.x == enemy3.x) enemy3.BeAttacked(player.AttackDamage());

            enemy1.Update(player);
            if (enemy1.isAttacking) player.BeAttacked(enemy1.AttackDamage());
            
            enemy2.Update(player);
            if (enemy2.isAttacking) player.BeAttacked(enemy2.AttackDamage());

            enemy3.Update(player);
            if (enemy3.isAttacking) player.BeAttacked(enemy3.AttackDamage());


            map.Draw();
            healthPack.Draw();
            shield.Draw();
            sword.Draw();
            enemy1.Draw();
            enemy2.Draw();
            enemy3.Draw();
            player.Draw();
        }
    }
}
