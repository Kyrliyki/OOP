-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               8.0.30 - MySQL Community Server - GPL
-- Операционная система:         Win64
-- HeidiSQL Версия:              12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Дамп структуры базы данных test
CREATE DATABASE IF NOT EXISTS `test` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `test`;

-- Дамп структуры для таблица test.question
CREATE TABLE IF NOT EXISTS `question` (
  `id_question` int NOT NULL AUTO_INCREMENT,
  `id_tests` int NOT NULL DEFAULT '0',
  `text_question` text NOT NULL,
  `answer_question` text NOT NULL,
  `question_number` int NOT NULL,
  PRIMARY KEY (`id_question`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы test.question: ~1 rows (приблизительно)
INSERT INTO `question` (`id_question`, `id_tests`, `text_question`, `answer_question`, `question_number`) VALUES
	(9, 20, '12412412421', '+123123 -123 -2124', 1),
	(10, 20, 'dfgdfgdg', '-sdfsf -sdfsdf +sdfsdf', 2);

-- Дамп структуры для таблица test.rez
CREATE TABLE IF NOT EXISTS `rez` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_user` int NOT NULL,
  `id_test` int NOT NULL,
  `grade` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы test.rez: ~0 rows (приблизительно)
INSERT INTO `rez` (`id`, `id_user`, `id_test`, `grade`) VALUES
	(1, 4, 20, '1 из 2');

-- Дамп структуры для таблица test.tests
CREATE TABLE IF NOT EXISTS `tests` (
  `id_test` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `name_test` text NOT NULL,
  PRIMARY KEY (`id_test`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы test.tests: ~0 rows (приблизительно)
INSERT INTO `tests` (`id_test`, `name_test`) VALUES
	(0000000020, '1234123');

-- Дамп структуры для таблица test.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `pasword` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `statys` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `login` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы test.users: ~4 rows (приблизительно)
INSERT INTO `users` (`id`, `login`, `pasword`, `statys`) VALUES
	(2, 'admin', 'admin', 'admin'),
	(4, 'login', 'login', 'student'),
	(6, 'nikitin', '123', 'student'),
	(7, 'shyr', '123', 'student'),
	(8, 'teacher', '123', 'teacher');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
