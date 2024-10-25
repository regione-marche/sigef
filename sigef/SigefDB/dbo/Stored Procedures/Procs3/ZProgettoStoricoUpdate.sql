CREATE PROCEDURE [dbo].[ZProgettoStoricoUpdate]
(
	@Id INT, 
	@IdProgetto INT, 
	@CodStato VARCHAR(255), 
	@Data DATETIME, 
	@Operatore INT, 
	@Segnatura VARCHAR(255), 
	@Revisione BIT, 
	@Riesame BIT, 
	@Ricorso BIT, 
	@RiaperturaProvinciale BIT, 
	@DataRi DATETIME, 
	@OperatoreRi INT, 
	@SegnaturaRi VARCHAR(255), 
	@IdAtto INT
)
AS
	UPDATE PROGETTO_STORICO
	SET
		ID_PROGETTO = @IdProgetto, 
		COD_STATO = @CodStato, 
		DATA = @Data, 
		OPERATORE = @Operatore, 
		SEGNATURA = @Segnatura, 
		REVISIONE = @Revisione, 
		RIESAME = @Riesame, 
		RICORSO = @Ricorso, 
		RIAPERTURA_PROVINCIALE = @RiaperturaProvinciale, 
		DATA_RI = @DataRi, 
		OPERATORE_RI = @OperatoreRi, 
		SEGNATURA_RI = @SegnaturaRi, 
		ID_ATTO = @IdAtto
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoStoricoUpdate]
(
	@Id INT, 
	@IdProgetto INT, 
	@CodStato VARCHAR(255), 
	@Data DATETIME, 
	@Operatore INT, 
	@Segnatura VARCHAR(255), 
	@Revisione BIT, 
	@Riesame BIT, 
	@Ricorso BIT, 
	@RiaperturaProvinciale BIT, 
	@DataRi DATETIME, 
	@OperatoreRi INT, 
	@SegnaturaRi VARCHAR(255)
)
AS
	UPDATE PROGETTO_STORICO
	SET
		ID_PROGETTO = @IdProgetto, 
		COD_STATO = @CodStato, 
		DATA = @Data, 
		OPERATORE = @Operatore, 
		SEGNATURA = @Segnatura, 
		REVISIONE = @Revisione, 
		RIESAME = @Riesame, 
		RICORSO = @Ricorso, 
		RIAPERTURA_PROVINCIALE = @RiaperturaProvinciale, 
		DATA_RI = @DataRi, 
		OPERATORE_RI = @OperatoreRi, 
		SEGNATURA_RI = @SegnaturaRi
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoStoricoUpdate';

