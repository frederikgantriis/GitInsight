# README

## Overleaf

Link to [Overleaf](https://www.overleaf.com/5821361738chhyxxvjsbrj)

## Run with Docker

To build image:
```bash
> docker build -t git-insight -f Dockerfile .
```
To run image in container:
```bash
> docker run -it --rm git-insight
```
## Initial setup of database

```bash
> dotnet user-secrets set "ConnectionStrings:GitInsight" "Server=localhost;Database=GitInsight;User Id=postgres;Password=<YourStrong@Passw0rd>;"

> dotnet ef database update
```
