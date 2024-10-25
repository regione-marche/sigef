
CREATE PROCEDURE [dbo].ZLocalizzazioneProgettoUpdate
(
	@IdLocalizzazione INT, 
	@IdProgetto INT, 
	@IdImpresa INT,
	@IdComune INT,
	@CAP char(5), 
	@DUG smallint, 
	@Via varchar(200), 
	@Num varchar(16)
)
AS
	UPDATE LOCALIZZAZIONE_PROGETTO
	SET
		--ID_PROGETTO = @IdProgetto,
		ID_IMPRESA = @IdImpresa,
		ID_COMUNE = @IdComune,
		CAP = @CAP,
		DUG = @DUG,
		VIA = @Via,
		NUM = @Num
	WHERE 
		(ID_LOCALIZZAZIONE = @IdLocalizzazione)

