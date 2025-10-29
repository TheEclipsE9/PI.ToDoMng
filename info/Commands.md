### Docker

- docker image build --file 'path to Dockerfile' --tag 'tag' 'build context'
- docker container run --name 'container name' -p portOnHost:portInsideImage'image name:tag'
- docker compose build
- docker compose up
- docker compose exec mysql mysql -uToDoMngAdmin -padmin ToDoMng

### MySQL

- docker run -d --name mysql-test -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=ToDoMng -e MYSQL_USER=ToDoMngAdmin -e MYSQL_PASSWORD=admin -p 3306:3306 mysql:9
- docker exec -it mysql-test mysql -uToDoMngAdmin -padmin ToDoMng

### EF

- dotnet ef migrations add InitialCreate --project PI.ToDoMng.WebApi/PI.ToDoMng.WebApi.csproj --output-dir Database/Migrations
- dotnet ef database update --project PI.ToDoMng.WebApi/PI.ToDoMng.WebApi.csproj  --connection "server=localhost;port=3306;database=ToDoMng;user=ToDoMngAdmin;password=admin"
- dotnet ef migrations remove