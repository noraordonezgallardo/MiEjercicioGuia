DROP DATABASE IF EXISTS DDBBPinturilloSO;
CREATE DATABASE DDBBPinturilloSO;
USE DDBBPinturilloSO;

CREATE TABLE Jugadores (
    ID INTEGER PRIMARY KEY NOT NULL,
    Usuario VARCHAR(80) NOT NULL,
    Correo VARCHAR(80) NOT NULL,
    Contrasena VARCHAR(80) NOT NULL
);

CREATE TABLE Dibujos (
    ID INTEGER PRIMARY KEY NOT NULL,
    Dibujo VARCHAR(80) NOT NULL,
    Dificultad INTEGER NOT NULL,
    Categoria VARCHAR(80) NOT NULL
);

CREATE TABLE Partidas (
    ID INTEGER PRIMARY KEY NOT NULL,
    Duracion INTEGER NOT NULL,
    PrimeroID INTEGER NOT NULL,
    SegundoID INTEGER NOT NULL,
    TerceroID INTEGER,
    CuartoID INTEGER,
    FOREIGN KEY (PrimeroID) REFERENCES Jugadores(ID),
    FOREIGN KEY (SegundoID) REFERENCES Jugadores(ID),
    FOREIGN KEY (TerceroID) REFERENCES Jugadores(ID),
    FOREIGN KEY (CuartoID) REFERENCES Jugadores(ID)
);

CREATE TABLE Ranking (
    JugadorID INTEGER NOT NULL,
    Victorias INTEGER NOT NULL,
    FOREIGN KEY (JugadorID) REFERENCES Jugadores(ID)
);

CREATE TABLE Amigos (
    JugadorID INTEGER NOT NULL,
    AmigoID INTEGER NOT NULL,
    FOREIGN KEY (JugadorID) REFERENCES Jugadores(ID),
    FOREIGN KEY (AmigoID) REFERENCES Jugadores(ID),
    CHECK (JugadorID <> AmigoID)
);

INSERT INTO Jugadores (ID, Usuario, Correo, Contrasena) 
VALUES  (1, 'polfernandez', 'pol.fernandez@gmail.com', 'pol123'),
        (2, 'hanabentaeb', 'hana.bentaeb@gmail.com', 'hana123'),
        (3, 'noraordonez', 'nora.ordonez@gmail.com', 'nora123');

INSERT INTO Dibujos (ID, Dibujo, Dificultad, Categoria) 
VALUES  (1, 'Perro', 1, 'Animales'),
        (2, 'Cigarrillo', 3, 'Objetos'),
        (3, 'Paella', 5, 'Culturas');

INSERT INTO Partidas (ID, Duracion, PrimeroID, SegundoID, TerceroID, CuartoID)
VALUES  (1, 120, 1, 2, 3, NULL),
        (2, 180, 2, 3, 1, NULL),
        (3, 240, 3, 1, 2, NULL);

INSERT INTO Ranking (JugadorID, Victorias)
VALUES  (1, 3),
        (2, 5),
        (3, 2);

INSERT INTO Amigos (JugadorID, AmigoID)
VALUES  (1, 2),
        (1, 3),
        (2, 3);