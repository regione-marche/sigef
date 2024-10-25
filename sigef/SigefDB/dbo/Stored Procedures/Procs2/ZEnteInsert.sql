CREATE PROCEDURE [dbo].[ZEnteInsert]
(
	@CodEnte VARCHAR(10), 
	@CodTipoEnte VARCHAR(10), 
	@Descrizione VARCHAR(255), 
	@CodSian VARCHAR(20), 
	@Attivo BIT
)
AS
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO ENTE
	(
		COD_ENTE, 
		COD_TIPO_ENTE, 
		DESCRIZIONE, 
		COD_SIAN, 
		ATTIVO
	)
	VALUES
	(
		@CodEnte, 
		@CodTipoEnte, 
		@Descrizione, 
		@CodSian, 
		@Attivo
	)
	SELECT @Attivo AS ATTIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZEnteInsert]
(
	@CodEnte VARCHAR(10), 
	@CodTipoEnte VARCHAR(10), 
	@Descrizione VARCHAR(255)
)
AS
	INSERT INTO ENTE
	(
		COD_ENTE, 
		COD_TIPO_ENTE, 
		DESCRIZIONE
	)
	VALUES
	(
		@CodEnte, 
		@CodTipoEnte, 
		@Descrizione
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZEnteInsert';

