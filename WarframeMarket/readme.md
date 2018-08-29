<p>
    # Warframe.Market API connection [Warframe.Market](https://warframe.market/) API connection for C# ## Built With * [Newtonsoft](https://www.newtonsoft.com/json) - Used to connect the mod with subnautica * [Warframe.Market](https://warframe.market/) API ## Documentation ## order class ### Properties &gt; **.Id** &gt;Id assaigned to the order by Warframe.Market &gt; **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) &gt; **.Created** &gt; When the listing was created &gt; **Type** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netframework-4.7.2) &gt; **.Updated** &gt; when the listing was updated &gt; **Type** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netframework-4.7.2) &gt; **.Type** &gt; The type of the order (buy or sell) &gt; **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) &gt; **.Platform** &gt; Platform of the order (px, xbox, ps4) &gt; **Type** 
    [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) &gt; **.Platinum** &gt; Price of the item &gt; **Type** [ushort](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort) &gt; **.Quantity** &gt; How many items are for sale with this order &gt; **Type** [ushort](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort) &gt; **.Region** &gt; Region of the order &gt; **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) &gt; **.Visible** &gt; &gt; **Type** [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/bool) &gt; **.User** &gt; Data about the user who listed the post &gt; **Type** [user]()
    <br />
    <br />
    ### Methods &gt; **.GetItemOrders(Item, part)** &gt; &gt; Gets all the listings on [Warframe.Market](https://warframe.market/) for the item &gt; &gt; | Variable | Type | Optional | Default | Description | &gt; |:-----------:|:-----------:|:-----------:|:-----------:|-----------| &gt; | item | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) | False | | Name of the Item you want to search for in &gt; Warframe.Market | &gt; | part | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) | False | | The part name for that item| &gt; returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.DumpDebug(order)** &gt; &gt; | Variable | Type | Optional | Default | Description | &gt; |:-----------:|:-----------:|:-----------:|:-----------:|-----------| &gt; | order | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) | False | | order object you want to write inot debug console | &gt; returns [void](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/void)
    <br />
    <br />
    &gt; **.DumpConsole(order)** &gt; &gt; | Variable | Type | Optional | Default | Description | &gt; |:-----------:|:-----------:|:-----------:|:-----------:|-----------| &gt; | order | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) | False | | order object you want to write into console | &gt; returns [void](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/void)
    <br />
    <br />
    <br />
    <br />
    ## order.user class ### Methods &gt; **.AvatarUrl** &gt; URL to the avatar image &gt; **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) &gt; **.User** &gt; Id assaigned to user in Warframe.Market &gt; **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) &gt; **.Id** &gt; ingame username &gt; **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) &gt; **.lastSeen** &gt; The last Date &amp; Time the user has been seen &gt; **Type** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netframework-4.7.2) &gt; **.Region** &gt; Language region of the user &gt; **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) &gt; **.Reputation** &gt; Reputation the user has &gt; **Type** [ushort](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort) &gt; **.ReputationBonus** &gt; &gt; **Type** 
    [ushort](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort) &gt; **.Status** &gt; Shows the current status of the user (offline, online, ingame) &gt; **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)
    <br />
    <br />
    <br />
    <br />
    ## [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2) ### Methods &gt; **.FindorderId(IdToFind)** &gt; &gt; Find order with a surta an id &gt; &gt; | Variable | Type | Optional | Default | Description | &gt; |:-----------:|:-----------:|:-----------:|:-----------:|-----------| &gt; | IdToFind | [order]() | False | | Id that you want to find | &gt; returns [order]()
    <br />
    <br />
    &gt; **.FindSellorders()** &gt; &gt; Find all listings that are for sale &gt; &gt; returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.FindBuyorders()** &gt; &gt; Find all the listings which are for PC &gt; &gt; returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.FindPcorders()** &gt; &gt; Find all the listings which are for PC &gt; &gt; returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.FindXboxorders()** &gt; &gt; Find all listings which are for Xbox &gt; &gt; returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.FindPs4orders()** &gt; &gt; Find all listings which are for PS4 &gt; &gt; returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.FilterByPrice(Min, Max)** &gt; &gt; Gets all the listings on [Warframe.Market](https://warframe.market/) for the item &gt; &gt; | Variable | Type | Optional | Default | Description | &gt; |:-----------:|:-----------:|:-----------:|:-----------:|-----------| &gt; | Min | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | True | null | The minimum price on the listing. If this is set to null it only takes the maximum price | &gt; | Max | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | true | null | The maximum price on the listing. If this is set to null it only takes the minimum price | &gt; returns [iList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.FilterByQuantity(Min, Max)** &gt; &gt; Gets all the listings on [Warframe.Market](https://warframe.market/) for the item &gt; &gt; | Variable | Type | Optional | Default | Description | &gt; |:-----------:|:-----------:|:-----------:|:-----------:|-----------| &gt; | Min | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | True | null | The minimum quantity on the listing. If this is set to null it only takes the maximum quantity | &gt; | Max | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | true | null | The maximum quantity on the listing. If this is set to null it only takes the minimum quantity | &gt; returns [iList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.IsVisible()** &gt; &gt; Find all listings which are visible &gt; &gt; returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.FindUserrId(IdToFind)** &gt; &gt; Find order which belongs to a user with a surta an id &gt; &gt; | Variable | Type | Optional | Default | Description | &gt; |:-----------:|:-----------:|:-----------:|:-----------:|-----------| &gt; | IdToFind | [order]() | False | | Id that you want to find | &gt; returns [order]()
    <br />
    <br />
    &gt; **.FindUserrName(NameToFind)** &gt; &gt; Find order which belongs to a user with a surta a name &gt; &gt; | Variable | Type | Optional | Default | Description | &gt; |:-----------:|:-----------:|:-----------:|:-----------:|-----------| &gt; | IdToFind | [order]() | False | | Id that you want to find | &gt; returns [order]()
    <br />
    <br />
    &gt; **.UserRep(Min, Max)** &gt; &gt; Filter listings based on user reputation, Min or max reputation has to be set &gt; &gt; | Variable | Type | Optional | Default | Description | &gt; |:-----------:|:-----------:|:-----------:|:-----------:|-----------| &gt; | Min | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | True | null | The minimum reputation the user on the on the listing has. If this is set to null it only takes the maximum reputation | &gt; | Max | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | true | null | The maximum reputation the user on the on the listing has. If this is set to null it only takes the minimum reputation | &gt; returns [iList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.UserBonusRep(Min, Max)** &gt; &gt; Filter listings based on user reputation, Min or max reputation has to be set &gt; &gt; | Variable | Type | Optional | Default | Description | &gt; |:-----------:|:-----------:|:-----------:|:-----------:|-----------| &gt; | Min | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | True | null | The minimum bonus reputation the user on the on the listing has. If this is set to null it only takes the maximum bonus reputation | &gt; | Max | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | true | null | The maximum bonus reputation the user on the on the listing has. If this is set to null it only takes the minimum bonus reputation | &gt; returns [iList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.FindIngameUsers()** &gt; &gt; Find listings where the users is ingame &gt; &gt; returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.FindOnlineUsers()** &gt; &gt; Find listings where the users is online &gt; &gt; returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
    <br />
    <br />
    &gt; **.FindOfflineUsers()** &gt; &gt; Find listings where the users is offline &gt; &gt; returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)</p>
