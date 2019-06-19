use BeautySalo

CREATE TABLE Salon
(
	ID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	MiddleName NVARCHAR(100) NULL,
	DirectionID INT NOT NULL,
	ExhibitionNumber INT NOT NULL,
	FOREIGN KEY (DirectionID) REFERENCES Category(ID)
)



CREATE TABLE Category
(
	ID INT PRIMARY KEY IDENTITY,
	CategName NVARCHAR(100) NOT NULL,
	CategDescription NVARCHAR(255) NOT NULL
)

INSERT INTO Category (CategName, CategDescription)
VALUES
('Manicure', 'For nails on hands'),
('Pedicure', 'For nails on legs'),
('Haircut', 'For hair on head')

INSERT INTO Salon (FirstName, LastName, MiddleName, DirectionID, ExhibitionNumber)
VALUES
('Oleksandr', 'Hryshchuk', NULL, 2, 5),
('Andrii', 'Kozirskiy', NULL, 1, 2),
('Petro', 'Krivorotko', NULL, 3, 6)