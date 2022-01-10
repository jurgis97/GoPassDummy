# GoPassDummy
GoPassDummy is an API made with .NET 5 (ASP.NET) as a task from TietoEVRY

Running mariaDb
```
docker run -d --name GoPassDummy -p 3306:3306 -v my_initdb:/data/mariadb --env MARIADB_USER=goadmin --env MARIADB_PASSWORD=jasnaresort --env MARIADB_ROOT_PASSWORD=jasnaresort  mariadb:latest
```