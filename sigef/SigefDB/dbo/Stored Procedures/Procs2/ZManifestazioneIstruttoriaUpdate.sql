CREATE PROCEDURE [dbo].[ZManifestazioneIstruttoriaUpdate]
(
	@IdManifestazione INT, 
	@Ricevibilita CHAR(1), 
	@RicevibilitaData DATETIME, 
	@RicevibilitaOperatore VARCHAR(16), 
	@RicevibilitaSegnatura VARCHAR(100), 
	@Ammissibilita CHAR(1), 
	@AmmissibilitaData DATETIME, 
	@AmmissibilitaOperatore VARCHAR(16), 
	@AmmissibilitaSegnatura VARCHAR(100), 
	@Rinuncia CHAR(1), 
	@RinunciaData DATETIME, 
	@RinunciaOperatore VARCHAR(16), 
	@RinunciaSegnatura VARCHAR(100)
)
AS
	UPDATE MANIFESTAZIONE_ISTRUTTORIA
	SET
		RICEVIBILITA = @Ricevibilita, 
		RICEVIBILITA_DATA = @RicevibilitaData, 
		RICEVIBILITA_OPERATORE = @RicevibilitaOperatore, 
		RICEVIBILITA_SEGNATURA = @RicevibilitaSegnatura, 
		AMMISSIBILITA = @Ammissibilita, 
		AMMISSIBILITA_DATA = @AmmissibilitaData, 
		AMMISSIBILITA_OPERATORE = @AmmissibilitaOperatore, 
		AMMISSIBILITA_SEGNATURA = @AmmissibilitaSegnatura, 
		RINUNCIA = @Rinuncia, 
		RINUNCIA_DATA = @RinunciaData, 
		RINUNCIA_OPERATORE = @RinunciaOperatore, 
		RINUNCIA_SEGNATURA = @RinunciaSegnatura
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione)
