CREATE TABLE OrienteeringColorCategory
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	Name NVARCHAR(256) NOT NULL,
	ShortName NVARCHAR(12) NOT NULL,
	PRIMARY KEY(Id)
)
GO
CREATE UNIQUE INDEX ColorName ON OrienteeringColorCategory (Name)
CREATE UNIQUE INDEX ColorShortName ON OrienteeringColorCategory (ShortName)
GO