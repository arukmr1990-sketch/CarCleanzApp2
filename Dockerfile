# Stage 1: Build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the csproj and restore dependencies
COPY CarCleanzApp/*.csproj ./CarCleanzApp/
RUN dotnet restore ./CarCleenzApp/CarCleanz.csproj

# Copy the rest of the files
COPY . .

# Build and publish the app
RUN dotnet publish ./CarCleanzApp/CarCleanz.csproj -c Release -o /app

# Stage 2: Run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

EXPOSE 80
ENTRYPOINT ["dotnet", "CarCleanz.dll"]
