CREATE TABLE IF NOT EXISTS address (
    id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,

    street VARCHAR NOT NULL,
    city VARCHAR NOT NULL,
    voivodeship VARCHAR NOT NULL,

    location VARCHAR NOT NULL -- link or coords
);

CREATE TABLE IF NOT EXISTS contact (
    id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,

    email VARCHAR(320) NOT NULL,
    phone_number VARCHAR(13),

    UNIQUE(email, phone_number)
);

CREATE TABLE IF NOT EXISTS person (
    id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,

    pesel CHAR(11) NOT NULL UNIQUE,
    
    first_name VARCHAR NOT NULL,
    second_name VARCHAR,
    last_name VARCHAR NOT NULL,

    birth_date DATE NOT NULL
);

CREATE INDEX IF NOT EXISTS p_bd ON person(birth_date);
CREATE INDEX IF NOT EXISTS p_p ON person(pesel);
CREATE INDEX IF NOT EXISTS p_ln ON person(last_name);

CREATE TABLE IF NOT EXISTS deceased_person (
    person_id BIGINT PRIMARY KEY REFERENCES person(id),

    date_of_death DATE NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS dp_dod ON deceased_person(date_of_death);

CREATE TABLE IF NOT EXISTS person_address (
    person_id BIGINT REFERENCES person(id),
    address_id BIGINT REFERENCES address(id),

    PRIMARY KEY (person_id, address_id),

    assigned DATE NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS pa_a ON person_address(assigned);

CREATE TABLE IF NOT EXISTS person_contact (
    person_id BIGINT REFERENCES person(id),
    contact_id BIGINT REFERENCES contact(id) UNIQUE,

    PRIMARY KEY (person_id, contact_id),

    assigned DATE NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS pc_a ON person_contact(assigned);
