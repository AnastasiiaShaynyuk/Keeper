-- Active: 1682439245094@@SG-codework-7502-mysql-master.servers.mongodirector.com@3306@codeworks-final-checkpoint-keeper
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';


CREATE TABLE keeps(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  description TEXT,
  img VARCHAR(1000) NOT NULL,
  views INT NOT NULL DEFAULT 0,
  kept INT NOT NULL DEFAULT 0,
  creatorId VARCHAR(255) NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
)default charset utf8mb4 COMMENT '';