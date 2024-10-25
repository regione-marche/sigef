CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniTUpdate]
(
	@IdEstrazione INT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@CodPsr VARCHAR(255), 
	@Bloccato BIT, 
	@TipoIndicatori VARCHAR(255)
)
AS
	UPDATE zDIMENSIONI_ESTRAZIONI_T
	SET
		DATA_INIZIO = @DataInizio, 
		DATA_FINE = @DataFine, 
		COD_PSR = @CodPsr, 
		BLOCCATO = @Bloccato, 
		TIPO_INDICATORI = @TipoIndicatori
	WHERE 
		(ID_ESTRAZIONE = @IdEstrazione)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniTUpdate';

