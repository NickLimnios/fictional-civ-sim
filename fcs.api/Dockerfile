# Base image for the .NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set working directory inside the container
WORKDIR /app

# Expose required ports
EXPOSE 8080
EXPOSE 5000

# Add a writable directory for SQLite database
RUN mkdir -p /app/Data && chmod -R 777 /app/Data

# Image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

# Set working directory for build
WORKDIR /src

# Copy project file(s) and restore dependencies
COPY ["fcs.api.csproj", "."]
RUN dotnet restore "./fcs.api.csproj"

# Copy the rest of the application files
COPY . .

# Build the application
RUN dotnet build "./fcs.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./fcs.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final

# Set working directory inside the container
WORKDIR /app

# Copy published application from build stage
COPY --from=publish /app/publish .

# Set default user for security
RUN adduser --disabled-password appuser && chown -R appuser:appuser /app
USER appuser

# Command to run the application
ENTRYPOINT ["dotnet", "fcs.api.dll"]
