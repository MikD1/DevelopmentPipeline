FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet restore

WORKDIR /app/DemoApp.WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/DemoApp.WebApi/out .
ENTRYPOINT ["dotnet", "DemoApp.WebApi.dll"]