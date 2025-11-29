# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyVaccine.Web/MyVaccine.Web.csproj", "MyVaccine.Web/"]
RUN dotnet restore "MyVaccine.Web/MyVaccine.Web.csproj"
COPY . .
WORKDIR "/src/MyVaccine.Web"
RUN dotnet build "MyVaccine.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyVaccine.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyVaccine.Web.dll"]
