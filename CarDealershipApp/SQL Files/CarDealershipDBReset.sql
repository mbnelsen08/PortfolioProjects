USE CarDealership;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DBReset')
      DROP PROCEDURE DBReset
GO

CREATE PROCEDURE DBReset AS
BEGIN
	
	DELETE FROM Specials;
	DELETE FROM Sales;
	DELETE FROM Vehicles;
	DELETE FROM PurchaseTypes;
	DELETE FROM States;
	DELETE FROM BodyStyle;
	DELETE FROM ExteriorColors;
	DELETE FROM InteriorColors;
	DELETE FROM Transmission;
	DELETE FROM Models;
	DELETE FROM Makes;

	DBCC CHECKIDENT ( 'Vehicles', RESEED, 1 )
	DBCC CHECKIDENT ( 'Makes', RESEED, 1 )
	DBCC CHECKIDENT ( 'Models', RESEED, 1 )
	DBCC CHECKIDENT ( 'Messages', RESEED, 1 )
	DBCC CHECKIDENT ( 'Sales', RESEED, 1 )

	SET IDENTITY_INSERT States ON;
	INSERT INTO States (StateID, StateAbv)
	VALUES (1, 'SD'),
	(2,'MN'),
	(3,'OH'),
	(4,'KY'),
	(5,'IA')
	SET IDENTITY_INSERT States OFF;

	SET IDENTITY_INSERT BodyStyle ON;
	INSERT INTO BodyStyle (BodyStyleID, Style)
	VALUES (1, 'SUV'),
	(2,'Sedan'),
	(3,'Hatchback'),
	(4,'Convertible'),
	(5,'Truck')
	SET IDENTITY_INSERT BodyStyle OFF;

	SET IDENTITY_INSERT ExteriorColors ON;
	INSERT INTO ExteriorColors (ExteriorColorID, ExteriorColor)
	VALUES (1, 'Black'),
	(2,'White'),
	(3,'Red'),
	(4,'Grey'),
	(5,'Green')
	SET IDENTITY_INSERT ExteriorColors OFF;

	SET IDENTITY_INSERT InteriorColors ON;
	INSERT INTO InteriorColors (InteriorColorID, InteriorColor)
	VALUES (1, 'Black'),
	(2,'White'),
	(3,'Red'),
	(4,'Grey'),
	(5,'Green')
	SET IDENTITY_INSERT InteriorColors OFF;

	SET IDENTITY_INSERT Transmission ON;
	INSERT INTO Transmission (TransmissionID, [Type])
	VALUES (1, 'Manual'),
	(2,'Automatic')
	SET IDENTITY_INSERT Transmission OFF;

	SET IDENTITY_INSERT Makes ON;
	INSERT INTO Makes (MakeID, MakeName, DateAdded, UserEmail)
	VALUES (1, 'Ford', '10/18/2021', 'mbnelsen08@gmail.com'),
	(2,'Dodge', '10/18/2021', 'mbnelsen08@gmail.com'),
	(3,'Honda', '10/18/2021', 'mbnelsen08@gmail.com'),
	(4,'Nissan' , '10/18/2021', 'mbnelsen08@gmail.com'),
	(5,'Toyota' , '10/18/2021', 'mbnelsen08@gmail.com')
	SET IDENTITY_INSERT Makes OFF;

	SET IDENTITY_INSERT Models ON;
	INSERT INTO Models (ModelID, MakeID, ModelName, DateAdded, UserEmail)
	VALUES (1, 5, 'Corolla', '10/18/2021', 'test@test.org'),
	(2, 4, 'Rogue', '10/18/2021', 'test@test.org'),
	(3, 3, 'Accord', '10/18/2021', 'test@test.org'),
	(4, 2, 'Caravan','10/18/2021', 'test@test.org'),
	(5, 1, 'F-150', '10/18/2021', 'test@test.org')
	SET IDENTITY_INSERT Models OFF;

	

	SET IDENTITY_INSERT Vehicles ON;
	INSERT INTO Vehicles (VehicleID, MakeID, ModelID, ExteriorColorID, InteriorColorID, BodyStyleID, TransmissionID, [Year], Mileage, Vin, Msrp, SalePrice, [Description], ImageFileName,Newold, Featured, Sold)
	VALUES	(1, 5, 1, 1,1,2,1,2018,8000,1234567890,21000,18000,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'Placeholder.png',0,1,0),
			(2, 4, 2, 1,1,3,1,2020,8000,1234567890,17000,18000,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.','Placeholder.png', 1,1,1),
			(3, 3, 3, 1,1,1,1,2015,8000,1234567890,33000,18000,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.','Placeholder.png', 0,1,0),
			(4, 2, 4, 1,1,1,1,2017,8000,1234567890,24000,18000,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'Placeholder.png', 1,1,0),
			(5, 1, 5, 1,1,1,1,2012,8000,1234567890,19000,18000,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'Placeholder.png', 0,1,0)
	SET IDENTITY_INSERT Vehicles OFF;
	
	SET IDENTITY_INSERT Specials ON;
	INSERT INTO Specials (SpecialID, Title, [Description])
	VALUES	(1, '2-For-1','Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
			(2, '3-For-1','Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
			(3, '4-For-1','Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
			(4, 'Free pop!','Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'),
			(5, 'Daily Specials','Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.')
	SET IDENTITY_INSERT Specials OFF;

	SET IDENTITY_INSERT PurchaseTypes ON;
	INSERT INTO PurchaseTypes (PurchaseTypeID, [Type])
	VALUES	(1, 'Bank Finance'),
			(2, 'Cash'),
			(3, 'Dealer Finance')
	SET IDENTITY_INSERT PurchaseTypes OFF;

	SET IDENTITY_INSERT Sales ON;
	INSERT INTO Sales (SaleID, VehicleID, StateID, PurchaseTypeID, [User], UserID , Vin, CustomerName, CustomerPhone, CustomerEmail, CustomerAddress, CustomerCity, CustomerZipcode, PurchasePrice, PurchaseDate)
	VALUES	(1, 2, 1, 1, 'test', '00000000-0000-0000-0000-000000000000' ,1234567890, 'Mark', '605555555','mbnelsen08@gmail.com','555 West St.','Sioux Falls','57106',12000,'10/21/2021'),
			(2, 2, 1, 1, 'test', '00000000-0000-0000-0000-000000000000' ,1234567890, 'Mark', '605555555','mbnelsen08@gmail.com','555 West St.','Sioux Falls','57106',12000,'10/21/2021'),
			(3, 2, 1, 1, 'test', '00000000-0000-0000-0000-000000000000' ,1234567890, 'Mark', '605555555','mbnelsen08@gmail.com','555 West St.','Sioux Falls','57106',12000,'10/21/2021'),
			(4, 2, 1, 1, 'test', '00000000-0000-0000-0000-000000000000' ,1234567890, 'Mark', '605555555','mbnelsen08@gmail.com','555 West St.','Sioux Falls','57106',12000,'10/21/2021'),
			(5, 2, 1, 1, 'test2', '00000000-0000-0000-0000-000000000001' ,1234567890, 'Mark', '605555555','mbnelsen08@gmail.com','555 West St.','Sioux Falls','57106',12000,'10/21/2021')
	SET IDENTITY_INSERT Sales OFF;


END