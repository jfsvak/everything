FROM mcr.microsoft.com/dotnet/core/runtime
WORKDIR /app

COPY EVErything.Web/EVErything.Web.csproj ./EVErything.Web/
COPY EVErything.Business/EVErything.Business.csproj ./EVErything.Business/
RUN dotnet restore EVErything.Web/EVErything.Web.csproj

COPY ./EVErything.Web/. ./EVErything.Web/
COPY ./EVErything.Business/. ./EVErything.Business/

RUN dotnet publish -c Debug -f netcoreapp2.2 -o /app/publish EVErything.Web/EVErything.Web.csproj

# expose on port 5000. Anything below 1024 requires root, and we are not running as root
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

WORKDIR /app/publish
ENTRYPOINT ["dotnet", "EVErything.Web.dll"]