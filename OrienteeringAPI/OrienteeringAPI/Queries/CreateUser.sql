CREATE TABLE OrienteeringUser
(
	Id BIGINT NOT NULL,
	Login NVARCHAR(256),
	Password NVARCHAR(MAX),
	Profil NVARCHAR(1),
	PRIMARY KEY(Id)
)
GO
CREATE UNIQUE INDEX UserLogin ON OrienteeringUser (Login)
GO