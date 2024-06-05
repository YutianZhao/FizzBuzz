# FizzBuzz
This is an ASP.NET Core 8.0 Web App.<br />
## Packagee
NuGet package:<br />
NUnit - For unit testing<br />
Moq - For mocking in unit test<br />
## Endpoints:
[Post] .../api/FizzBuzz;<br />
Request body type: array of any, e.g. [1, 3, 5, null, "A", 23]<br />
## Docker:
Command to build: docker build -t fizz-buzz:1.0.0<br />
Command to run: docker run -d -p 8080:8080 fizz-buzz:1.0.0<br />
### Note:
In order to test swagger from docker build, ENV ASPNETCORE_ENVIRONMENT=Development is added in Dockerfile
<br />
## Single Responsibility
FizzBuzzService: Handles logic of FizzBuzz.<br />
FizzBuzzController: Manages HTTP requests and responses, FizzBuzzService is injected.<br />
## Separation of Concerns
FizzBuzzService: The service layer that encapsulate business logic, which separate from Web API layer.<br />
FizzBuzzController: The Web API layer, and it is for HTTP call and input validation. <br />
Dependency Injection: Register FizzBuzzService to IoC container and inject it to FizzBuzzController, making sure they are separated.<br />
## Test Automation (Unit and/or Integration)
Unit Test: Separate project to ensure logic and can be tested independently with "Mock" from Moq package.<br />
### This structure ensures code maintainability, testability, and scalability
