-- phpMyAdmin SQL Dump
-- version 2.8.2.4
-- http://www.phpmyadmin.net
-- 
-- Host (domena): localhost
-- Vrijeme podizanja: 03. Tra 2007. u 12:46
-- Verzija servera: 5.0.24
-- verzija PHP-a: 5.1.6
-- 
-- Baza podataka: `timetable`
-- 

-- --------------------------------------------------------

-- 
-- Struktura tablice `allocated_lesson`
-- 

DROP TABLE IF EXISTS `allocated_lesson`;
CREATE TABLE IF NOT EXISTS `allocated_lesson` (
  `allocless_id` int(10) unsigned NOT NULL auto_increment,
  `course_id` tinyint(3) unsigned NOT NULL,
  `room_id` tinyint(3) unsigned NOT NULL,
  `day_id` tinyint(3) unsigned NOT NULL,
  `term_id` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY  (`allocless_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;
