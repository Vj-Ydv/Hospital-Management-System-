-- MySQL dump 10.13  Distrib 8.0.11, for Win64 (x86_64)
--
-- Host: localhost    Database: hospital
-- ------------------------------------------------------
-- Server version	8.0.11

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `patientinfo`
--

DROP TABLE IF EXISTS `patientinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `patientinfo` (
  `Sn` int(11) NOT NULL AUTO_INCREMENT,
  `PatientID` varchar(45) DEFAULT NULL,
  `Cases` varchar(45) DEFAULT NULL,
  `AppRoomNo` varchar(45) DEFAULT NULL,
  `AppWith` varchar(45) DEFAULT NULL,
  `TimeOfEntry` varchar(45) DEFAULT NULL,
  `DateOfEntry` varchar(45) DEFAULT NULL,
  `RecordedBy` varchar(45) DEFAULT NULL,
  `Type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Sn`),
  UNIQUE KEY `Sn_UNIQUE` (`Sn`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patientinfo`
--

LOCK TABLES `patientinfo` WRITE;
/*!40000 ALTER TABLE `patientinfo` DISABLE KEYS */;
INSERT INTO `patientinfo` VALUES (5,'10','Neurology','101','Dr. Govind KC','1:00 PM','2018-07-28','vj','OutPatient'),(6,'11','Cardiology','102','Ram Yadav','3:26 PM','2018-07-28','vj','InPatient'),(7,'11','Cardiology','102','Ram Yadav','1:45 PM','2017-05-25','suman','InPatient'),(8,'12','Cardiology','102','Ram Yadav','2:22 PM','2018-07-30','vj','InPatient'),(9,'13','Neurology','101','Dr. Govind KC','11:00:00 AM','2017-05-21','vj','InPatient'),(10,'12','Neurology','101','Dr. Govind KC','10:00:00 AM','2018-05-27','suman','InPatient'),(11,'14','Neurology','101','Dr. Govind KC','1:29:39 PM','2018-02-06','suman','InPatient'),(12,'15','Neurology','101','Dr. Govind KC','10:00:00 AM','2017-05-25','vj','OutPatient'),(14,'17','Cardiology','102','Dr.Ram Yadav','1:30:00 PM','2018-08-08','vj','OutPatient'),(15,'18','Neurology','101','Dr. Govind KC','10:00:00 AM','2018-08-05','vj','OutPatient');
/*!40000 ALTER TABLE `patientinfo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-05 18:39:47
