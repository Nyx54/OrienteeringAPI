CREATE TABLE OrienteeringRunner
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	FirstName NVARCHAR(MAX) NOT NULL,
	LastName NVARCHAR(MAX) NOT NULL,
	TeamId BIGINT,
	Sex BIT NOT NULL,
	BirthDate DATE,
	CategoryId BIGINT,
	FavoriteColor BIGINT,
	PRIMARY KEY(Id)
)
GO
CREATE INDEX RunnerTeam ON OrienteeringRunner (TeamId)
GO