CREATE TABLE OrienteeringRun
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	RaceId BIGINT NOT NULL,
	RunnerId BIGINT NOT NULL,
	StartTime TIME,
	Result TIME,
	Status NVARCHAR(256),
	Splits NVARCHAR(MAX)
	PRIMARY KEY(Id)
)
GO
CREATE INDEX RunRace ON OrienteeringRun (RaceId)
CREATE INDEX RunRunner ON OrienteeringRun (RunnerId)
CREATE UNIQUE INDEX RunRaceRunner ON OrienteeringRun (RaceId, RunnerId)
GO
