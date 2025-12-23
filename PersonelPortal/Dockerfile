# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyasını kopyala ve bağımlılıkları yükle
COPY ["PersonelPortal.csproj", "./"]
RUN dotnet restore "./PersonelPortal.csproj"

# Tüm dosyaları kopyala ve yayınla
COPY . .
RUN dotnet publish "PersonelPortal.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Çalıştırma aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render'ın portu dinamik ataması için
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "PersonelPortal.dll"]
