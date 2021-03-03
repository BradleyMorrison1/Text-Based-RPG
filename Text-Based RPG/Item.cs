using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Item
    {
        string icon;
        ConsoleColor iconColor;

        public int x;
        public int y;

        public int itemType;

        public int value;

        public bool pickedUp = false;

        public const int ITEM_HEALTH = 0;
        public const int ITEM_SHIELD = 1;
        public const int ITEM_SWORD = 2;

        public Item(int thisItemType, int thisX, int thisY)
        {
            itemType = thisItemType;
            x = thisX;
            y = thisY;
        }

        public void Update(Player player)
        {
            if (pickedUp) return;

            ItemType();
            

            if (player.x == x && player.y == y) pickedUp = true;
        }

        public void ItemType()
        {
            switch (itemType)
            {
                case ITEM_HEALTH:
                    icon = "+";
                    iconColor = ConsoleColor.Green;
                    value = 50;
                    break;

                case ITEM_SHIELD:
                    icon = "*";
                    iconColor = ConsoleColor.Blue;
                    value = 50;
                    break;

                case ITEM_SWORD:
                    icon = "/";
                    iconColor = ConsoleColor.DarkGray;
                    value = 2;
                    break;
            }
        }
        public void Draw()
        {
            Console.ForegroundColor = iconColor;
            Console.SetCursorPosition(x, y);
            Console.Write(icon);
            Console.ResetColor();
        }
    }
}
