create table `wekelly3_phpdemo`.`Movies` (
	`MovieId` int not null auto_increment,
	`Movie` text not null,
	primary key(MovieId)
);

select * from Movies;

insert into Movies (Movie) values ("Raiders of the Lost PHP");
insert into Movies (Movie) values ("Return of the Script");
insert into Movies (Movie) values ("PHP: The Extra-Terrestrial");


-- delete from Movies;