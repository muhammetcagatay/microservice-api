FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
EXPOSE 80

COPY src/Gateway/APIGateway/*.csproj src/Gateway/APIGateway/
RUN dotnet restore src/Gateway/APIGateway/*.csproj
COPY . .
RUN dotnet publish src/Gateway/APIGateway/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","APIGateway.dll"]