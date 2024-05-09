drop database if exists bdTest;
create database if not exists bdTest;

use bdTest;

Create Table Questionnaire
(
	cle varchar(12),
    nom varchar(40),
    displayName varchar(60),
    description varchar(124)
);

Create Table Reponses
(
	id int primary key auto_increment,
    cle_questionnaire varchar(12),
    rang int,
    dateCreation datetime,
    reponse varchar(250)
);

insert into Questionnaire values
('220224052603', 'Test 1', 'Display Test 1', 'Description Test 1'),
('240228055530', 'Test 2', 'Display Test 2', 'Description Test 2'),
('220224052922', 'Test 3', 'Display Test 3', 'Description Test 3');

select * from reponses;