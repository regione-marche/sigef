
-- =============================================
-- Author:		
-- Create date: 2018-06-19
-- Description:	Aggiorna i passi GANTT che prendono i valori in automatico dal SIGEF 
--	 Inserisce il valore nel passo @idStep di Tipo PASSO = 13 - Pagamento Anticipi /SAL/Saldo
-- Return: -1 se data = null; 0 se data = quella già inserita, 1 se data <> null e viene aggiornata
--
--   Legge il valore dei pagamenti dal SIGEF sulla base del GANTT e bando SIGEF collegati allo step @idStep, 
--   considerando il range di date:
--      - @dataFinePrevStepPrec = Data inizio = (se ho uno step pagamenti previsto precedente a @idStap, dataInizio = dataFine dello step precedente) altrimenti (dataInizio = 01/01/1990)
--      - @dataFineStep = Data fine = (se oggi < DATA_FINE_PREVISTA dello step --> Data fine = oggi) altrimenti (dataFine = DATA_FINE_PREVISTA dello step stesso)
--   Se importo == null (es. gantt non abbinato a nessun bando SIGEF) ==> 
--     Se @valoreSIGEFAttuale <> null --> lo annulla sulla base della lettura attuale
--   Se importo != null ==> 
--     Se importo è diverso da quella salvata attualmente per lo step idStep ==> 
--       Aggiorna VALORE_EFFETTIVO nella tabella STEPS
--       Aggiorna la DATA_LASTEDIT_STEPS nella tabella GANTT, ma solo se ......???? > DATA_LASTEDIT_STEPS attualmente impostata per il GANTT
-- =============================================
CREATE PROCEDURE [dbo].[spGanttSetPassoAuto013]
	@idStep int 
AS
BEGIN
	SET NOCOUNT ON;
	declare @valoreSIGEF decimal(18,2) = null          -- valore che legge dal sigef = pagamenti alla data DATA_FINE_PREVISTA
	declare @valoreSIGEFAttuale decimal(18,2) = null   -- valore attualemnte presente come valore di step
	declare @idGantt int = null                        -- id del GANTT da aggiornare
	declare @dataLastEditStepsGANTT datetime = null    -- data "Last Edit" STEP attualmente impostata per il gantt
	declare @dataLastEditStepsPassi datetime = null    -- data "Last Edit" STEP che verrà letta dai passi (== ???)
	declare @dataFineStep  datetime = null             -- data fine prevista per lo step, servirà per impostare "data fine effettiva"
	declare @maxDataPagam datetime = null              -- ultima data in cui ho fatto un pagamento, servirà per impostare "data fine effettiva"
	declare @dataFinePrevStepPrec datetime = null      -- data fine prevista step precedente, serve epr calcolare importi solo sul periodo, non cumulativi con periodi precedenti

	 -- legge la data attualmente associata allo step e gantt di interesse, per vedere poi se è cambiata
	SELECT  
		@dataFineStep  = GANTT_STEPS.DATA_FINE_PREVISTA,
		@valoreSIGEFAttuale = GANTT_STEPS.VALORE_EFFETTIVO, @idGantt = GANTT_STEPS.ID_GNATT, @dataLastEditStepsGANTT=GANTT.DATA_LASTEDIT_STEPS
	FROM GANTT_STEPS inner join GANTT on GANTT_STEPS.ID_GNATT = GANTT.ID_GANTT
	WHERE GANTT_STEPS.ID_STEP=@idStep and GANTT_STEPS.ID_TIPO_PASSO in (13)

	-- ** PER IMPORTI PAGAMENTI = SOLO in un PERIODO, NON CUMULATIVI **--
	 -- legge la data fine prevista per un eventuale step di pagamento precedente a quello corrente
	SELECT  
		@dataFinePrevStepPrec  = GANTT_STEPS.DATA_FINE_PREVISTA
	FROM GANTT_STEPS inner join GANTT on GANTT_STEPS.ID_GNATT = GANTT.ID_GANTT
	WHERE GANTT.ID_GANTT = @idGantt and GANTT_STEPS.ID_TIPO_PASSO in (13) and DATA_FINE_PREVISTA < @dataFineStep


	if (@dataLastEditStepsGANTT is null) set @dataLastEditStepsGANTT = '19000101'
	-- se non ho ancora raggiunto la data fine prevista, considero la data di oggi per estrarre pagamenti
	if (@dataFineStep  is null or @dataFineStep  > GETDATE()) set @dataFineStep = GETDATE()
	-- se non ho step precedente considero data molto vecchia, per prendere tutti i pagamenti fino ad oggi
	if (@dataFinePrevStepPrec is null) set @dataFinePrevStepPrec =  convert(datetime, '19900101', 112) 

	--  Legge valore pagamenti alla data @dataFinePrevistaStep, sulla base del GANTT e bando SIGEF collegati allo step @idStep
	SELECT @valoreSIGEF=sum(PR.QUIETANZA_IMPORTO), @maxDataPagam = MAX(PR.QUIETANZA_DATA)
	FROM 
		DOMANDA_DI_PAGAMENTO_ESPORTAZIONE DPE
		INNER JOIN DOMANDA_PAGAMENTO_LIQUIDAZIONE PR ON DPE.ID_DOMANDA_PAGAMENTO = PR.ID_DOMANDA_PAGAMENTO
		INNER JOIN vPROGETTO P ON P.ID_PROGETTO = DPE.ID_PROGETTO
		INNER JOIN vBANDO B ON P.ID_BANDO = B.ID_BANDO
		INNER JOIN GANTT_BANDO ON B.ID_BANDO = GANTT_BANDO.ID_BANDO_BANDI
		INNER JOIN GANTT ON GANTT_BANDO.ID_BANDO_GANTT = GANTT.ID_BANDO
		INNER JOIN GANTT_STEPS ON GANTT.ID_GANTT = GANTT_STEPS.ID_GNATT
	WHERE 
		PR.QUIETANZA_DATA IS NOT NULL and PR.QUIETANZA_DATA <= @dataFineStep  
		and PR.QUIETANZA_DATA >= @dataFinePrevStepPrec  -- per calcolare pagamenti su singolo range (non la somma di periodi fino a @dataFineStep)
		and GANTT_STEPS.ID_STEP=@idStep
	
	-- comwe data fine effettiva considero data dell'ultimo pagamento fatto
	if (@maxDataPagam is not null) set @dataFineStep  = @maxDataPagam;

	print 'valoreSIGEFAttuale:'
	print @valoreSIGEFAttuale
	print 'dataFineStep:'
	print @dataFineStep
	print 'maxDataPagam:'
	print @maxDataPagam
	print 'dataLastEditStepsGANTT:' 
	print @dataLastEditStepsGANTT
	print 'valoreSIGEF:' 
	print @valoreSIGEF

	-- Se la data == null (es. bando non è pubblicato in SIGEF, oppure GANTT non abbinato a nessun bando SIGEF) ==> 
	if (@valoreSIGEF is null or @maxDataPagam is null) 
	begin
		print 'valore o data pagamento non presente in SIGEF (= NULL)' 
		--  Se @valoreSIGEFAttuale <> null --> lo annulla sulla base della lettura attuale
		if (@valoreSIGEFAttuale is not null) begin
			print 'Annullamento VALORE_EFFETTIVO (@valoreSIGEF is null)' 
			-- insert in storico
			insert into GANTT_STEPS_STORICO
			SELECT 
				getdate() as [DATA_STORICO],[ID_STEP],[ID_GNATT],[ID_TIPO_PASSO],[ORDINE],[UO_PASSO],[DATA_INIZIO_PREVISTA],[DATA_INIZIO_EFFETTIVA],[DATA_FINE_PREVISTA],[DATA_FINE_EFFETTIVA],
				[NUM_GG_STANDARD],[VALORE_PREVISTO],[VALORE_EFFETTIVO],[NOTA_PREVISTO],[NOTA],[IS_IN_DEFINIZIONE],[DATA_INSERT],[DATA_LASTEDIT]
			FROM [sigefproduzione].[dbo].GANTT_STEPS where ID_STEP=@IdStep and ID_GNATT=@IdGantt
			-- aggiorna campo in DB
			update GANTT_STEPS set VALORE_EFFETTIVO=null, DATA_FINE_EFFETTIVA=NULL, DATA_INIZIO_EFFETTIVA=NULL, DATA_LASTEDIT=GETDATE() WHERE GANTT_STEPS.ID_STEP=@idStep
			-- aggiornamento data last edit steps di GANTT se @dataPubblicaSIGEFAttuale <> null (avevo associato dati ora modificati!)
		end
		return -1
	end;

	-- Il valore esiste, ed è cambiato rispetto a quella presente nel DB
	if (@valoreSIGEFAttuale is null or @valoreSIGEF <> @valoreSIGEFAttuale)
	begin
		print 'Impostazione VALORE_EFFETTIVO = valoreSIGEF ' 
		-- insert in storico
		insert into GANTT_STEPS_STORICO
		SELECT 
			getdate() as [DATA_STORICO],[ID_STEP],[ID_GNATT],[ID_TIPO_PASSO],[ORDINE],[UO_PASSO],[DATA_INIZIO_PREVISTA],[DATA_INIZIO_EFFETTIVA],[DATA_FINE_PREVISTA],[DATA_FINE_EFFETTIVA],
			[NUM_GG_STANDARD],[VALORE_PREVISTO],[VALORE_EFFETTIVO],[NOTA_PREVISTO],[NOTA],[IS_IN_DEFINIZIONE],[DATA_INSERT],[DATA_LASTEDIT]
		FROM [sigefproduzione].[dbo].GANTT_STEPS where ID_STEP=@IdStep and ID_GNATT=@IdGantt
		-- aggiorna campo in DB
		update GANTT_STEPS set VALORE_EFFETTIVO=@valoreSIGEF, DATA_FINE_EFFETTIVA=@dataFineStep, DATA_INIZIO_EFFETTIVA=@dataFineStep, DATA_LASTEDIT=GETDATE() WHERE GANTT_STEPS.ID_STEP=@idStep

		-- data ultimo aggiornamento dgli steps
		set @dataLastEditStepsPassi = @dataFineStep;
		if (convert(int,CONVERT(CHAR(8), @dataLastEditStepsPassi, 112)) > convert(int,CONVERT(CHAR(8), @dataLastEditStepsGANTT, 112))) begin
			print 'Impostazione DATA_LASTEDIT_STEPS del GANTT al valore dataFineStep' 
			update GANTT set DATA_LASTEDIT_STEPS = @dataLastEditStepsPassi where ID_GANTT=@idGantt
		end
		return 1
	end;

	-- data di pubblicazione in SIGEF esiste, ma non è cambiata rispetto a quella memorizzata
	print 'DATI NON VARIATI: importo in SIGEF esiste, ma non è cambiata rispetto a quello memorizzato' 
	return 0

END

