# How to use SpacePark API
All data is returned as JSON format.

## PARKINGS
<br/>

**GET** /api/Parkings  
Get all parking rows/entities from the database.  
Required API-key type: Visitor  
Example (Rest Client):  
```
GET https://localhost:44360/api/Parkings
apikey: apikey1234_visitor
```
<br/>

**POST** /api/Parkings  
Adds new parking to database. Checks so that characters is allowed to park and checks Starship length against Starports max length. Parking start time is added automatically.  
Required API-key type: Visitor  
Example (Rest Client):
```
POST https://localhost:44360/api/Parkings
Content-Type: application/json
apikey: apikey1234_visitor

{
    "Traveller":"string",
    "Starship":"string",
    "SpaceportId": int
}
```
<br/>

**GET** ​/api​/Parkings​/Ended  
Query parameter: traveller (string)  
Get all parking rows/entities from the database based on traveller in supplied string query.  
Required API-key type: Visitor  
Example (Rest Client):
```
GET https://localhost:44360​/api​/Parkings​/Ended?traveller=Luke Skywalker
apikey: apikey1234_visitor
```
<br/>

**GET** ​/api​/Parkings​/Active  
Query parameter: traveller (string)  
Get currently active parking from the database based on traveller in supplied string query.  
Required API-key type: Visitor  
Example (Rest Client):
```
GET https://localhost:44360​/api​/Parkings​/Active?traveller=Luke Skywalker
apikey: apikey1234_visitor
```
<br/>

**GET** /api/Parkings/{id}  
Path parameter: id (int)  
Find and return a {parking} entity with the specified {id} from the database. If no entity can be found, then {null} is returned.  
Required API-key type: Visitor  
Example (Rest Client):
```
GET https://localhost:44360/api/Parkings/1
apikey: apikey1234_visitor
```
<br/>

**PATCH** /api/Parkings/Checkout  
Query parameter: traveller (string)  
Ends active parking for the traveller based on supplied string query. Endtime and price is calculated and set automatically by the system. Returns the completed parking.  
Required API-key type: Visitor  
Example (Rest Client):
```
PATCH https://localhost:44360/api/Parkings/Checkout?traveller=Luke Skywalker
Content-Type: application/json
apikey: apikey1234_visitor

{
}
```
<br/>

## PEOPLE
<br/>

**GET** /api/People/All  
Returns all travellers allowed to park in any Spaceport.  
Required API-key type: Visitor  
Example (Rest Client):
```
GET https://localhost:44360​/api/People/All
apikey: apikey1234_visitor
```
<br/>

**GET** /api/People  
Query parameter: starship (string)  
Returns a single traveller based on supplied string query.  
Required API-key type: Visitor  
Example (Rest Client):
```
GET https://localhost:44360​/api/People?name=Darth Vader
apikey: apikey1234_visitor
```
<br/>

## SPACEPORTS
<br/>

**GET** /api/Spaceports  
Returns all Spaceports.  
Required API-key type: Visitor  
Example (Rest Client):
```
GET https://localhost:44360​/api/Spaceports
apikey: apikey1234_visitor
```
<br/>

**POST** /api/Spaceports  
Creates new Spceport. New spaceport name (string) needs to be provided in the request body.  
Required API-key type: Administrator  
Example (Rest Client):
```
POST https://localhost:44360/api/Spaceports
Content-Type: application/json
apikey: apikey1234_admin

{
    "PlanetName":"Tatooine",
    "Name":"Mos Eisley",
    "MaxStarshipLength":250
}
```
<br/>

**GET** /api/Spaceports/{id}  
Path parameter: id (int)  
Returns a single spaceport based on supplied id.  
Required API-key type: Visitor  
Example (Rest Client):
```
GET https://localhost:44360​/api/Spaceports/1
apikey: apikey1234_visitor
```
<br/>

## STARSHIPS
<br/>

**GET** /api/Starships/All  
Returns all starships assocciated with visitors allowed to park in any Starport.  
Required API-key type: Visitor  
Example (Rest Client):
```
GET https://localhost:44360​/api/Starships/All
apikey: apikey1234_visitor
```
<br/>

**GET** /api/Starships  
Query parameter: starship (string)  
Returns a single starships based on supplied id.  
Required API-key type: Visitor  
Example (Rest Client):
```
GET https://localhost:44360​/api/Starships?name=Millennium Falcon
apikey: apikey1234_visitor
```