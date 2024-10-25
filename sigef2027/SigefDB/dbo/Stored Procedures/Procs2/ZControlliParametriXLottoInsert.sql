CREATE PROCEDURE [dbo].[ZControlliParametriXLottoInsert]
(
	@IdLotto INT, 
	@IdParametro INT, 
	@PesoReale INT
)
AS
	INSERT INTO CONTROLLI_PARAMETRI_X_LOTTO
	(
		ID_LOTTO, 
		ID_PARAMETRO, 
		PESO_REALE
	)
	VALUES
	(
		@IdLotto, 
		@IdParametro, 
		@PesoReale
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriXLottoInsert';

