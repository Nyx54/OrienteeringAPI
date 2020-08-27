﻿CREATE TABLE OrienteeringLeague
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	Name NVARCHAR(256) NOT NULL,
	ShortName NVARCHAR(12) NOT NULL,
	PRIMARY KEY(Id)
)
GO
CREATE UNIQUE INDEX LeagueName ON OrienteeringLeague (Name)
CREATE UNIQUE INDEX LeagueShortName ON OrienteeringLeague (ShortName)
GO