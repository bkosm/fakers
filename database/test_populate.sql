INSERT INTO
    address (
        street,
        city,
        voivodeship,
        location
    )
VALUES
    (
        'some street1',
        'some city1',
        'something1',
        'location1'
    ),
    (
        'some street2',
        'some city1',
        'something3',
        'location2'
    ),
    (
        'some street1',
        'some city1',
        'something3',
        'location3'
    ),
    (
        'some street2',
        'some city2',
        'something3',
        'location4'
    );

INSERT INTO
    contact (email, phone_number)
VALUES
    ('an email', '0101010101'),
    ('an email2', '0101001012'),
    ('an email3', '0101001013'),
    ('an email4', '0101001014'),
    ('an email5', '0101001015');

INSERT INTO
    person (
        pesel,
        first_name,
        second_name,
        last_name,
        sex,
        birth_date
    )
VALUES
    (
        '11111111111',
        'first',
        'second',
        'last',
        'm',
        '2000-12-12'
    ),
    (
        '11111111112',
        'first first',
        NULL,
        'last last',
        'f',
        '1999-12-12'
    ),
    (
        '11111111113',
        'first first',
        NULL,
        'last last last',
        'm',
        '1972-12-11'
    );

INSERT INTO
    deceased_person (person_id)
SELECT
    id
FROM
    person
WHERE
    pesel = '11111111113';

INSERT INTO
    person_address (person_id, address_id)
SELECT
    p.id,
    a.id
FROM
    person p,
    address a
WHERE
    random() > 0.5;

INSERT INTO
    person_contact (person_id, contact_id)
SELECT
    p.id,
    c.id
FROM
    person p,
    contact c
WHERE
    random() > 0.5;