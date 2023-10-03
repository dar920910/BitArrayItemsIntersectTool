# :zero: Boolean Array Explore Tool :one:

:pushpin: Currently, the project is included to my summary repository of demo projects:

:link: [Demo Projects Workshop 2023+](https://github.com/dar920910/Demo-Projects-Workshop)

---

## :sound: About the Project History

This project implements a tool to explore the content of a custom two-dimensional array:

- Detecting "neighbour" elements for a selected element of the array
- Finding nodes of the shortest route between two elements of the array

The project was inspired my first test project from a technical interview from 2019.
I added more features to its initial idea and extended project's codebase infrastructure.

## :dart: Planned Further Improvements

There are two important areas which should be improved when further development of this project:

:collision: Check conditions when finding the route between two elements is either impossible or unsecure, i.e. can cause to throwing runtime exception when detecting a route.
:collision: Improve algorithms of finding the shortest route between two elements because its current implementation is created as a minimalistic start point for further investigation in this scope.

## :question: About the Repository Structure

This repository contains the following projects:

- **BooleanArrayExploreTool.Library** - implements the .NET class library for the project
- **BooleanArrayExploreTool.Testing** - implements NUnit-based unit tests for the project
- **BooleanArrayExploreTool.App.CLI** - implements the console application for the project
- **BooleanArrayExploreTool.App.Web** - implements the ASP.NET Core Razor Pages web application for the project

---

## :beginner: Quick Start

### :globe_with_meridians: Using Project's Web Application

1. Run the web application via Docker (see the "Run via Docker" section below).
2. Open either <https://localhost:5002> or <http://localhost:5001> URL in your web browser.
3. Set sizes of dimensions to generate a new custom boolean array with random element values.
4. Investigate the created custom boolean array. You can make the following actions to the array:
   - Find and display "neighbour" elements for a selected element from this array.
   - Try to build the shortest route between two elements of the array and then display its nodes.

### :computer: Using Project's Console Application

Run the program from the command-line via either program's executable or the **dotnet run** command.
Follow interactive prompt of the program to generate a custom boolean array and then apply a selected action to the array.

---

## :whale: Run via Docker

1. Run the **Create-DevCert-HTTPS.ps1** to generate a certificate for this application.
2. Build app's Docker image via **Execute-DockerBuild.ps1** script.
3. Run the app from a new container via any way from following:
    - **Execute-DockerRun-AppCLI.ps1** script to run project's console application
    - **Execute-DockerRun-AppWeb.ps1** script to run project's web application
    - **Execute-DockerRun-Testing.ps1** script to run project's unit tests
    - **Execute-DockerRun.ps1** script to investigate content of a container

---

## :wrench: Build Source Code

Use **.NET 6 SDK** to build this project from source code.

---

## :email: Contribute the Project

[You can contact me using any contacts from my profile page](https://github.com/dar920910#speech_balloon-how-can-you-contact-with-me-)
