# FizzBuzz
This is an ASP.NET Core 8.0 Web App.<br />
## Packages
NuGet package: Moq - For unit testing
## Endpoints:
[Post] .../api/FizzBuzz;<br />
Request body type: array of any, e.g. [1, 3, 5, null, "A", 23]<br />
## Docker:
Command to build: docker build -t fizz-buzz:1.0.0<br />
Command to run: docker run -d -p 8080:8080 fizz-buzz:1.0.0<br />
### Note:
In order to test swagger from docker build, ENV ASPNETCORE_ENVIRONMENT=Development is added in Dockerfile
