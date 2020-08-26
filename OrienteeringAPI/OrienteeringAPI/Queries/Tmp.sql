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


