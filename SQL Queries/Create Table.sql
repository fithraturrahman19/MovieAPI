CREATE TABLE Movies (
	Id int NOT NULL,
    Title NVARCHAR(200),
    Description NVARCHAR(500),
    Rating float,
    Image NVARCHAR(200),
    Created_at DATETIME,
    Updated_at DATETIME,
    PRIMARY KEY (Id)
)