# SpacePark API Documentation


## How to use the API
Data is returned as JSON.

### Parkings
**GET** /api/Parkings  
Get all parking rows/entities from the database.  
Example (Rest Client):  
```
GET https://localhost:44360/api/Parkings
apikey: apikey1234_visitor
```
**POST** /api/Parkings  
Adds new parking to database. Parking start time is added automatically.  
Example (Rest Client):
```
POST https://localhost:44360/api/Parkings
Content-Type: application/json
apikey: apikey1234_visitor
{
    "Traveller":"string",
    "StarShip":"string",
    "SpaceportId": int
}
```
**GET** ​/api​/Parkings​/Ended  
Query parameter: traveller (string)  
Get all parking rows/entities from the database.  
Example (Rest Client):
```
GET https://localhost:44360​/api​/Parkings​/Ended?traveller=Luke Skywalker
apikey: apikey1234_visitor
```
**GET** /api/Parkings/{id}  
Path parameter: id (int)
Find and return a {parking} entity with the specified {id} from the database. If no entity can be found, then {null} is returned.  
Example (Rest Client):
```
GET https://localhost:44360/api/Parkings/1
apikey: apikey1234_visitor
```
**PATCH** /api/Parkings/Checkout  
Query parameter: traveller (string)  
Ends active parking for the traveller. Endtime and price is calculated and set automatically by the system. Returns the completed parking.  
Example (Rest Client):
```
PATCH https://localhost:44360/api/Parkings/Checkout?traveller=Luke Skywalker
Content-Type: application/json
apikey: apikey1234_visitor
# apikey: apikey1234_admin
{
}
```
### People
**GET** /api/People  
Returns all travellers allowed to park in any Spaceport.  
Example (Rest Client):
```
GET https://localhost:44360​/api/People
apikey: apikey1234_visitor
```
**GET** /api/People/{id}  
Path parameter: id (int)
Returns a single traveller based on supplied id.  
Example (Rest Client):
```
GET https://localhost:44360​/api/People/1
apikey: apikey1234_visitor
```
### Spaceports
**GET** /api/Spaceports  
Returns all Spaceports.  
Example (Rest Client):
```
GET https://localhost:44360​/api/Spaceports
apikey: apikey1234_visitor
```
**POST** /api/Spaceports  
Creates new Spceport. New spaceport name (string) need to be provided in the request body.  
Administrator API-Key is required.  
Example (Rest Client):
```
POST https://localhost:44360/api/Spaceports
Content-Type: application/json
apikey: apikey1234_admin

{
    "Name":"Mos Eisley"
}
```
**GET** /api/Spaceports/{id}
Path parameter: id (int)
Returns a single spaceport based on supplied id.  
Example (Rest Client):
```
GET https://localhost:44360​/api/Spaceports/1
apikey: apikey1234_visitor
```
### Starships
**GET** /api/Starships
Returns all starships assocciated with visitors allowed to park in any Starport.  
Example (Rest Client):
```
GET https://localhost:44360​/api/Starships/
apikey: apikey1234_visitor
```
**GET** /api/Starships/{id}
Path parameter: id (int)
Returns a single starships based on supplied id.  
Example (Rest Client):
```
GET https://localhost:44360​/api/Starships/1
apikey: apikey1234_visitor
```