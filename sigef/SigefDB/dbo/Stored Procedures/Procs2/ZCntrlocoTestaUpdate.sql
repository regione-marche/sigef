CREATE PROCEDURE [dbo].[ZCntrlocoTestaUpdate]
(
	@Idloco INT, 
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
	UPDATE CntrLoco_Testa
	SET
		CodPsr = @Codpsr, 
		DataInizio = @Datainizio, 
		DataFine = @Datafine, 
		Note = @Note, 
		Definitivo = @Definitivo, 
		DataInserimento = @Datainserimento, 
		DataModifica = @Datamodifica, 
		Operatore = @Operatore, 
		DataSegnatura = @Datasegnatura, 
		Segnatura = @Segnatura
	WHERE 
		(IdLoco = @Idloco)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCntrlocoTestaUpdate]
(
	@Idloco INT, 
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
	UPDATE CntrLoco_Testa
	SET
		CodPsr = @Codpsr, 
		DataInizio = @Datainizio, 
		DataFine = @Datafine, 
		Note = @Note, 
		Definitivo = @Definitivo, 
		DataInserimento = @Datainserimento, 
		DataModifica = @Datamodifica, 
		Operatore = @Operatore
	WHERE 
		(IdLoco = @Idloco)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCntrlocoTestaUpdate';

