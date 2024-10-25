
CREATE PROCEDURE [dbo].[ZGanttStepUpdate]
(
	@IdStep INT, 
	@IdTipoPasso INT, 
	@IdUO INT, 
	@DataInizioPrevista DATETIME, 
	@DataFinePrevista DATETIME, 
	@nGGStandard int, 
	@valorePrevisto decimal(18,4),
	@notaPrevisto varchar(2000)
)
AS
	UPDATE GANTT_STEPS
	SET
		ID_TIPO_PASSO=@IdTipoPasso, UO_PASSO=@IdUO,
		DATA_INIZIO_PREVISTA=@DataInizioPrevista, DATA_FINE_PREVISTA=@DataFinePrevista,
		NUM_GG_STANDARD=@nGGStandard, VALORE_PREVISTO=@valorePrevisto, NOTA_PREVISTO=@notaPrevisto, DATA_LASTEDIT = getdate()
	where ID_STEP=@IdStep

	--declare @idGantt int = 0;
	--select  @idGantt = ID_GNATT from gantt_steps where ID_STEP=@IdStep;
	--update GANTT set DATA_LASTEDIT_STEPS = GETDATE() where ID_GANTT = @idGantt;
