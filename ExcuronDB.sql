SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


-- Database: `ExcuronDB`

CREATE TABLE IF NOT EXISTS `RegistrationTable` (
  `DBUserID` int(11) NOT NULL,
  `DBEmail` varchar(50) DEFAULT NULL,
  `DBPassword` varchar(20) DEFAULT NULL,
  `RegDate` datetime DEFAULT NULL,
  `LastLogDate` datetime DEFAULT NULL,
  `WalletID` int(11) NOT NULL,
  PRIMARY KEY (`DBUserID`,`WalletID`),
  UNIQUE KEY `DBUserID` (`DBUserID`),
  UNIQUE KEY `Wallet` (`WalletID`),
  UNIQUE KEY `DBEmail` (`DBEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



CREATE TABLE IF NOT EXISTS `WalletTable` (
  `WalletID` int(11) NOT NULL,
  `DBUserID` int(11) DEFAULT NULL,
  `WalletName` varchar(20) DEFAULT NULL,
  `Wanted` varchar(16) DEFAULT 'EURUSDTRY',
  `EUR` double DEFAULT '0',
  `USD` double DEFAULT '0',
  `JPY` double DEFAULT '0',
  `BGN` double DEFAULT '0',
  `CZK` double DEFAULT '0',
  `DKK` double DEFAULT '0',
  `GBP` double DEFAULT '0',
  `HUF` double DEFAULT '0',
  `PLN` double DEFAULT '0',
  `RON` double DEFAULT '0',
  `SEK` double DEFAULT '0',
  `CHF` double DEFAULT '0',
  `NOK` double DEFAULT '0',
  `HRK` double DEFAULT '0',
  `RUB` double DEFAULT '0',
  `TRY` double DEFAULT '0',
  `AUD` double DEFAULT '0',
  `BRL` double DEFAULT '0',
  `CAD` double DEFAULT '0',
  `CNY` double DEFAULT '0',
  `HKD` double DEFAULT '0',
  `IDR` double DEFAULT '0',
  `ILS` double DEFAULT '0',
  `INR` double DEFAULT '0',
  `KRW` double DEFAULT '0',
  `MXN` double DEFAULT '0',
  `MYR` double DEFAULT '0',
  `NZD` double DEFAULT '0',
  `PHP` double DEFAULT '0',
  `SGD` double DEFAULT '0',
  `THB` double DEFAULT '0',
  `ZAR` double DEFAULT '0',
  PRIMARY KEY (`WalletID`),
  UNIQUE KEY `Wallet` (`WalletID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

