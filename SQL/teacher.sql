-- phpMyAdmin SQL Dump
-- version 2.8.2.4
-- http://www.phpmyadmin.net
-- 
-- Host (domena): localhost
-- Vrijeme podizanja: 02. Tra 2007. u 15:13
-- Verzija servera: 5.0.24
-- verzija PHP-a: 5.1.6
-- 
-- Baza podataka: `timetable`
-- 

-- --------------------------------------------------------

-- 
-- Struktura tablice `teacher`
-- 

DROP TABLE IF EXISTS `teacher`;
CREATE TABLE IF NOT EXISTS `teacher` (
  `teacher_id` smallint(6) NOT NULL auto_increment,
  `name` varchar(20) collate utf8_unicode_ci NOT NULL,
  `lastname` varchar(30) collate utf8_unicode_ci NOT NULL,
  `title` varchar(40) collate utf8_unicode_ci default NULL,
  `edurank` varchar(70) collate utf8_unicode_ci default NULL,
  `ext_id` int(11) default NULL,
  PRIMARY KEY  (`teacher_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;
