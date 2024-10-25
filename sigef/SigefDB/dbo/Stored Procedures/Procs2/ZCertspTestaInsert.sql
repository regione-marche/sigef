CREATE PROCEDURE [dbo].[ZCertspTestaInsert]
(
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
	INSERT INTO CertSp_Testa
	(
		CodPsr, 
		DataInizio, 
		DataFine, 
		Id_File, 
		Note, 
		Definitivo, 
		Tipo, 
		DataInserimento, 
		DataModifica, 
		Operatore, 
		DataSegnatura, 
		Segnatura, 
		Segnatura_Certificazione
	)
	VALUES
	(
		@Codpsr, 
		@Datainizio, 
		@Datafine, 
		@IdFile, 
		@Note, 
		@Definitivo, 
		@Tipo, 
		@Datainserimento, 
		@Datamodifica, 
		@Operatore, 
		@Datasegnatura, 
		@Segnatura, 
		@SegnaturaCertificazione
	)
	SELECT SCOPE_IDENTITY() AS IdCertSp