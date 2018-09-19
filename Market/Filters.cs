using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Market
{
    public static class Filters
    {
        

        #region orders
        /// <summary>
        /// Find order with a surta an id
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <param name="IdToFind">Id that you want to find</param>
        /// <returns>Returns an order element</returns>
        public static order FindorderId(this IList<order> ordersToFilter, string IdToFind)
        {
            order orderToReturn = new order();

            Parallel.ForEach(ordersToFilter, (order, state) => { if (order.Id == IdToFind) { orderToReturn = order; state.Break(); } });

            return orderToReturn;
        }
        /// <summary>
        /// Find all listings that are for sale
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns an order element</returns>
        public static IList<order> FindSellorders(this IList<order> ordersToFilter)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => { if (order.Type == "sell") { ordersToReturn.Add(order); } });

            return ordersToReturn;
        }
        /// <summary>
        /// Find all listings that are for buy
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns an order element</returns>
        public static IList<order> FindBuyorders(this IList<order> ordersToFilter)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => { if (order.Type == "buy") { ordersToReturn.Add(order); } });

            return ordersToReturn;
        }
        /// <summary>
        /// Find all the listings which are for PC
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns an order element</returns>
        public static IList<order> FindPcorders(this IList<order> ordersToFilter)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => { if (order.Platform == "pc") { ordersToReturn.Add(order); } });

            return ordersToReturn;
        }
        /// <summary>
        /// Find all listings which are for Xbox
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns an order element</returns>
        public static IList<order> FindXboxorders(this IList<order> ordersToFilter)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => { if (order.Platform == "xbox") { ordersToReturn.Add(order); } });

            return ordersToReturn;
        }
        /// <summary>
        /// Find all listings which are for PS4
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns an order element</returns>
        public static IList<order> FindPs4orders(this IList<order> ordersToFilter)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => { if (order.Platform == "ps4") { ordersToReturn.Add(order); } });

            return ordersToReturn;
        }
        /// <summary>
        /// Filter listings based on price, Min or max pirce has to be set
        /// </summary>
        /// <param name="Min">The minimum price on the listing</param>
        /// <param name="Max">The maximum price on the listing</param>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns an order element</returns>
        public static IList<order> FilterByPrice(this IList<order> ordersToFilter, int? Min = null, int? Max = null)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, (order, state) => {

                if (Min == null && Max == null)
                {
                    throw new Exception("Can't have noth Minimum and Maximum price as null");
                } 
                else if (Min != null && Max != null)
                {
                    if (order.Platinum < Max && order.Platinum > Min) { ordersToReturn.Add(order); }
                }
                else if (Min == null)
                {
                    if (order.Platinum < Max) { ordersToReturn.Add(order); }
                }
                else if (Max == null)
                {
                    if (order.Platinum > Min) { ordersToReturn.Add(order); }
                }
            });

            return ordersToReturn;
        }
        /// <summary>
        /// Filter listings based on quantity, Min or max quantity has to be set
        /// </summary>
        /// <param name="Min">The minimum quantity on the listing</param>
        /// <param name="Max">The maximum quantity on the listing</param>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns an order element</returns>
        public static IList<order> FilterByQuantity(this IList<order> ordersToFilter, int? Min = null, int? Max = null)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => {

                if (Min == null && Max == null)
                {
                    throw new Exception("Can't have noth Minimum and Maximum quantity as null");
                }
                else if (Min != null && Max != null)
                {
                    if (order.Quantity < Max && order.Quantity > Min) { ordersToReturn.Add(order); }
                }
                else if (Min == null)
                {
                    if (order.Quantity < Max) { ordersToReturn.Add(order); }
                }
                else if (Max == null)
                {
                    if (order.Quantity > Min) { ordersToReturn.Add(order); }
                }
            });

            return ordersToReturn;
        }
        /// <summary>
        /// Find listings which are visible
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns an order element</returns>
        public static IList<order> IsVisible(this IList<order> ordersToFilter)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => { if (order.Visible) { ordersToReturn.Add(order); } });

            return ordersToReturn;
        }
        #endregion

        #region User
        /// <summary>
        /// Find user with a surtain id
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <param name="IdToFind">Id that you want to find</param>
        /// <returns>Returns an order element</returns>
        public static order FindUserrId(this IList<order> ordersToFilter, string IdToFind)
        {
            order ordersToReturn = new order();

            Parallel.ForEach(ordersToFilter, order => { if (order.User.Id == IdToFind) { ordersToReturn = order; } });

            return ordersToReturn;
        }
        /// <summary>
        /// Find user with a name
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <param name="IdToFind">Id that you want to find</param>
        /// <returns>Returns an order element</returns>
        public static order FindUserrName(this IList<order> ordersToFilter, string NameToFind)
        {
            order ordersToReturn = new order();

            Parallel.ForEach(ordersToFilter, order => { if (order.User.Name == NameToFind) { ordersToReturn = order; } });

            return ordersToReturn;
        }
        /// <summary>
        /// Filter listings based on user reputation, Min or max reputation has to be set
        /// </summary>
        /// <param name="Min">The minimum reputation on the listing</param>
        /// <param name="Max">The maximum reputation on the listing</param>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns a list of element</returns>
        public static IList<order> UserRep(this IList<order> ordersToFilter, int? Min = null, int? Max = null)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => {

                if (Min == null && Max == null)
                {
                    throw new Exception("Can't have noth Minimum and Maximum price as null");
                }
                else if (Min != null && Max != null)
                {
                    if (order.User.Reputation < Max && order.User.Reputation > Min) { ordersToReturn.Add(order); }
                }
                else if (Min == null)
                {
                    if (order.User.Reputation < Max) { ordersToReturn.Add(order); }
                }
                else if (Max == null)
                {
                    if (order.User.Reputation > Min) { ordersToReturn.Add(order); }
                }
            });

            return ordersToReturn;
        }
        /// <summary>
        /// Filter listings based on user bonus reputation, Min or max reputation has to be set
        /// </summary>
        /// <param name="Min">The minimum bonus reputation on the listing</param>
        /// <param name="Max">The maximum bonus reputation on the listing</param>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns a list of element</returns>
        public static IList<order> UserBonusRep(this IList<order> ordersToFilter, int? Min = null, int? Max = null)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => {

                if (Min == null && Max == null)
                {
                    throw new Exception("Can't have noth Minimum and Maximum price as null");
                }
                else if (Min != null && Max != null)
                {
                    if (order.User.ReputationBonus < Max && order.User.ReputationBonus > Min) { ordersToReturn.Add(order); }
                }
                else if (Min == null)
                {
                    if (order.User.ReputationBonus < Max) { ordersToReturn.Add(order); }
                }
                else if (Max == null)
                {
                    if (order.User.ReputationBonus > Min) { ordersToReturn.Add(order); }
                }
            });

            return ordersToReturn;
        }
        /// <summary>
        /// Find users that are online
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns a list of element</returns>
        public static IList<order> FindOnlineUsers(this IList<order> ordersToFilter)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => { if (order.User.Status == "online") { ordersToReturn.Add(order); } });

            return ordersToReturn;
        }
        /// <summary>
        /// Find users that are offline
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns a list of element</returns>
        public static IList<order> FindOfflineUsers(this IList<order> ordersToFilter)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => { if (order.User.Status == "offline") { ordersToReturn.Add(order); } });

            return ordersToReturn;
        }
        /// <summary>
        /// Find users that are ingame
        /// </summary>
        /// <param name="ordersToFilter">The list you want to find the items in</param>
        /// <returns>Returns a list of element</returns>
        public static IList<order> FindIngameUsers(this IList<order> ordersToFilter)
        {
            IList<order> ordersToReturn = new List<order>();

            Parallel.ForEach(ordersToFilter, order => { if (order.User.Status == "ingame") { ordersToReturn.Add(order); } });

            return ordersToReturn;
        }

        #endregion
    }
}
