FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Copy everything
COPY . ./

WORKDIR /DinosaurQuestTests

RUN dotnet restore

RUN dotnet build --no-restore

RUN dotnet test

RUN cd ..

WORKDIR /DinosaurQuestGame

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
COPY --from=build-env /DinosaurQuestGame/out .
ENTRYPOINT ["dotnet", "DinosaurQuestGame.dll"]