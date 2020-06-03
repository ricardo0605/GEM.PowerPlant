# GEM.PowerPlant

This code was created to solve the GEM PowerPlant challenge and it is composed by an Api and a log server - datalust/seq.
The api is expose at: http://localhost:8888/swagger and the seq is expose at: http://localhost:5341.

The solution was built using the following technologies:

* .net core v2.2
* asp.net core v2.2
* automapper v9.0
* automapper.extensions.microsoft.dependencyinjection v7.0.0
* serilog.aspnetcore v3.2.0
* serilog.enrichers.environment v2.1.3
* serilog.enrichers.process v2.0.1
* serilog.enrichers.thread v3.1.0
* serilog.settings.configuration v3.1.0
* serilog.sinks.seq v4.0.0
* swashbuckle.aspnetcore v4.0.1

# How to build
1. Extract the zip file
2. cd ./GEM.PowerPlant
3. docker-compose up

Note: When finishing the tests, run docker-compose down.
