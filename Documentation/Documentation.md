<pre style="font-family:monospace;line-height: 1.2;white-space: pre;margin:0 auto;display:inline-block;">
 _____   _   _   ____        __________________       ____         _______   _________ 
|_   _| | |_| | |  __|      /                  \     /    \       /       | |         |
  | |   |  _  | |  __|     /    ____     ___    |   /      \     /    ____| |    _____|
  |_|   |_| |_| |____|     \    \   |   |___|   |  /   /\   \   /    /      |   |_____ 
                            \    \  |           | /   /__\   \ |    |       |    _____|
                       ______|    | |    ______/ /            \ \    \____  |   |_____ 
                      |          /  |   |       /    ______    \ \        | |         |
                      |_________/   |___|      /____/      \____\ \_______| |_________|
                       __________       ____         ___________          ____    _____
                      |          \     /    \       |           \        |    |  /    /
                      |    ___    |   /      \      |     ___    |       |    | /    /
                      |   |___|   |  /   /\   \     |    |___|   |       |    |/    /
                      |           | /   /__\   \    |          _/        |         |        _     ____   _ 
                      |    ______/ /            \   |    |\    \_______  |    |\    \      / \   |    | | |
                      |   |       /    ______    \  |    | \           | |    | \    \    / _ \  |  __| | |
                      |___|      /____/      \____\ |____|  \__________| |____|  \____\  /_/ \_\ |_|    |_|
</pre>

<br>
<br>

# Documentation

## Table of contents
- [The assignment's specification](#The-assignment's-specification)
- [Process](#Process)
- [Code structure](#Code-structure)
  - [SpaceParkAPI](#SpaceParkAPI)
  - [SpaceParkTest](#SpaceParkTest)
- [API documentation](#API-documentation)
- [Sources & Credits](#Sources-&-Credits)
- [](#)

## The assignment's specification
[Go to top of document](#Documentation)

## Process
[Go to top of document](#Documentation)

We began by discussing 

## Code structure
[Go to top of document](#Documentation)

### **SpaceParkConsole**
```csharp
throw new NotImplementedException();
```

---

### SpaceParkAPI
[Go to top of document](#Documentation)

- #### _Properties/_
    - #### launchSettings.json
- #### _APIModels/_
    > Contains the DTO models which define the structure of the objects which the `POST` handlers expect. By using DTO models we don't have to expose our domain models to the end user.
    - #### `class PostParking` (PostParking.cs)
        > Defines the DTO model for the `POST` model on the `/Parkings/` endpoint.
    - #### PostSpaceport.cs
    - #### `class PostSpaceport` (PostSpaceport.cs)
        > Defines the DTO model for the `POST` model on the `/Spaceports/` endpoint.
- #### _Controllers/_
    > Contains our API Controllers.
    - #### `class ParkingsController` (ParkingsController.cs)
        > This controller defines the `/Parking/`-endpoint, its actions and methods.
        <!--- ##### `GetParkings()`
            > This defines the `/Parking/`-endpoint for the `GET` method.
             ##### **Attributes:**
            ```csharp
            [HttpGet]
            ```
            ##### **Attributes:**
            ```csharp
            [FromQuery] string traveller
            ```
            The name of the traveller
            ##### **returns:**
            ```csharp
            Task<ActionResult<IEnumerable<Parking>>>
            ``` -->
        <!--- ##### `GetEndedForTraveller()`
             ```csharp
            async GetEndedForTraveller([FromQuery] string traveller)
            ``` 
            >This defines the `/Parking/Ended` endpoints for the `GET` method.
            <!-- ##### **Attributes:**
            ```csharp
            [HttpGet("[action]")]
            [ActionName("Ended")]
            ```
            ##### **returns:**
            ```csharp
            Task<ActionResult<IEnumerable<Parking>>>
            ``` 
            -->
    - #### `class SpaceportsController` (SpaceportsController.cs)
        > This controller defines the `/Spaceports/` endpoints.
    - #### `class TeapotController` (TeapotController.cs)
        > I'm a teapot.
- #### _Middleware/_
    - #### `class ApiKey` (ApiKey.cs)
        ```csharp
        throw new NotImplementedException();
        ```

- #### _Migrations/_
    > Entity Framework Core migrations
- #### _Models/_
    > This folder contains the definition for our data entities and the database context as used by Entity Framework.
    - #### `class Parking` (Parking.cs)
        > This defines the `Parking` entity.
    - #### `class Spaceport` (Spaceport.cs)
        > This defines the `Spaceport` entity.
    - #### `class SpaceParkContext` (SpaceParkContext.cs)
        > This defines the database structure, connection and any configurations.
- #### _Repositories/_
    - #### `interface IParkingsRepository` (IParkingsRepository.cs)
        > This defines the repository for the `Parkings` entity.
    - #### `interface ISpaceportsRepository` (ISpaceportsRepository.cs)
        > This defines the repository for the `Spaceports` entity.
    - #### `class ParkingsRepository` (ParkingsRepository.cs)
        > This defines the repository for the `Parkings` entity which contains all of its database queries.
    - #### `class SpaceportsRepository` (SpaceportsRepository.cs)
        > This defines the repository for the `Spaceports` entity which contains all of its database queries.
- #### _Swagger/_
    - #### `HeaderFilter` (HeaderFilter.cs)
        > This adds an operation filter to swagger which defines the requirement of an API key in the header on API requests when using Swagger.
- #### _swapi/_
    > This folder contains all logic which deals with the Star Wars API (`swapi`).
    - #### _Controllers/_
        - #### `class PeopleController` (PeopleController.cs)
            > This controller defines the `/People/` endpoints, its actions and methods.
        - #### `class StarshipsController` (StarshipsController.cs)
            This controller defines the `/Starships/` endpoints, its actions and methods.
    - #### _Models/_
        > This folder contains the definition for the `swapi` data models, i.e. which data from `swapi` we want when we make API requests against `swapi` with RestSharp.
        - #### `class Person` (Person.cs)
            > This defines the `Person` entity, and tells RestSharp that we only want a person `Name` and the list of `Starship`s which the person can park with.
        - #### `class Starship` (Starship.cs)
            > This defines the `Starship` entity, and tells RestSharp that we want the `Name`, `Length` and `URL` (API URL) for each `Starship`. 
    - #### Repositories/
        - #### StarshipsRepository.cs
        - #### `interface IPeopleRepository` (IPeopleRepository.cs)
            > This defines the repository for the `People` model.
        - #### `interface IStarshipsRepository` (IStarshipsRepository.cs)
            > This defines the repository for the `Starship` model.
        - #### `class PeopleRepository` (PeopleRepository.cs)
            > The main implementation of the repository for the `People` model which contains all the API requests against `swapi`.
        - #### `class IStarshipsRepository` (StarshipsRepository.cs)
            > This defines the repository for the `Starship` model which contains all the API requests against `swapi`.
    - #### `class APIResponse` (APIResponse.cs)
        > This generic class defines the DTO for the body of responses from `swapi` for use with RestSharp.
    - #### `class Fetch` (Fetch.cs)
        > This `static` class contains:
        - #### Data<T>()
            > This generic method takes one of the swapi models described above (`People` and `Starship`) as a type argument and a request URL (e.g. `http://swapi.dev/api/people/` or `http://swapi.dev/api/people/?search=[name of person]`) and returns a list `List<T>` of objects we get back from `swapi`.
        - #### People()
            > This calls this `Data<T>()` method with an optional string (name of the person to search for), and returns a list of people `List<Person>` that match the request.
            ##### Examples of the requests sent by `Data<T>()` when called from this method...
            - When the parameter `name` is `null`:
                ```
                http://swapi.dev/api/people/
                ```
            - When the parameter `name` is not `null`:
                ````
                http://swapi.dev/api/people/?search=[name]
                ````
- #### appsettings.json
    Contains:
    - The database connection string
    - The API-keys for normal users `"Visitor"` and admins `"Admin"`
- #### Dockerfile
- #### Program.cs
- #### SpaceParkAPI.xml
- #### `class Startup` (Startup.cs)
    > Here we register the services (dependencies) we use in our controllers (via injection in the constructor).
    Of note:
    - The following tells Swagger to use the Xml comments from our code (Swagger reads the file `SpaceParkAPI.xml` which is generated when building the project)
        ```csharp
        c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "SpaceParkAPI.xml"));
        c.OperationFilter<HeaderFilter>();
        ```
    - Dependency injection: The following code registers our services which we can later request (e.g. in our API Controllers).
        ```csharp
        services.AddSingleton<IParkingsRepository, ParkingsRepository>();
        services.AddSingleton<ISpaceportsRepository, SpaceportsRepository>();
        services.AddSingleton<IPeopleRepository, PeopleRepository>();
        services.AddSingleton<IStarshipsRepository, StarshipsRepository>();
        ```

---

### SpaceParkTest
[Go to top of document](#Documentation)

> todo

## API documentation
[Go to top of document](#Documentation)

> todo

## Sources & Credits
[Go to top of document](#Documentation)

- [Jakob Kallin](https://jakobkallin.com/) creator of `ShowMenu()` (used in `SpaceParkConsole`)

