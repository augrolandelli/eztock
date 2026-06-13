# 1. Etapa de compilación (usamos el SDK oficial de .NET 10)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# Copiamos todo tu código al contenedor
COPY . .

# Restauramos las dependencias
RUN dotnet restore "src/EZtock.API/EZtock.API.csproj"

# Compilamos en modo Release
RUN dotnet publish "src/EZtock.API/EZtock.API.csproj" -c Release -o /app/publish

# 2. Etapa de producción (usamos solo el Runtime para que sea súper ligero)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Por defecto, .NET moderno usa el puerto 8080
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080

# Traemos los archivos compilados de la etapa anterior
COPY --from=build /app/publish .

# Comando de inicio
ENTRYPOINT ["dotnet", "EZtock.API.dll"]
