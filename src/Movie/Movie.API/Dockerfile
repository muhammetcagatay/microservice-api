FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
EXPOSE 80
COPY src/Movie/Movie.API/*.csproj src/Movie/Movie.API/
RUN dotnet restore src/Movie/Movie.API/*.csproj
COPY . .
RUN dotnet publish src/Movie/Movie.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","Movie.API.dll"]
