USE [Orienteering]
GO

INSERT INTO [dbo].[OrienteeringUser]
           ([Login]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[Profil]
           ,[TeamId])
     VALUES
           ('lchapelo'
           ,'Lucas'
           ,'Chapelot'
           ,'mdp'
           ,'A'
           , 1)
GO

INSERT INTO [dbo].[OrienteeringTeam]
           ([Name]
           ,[ShortName]
           ,[Code]
           ,[LeagueId])
     VALUES
           ('SO Lunéville'
           ,'SOL'
           ,5407
           ,1)
GO

INSERT INTO [dbo].[OrienteeringLeague]
           ([Name]
           ,[ShortName])
     VALUES
           ('League Grand-Est'
		   ,'LGECO')
GO

INSERT INTO [dbo].[OrienteeringRace]
           ([RaceFormat]
           ,[TeamOrganizer]
           ,[Tracer]
           ,[Latitude]
           ,[Longitude]
           ,[City]
           ,[CompetitionDate]
           ,[CompetitionStart])
     VALUES
           (1
           ,1
           ,1
           ,48.572796
           ,6.553795
           ,'Moncel-les-Lunéville'
           ,GETDATE()
           ,'10:00:00.0000')
GO
