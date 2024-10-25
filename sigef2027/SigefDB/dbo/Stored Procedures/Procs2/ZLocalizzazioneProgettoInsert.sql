
CREATE PROCEDURE [dbo].ZLocalizzazioneProgettoInsert
(
	@IdProgetto INT, 
	@IdImpresa INT,
	@IdComune INT,
	@CAP char(5), 
	@DUG smallint, 
	@Via varchar(200), 
	@Num varchar(16)
)
AS
	INSERT INTO LOCALIZZAZIONE_PROGETTO
	(
		ID_PROGETTO,
		ID_IMPRESA,
		ID_COMUNE,
		CAP,
		DUG,
		VIA,
		NUM
	)
	VALUES
	(
		@IdProgetto, 
		@IdImpresa,
		@IdComune,
		@CAP, 
		@DUG, 
		@Via, 
		@Num
	)
	SELECT SCOPE_IDENTITY() AS ID_LOCALIZZAZIONE

