# PiggyBank API

The following Piggybank API was created and extended from the given interfaces, Don't worry I did not change the interfaces and used them exactly as given :)

## Installation

```
Download the repository and change the connection string in the appsettings.json to an available SQL database.
```

## What did I do and how?

<ul>
  <li>Added Swagger docs for ease of use and playing around with the API</li>
  <li>Used allot of dependancy injection -> used transient injection as the API should be stateless</li>
  <li>Added a helper class that uses reflection to get property values -> requried when the Coin class has an extra field, not existing in the ICoin Interface</li>
  <li>Added Generic classes for Request/Response objects -> So that all requests and responses are in the same format
  -> Requests not really applicable here as there is only one post see comments in code in <B>Envelope.cs</B></li>
  <li>Added Services layer for all business logic</li>
  <li>Controller, logic layer, and data layer are all independant and should be able to be switched out for any others-> Controller only validates request, services layer handles all logic and data layer handles data storage and retrieval.</li>
  <li>Added Repository Pattern and Unit of work for Database calls.</li>
</ul>


## Methods Exposed on API

```
POST
​/api​/PiggyBank​/AddCoin
Add a coin to the coinJar by accepting the type of coin which it is
```

```
GET
​/api​/PiggyBank​/GetValueInJar
Gets the total ammount of money currently in the jar denoted in US dollars
```

```
PUT
​/api​/PiggyBank​/EmptyJar
Reset the Jar back to zero and remove all coins
```




