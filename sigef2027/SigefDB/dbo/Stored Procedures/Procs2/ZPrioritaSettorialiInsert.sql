CREATE PROCEDURE [dbo].[ZPrioritaSettorialiInsert]
(
	@Descrizione VARCHAR(1000)
)
AS
	INSERT INTO PRIORITA_SETTORIALI
	(
		DESCRIZIONE
	)
	VALUES
	(
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_PRIORITA_SETTORIALE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPrioritaSettorialiInsert]
(
	@IdSettoreProduttivo INT, 
	@Descrizione VARCHAR(1000)
)
AS
	INSERT INTO PRIORITA_SETTORIALI
	(
		ID_SETTORE_PRODUTTIVO, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdSettoreProduttivo, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_PRIORITA_SETTORIALE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaSettorialiInsert';

