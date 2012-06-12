-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2012 年 06 月 12 日 22:41
-- 服务器版本: 5.5.16
-- PHP 版本: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- 数据库: `db_bespeakmeal`
--

-- --------------------------------------------------------

--
-- 表的结构 `tbl_food`
--

CREATE TABLE IF NOT EXISTS `tbl_food` (
  `foodid` int(11) NOT NULL AUTO_INCREMENT,
  `foodname` varchar(20) NOT NULL,
  `foodprice` double NOT NULL,
  `foodtype` varchar(8) DEFAULT NULL,
  `status` int(11) DEFAULT '1',
  `foodcontent` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`foodid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=15 ;

--
-- 转存表中的数据 `tbl_food`
--

INSERT INTO `tbl_food` (`foodid`, `foodname`, `foodprice`, `foodtype`, `status`, `foodcontent`) VALUES
(1, '鱼香茄子', 12, '川菜', 1, '鱼香茄子是我国八大菜系中川菜的著名菜肴，主料为茄子，配以多种辅料加工烧制而成。有多种不同制法，其味道鲜美，营养丰富。'),
(2, '梅菜扣肉', 13, '粤菜', 1, '梅菜扣肉即我们常称之烧白，因地域不同而名字颇多，其特点在于颜色酱红油亮，汤汁黏稠鲜美，扣肉滑溜醇香，肥而不腻，食之软烂醇香。'),
(3, '白斩鸡', 11.5, '粤菜', 1, '白斩鸡是南方菜系名菜，形状美观，皮黄肉白，肥嫩鲜美，滋味异常鲜美，十分可口。'),
(4, '麻婆豆腐', 9, '川菜', 1, '麻婆豆腐是我国八大菜系之一的川菜中的名品。主要原料由豆腐构成，其特色在于麻、辣、烫、香、酥、嫩、鲜、活八字，称之为八字箴言。'),
(5, '红烧豆腐饭', 13, '快餐', 1, '红烧豆腐是我国传统的、大众化的一种豆制食品，在一些古籍中都有记载。豆腐作为食药兼备的食品，具有益气、补虚等多方面的功能。'),
(6, '叉烧饭', 15, '快餐', 1, '叉烧是广东特色肉制品，多呈红色，瘦肉做成，略甜。是把腌渍后的瘦猪肉挂在特制的叉子上，放入炉内烧烤。'),
(7, '可口可乐', 2.5, '饮料', 1, '由美国可口可乐公司出品的一种含有咖啡因的碳酸饮料。不仅能解渴，还能补充运动需要的碳水化合物。'),
(8, '维他奶', 2, '饮料', 1, '维他奶以天然非转基因大豆为主要原料，它不仅保留了大豆本身的营养成份，且其配方科学，综合平衡了植物蛋白与动物蛋白，还含有多种的维生素，容易被人体吸收。'),
(9, '港式双皮奶', 5, '甜点', 1, '双皮奶口感细腻润滑，冬天可以趁热吃，夏天放冰箱里冰一会儿口味更佳。'),
(11, '抹茶蛋糕', 4, '甜点', 0, '抹茶蛋糕就是加了抹茶粉的蛋糕。抹茶蛋糕既美观又美味，是一种很受人们喜爱的蛋糕。'),
(12, '蚂蚁上树', 15, '川菜', 1, '蚂蚁上树主料为粉丝和猪肉末。口味清淡，爽滑美味。 色泽红亮，肉末贴在粉丝上(形式蚂蚁爬在树枝上)，食之别有风味.　本菜以形取名，蚂蚁为面筋米，树为粉丝，形象逼真。 本菜粉丝油亮，柔软滑嫩，面筋酥香，风味别致，为素菜的上品。'),
(13, '干炒牛河', 15, '粤菜', 1, '干炒牛河是广东菜色的一种，以芽菜、河粉、牛肉等炒成。在广州、香港的茶餐厅、海外的粤菜酒家、干炒牛河几乎成为必备的菜色。喜欢吃牛河一个是喜欢它那炝炒的味道，一个是上色至深引发的口水欲。'),
(14, '盐水韭菜炸豆腐', 10, '粤菜', 1, '这道潮汕小菜所用的一定是老豆腐才显出这样的“品质”，而且拥有甘香的嚼头，令人回味。资料显示，韭菜具有健胃、暖身和提神、杀菌的功效，初春时的品质最好，适量食用，可以有助于增强脾胃之气，有益甘补肾的作用。');

-- --------------------------------------------------------

--
-- 表的结构 `tbl_order`
--

CREATE TABLE IF NOT EXISTS `tbl_order` (
  `orderid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL,
  `ordertime` datetime DEFAULT NULL,
  `eattype` varchar(8) DEFAULT NULL,
  `address` varchar(50) DEFAULT NULL,
  `phonenum` varchar(16) DEFAULT NULL,
  `otherrequest` varchar(50) DEFAULT NULL,
  `status` int(11) DEFAULT '0',
  PRIMARY KEY (`orderid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=42 ;

--
-- 转存表中的数据 `tbl_order`
--

INSERT INTO `tbl_order` (`orderid`, `userid`, `ordertime`, `eattype`, `address`, `phonenum`, `otherrequest`, `status`) VALUES
(4, 1, '2012-05-28 01:03:00', '外卖', '前山路206号', NULL, '加辣', -1),
(5, 1, '2012-05-28 01:05:15', '外卖', '前山路206号', NULL, '加辣', -1),
(6, 1, '2012-05-28 01:34:05', '外卖', '前山路206号', NULL, '加辣', 3),
(8, 1, '2012-05-29 08:55:58', '外卖', '暨大北门', NULL, 'ifaennaefn额infield爱犯贱额爱犯贱阿伟激发iwjefaw饥饿疗法就啊我类纠纷爱问家乐', -1),
(9, 8, '0001-01-01 00:00:00', NULL, NULL, NULL, NULL, 0),
(10, 2, '0001-01-01 00:00:00', NULL, '暨南大学', '13750010204', '', 1),
(11, 10, '2012-06-09 16:15:54', NULL, NULL, NULL, NULL, 0),
(12, 1, '2012-06-10 10:05:53', NULL, '1431宿舍', '1213123', '', 1),
(13, 1, '2012-06-11 20:52:03', NULL, '1431宿舍', '13750010204', '', 3),
(14, 1, '2012-06-11 20:54:47', NULL, '1431宿舍', '13750010204', '', -1),
(15, 1, '2012-06-11 21:36:06', NULL, '1431宿舍', '13750018812', '加饭', 2),
(16, 1, '2012-06-11 21:50:18', NULL, '1431宿舍', '13750018812', '加冰', 3),
(18, 2, '2012-06-11 22:03:18', NULL, NULL, NULL, NULL, 0),
(24, 1, '2012-06-11 23:03:37', NULL, '1431宿舍', '13750018812', '加饭', 3),
(25, 1, '2012-06-12 00:14:01', NULL, '1431宿舍', '1213123', 'ijfeij', 2),
(26, 1, '2012-06-12 00:27:37', NULL, '1431宿舍', '1213123', 'ijfeij', -1),
(27, 12, '2012-06-12 00:32:35', NULL, 'fej', 'jife', 'jia', 1),
(28, 1, '2012-06-12 00:46:37', NULL, 'jfie', 'jiaj', 'ljij', 1),
(34, 1, '2012-06-12 13:15:16', NULL, 'jei', 'jif', 'jie', 2),
(35, 1, '2012-06-12 17:47:41', NULL, 'fji', 'jif', 'jifej', 2);

-- --------------------------------------------------------

--
-- 表的结构 `tbl_orderfood`
--

CREATE TABLE IF NOT EXISTS `tbl_orderfood` (
  `orderfoodid` int(11) NOT NULL AUTO_INCREMENT,
  `orderid` int(11) NOT NULL,
  `foodid` int(11) NOT NULL,
  `foodnum` int(8) NOT NULL DEFAULT '1',
  PRIMARY KEY (`orderfoodid`),
  KEY `orderfoodid` (`orderfoodid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=85 ;

--
-- 转存表中的数据 `tbl_orderfood`
--

INSERT INTO `tbl_orderfood` (`orderfoodid`, `orderid`, `foodid`, `foodnum`) VALUES
(3, 9, 3, 1),
(4, 10, 7, 3),
(5, 11, 6, 1),
(6, 9, 4, 2),
(7, 9, 8, 2),
(8, 10, 6, 1),
(13, 8, 6, 4),
(14, 10, 4, 1),
(15, 9, 6, 1),
(16, 9, 2, 1),
(23, 8, 4, 1),
(24, 8, 2, 1),
(25, 8, 1, 1),
(28, 11, 7, 1),
(29, 12, 7, 1),
(30, 13, 7, 2),
(32, 15, 7, 1),
(35, 12, 8, 2),
(36, 12, 3, 2),
(37, 13, 11, 2),
(39, 14, 1, 1),
(40, 15, 5, 1),
(44, 16, 7, 1),
(53, 18, 7, 1),
(66, 24, 7, 1),
(67, 25, 9, 1),
(68, 26, 5, 1),
(69, 27, 5, 1),
(70, 28, 2, 1),
(76, 34, 5, 1),
(77, 34, 7, 1),
(78, 35, 5, 1);

-- --------------------------------------------------------

--
-- 表的结构 `tbl_user`
--

CREATE TABLE IF NOT EXISTS `tbl_user` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL,
  `password` varchar(128) NOT NULL,
  `name` varchar(20) DEFAULT NULL,
  `gender` char(1) DEFAULT NULL,
  `phonenum` varchar(20) DEFAULT NULL,
  `email` varchar(128) DEFAULT NULL,
  `createtime` datetime NOT NULL,
  `superuser` int(11) NOT NULL DEFAULT '0',
  `status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`userid`),
  UNIQUE KEY `username_2` (`username`),
  KEY `username` (`username`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=13 ;

--
-- 转存表中的数据 `tbl_user`
--

INSERT INTO `tbl_user` (`userid`, `username`, `password`, `name`, `gender`, `phonenum`, `email`, `createtime`, `superuser`, `status`) VALUES
(1, 'lion', '123', '谢平时', '男', '13750010204', 'xhyzdai@qq.com', '2012-05-28 00:00:00', 1, 1),
(2, 'judy', '123', '罗', '女', '12345678901', 'luo@qq.com', '2012-05-29 00:00:00', 1, 1),
(3, 'test', '123', '放假', '男', '12345678901', 'luo@qq.com', '2012-05-28 00:46:33', 0, 1),
(4, 'qwert', '123', '陈', '男', '13750010200', 'qinghe@qq.com', '2012-06-04 12:57:21', 0, 0),
(5, 'liona', 'wow', 'ajfi', '男', '23434534534', 'wja@qq.com', '2012-06-04 17:15:23', 0, 0),
(6, 'jei', 'jaifej', 'fiaen', '男', '13750010200', 'xhyzdai@126.com', '2012-06-07 15:33:00', 0, 0),
(7, 'abc', 'abc', NULL, '\0', NULL, NULL, '2012-06-07 15:51:32', 0, 0),
(8, 'test1', 'test1', NULL, '\0', NULL, NULL, '2012-06-07 16:29:02', 0, 0),
(9, 'test2', 'test2', NULL, '\0', NULL, NULL, '2012-06-07 16:34:04', 0, 0),
(10, 'test3', 'test3', NULL, '\0', NULL, NULL, '2012-06-07 16:36:30', 0, 0),
(11, 'test4', 'test4', NULL, '\0', NULL, NULL, '2012-06-07 16:39:55', 0, 0),
(12, '', '', NULL, '\0', NULL, NULL, '2012-06-12 00:32:22', 0, 0);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
