This is a reproduction repo for https://github.com/frankhommers/Hangfire.PostgreSql/issues/163

To run:

Install Postgres 14. Username and password should be postgres/postgres, but you can change this if you want, just change the connection string.
Create a database called "hangfire"

Check in postgres (pgadmin is fine) the connections. You don't need PGBouncer or anything.

Run the project.

See video:

![Reproduction](reproduction.gif)