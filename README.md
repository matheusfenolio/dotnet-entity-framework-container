# Sumary

Project in dotnet 6 using EntityFrameworkCore, Postgre, Container. Everything made in VSCode using a Linux OS machine.

![BUILD](https://github.com/matheusfenolio/dotnet-entity-framework-container/actions/workflows/build.yml/badge.svg)

## How to

### Setup environment

Fist, you're going to install dotnet in your machine.

>This command is for a Arch Linux machine. You can found the steps for you OS here: https://dotnet.microsoft.com/en-us/download

```bash
sudo pacman -S dotnet-sdk aspnet-runtime
```

Now create PostgesSQL service. I decided to create it using a container.

```bash
docker run --name postgres -e POSTGRES_PASSWORD=root -p 5432:5432 -d postgres
```

Connect in your PostgresSQL and create the database dotnet.

```sql
CREATE DATABASE dotnet
```

Then add some tool to handle EntityFramework to your database.

```bash
dotnet tool install --global dotnet-ef
```

Inside the project cloned in your machine.

```bash
dotnet ef migrations add Initial --context PostgresContext
```

```bash
dotnet ef database update --context PostgresContext
```

### Run

#### Locally

Make sure that you have dotnet 6 installed in your machine.

```bash
dotnet run
```

#### Docker

>In order for the dotnet container communicate with Postgres container, you must change the *DefaultConnection* present in *appsettings.json* with your local machine's IP.

```json
{
"ConnectionStrings": {
    "DefaultConnection": "Server=YOU_IP_HERE;Port=5432;Database=dotnet;User Id=postgres;Password=root;"
},
"Logging": {
    "LogLevel": {
    "Default": "Information",
    "Microsoft.AspNetCore": "Warning"
    }
},
"AllowedHosts": "*"
}
```

Build image.

```bash
docker build -t dotnet-six -f Containerfile .
```

Create container.

```bash
docker run --name dotnet-six -p 8000:80 dotnet-six
```

## Endpoints

>You can go to https://projecturl:port/swagger and test everything there!

### /api/User

#### POST

Add a user.

```bash
curl -X 'POST' 'https://localhost:7206/api/User' -H 'accept: text/plain' -H 'Content-Type: application/json' -d '{ "name": "Name", "email": "mail@mail.com" }'
```

#### GET

Return all users.

```bash
curl -X 'GET' 'https://localhost:7206/api/User' -H 'accept: text/plain'
```

#### GET

Get user by id.

```bash
curl -X 'GET' 'https://localhost:7206/api/User/6dc55597-c935-4a6a-ba5c-cd57035cf43d' -H 'accept: text/plain' 
```

#### PUT

Update user by id.

```bash
curl -X 'PUT' 'https://localhost:7206/api/User/6dc55597-c935-4a6a-ba5c-cd57035cf43d' -H 'accept: */*' -H 'Content-Type: application/json' -d '{ "name": "User", "email": "mail@mail.com" }'
```

#### DELETE

Delete user by id.

```bash
curl -X 'DELETE' 'https://localhost:7206/api/User/6dc55597-c935-4a6a-ba5c-cd57035cf43d' -H 'accept: */*' 
```
