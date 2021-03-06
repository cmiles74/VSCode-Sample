# Working Sample ASP.Net Core with Web API Application

This project provides a sample ASP.Net Core web application with Web API that
will build and run on .Net Core 1.0.1. It will server up a sample single page
web application that uses Bootstrap and React. The general idea is that you 
would *copy* the repository and use it as a basis for your own project.

This sample project pairs well with my [Visual Studio Code (VS Code) Docker 
image](https://github.com/cmiles74/docker-vscode). That image includes
everything you need to get started and it's all setup and sorted out for you.
This project includes VSCode tasks and launch targets to make development
easier.

NOTE: This project hasn't been updated in a while and is pretty out-of-date.

## Installing Project Dependencies

First off, you need .Net Core 1.0.1 or better installed. Installation is 
different depending on the operating system you are using, check out these
pages for more information. If you are using Visual Studio, you might be all
set already. 

 * [.Net Core](https://www.microsoft.com/net)

This application uses NodeJS and Gulp to build the client-site 
application. If you don't have NodeJS installed, you can download it from the
Node.js website, I recommend using the "LTS" version.

 * [Node.js Download Page](https://nodejs.org/en/download/)

Node.js comes with the Node Package Manager (NPM). To install the Grunt tool, 
open a terminal session  (in VS Code, choose "Integrated Terminal" from 
under the "View" menu, in Visual Studio open up a new command prompt window 
and navigate into your project folder) and type

    npm install -g grunt-cli

After install Grunt on Windows, you may have to open a new terminal session 
before you can actually use it.

## Building the Application

To build the application, open up a terminal session and type...

    dotnet build

If you are using Visual Studio, you may simply choose "Build Solution" from 
under the "Build" menu.

To build the client side application, type the following into a terminal 
session...

    gulp build

Or, in VS Code, choose the "Command Palette" from under the "View" and type 
"build" to choose "Run Build Task", or press `Ctrl-Shift-B`.

The client side application will build into the "wwwroot" folder so that it
can be served up by the server side application.

## Setup the Database

The application uses a SQLite database to store it's data, it's stored on-disk
in `bin\Debug\netcoreapp1.0`. After building the application, apply the
migrations to create this database.

    dotnet ef database update

## Running the Application

To run the server side application, open up a terminal session and type...

    dotnet run

In VS Code, you can select "Debug" from under the "View" menu and choose the
".Net Core Launch (web)" target. This will also attempt to open the application
in your default web browser.

In both cases, the server side application will build (if necessary) and then
start running. The server application will serve the static files in the
"wwwroot" folder, this contains the client side application.

That's all well and good, but not much fun from a development point-of-view.
To develop interactively, you can type the following in your terminal session:

    gulp run

In VS Code, you can invoke the "Command Palette" and type "run" to select the
"Run Task" option and then choose "run".

### Stopping the Application in Visual Studio Code

To stop the running application task in VS Code, you can invoke the "Command
Palette" and type "term" to select "Tasks: Terminate Running Task".
