FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CleanArchDotnet.API/CleanArchDotnet.API.csproj", "src/CleanArchDotnet.API/"]
COPY ["src/CleanArchDotnet.Infra/CleanArchDotnet.Infra.csproj", "src/CleanArchDotnet.Infra/"]
COPY ["src/CleanArchDotnet.Core/CleanArchDotnet.Core.csproj", "src/CleanArchDotnet.Core/"]
COPY ["src/CleanArchDotnet.SharedKernel/CleanArchDotnet.SharedKernel.csproj", "src/CleanArchDotnet.SharedKernel/"]
RUN dotnet restore "src/CleanArchDotnet.API/CleanArchDotnet.API.csproj"
COPY . .
WORKDIR "/src/src/CleanArchDotnet.API"
RUN dotnet build "CleanArchDotnet.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchDotnet.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchDotnet.API.dll"]
