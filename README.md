# Repo for EVErything

### Install Identity database
   > dotnet ef database update --startup-project EVErything.Web --project EVErything.Web --context IdentityDbContext

### Install application database
   > dotnet ef database update --startup-project EVErything.Web --project EVErything.Business --context AppDbContext
   
### Adding migrations
   > dotnet ef migrations add 'nameofmigration' --startup-project . --project ../everything.business --context AppDbContext