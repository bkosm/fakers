DROP TRIGGER IF EXISTS before_insert_update ON person_address CASCADE;
DROP TRIGGER IF EXISTS before_insert_update ON person_contact CASCADE;
DROP TRIGGER IF EXISTS before_insert ON deceased_person CASCADE;

--

CREATE OR REPLACE FUNCTION before_insert_update_person_address() RETURNS TRIGGER AS $$
BEGIN
    IF NOT NEW.is_primary THEN
		IF TRUE NOT IN (SELECT is_primary FROM person_address pa 
						WHERE pa.person_id = NEW.person_id) THEN
			NEW.is_primary := TRUE;
		END IF;
	ELSE
		UPDATE person_address
		SET is_primary = FALSE
		WHERE person_id = NEW.person_id;
	END IF;
	
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER before_insert_update
BEFORE INSERT OR UPDATE ON person_address
FOR EACH ROW
WHEN (pg_trigger_depth() < 1)
EXECUTE PROCEDURE before_insert_update_person_address();

--

CREATE OR REPLACE FUNCTION before_insert_update_person_contact() RETURNS TRIGGER AS $$
BEGIN
    IF NOT NEW.is_primary THEN
		IF TRUE NOT IN (SELECT is_primary FROM person_contact pc 
						WHERE pc.person_id = NEW.person_id) THEN
			NEW.is_primary := TRUE;
		END IF;
	ELSE
		UPDATE person_contact
		SET is_primary = FALSE
		WHERE person_id = NEW.person_id;
	END IF;
	
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER before_insert_update
BEFORE INSERT OR UPDATE ON person_contact
FOR EACH ROW
WHEN (pg_trigger_depth() < 1)
EXECUTE PROCEDURE before_insert_update_person_contact();

--

CREATE OR REPLACE FUNCTION before_insert_deceased_person() RETURNS TRIGGER AS $$
BEGIN
    DELETE FROM person_address
	WHERE person_id = NEW.person_id;
	
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER before_insert
BEFORE INSERT ON deceased_person
FOR EACH ROW
EXECUTE PROCEDURE before_insert_deceased_person();