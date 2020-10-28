#!/usr/bin/bash

if [ -z "$(which psql)" ]; then
    echo psql not found, installing...	

	sudo apt-get -y install postgresql-13
	sudo pg_createcluster 13 main
	sudo pg_ctlcluster 13 main start



    if [ ! -z "$(which psql)" ]; then
        echo instalation successful, configuring database
    fi
fi

sudo -u postgres psql -f "./database/init.sql"
sudo -u postgres psql -d fakers_db -f "./database/tables.sql"
sudo -u postgres psql -d fakers_db -f "./database/triggers.sql"