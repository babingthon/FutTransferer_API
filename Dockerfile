FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["src/Presentation/FutManagement.Presentation.csproj", "src/Presentation/"]
COPY ["src/Application/FutManagement.Application.csproj", "src/Application/"]
COPY ["src/Infrastructure/FutManagement.Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Core/FutManagement.Core.csproj", "src/Core/"]
RUN dotnet restore "src/Presentation/FutManagement.Presentation.csproj"

COPY . .
WORKDIR "/src/src/Presentation"
RUN dotnet publish "FutManagement.Presentation.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FutManagement.Presentation.dll"]