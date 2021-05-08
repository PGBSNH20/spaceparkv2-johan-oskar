<pre style="font-family:monospace;line-height: 1.2;white-space: pre;">
       ╱────────────────   ___     ┌──────<sub>\</sub>
     ╱                | /   \    |   _   \
    |   (-----|  |----`/  ^  \   |  |_)   |
     \   \    |  |    /  /_\  \  |       /
.-----)   |   |  |   /  _____  \ |  |\    ─────┐
|________/    |__|  /__/     \__\| _| \        │
                                       <sup>\</sup>───────┘
 ____    __    ____  ___     .______    ________.
 \   \  /  \  /   / /   \    |   _  \  /        |
  \   \/    \/   / /  ^  \   |  |_)  ||   (-----`
   \            / /  /_\  \  |      /  \   \
    \    /\    / /  _____  \ |  |\  \---)   |
     \__/  \__/ /__/     \__\|__| `._______/
</pre>

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
---
### **SpaceParkAPI**
- ### _Properties/_
    - ### launchSettings.json
- ### _APIModels/_
    - ### PostParking.cs
    - ### PostSpaceport.cs
- ### _Controllers/_

    - ###  ParkingsController.cs
        - ### `class ParkingsController`
            > This controller defines the `/Parking/`-endpoint, its actions and methods
            - #### `[HttpGet] GetParkings()`
                > This defines the `/Parking/`-endpoint for the `GET` method.
                #### **Attributes:**
                ```csharp
                [HttpGet]
                ```
                #### **Attributes:**
                ```csharp
                [FromQuery] string traveller
                ```
                The name of the traveller
                #### **returns:**
                ```csharp
                Task<ActionResult<IEnumerable<Parking>>>
                ```
            - #### `GetEndedForTraveller()`
                <!-- ```csharp
                async GetEndedForTraveller([FromQuery] string traveller)
                ``` -->
                >This defines the `/Parking/Ended`-endpoint for the `GET` method.
                #### **Attributes:**
                ```csharp
                [HttpGet("[action]")]
                [ActionName("Ended")]
                ```
                #### **returns:**
                ```csharp
                Task<ActionResult<IEnumerable<Parking>>>
                ```
    - ###  SpaceportsController.cs
        - ### `class SpaceportsController`
            This controller defines the `/Spaceports/`-endpoint, its actions and methods
- ### _Middleware/_
    - ### ApiKey.cs
- ### _Migrations/_
- ### _Models/_
- ### _Repositories/_
- ### _Swagger/_
- ### _swapi/_
    - ### _Controllers/_
        - ### PeopleController.cs
            - ### `class PeopleController`
                This controller defines the `/People/`-endpoint, its actions and methods
        - ### StarshipsController.cs
            - ### `class StarshipsController`
                This controller defines the `/Starships/`-endpoint, its actions and methods
    - ### _Models/_
    - ### Repositories/
        - ### StarshipsRepository.cs
            ```csharp
            class blabla
            ```
    - ### APIResponse.cs
        ```csharp
        class blabla
        ```
    - ### Fetch.cs
        ```csharp
        class blabla
        ```
- ### appsettings.json
    Contains:
    - The database connection string
    - The API-keys for normal users `"Visitor"` and admins `"Admin"`
- ### Dockerfile
- ### Program.cs
- ### SpaceParkAPI.xml
- ### Startup.cs
---
### **SpaceParkTest**

<br>
---
---
### **SpaceParkAPI**

### Properties/
### --- launchSettings.json
### APIModels/
### --- PostParking.cs
### --- PostSpaceport.cs
### Controllers/
### --- ParkingsController.cs
### --- SpaceportsController.cs
### Middleware/
<div style="margin-left:20px">

### <u>ApiKey.cs</u>

Not completed

```csharp
class
```
</div>


#### Migrations/
#### Models/
#### Repositories/
#### Swagger/
#### swapi/
#### appsettings.json
#### Dockerfile
#### Program.cs
#### SpaceParkAPI.xml
#### Startup.cs

### SpaceParkAPI
[Go to top of document](#Documentation)

### SpaceParkTest
[Go to top of document](#Documentation)

## API documentation
[Go to top of document](#Documentation)

## Sources & Credits
[Go to top of document](#Documentation)
