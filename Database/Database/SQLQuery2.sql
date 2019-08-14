CREATE DATABASE University;
GO 
USE University;

CREATE TABLE Class
(
	STT int IDENTITY,
	ID nvarchar(10) NOT NULL PRIMARY KEY,
	NameC nvarChar(50) NOT NULL,
	Sex CHAR(6) NOT NULL CHECK (Sex = 'Male' OR Sex = 'Female'),
	SSN char(15),
	Class char(10) not null,
);

CREATE TABLE Courses
(
	STT int IDENTITY,
	Code nvarchar(15) NOT NULL PRIMARY KEY,
	NameC Char(50) NOT NULL,
	Sex CHAR(1) NOT NULL CHECK (Sex = 'Male' OR Sex = 'Female'),
	SSN char(15),
	
);

insert into Class values ('1742002', 'Nguyen Van A','Male','123456789','17HCB');

select distinct Class.Class  from Class