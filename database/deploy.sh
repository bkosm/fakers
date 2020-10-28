#!/usr/bin/bash

if [ -z "$(which psql)" ]; then
    echo psql not found, installing...	

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