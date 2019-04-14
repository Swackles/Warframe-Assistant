# Warframe.Market API connection

[Warframe.Market](https://warframe.market/) API connection for C#

## Built With

* [Newtonsoft](https://www.newtonsoft.com/json) - Used to connect the mod with subnautica
* [Warframe.Market](https://warframe.market/) API

## Documentation

## order class

### Properties

> **.Id**
>Id assaigned to the order by Warframe.Market
> **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)

> **.Created**
> When the listing was created
> **Type** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netframework-4.7.2)

> **.Updated**
> when the listing was updated
> **Type** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netframework-4.7.2)

> **.Type**
> The type of the order (buy or sell)
> **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)

> **.Platform**
> Platform of the order (px, xbox, ps4)
> **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)

> **.Platinum** 
> Price of the item
> **Type** [ushort](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort)

> **.Quantity**
> How many items are for sale with this order
> **Type** [ushort](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort)

> **.Region**
> Region of the order
> **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)

> **.Visible**
> 
> **Type** [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/bool)

> **.User**
> Data about the user who listed the post
> **Type** [user]()

<br>
<br>

### Methods

> **.GetItemOrders(Item, part)**
>
> Gets all the listings on [Warframe.Market](https://warframe.market/) for the item
>
> | Variable | Type | Optional | Default | Description | 
> |:-----------:|:-----------:|:-----------:|:-----------:|-----------|
> | item | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) | False |  | Name of the Item you want to search for in > Warframe.Market |
> | part | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) | False | | The part name for that item|
> returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.DumpDebug(order)**
>
> | Variable | Type | Optional | Default | Description | 
> |:-----------:|:-----------:|:-----------:|:-----------:|-----------|
> | order | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) | False |  | order object you want to write inot debug console |
> returns [void](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/void)

<br>
<br>

> **.DumpConsole(order)**
>
> | Variable | Type | Optional | Default | Description | 
> |:-----------:|:-----------:|:-----------:|:-----------:|-----------|
> | order | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2) | False |  | order object you want to write into console |
> returns [void](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/void)

<br>
<br>
<br>
<br>

## order.user class

### Methods

> **.AvatarUrl**
> URL to the avatar image
> **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)

> **.User**
> Id assaigned to user in Warframe.Market
> **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)

> **.Id**
> ingame username
> **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)

> **.lastSeen**
> The last Date & Time the user has been seen
> **Type** [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netframework-4.7.2)

> **.Region**
> Language region of the user
> **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)

> **.Reputation**
> Reputation the user has
> **Type** [ushort](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort)

> **.ReputationBonus**
> 
> **Type** [ushort](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort)

> **.Status**
> Shows the current status of the user (offline, online, ingame)
> **Type** [string](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netframework-4.7.2)

<br>
<br>
<br>
<br>

## [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

### Methods


> **.FindorderId(IdToFind)**
>
> Find order with a surta an id
>
> | Variable | Type | Optional | Default | Description | 
> |:-----------:|:-----------:|:-----------:|:-----------:|-----------|
> | IdToFind | [order]() | False | | Id that you want to find |
> returns [order]()

<br>
<br>

> **.FindSellorders()**
>
> Find all listings that are for sale
>
> returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.FindBuyorders()**
>
> Find all the listings which are for PC
>
> returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>


> **.FindPcorders()**
>
> Find all the listings which are for PC
>
> returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.FindXboxorders()**
>
> Find all listings which are for Xbox
>
> returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.FindPs4orders()**
>
> Find all listings which are for PS4
>
> returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.FilterByPrice(Min, Max)**
>
> Gets all the listings on [Warframe.Market](https://warframe.market/) for the item
>
> | Variable | Type | Optional | Default | Description | 
> |:-----------:|:-----------:|:-----------:|:-----------:|-----------|
> | Min | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | True | null | The minimum price on the listing. If this is set to null it only takes the maximum price |
> | Max | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | true | null | The maximum price on the listing. If this is set to null it only takes the minimum price |
> returns [iList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.FilterByQuantity(Min, Max)**
>
> Gets all the listings on [Warframe.Market](https://warframe.market/) for the item
>
> | Variable | Type | Optional | Default | Description | 
> |:-----------:|:-----------:|:-----------:|:-----------:|-----------|
> | Min | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | True | null | The minimum quantity on the listing. If this is set to null it only takes the maximum quantity |
> | Max | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | true | null | The maximum quantity on the listing. If this is set to null it only takes the minimum quantity |
> returns [iList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.IsVisible()**
>
> Find all listings which are visible
>
> returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.FindUserrId(IdToFind)**
>
> Find order which belongs to a user with a surta an id
>
> | Variable | Type | Optional | Default | Description | 
> |:-----------:|:-----------:|:-----------:|:-----------:|-----------|
> | IdToFind | [order]() | False | | Id that you want to find |
> returns [order]()


<br>
<br>

> **.FindUserrName(NameToFind)**
>
> Find order which belongs to a user with a surta a name
>
> | Variable | Type | Optional | Default | Description | 
> |:-----------:|:-----------:|:-----------:|:-----------:|-----------|
> | IdToFind | [order]() | False | | Id that you want to find |
> returns [order]()


<br>
<br>

> **.UserRep(Min, Max)**
>
> Filter listings based on user reputation, Min or max reputation has to be set
>
> | Variable | Type | Optional | Default | Description | 
> |:-----------:|:-----------:|:-----------:|:-----------:|-----------|
> | Min | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | True | null | The minimum reputation the user on the on the listing has. If this is set to null it only takes the maximum reputation |
> | Max | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | true | null | The maximum reputation the user on the on the listing has. If this is set to null it only takes the minimum reputation |
> returns [iList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.UserBonusRep(Min, Max)**
>
> Filter listings based on user reputation, Min or max reputation has to be set
>
> | Variable | Type | Optional | Default | Description | 
> |:-----------:|:-----------:|:-----------:|:-----------:|-----------|
> | Min | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | True | null | The minimum bonus reputation the user on the on the listing has. If this is set to null it only takes the maximum bonus reputation |
> | Max | [int?](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int) | true | null | The maximum bonus reputation the user on the on the listing has. If this is set to null it only takes the minimum bonus reputation |
> returns [iList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.FindIngameUsers()**
>
> Find listings where the users is ingame
>
> returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.FindOnlineUsers()**
>
> Find listings where the users is online
>
> returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)

<br>
<br>

> **.FindOfflineUsers()**
>
> Find listings where the users is offline
>
> returns [IList\<order> ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2)
