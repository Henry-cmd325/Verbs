-- --------------------------------------------------------
-- Host:                         localhost
-- Versión del servidor:         10.6.8-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para english
CREATE DATABASE IF NOT EXISTS `english` /*!40100 DEFAULT CHARACTER SET utf8mb3 */;
USE `english`;

-- Volcando estructura para tabla english.aprendizaje
CREATE TABLE IF NOT EXISTS `aprendizaje` (
  `cve_aprendizaje` int(11) NOT NULL,
  `cve_verbs` int(11) NOT NULL,
  `cve_usuarios` int(11) NOT NULL,
  PRIMARY KEY (`cve_aprendizaje`),
  KEY `FK__verbs` (`cve_verbs`),
  KEY `FK_aprendizaje_usuarios` (`cve_usuarios`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla english.aprendizaje: 0 rows
/*!40000 ALTER TABLE `aprendizaje` DISABLE KEYS */;
/*!40000 ALTER TABLE `aprendizaje` ENABLE KEYS */;

-- Volcando estructura para tabla english.audios
CREATE TABLE IF NOT EXISTS `audios` (
  `cve_audios` int(11) NOT NULL,
  `audio` blob NOT NULL,
  PRIMARY KEY (`cve_audios`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla english.audios: 0 rows
/*!40000 ALTER TABLE `audios` DISABLE KEYS */;
/*!40000 ALTER TABLE `audios` ENABLE KEYS */;

-- Volcando estructura para tabla english.imagenes
CREATE TABLE IF NOT EXISTS `imagenes` (
  `cve_imagenes` int(11) NOT NULL,
  `imagen` varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`cve_imagenes`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla english.imagenes: 0 rows
/*!40000 ALTER TABLE `imagenes` DISABLE KEYS */;
/*!40000 ALTER TABLE `imagenes` ENABLE KEYS */;

-- Volcando estructura para tabla english.rutas
CREATE TABLE IF NOT EXISTS `rutas` (
  `cve_rutas` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`cve_rutas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla english.rutas: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `rutas` DISABLE KEYS */;
/*!40000 ALTER TABLE `rutas` ENABLE KEYS */;

-- Volcando estructura para tabla english.tiempos_verbales
CREATE TABLE IF NOT EXISTS `tiempos_verbales` (
  `cve_tiempos_verbales` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`cve_tiempos_verbales`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla english.tiempos_verbales: 0 rows
/*!40000 ALTER TABLE `tiempos_verbales` DISABLE KEYS */;
/*!40000 ALTER TABLE `tiempos_verbales` ENABLE KEYS */;

-- Volcando estructura para tabla english.traducciones
CREATE TABLE IF NOT EXISTS `traducciones` (
  `cve_traducciones` int(11) NOT NULL,
  `cve_imagenes` int(11) NOT NULL,
  `traduccion` varchar(50) NOT NULL,
  PRIMARY KEY (`cve_traducciones`),
  KEY `FK__imagenes` (`cve_imagenes`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla english.traducciones: 0 rows
/*!40000 ALTER TABLE `traducciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `traducciones` ENABLE KEYS */;

-- Volcando estructura para tabla english.traducciones_verbs
CREATE TABLE IF NOT EXISTS `traducciones_verbs` (
  `cve_traducciones_verbs` int(11) NOT NULL,
  `cve_traducciones` int(11) NOT NULL,
  PRIMARY KEY (`cve_traducciones_verbs`),
  KEY `FK__traducciones` (`cve_traducciones`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla english.traducciones_verbs: 0 rows
/*!40000 ALTER TABLE `traducciones_verbs` DISABLE KEYS */;
/*!40000 ALTER TABLE `traducciones_verbs` ENABLE KEYS */;

-- Volcando estructura para tabla english.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `cve_usuarios` int(11) NOT NULL,
  `correo` varchar(120) NOT NULL,
  `contraseña` varchar(100) NOT NULL,
  PRIMARY KEY (`cve_usuarios`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla english.usuarios: 0 rows
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;

-- Volcando estructura para tabla english.verbs
CREATE TABLE IF NOT EXISTS `verbs` (
  `cve_verbs` int(11) NOT NULL,
  `cve_audios` int(11) NOT NULL,
  `cve_traducciones_verbs` int(11) NOT NULL,
  `nombre` varchar(120) NOT NULL,
  `aprendido` bit(1) NOT NULL,
  `phrasal_web` bit(1) NOT NULL,
  `regular` bit(1) NOT NULL,
  PRIMARY KEY (`cve_verbs`),
  KEY `FK__audios` (`cve_audios`),
  KEY `FK_verbs_traducciones_verbs` (`cve_traducciones_verbs`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla english.verbs: 0 rows
/*!40000 ALTER TABLE `verbs` DISABLE KEYS */;
/*!40000 ALTER TABLE `verbs` ENABLE KEYS */;

-- Volcando estructura para tabla english.verbs_tiempos
CREATE TABLE IF NOT EXISTS `verbs_tiempos` (
  `cve_verbs_tiempos` int(11) NOT NULL,
  `cve_verbs` int(11) NOT NULL,
  `cve_tiempos_verbales` int(11) NOT NULL,
  PRIMARY KEY (`cve_verbs_tiempos`),
  KEY `FK__verbs` (`cve_verbs`),
  KEY `FK__tiempos_verbales` (`cve_tiempos_verbales`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla english.verbs_tiempos: 0 rows
/*!40000 ALTER TABLE `verbs_tiempos` DISABLE KEYS */;
/*!40000 ALTER TABLE `verbs_tiempos` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
