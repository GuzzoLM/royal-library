# Royal Library

This is an api for searching books by author, isbn, and if the book is loved/owned/want to read by the author.

## Starting up the database

You will need to put the connection string for the SQL database in the appsettings file, unde ConnectionString--SqlDatabase
Then run the command

```shell
dotnet run %SolutionFolder%/RoyalLibrary.Migrations/RoyalLibrary.Migrations.csproj
```

This will create the necessaries tables and populate them.

## Starting the service
Run the command
```shell
dotnet run %SolutionFolder%/RoyalLibrary/RoyalLibrary.csproj
```

## Usage
Once you start the api and you can access the API documentation at the url
```shell
%YourHost%/swagger/index.html
```

The main function of the api is the search endpoint, responsible for searching the books of your interest. You can also tag a book as a book, you own, love, or want to read and search by these tags too.
Ideally these preferences are stored by user, but for the testing purposes of this exercise everyone is considered to be the same user (UserId = 1).