# 1. Build Aşaması (.NET 8 SDK kullanıyoruz)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Proje dosyalarını kopyalayıp bağımlılıkları yükleyelim
COPY *.sln .
COPY OnlineUrunYonetimi/*.csproj ./OnlineUrunYonetimi/
RUN dotnet restore

# Tüm dosyaları kopyalayıp yayınlayalım (Publish)
COPY . .
WORKDIR /app/OnlineUrunYonetimi
RUN dotnet publish -c Release -o /out

# 2. Çalışma Zamanı (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Render için portu 10000 olarak sabitliyoruz
ENV ASPNETCORE_URLS=http://+:10000

# SQLite veritabanı dosyasının yazılabilir olması için (BozokGym.db örneğindeki gibi)
USER root
RUN chmod -R 777 /app

ENTRYPOINT ["dotnet", "OnlineUrunYonetimi.dll"]