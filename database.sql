create database AnimeDatabase

use AnimeDatabase

create table Anime (
	AnimeId int,
	Title nvarchar(255) not null,
	AlternateTitle nvarchar(255),
	CoverImage nvarchar(255),
	Author nvarchar(255),
	Synopsis nvarchar(MAX),
	constraint PK_Anime primary key (AnimeId)
)