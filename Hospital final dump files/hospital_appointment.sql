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
-- Table structure for table `appointment`
--

DROP TABLE IF EXISTS `appointment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `appointment` (
  `sn` varchar(15) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `mobileno` varchar(15) DEFAULT NULL,
  `doctor` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  `appointmentdate` varchar(45) DEFAULT NULL,
  `appointmentFrom` varchar(45) DEFAULT NULL,
  `appointmentUpto` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`sn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `appointment`
--

LOCK TABLES `appointment` WRITE;
/*!40000 ALTER TABLE `appointment` DISABLE KEYS */;
INSERT INTO `appointment` VALUES ('10','hggf','7665','Dr.Ram Yadav','Cardiology','2017-07-28','2018-07-31','13:00','14:00'),('11','Ram','9874563210','Dr. Govind KC',NULL,'2018-08-05','2018-08-05',NULL,NULL),('2','harilal','9883','Ram Yadav','Cardiology','2018-06-10','2018-06-25','13:30','14:30'),('3','Hari Bahadur','786','Dr. Govind KC','Neurology','2018-07-11','2018-07-19','13:30','14:30'),('4','umar','9876345765','Dr. Govind KC','Neurology','2018-07-12','2018-07-15','12:40','12:42'),('5','ujjwal','9777674883','Dr.Ram Yadav','Cardiology','2018-08-08','2018-08-09','17:30','18:30'),('6','Madan Bahadur','9856799876','Dr. Govind KC','Neurology','2018-08-15','2018-08-17','12:30','13:30'),('7','Aanand Thakur','9857067845','Dr. Govind KC','Neurology','2018-08-24','2018-08-26','12:00','13:00'),('8','arishi','987654633','Dr. Govind KC','Neurology','2018-09-10','2018-09-12','12:00','13:00'),('9','gggg','656','Dr. Govind KC','Neurology','2018-09-25','2018-09-28','13:30','14:30');
/*!40000 ALTER TABLE `appointment` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-05 18:39:48
