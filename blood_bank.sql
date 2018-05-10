-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 11, 2018 at 01:52 AM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `blood_bank`
--
CREATE DATABASE IF NOT EXISTS `blood_bank` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `blood_bank`;

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

--
-- Dumping data for table `donors`
--

INSERT INTO `donors` (`id`, `name`, `contact`, `dateOfBirth`, `bloodType`, `medicalRecord`) VALUES
(1, 'Mindy Hu ', '980-213-1122', '11/07/87', 'O-', 'healthy '),
(2, 'Eric Nicolas', '890-567-0000', '06/17/85', 'A+', 'unhealthy attitude');

-- --------------------------------------------------------

--
-- Table structure for table `donors_bloodBanks`
--

CREATE TABLE `donors_bloodBanks` (
  `id` int(11) NOT NULL,
  `donor_id` int(11) NOT NULL,
  `bloodBank_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

--
-- Dumping data for table `patients`
--

INSERT INTO `patients` (`id`, `name`, `contact`, `dateOfBirth`, `bloodType`, `ds`, `urgent`, `needBlood`) VALUES
(1, 'John Doe', '425-974-8080', '09/12/92', '0+', 'Heamolitic shock', b'0', b'1'),
(2, 'Jeck Green', '206-880-9090', '09/09/86', 'AB-', 'Heamolitic shock', b'0', b'0'),
(4, 'Jill Bing', '425-999-0000', '08/12/99', 'B+', 'Ds', b'1', b'0');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `donors`
--
ALTER TABLE `donors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `donors_bloodBanks`
--
ALTER TABLE `donors_bloodBanks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `patients`
--
ALTER TABLE `patients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `patients_donors`
--
ALTER TABLE `patients_donors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
