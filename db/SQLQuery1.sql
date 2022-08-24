
create table Category (
	CatID int identity(1,1) not null,
	CatName varchar(30),
	primary key (CatID)
);
SET IDENTITY_INSERT Category ON
GO
create table Product (
	ProdID nvarchar(20) not null,
	CatID int not null,
	Description_ varchar(200),
	UnitPrice float not null,
	primary key (ProdID),
	foreign key (CatID) references Category(CatID)
);
GO
create table Segment (
	SegtID int not null,
	SegName varchar(30),
	primary key(SegtID)
);
GO
create table Region (
	Region varchar(20) not null
	primary key (Region)
);
GO
create table Customer (
	CustID nvarchar(20) not null,
	FullName varchar(20),
	SegID int not null,
	Country varchar(20),
	City varchar(20),
	State_ varchar(20),
	PostCode varchar(4),
	Region varchar(20),
	primary key (CustID),
	foreign key (SegID) references Segment(SegtID),
	foreign key (Region) references Region(Region)
);
GO
create table Shipping (
	ShipMode varchar(20) not null
	primary key (ShipMode)
);
GO

create table Order_ (
	OrderID int identity(1,1) not null,
	CustID nvarchar(20) not null,
	ProdID nvarchar(20) not null,
	OrderDate nvarchar(20) not null,
	Quantity int,
	ShipDate nvarchar(20),
	ShipMode varchar(20),
	primary key (OrderID),
	-- unique(CustID, ProdID, OrderDate),
	foreign key (CustID) references Customer(CustID),
	foreign key (ProdID) references Product(ProdID),
	foreign key (ShipMode) references Shipping(ShipMode)
);
GO

INSERT INTO Category(CatID,CatName) VALUES ('1', 'Furniture');
INSERT INTO Category (CatID,CatName) VALUES ('2', 'Office Supplies');
INSERT INTO Category (CatID,CatName) VALUES ('3', 'Technology');
GO
INSERT INTO Segment (SegtID,SegName) VALUES ('1', 'Consumer');
INSERT INTO Segment (SegtID,SegName) VALUES ('2', 'Corporate');
INSERT INTO Segment (SegtID,SegName) VALUES ('3', 'Home Office');
GO
INSERT INTO Product (ProdID,CatID,Description_,UnitPrice) VALUES ('FUR-BO-10001798', '1', 'Bush Somerset Collection Bookcase', '261.96');
INSERT INTO Product (ProdID,CatID,Description_,UnitPrice) VALUES ('FUR-CH-10000454', '3', 'Mitel 5320 IP Phone VoIP phone', '731.94');
INSERT INTO Product (ProdID,CatID,Description_,UnitPrice) VALUES ('OFF-LA-10000240', '2', 'Self-Adhesive Address Labels for Typewriters by Universal', '14.62');
GO
INSERT INTO Customer (CustID,FullName,SegID,Country,City,State_,Region,PostCode) VALUES ('CG-12520', 'Claire Gute', '1', 'United States', 'Henderson', 'Oklahoma', 'Central', '42420');
INSERT INTO Customer (CustID,FullName,SegID,Country,City,State_,Region,PostCode) VALUES ('DV-13045', 'Darrin Van Huff', '2', 'United States', 'Los Angeles', 'California', 'West', '90036');
INSERT INTO Customer (CustID,FullName,SegID,Country,City,State_,Region,PostCode) VALUES ('SO-20335', 'Sean ODonnell', '1', 'United States', 'Fort Lauderdale', 'Florida', 'South', '33311');
INSERT INTO Customer (CustID,FullName,SegID,Country,City,State_,Region,PostCode) VALUES ('BH-11710', 'Brosina Hoffman', '3', 'United States', 'Los Angeles', 'California', 'West', '90032');
GO
INSERT INTO Order_ (CustID,ProdID,OrderDate,Quantity, ShipDate,ShipMode) VALUES ('CG-12520', 'FUR-BO-10001798', '11/8/16', '2', '11/11/16', 'Second Class');
INSERT INTO Order_ (CustID ,ProdID ,OrderDate,Quantity, ShipDate,ShipMode) VALUES ('CG-12520', 'FUR-CH-10000454', '11/8/16', '3', '11/11/16', 'Second Class');
INSERT INTO Order_ (CustID ,ProdID ,OrderDate,Quantity, ShipDate,ShipMode) VALUES ('CG-12520', 'OFF-LA-10000240', '6/12/16', '2', '6/16/16', 'Second Class');
INSERT INTO Order_ (CustID ,ProdID ,OrderDate,Quantity, ShipDate,ShipMode) VALUES ('DV-13045', 'OFF-LA-10000240', '11/21/15', '2', '11/26/15', 'Second Class');
INSERT INTO Order_ (CustID ,ProdID ,OrderDate,Quantity, ShipDate,ShipMode) VALUES ('DV-13045', 'OFF-LA-10000240', '10/11/14', '1', '10/15/14', 'Standard Class');
INSERT INTO Order_ (CustID ,ProdID ,OrderDate,Quantity, ShipDate,ShipMode) VALUES ('DV-13045', 'FUR-CH-10000454', '11/12/16', '9', '11/16/16', 'Standard Class');
INSERT INTO Order_ (CustID ,ProdID ,OrderDate,Quantity, ShipDate,ShipMode) VALUES ('SO-20335', 'OFF-LA-10000240', '9/2/16', '5', '9/8/16', 'Standard Class');
INSERT INTO Order_ (CustID ,ProdID ,OrderDate,Quantity, ShipDate,ShipMode) VALUES ('SO-20335', 'FUR-BO-10001798', '8/25/17', '2', '8/29/17', 'Overnight Express');
INSERT INTO Order_ (CustID,ProdID ,OrderDate,Quantity, ShipDate,ShipMode) VALUES ('SO-20335', 'FUR-CH-10000454', '6/22/17', '2', '6/26/17', 'Standard Class');
INSERT INTO Order_ (CustID ,ProdID ,OrderDate,Quantity, ShipDate,ShipMode) VALUES ('SO-20335', 'FUR-BO-10001798', '5/1/17', '3', '5/2/17', 'First Class');
GO
INSERT INTO Shipping (ShipMode) VALUES ('Second Class');
INSERT INTO Shipping (ShipMode) VALUES ('Standard Class');
INSERT INTO Shipping (ShipMode) VALUES ('First Class');
INSERT INTO Shipping (ShipMode) VALUES ('Overnight Express');
GO
INSERT INTO Region (Region) VALUES ('South');
INSERT INTO Region (Region) VALUES ('Central');
INSERT INTO Region (Region) VALUES ('West');
INSERT INTO Region (Region) VALUES ('East');
INSERT INTO Region (Region) VALUES ('North');

