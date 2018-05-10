/*INSERTS SISTEMA LOGISTICA*/

/*ROLE*/
INSERT INTO Role (NomeRole) VALUES ('ENTREGADOR');
INSERT INTO Role (NomeRole) VALUES ('EMBALAGEM');
INSERT INTO Role (NomeRole) VALUES ('USUARIO');
/*USUARIO*/
INSERT INTO Usuario (Nome, CPF, Usuario, Senha, Telefone, IdRole) VALUES ('Vitor','115.662.548-87','Entregador', '8f7957e71c2b39d1ee8d93cf9eaf44b09f7cd207711f5c0273951b358713efda','4654-4465','1');
INSERT INTO Usuario (Nome, CPF, Usuario, Senha, Telefone, IdRole) VALUES ('Cadena','113.548.789-98','Usuario', '8f7957e71c2b39d1ee8d93cf9eaf44b09f7cd207711f5c0273951b358713efda','9874-5612','2');
INSERT INTO Usuario (Nome, CPF, Usuario, Senha, Telefone, IdRole) VALUES ('Naiara','005-965-895-84','Embalagem', '8f7957e71c2b39d1ee8d93cf9eaf44b09f7cd207711f5c0273951b358713efda','4443-9999','3');
/* USUARIO = Entregador OU Usuario OU Embalagem - Senha = 12qw!@QW (Está daquele jeito acima na query pois está criptografada) */

/*TIPO_PRODUTO*/
INSERT INTO Tipo_Produto(Tipo, Fragilidade) VALUES ('ELETRODOMESTICO','SIM');
INSERT INTO Tipo_Produto(Tipo, Fragilidade) VALUES ('COSMETICO','NAO');

/*PRODUTO*/
INSERT INTO Produto(IdTipo_Produto
					, Descricao
					, Quantidade	
					, Valor
					, Peso
					, TamanhoX
					, TamanhoY
					, TamanhoZ)
VALUES ('1'	, 'TESTE', '5', '1', '1', '55', '55', '55')
		
/*ENDERECO*/
INSERT INTO Endereco (CEP
					, Estado
					, Cidade
					, Bairro
					, Logradouro
					, Numero
					, Complemento) 
					VALUES ('04320-040','SP','SP','Cidade Vargas', 'CASA', '7854', 'TESTE');

/*PEDIDO*/
INSERT INTO Pedido (IdUsuario, IdProduto, IdEndereco, DataDeEntrega) VALUES ('1','6','1',GETDATE());

