create database MiniCoreCompras
use MiniCoreCompras
 
create table clientes (
	idCliente int not null Primary Key IDENTITY(1,1),
	NombreCliente varchar(500) not null
)

create table Contratos(
	idContrato int not null Primary Key IDENTITY(1,1),
	idCliente int not null ,
	contratos varchar(900) not null,
	Monto int not null,
	fechaContrato Date not null,
	CONSTRAINT FK_PersonOrder FOREIGN KEY (idCliente) references clientes(idCliente)
)


insert into clientes values ( 'Udla')
insert into clientes values ('Pichincha')
insert into clientes values ('Casa Tosi')
insert into clientes values ('Pica ')

select * from clientes
insert into Contratos values (1,'Creacion de terrazas',400,'2023-01-10')
insert into Contratos values (1,'Creacion de terrazas',600,'2023-01-10')
insert into Contratos values (2,'atm en exteriores',900,'2023-01-10')
insert into Contratos values (2,'agencia interna',1400,'2023-01-10')
select * from contratos


select a.NombreCliente, sum(c.Monto) from Contratos c
inner join clientes a on c.idCliente = a.idCliente
where fechaContrato ='2023-01-10'
group by a.NombreCliente
