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
	NameT nvarchar(50) not null,
	Midterm float not null,
	Finalterm float not null,
	Bonus float not null,
	total float not null,
);

ALTER TABLE Schedule ADD Constraint FK__Schedule__Class__05F8DC4F FOREIGN KEY (Class) REFERENCES Class(Class);
ALTER TABLE Transript ADD FOREIGN KEY (ID) REFERENCES Class(ID);

insert into Class values ('1742002', 'Nguyen Van A','Male','123456789','17HCB');
insert into Schedule values ('CTT013', 'Lap trinh','C23','17HCB');
select distinct Class.Class  from Class
select distinct Schedule.Class  from Schedule

select Class.STT,Class.ID,Class.NameC,Class.Sex,Class.SSN from Class,Schedule where Class.Class=Schedule.Class;

use master
drop database University;

