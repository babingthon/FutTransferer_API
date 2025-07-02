FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

COPY *.sln .
COPY src/*/*.csproj ./

RUN for file in $(ls ./*/*.csproj); do mkdir -p ${file%/*} && mv $file ${file%/*}; done

RUN dotnet restore "*.sln"

COPY . .

RUN dotnet publish "src/Presentation/FutManagement.Presentation.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FutManagement.Presentation.dll"]