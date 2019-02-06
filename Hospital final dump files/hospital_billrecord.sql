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
-- Table structure for table `billrecord`
--

DROP TABLE IF EXISTS `billrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `billrecord` (
  `Sn` int(11) NOT NULL AUTO_INCREMENT,
  `BillNo` varchar(45) DEFAULT NULL,
  `PatientID` varchar(45) DEFAULT NULL,
  `Particulars` varchar(45) DEFAULT NULL,
  `Charge` varchar(45) DEFAULT NULL,
  `RecordedOn` varchar(45) DEFAULT NULL,
  `RecordedBy` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Sn`),
  UNIQUE KEY `BillNo_UNIQUE` (`Sn`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `billrecord`
--

LOCK TABLES `billrecord` WRITE;
/*!40000 ALTER TABLE `billrecord` DISABLE KEYS */;
INSERT INTO `billrecord` VALUES (1,'1','10','Appointment Charge','525','2018-07-28','vj'),(4,'2','11','Ward Procedures','0','2018-07-29','vj'),(5,'2','11','Surgeon Fee','50000','2018-07-29','vj'),(6,'2','11','Room Charge','30000','2018-07-29','vj'),(7,'2','11','Pathology Charge','0','2018-07-29','vj'),(8,'2','11','Miscellaneous','2000','2018-07-29','vj'),(9,'2','11','Medicine','10000','2018-07-29','vj'),(10,'2','11','Facility Fee','0','2018-07-29','vj'),(11,'2','11','Doctor Fee','10000','2018-07-29','vj'),(12,'2','11','Anaesthetist Fee','0','2018-07-29','vj'),(13,'3','14','Ward Procedures','0','2018-08-02','suman'),(14,'3','14','Surgeon Fee','2000','2018-08-02','suman'),(15,'3','14','Room Charge','60000','2018-08-02','suman'),(16,'3','14','Pathology Charge','30000','2018-08-02','suman'),(17,'3','14','Miscellaneous','0','2018-08-02','suman'),(18,'3','14','Medicine','25000','2018-08-02','suman'),(19,'3','14','Facility Fee','0','2018-08-02','suman'),(20,'3','14','Doctor Fee','200','2018-08-02','suman'),(21,'3','14','Anaesthetist Fee','20000','2018-08-02','suman');
/*!40000 ALTER TABLE `billrecord` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-05 18:39:49
