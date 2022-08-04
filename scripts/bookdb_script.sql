create table books(
	id serial primary key not null,
	authorid int not null,
	categoryid int not null,
	createddate date,
	updateddate date,
	isdelete boolean,
	printlenght int,
	publicationdate date,
	title text,
	description text,
	language int,
	CONSTRAINT fk_author FOREIGN KEY(authorid) REFERENCES authors(id),
	CONSTRAINT fk_category FOREIGN KEY(categoryid) REFERENCES categories(id)
);


create table authors(
	id serial primary key not null,
	createddate date,
	updateddate date,
	isdelete boolean,
	firstname text,
	lastname text,
	age int,
	country int
);

create table categories(
	id serial primary key not null,
	createddate date,
	updateddate date,
	isdelete boolean,
	name text
);

create table comments(
	id serial primary key not null,
	authorid int not null,
	bookid int not null,
	createddate date,
	updateddate date,
	isdelete boolean,
	title text,
	description text,
	CONSTRAINT fk_author FOREIGN KEY(authorid) REFERENCES authors(id),
	CONSTRAINT fk_book FOREIGN KEY(bookid) REFERENCES books(id)
);

create table images(
	id serial primary key not null,
	bookid int not null,
	createddate date,
	updateddate date,
	isdelete boolean,
	url text,
	CONSTRAINT fk_book FOREIGN KEY(bookid) REFERENCES books(id)
);