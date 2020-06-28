CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `coach` (
    `CoachId` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(45) NULL,
    `PhoneNo` bigint NULL,
    `Email` varchar(30) NULL,
    CONSTRAINT `PK_coach` PRIMARY KEY (`CoachId`)
);

CREATE TABLE `course` (
    `CourseId` int NOT NULL AUTO_INCREMENT,
    `Title` longtext CHARACTER SET utf8mb4 NULL,
    `Cost` int NOT NULL,
    `ClassHour` int NOT NULL,
    CONSTRAINT `PK_course` PRIMARY KEY (`CourseId`)
);

CREATE TABLE `member` (
    `MemberId` int NOT NULL AUTO_INCREMENT,
    `PhoneNo` bigint NULL,
    `Name` varchar(45) NULL,
    CONSTRAINT `PK_member` PRIMARY KEY (`MemberId`)
);

CREATE TABLE `user` (
    `Userid` varchar(30) NOT NULL,
    `UserName` varchar(30) NULL,
    `Password` varchar(100) NOT NULL,
    `CreateTime` date NULL,
    CONSTRAINT `PK_user` PRIMARY KEY (`Userid`)
);

CREATE TABLE `section` (
    `SectionId` int NOT NULL AUTO_INCREMENT,
    `CourseId` int NULL,
    `StartDate` date NULL,
    `EndDate` date NULL,
    CONSTRAINT `PK_section` PRIMARY KEY (`SectionId`),
    CONSTRAINT `FK_section_course_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `course` (`CourseId`) ON DELETE RESTRICT
);

CREATE TABLE `instructs` (
    `MemberId` int NOT NULL,
    `CoachId` int NOT NULL,
    `AttendedHours` int NOT NULL,
    `TotalHours` int NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`MemberId`, `CoachId`),
    CONSTRAINT `FK_instructs_coach_CoachId` FOREIGN KEY (`CoachId`) REFERENCES `coach` (`CoachId`) ON DELETE RESTRICT,
    CONSTRAINT `FK_instructs_member_MemberId` FOREIGN KEY (`MemberId`) REFERENCES `member` (`MemberId`) ON DELETE RESTRICT
);

CREATE INDEX `instruct_CoachID_idx` ON `instructs` (`CoachId`);

CREATE INDEX `section_CourseID_idx` ON `section` (`CourseId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200611011234_init', '3.1.5');

ALTER TABLE `user` MODIFY COLUMN `Userid` bigint NOT NULL AUTO_INCREMENT;

ALTER TABLE `user` ADD `Role` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200613070211_v2', '3.1.5');

CREATE TABLE `take` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `SectionId` int NOT NULL,
    `MemberId` int NOT NULL,
    CONSTRAINT `PK_take` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200613150228_take', '3.1.5');

DROP TABLE `take`;

CREATE TABLE `takes` (
    `SectionId` int NOT NULL,
    `MemberId` int NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`MemberId`, `SectionId`),
    CONSTRAINT `FK_takes_member_MemberId` FOREIGN KEY (`MemberId`) REFERENCES `member` (`MemberId`) ON DELETE RESTRICT,
    CONSTRAINT `FK_takes_section_SectionId` FOREIGN KEY (`SectionId`) REFERENCES `section` (`SectionId`) ON DELETE RESTRICT
);

CREATE INDEX `IX_takes_SectionId` ON `takes` (`SectionId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200615124212_v3', '3.1.5');

ALTER TABLE `section` ADD `CoachId` int NOT NULL DEFAULT 0;

ALTER TABLE `section` ADD CONSTRAINT `FK_section_coach_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `coach` (`CoachId`) ON DELETE RESTRICT;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200617123702_v4', '3.1.5');

ALTER TABLE `coach` ADD `State` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200617172708_v5', '3.1.5');

ALTER TABLE `user` MODIFY COLUMN `UserName` varchar(30) NOT NULL;

ALTER TABLE `section` MODIFY COLUMN `StartDate` DATETIME NULL;

ALTER TABLE `section` MODIFY COLUMN `EndDate` DATETIME NULL;

ALTER TABLE `course` MODIFY COLUMN `Title` varchar(45) NULL;

CREATE TABLE `coursearrangement` (
    `CourseId` int NOT NULL,
    `CourseNo` int NOT NULL,
    `CoachId` int NOT NULL,
    `StartTime` datetime NOT NULL,
    `EndTime` datetime NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`CourseId`, `CourseNo`),
    CONSTRAINT `FK_coursearrangement_coach_CoachId` FOREIGN KEY (`CoachId`) REFERENCES `coach` (`CoachId`) ON DELETE CASCADE,
    CONSTRAINT `FK_coursearrangement_course_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `course` (`CourseId`) ON DELETE CASCADE
);

CREATE INDEX `IX_coursearrangement_CoachId` ON `coursearrangement` (`CoachId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200622023720_v6', '3.1.5');

DROP TABLE `coursearrangement`;

ALTER TABLE `section` DROP COLUMN `EndDate`;

ALTER TABLE `section` DROP COLUMN `StartDate`;

CREATE TABLE `Lesson` (
    `SectionId` int NOT NULL,
    `LessonNo` int NOT NULL,
    `CoachId` int NOT NULL,
    `StartDate` DATETIME NULL,
    `EndDate` DATETIME NULL,
    `State` int NOT NULL,
    CONSTRAINT `PK_Lesson` PRIMARY KEY (`SectionId`, `LessonNo`),
    CONSTRAINT `FK_Lesson_course_CoachId` FOREIGN KEY (`CoachId`) REFERENCES `course` (`CourseId`) ON DELETE CASCADE,
    CONSTRAINT `FK_Lesson_section_SectionId` FOREIGN KEY (`SectionId`) REFERENCES `section` (`SectionId`) ON DELETE CASCADE
);

CREATE INDEX `IX_Lesson_CoachId` ON `Lesson` (`CoachId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200623143928_v7', '3.1.5');

ALTER TABLE `Lesson` DROP FOREIGN KEY `FK_Lesson_course_CoachId`;

ALTER TABLE `Lesson` ADD CONSTRAINT `FK_Lesson_coach_CoachId` FOREIGN KEY (`CoachId`) REFERENCES `coach` (`CoachId`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200623164136_v8', '3.1.5');

ALTER TABLE `user` MODIFY COLUMN `CreateTime` datetime NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200625011507_v9', '3.1.5');

ALTER TABLE `coach` MODIFY COLUMN `PhoneNo` varchar(20) NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200626081418_v10', '3.1.5');

ALTER TABLE `user` ADD `Number` int NOT NULL DEFAULT 0;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200626171258_v11', '3.1.5');

ALTER TABLE `user` RENAME COLUMN `Userid` TO `UserId`;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200627072647_v12', '3.1.5');

ALTER TABLE `member` MODIFY COLUMN `PhoneNo` varchar(20) NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200627084309_v13', '3.1.5');

