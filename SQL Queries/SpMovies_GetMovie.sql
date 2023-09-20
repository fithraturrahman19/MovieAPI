DELIMITER $$

CREATE PROCEDURE spMovies_GetMovie(
	IN Id int
)
BEGIN
	SELECT * FROM movies m
    WHERE m.Id = Id;
END$$

DELIMITER ;