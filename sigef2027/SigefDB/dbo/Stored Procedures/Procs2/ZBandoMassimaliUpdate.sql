CREATE PROCEDURE [dbo].[ZBandoMassimaliUpdate]
(
	@Id INT, 
	@IdBando INT, 
	@IdProgrammazione INT, 
	@Quota DECIMAL(10,2), 
	@Importo DECIMAL(18,2)
)
AS
	UPDATE BANDO_MASSIMALI
	SET
		ID_BANDO = @IdBando, 
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		QUOTA = @Quota, 
		IMPORTO = @Importo
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoMassimaliUpdate]
(
	@Id INT, 
	@IdBando INT, 
	@IdProgrammazione INT, 
	@Quota DECIMAL(10,2), 
	@Importo DECIMAL(18,2)
)
AS
	UPDATE BANDO_MASSIMALI
	SET
		ID_BANDO = @IdBando, 
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		QUOTA = @Quota, 
		IMPORTO = @Importo
	WHERE 
		(ID = @Id)


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoMassimaliUpdate';

