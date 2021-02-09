#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["fontes/Softplan.ApiUm/Softplan.ApiUm.csproj", "fontes/Softplan.ApiUm/"]
RUN dotnet restore "fontes/Softplan.ApiUm/Softplan.ApiUm.csproj"
COPY . .
WORKDIR "/src/fontes/Softplan.ApiUm"
RUN dotnet build "Softplan.ApiUm.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Softplan.ApiUm.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Softplan.ApiUm.dll"]