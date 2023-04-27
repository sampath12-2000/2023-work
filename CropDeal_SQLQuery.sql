use CropDealDatabase
---Crop Deal Management Database
--create database first
create database CropDealDatabase;

--now create tables
--create ADMIN table
CREATE TABLE Admin (
    AdminID INT PRIMARY KEY IDENTITY (100, 1),
    AdminUserName VARCHAR (50) NOT NULL,
    AdminPassword Varchar (50) NOT NULL
 );

--inserting some data in admin table
insert into admin values('Admin','Admin123');
--checking
select *from Admin;

----create user table
create table UserProfile(
UserID int primary key identity(200,1),
UserName varchar (50) not null,
UserEmail varchar (50) not null,
UserPhoneNo varchar (30) not null unique,
UserAddress varchar (200) not null,
UserPassword varchar (50) not null,
UserType varchar (50) check(UserType in ('Farmer','User')),
UserAccNo int not null unique,
UserIFSC varchar (20) not null unique,
UserBankName varchar (20) not null,
UserStatus varchar (20) check(UserStatus in ('Active','Inactive')) default 'Active'
);
---inserting data into user table
insert into UserProfile values('Admin','admin@gmail.com','9898776523','Vizag','admin1','Admin',345624735,'HDFC0291','HDFC','Active');

---displaying
select *from UserProfile;

-------crop table
create table Crop(
CropID int primary key identity(300,1),
CropName varchar (50) not null,
CropImage varchar (250) not null
);
---inserting data into crop table
insert into Crop values('Cabbage','link of the image');
---displaying
select *from crop;
delete from crop where CropID=312

---- create CropOnSale table
Create table CropOnSale(
CropSaleID int primary key identity(400,1),
CropID int,
Constraint fk_CropID Foreign Key(CropID) references Crop(CropID),
CropName varchar (50) not null,
CropType varchar (50) check(CropType in ('Vegetable','Fruit')),
CropQty int not null,
CropPrice float not null,
FarmerID int,
Constraint fk_FarmerID Foreign Key (FarmerID) references UserProfile(UserID),
);
----inserting values into CropOnSale table
insert into CropOnSale values(300,'Apple','Fruit',10,25,200);
------displaying
select *from CropOnSale;


--create invoice table
create table Invoice(
InvoiceID int primary key identity(500,1),
OrderDate date not null,
FarmerID int,
Constraint fk_FarmerID1 Foreign Key (FarmerID) references UserProfile(UserID),
DealerID int,
constraint fk_DealerID1 foreign key (DealerID) references UserProfile(UserID),
CropName varchar (50) not null,
CropType varchar(50) check(CropType in ('Vegetable','Fruit')),
CropQty int not null,
OrderTotal float not null,
Review varchar(250)
);
select *from Invoice;

alter table UserProfile alter column UserAccNo  bigint;

alter table UserProfile drop constraint UQ__UserProf__01507BF274C41D9F;
alter table UserProfile alter column UserAccNo bigint not null;
ALTER TABLE UserProfile ADD UNIQUE (UserAccNo); 

--alter table UserProfile alter column UserAccNo bigint not null;