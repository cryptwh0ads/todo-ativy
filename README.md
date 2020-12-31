# todo-ativy
Backend &amp; Frontend solution for ToDo sample app CRUD

## Functional Requirements

 - Get To-Do
 - Add To-Do to list
 - Edit To-Do
 - Remove To-Do
## Non-Functional Requirements

 - Backend should be develop with .NET EF
 - Frontend should be develop with React
## Step-by-Step (Backend)

 - Create a temporary SQL Database with name `CrudAPI`
 - Navigate to *crudApi* solution folder
 - run `dotnet restore` to restore all packages for this project
 - run `dotnet ef database update` to run the migrations to DB.
 - After success of previous step, run `dotnet run` to start the server
 - navigate to [Documentation](https://localhost:5001/swagger) to consult all endpoints available.
## Step-by-Step (Frontend)

 - Navigate to *app* folder
 - run `npm i` (if you use npm) or `yarn` (if you use yarn), to install all packages
 - On finish previous step, run `npm run start` or `yarn start`, to run application
 - test the application on [Application](http://localhost:3000)