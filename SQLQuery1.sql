CREATE TABLE Continent (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Country (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Area FLOAT,
    Population INT,
    ContinentId INT FOREIGN KEY REFERENCES Continent(Id)
);

CREATE TABLE Capital (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Population INT,
    CountryId INT UNIQUE FOREIGN KEY REFERENCES Country(Id)
);

CREATE TABLE City (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Population INT,
    CountryId INT FOREIGN KEY REFERENCES Country(Id)
);

INSERT INTO Continent (Name) VALUES ('Европа'), ('Азия');

INSERT INTO Country (Name, Area, Population, ContinentId)
VALUES 
('Украина', 603700, 41000000, 1),
('Франция', 551695, 67000000, 1),
('Китай', 9597000, 1440000000, 2);

INSERT INTO Capital (Name, Population, CountryId)
VALUES 
('Киев', 2884000, 1),
('Париж', 2161000, 2),
('Пекин', 21540000, 3);

INSERT INTO City (Name, Population, CountryId)
VALUES 
('Харьков', 1440000, 1),
('Лион', 522000, 2),
('Шанхай', 26300000, 3),
('Гуанчжоу', 18700000, 3);