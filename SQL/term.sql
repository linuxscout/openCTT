-- phpMyAdmin SQL Dump
-- version 2.8.2.4
-- http://www.phpmyadmin.net
-- 
-- Host (domena): localhost
-- Vrijeme podizanja: 02. Tra 2007. u 15:56
-- Verzija servera: 5.0.24
-- verzija PHP-a: 5.1.6
-- 
-- Baza podataka: `timetable`
-- 

-- --------------------------------------------------------

-- 
-- Struktura tablice `term`
-- 

DROP TABLE IF EXISTS `term`;
CREATE TABLE IF NOT EXISTS `term` (
  `term_id` smallint(5) unsigned NOT NULL auto_increment,
  `start_h` tinyint(3) unsigned NOT NULL,
  `start_min` tinyint(3) unsigned NOT NULL,
  `end_h` tinyint(3) unsigned NOT NULL,
  `end_min` tinyint(3) unsigned NOT NULL,
  `term_index` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY  (`term_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;
