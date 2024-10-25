CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vPROGETTO_COMUNICAZIONI_DOCUMENTI
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vPROGETTO_COMUNICAZIONI_DOCUMENTI
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniDocumentiGetById';

