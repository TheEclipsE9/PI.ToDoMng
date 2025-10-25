### Docker

- docker image build --file 'path to Dockerfile' --tag 'tag' 'build context'
- docker container run --name 'container name' -p portOnHost:portInsideImage'image name:tag'
- docker compose build
- docker compose up
- docker compose exec mysql mysql -uToDoMngAdmin -padmin ToDoMng
### EF

- dotnet ef migrations add InitialCreate --project PI.ToDoMng.WebApi/PI.ToDoMng.WebApi.csproj --output-dir Database
- dotnet ef database update --project PI.ToDoMng.WebApi/PI.ToDoMng.WebApi.csproj  --connection "server=localhost;port=3306;database=ToDoMng;user=ToDoMngAdmin;password=admin"
- 