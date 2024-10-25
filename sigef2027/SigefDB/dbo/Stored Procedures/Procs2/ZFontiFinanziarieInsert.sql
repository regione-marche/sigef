CREATE PROCEDURE [dbo].[ZFontiFinanziarieInsert]
(
	@Percentuale DECIMAL(10,3), 
	@Descrizione VARCHAR(255)
)
AS
	INSERT INTO FONTI_FINANZIARIE
	(
		PERCENTUALE, 
		DESCRIZIONE
	)
	VALUES
	(
		@Percentuale, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_FONTE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZFontifinanziarieInsert]
(
	@PERCENTUALE DECIMAL, 
	@DESCRIZIONE VARCHAR(255)
)
AS
	INSERT INTO FONTI_FINANZIARIE
	(
		PERCENTUALE, 
		DESCRIZIONE
	)
	VALUES
	(
		@PERCENTUALE, 
		@DESCRIZIONE
	)
	SELECT SCOPE_IDENTITY() as NEW_ID


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFontiFinanziarieInsert';

