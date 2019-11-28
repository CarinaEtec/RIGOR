create database SGC;
USE SGC;
	/* ------------------------------------------- */   
    CREATE TABLE Funcionarios(
	Nome VARCHAR(50) NOT NULL,
	Cpf BIGINT (11) NOT NULL PRIMARY KEY,
	Funcao VARCHAR(25) NOT NULL,
	Telefone VARCHAR (15), 
	Celular VARCHAR (15),
	Senha VARCHAR(15) NOT NULL);
	/* ------------------------------------------- */
	CREATE TABLE BA(
	BA_COD INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	APTO VARCHAR (10) NOT NULL,
	BLOCO VARCHAR (10) NOT NULL); 
	/* ------------------------------------------- */
	CREATE TABLE Moradores(
	CodMorador INTEGER NOT NULL AUTO_INCREMENT PRIMARY KEY,
	Nome VARCHAR(50) NOT NULL,
	DataNasc Date NOT NULL,
	Situacao VARCHAR (25) NOT NULL,
	Telefone VARCHAR (15), 
	Celular VARCHAR (15),
    BA_COD INT NOT NULL,
    foreign key (BA_COD) references BA(BA_COD));
	/* ------------------------------------------- */
	CREATE TABLE Locacoes(
	CodLocacao INTEGER NOT NULL AUTO_INCREMENT PRIMARY KEY,
	CodMorador INT NOT NULL,  
	Inicio DATETIME NOT NULL,
	Termino DATETIME NOT NULL,
    BA_COD INT NOT NULL,
    foreign key (BA_COD) references BA(BA_COD),
    foreign key (CodMorador) references Moradores(CodMorador));
	/* ------------------------------------------- */
	CREATE TABLE Veiculos(
	CodMorador INT NOT NULL,  
	Placa VARCHAR (8) NOT NULL PRIMARY KEY,
    Modelo VARCHAR(20) NOT NULL,
    Cor VARCHAR(20) NOT NULL, 
	BA_COD INT NOT NULL,
    foreign key (BA_COD) references BA(BA_COD),
    foreign key (CodMorador) references  Moradores(CodMorador));
	/* ------------------------------------------- */
    CREATE TABLE Obras(
	CodObras INTEGER NOT NULL AUTO_INCREMENT PRIMARY KEY,
	CodMorador INT NOT NULL, 
	DataHora DATETIME NOT NULL,
	BA_COD INT NOT NULL,
	foreign key (BA_COD) references BA(BA_COD),
    foreign key (CodMorador) references Moradores(CodMorador));	
	/* ------------------------------------------- */
	CREATE TABLE Pets(
	CodPet INTEGER NOT NULL AUTO_INCREMENT PRIMARY KEY,	
	Nome VARCHAR (20) NOT NULL,  
	CodMorador INT NOT NULL,  
	Especie VARCHAR (20) NOT NULL,
	BA_COD INT NOT NULL,
	foreign key (BA_COD) references BA(BA_COD),
    foreign key (CodMorador) references Moradores(CodMorador));
	/* ------------------------------------------- */
	CREATE TABLE Ocorrencias(
	CodOcorrencia INTEGER NOT NULL AUTO_INCREMENT PRIMARY KEY,
	CodMorador INT NOT NULL,
	Motivo VARCHAR (20) NOT NULL,  
	Data DATE NOT NULL,
	BA_COD INT NOT NULL,
	foreign key (BA_COD) references BA(BA_COD),
    foreign key (CodMorador) references Moradores(CodMorador));
 	/* ------------------------------------------- */



    
