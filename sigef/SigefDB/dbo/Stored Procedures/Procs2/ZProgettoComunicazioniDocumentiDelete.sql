CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiDelete]
(
	@Id INT
)
AS
	DELETE PROGETTO_COMUNICAZIONI_DOCUMENTI
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiDelete]
(
	@Id INT
)
AS
	DELETE PROGETTO_COMUNICAZIONI_DOCUMENTI
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniDocumentiDelete';

