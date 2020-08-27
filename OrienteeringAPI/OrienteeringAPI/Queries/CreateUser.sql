CREATE TABLE OrienteeringUser
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	Login NVARCHAR(MAX),
	FirstName NVARCHAR(MAX) NOT NULL,
	LastName NVARCHAR(MAX) NOT NULL,
	Password NVARCHAR(MAX),
	Profil NVARCHAR(1),
	TeamId BIGINT,
	Sex BIT NOT NULL,
	BirthDate DATE,
	CategoryId BIGINT,
	FavoriteColor BIGINT,
	PRIMARY KEY(Id)
)
GO
CREATE INDEX UserTeam ON OrienteeringUser (TeamId)
GO