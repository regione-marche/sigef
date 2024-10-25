
-- =============================================
-- Author:		
-- Create date: 2018-06-19
-- Description:	Aggiorna i passi GANTT che prendono i valori in automatico dal SIGEF
-- Return: -1 se data = null; 0 se data = quella già inserita, 1 se data <> null e viene aggiornata
--
--   Legge data di controlli spesa SIGEF sulla base del GANTT e bando SIGEF collegati allo step @idStep
--   Se la data == null (es. gantt non abbinato a nessun bando SIGEF) ==> 
--     Se @dataSIGEFAttuale <> null --> la annulla sulla base della lettura attuale
--   Se la data != null ==> 
--     Se la data è diversa da quella salvata attualmente per lo step idStep ==> 
--       Aggiorna la DATA_FINE_EFFETTIVA nella tabella STEPS
--       Aggiorna la DATA_LASTEDIT_STEPS nella tabella GANTT, ma solo se data controlli spesa in SIGEF > DATA_LASTEDIT_STEPS attualmente impostata per il GANTT
-- =============================================
CREATE PROCEDURE [dbo].[spGanttSetPassoAuto014]
	@idStep int 
AS
BEGIN
	SET NOCOUNT ON;
	declare @dataSIGEF datetime = null         -- data che legge dal sigef, di controlli spesa del bando
	declare @dataSIGEFAttuale datetime = null  -- data attualemnte presente come valore di step
	declare @idGantt int = null                        -- id del GANTT da aggiornare
	declare @dataLastEditStepsGANTT datetime = null    -- data "Last Edit" STEP attualmente impostata per il gantt
	declare @dataLastEditStepsPassi datetime = null    -- data "Last Edit" STEP che verrà letta dai passi (== @dataPubblicaSIGEF, mi occupo solo di questo STEP specifico)
	declare @dataFineStep datetime = null             -- data fine prevista per lo step, servirà per leggere solo valori fino a tale data, ed impostare "data fine effettiva"

	 -- legge la data attualmente associata allo step e gantt di interesse, per vedere poi se è cambiata
	SELECT  
		@dataFineStep  = GANTT_STEPS.DATA_FINE_PREVISTA,
		@dataSIGEFAttuale = GANTT_STEPS.DATA_FINE_EFFETTIVA, @idGantt = GANTT_STEPS.ID_GNATT, @dataLastEditStepsGANTT=GANTT.DATA_LASTEDIT_STEPS
	FROM GANTT_STEPS inner join GANTT on GANTT_STEPS.ID_GNATT = GANTT.ID_GANTT
	WHERE GANTT_STEPS.ID_STEP=@idStep and GANTT_STEPS.ID_TIPO_PASSO in (14)

	if (@dataLastEditStepsGANTT is null) set @dataLastEditStepsGANTT = '19000101'
	-- se non ho ancora raggiunto la data fine prevista, considero la data di oggi per estrarre i dati
	if (@dataFineStep  is null or @dataFineStep  > GETDATE()) set @dataFineStep = GETDATE()

	--  Legge data di controlli spesa SIGEF sulla base del GANTT e bando SIGEF collegati allo step @idStep
	SELECT  @dataSIGEF = MAX(RDP.DATA_MODIFICA)
	FROM 
		CTE_TESTATA_VALIDAZIONE RDP
		INNER JOIN  DOMANDA_DI_PAGAMENTO DP ON RDP.ID_DOMANDA_PAGAMENTO = DP.ID_DOMANDA_PAGAMENTO
		INNER JOIN vPROGETTO P ON DP.ID_PROGETTO = P.ID_PROGETTO 
		INNER JOIN vBANDO B ON P.ID_BANDO = B.ID_BANDO
		INNER JOIN GANTT_BANDO ON B.ID_BANDO = GANTT_BANDO.ID_BANDO_BANDI 
        INNER JOIN GANTT ON GANTT_BANDO.ID_BANDO_GANTT = GANTT.ID_BANDO 
        INNER JOIN GANTT_STEPS ON GANTT.ID_GANTT = GANTT_STEPS.ID_GNATT
	WHERE 
		RDP.APPROVATA = 1 and RDP.DATA_MODIFICA <= @dataFineStep
		and GANTT_STEPS.ID_STEP=@idStep

	print 'dataSIGEFAttuale:'
	print @dataSIGEFAttuale
	print 'dataFineStep:'
	print @dataFineStep
	print 'dataLastEditStepsGANTT:' 
	print @dataLastEditStepsGANTT
	print 'dataSIGEF:' 
	print @dataSIGEF

	-- Se la data == null (es. bando non è pubblicato in SIGEF, oppure GANTT non abbinato a nessun bando SIGEF) ==> 
	if (@dataSIGEF is null) 
	begin
		print 'data di controlli spesa SIGEF non presente (= NULL)' 
		--  Se @dataPubblicaSIGEFAttuale <> null --> la annulla sulla base della lettura attuale
		if (@dataSIGEFAttuale is not null) begin
			print 'Annullamento DATA_FINE_EFFETTIVA (dataPubblicaSIGEF is null)' 
			-- insert in storico
			insert into GANTT_STEPS_STORICO
			SELECT 
				getdate() as [DATA_STORICO],[ID_STEP],[ID_GNATT],[ID_TIPO_PASSO],[ORDINE],[UO_PASSO],[DATA_INIZIO_PREVISTA],[DATA_INIZIO_EFFETTIVA],[DATA_FINE_PREVISTA],[DATA_FINE_EFFETTIVA],
				[NUM_GG_STANDARD],[VALORE_PREVISTO],[VALORE_EFFETTIVO],[NOTA_PREVISTO],[NOTA],[IS_IN_DEFINIZIONE],[DATA_INSERT],[DATA_LASTEDIT]
			FROM [sigefproduzione].[dbo].GANTT_STEPS where ID_STEP=@IdStep and ID_GNATT=@IdGantt
			-- aggiorna campo in DB
			update GANTT_STEPS set DATA_FINE_EFFETTIVA=null, DATA_INIZIO_EFFETTIVA=null, DATA_LASTEDIT=GETDATE() WHERE GANTT_STEPS.ID_STEP=@idStep
			-- aggiornamento data last edit steps di GANTT se @dataPubblicaSIGEFAttuale <> null (avevo associato dati ora modificati!)
		end
		return -1
	end;

	-- La data di controlli spesa esiste, ed è cambiata rispetto a quella presente nel DB
	if ((@dataSIGEFAttuale is null) or (
			convert(int,CONVERT(CHAR(8), @dataSIGEF, 112)) <> convert(int,CONVERT(CHAR(8), @dataSIGEFAttuale, 112))
		))
	begin
		print 'Impostazione DATA_FINE_EFFETTIVA = dataPubblicaSIGEF ' 
		-- insert in storico
		insert into GANTT_STEPS_STORICO
		SELECT 
			getdate() as [DATA_STORICO],[ID_STEP],[ID_GNATT],[ID_TIPO_PASSO],[ORDINE],[UO_PASSO],[DATA_INIZIO_PREVISTA],[DATA_INIZIO_EFFETTIVA],[DATA_FINE_PREVISTA],[DATA_FINE_EFFETTIVA],
			[NUM_GG_STANDARD],[VALORE_PREVISTO],[VALORE_EFFETTIVO],[NOTA_PREVISTO],[NOTA],[IS_IN_DEFINIZIONE],[DATA_INSERT],[DATA_LASTEDIT]
		FROM [sigefproduzione].[dbo].GANTT_STEPS where ID_STEP=@IdStep and ID_GNATT=@IdGantt
		-- aggiorna campo in DB
		update GANTT_STEPS set DATA_FINE_EFFETTIVA=@dataSIGEF, DATA_INIZIO_EFFETTIVA=@dataSIGEF, DATA_LASTEDIT=GETDATE() WHERE GANTT_STEPS.ID_STEP=@idStep

		-- data ultimo aggiornamento dgli steps
		set @dataLastEditStepsPassi = @dataSIGEF;
		if (convert(int,CONVERT(CHAR(8), @dataLastEditStepsPassi, 112)) > convert(int,CONVERT(CHAR(8), @dataLastEditStepsGANTT, 112))) begin
			print 'Impostazione DATA_LASTEDIT_STEPS del GANTT al valore dataPubblicaSIGEF' 
			update GANTT set DATA_LASTEDIT_STEPS = @dataLastEditStepsPassi where ID_GANTT=@idGantt
		end
		return 1
	end;

	-- data di controlli spesa in SIGEF esiste, ma non è cambiata rispetto a quella memorizzata
	print 'DATI NON VARIATI: la data di controlli spesa in SIGEF esiste, ma non è cambiata rispetto a quella memorizzata' 
	return 0

END

