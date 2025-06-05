-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.41 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.10.0.7000
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para admision
CREATE DATABASE IF NOT EXISTS `admision` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `admision`;

-- Volcando estructura para tabla admision.cumples
CREATE TABLE IF NOT EXISTS `cumples` (
  `id_cumples` int NOT NULL AUTO_INCREMENT,
  `id_sesion` int DEFAULT NULL,
  `id_socio` int DEFAULT NULL,
  `id_sede` int DEFAULT NULL,
  `fecha_crea_mod` datetime DEFAULT NULL,
  `anio` int DEFAULT NULL,
  PRIMARY KEY (`id_cumples`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.cumples: ~0 rows (aproximadamente)

-- Volcando estructura para tabla admision.demos
CREATE TABLE IF NOT EXISTS `demos` (
  `DemoId` int NOT NULL AUTO_INCREMENT,
  `Nombre` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Correo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`DemoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.demos: ~0 rows (aproximadamente)

-- Volcando estructura para tabla admision.establecimientos
CREATE TABLE IF NOT EXISTS `establecimientos` (
  `id_establecimiento` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY (`id_establecimiento`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla admision.establecimientos: ~0 rows (aproximadamente)
INSERT INTO `establecimientos` (`id_establecimiento`, `nombre`) VALUES
	(1, 'demo');

-- Volcando estructura para tabla admision.problematicos
CREATE TABLE IF NOT EXISTS `problematicos` (
  `id_problematicos` int NOT NULL AUTO_INCREMENT,
  `id_sede` int NOT NULL,
  `id_sesion` int NOT NULL,
  `regla` longtext,
  `conflictivo` tinyint(1) NOT NULL,
  `prohibida_entrada` tinyint(1) NOT NULL,
  `gobcan` tinyint(1) NOT NULL,
  `fecha_crea` datetime DEFAULT NULL,
  `id_socio` int DEFAULT NULL,
  `comentario` longtext,
  `visible` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_problematicos`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.problematicos: ~1 rows (aproximadamente)
INSERT INTO `problematicos` (`id_problematicos`, `id_sede`, `id_sesion`, `regla`, `conflictivo`, `prohibida_entrada`, `gobcan`, `fecha_crea`, `id_socio`, `comentario`, `visible`) VALUES
	(20, 1, 2, 'conflictivo', 0, 0, 1, '2025-06-04 14:30:57', 23, 'Extremadamente problematico', 1),
	(21, 1, 2, 'conflictivo', 0, 0, 1, '2025-06-05 10:48:44', 24, 'Extremadamente problematico', 1),
	(22, 1, 2, 'Regla de ejemplo', 0, 1, 0, '2025-06-05 10:48:52', 24, 'Comentario de pruebaA', 1),
	(24, 1, 2, 'Regla de ejemplo', 0, 1, 0, '2025-06-05 11:33:41', 24, 'Comentario de pruebaA', 1),
	(25, 1, 2, 'Regla de ejemplo', 0, 0, 1, '2025-06-05 11:33:45', 24, 'Comentario de pruebaA', 1),
	(26, 1, 2, 'Regla de ejemplo', 0, 1, 0, '2025-06-05 11:33:51', 24, 'Comentario de pruebaA', 1),
	(27, 1, 2, 'conflictivo', 1, 0, 0, '2025-06-05 11:33:55', 24, 'Extremadamente problematico', 1),
	(28, 1, 2, 'Regla de ejemplo', 1, 0, 0, '2025-06-05 12:21:15', 24, 'Comentario de pruebaA', 1),
	(29, 1, 2, 'Regla de ejemplo', 1, 0, 0, '2025-06-05 12:27:06', 24, 'Comentario de pruebaA', 1),
	(30, 1, 2, 'Regla de ejemplo', 1, 0, 0, '2025-06-05 12:27:24', 24, 'Comentario de pruebaA', 1),
	(31, 1, 2, 'Regla de ejemplo', 1, 0, 0, '2025-06-05 12:28:01', 24, 'Comentario de pruebaA', 1),
	(32, 1, 12, 'Regla de ejemplo', 1, 0, 0, '2025-06-05 13:11:33', 24, 'Comentario de pruebaA', 1),
	(33, 1, 12, 'Regla de ejemplo', 1, 0, 0, '2025-06-05 13:14:45', 24, 'Comentario de pruebaA', 1),
	(34, 1, 12, 'Regla de ejemplo', 1, 0, 0, '2025-06-05 13:51:43', 24, 'Comentario de pruebaA', 1);

-- Volcando estructura para tabla admision.prohibidos
CREATE TABLE IF NOT EXISTS `prohibidos` (
  `id_prohibido` int NOT NULL AUTO_INCREMENT,
  `dni` longtext,
  `pasaporte` longtext,
  `nombre` longtext,
  `apellidos` longtext,
  `motivos` longtext,
  `tipo` longtext,
  `ambito` longtext,
  `fecha_inicio` datetime DEFAULT NULL,
  `fecha_fin` datetime DEFAULT NULL,
  `fecha_revision` datetime DEFAULT NULL,
  PRIMARY KEY (`id_prohibido`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.prohibidos: ~0 rows (aproximadamente)

-- Volcando estructura para tabla admision.reglasconflictivos
CREATE TABLE IF NOT EXISTS `reglasconflictivos` (
  `id_regla` int NOT NULL AUTO_INCREMENT,
  `dni` longtext,
  `nombre` longtext,
  `apel1` longtext,
  `apel2` longtext,
  `fecha_nacimiento` datetime DEFAULT NULL,
  `id_municipio` int DEFAULT NULL,
  `id_provincia` int DEFAULT NULL,
  `comentario` longtext,
  `sexo` tinyint(1) DEFAULT NULL,
  `eliminada` tinyint(1) NOT NULL,
  `nombreMunicipio` longtext,
  `nombreProvincia` longtext,
  `nombreSexo` longtext,
  `Discriminator` varchar(128) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id_regla`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.reglasconflictivos: ~0 rows (aproximadamente)

-- Volcando estructura para tabla admision.roles
CREATE TABLE IF NOT EXISTS `roles` (
  `id_rol` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) CHARACTER SET latin1 COLLATE latin1_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`id_rol`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci ROW_FORMAT=COMPACT;

-- Volcando datos para la tabla admision.roles: ~3 rows (aproximadamente)
INSERT INTO `roles` (`id_rol`, `nombre`) VALUES
	(1, 'Administrador'),
	(2, 'Recepcionista'),
	(3, 'Tecnico');

-- Volcando estructura para tabla admision.sedes
CREATE TABLE IF NOT EXISTS `sedes` (
  `id_sede` int NOT NULL AUTO_INCREMENT,
  `id_establecimiento` int NOT NULL,
  `ip_establecimiento` longtext,
  `nombre` longtext,
  PRIMARY KEY (`id_sede`),
  KEY `FK_sedes_establecimientos` (`id_establecimiento`),
  CONSTRAINT `FK_sedes_establecimientos` FOREIGN KEY (`id_establecimiento`) REFERENCES `establecimientos` (`id_establecimiento`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.sedes: ~1 rows (aproximadamente)
INSERT INTO `sedes` (`id_sede`, `id_establecimiento`, `ip_establecimiento`, `nombre`) VALUES
	(1, 1, '192.168.10.134', 'EstablecimientoO');

-- Volcando estructura para tabla admision.sesiones
CREATE TABLE IF NOT EXISTS `sesiones` (
  `id_sesion` int NOT NULL AUTO_INCREMENT,
  `fecha_inicio` datetime NOT NULL,
  `hombres` int NOT NULL,
  `mujeres` int NOT NULL,
  `nuevos` int NOT NULL,
  `habituales` int NOT NULL,
  `fecha_fin` datetime NOT NULL,
  `id_sede` int NOT NULL,
  PRIMARY KEY (`id_sesion`),
  KEY `IX_id_sede` (`id_sede`),
  CONSTRAINT `FK_sesiones_sedes_id_sede` FOREIGN KEY (`id_sede`) REFERENCES `sedes` (`id_sede`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.sesiones: ~7 rows (aproximadamente)
INSERT INTO `sesiones` (`id_sesion`, `fecha_inicio`, `hombres`, `mujeres`, `nuevos`, `habituales`, `fecha_fin`, `id_sede`) VALUES
	(1, '2025-02-20 08:30:00', 0, 2, 0, 2, '2025-02-21 04:30:00', 1),
	(6, '2025-02-28 10:00:00', 2, 3, 1, 4, '2025-02-28 12:00:00', 1),
	(7, '2025-02-28 10:00:00', 2, 3, 1, 4, '2025-02-28 12:00:00', 1),
	(8, '2025-02-28 10:00:00', 2, 3, 1, 4, '2025-02-28 12:00:00', 1),
	(9, '2025-02-28 10:00:00', 2, 3, 1, 4, '2025-02-28 12:00:00', 1),
	(10, '2025-02-28 10:00:00', 2, 3, 1, 4, '2025-02-28 12:00:00', 1),
	(11, '2025-02-28 10:00:00', 2, 3, 1, 4, '2025-02-28 12:00:00', 1),
	(12, '2025-02-28 10:00:00', 2, 3, 1, 4, '2025-02-28 12:00:00', 1);

-- Volcando estructura para tabla admision.socios
CREATE TABLE IF NOT EXISTS `socios` (
  `id_socio` int NOT NULL AUTO_INCREMENT,
  `dni` longtext,
  `nombre` longtext,
  `apel1` longtext,
  `apel2` longtext,
  `fecha_nacimiento` datetime NOT NULL,
  `sexo` tinyint(1) DEFAULT NULL,
  `id_municipio` int DEFAULT NULL,
  `id_provincia` int DEFAULT NULL,
  `calle` longtext,
  `cp` int DEFAULT NULL,
  `telefono` longtext,
  `fecha_alta` datetime DEFAULT NULL,
  `fecha_baja` datetime DEFAULT NULL,
  `comentario` longtext,
  `puntos` int DEFAULT NULL,
  `total_visitas` int DEFAULT NULL,
  `foto` longtext,
  `id_login` int DEFAULT NULL,
  `fecha_modificacion` datetime DEFAULT NULL,
  `prohibida_entrada` tinyint(1) DEFAULT NULL,
  `id_pais` int NOT NULL,
  PRIMARY KEY (`id_socio`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.socios: ~1 rows (aproximadamente)
INSERT INTO `socios` (`id_socio`, `dni`, `nombre`, `apel1`, `apel2`, `fecha_nacimiento`, `sexo`, `id_municipio`, `id_provincia`, `calle`, `cp`, `telefono`, `fecha_alta`, `fecha_baja`, `comentario`, `puntos`, `total_visitas`, `foto`, `id_login`, `fecha_modificacion`, `prohibida_entrada`, `id_pais`) VALUES
	(24, '12345678A', 'Jose', 'González', 'Herrera', '2025-06-04 00:00:00', NULL, NULL, NULL, 'Falsa 123', NULL, '666777888', NULL, NULL, 'Esto es una prueba', NULL, NULL, NULL, NULL, '2025-06-05 10:41:41', NULL, 0),
	(25, '12345678A', 'Jose', 'González', 'Herrera', '2025-06-05 00:00:00', NULL, NULL, NULL, 'Falsa 123', NULL, '666777888', NULL, NULL, 'Esto es una prueba', NULL, NULL, NULL, NULL, '2025-06-05 10:49:50', NULL, 0);

-- Volcando estructura para tabla admision.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `password` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `alias` varchar(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `fecha_update` datetime NOT NULL,
  `bloqueado` bit(1) NOT NULL DEFAULT (0x00),
  `email` char(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `Eliminado` bit(1) NOT NULL DEFAULT (0x00),
  `fecha_baja` datetime DEFAULT NULL,
  `fecha_creacion` datetime NOT NULL,
  `id_rol` int DEFAULT NULL,
  `dni` varchar(20) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY (`id_usuario`) USING BTREE,
  KEY `nombre` (`nombre`) USING BTREE,
  KEY `FK_usuarios_rol` (`id_rol`) USING BTREE,
  CONSTRAINT `FK_usuarios_rol` FOREIGN KEY (`id_rol`) REFERENCES `roles` (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=217 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla admision.usuarios: ~2 rows (aproximadamente)
INSERT INTO `usuarios` (`id_usuario`, `nombre`, `password`, `alias`, `fecha_update`, `bloqueado`, `email`, `Eliminado`, `fecha_baja`, `fecha_creacion`, `id_rol`, `dni`) VALUES
	(203, 'Jose', '7s+8mdi+Be+sz2CXsnnuDw==', 'joseg', '2025-06-05 10:40:57', b'0', 'jose@dominio.com', b'0', NULL, '2025-06-04 10:29:48', 3, '12345689A'),
	(214, 'Jose2', 'VKOdltxCGsg=', NULL, '0001-01-01 00:00:00', b'0', 'jc@gmail.com', b'0', NULL, '2025-06-04 11:21:40', 1, '123456789B'),
	(215, 'JoseC', 'r8rqyWtguqZBI6/rbzDN6w==', NULL, '0001-01-01 00:00:00', b'0', 'jcg@gmail.com', b'0', NULL, '2025-06-05 10:34:55', 1, '123456789G'),
	(216, 'JoseC', 'r8rqyWtguqZBI6/rbzDN6w==', NULL, '0001-01-01 00:00:00', b'0', 'jcg@gmail.com', b'0', NULL, '2025-06-05 14:21:15', 1, '123456789G');

-- Volcando estructura para tabla admision.visitas
CREATE TABLE IF NOT EXISTS `visitas` (
  `id_visita` int NOT NULL AUTO_INCREMENT,
  `id_sesion` int NOT NULL,
  `id_sede` int DEFAULT NULL,
  `id_socio` int NOT NULL,
  `fecha_hora` datetime NOT NULL,
  `motivo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_visita`),
  KEY `IX_id_sesion` (`id_sesion`),
  CONSTRAINT `FK_visitas_sesiones_id_sesion` FOREIGN KEY (`id_sesion`) REFERENCES `sesiones` (`id_sesion`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.visitas: ~2 rows (aproximadamente)
INSERT INTO `visitas` (`id_visita`, `id_sesion`, `id_sede`, `id_socio`, `fecha_hora`, `motivo`) VALUES
	(56, 1, 1, 15, '2025-06-20 12:00:00', 'Reprogramación de la sesión'),
	(57, 1, NULL, 23, '2025-06-20 12:00:00', 'Reprogramación de la sesión'),
	(58, 1, 1, 15, '2025-06-01 10:00:00', 'Reunión informativa');

-- Volcando estructura para tabla admision._logs
CREATE TABLE IF NOT EXISTS `_logs` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Message` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MessageTemplate` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Level` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TimeStamp` datetime(6) NOT NULL,
  `Exception` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Properties` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision._logs: ~0 rows (aproximadamente)

-- Volcando estructura para tabla admision.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.__efmigrationshistory: ~2 rows (aproximadamente)
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20250318160151_NombreDeLaMigracion', '8.0.4'),
	('20250318160822_ActualizarDemo', '8.0.4');

-- Volcando estructura para tabla admision.__migrationhistory
CREATE TABLE IF NOT EXISTS `__migrationhistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ContextKey` varchar(300) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla admision.__migrationhistory: ~0 rows (aproximadamente)
INSERT INTO `__migrationhistory` (`MigrationId`, `ContextKey`, `Model`, `ProductVersion`) VALUES
	('202410150721346_InitialCreate', 'AdmisionMvc.Models.AsistenciaModelo', _binary 0x1f8b0800000000000400ed5ddb6edcb819be2fd07710e6aa2db21edbb9498df12e9c4952185dc7862731f6cee0489cb1b612a94a9461a3e893f5a28fd4575852d481271d48690ed906b91993e2c7d37fe2cf9f7ffef79fff2e7e7a8923ef19a65988d1e5ecece474e641e4e32044dbcb594e363fbc9bfdf4e31fffb0f818c42fde43f5dd5bf61d6d89b2cbd91321c9c57c9ef94f3006d9491cfa29cef0869cf8389e8300cfcf4f4fff3a3f3b9b430a31a3589eb7b8cf11096358fc41ff5c62e4c384e420bac1018cb2b29cd6ac0a54ef33886196001f5eceae82386483b879f64ff8d733ef2a0a011dc90a469b990710c20410fac9c5d70cae488ad17695d002107d794d20fd6e03a20c96e3bf683e1f3a95d373369579d3b082f2f38ce0d812f0ec6db93673b5b9d30acfeab5a3abf791ae327965b32e56f072b6cce3248274c5d4be2e9651cabe33adef0983094000b393b2fd1b4ff8ea4d4d16947ad8bf37de328f489ec24b04739282e88d7797afa3d0ff3b7cfd82ff01d125caa3481c281d2aad930a68d15d8a139892d77bb829871f068f7e3583b9dc7eae02d4cd0d6df94caf11797b3ef33ed3c18075046bba10566545700aff06114c0181c11d2004a6745baf0358acac360abdcf0c66c5564a5df6b7c27e88ad1bc1005ab5d940ff093cfa29048f310eaaa61fe854bf50e6ec6b0d50e71017f386fa3a6992c2d2d58fe982fbd899304590035267220cc38d461584bd52aa463e5a876ee46e0993c26d042a082abfa92a9a7937e0e56788b6e4e972467fcebc4fe10b0caa9212f62ba28b16d04624cd7b7bf131dad05d27e1734dc5ef318e2040d603a67bf614ae29253ed2c54e4100c6026ef1da07682c4ac3deb6aced2481a832a2d30769d36c677bf74cb99bae83dd02d908a4623b4749238e70585154cdc24d0c55adf725820214ee9c7012908104a704eebc2784e375bafb6e4002a3886e53b6f39e62cc44e5eefb2161b27b0102e2754876df0d97c0216dd208c5a13298b7dd84c8ad610a9f4351159b5b0f9689f74c272f4595e9281a55a0034ac8d2ce70908e9285f2fb908c7b9457677be9e57c4fdc8d801fc621dd486b0ea78414e74c3624f6673daa9f9f43e4872a151e8d8996c117ddaeee6e0223ba90c8da7c1e2cc35245f4dc431058ca3113c42412cc7b0f32586e098c369a989c0d60de1b9598762c2cee541adc717f2b81a426ea6a30edac8ac3b1a3ce638d0fa8e7f8c1de41cd0df1084cea82801961e0aa4075f446246d78df9c12fd0c9ec36db1c89a94e536de3d8c8aeaec294c4a09b22aaaca3dfc94e2f81e470521d7c58f5f40ba85840e17eb752b9ca7be3bb7f06139f30bab3a28c7f0f13bf1cc1007d8745cd37dc4b06499a7827e7bdd8e3d07c5fc57381a04e5f0b9dfffd9331b400f793918e0f1773e89b93848adbdac1ddccfb0dc78bfe26f13ef577261e838d8499300e3481e8aaa9a2b9ab148159a24926b47c9a28772708eb288373fa02caa16d74116554d0f7ddd3509973879ac9d38fd09a7068ff9082e6dd5d103b943e55533efb8696abe68ae8a9ab53ea49ee6a37751d34388e5bb07c7d0cdff9707c7528038783d0ee0050251b47b3af113ab411118c10d46fbf2c9838858df8af2966bf0ab75cb3dfadd929cd2b16af0f62c3d157251692cd8b5dce03d1caa299d47781bdac5d0f0bd8a71106e429ff277df4588cba57e3f7b82d0eae8d1a6b5af32a6ae0a45241db0b999248fe2230abc0e6bbff1305667f41baa9ec3842a64daf1e5ec2fdab4cc80b5c12e02329b4d863b9ba97afc167da09c4ea077e5f310b925c87c607250d18ee512aafae9c112b140be2535a3e8a68488e8760213880988da07ad34b1719bb171d53da8351f6002113308da376064d7750fca52f5adcc622e90503765c926691b29b4d8a70d3154a7aee1d4d57220ec23d8c3539871e08337dae468b2a232e3568cee7e724ae3928db621b4054ccb315c65614620b3608ab385e924f23583e561242bf5854a410c7805891ae2dac8d29280962da1a32ac29d1c82a7e1c8018bfd603c90a605a92546478529ee83322166cd04a75fd2f7a032916d025a996e0cf4c68c785ada1bfda72ac243657268000f66a7873604768a330ec078301448539d462972852f0cae34954bba756d3d5871a9344eeb56af1246600a7b96e73460be8acf419f71870618a0038411d7dbdb3169b3d41fb0741d33afcca85ad8d4758b397f4f50162ce62d0f0f16372049a8352b3c44284bbc157f85b0fc61651f9e1f738cb99f19a2f4ebd1d63d119c822d546a69d774a49fc23423d492056bc08cc865106b9f69a2b58595aaee64e9a9ef58c561d5f7ec7729c47517510b4cb38e9fe8d4d899a8982514f6bbb5a5c71e838008a41d71fd4b1ce531ea7b2bd08356718602d6a62bbbb1b81c52a14cd2a977544c3e696332d989ed386ac0bf08a7d60d47e50f01442c5ea2232ce6caf66b768746679ac92693ed20a29615fa48d296b4bf3d7d7737ef2000e5618042099d0f0ff6415a53324e195e27e21863f5ba30a4f07e11c96fb78fbaf00cee0011d5503d1cbb0af71701ab3217e66e63ecc3082fd1f9256f44533e1cad0efd17a1eac263123995d93f5ede9467042761d3d6b65bd254a7125dca98cf2b5d88c5dd8708541458705e13b32f715c533c1cabba231181aa320b85d704dd4b5aaf291e8e5587d58b4875e1701c1e362f82f0128b599531f1d294ca325b2954c5a3e872a8aab1452cc22f74b8a2d816ab898dd7019bbaa3912586b3bf8d4cb9ced8efdbcd9f0cc245f518fcd941c87487aa76ed461349afc8196b6d3f56c64c2717ce749970668b71ae6368171e5d18fab5a64ee762ad9555205c562abb26d458210ab798babea96a0e656ff01b5d1187970c4710c2da4518a1787a49636f661883e3bf4d61a045c3eb5c7de342aa5ad4bb8e7be742b06274bb0eb96a2737bace4158dcdd3c8028876d2f1c44cc0f61e6a705e1d18d3b0ecaeb279963a33a6ddd75c7fb5ed7dcd1aee01ee591bbb73238c607ec98b9d91e9c14da93000552abb740373c3890d00df5bb32510e4652a5b77e3455992e1f06d195b9e13edc56d31f7dea787c11ac2eb438645621f9d221b32ab4a0c1322a5fa2c1b2cc6256425cbe3431a1fc30c7435b3973202eab2ed646325979c96acf646d0d3b96b50a455716d61cdcdebb45135ed04ce5fb9ec6572a06a0ebd4cccb8f860ccbdbf7b1a2be582307496f6eb7fb3dfaee6bd88faf61fcc9fb9bf056f0606cc951c18b2c30120520b1f21cd791d792f7b82eb5a5051e5aad53012fb745e3e1d63a1a2f3f9457a88ab2962e24ca328b959703afa5e597ab2c560d6b3c88ad7d7c65bcb542df65a9ed0eca41d8fa4ecaf5c771235b076fab2c5e14ee59036bf14cea2775ef6549fd771dcf54c612f56757d5828bf82733aff06c052cb0e8e675f5cfe884d59f143f971113edcd173700851b7ad0e5afbb66ef58aa582941ebf1244b9d6759101962b1840772c678a443642b0dd91af73e431b9bb1b1e8a50119f83e437a4de70821bcf8744030a7320de82a91e2adc75d0afd90e72e3eb5c516139df60ecd2deda91b757506fdb8671bdd1da5b56ef124c46a9f5c34c2684be08b35b5197287ae318ea64b1cea8426670d7582d053864ec34213c808fd0d9debee29d943072c9443ea50678e9e3269e74e385978cbecba035a1a4e5720f9cdb32b8a9644d31548c991e90a23a6c0749e9394e1d215c5945d661a89a025559912564d7ee982ed9e1ad38df527ca4679ac2c3f1da79e4d01723e0d67e8a90326d3975a520037bb3a5153041c54f58af91154bd3ba4bd9622d2c9ca694997388eb4efd4851e0727263b744552020f38187a062925dd547aa97f76fe6e2a1348bfd9df6fa2c25d9d5e5a72093a1d645a3313ee53bada66f373ddd38952e9ed645fddec1b975c7a2e74a264d2738190f3e8b920e859f45c501ccc3d67b782f684fc1a05f0e572f6afa2cd8577fdcb63d9ec8d779b0630bdf04ebd7f4f25ff4c97e3fb4ff6b6476fe1d0e5e6393d072ff82ebc843d6e08c71c714ea46c99a1cd51f84e931fedfb99e2d8cf14d6c9c95c8cef233b948859cc9c1db9c98811a829cbc66dbb98916c4a5f8898af6c1adce98e8372b232972d30a52e73b93ec2e36d70354f99f32d96296bd9343b37f8be61281f0b09cefa75e9d4e9cd1a53603ff9c7d4542d4ee9d41c93981983ec071fa23dfbb465bf9b546583f76a47b4f220d9e556c9d14624bcdb7b02b26f26e5989e3e47dd39eb7c623c46860ae93553225cfeb5457ea8f05218405fae315347dd410086eeaa2b42535f555d4b477526b39e5ef4f7505a67fa27a63e8bab8d6c29a53debe99bab01ad3f5e6cea233326d6d26139dd1a80798519ba2579958a5e49040dbdaa30a1b744079ab3a4b52749330ebc4caca620ef32815ab36bcd03315d4ae8725d7ffca349e7c3e5481b3c48a3cad09f5c0c9f9a4512343d38900a5de13f68a7123f0bb70d047bff88a02f89dbfa9b6bb4c195e05746547da2d8913790504b9480ab94841be0135aedc32c2b920997ef2b3fc66b185ca3db9c2439a15386f13a9272ae33edd1d57f91e94d1ef3e23629b2f14f31053acc9059e8b7e87d1e46413dee4f0623b80582a9a5d2bbc2f692302fcbf6b546fa4cc5c830a072f96a6dfa05524544c1b25bb402cfd0656c5f33f833dc02ffb50af16c07e9df0879d9171f42b04d419c95184d7bfa27a5e1207ef9f13777f5ae72a7800000, '6.4.4');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
