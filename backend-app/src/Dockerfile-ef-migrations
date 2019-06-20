FROM mcr.microsoft.com/dotnet/core/sdk
WORKDIR /app

COPY EVErything.Web/EVErything.Web.csproj ./EVErything.Web/
COPY EVErything.Business/EVErything.Business.csproj ./EVErything.Business/
RUN dotnet restore EVErything.Web/EVErything.Web.csproj

COPY ./EVErything.Web/. ./EVErything.Web/
COPY ./EVErything.Business/. ./EVErything.Business/

RUN dotnet build -f netcoreapp2.2 EVErything.Web/EVErything.Web.csproj

ENTRYPOINT ["dotnet", "ef", "database", "update", "--startup-project", "EVErything.Web", "--project", "EVErything.Business", "--context", "AppDbContext"]
#RUN  ef database update --startup-project EVErything.Web --project EVErything.Business --context AppDbContext
#RUN dotnet ef database update --startup-project EVErything.Web --project EVErything.Web --context IdentityDbContext
