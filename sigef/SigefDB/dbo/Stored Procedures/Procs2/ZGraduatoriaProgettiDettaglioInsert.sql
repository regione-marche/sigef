CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiDettaglioInsert]
(
	@IdPriorita INT, 
	@IdProgetto INT, 
	@Punteggio DECIMAL(10,6), 
	@DataValutazione DATETIME, 
	@Operatore VARCHAR(255), 
	@ModificaManuale BIT
)
AS
	INSERT INTO GRADUATORIA_PROGETTI_DETTAGLIO
	(
		ID_PRIORITA, 
		ID_PROGETTO, 
		PUNTEGGIO, 
		DATA_VALUTAZIONE, 
		OPERATORE, 
		MODIFICA_MANUALE
	)
	VALUES
	(
		@IdPriorita, 
		@IdProgetto, 
		@Punteggio, 
		@DataValutazione, 
		@Operatore, 
		@ModificaManuale
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiDettaglioInsert]
(
	@IdPriorita INT, 
	@IdProgetto INT, 
	@Punteggio DECIMAL(10,6), 
	@DataValutazione DATETIME, 
	@Operatore VARCHAR(16), 
	@ModificaManuale BIT
)
AS
	INSERT INTO GRADUATORIA_PROGETTI_DETTAGLIO
	(
		ID_PRIORITA, 
		ID_PROGETTO, 
		PUNTEGGIO, 
		DATA_VALUTAZIONE, 
		OPERATORE, 
		MODIFICA_MANUALE
	)
	VALUES
	(
		@IdPriorita, 
		@IdProgetto, 
		@Punteggio, 
		@DataValutazione, 
		@Operatore, 
		@ModificaManuale
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiDettaglioInsert';

