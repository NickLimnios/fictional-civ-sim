# Use the .NET runtime to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory inside the container
USER app
WORKDIR /app

# Expose the default ports
EXPOSE 8080
EXPOSE 8081
EXPOSE 5000

# Use the .NET 8 SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

# Copy the project files
WORKDIR /src
COPY ["fcs.api.csproj", "."]

# Restore dependencies
RUN dotnet restore "./fcs.api.csproj"

# Copy the project files
COPY . .
WORKDIR "/src/."

# Build the application
RUN dotnet build "./fcs.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./fcs.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Set the working directory for the runtime image
FROM base AS final
WORKDIR /app

# Copy the published application from the previous stage
COPY --from=publish /app/publish .

# Set the command to run the application
ENTRYPOINT ["dotnet", "fcs.api.dll"]