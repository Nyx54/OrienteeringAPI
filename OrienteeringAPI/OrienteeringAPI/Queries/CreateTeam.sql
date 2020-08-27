CREATE TABLE OrienteeringTeam
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	Name NVARCHAR(256) NOT NULL,
	ShortName NVARCHAR(12) NOT NULL,
	Code INT NOT NULL,
	LeagueId BIGINT NOT NULL,
	PRIMARY KEY(Id)
)
GO
CREATE UNIQUE INDEX TeamName ON OrienteeringTeam (Name)
CREATE UNIQUE INDEX TeamShortName ON OrienteeringTeam (ShortName)
CREATE UNIQUE INDEX TeamLeague ON OrienteeringTeam (LeagueId)
GO