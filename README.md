??? from here until ???END lines may have been inserted/deleted
# DutchTreat
Pluralsight course for Angular with Visual Studio (ASP.NET Core)


## Setup - Linux/Core

1. Clone from https://github.com/mochsner/DutchTreat

2. Download [Entity Framework Core 3.0+ on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux)

3. Install Entity framework in the project (cd into nested 'DutchTreat' solution first)

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

4. Install the .NET Core CLI tools for entity framework


```bash
# Note: only use --global tag if you're using this for other projects. I typically am.
dotnet tool install --global dotnet-ef
```

5. Get the package manager console tools

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### Install SQL Server (Ubuntu)

1. `sudo apt-get update; sudo apt-get -y upgrade; sudo reboot`

2. Add the public repository GPG keys

```bash
sudo wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
```

3. Add the SQL Server 2019 Ubuntu Repository (find url for your distro [here](https://computingforgeeks.com/how-to-install-ms-sql-on-ubuntu/))

```bash
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/18.04/mssql-server-2019.list)"
```

4. Install SQL Server

```bash
sudo apt update
sudo apt install mssql-server -y
```

5. Initialize MS SQL Server 2019 on Ubuntu 20.04/18.04/16.04

When the installation is done, proceed to set root user password by running initial setup 
`sudo /opt/mssql/bin/mssql-conf setup`
  - Edition: Developer (local only), or Express (up to 10 GB, can be used in production technically)

Optional: Check that service is started
`systemctl status mssql-server.service`

6. Install MS SQL tools and unixODBC plugin

```bash
curl https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
curl https://packages.microsoft.com/config/ubuntu/18.04/prod.list | sudo tee /etc/apt/sources.list.d/mssql-release.list
sudo apt-get install -y libodbc1
sudo apt update
sudo ACCEPT_EULA=Y apt install mssql-tools unixodbc-dev
```
*Optional:* Add `/opt/mssql-tools/bin` to your **PATH** environment variable in bash

To make sqlcmd/bcp accessible from the bash shell for login sessions, modify your PATH in the ~/.bash_profile file with the following command:
```bash
echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bash_profile
```

To make sqlcmd/bcp accessible from the bash shell for interactive/non-login sessions, modify the PATH in the ~/.bashrc file with the following command:

```bash
echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc
source ~/.bashrc
```

#### SQL Connections
1. Connect `qlcmd -S localhost -U SA -P '<YourPassword>'`
2. Create + View Tables

```SQL
CREATE DATABASE TestDB
SELECT Name from sys.Databases
GO
```

3. Insert Data

```SQL
USE TestDB
CREATE TABLE Inventory (id INT, name NVARCHAR(50), quantity INT)
INSERT INTO Inventory VALUES (1, 'banana', 150); INSERT INTO Inventory VALUES (2, 'orange', 154);
GO
```

4. Select Data
`
```SQL
SELECT * FROM Inventory WHERE quantity > 152;
GO
```

5. Exit

```SQL
QUIT
```

#### [Interfacing with SQL - Transact](https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-run-sql-server-agent-job?view=sql-server-ver15)
In addition to sqlcmd, you can use the following cross-platform tools to manage SQL Server:
| Tool 	Description
| Azure Data Studio 	A cross-platform GUI database management utility.
| Visual Studio Code 	A cross-platform GUI code editor that run Transact-SQL statements with the mssql extension.
| PowerShell Core 	A cross-platform automation and configuration tool based on cmdlets.
| mssql-cli 	A cross-platform command-line interface for running Transact-SQL commands.


