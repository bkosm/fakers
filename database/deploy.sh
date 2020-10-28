#!/usr/bin/bash

if [ -z "$(which psql)" ]; then
    echo psql not found, installing...

    sudo apt-get -y install postgresql-12 postgresql-client-12

    if [ ! -z "$(which psql)" ]; then
        echo instalation successful, configuring database
    fi
fi

