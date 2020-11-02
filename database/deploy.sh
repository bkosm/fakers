#!/usr/bin/bash

if [ -z "$(which psql)" ]; then
    echo psql not found, installing...
    
    # Add postgres repo to the package manager
    sudo sh -c 'echo "deb http://apt.postgresql.org/pub/repos/apt $(lsb_release -cs)-pgdg main" > /etc/apt/sources.list.d/pgdg.list'
    
    wget --quiet -O - https://www.postgresql.org/media/keys/ACCC4CF8.asc | sudo apt-key add -
    
    sudo apt-get update
    
    #Install pg and tools
    sudo apt-get -y install postgresql-13
    sudo pg_createcluster 13 main
    sudo pg_ctlcluster 13 main start
    
    if [ -z "$(which psql)" ]; then
        echo error while installing postgres, aborting
        exit 1
    fi
fi

echo postgresql present, configuring database

sudo -u postgres psql -f "./init.sql"
sudo -u postgres psql -d fakers_db -f "./tables.sql"
sudo -u postgres psql -d fakers_db -f "./triggers.sql"

exit 0