FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["WebStore.WebApplication/WebStore.WebApplication.csproj", "WebStore.WebApplication/"]
RUN dotnet restore "WebStore.WebApplication/WebStore.WebApplication.csproj"
COPY . .
WORKDIR "/src/WebStore.WebApplication"
RUN dotnet build "WebStore.WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebStore.WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebStore.WebApplication.dll"]