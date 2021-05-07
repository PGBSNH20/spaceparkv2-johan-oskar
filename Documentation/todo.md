* [x] API key
    * [] specific API key for user
    * [] specific API key for admin
* Finish `Parkings` Controller & API (finished?)
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
    * `SpacePorts`
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
