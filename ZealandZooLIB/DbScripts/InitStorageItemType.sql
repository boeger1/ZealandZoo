USE [bullerbob_dk_db_zealandzoo]
GO

DELETE FROM [dbo].[ItemType];

INSERT INTO [dbo].[ItemType]
           ([Item_Type])
     VALUES
           ('Sodavand'),
		   ('Alkohol'),
		   ('Snack'),
           ('SoftDrink'),
           ('Alcohol')
GO


