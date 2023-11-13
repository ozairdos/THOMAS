#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["THOMAS_WEB.NET/THOMAS_WEB.NET.csproj", "THOMAS_WEB.NET/"]
RUN dotnet restore "THOMAS_WEB.NET/THOMAS_WEB.NET.csproj"
COPY . .
WORKDIR "/src/THOMAS_WEB.NET"
RUN dotnet build "THOMAS_WEB.NET.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "THOMAS_WEB.NET.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "THOMAS_WEB.NET.dll"]