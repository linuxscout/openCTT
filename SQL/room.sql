-- phpMyAdmin SQL Dump
-- version 2.8.2.4
-- http://www.phpmyadmin.net
-- 
-- Host (domena): localhost
-- Vrijeme podizanja: 02. Tra 2007. u 15:26
-- Verzija servera: 5.0.24
-- verzija PHP-a: 5.1.6
-- 
-- Baza podataka: `timetable`
-- 

-- --------------------------------------------------------

-- 
-- Struktura tablice `room`
-- 

DROP TABLE IF EXISTS `room`;
CREATE TABLE IF NOT EXISTS `room` (
  `room_id` smallint(5) unsigned NOT NULL auto_increment,
  `name` varchar(20) collate utf8_unicode_ci NOT NULL,
  `capacity` smallint(5) unsigned NOT NULL,
  `ext_id` int(10) unsigned default NULL,
  PRIMARY KEY  (`room_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;
