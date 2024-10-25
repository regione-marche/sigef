





CREATE VIEW [dbo].[vNOTIFICHE_GANTT]
AS
/* 
	Elenco di utenti, e mail e relativi gant con passi in ritardo
	utilizza la vista vGANTT_LASTSTEP_RITARDO prendendo i soli GANTT con passi in ritardo 
*/

SELECT        
	dbo.UTENTI.ID_PERSONA_FISICA, dbo.UTENTI_STORICO.ID_PROFILO, 
	UTENTI_STORICO.EMAIL
	, dbo.UTENTI_STORICO.COD_ENTE
	,dbo.GANTT_UO_SIGEF.ID_UO
	,stepInRitardo.ID_GANTT
	,GANTT_BANDO.OGGETTO
	,stepInRitardo.DATA_LASTEDIT_STEPS
	,stepInRitardo.ID_STEP
	,stepInRitardo.DESCRIZIONE
	,stepInRitardo.DATA_FINE_PREVISTA
	,stepInRitardo.DATA_FINE_EFFETTIVA
	,stepInRitardo.RITARDO
FROM            
	dbo.UTENTI INNER JOIN
    dbo.UTENTI_STORICO ON dbo.UTENTI.ID_STORICO_ULTIMO = dbo.UTENTI_STORICO.ID INNER JOIN
    dbo.GANTT_UO_SIGEF ON dbo.UTENTI_STORICO.COD_ENTE = dbo.GANTT_UO_SIGEF.COD_ENTE_SIGEF INNER JOIN
    dbo.PROFILO_X_FUNZIONI ON dbo.UTENTI_STORICO.ID_PROFILO = dbo.PROFILO_X_FUNZIONI.ID_PROFILO INNER JOIN
    dbo.FUNZIONALITA ON dbo.PROFILO_X_FUNZIONI.COD_FUNZIONE = dbo.FUNZIONALITA.COD_FUNZIONE INNER JOIN

-- questa riga sostituisce la parte successiva:
	vGANTT_LASTSTEP_RITARDO stepInRitardo

/* PARTE SOSTITUITA da vGANTT_LASTSTEP_RITARDO
(
SELECT 
      GANTT.ID_GANTT
	  ,GANTT.ID_UO
	  ,ID_BANDO
	  ,GANTT.DATA_LASTEDIT_STEPS
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
	inner join GANTT on GANTT_STEPS.ID_GNATT=GANTT.ID_GANTT
	where 
		-- solo se ci sono ritardi...
		DATEDIFF(day, DATA_FINE_PREVISTA, isnull(DATA_FINE_EFFETTIVA, GETDATE())) > 0 
		-- ... e solo se step in ritardo li devo ancora eseguire (se ho DATA_FINE_EFFETTIVA, anche se è in ritardo, è inutile segnalare)
		and DATA_FINE_EFFETTIVA is null
		-- considero solo step inseribili da utente (automatici ancora non funzionano)
		and TIPO_GANTT_PASSI.VALORE_AUTOMATICO = 0
		-- solo se ci sono ancora steps da concludere! (se no, anche se conclusi in ritardo, non ha senso segnalarlo)
		and GANTT.ID_STATO=1
		and exists(select top 1 ID_STEP from GANTT_STEPS ganttNonConclusi where ganttNonConclusi.ID_GNATT=GANTT_STEPS.ID_GNATT and DATA_FINE_EFFETTIVA is null)
) stepInRitardo
 FIEN SOSTITUITA da vGANTT_LASTSTEP_RITARDO */

ON dbo.GANTT_UO_SIGEF.ID_UO = stepInRitardo.ID_UO

inner join GANTT_BANDO on GANTT_BANDO.ID_BANDO_GANTT = stepInRitardo.ID_BANDO
WHERE        (dbo.FUNZIONALITA.DESC_MENU = 'gantt') AND (dbo.UTENTI_STORICO.EMAIL LIKE '%.marche.it')

-- riga aggiunta per usare vGANTT_LASTSTEP_RITARDO:
and stepInRitardo.ID_STEP is not null


