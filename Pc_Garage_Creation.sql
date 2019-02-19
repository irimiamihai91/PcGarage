CREATE TABLE Member
(
MemberId int primary key not null identity(1,1),
Username varchar (100) not null,
Password varchar(100) not null,
Email varchar(100) not null,
FullName varchar(100) not null,
Address varchar (100) not null,
Phone varchar(20) not null,
BirthDate date,

)

CREATE TABLE Category
(
CategoryId int primary key not null identity(1,1),
CategoryName varchar (25) not null,

)

Create table Manufacturer 
(
ManufacturerId int primary key not null identity(1,1),
ManufacturerName varchar(25) not null,
)

CREATE TABLE Product
(
ProductId int primary key not null identity(1,1),
ProductName varchar (100) not null,
CategoryId int not null,
ManufacturerId int not null,
Description varchar (max),
Stock int not null, -- trigger--
Price decimal not null,
Display varchar (max),
Processor varchar (max),
Memory varchar (max),
VideoMemory varchar (max),
HDD varchar (max),
Camera varchar (200),

Constraint FK_Manufacturer_PRODUCT_ManufacturerId Foreign Key(ManufacturerId) References Manufacturer(ManufacturerId),
Constraint FK_CATEGORY_PRODUCT_CategoryId Foreign Key(CategoryId) References Category(CategoryId)
)

Create table Cart
(
CartId int not null primary key identity(1,1),
MemberId int not null,
ProductId int not null,
Quantity int not null,

Constraint FK_Member_Cart_MemberId Foreign Key(MemberId) References Member(MemberId),
Constraint FK_Product_Cart_ProductId Foreign Key(ProductId) References Product(ProductId)
)
Create Table Rating
(
RatingId int primary key not null identity(1,1),
MemberId int not null,
ProductId int not null,
Rate int not null,

Constraint FK_Member_Rating_MemberId Foreign Key(MemberId) References Member(MemberId),
Constraint FK_Product_Rating_ProductId Foreign Key(ProductId) References Product(ProductId)
)

Create table Transactions
(
TransactionId int primary key identity(1,1) not null,
MemberId int not null,
ProductId int not null,
Quantity int not null,
Status varchar(25),

Constraint FK_Member_Transaction_MemberId Foreign Key(MemberId) References Member(MemberId),
Constraint FK_Product_Transaction_ProductId Foreign Key(ProductId) References Product(ProductId)
)

Create table Card
(
CardId int primary key not null identity(1,1),
MemberId int not null,
NameOnCard varchar(50) not null,
CardNumber int not null,
CVC int not null,
ExpirationDate date,

Constraint FK_Member_Card_MemberId Foreign Key(MemberId) References Member(MemberId),
)