create database if not exists stomatology;

use stomatology;

CREATE TABLE IF NOT EXISTS PatientCat (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    name VARCHAR(50) NOT NULL,
    sale FLOAT(5 , 2 ) NOT NULL DEFAULT 0,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS Firm (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    name VARCHAR(50) NOT NULL,
    code VARCHAR(20) NOT NULL,
    isPatientPublic BOOL NOT NULL DEFAULT FALSE,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS Doctor (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    fullName VARCHAR(50) NOT NULL,
    firmId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (firmId)
        REFERENCES Firm (id)
);

CREATE TABLE IF NOT EXISTS Bank (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    splitAccount VARCHAR(20) NOT NULL,
    name VARCHAR(50) NOT NULL,
    mfo VARCHAR(50) NOT NULL,
    dayCash VARCHAR(20) NOT NULL,
    eveningCash VARCHAR(20),
    person VARCHAR(100) NOT NULL,
    firmId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (firmId)
        REFERENCES Firm (id)
);

CREATE TABLE IF NOT EXISTS Patient (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    medicalCard VARCHAR(100) NOT NULL,
    dateOfRegistration DATE NOT NULL,
    fullName VARCHAR(100) NOT NULL,
    patientCatId INT NOT NULL,
    phoneNumberId INT,
    firmId INT NOT NULL,
    adress VARCHAR(100),
    sale FLOAT(5 , 2 ) NOT NULL DEFAULT 0,
    remark VARCHAR(200),
    contraindications VARCHAR(200),
    iconPath VARCHAR(1000),
    isPublic BOOL NOT NULL DEFAULT FALSE,
    PRIMARY KEY (id),
    FOREIGN KEY (patientCatId)
        REFERENCES PatientCat (id),
    FOREIGN KEY (firmId)
        REFERENCES Firm (id)
);

CREATE TABLE IF NOT EXISTS PhoneNumber (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    phone VARCHAR(13) NOT NULL,
    patientId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (patientId)
        REFERENCES Patient (id)
);

CREATE TABLE IF NOT EXISTS Photo (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    photoPath VARCHAR(1000) NOT NULL,
    patientId INT NOT NULL,
    remark VARCHAR(200),
    PRIMARY KEY (id),
    FOREIGN KEY (patientId)
        REFERENCES Patient (id)
);

CREATE TABLE IF NOT EXISTS Cash (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    patientId INT NOT NULL,
    firmId INT NOT NULL,
    date DATE NOT NULL,
    value FLOAT(10 , 2 ),
    remark VARCHAR(200),
    PRIMARY KEY (id),
    FOREIGN KEY (patientId)
        REFERENCES Patient (id),
    FOREIGN KEY (firmId)
        REFERENCES Firm (id)
);

CREATE TABLE IF NOT EXISTS Paragraph (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    name VARCHAR(100) NOT NULL,
    printable BOOLEAN DEFAULT TRUE,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS Manipulation (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    name VARCHAR(50) NOT NULL,
    price FLOAT(10 , 2 ) NOT NULL,
    paragraphId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (paragraphId)
        REFERENCES Paragraph (id)
);

CREATE TABLE IF NOT EXISTS Matherial (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    name VARCHAR(50) NOT NULL,
    type CHAR(11) NOT NULL,
    date DATE NOT NULL,
    number INT NOT NULL,
    pricePerOne FLOAT(10 , 2 ),
    summ FLOAT(20 , 2 ),
    manipulationId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (manipulationId)
        REFERENCES Manipulation (id)
);

CREATE TABLE IF NOT EXISTS VisitCategory (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    name VARCHAR(50) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS Visit (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    firmId INT NOT NULL,
    patientId INT NOT NULL,
    doctorId INT NOT NULL,
    date DATE NOT NULL,
    diagnosis VARCHAR(1000) NOT NULL,
    terapy VARCHAR(1000) NOT NULL,
    sale FLOAT(5 , 2 ) DEFAULT 0,
    visitCategoryId INT NOT NULL,
    summ FLOAT(10 , 2 ) NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (visitCategoryId)
        REFERENCES visitCategory (id),
    FOREIGN KEY (firmId)
        REFERENCES Firm (id),
    FOREIGN KEY (patientId)
        REFERENCES Patient (id),
    FOREIGN KEY (doctorId)
        REFERENCES Doctor (id)
);

CREATE TABLE IF NOT EXISTS Operation (
    id INT NOT NULL AUTO_INCREMENT UNIQUE,
    visitId INT NOT NULL,
    manipulationId INT NOT NULL,
    number INT UNSIGNED DEFAULT 1,
    sale FLOAT(5 , 2 ) DEFAULT 0,
    summ FLOAT(10 , 2 ) NOT NULL,
    isMade BOOLEAN DEFAULT FALSE,
    PRIMARY KEY (id),
    FOREIGN KEY (visitId)
        REFERENCES Visit (id),
    FOREIGN KEY (manipulationId)
        REFERENCES Manipulation (id)
);