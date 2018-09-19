using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Prime_Manager
{
    class Storage
    {
        public static settings Settings = new settings();
        public static List<Relic> Relics = new List<Relic>();
        public static List<Item> Items = new List<Item>();
        public static List<string> Types = new List<string>();
        public static List<string> Tiers = new List<string>();
        public static List<string> Rarities = new List<string>();
        public static string TxtFilepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString() + "/PrimeManagerToParse.txt";
        public static string JsonFilepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString() + "/Data.json";
        public static string Images = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString() + "/Images";

        public class Json
        {
            public IList<Item> PrimeItems { get; set; }
            public IList<Relic> Relics { get; set; }

        }

        public class settings {
            public bool StopTimer { get; set; }
        }

        public static void DumpRelics()
        {
            Debug.WriteLine("\"Relics\": [");
            foreach (Relic relic in Storage.Relics)
            {                
                Debug.WriteLine("   {");
                Debug.WriteLine("       \"Name\": " + relic.Name);
                Debug.WriteLine("       \"Id\": " + relic.Id);
                Debug.WriteLine("       \"Tier\": " + relic.Tier);
                Debug.WriteLine("       \"Vault\": " + relic.Vaulted);
                Debug.WriteLine("       \"Have\": " + relic.Have);
                Debug.WriteLine("       \"Parts\": ");
                foreach (Item.Part part in relic.Parts)
                {
                    Debug.WriteLine("       {");
                    Debug.WriteLine("           \"Name\": " + part.Name);
                    Debug.WriteLine("           \"Rarity\": " + part.Rarity);
                    Debug.WriteLine("           \"Needed\": " + part.Needed);
                    Debug.WriteLine("           \"Item ID\": " + part.ItemId);
                    Debug.WriteLine("           \"Part ID\": " + part.PartId);
                    Debug.WriteLine("           \"Have\": " + part.Have);
                    Debug.WriteLine("       }");
                }
                Debug.WriteLine("   }");
            }
            Debug.WriteLine("]");
        }

        public static void DumpItems()
        {
            Debug.WriteLine("\"Items\": [");
            foreach (Item item in Storage.Items)
            {                                
                Debug.WriteLine("   {");
                Debug.WriteLine("       \"Name\": " + item.Name);
                Debug.WriteLine("        \"Id\": " + item.Id);
                Debug.WriteLine("       \"Type\": " + item.Type);
                Debug.WriteLine("       \"Vault\": " + item.Vaulted);
                Debug.WriteLine("       \"Constructed\": " + item.Constructed);
                Debug.WriteLine("       \"Parts\": ");

                foreach (Item.Part part in item.Parts)
                {
                    Debug.WriteLine("       {");
                    Debug.WriteLine("           \"Name\": " + part.Name);
                    Debug.WriteLine("           \"Rarity\": " + part.Rarity);
                    Debug.WriteLine("           \"Needed\": " + part.Needed);
                    Debug.WriteLine("           \"Item ID\": " + part.ItemId);
                    Debug.WriteLine("           \"Part ID\": " + part.PartId);
                    Debug.WriteLine("           \"Have\": " + part.Have);
                    Debug.WriteLine("       }");
                }
                Debug.WriteLine("   }");
                Debug.WriteLine("}");
            }
            Debug.WriteLine("]");
        }

        public static void Initilize()
        {
            #region Add all types of items
            Types.Add("Warframe");
            Types.Add("Primary");
            Types.Add("Secondary");
            Types.Add("Melee");
            Types.Add("Sentinel");
            Types.Add("Archwing");
            Types.Add("Misc");

            //Debug.WriteLine("Item types: ");
            //foreach(string content in Types) { Debug.WriteLine("  "+content); }
            #endregion

            #region Relic tiers
            Tiers.Add("Lith");
            Tiers.Add("Meso");
            Tiers.Add("Neo");
            Tiers.Add("Axi");

            //Debug.WriteLine("Item types: ");
            //foreach (string content in Tiers) { Debug.WriteLine("  "+content); }
            #endregion

            #region Item rarities
            Rarities.Add("Common");
            Rarities.Add("Uncommon");
            Rarities.Add("Rare");

            //Debug.WriteLine("Item rarity: ");
            //foreach (string content in Rarities) { Debug.WriteLine("  "+content); }
            #endregion
        }
        
    }
}
