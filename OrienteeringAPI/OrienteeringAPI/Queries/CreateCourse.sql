CREATE TABLE OrienteeringCourse
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	RaceId BIGINT NOT NULL,
	CategoryAge BIGINT,
	CategoryColor BIGINT,
	Free BIT NOT NULL,
	PRIMARY KEY(Id)
)
GO
CREATE INDEX CourseRace ON OrienteeringCourse (RaceId)
CREATE UNIQUE INDEX CourseRaceCategory ON OrienteeringCourse (RaceId, CategoryAge, CategoryColor)
GO