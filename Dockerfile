# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore
COPY CarCleanz.csproj ./
RUN dotnet restore
# Copy everything and build
COPY . .
RUN dotnet publish "CarCleanz.csproj" -c Release -o /app
 

# Stage 2: Run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENTRYPOINT ["dotnet", "CarCleanz.dll"]
