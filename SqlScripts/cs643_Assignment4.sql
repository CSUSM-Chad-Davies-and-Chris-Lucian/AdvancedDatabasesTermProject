/*
Created by Chris Lucian and Chad Davies
9/16/2014
CS512 Advanced Databases
Assignment 4

This script tests each individual table to ensure we can insert, update, select, and delete
Unike assignment 2, this script also tests invalid values, foreign key constraint violations, and invalid range, and sized data
*/

USE [GameReviewWebsite_CS643]
GO
--***********************Valid Arguments***********************--
----------------Author---------------------
--Select From Author
SELECT [AuthorId]
      ,[Name]
      ,[Genre]
      ,[Biography]
  FROM [dbo].[Author]
GO

--Insert Into Author
INSERT INTO [dbo].[Author]
           ([Name]
           ,[Genre]
           ,[Biography])
     VALUES
           ('New Author'
           ,'Cool Games'
           ,'Cool Auhthor')
GO

--Update the Author
UPDATE [dbo].[Author]
   SET [Name] = 'New Author New Name'
      ,[Genre] = 'Odd Games'
      ,[Biography] = 'Cool Author Cool Games'
 WHERE [Name] = 'New Author'
GO

--Delete the Author
DELETE FROM [dbo].[Author]
      WHERE [Name] = 'New Author New Name'
GO

----------------EndAuthor---------------------

----------------Comment---------------------
--Select From Comment
SELECT [CommentId]
      ,[GameReviewId]
      ,[GamerId]
      ,[Title]
	  ,[Content]
  FROM [dbo].[Comment]
GO

--Insert Into Comment
INSERT INTO [dbo].[Comment]
           ([GameReviewId]
           ,[GamerId]
           ,[Title]
		   ,[Content])
     VALUES
           (1
           ,1
           ,'Cool Comment Title'
		   ,'Cool Comment')
GO

--Update the Comment
UPDATE [dbo].[Comment]
   SET [Title] = 'Cool Comment Title Cool Games'
 WHERE [Title] = 'Cool Comment Title'
GO

--Delete the Comment
DELETE FROM [dbo].[Comment]
      WHERE [Title] = 'Cool Comment Title Cool Games'
GO

----------------EndComment---------------------

----------------Game---------------------
--Select From Game
SELECT [GameId]
      ,[Title]
      ,[Description]
  FROM [dbo].[Game]
GO

--Insert Into Game
INSERT INTO [dbo].[Game]
           ([Title]
           ,[Description])
     VALUES
           ('Cool Game'
		   ,'Cool Game Description')
GO

--Update the Game
UPDATE [dbo].[Game]
   SET [Title] = 'Coolest Game On Earth'
      ,[Description] = 'Extreme Cool Description'
 WHERE [Title] = 'Cool Game'
GO



-- Works since its not being used in a game review
DELETE FROM [dbo].[Game]
	WHERE [Title] = 'Coolest Game On Earth'
GO

----------------EndGame---------------------

----------------Gamer---------------------
--Select From Gamer
SELECT [GamerId]
      ,[Name]
      ,[AvatarUrl]
	  ,[Biography]
  FROM [dbo].Gamer
GO

--Insert Into Gamer
INSERT INTO [dbo].Gamer
           ([Name]
           ,[AvatarUrl]
		   ,[Biography])
     VALUES
           ('Cool Name'
		   ,'Cool.com/avatarurl.jpg'
		   ,'Cool Biography')
GO

--Update the Gamer
UPDATE [dbo].Gamer
   SET [Name] = 'Cool Name Cooler Name'
      ,[AvatarUrl] = 'CoolCool.com/avatarurl.jpg'
	  ,[Biography] = 'Cool Biography Cooler Biography'
 WHERE [Name] = 'Cool Name'
GO

--Delete the Gamer
DELETE FROM [dbo].Gamer
      WHERE [Name] = 'Cool Name Cooler Name'
GO

----------------EndGamer---------------------

----------------GameReview---------------------
--Select From GameReview
SELECT [GameReviewId]
      ,[GameId]
      ,[AuthorId]
	  ,[Title]
	  ,[Content]
	  ,[Rating]
  FROM [dbo].[GameReview]
GO

--Insert Into GameReview
INSERT INTO [dbo].[GameReview]
           ([GameId]
           ,[AuthorId]
		   ,[Title]
		   ,[Content]
		   ,[Rating])
     VALUES
           (1
		   ,1
		   ,'Amazing Game'
		   ,'Amazing Content'
		   ,1.0)
GO

--Update the GameReview
UPDATE [dbo].[GameReview]
   SET [GameId] = 2
      ,[AuthorId] = 2
	  ,[Title] = 'Amazing Cool Game'
	  ,[Content] = 'Amazing Cool Content'
	  ,[Rating] = 2.0
 WHERE [Title] = 'Amazing Game'
GO

-- Works since its not being used in a Comment
DELETE FROM [dbo].[GameReview]
      WHERE [Title] = 'Amazing Cool Game'
GO

----------------EndGameReview---------------------
--***********************End Valid Arguments***********************--


--***********************Invalid Arguments***********************--

--Begin Invalid Foreign Key Deletes
-- Error: Violates FK_GameReview_Game
DELETE FROM [dbo].[Game]
      WHERE [GameId] = 2
GO

-- Error: Violates FK_GameReview_Author
DELETE FROM [dbo].[Author]
	WHERE [AuthorId] = 2
GO

-- Error: Violates FK_Comment_GameReview
DELETE FROM [dbo].[GameReview]
      WHERE [GameReviewId] = 1
GO

-- Error: Violates FK_Comment_Gamer
DELETE FROM [dbo].[Gamer]
	WHERE [GamerId] = 7
GO
--End Invalid Foreign Key Deletes

--Begin Invalid Data Inserts


declare @Over4000Charecters as char(5000)

--Insert Invalid String Lengths for Author
INSERT INTO [dbo].[Author]
           ([Name]
           ,[Genre]
           ,[Biography])
     VALUES
           (@Over4000Charecters
           ,@Over4000Charecters
           ,@Over4000Charecters)
GO

declare @Over4000Charecters as char(5000)
INSERT INTO [dbo].[Comment]
           ([GameReviewId]
           ,[GamerId]
           ,[Title]
		   ,[Content])
     VALUES
           (1
           ,1
           ,@Over4000Charecters
           ,@Over4000Charecters)
GO

declare @Over4000Charecters as char(5000)
INSERT INTO [dbo].[Game]
           ([Title]
           ,[Description])
     VALUES
           (@Over4000Charecters
           ,@Over4000Charecters)
GO
declare @Over4000Charecters as char(5000)
INSERT INTO [dbo].Gamer
           ([Name]
           ,[AvatarUrl]
		   ,[Biography])
     VALUES
           (@Over4000Charecters
		   ,@Over4000Charecters
		   ,@Over4000Charecters)
GO

--***********************End Invalid Arguments***********************--

