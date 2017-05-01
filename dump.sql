CREATE DATABASE  IF NOT EXISTS `marguerite` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `marguerite`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: marguerite
-- ------------------------------------------------------
-- Server version	5.6.17

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
-- Table structure for table `indication_mdp`
--

DROP TABLE IF EXISTS `indication_mdp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `indication_mdp` (
  `id_indication` int(11) NOT NULL,
  `id_password` int(11) NOT NULL,
  `indication` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `indication_mdp`
--

LOCK TABLES `indication_mdp` WRITE;
/*!40000 ALTER TABLE `indication_mdp` DISABLE KEYS */;
INSERT INTO `indication_mdp` VALUES (1,1,'ami'),(2,1,'de'),(3,1,'l\'homme'),(4,2,'rond'),(5,2,'rebondit'),(6,2,'balle');
/*!40000 ALTER TABLE `indication_mdp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mots`
--

DROP TABLE IF EXISTS `mots`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mots` (
  `idMot` int(11) NOT NULL AUTO_INCREMENT,
  `contenuMot` varchar(50) NOT NULL,
  `nbPointsMot` int(11) NOT NULL,
  `idThemeMot` int(11) NOT NULL,
  `tempsMot` int(11) NOT NULL,
  PRIMARY KEY (`idMot`),
  KEY `FK_Mots_Themes` (`idThemeMot`),
  CONSTRAINT `FK_Mots_Themes` FOREIGN KEY (`idThemeMot`) REFERENCES `themes` (`idTheme`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mots`
--

LOCK TABLES `mots` WRITE;
/*!40000 ALTER TABLE `mots` DISABLE KEYS */;
INSERT INTO `mots` VALUES (1,'pomme',1,1,30),(9,'tennis',2,2,25),(10,'banane',1,1,30),(11,'orange',1,1,30),(12,'football',2,2,25),(13,'basket-ball',2,2,50);
/*!40000 ALTER TABLE `mots` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `password`
--

DROP TABLE IF EXISTS `password`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `password` (
  `id_password` int(11) NOT NULL AUTO_INCREMENT,
  `password` varchar(50) NOT NULL,
  PRIMARY KEY (`id_password`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `password`
--

LOCK TABLES `password` WRITE;
/*!40000 ALTER TABLE `password` DISABLE KEYS */;
INSERT INTO `password` VALUES (1,'chien'),(2,'ballon');
/*!40000 ALTER TABLE `password` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `themes`
--

DROP TABLE IF EXISTS `themes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `themes` (
  `idTheme` int(11) NOT NULL AUTO_INCREMENT,
  `nomTheme` varchar(50) NOT NULL,
  PRIMARY KEY (`idTheme`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `themes`
--

LOCK TABLES `themes` WRITE;
/*!40000 ALTER TABLE `themes` DISABLE KEYS */;
INSERT INTO `themes` VALUES (1,'Fruits'),(2,'Sports');
/*!40000 ALTER TABLE `themes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'marguerite'
--

--
-- Dumping routines for database 'marguerite'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-01 13:52:19
