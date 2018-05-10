/* PROCEDURES */
/* CRIAÇÃO NO BANCO DE DADOS E USING */
CREATE DATABASE Logistica;
USE Logistica;

/* CREATE TABLES */
CREATE TABLE Tipo_Produto
			(
				IdTipo_Produto INTEGER IDENTITY(1,1) PRIMARY KEY,
				Tipo VARCHAR(50),
				Fragilidade CHAR(3),
			);

CREATE TABLE Role
			 (
			    IdRole INTEGER IDENTITY(1,1) PRIMARY KEY,
				NomeRole VARCHAR(50),
			 );
				
CREATE TABLE Endereco
			(
				IdEndereco INTEGER IDENTITY(1,1) PRIMARY KEY,
				CEP VARCHAR(50),
				Estado VARCHAR(30),
				Cidade VARCHAR(20),
				Bairro VARCHAR(20),
				Logradouro VARCHAR(30),
				Numero INTEGER,
				Complemento VARCHAR(20),
			);
CREATE TABLE Produto
			(
				IdProduto INTEGER IDENTITY(1,1) PRIMARY KEY,
				IdTipo_Produto INTEGER,
				Descricao VARCHAR(100),
				Quantidade INTEGER,
				Valor FLOAT,
				Peso FLOAT,
				TamanhoX FLOAT,
				TamanhoY FLOAT,
				TamanhoZ FLOAT,
				FOREIGN KEY (IdTipo_Produto) REFERENCES Tipo_Produto(IdTipo_Produto)
			);
			
CREATE TABLE Estoque
			(
				IdEstoque INTEGER IDENTITY(1,1) PRIMARY KEY,
				IdProduto INTEGER,
				Unidade VARCHAR(20),
				Local_Produto VARCHAR(30),
				FOREIGN KEY (IdProduto) REFERENCES Produto(IdProduto)
			);


CREATE TABLE Pedido
			(
				IdPedido INTEGER IDENTITY(1,1) PRIMARY KEY,
				IdUsuario INTEGER,
				IdProduto INTEGER,
				IdEndereco INTEGER,
				DataDeEntrega DATE,
				FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
				FOREIGN KEY (IdProduto) REFERENCES Produto(IdProduto),
				FOREIGN KEY (IdEndereco) REFERENCES Endereco(IdEndereco)
			);

CREATE TABLE Usuario 
			 (
				IdUsuario INTEGER IDENTITY(1,1) PRIMARY KEY,
				Nome VARCHAR(50),
				CPF VARCHAR(20),
				Usuario VARCHAR(20),
				Senha VARCHAR(100),
				Telefone VARCHAR(30),
				IdRole INTEGER,
				FOREIGN KEY (IdRole) REFERENCES Role(IdRole)
			 );

CREATE TABLE Entregas
			(
				IdEntregas INTEGER IDENTITY(1,1) PRIMARY KEY,
				IdUsuario INTEGER,
				IdPedido INTEGER,
				StatusEntrega VARCHAR(15),
				FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido),
				FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
			);
				
/* SELECTS DE TODAS AS TABELAS */
SELECT * FROM Tipo_Produto;
SELECT * FROM Produto;
SELECT * FROM Estoque;
SELECT * FROM Endereco;
SELECT * FROM Usuario;
SELECT * FROM Pedido;
SELECT * FROM Entregas;
SELECT * FROM Role;



/* DROP DE TODAS AS TABELAS*/
DROP TABLE Entregas;
DROP TABLE Pedido;
DROP TABLE Usuario;
DROP TABLE Produto;
DROP TABLE Tipo_Produto;
DROP TABLE Endereco;
DROP TABLE Estoque;
DROP TABLE Role;



