CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PositionName VARCHAR(60),
    IsActive BIT
);

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RoleId INT NOT NULL,
    Handle VARCHAR(50) NOT NULL,
    SecretHash VARCHAR(MAX),
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);

CREATE TABLE Designers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(150) NOT NULL
);

CREATE TABLE Garments (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    DesignerId INT NOT NULL,
    ProductName VARCHAR(200) NOT NULL,
    MarketPrice DECIMAL(18,2),
    Quantity INT,
    FOREIGN KEY (DesignerId) REFERENCES Designers(Id)
);