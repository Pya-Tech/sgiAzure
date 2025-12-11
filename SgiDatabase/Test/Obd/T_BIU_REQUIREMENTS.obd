CREATE OR REPLACE TRIGGER T_BIU_REQUIREMENTS
BEFORE INSERT ON REQUERIMIENTOS
FOR EACH ROW
BEGIN
    IF :new.numero_requerimiento IS NULL THEN
      SELECT seq_requerimientos.NEXTVAL
      INTO   :NEW.numero_requerimiento
      FROM   dual;      
    END IF;
END;
