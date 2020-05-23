create table customers (
	id int not null identity(1, 1) primary key ,
	name varchar(100) not null,
	email varchar(100) not null,
	phone varchar(100)
)
