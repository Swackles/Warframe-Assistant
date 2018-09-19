using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Warframe
{
    public class relic
    {
        #region properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tier { get; set; }
        public bool CodexSecret { get; set; }
        public IList<part> Parts { get; set; }
        #endregion

        #region classes
        public class part
        {
            public ushort Count { get; set; }
            public string Rarity { get; set; }
            public string Name { get; set; }
            public ushort Tier { get; set; }
        }
        #endregion

        #region Methods
        public static IList<relic> Get()
        {
            // Request.   
            WebRequest request = WebRequest.Create("http://content.warframe.com/MobileExport/Manifest/ExportRelicArcane.json");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";

            // Response
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            JObject data = JObject.Parse(reader.ReadToEnd());

            IList<relic> reliclist = new List<relic>();

            Parallel.ForEach(data["ExportRelicArcane"], RelicData =>
            {
                if (!RelicData["name"].ToString().Contains("RELIC")) { return; }

                relic relic = new relic()
                {
                    Name = RelicData["name"].ToString().Remove(RelicData["name"].ToString().IndexOf(" "), RelicData["name"].ToString().Length - RelicData["name"].ToString().IndexOf(" ")),
                    Description = RelicData["description"].ToString(),
                    CodexSecret = bool.Parse(RelicData["codexSecret"].ToString()),
                    Parts = new List<part>()
                };

                relic.Tier = RelicData["name"].ToString().Remove(relic.Name.Length, RelicData["name"].ToString().IndexOf(" RELIC"));

                Parallel.ForEach(RelicData["relicRewards"], partData =>
                {
                    part Part = new part()
                    {
                        Count = ushort.Parse(partData["itemCount"].ToString()),
                        Rarity = partData["rarity"].ToString(),
                        Tier = ushort.Parse(partData["tier"].ToString())
                    };

                    Part.Name = partData["rewardName"].ToString().Remove(0, partData["rewardName"].ToString().LastIndexOf("/") + 1).Replace("Prime", " ");

                    if (Part.Name.Contains("Blueprint")) { Part.Name = Part.Name.Replace("Blueprint", " "); }

                    Char[] charaters = Part.Name.ToCharArray();

                    for (int i = 1; i < charaters.Length; i++)
                    {
                        if (Char.IsUpper(charaters[i]))
                        {
                            if (char.IsWhiteSpace(charaters[i - 1])) { continue; }
                            Part.Name = Part.Name.Replace(charaters[i].ToString(), " "+charaters[i].ToString());
                        }
                    }

                    relic.Parts.Add(Part);
                });


                reliclist.Add(relic);
            });

            return reliclist;
        }

        public static void DumpDebug(relic Relic)
        {
            Debug.WriteLine("Relic: {");
            Debug.WriteLine("   Name: "+Relic.Name);
            Debug.WriteLine("   Tier: " + Relic.Tier);
            Debug.WriteLine("   Description: " + Relic.Description);
            Debug.WriteLine("   Parts: {");
            foreach (part Part in Relic.Parts)
            {
                Debug.WriteLine("       [");
                Debug.WriteLine("           Name: " + Part.Name);
                Debug.WriteLine("           Count: " + Part.Count);
                Debug.WriteLine("           Rarity: " + Part.Rarity);
                Debug.WriteLine("           Tier: " + Part.Tier);
                Debug.WriteLine("       ],");
            }
            Debug.WriteLine("   }");
            Debug.WriteLine("}");
        }
        #endregion
    }
}
