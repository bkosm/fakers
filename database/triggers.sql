DROP TRIGGER IF EXISTS after_insert_update ON person_address CASCADE;
DROP TRIGGER IF EXISTS after_insert_update ON person_contact CASCADE;
DROP TRIGGER IF EXISTS after_insert ON deceased_person CASCADE;
DROP TRIGGER IF EXISTS after_delete ON person_address CASCADE;
DROP TRIGGER IF EXISTS after_delete ON person_contact CASCADE;

--

CREATE OR REPLACE FUNCTION after_insert_update_person_address() RETURNS TRIGGER AS $$ -- zapewnij jeden glowny adres osoby po dodaniu
BEGIN
    IF NOT NEW.is_primary THEN
		IF TRUE NOT IN (SELECT is_primary FROM person_address pa 
						WHERE pa.person_id = NEW.person_id) THEN
			
			UPDATE person_address
			SET is_primary = TRUE
			WHERE person_id = NEW.person_id AND address_id = NEW.address_id;
		END IF;
	ELSE
		UPDATE person_address
		SET is_primary = FALSE
		WHERE person_id = NEW.person_id AND address_id != NEW.address_id;
	END IF;
	
	RETURN NULL;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER after_insert_update
AFTER INSERT OR UPDATE ON person_address
FOR EACH ROW
WHEN (pg_trigger_depth() < 1)
EXECUTE PROCEDURE after_insert_update_person_address();

--

CREATE OR REPLACE FUNCTION after_delete_person_address() RETURNS TRIGGER AS $$ -- zapewnij jeden glowny adres osoby po usunieciu (najnowszy z pozostalych)
BEGIN
    UPDATE person_address
	SET is_primary = TRUE
	WHERE person_id = OLD.person_id AND address_id = (SELECT address_id FROM person_address WHERE person_id = OLD.person_id ORDER BY assigned DESC FETCH FIRST 1 ROWS ONLY);
	
	RETURN NULL;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER after_delete
AFTER DELETE ON person_address
FOR EACH ROW
WHEN (pg_trigger_depth() < 1)
EXECUTE PROCEDURE after_delete_person_address();

--

CREATE OR REPLACE FUNCTION after_insert_update_person_contact() RETURNS TRIGGER AS $$ -- zapewnij jeden glowny kontakt osoby po dodaniu
BEGIN
    IF NOT NEW.is_primary THEN
		IF TRUE NOT IN (SELECT is_primary FROM person_contact pc 
						WHERE pc.person_id = NEW.person_id) THEN
			UPDATE person_contact
			SET is_primary = TRUE
			WHERE person_id = NEW.person_id AND contact_id = NEW.contact_id;
		END IF;
	ELSE
		UPDATE person_contact
		SET is_primary = FALSE
		WHERE person_id = NEW.person_id AND contact_id != NEW.contact_id;
	END IF;
	
	RETURN NULL;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER after_insert_update
AFTER INSERT OR UPDATE ON person_contact
FOR EACH ROW
WHEN (pg_trigger_depth() < 1)
EXECUTE PROCEDURE after_insert_update_person_contact();

--

CREATE OR REPLACE FUNCTION after_delete_person_contact() RETURNS TRIGGER AS $$ -- zapewnij jeden glowny kontakt osoby po usunieciu (najnowszy z pozostalych)
BEGIN
    UPDATE person_contact
	SET is_primary = TRUE
	WHERE person_id = OLD.person_id AND contact_id = (SELECT contact_id FROM person_contact WHERE person_id = OLD.person_id ORDER BY assigned DESC FETCH FIRST 1 ROWS ONLY);
	
	RETURN NULL;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER after_delete
AFTER DELETE ON person_contact
FOR EACH ROW
WHEN (pg_trigger_depth() < 1)
EXECUTE PROCEDURE after_delete_person_contact();

--

CREATE OR REPLACE FUNCTION after_insert_deceased_person() RETURNS TRIGGER AS $$
BEGIN
    DELETE FROM person_address
	WHERE person_id = NEW.person_id;
	
	RETURN NULL;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER after_insert
AFTER INSERT ON deceased_person
FOR EACH ROW
EXECUTE PROCEDURE after_insert_deceased_person();