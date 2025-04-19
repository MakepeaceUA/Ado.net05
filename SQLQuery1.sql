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
('Украина', 600000, 40000000, 1),
('Франция', 550000, 65000000, 1),
('Китай', 9600000, 1400000000, 2);

INSERT INTO Capital (Name, Population, CountryId)
VALUES 
('Киев', 3000000, 1),
('Париж', 2200000, 2),
('Пекин', 20000000, 3);

INSERT INTO City (Name, Population, CountryId)
VALUES 
('Харьков', 1500000, 1),
('Лион', 520000, 2),
('Шанхай', 26000000, 3),
('Гуанчжоу', 18000000, 3);
