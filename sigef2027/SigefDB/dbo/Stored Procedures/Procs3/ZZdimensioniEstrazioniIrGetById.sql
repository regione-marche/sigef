CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIrGetById]
(
	@IdEstrazioneIr INT
)
AS
	SELECT *
	FROM vzDIMENSIONI_ESTRAZIONI_IR
	WHERE 
		(ID_ESTRAZIONE_IR = @IdEstrazioneIr)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIrGetById]
(
	@IdEstrazioneIr INT
)
AS
	SELECT *
	FROM vzDIMENSIONI_ESTRAZIONI_IR
	WHERE 
		(ID_ESTRAZIONE_IR = @IdEstrazioneIr)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIrGetById';

