var builder = DistributedApplication.CreateBuilder(args);

var mysql = builder
    .AddMySql("mysql")
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var mysqldb = mysql
    .AddDatabase("ToDoMng");

var apiService = builder
    .AddProject<Projects.PI_ToDoMng_WebApi>("api")
    .WithReference(mysqldb)
    .WaitFor(mysqldb);

builder.Build().Run();
