CREATE TABLE Users(
	Id			int				PRIMARY KEY IDENTITY,
	UserName	nvarchar(256)	NOT NULL,
	Email		nvarchar(256)	NOT NULL
)

CREATE TABLE Games(
	Id			int				PRIMARY KEY IDENTITY,
	Name		nvarchar(256)	NOT NULL,
	OwnerUserId	int				NOT NULL
)

CREATE TABLE Players(
	Id			int				PRIMARY KEY IDENTITY,
	GameId		int				NOT NULL,
	UserId		int				NULL,
	Name		nvarchar(256)	NOT NULL
)

CREATE TABLE DungeonMasters(
	Id			int				PRIMARY KEY IDENTITY,
	GameId		int				NOT NULL,
	UserId		int				NOT NULL
)