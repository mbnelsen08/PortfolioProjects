USE [master];
GO

if exists (select * from sys.databases where name = N'DvdLibrary')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'DvdLibrary';
	ALTER DATABASE DvdLibrary SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE DvdLibrary;
end

CREATE DATABASE DvdLibrary;
GO

USE DvdLibrary
Go

CREATE TABLE Movies (
	DvdId int Primary Key Identity(1,1),
	Title varchar(50) NOT NULL,
	Rating varchar(10) NULL,
	Director varchar(50) NULL,
	ReleaseYear varchar(10) NOT NULL,
	Notes varchar(500) NULL
);


SET IDENTITY_INSERT Movies ON;
INSERT INTO Movies(DvdId,Title,Rating,Director,ReleaseYear,Notes) Values
	(1,'Ghostbusters','PG-13','George','1972','There are lots of ghosts in this one.'),
	(2,'Star Wars','PG','Lucas','1977','Space!!!'),
	(3,'Indian Jones','G','Steven','1988','Exploration. Adventure. Nazis!');

SET IDENTITY_INSERT Movies OFF;