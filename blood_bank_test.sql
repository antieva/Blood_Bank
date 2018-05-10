-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 11, 2018 at 01:55 AM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `blood_bank_test`
--
CREATE DATABASE IF NOT EXISTS `blood_bank_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `blood_bank_test`;

-- --------------------------------------------------------

--
-- Table structure for table `blood_banks`
--

CREATE TABLE `blood_banks` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `contact` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `donors`
--

CREATE TABLE `donors` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `contact` varchar(255) NOT NULL,
  `dateOfBirth` varchar(11) NOT NULL,
  `bloodType` varchar(11) NOT NULL,
  `medicalRecord` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- --------------------------------------------------------

--
-- Table structure for table `donors_bloodBanks`
--

CREATE TABLE `donors_bloodBanks` (
  `id` int(11) NOT NULL,
  `donor_id` int(11) NOT NULL,
  `bloodBank_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `donors_bloodBanks`
--

INSERT INTO `donors_bloodBanks` (`id`, `donor_id`, `bloodBank_id`) VALUES
(1, 9, 18),
(2, 12, 20),
(3, 15, 22),
(5, 19, 25),
(7, 23, 28),
(9, 28, 31),
(11, 34, 34),
(13, 41, 37),
(15, 48, 40),
(17, 55, 43),
(19, 62, 46),
(21, 69, 49),
(23, 76, 52),
(25, 83, 55),
(27, 90, 58),
(29, 97, 61);

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE `patients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `contact` varchar(255) NOT NULL,
  `dateOfBirth` varchar(255) NOT NULL,
  `bloodType` varchar(11) NOT NULL,
  `ds` varchar(255) NOT NULL,
  `urgent` bit(1) NOT NULL,
  `needBlood` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- --------------------------------------------------------

--
-- Table structure for table `patients_donors`
--

CREATE TABLE `patients_donors` (
  `id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL,
  `donor_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `patients_donors`
--

INSERT INTO `patients_donors` (`id`, `patient_id`, `donor_id`) VALUES
(1, 5, 2),
(2, 7, 3),
(3, 9, 4),
(4, 11, 5),
(6, 14, 7),
(8, 17, 10),
(10, 20, 13),
(12, 23, 17),
(14, 26, 21),
(16, 29, 25),
(17, 30, 26),
(19, 33, 30),
(20, 34, 32),
(22, 37, 36),
(24, 39, 39),
(26, 42, 43),
(28, 44, 46),
(30, 47, 50),
(32, 49, 53),
(34, 52, 57),
(36, 54, 60),
(38, 57, 64),
(40, 59, 67),
(42, 62, 71),
(44, 64, 74),
(46, 67, 78),
(48, 69, 81),
(50, 72, 85),
(52, 74, 88),
(54, 79, 92),
(56, 81, 95),
(58, 86, 99),
(60, 88, 104);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `blood_banks`
--
ALTER TABLE `blood_banks`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `donors`
--
ALTER TABLE `donors`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `donors_bloodBanks`
--
ALTER TABLE `donors_bloodBanks`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patients_donors`
--
ALTER TABLE `patients_donors`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `blood_banks`
--
ALTER TABLE `blood_banks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;
--
-- AUTO_INCREMENT for table `donors`
--
ALTER TABLE `donors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=106;
--
-- AUTO_INCREMENT for table `donors_bloodBanks`
--
ALTER TABLE `donors_bloodBanks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;
--
-- AUTO_INCREMENT for table `patients`
--
ALTER TABLE `patients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=93;
--
-- AUTO_INCREMENT for table `patients_donors`
--
ALTER TABLE `patients_donors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=62;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
