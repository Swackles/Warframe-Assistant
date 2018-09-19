using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Warframe
{
    public class warframe
    {
        #region properties
        public string UniqueName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ParentName { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public ushort Health { get; set; }
        public ushort Shield { get; set; }
        public ushort Armor { get; set; }
        public ushort Stamina { get; set; }
        public byte Power { get; set; }
        public bool CodexSecret {get; set;}

        public IList<ability> Abilities { get; set; }
        #endregion

        #region classes
        public class ability
        {
            public string UniqueName { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        #endregion

        #region Methods
        public static IList<warframe> Get(string name = null)
        {
            // Request.   
            WebRequest request = WebRequest.Create("http://content.warframe.com/MobileExport/Manifest/ExportWarframes.json");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";

            // Response
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            JObject data = JObject.Parse(reader.ReadToEnd());

            IList<warframe> WarframeList = new List<warframe>();

            Parallel.ForEach(data["ExportWarframes"], WarframeData =>
            {
                warframe warframe = new warframe()
                {
                    UniqueName = WarframeData["uniqueName"].ToString(),
                    ParentName = WarframeData["parentName"].ToString(),
                    Description = WarframeData["description"].ToString(),
                    LongDescription = WarframeData["longDescription"].ToString(),
                    Health = ushort.Parse(WarframeData["health"].ToString()),
                    Shield = ushort.Parse(WarframeData["shield"].ToString()),
                    Armor = ushort.Parse(WarframeData["armor"].ToString()),
                    Stamina = ushort.Parse(WarframeData["stamina"].ToString()),
                    Power = byte.Parse(WarframeData["power"].ToString()),
                    CodexSecret = bool.Parse(WarframeData["codexSecret"].ToString()),

                    Abilities = new List<ability>()
                };
                
                if (WarframeData["name"].ToString().Contains("<ARCHWING")) {
                    warframe.Name = WarframeData["name"].ToString().Replace("<ARCHWING>", "");
                    warframe.Type = "Archwing";
                } else
                {
                    warframe.Name = WarframeData["name"].ToString();
                    warframe.Type = "Warframe";
                }

                if (name != null)
                {
                    if (!warframe.Name.Contains(name)) { return; }
                }

                Parallel.ForEach(WarframeData["abilities"], AbilityData =>
                {
                    ability Ability = new ability()
                    {
                        UniqueName = AbilityData["abilityUniqueName"].ToString(),
                        Name = AbilityData["abilityName"].ToString(),
                        Description = AbilityData["description"].ToString()
                    };

                    warframe.Abilities.Add(Ability);
                });

                WarframeList.Add(warframe);
            });

            return WarframeList;
        }

        public static void DumpDebug(warframe Warframe)
        {
            Debug.WriteLine("{");
            Debug.WriteLine("   UniqueName: " +Warframe.UniqueName);
            Debug.WriteLine("   Name: " + Warframe.Name);
            Debug.WriteLine("   Type: " + Warframe.Type);
            Debug.WriteLine("   ParentName: " + Warframe.ParentName);
            Debug.WriteLine("   Description: " + Warframe.Description);
            Debug.WriteLine("   LongDescription: " + Warframe.LongDescription);
            Debug.WriteLine("   Health: " + Warframe.Health);
            Debug.WriteLine("   Shield: " + Warframe.Shield);
            Debug.WriteLine("   Armor: " + Warframe.Armor);
            Debug.WriteLine("   Stamina: " + Warframe.Stamina);
            Debug.WriteLine("   Power: " + Warframe.Power);
            Debug.WriteLine("   CodexSecret: " + Warframe.CodexSecret);
            Debug.WriteLine("   Abilities: [");
            foreach (ability ability in Warframe.Abilities)
            {
                Debug.WriteLine("       {");
                Debug.WriteLine("           AbilityUniqueName: " +ability.UniqueName);
                Debug.WriteLine("           AbilityName: " +ability.Name);
                Debug.WriteLine("           Description: " +ability.Description);
                Debug.WriteLine("       },");
            }
            Debug.WriteLine("   ]");
            Debug.WriteLine("}");
        }
        #endregion
    }
}