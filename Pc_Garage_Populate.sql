Insert into Manufacturer(ManufacturerName) Values ('Lenovo');
Insert into Manufacturer(ManufacturerName) Values ('HP');
Insert into Manufacturer(ManufacturerName) Values ('Dell');
Insert into Manufacturer(ManufacturerName) Values ('Apple');
Insert into Manufacturer(ManufacturerName) Values ('Acer');
Insert into Manufacturer(ManufacturerName) Values ('Asus');
Insert into Manufacturer(ManufacturerName) Values ('Samsung');
Insert into Manufacturer(ManufacturerName) Values ('Sony');
Insert into Manufacturer(ManufacturerName) Values ('Huawei');

Insert into Category(CategoryName) Values ('Laptop');
Insert into Category(CategoryName) Values ('Laptop Gamming');
Insert into Category(CategoryName) Values ('Telefon');
Insert into Category(CategoryName) Values ('Tableta');

Insert into Product(ProductName,CategoryId,ManufacturerId,Description,Stock,Price,Display,Processor,Memory,VideoMemory,HDD,Camera)
			Values ('Laptop Lenovo IdeaPad 330-15IKB cu procesor Intel® Core™ i5-8250U pana la 3.40 ',1,1,'Laptop Lenovo IdeaPad 330-15IKB cu procesor Intel® Core™ i5-8250U pana la 3.40 GHz, Kaby Lake R, 15.6", Full HD, 8GB, 512GB SSD, Intel® UHD Graphics 620, Free DOS, Platinum Grey Imbunatatiti-va ziua. Uneori e mai bine sa pastrezi lucrurile simple. Avand procesare premium si optiuni grafice avansate, Ideapad 330 este la fel de puternic si usor de utilizat. Disponibil intr-un finisaj elegant, este sigur, durabil si pregatit pentru sarcinile din fiecare zi. Proiectat pentru a tine pasul cu dumneavoastra. Un laptop nu este doar un obiect electronic - este si o investitie. De aceea am conceput Ideapad 330 cu un finisaj special de protectie pentru a va proteja impotriva uzurii, precum si cu detalii din cauciuc pentru a maximiza ventilatia si a prelungi durata de viata a componentelor.',
			10,3880,'Diagonala display	15.6 inch,Format display Full HD,Tehnologie display	LCD LED ,Finisaj display	Anti-Glare ,Rezolutie	1920 x 1080',
			'Producator procesor Intel®, Tip procesor i5, Model procesor 8250U','Capacitate memorie	8 GB , Tip memorie	DDR4','Tip placa video	Integrata','Tip stocare	SSD, Capacitate stocare	512 GB','16 MPX');

Insert into Member (Username,Password,Email,FullName,Address,Phone,BirthDate) Values ('irimia.mihai','Pc-garage','irimia@yahoo.com','Irimia Mihai','BVD Chimiei, Iasi','074653545','1995-11-22');

