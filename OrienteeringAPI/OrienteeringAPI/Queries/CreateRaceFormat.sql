CREATE TABLE OrienteeringRaceFormat
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	Name NVARCHAR(256) NOT NULL,
	ShortName NVARCHAR(12) NOT NULL,
	PRIMARY KEY(Id)
)
GO
CREATE INDEX RaceFormatName ON OrienteeringRaceFormat (Name)
CREATE INDEX RaceFormatShortName ON OrienteeringRaceFormat (ShortName)
CREATE UNIQUE INDEX RaceFormatNameShortName ON OrienteeringRaceFormat (Name, ShortName)
GO
