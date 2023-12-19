create database PianoEmulator;
use PianoEmulator;

create table if not exists Admins
(
	Id serial primary key not null,
	Login varchar(30) not null,
	Password varchar(30) not null
);

create table if not exists Users
(
	Id serial primary key not null,
	Login varchar(30) not null,
	Password varchar(30) not null
);

create table if not exists Recorded
(
	Id serial primary key not null,
	Name varchar(150) not null,
	Composition text not null
);

/*inserts*/

INSERT INTO users(login, password)
VALUES 
('user','user');

INSERT INTO admins(login, password)
VALUES 
('admin','admin');

