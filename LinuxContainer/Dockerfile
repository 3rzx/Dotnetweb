FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

COPY . ./

#RUN dotnet test ./Tests/Tests.csproj

RUN dotnet publish -c Release -o publish

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app

COPY --from=build /app/publish ./

ENTRYPOINT ["dotnet", "DotnetWeb.dll"]