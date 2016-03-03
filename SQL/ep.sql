-- phpMyAdmin SQL Dump
-- version 2.8.2.4
-- http://www.phpmyadmin.net
-- 
-- Host (domena): localhost
-- Vrijeme podizanja: 03. Tra 2007. u 12:21
-- Verzija servera: 5.0.24
-- verzija PHP-a: 5.1.6
-- 
-- Baza podataka: `timetable`
-- 

-- --------------------------------------------------------

-- 
-- Struktura tablice `ep`
-- 

DROP TABLE IF EXISTS `ep`;
CREATE TABLE IF NOT EXISTS `ep` (
  `ep_id` tinyint(3) unsigned NOT NULL auto_increment,
  `name` varchar(50) collate utf8_unicode_ci NOT NULL,
  `code` varchar(10) collate utf8_unicode_ci default NULL,
  `semester` varchar(10) collate utf8_unicode_ci NOT NULL,
  `ext_id` int(10) unsigned default NULL,
  `epg_id` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY  (`ep_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;
