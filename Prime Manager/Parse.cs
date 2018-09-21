using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Warframe;
using IronOcr;
using Market;
using Nexus;

namespace Prime_Manager
{
    class Parse
    {
        #region JSON to Data
        public static void JsonData(string filepath)
        {
            Debug.WriteLine("Parsing from Jsaon");

            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd();

                JObject jobj = JObject.Parse(json);

                #region Get all item data
                foreach (var ItemData in jobj["PrimeItems"])
                {
                    Item item = new Item();

                    item.Name = ItemData["Name"].ToString();
                    item.Id = Int32.Parse(ItemData["Id"].ToString());
                    item.Type = Int32.Parse(ItemData["Type"].ToString());
                    item.Vaulted = Convert.ToBoolean(ItemData["Vaulted"].ToString());
                    item.Constructed = Convert.ToBoolean(ItemData["Constructed"].ToString());

                    item.Parts = new List<Item.Part>();

                    foreach (var PartData in ItemData["Parts"])
                    {
                        
                        Item.Part part = new Item.Part();

                        part.Name = PartData["Name"].ToString();
                        part.PartId = Int32.Parse(PartData["PartId"].ToString());
                        part.ItemId = Int32.Parse(PartData["ItemId"].ToString());
                        part.Have = Int32.Parse(PartData["Have"].ToString());
                        part.Rarity = Int32.Parse(PartData["Rarity"].ToString());
                        part.Needed = Int32.Parse(PartData["Needed"].ToString());

                        item.Parts.Add(part);
                    }

                    Storage.Items.Add(item);
                }
                #endregion

                #region Get all relic data
                foreach (var ReliCData in jobj["Relics"])
                {
                    Relic relic = new Relic();

                    relic.Name= ReliCData["Name"].ToString();
                    relic.Id = Int32.Parse(ReliCData["Id"].ToString());
                    relic.Tier = Int32.Parse(ReliCData["Tier"].ToString());
                    relic.Vaulted = Convert.ToBoolean(ReliCData["Vaulted"].ToString());
                    relic.Have = Int32.Parse(ReliCData["Have"].ToString());

                    relic.Parts = new List<Item.Part>();

                    foreach (var PartData in ReliCData["Parts"])
                    {
                        Item.Part part = new Item.Part();

                        part.Name = PartData["Name"].ToString();
                        part.PartId = Int32.Parse(PartData["PartId"].ToString());
                        part.ItemId = Int32.Parse(PartData["ItemId"].ToString());
                        part.Have = Int32.Parse(PartData["Have"].ToString());
                        part.Rarity = Int32.Parse(PartData["Rarity"].ToString());
                        part.Needed = Int32.Parse(PartData["Needed"].ToString());

                        relic.Parts.Add(part);
                    }

                    Storage.Relics.Add(relic);
                }
                #endregion
            }
        }
        #endregion

        #region Text to Data
        public static void TxtData(string filepath)
        {
            Debug.WriteLine("Parsing from txt");


            string file = File.ReadAllText(filepath);


            List<string> words = new List<string>();

            foreach (string word in file.Split(Convert.ToChar(" "))) {words.Add(word); }

            for (int i = 0; i < words.Count; )
            {
                //If the prime item name is in one part
                if (words[i + 1] == "Prime")
                {
                    //Create a part
                    Item item = new Item();

                    item.Name = words[i];
                    item.Id = Storage.Items.Count;
                    item.Constructed = false;
                    item.Vaulted = false;
                    item.Type = 777;

                    i = i + 2;

                    item.Parts = new List<Item.Part>();

                    //Parse trough all the parts
                    do
                    {
                        Item.Part part = new Item.Part();

                        if (Storage.Tiers.IndexOf(words[i + 3]) != -1)
                        {
                            part.Name = words[i] + " " + words[i + 1] + " " + words[i + 2];
                            i = i + 3;
                        } else if (Storage.Tiers.IndexOf(words[i + 2]) != -1)
                        {
                            part.Name = words[i] +" "+ words[i+1];
                            i = i + 2;
                        } else if (Storage.Tiers.IndexOf(words[i + 1]) != -1)
                        {
                            part.Name = words[i];
                            i++;
                        }


                        part.ItemId = item.Id;
                        part.Have = 0;
                        
                        part.Rarity = Storage.Rarities.IndexOf(words[i + 2]);
                        part.Needed = 1;
                        try { part.PartId = item.Parts.Count; } catch (InvalidCastException) { part.PartId = 0; }

                        item.Parts.Add(part);


                        #region Add all the relics
                        do
                        {
                            Relic relic = new Relic();

                            #region if the relic dosen't exists
                            if (Storage.Relics.Find(x => x.Name.Contains(words[i + 1]) && x.Tier == Storage.Tiers.IndexOf(words[i])) == null)
                            {                               
                                relic.Name = words[i + 1];

                                try { relic.Id = Storage.Relics.Count; } catch (InvalidCastException) { relic.Id = 0; }

                                relic.Tier = Storage.Tiers.IndexOf(words[i]);

                                relic.Parts = new List<Item.Part>();
                                relic.Parts.Add(part);
                            }
                            #endregion
                            #region If the relic does exists
                            else
                            {
                                relic = Storage.Relics.Find(x => x.Name.Contains(words[i + 1]) && x.Tier == Storage.Tiers.IndexOf(words[i]));
                                Storage.Relics.Remove(relic);
                                relic.Parts.Add(part);
                            }
                            #endregion

                            relic.Have = 0;

                            try
                            {
                                if (words[i + 3] != "(V)")
                                {
                                    //If relic is not vaulted
                                    relic.Vaulted = false;
                                    i = i + 3;
                                }
                                else
                                {
                                    //if relic is vaulted
                                    relic.Vaulted = true;
                                    i = i + 4;
                                }
                            } catch(ArgumentException)
                            {
                                relic.Vaulted = true;
                                i = i + 4;
                            }


                            Storage.Relics.Add(relic);

                            try
                            {
                                if (Storage.Tiers.IndexOf(words[i]) == -1)
                                {
                                    break;
                                }
                            } catch (ArgumentException)
                            {
                                break;
                            }


                        } while (true);
                        #endregion

                        try
                        {

                            if (words[i + 1] == "Prime")
                            {
                                break;
                            }
                        }
                        catch (ArgumentException)
                        {
                            break;
                        }
                        
                    } while (true);


                    Storage.Items.Add(item);             
                }
            }
        }
        #endregion

        #region Data to Json
        public static void DataJson(string filepath)
        {
            Debug.WriteLine("DataJson");

            Storage.Json Data = new Storage.Json();

            Data.PrimeItems = new List<Item>();
            Data.Relics = new List<Relic>();

            Data.PrimeItems = Storage.Items;
            Data.Relics = Storage.Relics;

            File.WriteAllText(filepath, JsonConvert.SerializeObject(Data));
        }
        #endregion

        #region Get Primes & Relics from DE
        public static void getPrimeFromDE()
        {
            foreach(warframe Warframe in warframe.Get("PRIME"))
            {
                warframe.DumpDebug(Warframe);

                Item item = new Item()
                {
                    Type = Storage.Types.IndexOf(Warframe.Type),
                    Id = Storage.Items.Count,
                    Constructed = false,
                    Vaulted = false,
                    Parts = new List<Item.Part>()
                };

                char Last = new char();

                foreach(char character in Warframe.Name)
                {                    
                    if (Last.ToString() == "" || char.IsWhiteSpace(Last))
                    {
                        item.Name += char.ToUpper(character).ToString();                        
                    }

                    Last = character;
                }
            }

            IList<weapon> weaponList = weapon.Get("PRIME");
            IList<relic> relicList = relic.Get();
        }
        #endregion

        #region Get Market data
        public static Item GetMarket(Item item) {

            Parallel.ForEach(Item.Part, item (partData, item) => {
                Ilist<order> MarketData = Market.order.GetItemOrders(item.Name, partData.Name);

                IList<ushort> Prices = new Ilist<ushort>(); 

                Parallel.ForEach(MarketData, marketData  => {

                    if (marketData.User.Status != "ingame") { return };
                    
                    for (byte i = 0; i < marketData.quantity; i++) {
                        Prices.Add(marketData.Prices);
                    }
                });

                Prices = Prices.OrderBy(i => i);

                partData.Market = new Item.Market() {
                    MinPrice = Prices[0],
                    MaxPrice = Prices[Prices.Count]
                };
                
                if ( Prices[Prices.Count / 2]%2 == 0 ) {
                    partData.Market.Median = (Prices[Prices.Count / 2] + Prices[Prices.Count / 2 + 1]) / 2;
                } else {
                    partData.Market.Median = Prices[Prices.Count / 2];
                }
            });

            return item;
        }
        #endregion

        #region Get Nexus data
        public static Item getNexus(Item item) {
            nexus = nexus.GetPrimeStatistics(item.Name);

            Parallel.foreach(item, nexus.Components ,(item, component) => {
                part = item.Parts.Find(x => x.Name == component.Name);

                part.Nexus == new part.nexus();

                part.Nexus.Buying == new part.nexus.values(){
                    median = component.Buying.Median,
                    max = component.Buying.Max,
                    min = component.Buying.Min
                };

                part.Selling.Buying == new part.nexus.values(){
                    median = component.Selling.Median,
                    max = component.Selling.Max,
                    min = component.Selling.Min
                };
            });

            return item;
        }
        #endregion

        #region Read image data
        public static void ReadImage(string application = "Warframe.x64")
        {
            /*
            Process proc;

            try
            {
                proc = Process.GetProcessesByName(application)[0];
            } catch (IndexOutOfRangeException error)
            {
                return ";
            }

            var rect = new User32.Rect();
            User32.GetWindowRect(proc.MainWindowHandle, ref rect);
                        
            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            Bitmap bmp;

            try
            {
                bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            } catch (ArgumentException error) {
                return "Something wrong with the window";
            }
                        
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            */
            var Ocr = new AutoOcr();

            OcrResult result = Ocr.Read("http://images.akamai.steamusercontent.com/ugc/177160601660790984/75EC368F67FE5E0E0C3A2AEA20B1D49D1F79ACDF/");

            string[] TextInImage = result.ToString().Split(" ");

            TextInImage = TextInImage.Select(x => x.ToLowerInvariant());

            if (TextInImage.Contains("Select") && TextInImage.Contains("Reward")) {
                Debug.WriteLine("Select a Reward");
                
                GameData gameData = new GameData(){
                    Event = 0,
                    partsFound = new List<Item.Part>(),
                }

                Item.Part[] Parts = new Item.Part[](); 

                for (int i = 0; i < values.Count; i++) {
                    if (values[i].ToLower() == "prime") {
                        Item item = Storage.Items.Find(x => x.Name == values[0 - 1]);
                        Item.Part part = item.Parts.Find(x => x.Name == values[0 + 1]);

                        if (gameData.partsFound.Any(x => x.Id == part.Id)) {
                            partsFound.YouPick = part;

                            continue;
                        } else {
                            gameData.partsFound.Add(part);

                            continue;
                        }                      
                        
                    } else if (values[i].ToLower() == "form") {
                        Item.Part part = new Item.Part() {
                            Name = forma
                        };

                        gameData.partsFound.Add(part);
                    }
                }

                Debug.WriteLine("Items Found: ")
                foreach(Item.Part item in gameData.partsFound) {
                    Debug.WriteLine("Name: "+item.Name);
                }

                GameData.SuccessHandler(gameData);

            } else if (TextInImage.Contains("mission") && TextInImage.Contains("complete")) {
                Debug.WriteLine("Mission Complete");
                
                GameData gameData = new GameData(){
                    Event = 1,
                    partsFound = new List<Item.Part>(),
                }

                Item.Part[] Parts = new Item.Part[](); 

                for (int i = 0; i < values.Count; i++) {
                    if (values[i].ToLower() == "prime") {
                        Item item = Storage.Items.Find(x => x.Name == values[0 - 1]);
                        Item.Part part = item.Parts.Find(x => x.Name == values[0 + 1]);

                        if (gameData.partsFound.Any(x => x.Id == part.Id)) {
                            partsFound.YouPick = part;

                            continue;
                        } else {
                            gameData.partsFound.Add(part);

                            continue;
                        }                        
                    }
                }

                Debug.WriteLine("Items Found: ")
                foreach(Item.Part item in gameData.partsFound) {
                    Debug.WriteLine("Name: "+item.Name);

                GameData.SuccessHandler(gameData);
            }
        }

        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct Rect
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        }
        #endregion
    }
}

namespace Prime_Manager
{
    publi class GameData {
        // 0 - Nothing
        // 1 - Reward Selection
        // 2 - Mission Complete
        public byte Event { get; set; }
        public IList<Item.Part> partsFound { get; set; }
        public Item.Part YouPick { get; set; }

        public static void SuccessHandler(GameData gamedata) {
            switch (gameData.Event)
            {
                case 0: 
                    
                case 1:

                default:
                    throw new System.ArgumentException("Unknown case: "+gameData.Event);
            }
        }
    }
}