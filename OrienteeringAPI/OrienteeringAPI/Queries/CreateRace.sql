CREATE TABLE OrienteeringRace
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	Name NVARCHAR(Max) NOT NULL,
	FormatId BIGINT NOT NULL,
	CN BIT NOT NULL,
	Latitude FLOAT,
	Longitude FLOAT,
	City NVARCHAR(256),
	CodePostal INT,
	TeamOrganizer BIGINT NOT NULL,
	Tracer BIGINT NOT NULL,
	CompetitionDate DATE,
	CompetitionStart TIME,
	PRIMARY KEY(Id)
)
GO
CREATE INDEX RaceDate ON OrienteeringRace (CompetitionDate)
CREATE INDEX RaceFormat ON OrienteeringRace (FormatId)
CREATE INDEX RaceCN ON OrienteeringRace (CN)
GO