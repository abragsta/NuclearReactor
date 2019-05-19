# NuclearReactor

## Description

The purpose of this application is to simulate an automated control mechanism for an imaginary Nuclear Reactor.

The pressure of the Nuclear Reactor increases when a valve is closed, and decreases when the valve is open.

The job of the automated control mechanism is to keep the reactor stable, by staying around the optimal 50% - 75% range, and never above 90%.

The pressure at any given time is displayed in a web application.

## Required Software

* [NodeJS](https://nodejs.org/en/)
* [ASP.NET Core 2.2](https://dotnet.microsoft.com/download)
* [Git](https://git-scm.com/downloads)

## Project Structure

* **nuclear-reactor-web:** React frontend to display pressure values
* **NuclearReactor.Core:** Project which contains Core business logic 
* **NuclearReactor.Core.UnitTests:** Unit Tests for Core Project
* **NuclearReactor.WebApi:** Project for running the web server that transmits pressure values to clients
* **NuclearReactor.WebApi.IntegrationTests:** Integration test project to test the entire application is working as a whole

## Getting the source code

```
git clone https://github.com/abragsta/NuclearReactor.git
```

## Running the backend server

* Navigate to the NuclearReactor.WebApi folder in a command prompt
* dotnet build
* dotnet run

## Running the web application

* Navigate to the nuclear-reactor-web folder in a command prompt
* npm install
* npm start