-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2012 年 06 月 09 日 23:07
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
  `foodcontent` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`foodid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- 转存表中的数据 `tbl_food`
--

INSERT INTO `tbl_food` (`foodid`, `foodname`, `foodprice`, `foodtype`, `foodcontent`) VALUES
(1, '鱼香茄子', 12, '川菜', '鱼香茄子是我国八大菜系中川菜的著名菜肴，主料为茄子，配以多种辅料加工烧制而成。有多种不同制法，其味道鲜美，营养丰富。'),
(2, '梅菜扣肉', 13, '粤菜', '梅菜扣肉即我们常称之烧白，因地域不同而名字颇多，其特点在于颜色酱红油亮，汤汁黏稠鲜美，扣肉滑溜醇香，肥而不腻，食之软烂醇香。'),
(3, '白斩鸡', 11.5, '粤菜', '白斩鸡是南方菜系名菜，形状美观，皮黄肉白，肥嫩鲜美，滋味异常鲜美，十分可口。'),
(4, '麻婆豆腐', 9, '川菜', '麻婆豆腐是我国八大菜系之一的川菜中的名品。主要原料由豆腐构成，其特色在于麻、辣、烫、香、酥、嫩、鲜、活八字，称之为八字箴言。'),
(5, '红烧豆腐饭', 13, '快餐', '红烧豆腐是我国传统的、大众化的一种豆制食品，在一些古籍中都有记载。豆腐作为食药兼备的食品，具有益气、补虚等多方面的功能。'),
(6, '叉烧饭', 15, '快餐', '叉烧是广东特色肉制品，多呈红色，瘦肉做成，略甜。是把腌渍后的瘦猪肉挂在特制的叉子上，放入炉内烧烤。'),
(7, '可口可乐', 2.5, '饮料', '由美国可口可乐公司出品的一种含有咖啡因的碳酸饮料。不仅能解渴，还能补充运动需要的碳水化合物。'),
(8, '维他奶', 2, '饮料', '维他奶以天然非转基因大豆为主要原料，它不仅保留了大豆本身的营养成份，且其配方科学，综合平衡了植物蛋白与动物蛋白，还含有多种的维生素，容易被人体吸收。'),
(9, '港式双皮奶', 5, '甜点', '双皮奶口感细腻润滑，冬天可以趁热吃，夏天放冰箱里冰一会儿口味更佳。'),
(11, '抹茶蛋糕', 4, '甜点', '抹茶蛋糕就是加了抹茶粉的蛋糕。抹茶蛋糕既美观又美味，是一种很受人们喜爱的蛋糕。');

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
  `otherrequest` varchar(50) DEFAULT NULL,
  `status` int(11) DEFAULT '0',
  PRIMARY KEY (`orderid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- 转存表中的数据 `tbl_order`
--

INSERT INTO `tbl_order` (`orderid`, `userid`, `ordertime`, `eattype`, `address`, `otherrequest`, `status`) VALUES
(4, 1, '2012-05-28 01:03:00', '外卖', '前山路206号', '加辣', 1),
(5, 1, '2012-05-28 01:05:15', '外卖', '前山路206号', '加辣', 1),
(6, 1, '2012-05-28 01:34:05', '外卖', '前山路206号', '加辣', 1),
(8, 1, '2012-05-29 08:55:58', '外卖', '暨大北门', NULL, 0),
(9, 8, '0001-01-01 00:00:00', NULL, NULL, NULL, 0),
(10, 2, '0001-01-01 00:00:00', NULL, NULL, NULL, 0),
(11, 10, '2012-06-09 16:15:54', NULL, NULL, NULL, 0);

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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=29 ;

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
(28, 11, 7, 1);

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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- 转存表中的数据 `tbl_user`
--

INSERT INTO `tbl_user` (`userid`, `username`, `password`, `name`, `gender`, `phonenum`, `email`, `createtime`, `superuser`, `status`) VALUES
(1, 'lion', '123', '戴礼荣', '男', '13750018812', 'xhyzdai@qq.com', '2012-05-28 00:00:00', 1, 1),
(2, 'judy', '123', '罗', '女', '12345678901', 'luo@qq.com', '2012-05-29 00:00:00', 1, 1),
(3, 'test', '123', '放假', '男', '12345678901', 'luo@qq.com', '2012-05-28 00:46:33', 0, 1),
(4, 'qwert', '123', '陈', '男', '13750010200', 'qinghe@qq.com', '2012-06-04 12:57:21', 0, 0),
(5, 'liona', 'wow', 'ajfi', '男', '23434534534', 'wja@qq.com', '2012-06-04 17:15:23', 0, 0),
(6, 'jei', 'jaifej', 'fiaen', '男', '13750010200', 'xhyzdai@126.com', '2012-06-07 15:33:00', 0, 0),
(7, 'abc', 'abc', NULL, '\0', NULL, NULL, '2012-06-07 15:51:32', 0, 0),
(8, 'test1', 'test1', NULL, '\0', NULL, NULL, '2012-06-07 16:29:02', 0, 0),
(9, 'test2', 'test2', NULL, '\0', NULL, NULL, '2012-06-07 16:34:04', 0, 0),
(10, 'test3', 'test3', NULL, '\0', NULL, NULL, '2012-06-07 16:36:30', 0, 0),
(11, 'test4', 'test4', NULL, '\0', NULL, NULL, '2012-06-07 16:39:55', 0, 0);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
