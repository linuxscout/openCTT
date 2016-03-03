-- phpMyAdmin SQL Dump
-- version 2.8.2.4
-- http://www.phpmyadmin.net
-- 
-- Host (domena): localhost
-- Vrijeme podizanja: 03. Tra 2007. u 12:37
-- Verzija servera: 5.0.24
-- verzija PHP-a: 5.1.6
-- 
-- Baza podataka: `timetable`
-- 

-- --------------------------------------------------------

-- 
-- Struktura tablice `course`
-- 

DROP TABLE IF EXISTS `course`;
CREATE TABLE IF NOT EXISTS `course` (
  `course_id` int(10) unsigned NOT NULL auto_increment,
  `name` varchar(70) collate utf8_unicode_ci NOT NULL,
  `short_name` varchar(70) collate utf8_unicode_ci NOT NULL,
  `group_name` varchar(15) collate utf8_unicode_ci default NULL,
  `course_type` varchar(40) NOT NULL,
  `numoflessperweek` int(10) unsigned NOT NULL,
  `ext_id` int(10) unsigned default NULL,
  `ep_id` tinyint(3) unsigned NOT NULL,
  `teacher_id` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY  (`course_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;
