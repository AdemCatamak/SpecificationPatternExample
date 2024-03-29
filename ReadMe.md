
# Specification Design Pattern

Medium üzerinde yayınlanmış bir yazıya ait örnek kodlar bu repository içerisinde yer almaktadır. Yazıya bu link aracılığı ile erişebilirsiniz: 
https://medium.com/@ademcatamak/specification-tasarim-deseni-d142692a8e41

This repo contains sample codes for the Medium article, which you can access via https://medium.com/@ademcatamak/specification-design-pattern-c814649be0ef.

The implementation of design pattern is in the _SpecificationPatternExample.Specification_ project which has no dependencies. You are free to copy this project and use it.

__Note__: You can access the implementation of the design pattern via [NuGet](https://www.nuget.org/packages/Spectacular/) using the name [Spectacular](https://github.com/AdemCatamak/Spectacular).

## __RUN__

When you run the program and send some GET requests, created sql queries can be seen via console screen. The easiest way of running the program is using `docker-compose up`. If you want to debug the code, you have two ways which are listed below.

__Way 1__

The project could be executed via _docker-compose_. If you have an IDE which is capable of debugging _docker-compose file_, _docker-compose.yml_ which is located at the main directory would be useful for you.

In case of choosing this way to run the project, you can reach swagger screen via _http://localhost:10000_.

Note: Because the sql server needs more time to be ready compared to SpecificationPatternExample-Api, it might take a while for you to reach the endpoints after `docker-compose up` command execution.

__Way 2__

If you want to execute the project without using docker, it is required that you set the connection strings inside the SpecificationPatternExample/appsettings.json file.

Changes to be made are:
1. ConnectionStrings -> SqlServer value should be changed with the Sql Server connection string that you have.

