CREATE PROCEDURE [dbo].[ZVariantiSegnatureUpdate]
(
	@IdVariante INT, 
	@CodTipo CHAR(3), 
	@Segnatura VARCHAR(100), 
	@Data DATETIME, 
	@Operatore VARCHAR(16), 
	@Motivazione NTEXT, 
	@RiapriVariante BIT
)
AS
	UPDATE VARIANTI_SEGNATURE
	SET
		SEGNATURA = @Segnatura, 
		DATA = @Data, 
		OPERATORE = @Operatore, 
		MOTIVAZIONE = @Motivazione, 
		RIAPRI_VARIANTE = @RiapriVariante
	WHERE 
		(ID_VARIANTE = @IdVariante) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVariantiSegnatureUpdate]
(
	@IdVariante INT, 
	@CodTipo CHAR(3), 
	@Segnatura VARCHAR(100), 
	@Data DATETIME, 
	@Operatore VARCHAR(16), 
	@Motivazione NTEXT
)
AS
	UPDATE VARIANTI_SEGNATURE
	SET
		SEGNATURA = @Segnatura, 
		DATA = @Data, 
		OPERATORE = @Operatore, 
		MOTIVAZIONE = @Motivazione
	WHERE 
		(ID_VARIANTE = @IdVariante) AND 
		(COD_TIPO = @CodTipo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiSegnatureUpdate';

