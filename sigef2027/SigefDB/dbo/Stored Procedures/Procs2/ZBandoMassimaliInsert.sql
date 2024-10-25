CREATE PROCEDURE [dbo].[ZBandoMassimaliInsert]
(
	@IdBando INT, 
	@IdProgrammazione INT, 
	@Quota DECIMAL(10,2), 
	@Importo DECIMAL(18,2)
)
AS
	SET @Quota = ISNULL(@Quota,((0)))
	SET @Importo = ISNULL(@Importo,((0)))
	INSERT INTO BANDO_MASSIMALI
	(
		ID_BANDO, 
		ID_PROGRAMMAZIONE, 
		QUOTA, 
		IMPORTO
	)
	VALUES
	(
		@IdBando, 
		@IdProgrammazione, 
		@Quota, 
		@Importo
	)
	SELECT SCOPE_IDENTITY() AS ID, @Quota AS QUOTA, @Importo AS IMPORTO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoMassimaliInsert]
(
	@IdBando INT, 
	@IdProgrammazione INT, 
	@Quota DECIMAL(10,2), 
	@Importo DECIMAL(18,2)
)
AS
	SET @Quota = ISNULL(@Quota,((0)))
	SET @Importo = ISNULL(@Importo,((0)))
	INSERT INTO BANDO_MASSIMALI
	(
		ID_BANDO, 
		ID_PROGRAMMAZIONE, 
		QUOTA, 
		IMPORTO
	)
	VALUES
	(
		@IdBando, 
		@IdProgrammazione, 
		@Quota, 
		@Importo
	)
	SELECT SCOPE_IDENTITY() AS ID, @Quota AS QUOTA, @Importo AS IMPORTO


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoMassimaliInsert';

