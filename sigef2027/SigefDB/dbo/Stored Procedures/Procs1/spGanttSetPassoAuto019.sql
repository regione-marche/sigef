
-- =============================================
-- Author:		
-- Create date: 2018-06-19
-- Description:	Aggiorna i passi GANTT che prendono i valori in automatico dal SIGEF
-- Return: -1 se data = null; 0 se data = quella già inserita, 1 se data <> null e viene aggiornata
--
--   Legge data di Decreto Concessione contributi SIGEF sulla base del GANTT e bando SIGEF collegati allo step @idStep
--   Se la data == null (es. gantt non abbinato a nessun bando SIGEF) ==> 
--     Se @dataSIGEFAttuale <> null --> la annulla sulla base della lettura attuale
--   Se la data != null ==> 
--     Se la data è diversa da quella salvata attualmente per lo step idStep ==> 
--       Aggiorna la DATA_FINE_EFFETTIVA nella tabella STEPS
--       Aggiorna la DATA_LASTEDIT_STEPS nella tabella GANTT, ma solo se data controlli spesa in SIGEF > DATA_LASTEDIT_STEPS attualmente impostata per il GANTT
-- =============================================
create PROCEDURE [dbo].[spGanttSetPassoAuto019]
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
	WHERE GANTT_STEPS.ID_STEP=@idStep and GANTT_STEPS.ID_TIPO_PASSO in (19)

	if (@dataLastEditStepsGANTT is null) set @dataLastEditStepsGANTT = '19000101'
	-- se non ho ancora raggiunto la data fine prevista, considero la data di oggi per estrarre i dati
	if (@dataFineStep  is null or @dataFineStep  > GETDATE()) set @dataFineStep = GETDATE()

	--  Legge data di SIGEF sulla base del GANTT e bando SIGEF collegati allo step @idStep
	SELECT 
		@dataSIGEF=MAX(DATA_IMPEGNO) 
	FROM 
	(SELECT 
		B.ID_BANDO,
		P.ID_PROGETTO,
		CASE WHEN BC.COD_TIPO IS NOT NULL 
		THEN 
		ATTI_P.DATA --AS COD_IMPEGNO,
		ELSE 
		ATTI_B.DATA END AS DATA_IMPEGNO 
		FROM
		vPROGETTO P
		INNER JOIN vBANDO B ON
		P.ID_BANDO = B.ID_BANDO
		LEFT OUTER JOIN GRADUATORIA_PROGETTI GPR ON
		P.ID_PROGETTO = GPR.ID_PROGETTO
		LEFT OUTER JOIN BANDO_CONFIG BC ON
		B.ID_BANDO = BC.ID_BANDO 
		AND 
		BC.COD_TIPO = 'ATTGRADBLOCCHI'
		AND 
		BC.ATTIVO = 1
		LEFT OUTER JOIN 
		(
			SELECT 
			BS.ID_BANDO,
			MAX(BS.ID_ATTO) ID_ATTO
			FROM BANDO_STORICO BS 
			WHERE BS.COD_STATO = 'G'
			GROUP BY ID_BANDO) GB ON
			B.ID_BANDO = GB.ID_BANDO
			LEFT OUTER JOIN ATTI ATTI_B ON 
			GB.ID_ATTO = ATTI_B.ID_ATTO
			LEFT OUTER JOIN 
			(
				SELECT 
				PS.ID_PROGETTO,
				MAX(PS.ID_ATTO) ID_ATTO
				FROM PROGETTO_STORICO PS 
				WHERE PS.COD_STATO = 'F'
				GROUP BY ID_PROGETTO
			) GP ON
		P.ID_PROGETTO = GP.ID_PROGETTO
		LEFT OUTER JOIN ATTI ATTI_P ON
		GP.ID_ATTO = ATTI_P.ID_ATTO
		INNER JOIN PROGETTO_STORICO PS ON 
		P.ID_PROGETTO = PS.ID_PROGETTO
		AND 
		PS.COD_STATO ='F'
	) AS A
	INNER JOIN GANTT_BANDO ON A.ID_BANDO = GANTT_BANDO.ID_BANDO_BANDI 
	INNER JOIN GANTT ON GANTT_BANDO.ID_BANDO_GANTT = GANTT.ID_BANDO 
	INNER JOIN GANTT_STEPS ON GANTT.ID_GANTT = GANTT_STEPS.ID_GNATT
	where GANTT_STEPS.ID_STEP=@idStep and DATA_IMPEGNO  <= @dataFineStep


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
		print 'data di Decreto Concessione contributi SIGEF non presente (= NULL)' 
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

	-- La data Decreto Concessione contributi esiste, ed è cambiata rispetto a quella presente nel DB
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
	print 'DATI NON VARIATI: la data Decreto Concessione contributi in SIGEF esiste, ma non è cambiata rispetto a quella memorizzata' 
	return 0

END

