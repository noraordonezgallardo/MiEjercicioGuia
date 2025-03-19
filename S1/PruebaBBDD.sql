DROP DATABASE IF EXISTS prueba;
CREATE DATABASE prueba;

USE prueba;

CREATE TABLE persona (
    nombre VARCHAR(60),
    edad INT
)ENGINE=InnoDB;

INSERT INTO persona VALUES ('Juan', 34);
INSERT INTO persona VALUES ('Maria', 14);
INSERT INTO persona VALUES ('Luis', 23);
INSERT INTO persona VALUES ('Pedro', 11);

