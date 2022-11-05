--Criacao da base de dados sem especificar nenhum parametro, usando valores default do DBMS
CREATE DATABASE SUCOS_VENDAS_01

--Criacao da base de dados especificando parametros a serem usados na criacao da base
CREATE DATABASE SUCOS_VENDAS_02
ON (
		NAME=SUCOS_VENDAS_DAT,						 --NAME da particao; 
		FILENAME='C:\TEMP\DATA\SALES_VENDAS_02.MDF', --FILENAME do arquivo fisico do banco; 
		SIZE=10,									 --SIZE inicial do banco em MB; 
		MAXSIZE=50,									 --MAXSIZE do banco em MB; 
		FILEGROWTH=5								 --FILEGROWTH para definir o tamanho em MB do incremento a ser usado cada vez que o arquivo .MDF for redimensionado
	)
LOG 
ON (
		NAME=SUCOS_VENDAS_LOG,
		FILENAME='C:\TEMP\DATA\SALES_VENDAS_02.LDF',
		SIZE=10,
		MAXSIZE=50,
		FILEGROWTH=5
	)

CREATE DATABASE SUCOS_VENDAS

CREATE DATABASE SUCOS_VENDAS_03