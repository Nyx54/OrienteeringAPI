USE [Orienteering]
GO

INSERT INTO [dbo].[OrienteeringUser]
           ([Login]
           ,[FirstName]
           ,[LastName]
           ,[Password]
           ,[Profil])
     VALUES
           ('lchapelo'
           ,'Lucas'
           ,'Chapelot'
           ,'mdp'
           ,'A')
GO

SELECT * FROM LogAPI

