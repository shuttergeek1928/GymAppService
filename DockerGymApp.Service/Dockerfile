# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy everything from the context to /app
COPY . .

# Debug: List files in /app to verify the .csproj is there
RUN ls -la

# Restore and build
RUN dotnet restore DockerGymApp.Service.csproj
RUN dotnet build DockerGymApp.Service.csproj -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish DockerGymApp.Service.csproj -c Release -o /app/publish

# Stage 3: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "DockerGymApp.Service.dll"]
