using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Newtonsoft.Json;

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
                        try { part.PartId = item.Parts.Count; } catch (InvalidCastException e) { part.PartId = 0; }

                        item.Parts.Add(part);


                        #region Add all the relics
                        do
                        {
                            Relic relic = new Relic();

                            #region if the relic dosen't exists
                            if (Storage.Relics.Find(x => x.Name.Contains(words[i + 1]) && x.Tier == Storage.Tiers.IndexOf(words[i])) == null)
                            {                               
                                relic.Name = words[i + 1];

                                try { relic.Id = Storage.Relics.Count; } catch (InvalidCastException e) { relic.Id = 0; }

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
                            } catch(ArgumentException e)
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
                            } catch (ArgumentException e)
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
                        catch (ArgumentException e)
                        {
                            break;
                        }
                        
                    } while (true);


                    Storage.Items.Add(item);             
                }
            }
        }
        #endregion

        #region Date to Json
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
    }
}
