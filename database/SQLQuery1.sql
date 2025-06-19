-- Create Database
CREATE DATABASE StudentEventsDB;
GO

USE StudentEventsDB;
GO

-- Create Students Table
CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);
GO

-- Create Events Table
CREATE TABLE Events (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Venue NVARCHAR(100) NOT NULL,
    Date DATETIME NOT NULL
);
GO

-- Create Registrations Table (Many-to-Many)
CREATE TABLE Registrations (
    StudentId INT NOT NULL,
    EventId INT NOT NULL,
    PRIMARY KEY (StudentId, EventId),
    FOREIGN KEY (StudentId) REFERENCES Students(Id) ON DELETE CASCADE,
    FOREIGN KEY (EventId) REFERENCES Events(Id) ON DELETE CASCADE
);
GO

-- Create Feedback Table
CREATE TABLE Feedbacks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    EventId INT NOT NULL,
    Rating INT NOT NULL,
    Comment NVARCHAR(MAX) NOT NULL,
    SubmittedOn DATETIME NOT NULL,
    FOREIGN KEY (EventId) REFERENCES Events(Id) ON DELETE CASCADE
);
GO
