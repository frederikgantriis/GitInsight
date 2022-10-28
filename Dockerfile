FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Install git
RUN apt-get install git

# Clone git repo
RUN git clone https://github.com/frmo24042/GitInsight.git

# Restore as distinct layers
WORKDIR /App/GitInsight
RUN dotnet restore

# Install LibGit2Sharp correctly
WORKDIR /App/GitInsight/GitInsight
RUN dotnet add package LibGit2Sharp --version 0.27.0-preview-0182

# Build and publish a release
WORKDIR /App/GitInsight
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/GitInsight/out .
ENTRYPOINT ["dotnet", "GitInsight.dll"]