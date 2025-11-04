# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy all project files
COPY . ./

# Restore dependencies and build the app
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Stage 2: Run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose port 8080 (Render expects web services on 8080)
EXPOSE 8080

# Set the entry point
ENTRYPOINT ["dotnet", "CarCleanzApp.dll"]
