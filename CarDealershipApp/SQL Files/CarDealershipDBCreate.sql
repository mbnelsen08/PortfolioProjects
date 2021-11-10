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
