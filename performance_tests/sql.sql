-- select 1
SELECT id, first_name, pesel 
FROM person
WHERE id = 4;

-- select 2
SELECT p.id, p.first_name, p.pesel, c.email, c.phone_number, a.street, a.location
FROM person p
JOIN person_address pa ON p.id = pa.person_id
JOIN address a ON a.id = pa.address_id
JOIN person_contact pc ON p.id = pc.person_id
JOIN contact c ON c.id = pc.contact_id
WHERE p.id = 4;

-- insert
INSERT INTO person (birth_date, first_name, last_name, pesel, sex) VALUES ('2010-01-01', 'New', 'Person', '12345678903', 'f');

-- update
UPDATE person SET first_name = 'NewName' WHERE id = 4;