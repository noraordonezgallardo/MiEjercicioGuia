DROP DATABASE IF EXISTS Play;
CREATE DATABASE Play;
USE Play;

CREATE TABLE Player (
    Id INTEGER PRIMARY KEY NOT NULL,
    Username TEXT NOT NULL,
    Name TEXT NOT NULL,
    Address TEXT NOT NULL,
    Password TEXT NOT NULL
) ENGINE = InnoDB;

CREATE TABLE Game (
    Id INTEGER PRIMARY KEY NOT NULL,
    Points INTEGER NOT NULL,
    Duration INTEGER NOT NULL,
    Finish_time INTEGER NOT NULL
) ENGINE = InnoDB;

CREATE TABLE Ranking (
    Player_id INTEGER NOT NULL,
    Game_id INTEGER NOT NULL,  
    FOREIGN KEY (Player_id) REFERENCES Player(Id),
    FOREIGN KEY (Game_id) REFERENCES Game(Id) 
) ENGINE = InnoDB;

CREATE TABLE Dibujos(
    Id INTEGER PRIMARY KEY NOT NULL,
    Difficulty INTEGER NOT NULL,
    Category TEXT NOT NULL
)

INSERT INTO Player VALUES (1,'polfernandez','Pol','pol.fernandez@gmail.com','contraseña');
INSERT INTO Player VALUES (2,'hanabentaeb','Hana','hana.bentaeb@gmail.com','contraseña');
INSERT INTO Player VALUES (3,'noraordonez','Nora','nora.ordonez@gmail.com','contraseña');

INSERT INTO Game VALUES (1,12,324,100);
INSERT INTO Game VALUES (2,24,600,120);


INSERT INTO Ranking VALUES (1, 1);
INSERT INTO Ranking VALUES (2, 2);
INSERT INTO Ranking VALUES (3, 1);
