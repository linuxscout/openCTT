-- phpMyAdmin SQL Dump
-- version 2.8.2.4
-- http://www.phpmyadmin.net
-- 
-- Host (domena): localhost
-- Vrijeme podizanja: 04. Tra 2007. u 10:19
-- Verzija servera: 5.0.24
-- verzija PHP-a: 5.1.6
-- 
-- Baza podataka: `timetable`
-- 

-- --------------------------------------------------------

-- 
-- Struktura tablice `tt_data`
-- 

DROP TABLE IF EXISTS `tt_data`;
CREATE TABLE IF NOT EXISTS `tt_data` (
  `tt_id` tinyint(3) unsigned NOT NULL auto_increment,
  `type` tinyint(3) unsigned NOT NULL,
  `institution_name` varchar(80) collate utf8_unicode_ci NOT NULL,
  `school_year` varchar(20) collate utf8_unicode_ci NOT NULL,
  `last_change` varchar(40) collate utf8_unicode_ci NOT NULL,
  PRIMARY KEY  (`tt_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;
