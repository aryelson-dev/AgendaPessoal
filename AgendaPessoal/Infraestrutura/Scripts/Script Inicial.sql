use[master]
go

--create database agenda
--go

use[agenda]
go

create table Endereco
(
	Id uniqueidentifier primary key not null,
	Cep bigint not null,
	Rua varchar(300) not null,
	Numero varchar(10),
	Complemento varchar(max),
	Bairro varchar(200) not null,
	Cidade varchar(300) not null,
	Estado varchar(2) not null,
)

create table Contato
(
	Id uniqueidentifier primary key not null,
	Nome varchar(300) not null,
	Telefone1 varchar(50),
	Telefone2 varchar(50),
	Email varchar(300),
	DataNascimento datetime,
	EnderecoId uniqueidentifier,

	Foreign Key(EnderecoId) References Endereco(Id)
)