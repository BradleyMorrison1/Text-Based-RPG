using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class GameCharacter
    {
        string avatar = "■";
        protected string name = "";
        protected ConsoleColor avatarColor;

        public bool isAttacking = false;

        protected Random rand = new Random();

        public int x;
        public int y;

        public int maxHealth;
        public int health;
        public int damageMult; // Multiplier for damage

        public void Draw()
        {
            Console.ForegroundColor = avatarColor;
            RangeCheckWindowBorder();
            Console.SetCursorPosition(x, y);
            Console.Write(avatar);
            Console.ResetColor();
        }

        public void RangeCheckWindowBorder()
        {
            if (x <= 0) x++;
            else if (y <= 0) y++;
        }

        public void RangeCheckHealth()
        {
            if (health <= 0) health = 0;
            if (health >= maxHealth) health = maxHealth;
        }

        public int AttackDamage()
        {
            int damage = 0;
            damage = rand.Next(6) * damageMult;
            return damage;
        }
        public void BeAttacked(int damage)
        {
            health -= damage;
        }

        public void Attack(int opponentX, int opponentY)
        {
            //isAttacking = true;




            if (opponentX == (x + 1) && opponentY == y) isAttacking = true;
            else if (opponentX == (x - 1) && opponentY == y) isAttacking = true;
            else if (opponentY == (y + 1) && opponentX == x) isAttacking = true;
            else if (opponentY == (y - 1) && opponentX == x) isAttacking = true;
        }
    }
}
