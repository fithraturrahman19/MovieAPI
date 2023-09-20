DELIMITER $$

CREATE PROCEDURE spMovies_DeleteMovie(
	IN Id int
)
BEGIN
	DELETE FROM movies m
    WHERE m.Id = Id;
END$$

DELIMITER ;