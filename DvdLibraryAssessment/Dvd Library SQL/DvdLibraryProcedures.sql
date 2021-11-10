USE DvdLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AllMovies')
      DROP PROCEDURE AllMovies
GO

CREATE PROCEDURE AllMovies
AS

SELECT * FROM Movies
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetMovieById')
      DROP PROCEDURE GetMovieById
GO

CREATE PROCEDURE GetMovieById(
    @DvdId int
)
AS

SELECT * FROM Movies
WHERE DvdId = @DvdId

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetMovieByTitle')
      DROP PROCEDURE GetMovieByTitle
GO

CREATE PROCEDURE GetMovieByTitle(
    @searchText varchar(50)
)
AS

SELECT @searchText = '%'+@searchText+'%'
SELECT * FROM Movies
WHERE Title LIKE @searchText
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetMovieByRating')
      DROP PROCEDURE GetMovieByRating
GO

CREATE PROCEDURE GetMovieByRating(
    @searchText varchar(50)
)
AS
SELECT @searchText = '%'+@searchText+'%'
SELECT * FROM Movies
WHERE Rating LIKE @searchText
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetMovieByDirector')
      DROP PROCEDURE GetMovieByDirector
GO

CREATE PROCEDURE GetMovieByDirector(
    @searchText varchar(50)
)
AS
SELECT @searchText = '%'+@searchText+'%'
SELECT * FROM Movies
WHERE Director LIKE @searchText
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetMovieByYear')
      DROP PROCEDURE GetMovieByYear
GO

CREATE PROCEDURE GetMovieByYear(
    @searchText varchar(50)
)
AS
SELECT @searchText = '%'+@searchText+'%'
SELECT * FROM Movies
WHERE ReleaseYear LIKE @searchText
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieDelete')
      DROP PROCEDURE MovieDelete
GO

CREATE PROCEDURE MovieDelete (
	@DvdId int
)
AS
	DELETE FROM Movies
	WHERE DvdId = @DvdId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieUpdate')
      DROP PROCEDURE MovieUpdate
GO

CREATE PROCEDURE MovieUpdate (
	@DvdId int,
	@Title varchar(50),
	@Rating varchar(10),
	@Director varchar(50),
	@ReleaseYear varchar(10),
	@Notes varchar(500)
)
AS
	UPDATE Movies
		SET Title = @Title,
			Rating = @Rating,
			Director = @Director,
			ReleaseYear = @ReleaseYear,
			Notes = @Notes
	WHERE DvdId = @DvdId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieAdd')
      DROP PROCEDURE MovieAdd
GO

CREATE PROCEDURE MovieAdd (
	@DvdId int output,
	@Title varchar(50),
	@Rating varchar(10),
	@Director Varchar(50),
	@ReleaseYear varchar(10),
	@Notes varchar(500)
)
AS
	INSERT INTO Movies (Title, Rating, Director, ReleaseYear, Notes)
	VALUES (@Title, @Rating, @Director, @ReleaseYear, @Notes)

	SET @DvdId = SCOPE_IDENTITY()
GO