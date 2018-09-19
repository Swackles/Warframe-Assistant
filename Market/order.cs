using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace Market
{
    public class order
    {

        #region properties
        /// <summary>
        /// Id assaigned to the order by Warframe.Market
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// When the listing was created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// when the listing was updated
        /// </summary>
        public DateTime Updated { get; set; }
        /// <summary>
        /// The type of the order (buy or sell)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Platform of the order (px, xbox, ps4)
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        /// Price of the item
        /// </summary>
        public ushort Platinum { get; set; }
        /// <summary>
        /// How many items are for sale with this order
        /// </summary>
        public ushort Quantity { get; set; }
        /// <summary>
        /// Region of the order
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Data about the user who listed the post
        /// </summary>
        public user User { get; set; }
        /// <summary>
        /// Wether the listing is visible
        /// </summary>
        public bool Visible { get; set; }
        #endregion

        #region classes
        public class user
        {
            /// <summary>
            /// URL to the avatar image
            /// </summary>
            public string AvatarUrl { get; set; }
            /// <summary>
            /// Id assaigned to user in Warframe.Market
            /// </summary>
            public string Id { get; set; }
            /// <summary>
            /// ingame username
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// The last Date & Time the user has been seen
            /// </summary>
            public DateTime lastSeen { get; set; }
            /// <summary>
            /// language region of the user
            /// </summary>
            public string Region { get; set; }
            /// <summary>
            /// Reputation the user has
            /// </summary>
            public short Reputation { get; set; }
            public short ReputationBonus { get; set; }
            /// <summary>
            /// Shows the current status of the user (offline, online, ingame)
            /// </summary>
            public string Status { get; set; }
        }
        #endregion

        #region methods
        /// <summary>
        /// Gets all orders on the item
        /// </summary>
        /// <param name="Item">
        /// The item name
        /// </param>
        /// <param name="part">
        /// The part name
        /// </param>
        /// <returns></returns>
        public static IList<order> GetItemOrders(string Item, string part)
        {
            IList<order> orders = new List<order>();

            string ItemName = (Item + "_prime_" + part).ToLower();

            // Request.   
            WebRequest request = WebRequest.Create("https://api.warframe.market/v1/items/" + ItemName + "/orders?include=item");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";

            // Response
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            JObject data = JObject.Parse(reader.ReadToEnd());

            Parallel.ForEach(data["payload"]["orders"], item  => {
                order order = new order();

                order.Id = item["id"].ToString();
                order.Created = DateTime.Parse(item["creation_date"].ToString());
                order.Updated = DateTime.Parse(item["last_update"].ToString());
                order.Type = item["order_type"].ToString();
                order.Platform = item["platform"].ToString();
                order.Platinum = ushort.Parse(item["platinum"].ToString());
                order.Quantity = ushort.Parse(item["quantity"].ToString());
                order.Region = item["region"].ToString();
                order.Visible = bool.Parse(item["visible"].ToString());

                order.user user = new order.user();

                user.AvatarUrl = "https://warframe.market/static/assets/" + item["user"]["avatar"].ToString();
                user.Id = item["user"]["id"].ToString();
                user.Name = item["user"]["ingame_name"].ToString();
                user.lastSeen = DateTime.Parse(item["user"]["last_seen"].ToString());
                user.Region = item["user"]["region"].ToString();
                user.Reputation = short.Parse(item["user"]["reputation"].ToString());
                user.ReputationBonus = short.Parse(item["user"]["reputation_bonus"].ToString());
                user.Status = item["user"]["status"].ToString();

                order.User = user;

                orders.Add(order);
            });

            
            reader.Close();
            response.Close();

            return orders;
        }
        /// <summary>
        /// Dumps all of the order data into debug console
        /// </summary>
        /// <param name="order"></param>
        public static void DumpDebug(order order)
        {
            Debug.WriteLine("order: {");
            Debug.WriteLine("   Id: "+ order.Id);
            Debug.WriteLine("   Created: "+ order.Created);
            Debug.WriteLine("   Updated: "+ order.Updated);
            Debug.WriteLine("   Type: "+ order.Type);
            Debug.WriteLine("   Platform: "+ order.Platform);
            Debug.WriteLine("   Platinum: "+ order.Platinum);
            Debug.WriteLine("   Quantity: "+ order.Quantity);
            Debug.WriteLine("   Region: "+ order.Region);
            Debug.WriteLine("   visible: "+ order.Visible);
            Debug.WriteLine("   user: {");
            Debug.WriteLine("       Avatar Url: "+ order.User.AvatarUrl);
            Debug.WriteLine("       id: "+ order.User.Id);
            Debug.WriteLine("       last Seen: "+ order.User.lastSeen);
            Debug.WriteLine("       Name: "+ order.User.Name);
            Debug.WriteLine("       Region: "+ order.User.Region);
            Debug.WriteLine("       Reputation: "+ order.User.Reputation);
            Debug.WriteLine("       Reputation Bonus: "+ order.User.ReputationBonus);
            Debug.WriteLine("       Satus: "+ order.User.Status);
            Debug.WriteLine("   }");
            Debug.WriteLine("}");
        }
        /// <summary>
        /// Dumps all of the order data into console
        /// </summary>
        /// <param name="order"></param>
        public static void DumpConsole(order order)
        {
            Console.WriteLine("order: {");
            Console.WriteLine("   Id: "+ order.Id);
            Console.WriteLine("   Created: "+ order.Created);
            Console.WriteLine("   Updated: "+ order.Updated);
            Console.WriteLine("   Type: "+ order.Type);
            Console.WriteLine("   Platform: "+ order.Platform);
            Console.WriteLine("   Platinum: "+ order.Platinum);
            Console.WriteLine("   Quantity: "+ order.Quantity);
            Console.WriteLine("   Region: "+ order.Region);
            Console.WriteLine("   visible: "+ order.Visible);
            Console.WriteLine("   user: {");
            Console.WriteLine("       Avatar Url: "+ order.User.AvatarUrl);
            Console.WriteLine("       id: "+ order.User.Id);
            Console.WriteLine("       last Seen: "+ order.User.lastSeen);
            Console.WriteLine("       Name: "+ order.User.Name);
            Console.WriteLine("       Region: "+ order.User.Region);
            Console.WriteLine("       Reputation: "+ order.User.Reputation);
            Console.WriteLine("       Reputation Bonus: "+ order.User.ReputationBonus);
            Console.WriteLine("       Satus: "+ order.User.Status);
            Console.WriteLine("   }");
            Console.WriteLine("}");
        }
        #endregion
    }
}
