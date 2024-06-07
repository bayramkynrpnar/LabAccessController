FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build
WORKDIR /app
COPY . .
RUN dotnet restore -r linux-x64

RUN dotnet publish -o /app/published-app -r linux-x64

FROM mcr.microsoft.com/dotnet/runtime:6.0-bullseye-slim-amd64
WORKDIR /app
COPY --from=build /app/published-app /app
ENTRYPOINT [ "dotnet", "LabAccessController.dll" ]
