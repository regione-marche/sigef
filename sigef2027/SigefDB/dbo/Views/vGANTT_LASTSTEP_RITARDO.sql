



CREATE VIEW [dbo].[vGANTT_LASTSTEP_RITARDO]
AS
/*
Seleziona tutti i gant con oggetto e bando, e - per i gantt in ritardo - indica quale è l'ultijmo step in ritardo e di quantio giorni
Utilizzata dalla vista vNOTIFICHE_GANTT per estrarre gli step in ritardo e segnalarli agli utenti interessati
Utilizzata in report che visualizza le date di ultimo aggiornamento di ogni GANTT
*/

SELECT        
    GANTT.ID_GANTT
	,asse.CODICE AS ASSE, asse.ID AS ID_ASSE, asse.DESCRIZIONE AS DESCRIZIONE_ASSE
	,azione.CODICE AS AZIONE, azione.DESCRIZIONE AS DESCRIZIONE_AZIONE 
    ,intervento.CODICE AS INTERVENTO, intervento.DESCRIZIONE AS DESCRIZIONE_INTERVENTO 
	,GANTT.ID_UO
	,UO.NOME AS NOME_UO
	,GANTT.ID_BANDO
	,GANTT_BANDO.OGGETTO
	,GANTT.DATA_LASTEDIT_STEPS
	,stepInRitardo.ID_STEP
	,stepInRitardo.DESCRIZIONE
	,stepInRitardo.DATA_FINE_PREVISTA
	,stepInRitardo.DATA_FINE_EFFETTIVA
	,stepInRitardo.RITARDO
FROM            
	GANTT inner join 
	GANTT_BANDO on GANTT_BANDO.ID_BANDO_GANTT = GANTT.ID_BANDO INNER JOIN
	dbo.UO ON dbo.UO.ID_UO = dbo.GANTT.ID_UO INNER JOIN
	dbo.zPROGRAMMAZIONE AS intervento ON intervento.ID = dbo.GANTT_BANDO.ID_PROGRAMMAZIONE INNER JOIN
    dbo.zPROGRAMMAZIONE AS azione ON azione.ID = intervento.ID_PADRE INNER JOIN
    dbo.zPROGRAMMAZIONE AS asse ON asse.ID = azione.ID_PADRE 
	left join
(
SELECT 
	  GANTT_STEPS.ID_GNATT
	  ,ID_STEP
	  ,TIPO_GANTT_PASSI.DESCRIZIONE
	  ,TIPO_GANTT_PASSI.VALORE_AUTOMATICO
      ,[DATA_FINE_PREVISTA]
      ,[DATA_FINE_EFFETTIVA]
      ,[VALORE_PREVISTO]
      ,[VALORE_EFFETTIVO]
	  ,case when DATEDIFF(day, DATA_FINE_PREVISTA, isnull(DATA_FINE_EFFETTIVA, GETDATE())) > 0 
	       then DATEDIFF(day, DATA_FINE_PREVISTA, isnull(DATA_FINE_EFFETTIVA, GETDATE()))
	       else 0 
		end as RITARDO
  FROM 
	GANTT_STEPS inner join
	(
		SELECT ID_GNATT, max([DATA_FINE_PREVISTA]) as dataFinePrevistaUltimoStep
		FROM [GANTT_STEPS]
		where DATA_FINE_PREVISTA <= getdate()
		group by [ID_GNATT]
	) ultimoSTEPFinoAdOggi
	on ultimoSTEPFinoAdOggi.ID_GNATT=GANTT_STEPS.ID_GNATT and ultimoSTEPFinoAdOggi.dataFinePrevistaUltimoStep=GANTT_STEPS.DATA_FINE_PREVISTA
	inner join TIPO_GANTT_PASSI on TIPO_GANTT_PASSI.ID_PASSO=GANTT_STEPS.ID_TIPO_PASSO
	where 
		-- solo se ci sono ritardi...
		DATEDIFF(day, DATA_FINE_PREVISTA, isnull(DATA_FINE_EFFETTIVA, GETDATE())) > 0 
		-- ... e solo se step in ritardo li devo ancora eseguire (se ho DATA_FINE_EFFETTIVA, anche se è in ritardo, è inutile segnalare)
		and DATA_FINE_EFFETTIVA is null
		-- considero solo step inseribili da utente (automatici ancora non funzionano)
		and TIPO_GANTT_PASSI.VALORE_AUTOMATICO = 0
		-- solo se ci sono ancora steps da concludere! (se no, anche se conclusi in ritardo, non ha senso segnalarlo)
		--and GANTT.ID_STATO=1
		and exists(select top 1 ID_STEP from GANTT_STEPS ganttNonConclusi where ganttNonConclusi.ID_GNATT=GANTT_STEPS.ID_GNATT and DATA_FINE_EFFETTIVA is null)
) stepInRitardo
ON GANTT.ID_GANTT = stepInRitardo.ID_GNATT
WHERE  GANTT.ID_STATO=1




