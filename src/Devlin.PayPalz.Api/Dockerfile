#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Devlin.PayPalz.Api/Devlin.PayPalz.Api.csproj", "src/Devlin.PayPalz.Api/"]
RUN dotnet restore "src/Devlin.PayPalz.Api/Devlin.PayPalz.Api.csproj"
COPY . .
WORKDIR "/src/src/Devlin.PayPalz.Api"
RUN dotnet build "Devlin.PayPalz.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Devlin.PayPalz.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Devlin.PayPalz.Api.dll"]