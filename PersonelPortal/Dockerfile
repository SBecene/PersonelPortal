# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY PersonelPortal.csproj ./
RUN dotnet restore "./PersonelPortal.csproj"

COPY . ./
RUN dotnet publish "./PersonelPortal.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Render genelde PORT environment variable verir
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PersonelPortal.dll"]
