CREATE PROCEDURE [dbo].[ZControlliParametriXLottoUpdate]
(
	@IdLotto INT, 
	@IdParametro INT, 
	@PesoReale INT
)
AS
	UPDATE CONTROLLI_PARAMETRI_X_LOTTO
	SET
		PESO_REALE = @PesoReale
	WHERE 
		(ID_LOTTO = @IdLotto) AND 
		(ID_PARAMETRO = @IdParametro)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriXLottoUpdate';

