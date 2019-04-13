CREATE DATABASE MVCTutorial
GO
USE MVCTutorial
GO

CREATE TABLE Employee
(
	EmployeeID		INT IDENTITY PRIMARY KEY	NOT NULL,
	FirstName		NVARCHAR(30)				NOT NULL,
	LastName		NVARCHAR(30)				NOT NULL,
	Email			NVARCHAR(50)					NULL,
	Telephone		NVARCHAR(20)					NULL,
	IsDeleted		BIT							NOT NULL,
	CompanyID		INT							NOT NULL
);

CREATE TABLE Company
(
	CompanyID		INT IDENTITY PRIMARY KEY	NOT NULL,
	Name			NVARCHAR(50)				NOT NULL
);
GO
ALTER TABLE Employee ADD CONSTRAINT FK_Employee_CompanyID FOREIGN KEY (CompanyID) REFERENCES Company(CompanyID)
GO
INSERT INTO Company (Name) VALUES ('Bitel')
INSERT INTO Company (Name) VALUES ('Sitel')
INSERT INTO Company (Name) VALUES ('Teles')
INSERT INTO Company (Name) VALUES ('Telefonica')
INSERT INTO Company (Name) VALUES ('Vodafone')
GO
INSERT INTO Employee (FirstName, LastName, Email, Telephone, IsDeleted, CompanyID) VALUES ('Michael', 'Denver', 'Michael.Denver@bitel.com', '078598568', 0, 1)
INSERT INTO Employee (FirstName, LastName, Email, Telephone, IsDeleted, CompanyID) VALUES ('Jack', 'Pablo', 'Jack.Pablo@sitel.com', '078598568', 0, 1)
INSERT INTO Employee (FirstName, LastName, Email, Telephone, IsDeleted, CompanyID) VALUES ('Gina', 'Field', 'Gina.Field@teles.com', '078598568', 0, 1)
INSERT INTO Employee (FirstName, LastName, Email, Telephone, IsDeleted, CompanyID) VALUES ('Anne', 'Martins', 'Anne.Martins@telefonica.com', '078598568', 0, 1)
INSERT INTO Employee (FirstName, LastName, Email, Telephone, IsDeleted, CompanyID) VALUES ('John', 'Davis', 'John.Davis@vodafone.com', '078598568', 0, 1)



-- Drop two tables that are related

--alter table Employee drop constraint FK_Employee_CompanyID
--drop table Employee
--drop table Company