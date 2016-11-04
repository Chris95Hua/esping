-- phpMyAdmin SQL Dump
-- version 4.5.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 04, 2016 at 06:31 AM
-- Server version: 10.1.8-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `espring`
--

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `department_id` int(10) UNSIGNED NOT NULL,
  `name` varchar(64) NOT NULL,
  `c_user` int(10) UNSIGNED NOT NULL,
  `c_date` datetime NOT NULL,
  `e_user` int(10) UNSIGNED NOT NULL,
  `e_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `order_customer`
--

CREATE TABLE `order_customer` (
  `order_id` int(10) UNSIGNED NOT NULL,
  `order_name` varchar(64) NOT NULL,
  `salesperson_id` int(10) UNSIGNED NOT NULL,
  `customer` varchar(128) NOT NULL,
  `fabric` varchar(128) NOT NULL COMMENT 'Assumed to be string of text only',
  `collar` varchar(128) NOT NULL COMMENT 'Assumed to be string of text only',
  `cuff` varchar(128) NOT NULL COMMENT 'Assumed to be string of text only',
  `front` varchar(58) NOT NULL COMMENT 'Uses json string, assumed to be multiple values',
  `back` varchar(58) NOT NULL COMMENT 'Uses json string, assumed to be multiple values',
  `artwork` longblob NOT NULL COMMENT '4mb max',
  `size` varchar(128) NOT NULL COMMENT 'Uses json string, assumed to be multiple values',
  `material` varchar(128) NOT NULL COMMENT 'Uses json string, assumed to be multiple values',
  `colour` varchar(128) NOT NULL COMMENT 'Uses json string, assumed to be multiple values',
  `packaging` tinyint(1) UNSIGNED NOT NULL COMMENT '1 int to indicate chosen packaging',
  `issue_date` date NOT NULL,
  `delivery_date` date NOT NULL,
  `payment` varchar(64) NOT NULL COMMENT 'Uses json string',
  `remarks` varchar(255) NOT NULL,
  `approval` tinyint(1) UNSIGNED NOT NULL,
  `c_user` int(10) UNSIGNED NOT NULL,
  `c_date` datetime NOT NULL,
  `e_user` int(10) UNSIGNED NOT NULL,
  `e_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `order_log`
--

CREATE TABLE `order_log` (
  `log_id` int(10) UNSIGNED NOT NULL,
  `order_id` int(10) UNSIGNED NOT NULL,
  `datetime` datetime NOT NULL,
  `status` varchar(255) NOT NULL,
  `c_user` int(10) UNSIGNED NOT NULL,
  `e_user` int(10) UNSIGNED NOT NULL,
  `e_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL,
  `first_name` varchar(64) NOT NULL,
  `last_name` varchar(64) NOT NULL,
  `username` varchar(16) NOT NULL,
  `password` char(44) NOT NULL,
  `salt` char(44) NOT NULL,
  `department_id` int(11) NOT NULL,
  `c_user` int(10) UNSIGNED NOT NULL,
  `c_date` datetime NOT NULL,
  `e_user` int(10) UNSIGNED NOT NULL,
  `e_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_id`, `first_name`, `last_name`, `username`, `password`, `salt`, `department_id`, `c_user`, `c_date`, `e_user`, `e_date`) VALUES
(14, 'Zero', 'Gravity', 'chye yee', '8TBLmgdzOtg4zrO6TfPXQ7r6NWm2cipZQQe1QeonvDQ=', 'cAMOVSXZ+ej7FJuuRt7xTRHLr3sU2x7ZUg7Gl4+34D7o', 1, 0, '0000-00-00 00:00:00', 0, '0000-00-00 00:00:00');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`department_id`);

--
-- Indexes for table `order_customer`
--
ALTER TABLE `order_customer`
  ADD PRIMARY KEY (`order_id`);

--
-- Indexes for table `order_log`
--
ALTER TABLE `order_log`
  ADD PRIMARY KEY (`log_id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `department_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `order_customer`
--
ALTER TABLE `order_customer`
  MODIFY `order_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `order_log`
--
ALTER TABLE `order_log`
  MODIFY `log_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
