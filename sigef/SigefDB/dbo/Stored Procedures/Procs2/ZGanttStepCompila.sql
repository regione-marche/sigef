
CREATE PROCEDURE [dbo].[ZGanttStepCompila]
(
 	@IdGantt INT, 
	@IdStep INT, 
	@DataInizioEffettiva DATETIME, 
	@DataFineEffettiva DATETIME, 
	@ValoreEffettivo decimal(18,4),
	@Nota varchar(200)
)
AS
	-- insert in storico
	insert into GANTT_STEPS_STORICO
	SELECT 
	  getdate() as [DATA_STORICO]
	  ,[ID_STEP]
	  ,[ID_GNATT]
	  ,[ID_TIPO_PASSO]
      ,[ORDINE]
      ,[UO_PASSO]
      ,[DATA_INIZIO_PREVISTA]
      ,[DATA_INIZIO_EFFETTIVA]
      ,[DATA_FINE_PREVISTA]
      ,[DATA_FINE_EFFETTIVA]
      ,[NUM_GG_STANDARD]
      ,[VALORE_PREVISTO]
      ,[VALORE_EFFETTIVO]
      ,[NOTA_PREVISTO]
      ,[NOTA]
      ,[IS_IN_DEFINIZIONE]
      ,[DATA_INSERT]
      ,[DATA_LASTEDIT]
  FROM [sigefproduzione].[dbo].GANTT_STEPS where ID_STEP=@IdStep and ID_GNATT=@IdGantt

	UPDATE GANTT_STEPS
	SET
		DATA_INIZIO_EFFETTIVA=@DataInizioEffettiva, DATA_FINE_EFFETTIVA=@DataFineEffettiva,
		VALORE_EFFETTIVO=@ValoreEffettivo, NOTA=@Nota, DATA_LASTEDIT = getdate()
	where ID_STEP=@IdStep and ID_GNATT=@IdGantt

	update GANTT set DATA_LASTEDIT_STEPS = GETDATE() where ID_GANTT = @IdGantt;