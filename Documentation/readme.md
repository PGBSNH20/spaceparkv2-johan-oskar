# SpacePark API Documentation


## How to use the API
Data is return in JSON string.

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
```
GET https://localhost:44360​/api​/Parkings​/Ended?traveller=Luke Skywalker
apikey: apikey1234_visitor
```
**GET** /api/Parkings/{id}  
Path parameter: id (int)
Find and return a {parking} entity with the specified {id} from the database. If no entity can be found, then {null} is returned.
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
```
GET https://localhost:44360​/api/People
apikey: apikey1234_visitor
```
**GET** /api/People/{id}
Path parameter: id (int)
Returns a single traveller based on supplied id.
```
GET https://localhost:44360​/api/People/1
apikey: apikey1234_visitor
```
### Spaceports
**GET** /api/Spaceports

**POST** /api/Spaceports

**GET** /api/Spaceports/{id}

**PUT** /api/Spaceports/{id}

**DELETE** /api/Spaceports/{id}

### Starships
**GET** /api/Starships

**GET** /api/Starships/{id}