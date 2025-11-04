
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

# Expose port 80
EXPOSE 80

# Set the entry point
ENTRYPOINT ["dotnet", "CarCleanz.dll"]
