FROM microsoft/dotnet:2.2-sdk-alpine3.8 AS build
WORKDIR /app
#RUN apk add --update nodejs nodejs-npm
#COPY package.json .
#RUN npm install

COPY *.csproj .
#COPY NuGet.config ./

RUN dotnet restore
#RUN dotnet restore --configfile NuGet.config

#RUN dotnet build

#RUN dotnet test ./Tests/Tests.csproj

#RUN dotnet ef database update --environment LinuxContainer

COPY . .

RUN dotnet publish -c Release -o publish


FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

VOLUME /app/logs

ENTRYPOINT ["dotnet", "DotnetWeb.dll"]