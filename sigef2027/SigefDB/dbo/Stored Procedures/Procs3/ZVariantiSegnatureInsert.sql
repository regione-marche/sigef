CREATE PROCEDURE [dbo].[ZVariantiSegnatureInsert]
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
	SET @RiapriVariante = ISNULL(@RiapriVariante,((0)))

	INSERT INTO VARIANTI_SEGNATURE
	(
		ID_VARIANTE, 
		COD_TIPO, 
		SEGNATURA, 
		DATA, 
		OPERATORE, 
		MOTIVAZIONE, 
		RIAPRI_VARIANTE
	)
	VALUES
	(
		@IdVariante, 
		@CodTipo, 
		@Segnatura, 
		@Data, 
		@Operatore, 
		@Motivazione, 
		@RiapriVariante
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVariantiSegnatureInsert]
(
	@IdVariante INT, 
	@CodTipo CHAR(3), 
	@Segnatura VARCHAR(100), 
	@Data DATETIME, 
	@Operatore VARCHAR(16), 
	@Motivazione NTEXT
)
AS
	INSERT INTO VARIANTI_SEGNATURE
	(
		ID_VARIANTE, 
		COD_TIPO, 
		SEGNATURA, 
		DATA, 
		OPERATORE, 
		MOTIVAZIONE
	)
	VALUES
	(
		@IdVariante, 
		@CodTipo, 
		@Segnatura, 
		@Data, 
		@Operatore, 
		@Motivazione
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiSegnatureInsert';

