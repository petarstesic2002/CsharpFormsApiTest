# CsharpFormsApiTest
 
# Create database
`database.sql` file is in the repo root. Update the connection string in `DataAccessModels` Layer in `TestDbContext` class (It's set there and not in the API for convenience)

### Database is filled with some test data

# Disable break on Validation Exceptions (optional)
There are `FluentValidation` validators for insert and update that throw `ValidationException` if the validation fails. Because of that the project has a breakpoint if the exception if the validation is thrown. (This only happens if you run the project in Visual Studio, not through terminal)

### Solution is set to multiple startup projects (API and GUI)
### Swagger is disabled, change launchSettings in API to turn it on

# Start the project
Open `GUI` and `API` projects in a separate terminal and run `dotnet run` in each one (`API FIRST!`) or Open the solution in Visual Studio and build and start the project
