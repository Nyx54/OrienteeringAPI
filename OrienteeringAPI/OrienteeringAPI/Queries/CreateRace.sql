CREATE TABLE OrienteeringRace
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	RaceFormat INT,
	TeamOrganizer BIGINT,
	Tracer BIGINT,
	Latitude FLOAT,
	Longitude FLOAT,
	City NVARCHAR(MAX),
	CompetitionDate Date,
	CompetitionStart Time,
	PRIMARY KEY(Id)
)
