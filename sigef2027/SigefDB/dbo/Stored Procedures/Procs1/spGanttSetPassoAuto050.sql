
-- =============================================
-- Author:		
-- Create date: 2018-06-07
-- Description:	Aggiorna i passi GANTT che prendono i valori in automatico dal SIGEF (ID_TIPO = 5 e 36)
-- Return: -1 se data = null; 0 se data = quella già inserita, 1 se data <> null e viene aggiornata
--
--   Legge data di pubblicazione SIGEF sulla base del GANTT e bando SIGEF collegati allo step @idStep
--   Se la data == null (es. gantt non abbinato a nessun bando SIGEF) ==> 
--     Se @dataPubblicaSIGEFAttuale <> null --> la annulla sulla base della lettura attuale
--   Se la data != null ==> 
--     Se la data è diversa da quella salvata attualmente per lo step idStep ==> 
--       Aggiorna la DATA_FINE_EFFETTIVA nella tabella STEPS
--       Aggiorna la DATA_LASTEDIT_STEPS nella tabella GANTT, ma solo se data pubblicazione in SIGEF > DATA_LASTEDIT_STEPS attualmente impostata per il GANTT
-- =============================================
CREATE PROCEDURE [dbo].[spGanttSetPassoAuto050]
	@idStep int 
AS
BEGIN
	SET NOCOUNT ON;
	declare @dataPubblicaSIGEF datetime = null         -- data che legge dal sigef, di pubblicazione del bando
	declare @dataPubblicaSIGEFAttuale datetime = null  -- data attualemnte presente come valore di step
	declare @idGantt int = null                        -- id del GANTT da aggiornare
	declare @dataLastEditStepsGANTT datetime = null    -- data "Last Edit" STEP attualmente impostata per il gantt
	declare @dataLastEditStepsPassi datetime = null    -- data "Last Edit" STEP che verrà letta dai passi (== @dataPubblicaSIGEF, mi occupo solo di questo STEP specifico)

	 -- legge la data attualmente associata allo step e gantt di interesse, per vedere poi se è cambiata
	SELECT  
		@dataPubblicaSIGEFAttuale = GANTT_STEPS.DATA_FINE_EFFETTIVA, @idGantt = GANTT_STEPS.ID_GNATT, @dataLastEditStepsGANTT=GANTT.DATA_LASTEDIT_STEPS
	FROM GANTT_STEPS inner join GANTT on GANTT_STEPS.ID_GNATT = GANTT.ID_GANTT
	WHERE GANTT_STEPS.ID_STEP=@idStep and GANTT_STEPS.ID_TIPO_PASSO in (50)
	if (@dataLastEditStepsGANTT is null) set @dataLastEditStepsGANTT = '19000101'

	--  Legge data di pubblicazione SIGEF sulla base del GANTT e bando SIGEF collegati allo step @idStep
	SELECT  @dataPubblicaSIGEF = DATEADD(DAY, -10, min(BS.DATA))
	FROM            vBANDO_STORICO AS BS INNER JOIN
                         GANTT_BANDO ON BS.ID_BANDO = GANTT_BANDO.ID_BANDO_BANDI INNER JOIN
                         GANTT ON GANTT_BANDO.ID_BANDO_GANTT = GANTT.ID_BANDO INNER JOIN
                         GANTT_STEPS ON GANTT.ID_GANTT = GANTT_STEPS.ID_GNATT
	WHERE        (BS.COD_STATO = 'P') and GANTT_STEPS.ID_STEP=@idStep

	print 'dataPubblicaSIGEFAttuale:'
	print @dataPubblicaSIGEFAttuale
	print 'dataLastEditStepsGANTT:' 
	print @dataLastEditStepsGANTT
	print 'dataPubblicaSIGEF:' 
	print @dataPubblicaSIGEF

	-- Se la data == null (es. bando non è pubblicato in SIGEF, oppure GANTT non abbinato a nessun bando SIGEF) ==> 
	if (@dataPubblicaSIGEF is null) 
	begin
		print 'data di pubblicazione SIGEF non presente (= NULL)' 
		--  Se @dataPubblicaSIGEFAttuale <> null --> la annulla sulla base della lettura attuale
		if (@dataPubblicaSIGEFAttuale is not null) begin
			print 'Annullamento DATA_FINE_EFFETTIVA (dataPubblicaSIGEF is null)' 
			-- insert in storico
			insert into GANTT_STEPS_STORICO
			SELECT 
				getdate() as [DATA_STORICO],[ID_STEP],[ID_GNATT],[ID_TIPO_PASSO],[ORDINE],[UO_PASSO],[DATA_INIZIO_PREVISTA],[DATA_INIZIO_EFFETTIVA],[DATA_FINE_PREVISTA],[DATA_FINE_EFFETTIVA],
				[NUM_GG_STANDARD],[VALORE_PREVISTO],[VALORE_EFFETTIVO],[NOTA_PREVISTO],[NOTA],[IS_IN_DEFINIZIONE],[DATA_INSERT],[DATA_LASTEDIT]
			FROM [sigefproduzione].[dbo].GANTT_STEPS where ID_STEP=@IdStep and ID_GNATT=@IdGantt
			-- aggiorna campo in DB
			update GANTT_STEPS set DATA_FINE_EFFETTIVA=null,DATA_INIZIO_EFFETTIVA=null, DATA_LASTEDIT=GETDATE() WHERE GANTT_STEPS.ID_STEP=@idStep
			-- aggiornamento data last edit steps di GANTT se @dataPubblicaSIGEFAttuale <> null (avevo associato dati ora modificati!)
		end
		return -1
	end;

	-- La data di pubblicazione esiste, ed è cambiata rispetto a quella presente nel DB
	if ((@dataPubblicaSIGEFAttuale is null) or (
			convert(int,CONVERT(CHAR(8), @dataPubblicaSIGEF, 112)) <> convert(int,CONVERT(CHAR(8), @dataPubblicaSIGEFAttuale, 112))
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
		update GANTT_STEPS set DATA_FINE_EFFETTIVA=@dataPubblicaSIGEF, DATA_INIZIO_EFFETTIVA=@dataPubblicaSIGEF, DATA_LASTEDIT=GETDATE() WHERE GANTT_STEPS.ID_STEP=@idStep

		-- data ultimo aggiornamento dgli steps
		set @dataLastEditStepsPassi = @dataPubblicaSIGEF;
		if (convert(int,CONVERT(CHAR(8), @dataLastEditStepsPassi, 112)) > convert(int,CONVERT(CHAR(8), @dataLastEditStepsGANTT, 112))) begin
			print 'Impostazione DATA_LASTEDIT_STEPS del GANTT al valore dataPubblicaSIGEF' 
			update GANTT set DATA_LASTEDIT_STEPS = @dataLastEditStepsPassi where ID_GANTT=@idGantt
		end
		return 1
	end;

	-- data di pubblicazione in SIGEF esiste, ma non è cambiata rispetto a quella memorizzata
	print 'DATI NON VARIATI: la data di pubblicazione in SIGEF esiste, ma non è cambiata rispetto a quella memorizzata' 
	return 0

END

