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

        public int x = Console.CursorLeft;
        public int y = Console.CursorTop;

        public int maxHealth;
        public int health;
        public int damageMult; // Multiplier for damage

        public void Draw()
        {

            Console.ForegroundColor = avatarColor; 
            Console.SetCursorPosition(x, y);
            RangeCheckBorder();
            Console.Write(avatar);
            Console.ResetColor();
        }

        private void RangeCheckBorder()
        {
            if (x <= 1) x++;
            if (y <= 1) y++;
            if (y >= (Console.WindowHeight - 6)) y--;
        }

        

        public void RangeCheckHealth()
        {
            if (health <= 0) health = 0;
            if (health >= maxHealth) health = maxHealth;
        }

        public int Attack(int externalHealth)
        {
            int damagedHealth;
            damagedHealth = externalHealth - (rand.Next(10) * damageMult);
            return damagedHealth;
        }
    }
}
