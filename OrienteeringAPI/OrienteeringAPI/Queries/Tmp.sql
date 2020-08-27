USE [Orienteering]
GO
-- DELETE 

DELETE FROM [dbo].[OrienteeringLeague]
DELETE FROM [dbo].[OrienteeringTeam]
DELETE FROM [dbo].[OrienteeringColorCategory]
DELETE FROM [dbo].[OrienteeringAgeCategory]
DELETE FROM [dbo].[OrienteeringUser]
DELETE FROM [dbo].[OrienteeringRaceFormat]
DELETE FROM [dbo].[OrienteeringRace]

-- League 
INSERT INTO [dbo].[OrienteeringLeague]
           ([Name]
           ,[ShortName])
     VALUES
           ('League Grand-Est'
		   ,'LGECO')
GO

-- Team
DECLARE @LeagueId BIGINT = (SELECT Id FROM [dbo].[OrienteeringLeague] WHERE ShortName = 'LGECO')

INSERT INTO [dbo].[OrienteeringTeam]
           ([Name]
           ,[ShortName]
           ,[Code]
           ,[LeagueId])
     VALUES
           ('SCAPA Nancy CO'
           ,'SCAPA'
           ,5402
           ,@LeagueId)
INSERT INTO [dbo].[OrienteeringTeam]
           ([Name]
           ,[ShortName]
           ,[Code]
           ,[LeagueId])
     VALUES
           ('SO Lunéville'
           ,'SOL'
           ,5407
           ,@LeagueId)
GO

-- ColorCate
INSERT INTO [dbo].[OrienteeringColorCategory]
           ([Name]
           ,[ShortName])
     VALUES
           ('Violet Court'
		   ,'VC')
INSERT INTO [dbo].[OrienteeringColorCategory]
           ([Name]
           ,[ShortName])
     VALUES
           ('Noir'
		   ,'N')
GO

-- AgeCate
INSERT INTO [dbo].[OrienteeringAgeCategory]
           ([Name]
           ,[ShortName]
		   ,[Sex]
		   ,[AgeMin]
		   ,[AgeMax])
     VALUES
           ('Homme 21'
		   ,'H21'
		   ,CAST(1 AS BIT)
		   ,21
		   ,34)
INSERT INTO [dbo].[OrienteeringAgeCategory]
           ([Name]
           ,[ShortName]
		   ,[Sex]
		   ,[AgeMin]
		   ,[AgeMax])
     VALUES
           ('Damme 21'
		   ,'D21'
		   ,CAST(0 AS BIT)
		   ,21
		   ,34)
GO

-- User
DECLARE @TeamSOL BIGINT = (SELECT Id FROM [dbo].[OrienteeringTeam] WHERE ShortName = 'SOL')
DECLARE @TeamSCAPA BIGINT = (SELECT Id FROM [dbo].[OrienteeringTeam] WHERE ShortName = 'SCAPA')
DECLARE @VioletCourt BIGINT = (SELECT Id FROM [dbo].[OrienteeringColorCategory] WHERE ShortName = 'VC')
DECLARE @H21 BIGINT = (SELECT Id FROM [dbo].[OrienteeringAgeCategory] WHERE ShortName = 'H21')
DECLARE @Noir BIGINT = (SELECT Id FROM [dbo].[OrienteeringColorCategory] WHERE ShortName = 'N')
DECLARE @D21 BIGINT = (SELECT Id FROM [dbo].[OrienteeringAgeCategory] WHERE ShortName = 'D21')

INSERT INTO [dbo].[OrienteeringUser]
           ([Login]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[Profil]
           ,[TeamId]
           ,[Sex]
           ,[BirthDate]
           ,[CategoryId]
		   ,[FavoriteColor])
     VALUES
           ('lchapelo'
           ,'Lucas'
           ,'Chapelot'
           ,'mdp'
           ,'A'
           , @TeamSOL
		   ,CAST(1 AS BIT)
		   ,'23-09-1994'
		   ,@H21
		   ,@VioletCourt)
INSERT INTO [dbo].[OrienteeringUser]
           ([Login]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[Profil]
           ,[TeamId]
           ,[Sex]
           ,[BirthDate]
           ,[CategoryId]
		   ,[FavoriteColor])
     VALUES
           ('test'
           ,'Madame'
           ,'Testeuse'
           ,NULL
           ,NULL
           , @TeamSOL
		   ,CAST(0 AS BIT)
		   ,'30-01-1996'
		   ,@D21
		   ,NULL)
INSERT INTO [dbo].[OrienteeringUser]
           ([Login]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[Profil]
           ,[TeamId]
           ,[Sex]
           ,[BirthDate]
           ,[CategoryId]
		   ,[FavoriteColor])
     VALUES
           ('test2'
           ,'Mister'
           ,'Long'
           ,NULL
           ,Null
           , @TeamSCAPA
		   ,CAST(1 AS BIT)
		   ,Null
		   ,Null
		   ,@Noir)
GO

-- RaceFormat
INSERT INTO [dbo].[OrienteeringRaceFormat]
           ([Name]
           ,[ShortName])
     VALUES
           ('Moyenne Distance'
		   ,'MD')
GO
INSERT INTO [dbo].[OrienteeringRaceFormat]
           ([Name]
           ,[ShortName])
     VALUES
           ('Longue Distance'
		   ,'LD')
GO


DECLARE @LD BIGINT = (SELECT Id FROM [dbo].[OrienteeringRaceFormat] WHERE ShortName = 'LD')
DECLARE @Tarcer BIGINT = (SELECT Id FROM [dbo].[OrienteeringUser] WHERE Login = 'test')
DECLARE @TeamSOL BIGINT = (SELECT Id FROM [dbo].[OrienteeringTeam] WHERE ShortName = 'SOL')
-- Race
INSERT INTO [dbo].[OrienteeringRace]
           ([Name]
		   ,[FormatId]
		   ,[CN]
           ,[Latitude]
           ,[Longitude]
           ,[City]
           ,[CodePostal]
           ,[TeamOrganizer]
           ,[Tracer]
           ,[CompetitionDate]
           ,[CompetitionStart])
     VALUES
           ('Course régionale n°1'
		   ,@LD
		   ,CAST(1 AS BIT)
           ,48.572796
           ,6.553795
           ,'Moncel-les-Lunéville'
           ,54300
           ,@TeamSOL
           ,@Tarcer
           ,'12-06-2021'
           ,'10:00:00.0000')
GO
