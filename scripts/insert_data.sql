insert into categories(createddate,isdelete,name) values('2022-08-03',false,'Edebiyat');
insert into categories(createddate,isdelete,name) values('2022-08-03',false,'Hobi');
insert into categories(createddate,isdelete,name) values('2022-08-03',false,'Ekonomi');
insert into categories(createddate,isdelete,name) values('2022-08-03',false,'Hukuk');

insert into authors (createddate,isdelete,firstname,lastname,age,country) values('2022-08-03',false,'Sabahattin','ALi',48,0);
insert into authors (createddate,isdelete,firstname,lastname,age,country) values('2022-08-03',false,'Doğan','Cüceloğlu',70,0);
insert into authors (createddate,isdelete,firstname,lastname,age,country) values('2022-08-03',false,'Zülfü','Livaneli',55,0);
insert into authors (createddate,isdelete,firstname,lastname,age,country) values('2022-08-03',false,'George','Orwell',37,1);

insert into books (createddate,isdelete,authorid,categoryid,printlenght ,publicationdate ,title ,description,language) 
values('2022-08-03',false,1,1,280,'2002-08-03','İçimizdeki Şeytan','Kitabın açıklaması',0);

insert into books (createddate,isdelete,authorid,categoryid,printlenght ,publicationdate ,title ,description,language) 
values('2022-08-03',false,2,1,472,'2002-08-03','İletişim Donanımları','Kitabın açıklaması',0);

insert into books (createddate,isdelete,authorid,categoryid,printlenght ,publicationdate ,title ,description,language) 
values('2022-08-03',false,3,2,165,'2002-08-03','Huzursuzluk','Kitabın açıklaması',0);

insert into books (createddate,isdelete,authorid,categoryid,printlenght ,publicationdate ,title ,description,language) 
values('2022-08-03',false,4,2,687,'2002-08-03','Günlükler2','Kitabın açıklaması',0);




