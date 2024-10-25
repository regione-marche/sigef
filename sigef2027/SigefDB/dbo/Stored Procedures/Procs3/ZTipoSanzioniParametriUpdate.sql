CREATE PROCEDURE [dbo].[ZTipoSanzioniParametriUpdate]
(
	@Codice INT, 
	@CodTipoSanzione VARCHAR(10), 
	@Descrizione VARCHAR(500), 
	@NonComportaSanzione BIT, 
	@Durata BIT, 
	@Gravita BIT, 
	@Entita BIT, 
	@ClasseViolazione INT, 
	@Tooltip VARCHAR(255)
)
AS
	UPDATE TIPO_SANZIONI_PARAMETRI
	SET
		COD_TIPO_SANZIONE = @CodTipoSanzione, 
		DESCRIZIONE = @Descrizione, 
		NON_COMPORTA_SANZIONE = @NonComportaSanzione, 
		DURATA = @Durata, 
		GRAVITA = @Gravita, 
		ENTITA = @Entita, 
		CLASSE_VIOLAZIONE = @ClasseViolazione, 
		TOOLTIP = @Tooltip
	WHERE 
		(CODICE = @Codice)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoSanzioniParametriUpdate';

