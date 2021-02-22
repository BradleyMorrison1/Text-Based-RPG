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

        public int Attack()
        {
            int damage = 0;
            damage = rand.Next(6) * damageMult;
            return damage;
        }
        public void BeAttacked(int damage)
        {
            health -= damage;
        }
    }
}
