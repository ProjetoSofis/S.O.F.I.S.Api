FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Sofis.Api/Sofis.Api.csproj", "Sofis.Api/"]
RUN dotnet restore "Sofis.Api/Sofis.Api.csproj"

COPY . .
WORKDIR "/src/Sofis.Api"
RUN dotnet build "Sofis.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sofis.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sofis.Api.dll"]
