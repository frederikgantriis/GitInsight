FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

RUN apt-get install git

# Copy everything
RUN git clone https://github.com/frmo24042/GitInsight.git
# Restore as distinct layers
WORKDIR /App/GitInsight

RUN dotnet restore

WORKDIR /App/GitInsight/GitInsight
RUN dotnet add package LibGit2Sharp --version 0.27.0-preview-0182

WORKDIR /App/GitInsight
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/GitInsight/out .
ENTRYPOINT ["dotnet", "GitInsight.dll"]