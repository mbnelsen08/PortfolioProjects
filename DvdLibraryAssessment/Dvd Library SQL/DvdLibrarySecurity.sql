CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DvdLibrary
GO
 
CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON AllMovies TO DvdLibraryApp
GRANT EXECUTE ON GetMovieByDirector TO DvdLibraryApp
GRANT EXECUTE ON GetMovieById TO DvdLibraryApp
GRANT EXECUTE ON GetMovieByRating TO DvdLibraryApp
GRANT EXECUTE ON GetMovieByTitle TO DvdLibraryApp
GRANT EXECUTE ON GetMovieByYear TO DvdLibraryApp
GRANT EXECUTE ON MovieDelete TO DvdLibraryApp
GRANT EXECUTE ON MovieUpdate TO DvdLibraryApp
GRANT EXECUTE ON MovieAdd TO DvdLibraryApp
GO