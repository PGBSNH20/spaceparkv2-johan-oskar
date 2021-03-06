* [x] API key
    * [x] specific API key for user
    * [x] specific API key for admin
* Finish `Parkings` Controller & API (finished?)
    * [] Get information on current parking
    * [] Get information on all previous parkings
    * [] End active parking & "pay"
* Finish `SpacePorts` Controller & API
* SWAPI Controllers & API?
    * `Person` Controller & API
        * e.g. `/api/swapi/person?name=Luke`
        * e.g. `/api/swapi/person/3`
    * `Starship` Controller & API
        * e.g. `/api/swapi/starship/5`
    * `Planet` Controller & API (for admin when creating `SpacePorts`)
        * e.g. `/api/swapi/starship/5`
* Multi-Tenant (User Types? (user, admin))
* Tests
    * `Parkings`
        * `POST /parkings`
            * [x] success
            * fail
        * `GET /parkings` (get all)
            * [x] success
            * fail
        * `GET /parkings/2` (single)
            * [x] success
            * fail
        * `PUT /parkings/2` and/or `PATCH /parkings/2`
            * success
            * fail
    
    * `Parkings/CheckOut/2`
        * `GET`
    
    * `EndParkings/`
    * `Spaceports`
        * `POST /parkings`
            * success
            * fail
        * `GET /parkings` (get all)
            * success
            * fail
        * `GET /parkings/2` (single)
            * success
            * fail
        * `PUT /parkings/2` and/or `PATCH /parkings/2`
            * success
            * fail
    * `People` (swapi)
        * `GET /people` (get all)
            * success
            * fail
        * `GET /people/2` (single)
            * success
            * fail
    * `Starships` (swapi)
        * `GET /starships` (get all)
            * success
            * fail
        * `GET /starships/2` (single)
            * success
            * fail
* Input Validation
* Documentation
* Presentation
