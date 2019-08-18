CREATE DATABASE University;
GO 
USE University;

CREATE TABLE Class
(
	STT int IDENTITY,
	ID nvarchar(10) NOT NULL ,
	NameC nvarChar(50) NOT NULL,
	Sex CHAR(6) NOT NULL CHECK (Sex = 'Male' OR Sex = 'Female'),
	SSN char(15),
	Class char(15) not null,
	PRIMARY KEY(ID,Class),
);

CREATE TABLE Schedule
(
	STT int IDENTITY,
	Code nvarchar(15) NOT NULL PRIMARY KEY,
	NameC Char(50) NOT NULL,
	Classroom CHAR(10) NOT NULL ,
	Class char(15),
	
);

CREATE TABLE Schedule_Class
(
	STT int IDENTITY,
	ID nvarchar(10) NOT NULL ,
	NameC nvarChar(50) NOT NULL,
	Sex CHAR(6) NOT NULL CHECK (Sex = 'Male' OR Sex = 'Female'),
	SSN char(15),
	Class char(10) not null,
	CodeSchedule char(15) not null,
	--PRIMARY KEY(ID,Class),
);



create table Transcript
(
	STT int IDENTITY,
	ID nvarchar(10) not null,
	code char(15) not null,
	NameT nvarchar(50) not null,
	Midterm float not null,
	Finalterm float not null,
	Bonus float not null,
	total float not null,
	Class char(15) not null,
);

create table LoginForm
(
	userL char(10) not null,
	pass char(20) not null,
);

