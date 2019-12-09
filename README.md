# .NET CORE 3.0 Microservices Boilerplate
Microservices architecture boilerplate with an **API GATEWAY**, **Auth Resource** and **User Microservice**. 

**Swagger API Documentation**, **Security with JWT** (Authentication, Authorization based on roles in token), **Globalized Exception Handler** that supports custom exceptions.

# Structure
The basic structure looks like this:

![application structure](https://i.ibb.co/Dwfky4g/New-Project.png)

Pretty frequent architecture; client sends a request to the API Gateway, it decides where the request will proceed. Assuming all of our microservices are secured with at least JWT Authorization, Auth Resource provides a new JWT.

### Client

In this case, client is either Postman, Insomnia etc. or Swagger Documentation which is implemented in *User Microservice*.
There are **Nuget Packages** including [this one](https://github.com/Burgyn/MMLib.SwaggerForOcelot) that provide Swagger Documentation on the *Gateway* level, but it is yet to be implemented in this project.

### API Gateway
API Gateway is implemented using [Ocelot](https://github.com/ThreeMammals/Ocelot).  **Ocelot** makes it very simple to map microservices to specific routes using only *json configuration file* (in this case called `ocelot.json`.

> This application runs on `http://localhost:5000`

### Auth Resource
Auth Resource is a simple REST Service that provides us with **JWT** (JSON Web Token) which we must propagate through ours microservices in order to pass the security gates. 

In this case, there is a *util class* called `JwtGenerator` with method called `Generate` which takes two arguments; username (for JWT sub Claim) and role name. Role name is essential since we want to guard our endpoints in microservices with `[Authorize(Roles = "ROLE_NAME")]`.

> This application runs on `http://localhost:5000/auth` in Ocelot, or on `http://localhost:40000/` on its own

JWT is set to expire in 24 hours.

You can change all JWT Claims and properties in `Generate` method, mentioned above.

## User Microservice
This microservice contains some basic Web API structure. (Rest Controller, DTOs, Service etc.)

>**Initializers** - Any class that implements `IInitializer` interface will be treated as an Initializer and will be called in `ConfigureServices` method of `Startup.cs` file. The idea behind this is to separate responsibilities into smaller groups, thus we can find the common `SingletonInitializer` that will initialize all singleton objects needed for *Dependency Injection*, `SecurityInitializer` which is pretty self explanatory etc.

> This application runs on `http://localhost:5000/users` in Ocelot, or on `http://localhost:40001/` on its own

# Microservices Communication

Communication between microservices can be both async and sync. Synchronous (*REST*) communication is yet to be implemented in near future, though asynchronous (*RabbitMQ*) will be when it becomes necessary.

# Further Steps
The next step would be to see this boilerplate in action, gather experiences and modify the project.

## Todo
- [ ] Implement Swagger in API Gateway layer - Ocelot Swagger
- [ ] Implement synchronous communication between microservices
- [ ] Add mailing service
- [ ] Add file upload service
- [ ] Implement asynchronous communication between microservices
- [ ]  Implement *Refresh Token* system
- [ ] Add Localization
