using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Prime_Manager
{
    public class Item
    {
        public string Name { get; set; }
        public int Id { get; set; }
        /*
         * 0 - Warframe
         * 1 - Primary
         * 2 - Secondary
         * 3 - Melee
         * 4 - Sentinel
         * 5 - Odonata
         * 6 - Misc
         */
        public int Type { get; set; }
        public bool Constructed { get; set; }
        public bool Vaulted { get; set; }
        public IList<Part> Parts { get; set; }

        public class Part
        {
            public string Name { get; set; }
            public int ItemId { get; set; }
            public int PartId { get; set; }
            /*
             * 0 - Common
             * 1 - Uncommon
             * 2 - Rare
             */
            public int Rarity { get; set; }
            public int Needed { get; set; }
            public int Have { get; set; }


            public static void More(Item.Part part, Label label)
            {
                Debug.WriteLine("More");
                part.Have = part.Have + 1;
                label.Text = "Have: " + part.Have + "/" + part.Needed;
            }

            public static void Less(Item.Part part, Label label)
            {
                Debug.WriteLine("Less");
                part.Have = part.Have - 1;
                label.Text = "Have: " + part.Have + "/" + part.Needed;
            }
        }

        public static void Craft(Item item, Label label)
        {
            item.Constructed = !item.Constructed;

            label.Text = "Vaulted: " + item.Vaulted.ToString() + "     Constructed: " + item.Constructed.ToString();
        }

        public static Item FindById(int id)
        {
            Item item = Storage.Items.Find(x => x.Id == id);

            return item;
        }

        public static Item FindByName(string name)
        {
            Item item = Storage.Items.Find(x => x.Name == name);

            return item;
        }

        public static IList<Item> FindByType(int id)
        {
            IList<Item> items = new List<Item>();

            foreach(Item item in Storage.Items)
            {
                if (item.Type == id) { items.Add(item); }
            }

            return items;
        }

        public static IList<Item> FindConstructed()
        {
            IList<Item> items = new List<Item>();

            foreach (Item item in Storage.Items)
            {
                if (item.Constructed) { items.Add(item); }
            }

            return items;
        }

        public static IList<Item> FindNotConstructed()
        {
            IList<Item> items = new List<Item>();

            foreach (Item item in Storage.Items)
            {
                if (!item.Constructed) { items.Add(item); }
            }

            return items;
        }

        public static IList<Item> FindVaulted()
        {
            IList<Item> items = new List<Item>();

            foreach (Item item in Storage.Items)
            {
                if (item.Vaulted) { items.Add(item); }
            }

            return items;
        }

        public static IList<Item> FindNotVaulted()
        {
            IList<Item> items = new List<Item>();

            foreach (Item item in Storage.Items)
            {
                if (!item.Vaulted) { items.Add(item); }
            }

            return items;
        }
    }
}
