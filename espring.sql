-- phpMyAdmin SQL Dump
-- version 4.5.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 15, 2016 at 09:30 AM
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
  `e_user` int(10) UNSIGNED DEFAULT NULL,
  `e_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`department_id`, `name`, `c_user`, `c_date`, `e_user`, `e_date`) VALUES
(1, 'Approval Department', 1, '2016-11-09 00:00:00', NULL, NULL),
(2, 'Cutting Department', 1, '2016-11-09 00:00:00', NULL, NULL),
(3, 'Embroidery Department', 1, '2016-11-09 00:00:00', NULL, NULL),
(4, 'Inventory Preparation', 1, '2016-11-09 00:00:00', NULL, NULL),
(5, 'Order Department', 1, '2016-11-09 00:00:00', NULL, NULL),
(6, 'Printing Department', 1, '2016-11-09 00:00:00', NULL, NULL),
(7, 'Sewing Department', 1, '2016-11-09 00:00:00', NULL, NULL);

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
  `collar` int(10) UNSIGNED NOT NULL,
  `cuff` int(10) UNSIGNED NOT NULL,
  `front` varchar(70) NOT NULL COMMENT 'Uses json string, assumed to be multiple values',
  `back` varchar(70) NOT NULL COMMENT 'Uses json string, assumed to be multiple values',
  `artwork` char(51) DEFAULT NULL,
  `size` varchar(128) NOT NULL COMMENT 'Uses json string, assumed to be multiple values',
  `material` varchar(128) NOT NULL,
  `colour` varchar(128) NOT NULL,
  `packaging` varchar(128) NOT NULL,
  `issue_date` date NOT NULL,
  `delivery_date` date NOT NULL,
  `payment` varchar(32) NOT NULL COMMENT 'Uses json string',
  `amount` int(10) UNSIGNED NOT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  `approval` tinyint(1) UNSIGNED DEFAULT '0',
  `inventory` tinyint(1) UNSIGNED DEFAULT '0',
  `cutting` tinyint(1) UNSIGNED DEFAULT '0',
  `embroidery` tinyint(1) UNSIGNED DEFAULT '0',
  `printing` tinyint(1) UNSIGNED DEFAULT '0',
  `sewing` tinyint(1) UNSIGNED NOT NULL DEFAULT '0',
  `e_user` int(10) UNSIGNED DEFAULT NULL,
  `e_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `order_customer`
--

INSERT INTO `order_customer` (`order_id`, `order_name`, `salesperson_id`, `customer`, `fabric`, `collar`, `cuff`, `front`, `back`, `artwork`, `size`, `material`, `colour`, `packaging`, `issue_date`, `delivery_date`, `payment`, `amount`, `remarks`, `approval`, `inventory`, `cutting`, `embroidery`, `printing`, `sewing`, `e_user`, `e_date`) VALUES
(1, 'test', 1, 'Nelson', '{"fabric":1}', 3, 4, '{"printing":1,"heat":1}', '{"printing":1,"heat":1}', 'stuff', '{"xs":3,"l":4,"xl":2,"3xl":4}', 'Cotton', 'Pink', '{"normal":1,"sugerbag":1}', '2016-11-08', '2016-12-14', '{"cash":1}', 120, NULL, 0, 0, 0, 0, 1, 0, NULL, '2016-11-09 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `order_log`
--

CREATE TABLE `order_log` (
  `log_id` int(10) UNSIGNED NOT NULL,
  `order_id` int(10) UNSIGNED NOT NULL,
  `department_id` int(10) NOT NULL,
  `datetime` datetime NOT NULL,
  `status` varchar(255) NOT NULL,
  `c_user` int(10) UNSIGNED NOT NULL,
  `e_user` int(10) UNSIGNED DEFAULT NULL,
  `e_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `order_log`
--

INSERT INTO `order_log` (`log_id`, `order_id`, `department_id`, `datetime`, `status`, `c_user`, `e_user`, `e_date`) VALUES
(1, 1, 0, '2016-11-08 12:08:00', 'Processing', 1, NULL, NULL),
(2, 1, 0, '2016-11-11 15:54:44', 'Check out', 0, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `role`
--

CREATE TABLE `role` (
  `role_id` int(10) UNSIGNED NOT NULL,
  `title` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `status`
--

CREATE TABLE `status` (
  `check_id` int(11) NOT NULL,
  `status_id` tinyint(1) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `status`
--

INSERT INTO `status` (`check_id`, `status_id`, `status`) VALUES
(1, 1, 'Check-IN'),
(2, 2, 'Check-OUT'),
(3, 0, 'Processing'),
(4, 3, 'Approved'),
(5, 4, 'Rejected');

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
  `role` int(10) UNSIGNED NOT NULL,
  `department_id` int(11) NOT NULL,
  `c_user` int(10) UNSIGNED NOT NULL,
  `c_date` datetime NOT NULL,
  `e_user` int(10) UNSIGNED DEFAULT NULL,
  `e_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_id`, `first_name`, `last_name`, `username`, `password`, `salt`, `role`, `department_id`, `c_user`, `c_date`, `e_user`, `e_date`) VALUES
(1, 'Zero', 'Gravity', 'admin', '8TBLmgdzOtg4zrO6TfPXQ7r6NWm2cipZQQe1QeonvDQ=', 'cAMOVSXZ+ej7FJuuRt7xTRHLr3sU2x7ZUg7Gl4+34D7o', 0, 1, 0, '2016-11-07 00:00:00', 0, '0000-00-00 00:00:00');

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
  ADD PRIMARY KEY (`log_id`),
  ADD KEY `order_id` (`order_id`);

--
-- Indexes for table `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`role_id`);

--
-- Indexes for table `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`check_id`);

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
  MODIFY `department_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `order_customer`
--
ALTER TABLE `order_customer`
  MODIFY `order_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `order_log`
--
ALTER TABLE `order_log`
  MODIFY `log_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `role`
--
ALTER TABLE `role`
  MODIFY `role_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `status`
--
ALTER TABLE `status`
  MODIFY `check_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `order_log`
--
ALTER TABLE `order_log`
  ADD CONSTRAINT `order_log_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `order_customer` (`order_id`) ON DELETE CASCADE ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
