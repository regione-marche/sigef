CREATE PROCEDURE [dbo].[ZProgettoSegnatureUpdate]
(
	@IdProgetto INT, 
	@CodTipo CHAR(3), 
	@Data DATETIME, 
	@Operatore VARCHAR(16), 
	@Segnatura VARCHAR(100), 
	@RiapriDomanda BIT, 
	@Motivazione NTEXT
)
AS
	UPDATE PROGETTO_SEGNATURE
	SET
		DATA = @Data, 
		OPERATORE = @Operatore, 
		SEGNATURA = @Segnatura, 
		RIAPRI_DOMANDA = @RiapriDomanda, 
		MOTIVAZIONE = @Motivazione
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProgettoSegnatureUpdate]
(
	@IdProgetto INT, 
	@CodTipo CHAR(3), 
	@Data DATETIME, 
	@Operatore VARCHAR(16), 
	@Segnatura VARCHAR(100), 
	@RiapriDomanda BIT, 
	@Motivazione NTEXT
)
AS
	UPDATE PROGETTO_SEGNATURE
	SET
		DATA = @Data, 
		OPERATORE = @Operatore, 
		SEGNATURA = @Segnatura, 
		RIAPRI_DOMANDA = @RiapriDomanda, 
		MOTIVAZIONE = @Motivazione
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(COD_TIPO = @CodTipo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoSegnatureUpdate';

