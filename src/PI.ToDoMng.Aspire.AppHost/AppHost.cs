var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.PI_ToDoMng_WebApi>("api");

builder.Build().Run();
