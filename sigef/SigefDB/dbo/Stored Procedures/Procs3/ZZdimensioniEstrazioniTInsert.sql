CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniTInsert]
(
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@CodPsr VARCHAR(255), 
	@Bloccato BIT, 
	@TipoIndicatori VARCHAR(255)
)
AS
	INSERT INTO zDIMENSIONI_ESTRAZIONI_T
	(
		DATA_INIZIO, 
		DATA_FINE, 
		COD_PSR, 
		BLOCCATO, 
		TIPO_INDICATORI
	)
	VALUES
	(
		@DataInizio, 
		@DataFine, 
		@CodPsr, 
		@Bloccato, 
		@TipoIndicatori
	)
	SELECT SCOPE_IDENTITY() AS ID_ESTRAZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniTInsert';

