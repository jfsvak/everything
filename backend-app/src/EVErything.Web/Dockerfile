FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
RUN apt-get update
RUN apt-get -y install vim
RUN apt-get -y install telnet
RUN apt-get -y install iputils-ping
RUN apt-get -y install net-tools
EXPOSE 59987
EXPOSE 44313

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY EVErything.Web/EVErything.Web.csproj EVErything.Web/
COPY EVErything.Business/EVErything.Business.csproj EVErything.Business/
RUN dotnet restore EVErything.Web/EVErything.Web.csproj
COPY . .
WORKDIR /src/EVErything.Web
RUN dotnet build EVErything.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EVErything.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EVErything.Web.dll"]
