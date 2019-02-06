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
-- Table structure for table `ipbilling`
--

DROP TABLE IF EXISTS `ipbilling`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ipbilling` (
  `sn` int(11) NOT NULL AUTO_INCREMENT,
  `patientid` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `gender` varchar(45) DEFAULT NULL,
  `age` varchar(45) DEFAULT NULL,
  `admitteddate` varchar(45) DEFAULT NULL,
  `dischargedate` varchar(45) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  `roomcharge` varchar(45) DEFAULT NULL,
  `doctorfee` varchar(45) DEFAULT NULL,
  `medicine` varchar(45) DEFAULT NULL,
  `pathologycharge` varchar(45) DEFAULT NULL,
  `miscellaneous` varchar(45) DEFAULT NULL,
  `total` varchar(45) DEFAULT NULL,
  `billingdoneby` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`sn`)
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ipbilling`
--

LOCK TABLES `ipbilling` WRITE;
/*!40000 ALTER TABLE `ipbilling` DISABLE KEYS */;
INSERT INTO `ipbilling` VALUES (1,'3','bv','Male','10','2018-01-05','2018-01-08','2018-01-08','10','20','30','40','50','150','vj'),(3,'3','bv','Male','10','2018-01-05','2018-01-08','2018-01-08','10','10','10','10','10','50','vj'),(4,'2','qw','Male','19','2018-01-05','2018-01-08','2018-01-08','10','20','30','40','50','150','vj'),(5,'101','Ramjane','Male','20','05/01/2018','2018-01-08','2018-01-08','10','20','30','10','10','80','vj'),(100,'104','John Ak','Male','14','2018-01-10','2018-01-10','2018-01-10','40','50','40','50','10','190','vj'),(101,'91','Hari','Male','5','2018-01-10','2018-01-10','2018-01-10','10','10','10','10','10','50','vj'),(102,'107','vj','Male','21','2018-01-18','2018-01-21','2018-01-21','100','10','0','0','0','110','vj'),(103,'117','Harry','Male','20','2018-01-24','2018-01-24','2018-01-24','1000','200','1000','200','5000','7400','vj'),(104,'112','john','Male','24','2018-01-24','2018-01-24','2018-01-24','0','0','0','0','0','0','vj'),(105,'117','Harry','Male','20','2018-01-24','2018-02-02','2018-02-02','1000','100','5000','2000','2000','10100','vj');
/*!40000 ALTER TABLE `ipbilling` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-08-05 18:39:54
