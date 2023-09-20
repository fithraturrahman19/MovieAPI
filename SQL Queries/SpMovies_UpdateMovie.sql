DELIMITER $$

CREATE PROCEDURE spMovies_UpdateMovie(
	IN Id INT,
	IN Title NVARCHAR(200),
    IN Description NVARCHAR(500),
    IN Rating float,
    IN Image NVARCHAR(300),
    IN Created_at DATETIME,
    IN Updated_at DATETIME
)

BEGIN
	UPDATE Movies m
    SET
        m.Title = CASE WHEN Title IS NOT NULL THEN Title ELSE m.Title END, 
        m.Description = CASE WHEN Description IS NOT NULL THEN Description ELSE m.Description END, 
        m.Rating = CASE WHEN Rating IS NOT NULL THEN Rating ELSE m.Rating END, 
        m.Image = CASE WHEN Image IS NOT NULL THEN Image ELSE m.Image END, 
        m.Created_at = CASE WHEN Created_at IS NOT NULL THEN Created_at ELSE m.Created_at END, 
        m.Updated_at = CASE WHEN Updated_at IS NOT NULL THEN Updated_at ELSE m.Updated_at END
	WHERE  m.Id = Id;
END$$

DELIMITER ;