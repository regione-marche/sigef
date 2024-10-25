CREATE PROCEDURE [dbo].[ZFontiFinanziarieUpdate]
(
	@IdFonte INT, 
	@Percentuale DECIMAL(10,3), 
	@Descrizione VARCHAR(255)
)
AS
	UPDATE FONTI_FINANZIARIE
	SET
		PERCENTUALE = @Percentuale, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_FONTE = @IdFonte)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZFontifinanziarieUpdate]
(
	@ID_FONTE INT, 
	@PERCENTUALE DECIMAL(10,2), 
	@DESCRIZIONE VARCHAR(255)
)
AS
	UPDATE FONTI_FINANZIARIE
	SET
		PERCENTUALE = @PERCENTUALE, 
		DESCRIZIONE = @DESCRIZIONE
	WHERE 
		(ID_FONTE = @ID_FONTE)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFontiFinanziarieUpdate';

