#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["advance-csharp/advance-csharp.csproj", "advance-csharp/"]
COPY ["advance-csharp.dto/advance-csharp.dto.csproj", "advance-csharp.dto/"]
COPY ["advance-csharp.service/advance-csharp.service.csproj", "advance-csharp.service/"]
COPY ["advance-csharp.database/advance-csharp.database.csproj", "advance-csharp.database/"]
RUN dotnet restore "advance-csharp/advance-csharp.csproj"
COPY . .
WORKDIR "/src/advance-csharp"
RUN dotnet build "advance-csharp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "advance-csharp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "advance-csharp.dll"]