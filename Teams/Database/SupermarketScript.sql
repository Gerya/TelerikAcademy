SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;

SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;

SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';



CREATE SCHEMA IF NOT EXISTS `supermarket` DEFAULT CHARACTER SET utf8 ;

USE `supermarket` ;



-- -----------------------------------------------------

-- Table `supermarket`.`measures`

-- -----------------------------------------------------

CREATE  TABLE IF NOT EXISTS `supermarket`.`measures` (

  `ID` INT(11) NOT NULL ,

  `Name` VARCHAR(45) NOT NULL ,

  PRIMARY KEY (`ID`) ,

  UNIQUE INDEX `idMeasures_UNIQUE` (`ID` ASC) ,

  UNIQUE INDEX `Name_UNIQUE` (`Name` ASC) )

ENGINE = InnoDB

DEFAULT CHARACTER SET = utf8;





-- -----------------------------------------------------

-- Table `supermarket`.`vendors`

-- -----------------------------------------------------

CREATE  TABLE IF NOT EXISTS `supermarket`.`vendors` (

  `ID` INT(11) NOT NULL ,

  `Name` VARCHAR(45) NOT NULL ,

  PRIMARY KEY (`ID`) ,

  UNIQUE INDEX `Name_UNIQUE` (`Name` ASC) ,

  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )

ENGINE = InnoDB

DEFAULT CHARACTER SET = utf8;





-- -----------------------------------------------------

-- Table `supermarket`.`products`

-- -----------------------------------------------------

CREATE  TABLE IF NOT EXISTS `supermarket`.`products` (

  `ID` INT(11) NOT NULL AUTO_INCREMENT ,

  `Name` VARCHAR(45) NOT NULL ,

  `BasePrice` DECIMAL(10,2) NOT NULL ,

  `Vendor_ID` INT(11) NOT NULL ,

  `Measure_ID` INT(11) NOT NULL ,

  PRIMARY KEY (`ID`) ,

  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) ,

  UNIQUE INDEX `Name_UNIQUE` (`Name` ASC) ,

  INDEX `fk_Products_Vendors_idx` (`Vendor_ID` ASC) ,

  INDEX `fk_Products_Measures1_idx` (`Measure_ID` ASC) ,

  CONSTRAINT `fk_Products_Vendors`

    FOREIGN KEY (`Vendor_ID` )

    REFERENCES `supermarket`.`vendors` (`ID` )

    ON DELETE NO ACTION

    ON UPDATE NO ACTION,

  CONSTRAINT `fk_Products_Measures1`

    FOREIGN KEY (`Measure_ID` )

    REFERENCES `supermarket`.`measures` (`ID` )

    ON DELETE NO ACTION

    ON UPDATE NO ACTION)

ENGINE = InnoDB

DEFAULT CHARACTER SET = utf8;



USE `supermarket` ;





SET SQL_MODE=@OLD_SQL_MODE;

SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;

SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;