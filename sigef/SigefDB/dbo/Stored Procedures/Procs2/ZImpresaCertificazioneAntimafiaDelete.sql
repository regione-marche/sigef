CREATE PROCEDURE [dbo].[ZImpresaCertificazioneAntimafiaDelete]
(
	@Id INT
)
AS
	DELETE IMPRESA_CERTIFICAZIONE_ANTIMAFIA
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZImpresaCertificazioneAntimafiaDelete]
(
	@Id INT
)
AS
	DELETE IMPRESA_CERTIFICAZIONE_ANTIMAFIA
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaCertificazioneAntimafiaDelete';

