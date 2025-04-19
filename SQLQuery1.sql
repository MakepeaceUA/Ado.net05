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

INSERT INTO Continent (Name) VALUES ('������'), ('����');

INSERT INTO Country (Name, Area, Population, ContinentId)
VALUES 
('�������', 603700, 41000000, 1),
('�������', 551695, 67000000, 1),
('�����', 9597000, 1440000000, 2);

INSERT INTO Capital (Name, Population, CountryId)
VALUES 
('����', 2884000, 1),
('�����', 2161000, 2),
('�����', 21540000, 3);

INSERT INTO City (Name, Population, CountryId)
VALUES 
('�������', 1440000, 1),
('����', 522000, 2),
('������', 26300000, 3),
('��������', 18700000, 3);