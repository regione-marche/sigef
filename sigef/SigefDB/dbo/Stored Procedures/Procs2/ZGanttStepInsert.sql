
CREATE PROCEDURE [dbo].[ZGanttStepInsert]
(
	@IdGantt INT, 
	@IdTipoPasso INT, 
	@IdUO INT, 
	@DataInizioPrevista DATETIME, 
	@DataFinePrevista DATETIME, 
	@nGGStandard int, 
	@valorePrevisto decimal(18,4),
	@notaPrevisto varchar(2000),
	@isInDefinizione bit = 0
)
AS
	--update GANTT set DATA_LASTEDIT_STEPS = GETDATE() where ID_GANTT = @IdGantt;

	INSERT INTO GANTT_STEPS
	(
		ID_GNATT,  ID_TIPO_PASSO, UO_PASSO,
		DATA_INIZIO_PREVISTA, DATA_FINE_PREVISTA,
		NUM_GG_STANDARD, VALORE_PREVISTO, NOTA_PREVISTO, 
		IS_IN_DEFINIZIONE, DATA_INSERT, DATA_LASTEDIT
	)
	VALUES
	(
		@IdGantt, @IdTipoPasso, @IdUO,
		@DataInizioPrevista, @DataFinePrevista, 
		@nGGStandard, @valorePrevisto, @notaPrevisto,
		@isInDefinizione, GETDATE(), GETDATE()
	)

	SELECT SCOPE_IDENTITY() AS ID
