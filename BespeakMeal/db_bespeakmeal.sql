-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2012 年 05 月 28 日 11:28
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
  `foodprice` decimal(10,10) NOT NULL,
  `foodtype` varchar(8) DEFAULT NULL,
  `foodcontent` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`foodid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- 表的结构 `tbl_foodlist`
--

CREATE TABLE IF NOT EXISTS `tbl_foodlist` (
  `orderid` int(11) NOT NULL,
  `foodid` int(11) NOT NULL,
  `foodnum` int(8) NOT NULL DEFAULT '1',
  PRIMARY KEY (`orderid`,`foodid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- 表的结构 `tbl_order`
--

CREATE TABLE IF NOT EXISTS `tbl_order` (
  `orderid` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) NOT NULL,
  `ordertime` datetime NOT NULL,
  `eattype` varchar(8) NOT NULL,
  `address` varchar(50) NOT NULL,
  `otherrequest` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`orderid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- 转存表中的数据 `tbl_order`
--

INSERT INTO `tbl_order` (`orderid`, `userid`, `ordertime`, `eattype`, `address`, `otherrequest`) VALUES
(4, 1, '2012-05-28 01:03:00', '外卖', '前山路206号', '加辣'),
(5, 1, '2012-05-28 01:05:15', '外卖', '前山路206号', '加辣'),
(6, 1, '2012-05-28 01:34:05', '外卖', '前山路206号', '加辣');

-- --------------------------------------------------------

--
-- 表的结构 `tbl_user`
--

CREATE TABLE IF NOT EXISTS `tbl_user` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL,
  `password` varchar(128) NOT NULL,
  `firstname` varchar(20) NOT NULL,
  `lastname` varchar(20) NOT NULL,
  `gender` char(1) NOT NULL,
  `phonenum` varchar(20) NOT NULL,
  `email` varchar(128) NOT NULL,
  `createtime` datetime NOT NULL,
  `superuser` int(1) NOT NULL DEFAULT '0',
  `status` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- 转存表中的数据 `tbl_user`
--

INSERT INTO `tbl_user` (`userid`, `username`, `password`, `firstname`, `lastname`, `gender`, `phonenum`, `email`, `createtime`, `superuser`, `status`) VALUES
(1, 'lion', '123', '礼荣', '戴', '男', '12345678901', 'xhyzdai@qq.com', '2012-05-28 00:00:00', 0, 0),
(2, 'judy', '123', '娟', '罗', '女', '12345678901', 'luo@qq.com', '2012-05-29 00:00:00', 0, 0),
(3, 'test', '123', '阿飞', '放假', '男', '12345678901', 'luo@qq.com', '2012-05-28 00:46:33', 0, 0);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
