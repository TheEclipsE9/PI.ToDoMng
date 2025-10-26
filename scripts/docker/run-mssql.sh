#!/bin/bash

# Get the directory of the script
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
echo "Script is located in: $SCRIPT_DIR"

# Remove existing container if it exists
docker rm -f webapp-sqlserver 2>/dev/null || true

# Run SQL Server container
echo "Starting SQL Server..."
docker run -d \
    -p 1433:1433 \
    --name webapp-sqlserver \
    --hostname webapp-sqlserver \
    -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=MyStrong!Passw0rd123" \
    mcr.microsoft.com/mssql/server:2022-latest

echo "Waiting for SQL Server to start..."
sleep 15


# Connect to server
echo "Starting SQL Server Tools..."
docker run -i --rm \
  --network host \
  mcr.microsoft.com/mssql-tools:latest \
  /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "MyStrong!Passw0rd123" <<EOF

-- Create database
CREATE DATABASE ToDoMng;
GO

-- Verify it was created
SELECT name FROM sys.databases;
GO

-- Create login for WebApp
CREATE LOGIN WebApp WITH PASSWORD = 'MyStrong!Passw0rd123';
GO

-- Create user in the database
USE ToDoMng;
GO
CREATE USER WebAppUser FOR LOGIN WebApp;
GO

-- Add db_owner role to the user
ALTER ROLE db_owner ADD MEMBER WebAppUser;
GO