-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: book_store
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `book`
--

DROP TABLE IF EXISTS `book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book` (
  `ISBN` int NOT NULL,
  `Title` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Version` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Language` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Price` float DEFAULT NULL,
  `Year` varchar(10) DEFAULT NULL,
  `Stock` int DEFAULT NULL,
  `Image` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `conclution` varchar(10000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Author_id` int NOT NULL,
  `Publisher_id` int NOT NULL,
  PRIMARY KEY (`ISBN`),
  KEY `fk_book_author1_idx` (`Author_id`),
  KEY `fk_book_publisher1_idx` (`Publisher_id`),
  CONSTRAINT `fk_book_author1` FOREIGN KEY (`Author_id`) REFERENCES `author` (`Author_id`),
  CONSTRAINT `fk_book_publisher1` FOREIGN KEY (`Publisher_id`) REFERENCES `publisher` (`Publisher_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book`
--

LOCK TABLES `book` WRITE;
/*!40000 ALTER TABLE `book` DISABLE KEYS */;
INSERT INTO `book` VALUES (101,'Daisy Jones & The Six','1st Edition','English',400,'2021',38,'8167482488.jpg','A gripping novel about the whirlwind rise of an iconic 1970s rock group and their beautiful lead singer, revealing the mystery behind their infamous break up.',2,2),(201,'Pretty Reckless','2nd Edition','English',20,'2018',47,'2656413312.jpg','Penn\n\nThey say revenge is a dish best served cold.\nI’d had four years to stew on what Daria Followhill did to me, and now my heart was completely iced.\nI took her first kiss.\nShe took the only thing I loved.\nI was poor.\nShe was rich.\nThe good thing about circumstances? They can change. Fast.\nNow, I’m her parents’ latest shiny project.\nHer housemate. Her tormentor. The captain of the rival football team she hates so much.\nYeah, baby girl, say it—I’m your foster brother.\nThere’s a price to pay for ruining the only good thing in my life, and she’s about to shell out some serious tears.\nDaria Followhill thinks she is THE queen. I’m about to prove to her that she’s nothing but a spoiled princess.\n\nDaria\n\nEveryone loves a good old unapologetic punk.\nBut being a bitch? Oh, you get slammed for every snarky comment, cynical eye roll, and foot you put in your adversaries’ way.\nThe thing about stiletto heels is that they make a hell of a dent when you walk all over the people who try to hurt you.\nIn Penn Scully’s case, I pierced his heart until he bled out, then left it in a trash can on a bright summer day.\nFour years ago, he asked me to save all my firsts for him.\nNow he lives across the hall, and I want nothing more than to be his last everything.\nHis parting words when he gave me his heart were that nothing in this world is free.\nNow? Now he is making me pay.',3,2),(301,'يوتوبيا','الطبعة الاولى','Arabic',160,'250',9,'1512004698.jpg','كيف ستكون مصر عام 2023؟\nلقد عزَلَ الأغنياء أنفسهم في (يوتوبيا) الساحل الشمالي تحت حراسة المارينز الأمريكيين، يتعاطون المخدرات ويمارسون المتع المحرمة إلى أقصاها، بينما ينسحق الفقراء خارجها ينهش بعضهم لحم بعض من أجل العيش، دونما كهرباء أو صرف صحي أو رعاية طبية من أي نوع. ولكن حين يتسلل الراوي وصديقته (جرمينال) خارج (يوتوبيا) بدافع الملل وبحثا عن (صيد بشري)\nمناسب يحدث ما يهدد الوضع المستقر بالانفجار.\n\nفيما يشبه هول علامات يوم القيامة، تدق هذه الرواية المثيرة ناقوس الخطر، تكاد تشك إذ تنهيها أهي بالفعل رواية متخيلة، أم إن كاتبها تسلل من المستقبل القريب لينقل لك هوله بحياد مذهل',8,5),(401,'نعمة عدم الكمال','الطبعة الثانية','Arabic(مترجم)',200,'2015',37,'4101875474.jpg','في هذا الكتاب تشاركنا برينيه براون الباحثة الرائدة في مجال الخزي والمصداقية والانتماء عشرة منشورات ارشادية عن قوة العيش بكامل القلب الوسيلة للانخراط في هذا العالم من موضع الشعور بالجدارة فهو كتاب رائع ومهم يقدم لنا التعاطف والحكمة والمشورة السديدة.',4,6);
/*!40000 ALTER TABLE `book` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-24 21:17:56
