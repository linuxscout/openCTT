-- phpMyAdmin SQL Dump
-- version 2.8.2.4
-- http://www.phpmyadmin.net
-- 
-- Host (domena): localhost
-- Vrijeme podizanja: 03. Tra 2007. u 11:52
-- Verzija servera: 5.0.24
-- verzija PHP-a: 5.1.6
-- 
-- Baza podataka: `timetable`
-- 

-- --------------------------------------------------------

-- 
-- Struktura tablice `epg`
-- 

DROP TABLE IF EXISTS `epg`;
CREATE TABLE IF NOT EXISTS `epg` (
  `epg_id` tinyint(3) unsigned NOT NULL auto_increment,
  `name` varchar(80) collate utf8_unicode_ci NOT NULL,
  `ext_id` int(10) unsigned default NULL,
  PRIMARY KEY  (`epg_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;
