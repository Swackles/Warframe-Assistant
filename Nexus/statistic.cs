using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Nexus
{
    public class nexus
    {
        #region Properties
        public string Name { get; set; }
        public info Supply { get; set; }
        public info Demand { get; set; }
        public IList<components> Components { get; set; }
        #endregion

        #region Classes
        public class components
        {
            public string Name { get; set; }
            public satistics Buying { get; set; }
            public satistics Selling { get; set; }
            public satistics Combined { get; set; }
        }

        public class satistics
        {
            public double? Avg { get; set; }
            public IList<satistics> Intervals { get; set; }
            public ushort? Max { get; set; }
            public double? Median { get; set; }
            public ushort? Min { get; set; }
            public info Offers { get; set; }
            public decimal? PriceAccuracy { get; set; }
        }

        public class info
        {
            public int? Count { get; set; }
            public int? HasVaule { get; set; }
            public decimal? Percentage { get; set; }
        }
        #endregion

        #region Methods
        public static nexus GetPrimeStatistics(string Item)
        {
            string ItemName = (Item + "%20prime").ToLower();

            // Request.   
            WebRequest request = WebRequest.Create("https://api.nexus-stats.com/warframe/v1/items/"+ItemName+"/statistics");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";

            // Response
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            JObject data = JObject.Parse(reader.ReadToEnd());

            nexus item = new nexus()
            {
                Name = data["name"].ToString(),

                Demand = new info()
                {
                    Count = Int32.Parse(data["demand"]["count"].ToString()),
                    HasVaule = Int32.Parse(data["demand"]["count"].ToString()),
                    Percentage = decimal.Parse(data["demand"]["count"].ToString())
                },
                Supply = new info()
                {
                    Count = Int32.Parse(data["supply"]["count"].ToString()),
                    HasVaule = Int32.Parse(data["supply"]["count"].ToString()),
                    Percentage = decimal.Parse(data["supply"]["count"].ToString())
                },
                Components = new List<components>()
            };

            Parallel.ForEach(data["components"], ComponentData =>
            {

                components Component = new components()
                {
                    Name = ComponentData["name"].ToString(),

                    Buying = new satistics()
                    {
                        Avg = double.Parse(ComponentData["buying"]["avg"].ToString()),
                        Max = ushort.Parse(ComponentData["buying"]["max"].ToString()),
                        Median = double.Parse(ComponentData["buying"]["median"].ToString()),
                        Min = ushort.Parse(ComponentData["buying"]["min"].ToString()),

                        Offers = new info()
                        {
                            Count = Int32.Parse(ComponentData["buying"]["offers"]["count"].ToString()),
                            HasVaule = Int32.Parse(ComponentData["buying"]["offers"]["count"].ToString()),
                            Percentage = decimal.Parse(ComponentData["buying"]["offers"]["percentage"].ToString())
                        },

                        Intervals = new List<satistics>()
                    },
                    Combined = new satistics()
                    {
                        Avg = double.Parse(ComponentData["combined"]["avg"].ToString()),
                        Max = ushort.Parse(ComponentData["combined"]["max"].ToString()),
                        Median = double.Parse(ComponentData["combined"]["median"].ToString()),
                        Min = ushort.Parse(ComponentData["combined"]["min"].ToString()),

                        Offers = new info()
                        {
                            Count = Int32.Parse(ComponentData["combined"]["offers"]["count"].ToString()),
                            HasVaule = Int32.Parse(ComponentData["combined"]["offers"]["count"].ToString()),
                            Percentage = decimal.Parse(ComponentData["combined"]["offers"]["percentage"].ToString())
                        },

                        Intervals = new List<satistics>()
                    },
                    Selling = new satistics()
                    {
                        Avg = double.Parse(ComponentData["selling"]["avg"].ToString()),
                        Max = ushort.Parse(ComponentData["selling"]["max"].ToString()),
                        Median = double.Parse(ComponentData["selling"]["median"].ToString()),
                        Min = ushort.Parse(ComponentData["selling"]["min"].ToString()),

                        Offers = new info()
                        {
                            Count = Int32.Parse(ComponentData["selling"]["offers"]["count"].ToString()),
                            HasVaule = Int32.Parse(ComponentData["selling"]["offers"]["count"].ToString()),
                            Percentage = decimal.Parse(ComponentData["selling"]["offers"]["percentage"].ToString())
                        },

                        Intervals = new List<satistics>()
                    },
                };

                string[] variable = {"buying", "selling", "combined" };
                
                for (int i = 0; i < variable.Length; i++)
                {
                    Parallel.ForEach(ComponentData[variable[i]]["intervals"], intervalData => {
                        satistics interval = new satistics()
                        {
                            Offers = new info()
                            {
                                Count = Int32.Parse(intervalData["offers"]["count"].ToString()),
                                HasVaule = Int32.Parse(intervalData["offers"]["hasValue"].ToString()),
                                Percentage = decimal.Parse(intervalData["offers"]["percentage"].ToString())
                            }
                        };

                        if (intervalData["avg"].ToString() != "")
                        {
                            interval.Avg = double.Parse(intervalData["avg"].ToString());
                        }
                        else
                        {
                            interval.Avg = 0;
                        }
                        if (intervalData["max"].ToString() != "")
                        {
                            interval.Max = ushort.Parse(intervalData["max"].ToString());
                        }
                        else
                        {
                            interval.Avg = 0;
                        }
                        if (intervalData["median"].ToString() != "")
                        {
                            interval.Median = double.Parse(intervalData["median"].ToString());
                        }
                        else
                        {
                            interval.Avg = 0;
                        }
                        if (intervalData["min"].ToString() != "")
                        {
                            interval.Min = ushort.Parse(intervalData["min"].ToString());
                        }
                        else
                        {
                            interval.Avg = 0;
                        }
                        if (intervalData["priceAccuracy"].ToString() != "")
                        {
                            interval.PriceAccuracy = decimal.Parse(intervalData["priceAccuracy"].ToString());
                        }
                        else
                        {
                            interval.Avg = 0;
                        }

                        switch(variable[i])
                        {
                            case "buying":
                                Component.Buying.Intervals.Add(interval);
                                break;
                            case "combined":
                                Component.Buying.Intervals.Add(interval);
                                break;
                            case "selling":
                                Component.Buying.Intervals.Add(interval);
                                break;
                        }
                        
                    });
                }
                item.Components.Add(Component);
            });



            reader.Close();
            response.Close();

            return item;

        }

        public static void DumpDebug(nexus item)
        {
            Debug.WriteLine("nexus: {");
            Debug.WriteLine("   Name: " + item.Name);
            Debug.WriteLine("   Supply: {");
            Debug.WriteLine("       Count: " + item.Supply.Count);
            Debug.WriteLine("       HasValue: " + item.Supply.HasVaule);
            Debug.WriteLine("       Percentage: " + item.Supply.Percentage);
            Debug.WriteLine("   }");
            Debug.WriteLine("   Demand: {");
            Debug.WriteLine("       Count: " + item.Demand.Count);
            Debug.WriteLine("       HasValue: " + item.Demand.HasVaule);
            Debug.WriteLine("       Percentage: " + item.Demand.Percentage);
            Debug.WriteLine("   }");
            Debug.WriteLine("   Components: [");
            foreach(components component in item.Components)
            {
                Debug.WriteLine("       {");
                Debug.WriteLine("           Name: " + component.Name);
                // Buying
                Debug.WriteLine("           Buying: {");
                Debug.WriteLine("               Avg: " + component.Buying.Avg);
                Debug.WriteLine("               Max: "+component.Buying.Max);
                Debug.WriteLine("               Median: "+component.Buying.Median);
                Debug.WriteLine("               Min: "+component.Buying.Min);
                Debug.WriteLine("               PriceAccuracy: " + component.Buying.PriceAccuracy);
                Debug.WriteLine("               Offers: {");
                Debug.WriteLine("                   Count: " + component.Buying.Offers.Count);
                Debug.WriteLine("                   HasValue: " + component.Buying.Offers.HasVaule);
                Debug.WriteLine("                   Percentage: " + component.Buying.Offers.Percentage);
                Debug.WriteLine("               }");
                Debug.WriteLine("               Intevals: [");
                foreach(satistics statistic in component.Buying.Intervals)
                {
                    Debug.WriteLine("           {");
                    Debug.WriteLine("               Avg: " + statistic.Avg);
                    Debug.WriteLine("               Max: " + statistic.Max);
                    Debug.WriteLine("               Median: " + statistic.Median);
                    Debug.WriteLine("               Min: " + statistic.Min);
                    Debug.WriteLine("               PriceAccuracy: " + statistic.PriceAccuracy);
                    Debug.WriteLine("               Offers: {");
                    Debug.WriteLine("                   Count: " + statistic.Offers.Count);
                    Debug.WriteLine("                   HasValue: " + statistic.Offers.HasVaule);
                    Debug.WriteLine("                   Percentage: " + statistic.Offers.Percentage);
                    Debug.WriteLine("               }");
                    Debug.WriteLine("           }");
                }
                Debug.WriteLine("               ]");
                Debug.WriteLine("           }");


                // selling
                Debug.WriteLine("           Buying: {");
                Debug.WriteLine("               Avg: " + component.Selling.Avg);
                Debug.WriteLine("               Max: " + component.Selling.Max);
                Debug.WriteLine("               Median: " + component.Selling.Median);
                Debug.WriteLine("               Min: " + component.Selling.Min);
                Debug.WriteLine("               PriceAccuracy: " + component.Selling.PriceAccuracy);
                Debug.WriteLine("               Offers: {");
                Debug.WriteLine("                   Count: " + component.Selling.Offers.Count);
                Debug.WriteLine("                   HasValue: " + component.Selling.Offers.HasVaule);
                Debug.WriteLine("                   Percentage: " + component.Selling.Offers.Percentage);
                Debug.WriteLine("               }");
                Debug.WriteLine("               Intevals: [");
                foreach (satistics statistic in component.Selling.Intervals)
                {
                    Debug.WriteLine("           {");
                    Debug.WriteLine("               Avg: " + statistic.Avg);
                    Debug.WriteLine("               Max: " + statistic.Max);
                    Debug.WriteLine("               Median: " + statistic.Median);
                    Debug.WriteLine("               Min: " + statistic.Min);
                    Debug.WriteLine("               PriceAccuracy: " + statistic.PriceAccuracy);
                    Debug.WriteLine("               Offers: {");
                    Debug.WriteLine("                   Count: " + statistic.Offers.Count);
                    Debug.WriteLine("                   HasValue: " + statistic.Offers.HasVaule);
                    Debug.WriteLine("                   Percentage: " + statistic.Offers.Percentage);
                    Debug.WriteLine("               }");
                    Debug.WriteLine("           }");
                }
                Debug.WriteLine("               ]");
                Debug.WriteLine("           }");
                Debug.WriteLine("       }");


                // combined
                Debug.WriteLine("           Buying: {");
                Debug.WriteLine("               Avg: " + component.Combined.Avg);
                Debug.WriteLine("               Max: " + component.Combined.Max);
                Debug.WriteLine("               Median: " + component.Combined.Median);
                Debug.WriteLine("               Min: " + component.Combined.Min);
                Debug.WriteLine("               PriceAccuracy: " + component.Combined.PriceAccuracy);
                Debug.WriteLine("               Offers: {");
                Debug.WriteLine("                   Count: " + component.Combined.Offers.Count);
                Debug.WriteLine("                   HasValue: " + component.Combined.Offers.HasVaule);
                Debug.WriteLine("                   Percentage: " + component.Combined.Offers.Percentage);
                Debug.WriteLine("               }");
                Debug.WriteLine("               Intevals: [");
                foreach (satistics statistic in component.Combined.Intervals)
                {
                    Debug.WriteLine("           {");
                    Debug.WriteLine("               Avg: " + statistic.Avg);
                    Debug.WriteLine("               Max: " + statistic.Max);
                    Debug.WriteLine("               Median: " + statistic.Median);
                    Debug.WriteLine("               Min: " + statistic.Min);
                    Debug.WriteLine("               PriceAccuracy: " + statistic.PriceAccuracy);
                    Debug.WriteLine("               Offers: {");
                    Debug.WriteLine("                   Count: " + statistic.Offers.Count);
                    Debug.WriteLine("                   HasValue: " + statistic.Offers.HasVaule);
                    Debug.WriteLine("                   Percentage: " + statistic.Offers.Percentage);
                    Debug.WriteLine("               }");
                    Debug.WriteLine("           }");
                }
                Debug.WriteLine("               ]");
                Debug.WriteLine("           }");
                Debug.WriteLine("       }");


            }
            Debug.WriteLine("   ]");
        }
        #endregion
    }
}
