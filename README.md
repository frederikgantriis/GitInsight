# README

## Run with Docker

To build image:
    docker build -t git-insight -f Dockerfile .

To run image in container:
    docker run -it --rm git-insight

## Initial setup of database

```bash
> dotnet user-secrets set "ConnectionStrings:GitInsight" "Server=localhost;Database=GitInsight;User Id=postgres;Password=<YourStrong@Passw0rd>;"

> dotnet ef database update
```
