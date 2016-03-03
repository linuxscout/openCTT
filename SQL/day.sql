-- phpMyAdmin SQL Dump
-- version 2.8.2.4
-- http://www.phpmyadmin.net
-- 
-- Host (domena): localhost
-- Vrijeme podizanja: 02. Tra 2007. u 15:42
-- Verzija servera: 5.0.24
-- verzija PHP-a: 5.1.6
-- 
-- Baza podataka: `timetable`
-- 

-- --------------------------------------------------------

-- 
-- Struktura tablice `day`
-- 

DROP TABLE IF EXISTS `day`;
CREATE TABLE IF NOT EXISTS `day` (
  `day_id` smallint(5) unsigned NOT NULL auto_increment,
  `name` varchar(15) collate utf8_unicode_ci NOT NULL,
  `day_index` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY  (`day_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;
