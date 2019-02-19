# Vueling School
## Ferran Ramírez

C# application to store and manage students in diferent streams.

## Environment

**Hardware:**  Intel Core i5-8250U CPU @ 1.60Ghz 1801Mhz 64Bit 4 cores, 8 logical processors, 8GB DDR3 RAM

**OS:** Windows 10 Pro 10.0.17134 (Build 17134)

**Software:** 
  - .NET Framework 4.7.03056
  - Docker 18.09.1, build 4c52b90

##  Structure
This project follows the DDD structure, with the one it has is split into three tiers: Presentation, DataAccess and Common.

### Testing
This project has implemented the following tests:
  - Unit tests. Implemented using "Visual Studio Unit Testing Tools"
  - Integration tests. Implemented using "Nunit"
  - Behaviour-Driven Development. Implemented using "SpecFlow"

### Plugins
The next plugins are the ones have been installed into de project to add some extra features:
> Moq
> NUnit3
> NUnit3Adapter
> SpecFlow.Runner


## Design patterns
# Abstract Factory Pattern
An abstract factory pattern has been used to create a new specific type of FileManager to be assigned to the StudentRepository on the presentation tier.
This pattern abstracts the implementation from the presentation so the repository can't know about the FileManager used although this one works properly with its own implementation of the methods overrided.

## Exceptions
All the exceptions are catched in all the funtions where they are thrown, showing the trace of each in a logfile due to the use of log4net. The handling of the exceptions consists in catching, throwing and logging them until reaching the Presentation tier where they are not thrown anymore, just shown up.

## Docker support
The image is available on [docker hub](https://hub.docker.com/r/ferranramirez/vuelingschool).

In order to build a docker image for the project, I created a Dockerfile that would build on top of the `microsoft/dotnet-framework:4.6.2` image, it would then COPY the presentation tier.

Once the image is built using `docker build -t vuelingschool .` it's ready to run with`docker run tagname`.

In order to also upload the image to the docker hub registry, I had to give the image a tag under my username using `docker tag vuelingschool ferranramirez/vuelingschool`. 
Finally, I used `docker push ferranramirez/vuelingschool` to upload the new image.

We need to note how docker automatically added 'latest' to the version as I didn't specify any, and also that docker push won't work if we're not locally logged into docker.

Also worth a note is the fact that altough the image runs and the program executes, the Console doesn't appear accept keyboard interaction and because of that it can't really be used. I found that running the image usig `docker -i -t ferranramirez/vuelingschool` solved the problem by running the app in interactive deatatched mode.

In order to pull and run the docker image for this project:
`docker pull ferranramirez/vuelingschool:latest`
And then
`docker run -i -t ferranramirez/vuelingschool`
