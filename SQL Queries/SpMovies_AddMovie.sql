DELIMITER $$

CREATE PROCEDURE spMovies_AddMovie(
	IN Id INT,
	IN Title NVARCHAR(200),
    IN Description NVARCHAR(500),
    IN Rating float,
    IN Image NVARCHAR(300),
    IN Created_at DATETIME,
    IN Updated_at DATETIME
)

BEGIN
	INSERT INTO Movies (Id, Title, Description, Rating, Image, Created_at, Updated_at)
	VALUES (Id, Title, Description, Rating, Image, Created_at, Updated_at);
END$$

DELIMITER ;