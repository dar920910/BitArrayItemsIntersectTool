# BitArrayItemsIntersectTool

## About the Project

This project implements a tool for processing elements of a custom two-dimensional array:

- Detecting intersections between elements of a custom array
- Finding the shortest route between elements of a custom array

## About the Repository Structure

This repository contains the following projects:

- "BitArrayItemsIntersection.Library"
- "BitArrayItemsIntersection.Testing"
- "BitArrayItemsIntersection.App.CLI"
- "BitArrayItemsIntersection.App.Web"

## Prerequisites

Use **.NET 6 SDK** to build the project from source code.

## Deployment

1. Build app's Docker image via **Execute-DockerBuild.ps1** script.
2. Run the app from a new container via any way from following:
    - **Execute-DockerRun-AppCLI.ps1** script to run project's console application
    - **Execute-DockerRun-AppWeb.ps1** script to run project's web application
    - **Execute-DockerRun-Testing.ps1** script to run project's unit tests
    - **Execute-DockerRun.ps1** script to investigate content of a container
