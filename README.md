# GEM.PowerPlant

This code was created to solve the GEM PowerPlant challenge and it is composed by an Api and a log server - datalust/seq.
The api is expose at: http://localhost:8888 and the seq is expose at: http://localhost:5340.

The solution was built using the following technologies:

* .net core v2.2
* asp.net core v2.2
* automapper v9.0
* automapper.extensions.microsoft.dependencyinjection v7.0.0
* serilog.aspnetcore v3.2.0
* serilog.settings.configuration v3.1.0
* serilog.sinks.seq v4.0.0

# How to build
1. git clone https://github.com/ricardo0605/GEM.PowerPlant.git
2. cd ./GEM.PowerPlant
3. docker-compose up
