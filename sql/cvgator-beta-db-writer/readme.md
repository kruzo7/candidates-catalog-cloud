# Warning
Publishing DB will remove User, Login, Role settings and CHANGE_TRACKING.

Implementing it in Post Deploy scripts ended in failure at the moment of this writing this.

There is some article about CHANGE_TRACKING problems.
https://www.mssqltips.com/sqlservertip/3316/how-to-enable-change-tracking-in-a-sql-server-database-project/

Other sources says User/Login is not supported now on Azure...
