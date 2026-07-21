# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution
COPY . .

# Restore
RUN dotnet restore GoldERP.sln

# Publish Blazor project
RUN dotnet publish GoldERP.Blazor/GoldERP.Blazor.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "GoldERP.Blazor.dll"]