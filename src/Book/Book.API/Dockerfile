FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
EXPOSE 80
COPY src/Book/Book.API/*.csproj src/Book/Book.API/
RUN dotnet restore src/Book/Book.API/*.csproj
COPY . .
RUN dotnet publish src/Book/Book.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","Book.API.dll"]