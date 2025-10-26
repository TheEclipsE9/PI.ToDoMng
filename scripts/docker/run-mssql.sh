#!/bin/bash

# Get the directory of the script
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
echo "Script is located in: $SCRIPT_DIR"

# Remove existing container if it exists
docker rm -f sql1 2>/dev/null || true

# Run SQL Server container
docker run -d \
    -p 1433:1433 \
    --name sql1 \
    --hostname sql1 \
    -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=MyStrong!Passw0rd123" \
    mcr.microsoft.com/mssql/server:2022-latest