-- Create database
CREATE DATABASE dbCascadingProject

-- Use database
USE dbCascadingProject

-- Create table to store the user's record
CREATE TABLE tUserRecord
(
	[User ID] INT PRIMARY KEY IDENTITY,
	Name VARCHAR(60) NOT NULL,
	Email VARCHAR(60) NOT NULL,
	Gender INT,
	Country INT,
	State INT,
	Password VARCHAR(10)
)

-- View table "tUserRecord" to see the user records
SELECT * FROM tUserRecord

-- Create table for gender column
CREATE TABLE tGender
(
	[Gender ID] INT PRIMARY KEY IDENTITY,
	GEN VARCHAR(6) NOT NULL
)

-- Inserting data into "tGender" table
INSERT INTO tGender(GEN)VALUES('Male')
INSERT INTO tGender(GEN)VALUES('Female')
INSERT INTO tGender(GEN)VALUES('Other')

-- Viewing table "tGender"
SELECT * FROM tGender

-- Creating table for column "Country"
CREATE TABLE tCountry
(
	[Country ID] INT PRIMARY KEY IDENTITY,
	[Country Name] VARCHAR(60) NOT NULL
)

-- Inserting data into table "tCountry"
INSERT INTO tCountry([Country Name])VALUES('United States')
INSERT INTO tCountry([Country Name])VALUES('India')
INSERT INTO tCountry([Country Name])VALUES('Australia')
INSERT INTO tCountry([Country Name])VALUES('Saudi Arabia')

-- Viewing table "tCountry"
SELECT * FROM tCountry

-- Create table for column "State"
-- Note: The column "State" would be dependent on column "Country"
CREATE TABLE tState
(
	[State ID] INT PRIMARY KEY IDENTITY,
	[CID] INT,
	[State Name] VARCHAR(60) NOT NULL
)

-- Inserting data into table "tState"
INSERT INTO tState([CID],[State Name]) VALUES(1, 'Arizona')
INSERT INTO tState([CID],[State Name]) VALUES(1, 'Connecticut')
INSERT INTO tState([CID],[State Name]) VALUES(1, 'Delaware')
INSERT INTO tState([CID],[State Name]) VALUES(1, 'Idaho')
INSERT INTO tState([CID],[State Name]) VALUES(1, 'Illinois')
INSERT INTO tState([CID],[State Name]) VALUES(1, 'Maryland')
INSERT INTO tState([CID],[State Name]) VALUES(1, 'Michigan')
INSERT INTO tState([CID],[State Name]) VALUES(1, 'New York')
INSERT INTO tState([CID],[State Name]) VALUES(1, 'Ohio')
INSERT INTO tState([CID],[State Name]) VALUES(1, 'Texas')

INSERT INTO tState([CID],[State Name]) VALUES(2, 'Maharashtra')
INSERT INTO tState([CID],[State Name]) VALUES(2, 'Bihar')
INSERT INTO tState([CID],[State Name]) VALUES(2, 'Uttar Pradesh')
INSERT INTO tState([CID],[State Name]) VALUES(2, 'West Bengal')
INSERT INTO tState([CID],[State Name]) VALUES(2, 'Madhya Pradesh')
INSERT INTO tState([CID],[State Name]) VALUES(2, 'Tamil Nadu')
INSERT INTO tState([CID],[State Name]) VALUES(2, 'Rajasthan')
INSERT INTO tState([CID],[State Name]) VALUES(2, 'Karnataka')
INSERT INTO tState([CID],[State Name]) VALUES(2, 'Delhi')
INSERT INTO tState([CID],[State Name]) VALUES(2, 'Gujarat')

INSERT INTO tState([CID],[State Name]) VALUES(3, 'New South Wales')
INSERT INTO tState([CID],[State Name]) VALUES(3, 'Victoria')
INSERT INTO tState([CID],[State Name]) VALUES(3, 'Queensland')
INSERT INTO tState([CID],[State Name]) VALUES(3, 'Western Australia')
INSERT INTO tState([CID],[State Name]) VALUES(3, 'South Australia')
INSERT INTO tState([CID],[State Name]) VALUES(3, 'Tasmania')
INSERT INTO tState([CID],[State Name]) VALUES(3, 'Northern Territory')
INSERT INTO tState([CID],[State Name]) VALUES(3, 'Australian Capital Territory')

INSERT INTO tState([CID],[State Name]) VALUES(4, 'Riyadh')
INSERT INTO tState([CID],[State Name]) VALUES(4, 'Makkah (Mecca)')
INSERT INTO tState([CID],[State Name]) VALUES(4, 'Madinah (Medina)')
INSERT INTO tState([CID],[State Name]) VALUES(4, 'Eastern Province')
INSERT INTO tState([CID],[State Name]) VALUES(4, 'Qassim (Al-Qassim)')
INSERT INTO tState([CID],[State Name]) VALUES(4, 'Tabuk')
INSERT INTO tState([CID],[State Name]) VALUES(4, 'Baha')
INSERT INTO tState([CID],[State Name]) VALUES(4, 'Al-Jouf (Al-Jawf)')
INSERT INTO tState([CID],[State Name]) VALUES(4, 'Asir')
INSERT INTO tState([CID],[State Name]) VALUES(4, 'Jazan')

-- View table "tStates"
SELECT * FROM tState

-- Create stored procedure to bind the gender
CREATE PROC spBindGender
AS
BEGIN
	SELECT * FROM tGender
END;

-- Create stored procedure to bind the country
CREATE PROC spBindCountry
AS
BEGIN
	SELECT * FROM tCountry
END;

-- Create stored procedure to bind the state
CREATE PROC spBindState
(
	@country_id INT
)
AS
BEGIN
	SELECT * FROM tState WHERE CID = @country_id
END;

-- Create proc to insert user record into "tUserRecord" table
CREATE PROC spInsertRecord
(
	@name VARCHAR(60),
	@email VARCHAR(60),
	@gender INT,
	@country INT,
	@state INT,
	@password VARCHAR(10)
)
AS
BEGIN
	INSERT INTO tUserRecord(Name, Email, Gender, Country, State, Password) VALUES (@name,@email,@gender,@country,@state,@password)
END;

