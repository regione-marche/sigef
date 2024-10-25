CREATE PROCEDURE [dbo].[ZTipoSanzioniParametriInsert]
(
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
	SET @NonComportaSanzione = ISNULL(@NonComportaSanzione,((0)))
	SET @Durata = ISNULL(@Durata,((0)))
	SET @Gravita = ISNULL(@Gravita,((0)))
	SET @Entita = ISNULL(@Entita,((0)))
	INSERT INTO TIPO_SANZIONI_PARAMETRI
	(
		COD_TIPO_SANZIONE, 
		DESCRIZIONE, 
		NON_COMPORTA_SANZIONE, 
		DURATA, 
		GRAVITA, 
		ENTITA, 
		CLASSE_VIOLAZIONE, 
		TOOLTIP
	)
	VALUES
	(
		@CodTipoSanzione, 
		@Descrizione, 
		@NonComportaSanzione, 
		@Durata, 
		@Gravita, 
		@Entita, 
		@ClasseViolazione, 
		@Tooltip
	)
	SELECT SCOPE_IDENTITY() AS CODICE, @NonComportaSanzione AS NON_COMPORTA_SANZIONE, @Durata AS DURATA, @Gravita AS GRAVITA, @Entita AS ENTITA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoSanzioniParametriInsert';

