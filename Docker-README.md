Developing Within a Docker Container
=============================================

I have added scripts that will let youo bootstrap your development environment
inside of a Docker container. This is especially handy if your workstation is
running an unsupported Linux environment like Arch or Solus.

Running the Container
--------------------------

This first step is to start the container. From inside the main project folder,
you can easily invoke the script to start the container; all of the relevant
scripts are in the "docker" directory.

    docker/run
    
Docker will pull down the image, start up a container and then open up a
Terminal window, an Emacs instance and Visual Studio Code. You can customize
these scripts, for instance, you may not want to start Emacs.

Once the container is up and running, you need to install some stuff...

### Install .Net

The .Net tools are installed, run restore to pull down the runtime,
dependencies, etc.
  
    dotnet restore

### Install NodeJS Dependencies

NodeJS comes installed, you just need to setup Gulp and pull down the project's
dependencies.

    npm install --global gulp-cli
    npm install    

### Optional Emacs Dependencies

If you're using Emacs, install the following to support the Javascript tooling.

    npm install --global tern js-beautify jshint

Build and Run the Project
-------------------------------

From here, you can follow along with the main project README file.
