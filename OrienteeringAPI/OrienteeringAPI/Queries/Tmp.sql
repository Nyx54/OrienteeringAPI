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

SELECT * FROM LogAPI

