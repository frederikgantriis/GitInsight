FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Clone git repo
COPY . ./

# Restore as distinct layers
RUN dotnet restore

# Test project 
WORKDIR /App/GitInsight.Tests
RUN dotnet test


# TODO: Implement runtime image correctly in docker
# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0

# # Install git
# RUN apt-get install git

# WORKDIR /App
# COPY --from=build-env /App/out .
# ENTRYPOINT ["dotnet", "GitInsight.dll"]