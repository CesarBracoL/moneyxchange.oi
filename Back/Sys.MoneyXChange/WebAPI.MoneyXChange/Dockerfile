#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["WebAPI.MoneyXChange/WebAPI.MoneyXChange.csproj", "WebAPI.MoneyXChange/"]
RUN dotnet restore "WebAPI.MoneyXChange/WebAPI.MoneyXChange.csproj"
COPY . .
WORKDIR "/src/WebAPI.MoneyXChange"
RUN dotnet build "WebAPI.MoneyXChange.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.MoneyXChange.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.MoneyXChange.dll"]