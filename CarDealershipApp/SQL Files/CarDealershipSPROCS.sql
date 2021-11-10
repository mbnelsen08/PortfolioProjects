USE CarDealership;
GO

DROP PROCEDURE IF EXISTS dbo.StatesSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.BodyStyleSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.ModelsSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.MakesSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.TransmissionSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.InteriorColorSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.ExteriorColorSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.VehiclesSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.SalesSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.SpecialsSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.VehicleInsert
GO

DROP PROCEDURE IF EXISTS dbo.SpecialInsert
GO

DROP PROCEDURE IF EXISTS dbo.SaleInsert
GO

DROP PROCEDURE IF EXISTS dbo.MakeInsert
GO

DROP PROCEDURE IF EXISTS dbo.ModelInsert
GO

DROP PROCEDURE IF EXISTS dbo.MessageInsert
GO

DROP PROCEDURE IF EXISTS dbo.VehicleUpdate
GO

DROP PROCEDURE IF EXISTS dbo.VehicleDelete
GO

DROP PROCEDURE IF EXISTS dbo.SpecialDelete
GO

DROP PROCEDURE IF EXISTS dbo.GetVehicleByID
GO

DROP PROCEDURE IF EXISTS dbo.VehicleSearchSales
GO

DROP PROCEDURE IF EXISTS dbo.VehicleSearchNew
GO

DROP PROCEDURE IF EXISTS dbo.VehicleSearchUsed
GO

DROP PROCEDURE IF EXISTS dbo.SalesSearch
GO

DROP PROCEDURE IF EXISTS dbo.VehiclesSelectFeatured
GO

DROP PROCEDURE IF EXISTS dbo.UsersSelectAll
GO

DROP PROCEDURE IF EXISTS dbo.VehiclePurchase
GO

CREATE PROCEDURE StatesSelectAll AS

	SELECT StateID, StateAbv
	FROM States
Go

CREATE PROCEDURE BodyStyleSelectAll AS

	SELECT BodyStyleID, Style
	FROM BodyStyle
Go

CREATE PROCEDURE ExteriorColorSelectAll AS

	SELECT ExteriorColorID, ExteriorColor
	FROM ExteriorColors
Go

CREATE PROCEDURE InteriorColorSelectAll AS

	SELECT InteriorColorID, InteriorColor
	FROM InteriorColors
GO

CREATE PROCEDURE TransmissionSelectAll AS

	SELECT TransmissionID, Type
	FROM Transmission
GO

CREATE PROCEDURE MakesSelectAll AS

	SELECT MakeID, MakeName, DateAdded, UserEmail
	FROM Makes
GO

CREATE PROCEDURE MakeInsert (
	@MakeID int output,
	@MakeName varchar(30),
	@DateAdded date,
	@UserEmail varchar(50) )
	AS
	INSERT INTO Makes(MakeName, DateAdded, UserEmail)
	VALUES(@MakeName, @DateAdded, @UserEmail)
	SET @MakeID = SCOPE_IDENTITY();
GO

CREATE PROCEDURE ModelsSelectAll AS

	SELECT Models.ModelID, Models.MakeID, Models.ModelName, Models.DateAdded, Models.UserEmail, Makes.MakeName
	FROM Models
	JOIN Makes ON Makes.MakeID = Models.ModelID
Go

CREATE PROCEDURE ModelInsert (
	@ModelID int output,
	@MakeID int,
	@ModelName varchar(30),
	@DateAdded date,
	@UserEmail varchar(50) )
	AS
	INSERT INTO Models (MakeID, ModelName, DateAdded, UserEmail)
	VALUES(@MakeID, @ModelName, @DateAdded, @UserEmail)
	SET @ModelID = SCOPE_IDENTITY();
GO

CREATE PROCEDURE VehiclesSelectAll AS

	SELECT	Vehicles.VehicleID,
			Vehicles.MakeID,
			Vehicles.ModelID,
			Vehicles.ExteriorColorID,
			Vehicles.InteriorColorID,
			Vehicles.BodyStyleID,
			Vehicles.TransmissionID,
			Vehicles.[Year],
			Vehicles.Mileage,
			Vehicles.Vin,
			Vehicles.Msrp,
			Vehicles.SalePrice,
			Vehicles.[Description],
			Vehicles.ImageFileName,
			Vehicles.NewOld,
			Vehicles.Featured,
			Vehicles.Sold,
			Makes.MakeName,
			Models.ModelName,
			ExteriorColors.ExteriorColor,
			InteriorColors.InteriorColor,
			BodyStyle.Style,
			Transmission.[Type]
	FROM Vehicles
	JOIN Makes ON Vehicles.MakeID = Makes.MakeID
	JOIN Models ON Vehicles.ModelID = Models.ModelID
	JOIN ExteriorColors ON Vehicles.ExteriorColorID = ExteriorColors.ExteriorColorID
	JOIN InteriorColors ON Vehicles.InteriorColorID = InteriorColors.InteriorColorID
	JOIN BodyStyle ON Vehicles.BodyStyleID = BodyStyle.BodyStyleID
	JOIN Transmission ON Vehicles.TransmissionID = Transmission.TransmissionID
Go

CREATE PROCEDURE VehiclesSelectFeatured AS

	SELECT TOP 5
			Vehicles.VehicleID,
			Vehicles.MakeID,
			Vehicles.ModelID,
			Vehicles.ExteriorColorID,
			Vehicles.InteriorColorID,
			Vehicles.BodyStyleID,
			Vehicles.TransmissionID,
			Vehicles.[Year],
			Vehicles.Mileage,
			Vehicles.Vin,
			Vehicles.Msrp,
			Vehicles.SalePrice,
			Vehicles.[Description],
			Vehicles.ImageFileName,
			Vehicles.NewOld,
			Vehicles.Featured,
			Vehicles.Sold,
			Makes.MakeName,
			Models.ModelName,
			ExteriorColors.ExteriorColor,
			InteriorColors.InteriorColor,
			BodyStyle.Style,
			Transmission.[Type]
	FROM Vehicles
	JOIN Makes ON Vehicles.MakeID = Makes.MakeID
	JOIN Models ON Vehicles.ModelID = Models.ModelID
	JOIN ExteriorColors ON Vehicles.ExteriorColorID = ExteriorColors.ExteriorColorID
	JOIN InteriorColors ON Vehicles.InteriorColorID = InteriorColors.InteriorColorID
	JOIN BodyStyle ON Vehicles.BodyStyleID = BodyStyle.BodyStyleID
	JOIN Transmission ON Vehicles.TransmissionID = Transmission.TransmissionID
	WHERE Vehicles.Featured = 1;
Go

CREATE PROCEDURE GetVehicleByID(@VehicleID int) AS

	SELECT	Vehicles.VehicleID,
			Vehicles.MakeID,
			Vehicles.ModelID,
			Vehicles.ExteriorColorID,
			Vehicles.InteriorColorID,
			Vehicles.BodyStyleID,
			Vehicles.TransmissionID,
			Vehicles.[Year],
			Vehicles.Mileage,
			Vehicles.Vin,
			Vehicles.Msrp,
			Vehicles.SalePrice,
			Vehicles.[Description],
			Vehicles.ImageFileName,
			Vehicles.NewOld,
			Vehicles.Featured,
			Vehicles.Sold,
			Makes.MakeName,
			Models.ModelName,
			ExteriorColors.ExteriorColor,
			InteriorColors.InteriorColor,
			BodyStyle.Style,
			Transmission.[Type]
	FROM Vehicles
	JOIN Makes ON Vehicles.MakeID = Makes.MakeID
	JOIN Models ON Vehicles.ModelID = Models.ModelID
	JOIN ExteriorColors ON Vehicles.ExteriorColorID = ExteriorColors.ExteriorColorID
	JOIN InteriorColors ON Vehicles.InteriorColorID = InteriorColors.InteriorColorID
	JOIN BodyStyle ON Vehicles.BodyStyleID = BodyStyle.BodyStyleID
	JOIN Transmission ON Vehicles.TransmissionID = Transmission.TransmissionID
	WHERE Vehicles.VehicleID = @VehicleID
GO

CREATE PROCEDURE VehicleInsert (
	@VehicleID int output,
	@MakeID int,
	@ModelID int,
	@ExteriorColorID int,
	@InteriorColorID int,
	@BodyStyleID int,
	@TransmissionID int,
	@Year int,
	@Mileage int,
	@Vin int,
	@Msrp decimal(11,2),
	@SalePrice decimal(11,2),
	@Description varchar(max),
	@ImageFileName varchar(max),
	@NewOld bit,
	@Featured bit,
	@Sold bit )
	AS
	INSERT INTO Vehicles (MakeID, ModelID, ExteriorColorID, InteriorColorID, BodyStyleID, TransmissionID, [Year], Mileage, Vin, Msrp, SalePrice, [Description], NewOld, Featured, Sold)
	Values(@MakeID, @ModelID, @ExteriorColorID, @InteriorColorID, @BodyStyleID, @TransmissionID, @Year, @Mileage, @Vin, @Msrp, @SalePrice, @Description, @NewOld, @Featured, @Sold)
	SET @VehicleID = SCOPE_IDENTITY();
GO

CREATE PROCEDURE VehicleUpdate (
	@VehicleID int,
	@MakeID int,
	@ModelID int,
	@ExteriorColorID int,
	@InteriorColorID int,
	@BodyStyleID int,
	@TransmissionID int,
	@Year int,
	@Mileage int,
	@Vin int,
	@Msrp decimal(11,2),
	@SalePrice decimal(11,2),
	@Description varchar(max),
	@ImageFileName varchar(max),
	@NewOld bit,
	@Featured bit,
	@Sold bit )
	AS
	UPDATE Vehicles SET 
	MakeID = @MakeID,
	ModelID = @ModelID, 
	ExteriorColorID = @ExteriorColorID,
	InteriorColorID= @InteriorColorID,
	BodyStyleID = @BodyStyleID,
	TransmissionID = @TransmissionID, 
	[Year] = @Year,
	Mileage = @Mileage,
	Vin = @Vin,
	Msrp = @Msrp,
	SalePrice = @SalePrice,
	[Description] = @Description, 
	NewOld = @NewOld,
	Featured = @Featured,
	Sold = @Sold
	WHERE VehicleID = @VehicleID
GO

CREATE PROCEDURE VehiclePurchase (
	@VehicleID int )
	AS
	UPDATE Vehicles SET 
	Sold = 1
	WHERE VehicleID = @VehicleID
GO

CREATE PROCEDURE VehicleDelete (
	@VehicleID int)
	AS
	DELETE FROM Sales WHERE VehicleID = @VehicleID
	DELETE FROM Vehicles WHERE VehicleID = @VehicleID
GO

CREATE PROCEDURE SpecialsSelectAll AS
	
	SELECT SpecialID, Title, [Description]
	FROM Specials
GO

CREATE PROCEDURE SpecialInsert (
	@SpecialID int output,
	@Title varchar(100),
	@Description varchar(max) )
	AS
	INSERT INTO Specials(Title, [Description])
	VALUES(@Title,@Description)
	SET @SpecialID = SCOPE_IDENTITY();
GO

CREATE PROCEDURE SpecialDelete (
	@SpecialID int )
	AS
	DELETE FROM Specials WHERE SpecialID = @SpecialID
GO

CREATE PROCEDURE MessageInsert (
	@MessageID int output,
	@Name varchar(100),
	@Phone varchar(50),
	@Email varchar(50),
	@MessageText varchar(max))
	AS
	INSERT INTO [Messages]([Name], Phone, Email, MessageText)
	VALUES(@Name, @Phone, @Email, @MessageText)
	SET @MessageID = SCOPE_IDENTITY();
GO

CREATE PROCEDURE SalesSelectAll AS
	SELECT SaleID, VehicleID, StateID, PurchaseTypeID, [User], UserID, Vin, CustomerName, CustomerPhone, CustomerEmail, CustomerAddress, CustomerCity, CustomerZipcode, PurchasePrice, PurchaseDate
	From Sales
GO

CREATE PROCEDURE SaleInsert (
	@SaleID int output,
	@VehicleID int,
	@StateID int,
	@PurchaseTypeID int,
	@User varchar(100),
	@UserID varchar(100),
	@Vin int,
	@CustomerName varchar(100),
	@CustomerPhone varchar(20),
	@CustomerEmail varchar(50),
	@CustomerAddress varchar(100),
	@CustomerCity varchar(50),
	@CustomerZipcode varchar(50),
	@PurchasePrice decimal(11,2),
	@PurchaseDate date )
	AS
	INSERT INTO Sales(VehicleID, StateID, PurchaseTypeID, [User], UserID, Vin, CustomerName, CustomerPhone, CustomerEmail, CustomerAddress, CustomerCity, CustomerZipcode, PurchasePrice, PurchaseDate)
	VALUES (@VehicleID, @StateID, @PurchaseTypeID, @User, @UserID, @Vin, @CustomerName, @CustomerPhone, @CustomerEmail, @CustomerAddress, @CustomerCity, @CustomerZipcode, @PurchasePrice, @PurchaseDate)
	SET @SaleID = SCOPE_IDENTITY();
GO

CREATE PROCEDURE VehicleSearchSales (
	@SearchText varchar(100),
	@MinPrice decimal(11,2),
	@MaxPrice decimal(11,2),
	@MinYear int,
	@MaxYear int)
	AS
	SELECT @SearchText = '%'+@SearchText+'%'
	SELECT	Vehicles.VehicleID,
			Vehicles.MakeID,
			Vehicles.ModelID,
			Vehicles.ExteriorColorID,
			Vehicles.InteriorColorID,
			Vehicles.BodyStyleID,
			Vehicles.TransmissionID,
			Vehicles.[Year],
			Vehicles.Mileage,
			Vehicles.Vin,
			Vehicles.Msrp,
			Vehicles.SalePrice,
			Vehicles.[Description],
			Vehicles.ImageFileName,
			Vehicles.NewOld,
			Vehicles.Featured,
			Vehicles.Sold,
			Makes.MakeName,
			Models.ModelName,
			ExteriorColors.ExteriorColor,
			InteriorColors.InteriorColor,
			BodyStyle.Style,
			Transmission.[Type]
	FROM Vehicles
	JOIN Makes ON Vehicles.MakeID = Makes.MakeID
	JOIN Models ON Vehicles.ModelID = Models.ModelID
	JOIN ExteriorColors ON Vehicles.ExteriorColorID = ExteriorColors.ExteriorColorID
	JOIN InteriorColors ON Vehicles.InteriorColorID = InteriorColors.InteriorColorID
	JOIN BodyStyle ON Vehicles.BodyStyleID = BodyStyle.BodyStyleID
	JOIN Transmission ON Vehicles.TransmissionID = Transmission.TransmissionID
	WHERE (Makes.MakeName LIKE @SearchText
	OR Models.ModelName LIKE @SearchText
	OR Vehicles.[Year] LIKE @SearchText)
	AND (@MinPrice <= Vehicles.Msrp)
	AND (Vehicles.Msrp <= @MaxPrice)
	AND(@MinYear <= Vehicles.[Year])
	AND(Vehicles.[Year]<=@MaxYear)
	AND(Vehicles.Sold = 0)
	ORDER BY Vehicles.Msrp DESC
GO

CREATE PROCEDURE VehicleSearchNew (
	@SearchText varchar(100),
	@MinPrice decimal(11,2),
	@MaxPrice decimal(11,2),
	@MinYear int,
	@MaxYear int)
	AS
	SELECT @SearchText = '%'+@SearchText+'%'
	SELECT	Vehicles.VehicleID,
			Vehicles.MakeID,
			Vehicles.ModelID,
			Vehicles.ExteriorColorID,
			Vehicles.InteriorColorID,
			Vehicles.BodyStyleID,
			Vehicles.TransmissionID,
			Vehicles.[Year],
			Vehicles.Mileage,
			Vehicles.Vin,
			Vehicles.Msrp,
			Vehicles.SalePrice,
			Vehicles.[Description],
			Vehicles.ImageFileName,
			Vehicles.NewOld,
			Vehicles.Featured,
			Vehicles.Sold,
			Makes.MakeName,
			Models.ModelName,
			ExteriorColors.ExteriorColor,
			InteriorColors.InteriorColor,
			BodyStyle.Style,
			Transmission.[Type]
	FROM Vehicles
	JOIN Makes ON Vehicles.MakeID = Makes.MakeID
	JOIN Models ON Vehicles.ModelID = Models.ModelID
	JOIN ExteriorColors ON Vehicles.ExteriorColorID = ExteriorColors.ExteriorColorID
	JOIN InteriorColors ON Vehicles.InteriorColorID = InteriorColors.InteriorColorID
	JOIN BodyStyle ON Vehicles.BodyStyleID = BodyStyle.BodyStyleID
	JOIN Transmission ON Vehicles.TransmissionID = Transmission.TransmissionID
	WHERE (Makes.MakeName LIKE @SearchText
	OR Models.ModelName LIKE @SearchText
	OR Vehicles.[Year] LIKE @SearchText)
	AND (@MinPrice <= Vehicles.Msrp)
	AND (Vehicles.Msrp <= @MaxPrice)
	AND(@MinYear <= Vehicles.[Year])
	AND(Vehicles.[Year]<=@MaxYear)
	AND(Vehicles.NewOld = 1)
	ORDER BY Vehicles.Msrp DESC
GO

CREATE PROCEDURE VehicleSearchUsed (
	@SearchText varchar(100),
	@MinPrice decimal(11,2),
	@MaxPrice decimal(11,2),
	@MinYear int,
	@MaxYear int)
	AS
	SELECT @SearchText = '%'+@SearchText+'%'
	SELECT	Vehicles.VehicleID,
			Vehicles.MakeID,
			Vehicles.ModelID,
			Vehicles.ExteriorColorID,
			Vehicles.InteriorColorID,
			Vehicles.BodyStyleID,
			Vehicles.TransmissionID,
			Vehicles.[Year],
			Vehicles.Mileage,
			Vehicles.Vin,
			Vehicles.Msrp,
			Vehicles.SalePrice,
			Vehicles.[Description],
			Vehicles.ImageFileName,
			Vehicles.NewOld,
			Vehicles.Featured,
			Vehicles.Sold,
			Makes.MakeName,
			Models.ModelName,
			ExteriorColors.ExteriorColor,
			InteriorColors.InteriorColor,
			BodyStyle.Style,
			Transmission.[Type]
	FROM Vehicles
	JOIN Makes ON Vehicles.MakeID = Makes.MakeID
	JOIN Models ON Vehicles.ModelID = Models.ModelID
	JOIN ExteriorColors ON Vehicles.ExteriorColorID = ExteriorColors.ExteriorColorID
	JOIN InteriorColors ON Vehicles.InteriorColorID = InteriorColors.InteriorColorID
	JOIN BodyStyle ON Vehicles.BodyStyleID = BodyStyle.BodyStyleID
	JOIN Transmission ON Vehicles.TransmissionID = Transmission.TransmissionID
	WHERE (Makes.MakeName LIKE @SearchText
	OR Models.ModelName LIKE @SearchText
	OR Vehicles.[Year] LIKE @SearchText)
	AND (@MinPrice <= Vehicles.Msrp)
	AND (Vehicles.Msrp <= @MaxPrice)
	AND(@MinYear <= Vehicles.[Year])
	AND(Vehicles.[Year]<=@MaxYear)
	AND(Vehicles.NewOld = 0)
	ORDER BY Vehicles.Msrp DESC
GO

CREATE PROCEDURE SalesSearch (
	@UserID varchar(100),
	@MinDate Date,
	@MaxDate Date )
AS
	SELECT @UserID = '%'+@UserID+'%'
	SELECT DISTINCT Sales.UserID,
		COUNT(Sales.SaleID) AS SalesPerUser,
		Sales.[User],
		SUM(Sales.PurchasePrice) AS TotalSales
	FROM Sales
	WHERE Sales.UserID LIKE @UserID
	GROUP BY Sales.UserID, Sales.[User]
GO

CREATE PROCEDURE UsersSelectAll AS

SELECT	*
FROM AspNetUsers
JOIN AspNetUserRoles ON AspNetUserRoles.UserId = AspNetUsers.Id
JOIN AspNetRoles ON AspNetRoles.Id = AspNetUserRoles.RoleId
GO
