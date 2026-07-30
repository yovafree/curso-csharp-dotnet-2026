CREATE TABLE `curso_db`.`nota` (
  `cod_nota` INT NOT NULL AUTO_INCREMENT,
  `nota` INT NOT NULL DEFAULT 0,
  `cod_curso` INT NOT NULL,
  `cod_estudiante` INT NOT NULL,
  PRIMARY KEY (`cod_nota`),
  INDEX `fk_curso_nota_idx` (`cod_curso` ASC) VISIBLE,
  INDEX `fk_estudiante_curso_idx` (`cod_estudiante` ASC) VISIBLE,
  CONSTRAINT `fk_curso_nota`
    FOREIGN KEY (`cod_curso`)
    REFERENCES `curso_db`.`curso` (`cod_curso`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_estudiante_curso`
    FOREIGN KEY (`cod_estudiante`)
    REFERENCES `curso_db`.`estudiante` (`cod_estudiante`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

ALTER TABLE `curso_db`.`nota` 
ADD COLUMN `estado` INT NOT NULL DEFAULT 1 AFTER `cod_estudiante`;
