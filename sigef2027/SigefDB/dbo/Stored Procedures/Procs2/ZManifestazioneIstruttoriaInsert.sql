CREATE PROCEDURE [dbo].[ZManifestazioneIstruttoriaInsert]
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
	INSERT INTO MANIFESTAZIONE_ISTRUTTORIA
	(
		ID_MANIFESTAZIONE, 
		RICEVIBILITA, 
		RICEVIBILITA_DATA, 
		RICEVIBILITA_OPERATORE, 
		RICEVIBILITA_SEGNATURA, 
		AMMISSIBILITA, 
		AMMISSIBILITA_DATA, 
		AMMISSIBILITA_OPERATORE, 
		AMMISSIBILITA_SEGNATURA, 
		RINUNCIA, 
		RINUNCIA_DATA, 
		RINUNCIA_OPERATORE, 
		RINUNCIA_SEGNATURA
	)
	VALUES
	(
		@IdManifestazione, 
		@Ricevibilita, 
		@RicevibilitaData, 
		@RicevibilitaOperatore, 
		@RicevibilitaSegnatura, 
		@Ammissibilita, 
		@AmmissibilitaData, 
		@AmmissibilitaOperatore, 
		@AmmissibilitaSegnatura, 
		@Rinuncia, 
		@RinunciaData, 
		@RinunciaOperatore, 
		@RinunciaSegnatura
	)
