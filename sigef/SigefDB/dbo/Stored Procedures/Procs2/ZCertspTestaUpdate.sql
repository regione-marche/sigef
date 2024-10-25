CREATE PROCEDURE [dbo].[ZCertspTestaUpdate]
(
	@Idcertsp INT, 
	@Codpsr VARCHAR(255), 
	@Datainizio DATETIME, 
	@Datafine DATETIME, 
	@IdFile INT, 
	@Note VARCHAR(500), 
	@Definitivo BIT, 
	@Tipo VARCHAR(255), 
	@Datainserimento DATETIME, 
	@Datamodifica DATETIME, 
	@Operatore VARCHAR(255), 
	@Datasegnatura DATETIME, 
	@Segnatura VARCHAR(255), 
	@SegnaturaCertificazione VARCHAR(255)
)
AS
	UPDATE CertSp_Testa
	SET
		CodPsr = @Codpsr, 
		DataInizio = @Datainizio, 
		DataFine = @Datafine, 
		Id_File = @IdFile, 
		Note = @Note, 
		Definitivo = @Definitivo, 
		Tipo = @Tipo, 
		DataInserimento = @Datainserimento, 
		DataModifica = @Datamodifica, 
		Operatore = @Operatore, 
		DataSegnatura = @Datasegnatura, 
		Segnatura = @Segnatura, 
		Segnatura_Certificazione = @SegnaturaCertificazione
	WHERE 
		(IdCertSp = @Idcertsp)

GO
