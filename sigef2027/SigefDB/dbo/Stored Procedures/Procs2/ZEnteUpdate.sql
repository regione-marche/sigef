CREATE PROCEDURE [dbo].[ZEnteUpdate]
(
	@CodEnte VARCHAR(10), 
	@CodTipoEnte VARCHAR(10), 
	@Descrizione VARCHAR(255), 
	@CodSian VARCHAR(20), 
	@Attivo BIT
)
AS
	UPDATE ENTE
	SET
		COD_TIPO_ENTE = @CodTipoEnte, 
		DESCRIZIONE = @Descrizione, 
		COD_SIAN = @CodSian, 
		ATTIVO = @Attivo
	WHERE 
		(COD_ENTE = @CodEnte)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZEnteUpdate]
(
	@CodEnte VARCHAR(10), 
	@CodTipoEnte VARCHAR(10), 
	@Descrizione VARCHAR(255)
)
AS
	UPDATE ENTE
	SET
		COD_TIPO_ENTE = @CodTipoEnte, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(COD_ENTE = @CodEnte)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZEnteUpdate';

