CREATE PROCEDURE [dbo].[ZCntrlocoTestaInsert]
(
	@Codpsr VARCHAR(255), 
	@Datainizio DATETIME, 
	@Datafine DATETIME, 
	@Note VARCHAR(500), 
	@Definitivo BIT, 
	@Datainserimento DATETIME, 
	@Datamodifica DATETIME, 
	@Operatore VARCHAR(255), 
	@Datasegnatura DATETIME, 
	@Segnatura VARCHAR(255)
)
AS
	INSERT INTO CntrLoco_Testa
	(
		CodPsr, 
		DataInizio, 
		DataFine, 
		Note, 
		Definitivo, 
		DataInserimento, 
		DataModifica, 
		Operatore, 
		DataSegnatura, 
		Segnatura
	)
	VALUES
	(
		@Codpsr, 
		@Datainizio, 
		@Datafine, 
		@Note, 
		@Definitivo, 
		@Datainserimento, 
		@Datamodifica, 
		@Operatore, 
		@Datasegnatura, 
		@Segnatura
	)
	SELECT SCOPE_IDENTITY() AS IdLoco


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCntrlocoTestaInsert]
(
	@Codpsr VARCHAR(255), 
	@Datainizio DATETIME, 
	@Datafine DATETIME, 
	@Note VARCHAR(500), 
	@Definitivo BIT, 
	@Datainserimento DATETIME, 
	@Datamodifica DATETIME, 
	@Operatore VARCHAR(255)
)
AS
	INSERT INTO CntrLoco_Testa
	(
		CodPsr, 
		DataInizio, 
		DataFine, 
		Note, 
		Definitivo, 
		DataInserimento, 
		DataModifica, 
		Operatore
	)
	VALUES
	(
		@Codpsr, 
		@Datainizio, 
		@Datafine, 
		@Note, 
		@Definitivo, 
		@Datainserimento, 
		@Datamodifica, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS IdLoco

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCntrlocoTestaInsert';

