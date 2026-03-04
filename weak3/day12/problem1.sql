CREATE DATABASE Event;
use Event;
CREATE table UserInfo(
    EmailId VARCHAR(50) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL
    CHECK (Role IN ('Admin', 'Participant')),
    Password VARCHAR(20) NOT NULL
     CHECK (LEN(Password) BETWEEN 6 AND 20)
);

CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(250) NULL,
    Status VARCHAR(20)
    CHECK (Status IN ('Active', 'In-Active'))
);

CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL
);

CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(250) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(200) NULL,
        FOREIGN KEY (EventId)
        REFERENCES EventDetails(EventId),
        FOREIGN KEY (SpeakerId)
        REFERENCES SpeakersDetails(SpeakerId),
        CHECK (SessionEnd > SessionStart)
);

CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(50) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT NOT NULL
        CHECK (IsAttended IN (0,1)),
        FOREIGN KEY (ParticipantEmailId)
        REFERENCES UserInfo(EmailId),
        FOREIGN KEY (EventId)
        REFERENCES EventDetails(EventId),
        FOREIGN KEY (SessionId)
        REFERENCES SessionInfo(SessionId)
);

INSERT INTO UserInfo VALUES
('admin@gmail.com', 'Murali', 'Admin', 'Admin@123'),
('rahul@gmail.com', 'Rahul', 'Participant', 'Rahul@123'),
('sneha@gmail.com', 'Sneha', 'Participant', 'Sneha@123');

SELECT * from UserInfo;

INSERT INTO EventDetails
VALUES
(1, 'Tech Summit 2026', 'Technology', '2026-04-10 09:00:00', 'Annual Tech Conference', 'Active'),
(2, 'AI Workshop', 'Artificial Intelligence', '2026-05-15 10:00:00', 'Hands-on AI Training', 'Active'),
(3, 'Business Meetup', 'Entrepreneurship', '2026-06-20 11:00:00', NULL, 'In-Active');

SELECT * FROM EventDetails;

INSERT INTO SpeakersDetails 
VALUES
(1, 'Dr. Ravi Kumar'),
(2, 'Anita Sharma'),
(3, 'Kiran Reddy');

SELECT * FROM SpeakersDetails;

INSERT INTO SessionInfo
VALUES
(1, 1, 'Future of Cloud', 1, 'Cloud Technology Trends',
 '2026-04-10 10:00:00',
 '2026-04-10 12:00:00',
 'https://meet.google.com/cloud'),
(2, 2, 'Introduction to AI', 2, 'Basics of Artificial Intelligence',
 '2026-05-15 11:00:00',
 '2026-05-15 13:00:00',
 'https://meet.google.com/ai');

 SELECT * FROM SessionInfo;

INSERT INTO ParticipantEventDetails
VALUES
(1, 'rahul@gmail.com', 1, 1, 1),
(2, 'sneha@gmail.com', 2, 2, 0);

SELECT * FROM ParticipantEventDetails;