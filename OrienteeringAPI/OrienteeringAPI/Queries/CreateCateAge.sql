CREATE TABLE OrienteeringAgeCategory
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	Name NVARCHAR(256) NOT NULL,
	ShortName NVARCHAR(12) NOT NULL,
	Sex BIT NOT NULL,
	AgeMin INT NOT NULL,
	AgeMax INT NOT NULL,
	PRIMARY KEY(Id)
)
GO
CREATE UNIQUE INDEX AgeName ON OrienteeringAgeCategory (Name)
CREATE UNIQUE INDEX AgeShortName ON OrienteeringAgeCategory (ShortName)
CREATE UNIQUE INDEX AgeSex ON OrienteeringAgeCategory (Sex)
GO