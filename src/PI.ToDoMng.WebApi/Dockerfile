#BUILD
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY PI.ToDoMng.WebApi.csproj PI.ToDoMng.WebApi/
RUN dotnet restore PI.ToDoMng.WebApi/PI.ToDoMng.WebApi.csproj

COPY . PI.ToDoMng.WebApi/
RUN dotnet publish PI.ToDoMng.WebApi/PI.ToDoMng.WebApi.csproj -c Release -o /app

#RUNTIME
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app .

ENTRYPOINT ["dotnet", "PI.ToDoMng.WebApi.dll"]