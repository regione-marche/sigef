CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniTGetById]
(
	@IdEstrazione INT
)
AS
	SELECT *
	FROM vzDIMENSIONI_ESTRAZIONI_T
	WHERE 
		(ID_ESTRAZIONE = @IdEstrazione)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniTGetById';

