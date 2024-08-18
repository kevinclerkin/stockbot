# .NET runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5280
EXPOSE 7297

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StockBotAPI/StockBotAPI.csproj", "StockBotAPI/"]
RUN dotnet restore "StockBotAPI/StockBotAPI.csproj"
COPY . .
WORKDIR "/src/StockBotAPI"
RUN dotnet build "StockBotAPI.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "StockBotAPI.csproj" -c Release -o /app/publish

# Use the .NET runtime image as the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "StockBotAPI.dll"]