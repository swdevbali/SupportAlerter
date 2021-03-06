-- MySQL dump 10.13  Distrib 5.5.27, for Win32 (x86)
--
-- Host: localhost    Database: email2sms
-- ------------------------------------------------------
-- Server version	5.5.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `name` varchar(255) NOT NULL,
  `server` varchar(45) DEFAULT NULL,
  `port` int(11) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `use_ssl` tinyint(1) DEFAULT NULL,
  `active` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES ('eko.wibowo@fikr-malaysia.com','pop.gmail.com',995,'eko.wibowo@fikr-malaysia.com','HGtKxT7czTHzcRtjh9ybyw==',0,0),('support-pv@datasam.com.au','pop.gmail.com',995,'support-pv@datasam.com.au','PYsp5cv2Khc/HaIupliAqw==',1,1);
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `configuration`
--

DROP TABLE IF EXISTS `configuration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `configuration` (
  `idconfiguration` int(11) NOT NULL AUTO_INCREMENT,
  `phone_notify` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idconfiguration`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `configuration`
--

LOCK TABLES `configuration` WRITE;
/*!40000 ALTER TABLE `configuration` DISABLE KEYS */;
INSERT INTO `configuration` VALUES (1,'0812221975');
/*!40000 ALTER TABLE `configuration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inbox`
--

DROP TABLE IF EXISTS `inbox`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inbox` (
  `idinbox` int(11) NOT NULL AUTO_INCREMENT,
  `account_name` varchar(255) DEFAULT NULL,
  `sender` varchar(255) DEFAULT NULL,
  `subject` varchar(255) DEFAULT NULL,
  `body` text,
  `date` varchar(255) DEFAULT NULL,
  `handled` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idinbox`)
) ENGINE=InnoDB AUTO_INCREMENT=447 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inbox`
--

LOCK TABLES `inbox` WRITE;
/*!40000 ALTER TABLE `inbox` DISABLE KEYS */;
/*!40000 ALTER TABLE `inbox` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log`
--

DROP TABLE IF EXISTS `log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `log` (
  `idlog` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `message` text NOT NULL,
  `occur` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `account_name` varchar(255) CHARACTER SET latin1 DEFAULT NULL,
  PRIMARY KEY (`idlog`),
  KEY `FK_log_1` (`account_name`),
  CONSTRAINT `FK_log_1` FOREIGN KEY (`account_name`) REFERENCES `account` (`name`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=90424 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log`
--

LOCK TABLES `log` WRITE;
/*!40000 ALTER TABLE `log` DISABLE KEYS */;
/*!40000 ALTER TABLE `log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rule`
--

DROP TABLE IF EXISTS `rule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rule` (
  `name` varchar(255) NOT NULL,
  `contains` varchar(255) DEFAULT NULL,
  `send_sms` tinyint(1) DEFAULT NULL,
  `voice_call` tinyint(1) DEFAULT NULL,
  `use_body` tinyint(1) DEFAULT '1',
  `use_subject` tinyint(1) DEFAULT '0',
  `use_sender` tinyint(1) DEFAULT '0',
  `subject_contains` varchar(255) DEFAULT NULL,
  `sender_contains` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rule`
--

LOCK TABLES `rule` WRITE;
/*!40000 ALTER TABLE `rule` DISABLE KEYS */;
INSERT INTO `rule` VALUES ('Severity=Critical','Severity=Critical',1,1,1,0,0,' ',' '),('Severity=Warning','Severity=Warning',1,0,1,0,0,' ',' ');
/*!40000 ALTER TABLE `rule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `send_sms`
--

DROP TABLE IF EXISTS `send_sms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `send_sms` (
  `idsend_sms` int(11) NOT NULL AUTO_INCREMENT,
  `idinbox` int(11) DEFAULT NULL,
  `content` text,
  `status` varchar(255) DEFAULT NULL,
  `account_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idsend_sms`),
  KEY `fk1_idx` (`idinbox`),
  KEY `FK_send_sms_21` (`account_name`),
  CONSTRAINT `fk1` FOREIGN KEY (`idinbox`) REFERENCES `inbox` (`idinbox`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_send_sms_21` FOREIGN KEY (`account_name`) REFERENCES `account` (`name`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `send_sms`
--

LOCK TABLES `send_sms` WRITE;
/*!40000 ALTER TABLE `send_sms` DISABLE KEYS */;
/*!40000 ALTER TABLE `send_sms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `voice_call`
--

DROP TABLE IF EXISTS `voice_call`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `voice_call` (
  `idvoice_call` int(11) NOT NULL AUTO_INCREMENT,
  `idinbox` int(11) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `account_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idvoice_call`),
  KEY `pk2_idx` (`idinbox`),
  KEY `FK_voice_call_2` (`account_name`),
  CONSTRAINT `FK_voice_call_2` FOREIGN KEY (`account_name`) REFERENCES `account` (`name`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `pk2` FOREIGN KEY (`idinbox`) REFERENCES `inbox` (`idinbox`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `voice_call`
--

LOCK TABLES `voice_call` WRITE;
/*!40000 ALTER TABLE `voice_call` DISABLE KEYS */;
/*!40000 ALTER TABLE `voice_call` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-04-05 23:11:24
