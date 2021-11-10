USE [master];
GO

if exists (select * from sys.databases where name = N'CarDealership')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'CarDealership';
	ALTER DATABASE CarDealership SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE CarDealership;
end

CREATE DATABASE CarDealership;
GO

USE CarDealership;
GO

if exists (select * from sys.tables where name = N'Transmission')
	DROP TABLE Transmission
GO

CREATE TABLE Transmission (
    TransmissionID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Type varchar(10) NOT NULL
);

if exists (select * from sys.tables where name = N'BodyStyle')
	DROP TABLE BodyStyle
GO

CREATE TABLE BodyStyle (
    BodyStyleID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Style varchar(20) NOT NULL
);

if exists (select * from sys.tables where name = N'ExteriorColors')
	DROP TABLE ExteriorColor
GO

CREATE TABLE ExteriorColors (
    ExteriorColorID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ExteriorColor varchar(20) NOT NULL
);

if exists (select * from sys.tables where name = N'InteriorColors')
	DROP TABLE InteriorColor
GO

CREATE TABLE InteriorColors (
    InteriorColorID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	InteriorColor varchar(20) NOT NULL
);

if exists (select * from sys.tables where name = N'Makes')
	DROP TABLE Makes
GO

CREATE TABLE Makes (
    MakeID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
	MakeName varchar(30) NOT NULL,
	DateAdded Date NOT NULL,
	UserEmail varchar(50) NOT NULL
);

if exists (select * from sys.tables where name = N'Models')
	DROP TABLE Models
GO

CREATE TABLE Models (
    ModelID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MakeID int NOT NULL foreign key references Makes(MakeID),
	ModelName varchar(30) NOT NULL,
	DateAdded Date NOT NULL,
	UserEmail varchar(50) NOT NULL
);

if exists (select * from sys.tables where name = N'Vehicles')
	DROP TABLE Vehicles
GO

CREATE TABLE Vehicles (
    VehicleID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MakeID int NOT NULL foreign key references Makes(MakeID),
	ModelID int NOT NULL foreign key references Models(ModelID),
	ExteriorColorID int NOT NULL foreign key references ExteriorColors(ExteriorColorID),
	InteriorColorID int NOT NULL foreign key references InteriorColors(InteriorColorID),
	BodyStyleID int NOT NULL foreign key references BodyStyle(BodyStyleID),
	TransmissionID int NOT NULL foreign key references Transmission(TransmissionID),
	[Year] int NOT NULL,
	Mileage int NULL,
	Vin int NOT NULL,
	Msrp decimal(11,2) NOT NULL,
	SalePrice decimal(11,2) NOT NULL,
	[Description] varchar(max) NULL,
	Picture varchar(max) NULL,
	NewOld bit NOT NULL,
	Featured bit NOT NULL,
	Sold bit NOT NULL,
	ImageFileName varchar(max) NULL
);

if exists (select * from sys.tables where name = N'Messages')
	DROP TABLE Messages
GO

CREATE TABLE Messages (
    MessageID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] varchar(100) NOT NULL,
	Phone varchar(50) NULL,
	Email varchar(50) NULL,
	MessageText varchar(max) NOT NULL
);

if exists (select * from sys.tables where name = N'Specials')
	DROP TABLE Specials
GO

CREATE TABLE Specials (
    SpecialID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Title varchar(100) NOT NULL,
	Description varchar(max) NOT NULL
);

if exists (select * from sys.tables where name = N'States')
	DROP TABLE States
GO

CREATE TABLE States (
    StateID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	StateAbv char(2) NOT NULL
);

if exists (select * from sys.tables where name = N'PurchaseTypes')
	DROP TABLE PurchaseTypes
GO

CREATE TABLE PurchaseTypes (
    PurchaseTypeID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Type varchar(20) NOT NULL
);

if exists (select * from sys.tables where name = N'Sales')
	DROP TABLE Sales
GO

CREATE TABLE Sales (
    SaleID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	VehicleID int NOT NULL foreign key references Vehicles(VehicleID),
	StateID int NOT NULL foreign key references States(StateID),
	PurchaseTypeID int NOT NULL foreign key references PurchaseTypes(PurchaseTypeID),
	[User] varchar(100) NOT NULL,
	UserID nvarchar(128) NOT NULL,
	Vin int NOT NULL,
	CustomerName varchar(100) NOT NULL,
	CustomerPhone varchar(20) NOT NULL,
	CustomerEmail varchar(50) NOT NULL,
	CustomerAddress varchar(100) NOT NULL,
	CustomerCity varchar(50) NOT NULL,
	CustomerZipcode varchar(10) NOT NULL,
	PurchasePrice decimal(11,2) NOT NULL,
	PurchaseDate Date NOT NULL
);