
# Order Management

This project is designed for managing order operations by using state machine.

<img src="./images/state-diagram.png" alt="" width="800px"/>

## __RUN__

__Way 1__

The project could be executed via _docker-compose_. If you have an IDE which is capable of debugging _docker-compose file_, _docker-compose.yml_ which is located at the main directory would  be useful for you.

In case of choosing this way to run the project, you can reach swagger screen via _http://localhost:2000_.

Note: Because the sql server needs more time to be ready compared to SpecificationPatternExample-Api, it might take a while for you to reach the endpoints after `docker-compose up` command execution.

__Way 2__

If you want to execute the project without using docker, it is required that you set the connection strings inside the SpecificationPatternExample/appsettings.json file.

Changes to be made are:
1. DbConfig -> DbOptions -> ConnectionStr value should be changed with the Sql Server connection string that you have.
2. DistributedLockConfig -> DistributedLockOptions -> ConnectionStr value should be changed with the Sql Server connection string that you have.
3. MassTransitConfig -> MassTransitOptions -> HostName, VirtualHost, Username, Password values should be changed with the RabbitMq platform information that you have.

In the first item if the connection string information is invalid, application will crash immediately. In order to check if the remaining settings are valid, you can use http://localhost:5000/healthchecks-ui endpoint.

<img src="./images/health-checks-ui.png" alt="" width="800px"/>

