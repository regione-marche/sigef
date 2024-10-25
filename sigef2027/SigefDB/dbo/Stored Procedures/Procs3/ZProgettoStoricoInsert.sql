CREATE PROCEDURE [dbo].[ZProgettoStoricoInsert]
(
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
	SET @Revisione = ISNULL(@Revisione,((0)))
	SET @Riesame = ISNULL(@Riesame,((0)))
	SET @Ricorso = ISNULL(@Ricorso,((0)))
	SET @RiaperturaProvinciale = ISNULL(@RiaperturaProvinciale,((0)))
	INSERT INTO PROGETTO_STORICO
	(
		ID_PROGETTO, 
		COD_STATO, 
		DATA, 
		OPERATORE, 
		SEGNATURA, 
		REVISIONE, 
		RIESAME, 
		RICORSO, 
		RIAPERTURA_PROVINCIALE, 
		DATA_RI, 
		OPERATORE_RI, 
		SEGNATURA_RI, 
		ID_ATTO
	)
	VALUES
	(
		@IdProgetto, 
		@CodStato, 
		@Data, 
		@Operatore, 
		@Segnatura, 
		@Revisione, 
		@Riesame, 
		@Ricorso, 
		@RiaperturaProvinciale, 
		@DataRi, 
		@OperatoreRi, 
		@SegnaturaRi, 
		@IdAtto
	)
	SELECT SCOPE_IDENTITY() AS ID, @Revisione AS REVISIONE, @Riesame AS RIESAME, @Ricorso AS RICORSO, @RiaperturaProvinciale AS RIAPERTURA_PROVINCIALE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoStoricoInsert]
(
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
	SET @Revisione = ISNULL(@Revisione,((0)))
	SET @Riesame = ISNULL(@Riesame,((0)))
	SET @Ricorso = ISNULL(@Ricorso,((0)))
	SET @RiaperturaProvinciale = ISNULL(@RiaperturaProvinciale,((0)))
	INSERT INTO PROGETTO_STORICO
	(
		ID_PROGETTO, 
		COD_STATO, 
		DATA, 
		OPERATORE, 
		SEGNATURA, 
		REVISIONE, 
		RIESAME, 
		RICORSO, 
		RIAPERTURA_PROVINCIALE, 
		DATA_RI, 
		OPERATORE_RI, 
		SEGNATURA_RI
	)
	VALUES
	(
		@IdProgetto, 
		@CodStato, 
		@Data, 
		@Operatore, 
		@Segnatura, 
		@Revisione, 
		@Riesame, 
		@Ricorso, 
		@RiaperturaProvinciale, 
		@DataRi, 
		@OperatoreRi, 
		@SegnaturaRi
	)
	SELECT SCOPE_IDENTITY() AS ID, @Revisione AS REVISIONE, @Riesame AS RIESAME, @Ricorso AS RICORSO, @RiaperturaProvinciale AS RIAPERTURA_PROVINCIALE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoStoricoInsert';

