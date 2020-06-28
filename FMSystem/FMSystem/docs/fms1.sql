-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: fms
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20200611011234_init','3.1.5'),('20200613070211_v2','3.1.5'),('20200613150228_take','3.1.5'),('20200615124212_v3','3.1.5'),('20200617123702_v4','3.1.5'),('20200617172708_v5','3.1.5'),('20200622023720_v6','3.1.5'),('20200623143928_v7','3.1.5'),('20200623164136_v8','3.1.5'),('20200625011507_v9','3.1.5'),('20200626081418_v10','3.1.5'),('20200626171258_v11','3.1.5'),('20200627072647_v12','3.1.5'),('20200627084309_v13','3.1.5');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `coach`
--

DROP TABLE IF EXISTS `coach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `coach` (
  `CoachId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `PhoneNo` varchar(20) DEFAULT NULL,
  `Email` varchar(30) DEFAULT NULL,
  `State` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`CoachId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coach`
--

LOCK TABLES `coach` WRITE;
/*!40000 ALTER TABLE `coach` DISABLE KEYS */;
INSERT INTO `coach` VALUES (1,'刘能','13060648195','1506493779@qq.com',0),(2,'玛里苟斯','13535507207','2506493779@qq.com',0),(3,'马睿','23535507207','3506493779@qq.com',0),(4,'赵三','33535507207','4506493779@qq.com',0),(5,'李四','43535507207','5506493779@qq.com',1);
/*!40000 ALTER TABLE `coach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `course` (
  `CourseId` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) DEFAULT NULL,
  `Cost` int NOT NULL,
  `ClassHour` int NOT NULL,
  PRIMARY KEY (`CourseId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course`
--

LOCK TABLES `course` WRITE;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
INSERT INTO `course` VALUES (1,'减肥',1000,10),(2,'打架',2400,8),(3,'长时间打架',4000,16),(4,'增肌',1000,10);
/*!40000 ALTER TABLE `course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instructs`
--

DROP TABLE IF EXISTS `instructs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instructs` (
  `MemberId` int NOT NULL,
  `CoachId` int NOT NULL,
  `AttendedHours` int NOT NULL,
  `TotalHours` int NOT NULL,
  PRIMARY KEY (`MemberId`,`CoachId`),
  KEY `instruct_CoachID_idx` (`CoachId`),
  CONSTRAINT `FK_instructs_coach_CoachId` FOREIGN KEY (`CoachId`) REFERENCES `coach` (`CoachId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_instructs_member_MemberId` FOREIGN KEY (`MemberId`) REFERENCES `member` (`MemberId`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instructs`
--

LOCK TABLES `instructs` WRITE;
/*!40000 ALTER TABLE `instructs` DISABLE KEYS */;
INSERT INTO `instructs` VALUES (1,1,7,10),(2,1,4,7),(3,1,10,40),(4,1,4,9),(5,2,6,10),(6,2,2,4),(7,1,8,17);
/*!40000 ALTER TABLE `instructs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lesson`
--

DROP TABLE IF EXISTS `lesson`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lesson` (
  `SectionId` int NOT NULL,
  `LessonNo` int NOT NULL,
  `CoachId` int NOT NULL,
  `StartDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `State` int NOT NULL,
  PRIMARY KEY (`SectionId`,`LessonNo`),
  KEY `IX_Lesson_CoachId` (`CoachId`),
  CONSTRAINT `FK_Lesson_coach_CoachId` FOREIGN KEY (`CoachId`) REFERENCES `coach` (`CoachId`) ON DELETE CASCADE,
  CONSTRAINT `FK_Lesson_section_SectionId` FOREIGN KEY (`SectionId`) REFERENCES `section` (`SectionId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lesson`
--

LOCK TABLES `lesson` WRITE;
/*!40000 ALTER TABLE `lesson` DISABLE KEYS */;
INSERT INTO `lesson` VALUES (3,1,1,'2020-06-30 07:00:00','2020-06-30 10:00:00',0);
/*!40000 ALTER TABLE `lesson` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `member`
--

DROP TABLE IF EXISTS `member`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `member` (
  `MemberId` int NOT NULL AUTO_INCREMENT,
  `PhoneNo` varchar(20) DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`MemberId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `member`
--

LOCK TABLES `member` WRITE;
/*!40000 ALTER TABLE `member` DISABLE KEYS */;
INSERT INTO `member` VALUES (1,'13060648191','柳依依'),(2,'13060648192','柳尔尔'),(3,'13060648193','柳散散'),(4,'13060648194','柳打打'),(5,'13060648195','柳柳柳'),(6,'13060648196','柳六六'),(7,'13060648197','柳耶耶');
/*!40000 ALTER TABLE `member` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `section`
--

DROP TABLE IF EXISTS `section`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `section` (
  `SectionId` int NOT NULL AUTO_INCREMENT,
  `CourseId` int DEFAULT NULL,
  `CoachId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`SectionId`),
  KEY `section_CourseID_idx` (`CourseId`),
  CONSTRAINT `FK_section_coach_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `coach` (`CoachId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_section_course_CourseId` FOREIGN KEY (`CourseId`) REFERENCES `course` (`CourseId`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `section`
--

LOCK TABLES `section` WRITE;
/*!40000 ALTER TABLE `section` DISABLE KEYS */;
INSERT INTO `section` VALUES (1,1,1),(2,1,2),(3,2,1),(4,2,2),(5,2,3),(6,3,1),(7,3,3),(8,4,1),(9,4,4),(10,4,5);
/*!40000 ALTER TABLE `section` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `takes`
--

DROP TABLE IF EXISTS `takes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `takes` (
  `SectionId` int NOT NULL,
  `MemberId` int NOT NULL,
  PRIMARY KEY (`MemberId`,`SectionId`),
  KEY `IX_takes_SectionId` (`SectionId`),
  CONSTRAINT `FK_takes_member_MemberId` FOREIGN KEY (`MemberId`) REFERENCES `member` (`MemberId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_takes_section_SectionId` FOREIGN KEY (`SectionId`) REFERENCES `section` (`SectionId`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `takes`
--

LOCK TABLES `takes` WRITE;
/*!40000 ALTER TABLE `takes` DISABLE KEYS */;
INSERT INTO `takes` VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(2,1),(2,3),(2,4),(2,7),(3,1),(3,2),(3,3),(4,1),(5,2),(5,6),(5,7),(6,3),(7,4),(7,5),(8,5),(9,3),(9,4),(9,6),(10,7);
/*!40000 ALTER TABLE `takes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `UserId` bigint NOT NULL AUTO_INCREMENT,
  `UserName` varchar(30) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `CreateTime` datetime DEFAULT NULL,
  `Role` int NOT NULL DEFAULT '0',
  `Number` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'root','123456','2020-06-25 08:43:27',0,1),(2,'admin','123456','2020-06-25 08:43:27',1,1),(3,'liuneng','123456','2020-06-25 08:43:27',2,1),(4,'maligousi','123456','2020-06-25 08:43:27',2,2),(5,'marui','123456','2020-06-25 08:43:27',2,3),(6,'zhaosan','123456','2020-06-25 08:43:27',2,4),(7,'lisi','123456','2020-06-25 08:43:27',2,5),(8,'dagongzai','123456','2020-06-25 08:43:27',3,1),(9,'vip','123456','2020-06-25 08:43:27',4,1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-28  9:13:49
