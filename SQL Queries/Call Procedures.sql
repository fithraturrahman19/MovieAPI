
CALL spMovies_GetMovies();

CALL spMovies_GetMovie(3);

CALL spMovies_DeleteMovie(2);

CALL spMovies_AddMovie(2, 'Title', 'Desc', 7.5, 'Image', 'datecreated', 'dateupdated');

CALL spMovies_UpdateMovie(2, 'Title', 'Desc', 7.5, 'Image', 'datecreated', 'dateupdated');