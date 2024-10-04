CREATE SCHEMA minibank;
USE minibank;

create table
  `accounts` (
    `id` int not null auto_increment,
    `name` VARCHAR(255) not null,
    `balance` DECIMAL(15, 2) not null default 0,
    `create_date` DATETIME not null default NOW(),
    `update_date` DATETIME not null default NOW(),
    primary key (`id`)
  );
  
  create table
  `transactions` (
    `id` int not null auto_increment,
    `origin_account_id` INT not null,
    `value` DECIMAL(15, 2) not null,
    `operation_type` INT not null,
    `destination_account_id` INT null,
    `create_date` DATETIME not null default NOW(),
    `update_date` DATETIME not null default NOW(),
    primary key (`id`)
  );
  
 
ALTER TABLE
  `transactions`
ADD
  CONSTRAINT `origin_account_fk` FOREIGN KEY (`origin_account_id`) REFERENCES `accounts` (`id`) ON UPDATE NO ACTION ON DELETE NO ACTION;

ALTER TABLE
  `transactions`
ADD
  CONSTRAINT `destination_account_fk` FOREIGN KEY (`destination_account_id`) REFERENCES `accounts` (`id`) ON UPDATE NO ACTION ON DELETE NO ACTION


