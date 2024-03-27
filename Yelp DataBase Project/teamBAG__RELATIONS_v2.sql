-- Team BAG Milestone 1, Create tables based on ER Diagram.

CREATE TABLE Users
(   userId CHAR(30) NOT NULL UNIQUE,
    uname VARCHAR(50) NOT NULL,
    join_datetime VARCHAR(25) NOT NULL,
    tipcount INTEGER DEFAULT 0,
    totalFans INT DEFAULT 0,
    totalLikes INT DEFAULT 0,
    avgStars FLOAT CHECK (avgStars <= 5.0 AND avgStars >= 0.0), --perhaps check for non-negatives
    funnyVotes INT DEFAULT 0,
    coolVotes INT DEFAULT 0,
    usefulVotes INT DEFAULT 0,
    Primary Key (userId)
);


CREATE TABLE Friend (
    userId VARCHAR(30) NOT NULL,
    friendId VARCHAR(30),
    PRIMARY KEY(userId, friendId),
	FOREIGN KEY (friendId) REFERENCES Users(userId),
    FOREIGN KEY (userId) REFERENCES Users(userId)
);



CREATE TABLE Business
(   busId VARCHAR(30) NOT NULL,
    bname VARCHAR(75) NOT NULL,
    bAddress VARCHAR(128),
    bCity VARCHAR(128),
    bState VARCHAR(4),
    bZip VARCHAR(5),
    checkInCount INT DEFAULT 0,
    tipCount INT DEFAULT 0,
    stars FLOAT NOT NULL DEFAULT 0.0,
    latitude FLOAT,
    longitude FLOAT,
    isOpen VARCHAR(10),
    Primary Key (busId)
);

CREATE TABLE Categories (
    busId VARCHAR(30),
    category VARCHAR(50),
	PRIMARY KEY (busId, category),
    FOREIGN KEY (busId) REFERENCES Business(busId)
);

CREATE TABLE Attributes (
    busId VARCHAR(30),
    attribute VARCHAR(50),
	value VARCHAR(20),
	PRIMARY KEY (busId, attribute),
    FOREIGN KEY (busId) REFERENCES Business(busId)
);

CREATE TABLE checkIn (
    busId VARCHAR(30) NOT NULL,
	year INTEGER,
	month INTEGER,
	day INTEGER, 
	time TIME,
    PRIMARY KEY(busId, year, month, day, time),
    FOREIGN KEY (busId) REFERENCES Business(busId)
);

CREATE TABLE Hours(
	busId CHAR(30),
	dayOfWeek VARCHAR(15),
	openTime VARCHAR,
	closeTime VARCHAR,
	PRIMARY KEY (busId, dayOfWeek),
	FOREIGN KEY (busId) REFERENCES Business (busId)
);

CREATE TABLE tip (
    busId VARCHAR(30) NOT NULL,
    userId VARCHAR(30) NOT NULL,
	tipDate TIMESTAMP,
    likes INTEGER DEFAULT 0,
    tipText VARCHAR,
    PRIMARY KEY (busId, userId,tipDate),
    FOREIGN KEY (busId) REFERENCES business(busId),
    FOREIGN KEY (userId) REFERENCES users(userId)
);
