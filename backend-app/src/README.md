# Backend services for EVErything

## Run backend Services locally (In VisualStudio and connect to local db)
#### Spin up a docker with mysql
  > docker run --name mysql-localdev -d -e MYSQL_ROOT_PASSWORD=unico88 -p 33306:3306 centos/mysql-57-centos7  

Or just start container if it exists
  > docker start mysql-localdev

#### Connect to mysql in docker
  > mysql -u root -p -h <IP:192.168.99.100> -P 33306

#### Prepare database for app startup.
Backend services will use EF core to migrate/update the database, but users and database schema needs to be in place first. Run script in 
  > everything-infrastructure/environments/everything-staging/setup-db-everything.sql

  






# Old/Obsolete stuff

### Install Identity database
   > dotnet ef database update --startup-project EVErything.Web --project EVErything.Web --context IdentityDbContext

### Install application database
   > dotnet ef database update --startup-project EVErything.Web --project EVErything.Business --context AppDbContext
   
### Adding migrations
   > dotnet ef migrations add 'nameofmigration' --startup-project . --project ../everything.business --context AppDbContext