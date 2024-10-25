CREATE PROCEDURE [dbo].[ZFontiFinanziarieDelete]
(
	@IdFonte INT
)
AS
	DELETE FONTI_FINANZIARIE
	WHERE 
		(ID_FONTE = @IdFonte)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZFontifinanziarieDelete]
(
	@ID_FONTE INT
)
AS
	DELETE FONTI_FINANZIARIE
	WHERE 
		(ID_FONTE = @ID_FONTE)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFontiFinanziarieDelete';

