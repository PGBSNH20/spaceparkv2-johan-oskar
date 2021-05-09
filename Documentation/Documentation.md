<pre style="font-family:monospace;line-height: 1.2;white-space: pre;">
 _____   _   _   ____     __________________       ____         _______   _________ 
|_   _| | |_| | |  __|   /                  \     /    \       /       | |         |
  | |   |  _  | |  __|  /    ____     ___    |   /      \     /    ____| |    _____|
  |_|   |_| |_| |____|  \    \   |   |___|   |  /   /\   \   /    /      |   |_____ 
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

# Documentation

This is the first project in the course "Webbutveckling Backend" in the ".NET Utvecklare" (2020-2022) programme at Teknikhögskolan.

## Table of contents
- [The assignment's specification](#The-assignment-Specification)
- [Process](#Process)
- [How to Use & Install](#How-to-Use-&-Install)
- [Code Structure](#Code-Structure)
  - [SpaceParkAPI](#SpaceParkAPI)
  - [SpaceParkTest](#SpaceParkTest)
- [Flow Chart](#Flow-Chart)
- [API documentation](#API-documentation)
- [Sources & Credits](#Sources-&-Credits)
- [](#)

## The assignment (Specification)
##### [Go to top of document](#Documentation)

### [See the repository's main README.md](../README.md).

## Process
##### [Go to top of document](#Documentation)

We decided to use the pair programming technique since we wanted to develop the project together.
We used Microsoft Teams and Github to facilitate this.
Some of the other tools we used were:
- Visual Studio and Visual Studio Code
- REST Client (an extension for VS Code): to send REST API requets to our api (used to manually test our API).
- [https://app.diagrams.net](https://app.diagrams.net): for our flow chart.

We began by creating some basic [User Stories](UserStories.md) and by designing [the API](APIDesign.md).
Using this we could implement some the `Parking` and `Spaceport` models and the `API Controller` for the former.


## How to Use & Install
##### [Go to top of document](#Documentation)

> The following assumes that you have Docker Desktop, Visual Studio 2019 installed and (.NET 5, ASP.NET 5)

To build and use the API:
- Clone the repository
- Open `Source/SpacePark.sln` and build the solution.
- In `Source/`, start the database with `docker-compose up`.
- In visual studio's Nuget's Package Manager Console, apply the migrations with `Update-Database`
- In Visual Studio, start the `SpaceParkAPI` project.
- Using `Rest Client`, SwaggerUI or Postman, make API requests.
- Eat cake, you're a teapot (maybe).


## Code structure
##### [Go to top of document](#Documentation)


### **SpaceParkConsole**
```csharp
throw new NotImplementedException();
```


### SpaceParkAPI
##### [Go to top of document](#Documentation)

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
    - #### `class ApiKeyMiddleware` (ApiKeyMiddleware.cs)
        This `Middleware` 

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
    In this class we:
    - Register services (dependencies) we use in our controllers (via injection in an `API Controllers`constructor).
    - Configure Swagger.
    - Add all middleware.
    
    Of note:
    - #### `ConfigureServices()`
        - Register the database context:

            The following imports the connection string from [appsettings.json](appsettings.json) and registers our database context `SpaceParkContext`:
            ```csharp
            services.AddDbContext<SpaceParkContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            ```
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
    - #### `Configure()`
        The following adds our `ApiKeyMiddleware` ([click here for details](#class-ApiKeyMiddleware-ApiKeyMiddleware.cs)):
        ```csharp
        app.UseMiddleware<ApiKeyMiddleware>();
        ```

### SpaceParkTest
##### [Go to top of document](#Documentation)

> todo

### Flow Chart
##### [Go to top of document](#Documentation)

![](Project1_SpacePark2_FlowChart.svg)

## API documentation
##### [Go to top of document](#Documentation)

> [go to "readme.md"](readme.md)

## Sources & Credits
##### [Go to top of document](#Documentation)

- [Jakob Kallin](https://jakobkallin.com/) creator of `ShowMenu()` (used in `SpaceParkConsole`)
- [REST Client (extension for Visual Studio Code)](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)
- [https://app.diagrams.net](https://app.diagrams.net)

