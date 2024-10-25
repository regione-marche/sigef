CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneSpostamentiDelete]
(
	@Id INT
)
AS
	DELETE CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCorrettivaRendicontazioneSpostamentiDelete';

