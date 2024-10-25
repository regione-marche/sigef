CREATE PROCEDURE [dbo].[ZProgettoSegnatureInsert]
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
	SET @RiapriDomanda = ISNULL(@RiapriDomanda,((0)))
	INSERT INTO PROGETTO_SEGNATURE
	(
		ID_PROGETTO, 
		COD_TIPO, 
		DATA, 
		OPERATORE, 
		SEGNATURA, 
		RIAPRI_DOMANDA, 
		MOTIVAZIONE
	)
	VALUES
	(
		@IdProgetto, 
		@CodTipo, 
		@Data, 
		@Operatore, 
		@Segnatura, 
		@RiapriDomanda, 
		@Motivazione
	)
	SELECT @RiapriDomanda AS RIAPRI_DOMANDA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProgettoSegnatureInsert]
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
	SET @RiapriDomanda = ISNULL(@RiapriDomanda,((0)))
	INSERT INTO PROGETTO_SEGNATURE
	(
		ID_PROGETTO, 
		COD_TIPO, 
		DATA, 
		OPERATORE, 
		SEGNATURA, 
		RIAPRI_DOMANDA, 
		MOTIVAZIONE
	)
	VALUES
	(
		@IdProgetto, 
		@CodTipo, 
		@Data, 
		@Operatore, 
		@Segnatura, 
		@RiapriDomanda, 
		@Motivazione
	)
	SELECT @RiapriDomanda AS RIAPRI_DOMANDA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoSegnatureInsert';

