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
-- Table structure for table `tempcharge`
--

DROP TABLE IF EXISTS `tempcharge`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tempcharge` (
  `Sn` int(11) NOT NULL AUTO_INCREMENT,
  `PatientID` varchar(45) DEFAULT NULL,
  `Particulars` varchar(45) DEFAULT NULL,
  `Charges` varchar(45) NOT NULL DEFAULT '0',
  `RecordedOn` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Sn`),
  UNIQUE KEY `BillNo_UNIQUE` (`Sn`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tempcharge`
--

LOCK TABLES `tempcharge` WRITE;
/*!40000 ALTER TABLE `tempcharge` DISABLE KEYS */;
INSERT INTO `tempcharge` VALUES (29,'12','Medicine','20000','2018-07-30'),(30,'12','Doctor Fee','30000','2018-07-30'),(31,'12','Room Charge','2000','2018-07-30'),(32,'12','Facility Fee','','2018-07-30'),(33,'12','Surgeon Fee','50000','2018-07-30'),(34,'12','Anaesthetist Fee','','2018-07-30'),(35,'12','Ward Procedures','20000','2018-07-30'),(36,'12','Pathology Charge','','2018-07-30'),(37,'12','Miscellaneous','','2018-07-30'),(38,'12','Medicine','20000','2018-07-30'),(39,'12','Doctor Fee','','2018-07-30'),(40,'12','Room Charge','3000','2018-07-30'),(41,'12','Facility Fee','','2018-07-30'),(42,'12','Surgeon Fee','50000','2018-07-30'),(43,'12','Anaesthetist Fee','','2018-07-30'),(44,'12','Ward Procedures','','2018-07-30'),(45,'12','Pathology Charge','','2018-07-30'),(46,'12','Miscellaneous','','2018-07-30');
/*!40000 ALTER TABLE `tempcharge` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-05 18:39:51
