﻿

CREATE VIEW [dbo].[vESTRAZIONE_GLOBALE_FESR_PROGETTI_DOMANDE_PAGAMENTO]
AS
WITH BRT AS
(
      SELECT  
      dbo.PROGETTO.ID_PROGETTO,
      dbo.PROGETTO.ID_BANDO,
      dbo.BANDO_RELAZIONE_TECNICA.ORDINE,
      ROW_NUMBER() OVER(PARTITION BY PROGETTO.ID_PROGETTO, dbo.BANDO_RELAZIONE_TECNICA.ORDINE ORDER BY PROGETTO.ID_PROGETTO, dbo.BANDO_RELAZIONE_TECNICA.ORDINE ASC) AS ORDER_ROW,
      dbo.PROGETTO_RELAZIONE_TECNICA.TESTO
      FROM        
      dbo.BANDO_RELAZIONE_TECNICA
      INNER JOIN
      dbo.PROGETTO_RELAZIONE_TECNICA ON
      dbo.BANDO_RELAZIONE_TECNICA.ID_PARAGRAFO = dbo.PROGETTO_RELAZIONE_TECNICA.ID_PARAGRAFO
      INNER JOIN
      dbo.PROGETTO ON
      dbo.PROGETTO_RELAZIONE_TECNICA.ID_PROGETTO = dbo.PROGETTO.ID_PROGETTO
      WHERE
      dbo.BANDO_RELAZIONE_TECNICA.ORDINE IN (1,2)
)
,
PSIC AS (
      SELECT
      MIN(PS1.DATA) AS DATA,
      PS1.ID_PROGETTO,
      PS1.COD_STATO
      FROM PROGETTO_STORICO PS1
      GROUP BY
      PS1.ID_PROGETTO,
      PS1.COD_STATO
)
,
CTE_PROGRAMMAZIONE AS 
(
	SELECT rootTree.ID,rootTree.COD_TIPO,rootTree.CODICE,rootTree.DESCRIZIONE,rootTree.ID_PADRE,rootTree.COD_PSR,
	rootTree.TIPO,rootTree.LIVELLO,rootTree.ATTIVAZIONE_BANDI,rootTree.ATTIVAZIONE_FA,rootTree.ATTIVAZIONE_OB_MISURA,
	rootTree.ATTIVAZIONE_INVESTIMENTI,rootTree.ATTIVAZIONE_FF,CONVERT(VARCHAR(MAX),rootTree.PathSequence) AS PathLabel
	FROM (
	SELECT ID,COD_TIPO,CODICE,DESCRIZIONE,ID_PADRE,COD_PSR,TIPO,LIVELLO,ATTIVAZIONE_BANDI,
	ATTIVAZIONE_FA,ATTIVAZIONE_OB_MISURA,ATTIVAZIONE_INVESTIMENTI,ATTIVAZIONE_FF,
	char(64 + ROW_NUMBER() OVER(ORDER BY COD_PSR+CAST(LIVELLO AS VARCHAR(5))+CODICE)) AS PathSequence
	FROM VZPROGRAMMAZIONE WHERE COD_PSR='POR20142020' AND ID_PADRE=0) rootTree -- Anchor/root term
	UNION ALL
	SELECT subTree.ID,subTree.COD_TIPO,subTree.CODICE,subTree.DESCRIZIONE,subTree.ID_PADRE,subTree.COD_PSR,
	subTree.TIPO,subTree.LIVELLO,subTree.ATTIVAZIONE_BANDI,subTree.ATTIVAZIONE_FA,subTree.ATTIVAZIONE_OB_MISURA,
	subTree.ATTIVAZIONE_INVESTIMENTI,subTree.ATTIVAZIONE_FF,PathLabel = subTree.PathLabel + CONVERT(VARCHAR(MAX),subTree.PathSequence)
	FROM   (
	SELECT P.ID,P.COD_TIPO,P.CODICE,P.DESCRIZIONE,P.ID_PADRE,P.COD_PSR,P.TIPO,P.LIVELLO,P.ATTIVAZIONE_BANDI,
	P.ATTIVAZIONE_FA,P.ATTIVAZIONE_OB_MISURA,P.ATTIVAZIONE_INVESTIMENTI,P.ATTIVAZIONE_FF,cte.PathLabel,
	PathSequence = char(64 + ROW_NUMBER() OVER(ORDER BY P.COD_PSR+CAST(P.LIVELLO AS VARCHAR(5))+P.CODICE))
	FROM CTE_PROGRAMMAZIONE cte INNER JOIN VZPROGRAMMAZIONE P ON CTE.ID = P.ID_PADRE 
	WHERE P.COD_PSR='POR20142020') subTree
)
,
PAGAMENTI AS 
(
	SELECT   DECRETI_X_DOM_PAG_ESPORTAZIONE.ID_PROGETTO, sum(DOMANDA_PAGAMENTO_LIQUIDAZIONE.QUIETANZA_IMPORTO) as IMPORTO_LIQUIDATO_MANDATI
	FROM      
	DECRETI_X_DOM_PAG_ESPORTAZIONE INNER JOIN 
	DOMANDA_PAGAMENTO_LIQUIDAZIONE ON DECRETI_X_DOM_PAG_ESPORTAZIONE.ID_DOMANDA_PAGAMENTO = DOMANDA_PAGAMENTO_LIQUIDAZIONE.ID_DOMANDA_PAGAMENTO
	WHERE LIQUIDATO=1
	group by DECRETI_X_DOM_PAG_ESPORTAZIONE.ID_PROGETTO
)
SELECT 
X.ASSE,
Z.AZIONE,
ISNULL(REPLACE(REPLACE(REPLACE(REPLACE(SUBSTRING(X.DESCRIZIONE,1,500),CHAR(10),' '),CHAR(13),' '),'#',' '),'|',' '), 'nessun titolo') AS BANDO,
X.CODICE_FONDO,
X.COD_LOCALE_PROGETTO,
X.CUP,
X.BENEFICIARIO,
X.RAGIONE_SOCIALE,
X.INDIRIZZO_BENEFICIARIO,
X.CAP,
X.PROVINCIA,
X.TITOLO_PROGETTO,
X.SINTESI_PRG,
X.TIPO_OPERAZIONE,
X.DATA_INIZIO,
X.DATA_FINE_PREVISTA,
X.DATA_FINE_EFFETTIVA,
H.*,
PAGAMENTI.IMPORTO_LIQUIDATO_MANDATI
FROM
(
SELECT 
B.ID_BANDO, 
BP.CODICE + ' ' + BP.DESCRIZIONE AS AZIONE
FROM CTE_PROGRAMMAZIONE BP 
LEFT JOIN vzPROGRAMMAZIONE P ON BP.ID_PADRE=P.ID AND P.ATTIVAZIONE_BANDI=0
LEFT JOIN BANDO_PROGRAMMAZIONE B ON BP.ID=B.ID_PROGRAMMAZIONE AND BP.TIPO = 'TIPOLOGIA DI INTERVENTO' WHERE B.ID_BANDO IS NOT NULL --AND B.ID_BANDO=93
) AS Z
INNER JOIN
(
SELECT
vzP.TIPO + ' ' + vzP.CODICE AS ASSE, 
P.ID_BANDO,
B.DESCRIZIONE,
'FESR20142020' AS CODICE_FONDO,
P.ID_PROGETTO AS COD_LOCALE_PROGETTO,
P.COD_AGEA AS CUP,
I.CUAA AS BENEFICIARIO,
I.RAGIONE_SOCIALE,
C.DENOMINAZIONE + ', ' + IND.VIA AS INDIRIZZO_BENEFICIARIO,
C.CAP,
C.SIGLA AS PROVINCIA,
 --ISNULL(REPLACE(REPLACE(REPLACE(REPLACE(SUBSTRING(BRT1.TESTO,1,500),CHAR(10),' '),CHAR(13),' '),'#',' '),'|',' '), I.RAGIONE_SOCIALE) AS TITOLO_PROGETTO,
 --ISNULL(REPLACE(REPLACE(REPLACE(REPLACE(SUBSTRING(BRT2.TESTO,1,1300),CHAR(10),' '),CHAR(13),' '),'#',' '),'|',' '),I.RAGIONE_SOCIALE) AS SINTESI_PRG,
dbo.RemoveNonAlphaCharactersWithBlank(BRT1.TESTO) AS TITOLO_PROGETTO,
dbo.RemoveNonAlphaCharactersWithBlank(BRT2.TESTO) AS SINTESI_PRG,

CUP_TO.Descrizione AS TIPO_OPERAZIONE,
dbo.DateToString_Igrue(PSI.DATA_INIZIO) AS DATA_INIZIO, 
dbo.DateToString_Igrue(DATEADD(MONTH,12,PSP.DATA_FINANZIABILITA)) AS DATA_FINE_PREVISTA,
CASE
WHEN PSC.DATA_FINE_EFFETTIVA IS NOT NULL
THEN dbo.DateToString_Igrue(PSC.DATA_FINE_EFFETTIVA)
END AS DATA_FINE_EFFETTIVA
FROM vPROGETTO P
INNER JOIN DATI_MONITORAGGIO_FESR DMF ON
P.ID_PROGETTO = DMF.ID_PROGETTO
INNER JOIN TIPO_CUP_CATEGORIE_TIPIOPERAZIONI CUP_TO ON
DMF.CUP_CATEGORIA_TIPOOPER = CUP_TO.COD_CUP_CATEGORIE_TIPIOPERAZIONI
INNER JOIN vBANDO B ON
P.ID_BANDO = B.ID_BANDO
INNER JOIN zPROGRAMMAZIONE PRG ON
B.ID_PROGRAMMAZIONE = PRG.ID
INNER JOIN CTE_PROGRAMMAZIONE CTE ON B.ID_PROGRAMMAZIONE = CTE.ID
INNER JOIN vzPROGRAMMAZIONE vzP ON CTE.ID_PADRE = vzP.ID AND CTE.ATTIVAZIONE_BANDI = 1
INNER JOIN zPSR_ALBERO PA ON
PRG.COD_TIPO = PA.CODICE
INNER JOIN zPSR PSR ON
PA.COD_PSR = PSR.CODICE
LEFT OUTER JOIN
(
SELECT BRT.ID_PROGETTO, BRT.TESTO FROM BRT
WHERE ORDINE = 2 AND ORDER_ROW = 1) AS BRT2
ON
P.ID_PROGETTO = BRT2.ID_PROGETTO
LEFT OUTER JOIN
(
SELECT BRT.ID_PROGETTO, BRT.TESTO FROM BRT
WHERE ORDINE = 1 AND ORDER_ROW = 1) AS BRT1
ON
P.ID_PROGETTO = BRT1.ID_PROGETTO
INNER JOIN
(SELECT PSIC.DATA DATA_INIZIO, PSIC.ID_PROGETTO FROM PSIC WHERE PSIC.COD_STATO = 'F') PSI ON
P.ID_PROGETTO = PSI.ID_PROGETTO
LEFT OUTER JOIN
(SELECT PSIC.DATA DATA_FINE_EFFETTIVA, PSIC.ID_PROGETTO FROM PSIC WHERE PSIC.COD_STATO = 'C') PSC ON
P.ID_PROGETTO = PSC.ID_PROGETTO
LEFT OUTER JOIN
(SELECT PSIC.DATA DATA_FINANZIABILITA, PSIC.ID_PROGETTO FROM PSIC WHERE PSIC.COD_STATO = 'F') PSP ON
P.ID_PROGETTO = PSP.ID_PROGETTO
INNER JOIN vIMPRESA I ON
P.ID_IMPRESA = I.ID_IMPRESA
INNER JOIN INDIRIZZARIO A ON I.ID_IMPRESA = A.ID_IMPRESA AND I.ID_SEDELEGALE_ULTIMO = A.ID_INDIRIZZARIO
INNER JOIN INDIRIZZO IND ON A.ID_INDIRIZZO = IND.ID_INDIRIZZO
INNER JOIN COMUNI C ON IND.ID_COMUNE = C.ID_COMUNE
WHERE
P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R')  --INSERIRE STATI VALIDI
AND
PSR.CODICE = 'POR20142020'
AND
P.COD_AGEA IS NOT NULL
) AS X 
ON Z.ID_BANDO = X.ID_BANDO
INNER JOIN
(
SELECT 
X.ID_PROGETTO, 
X.TOTALE_SPESA, 
Y.TOTALE_SPESA_ISTRUITA, 
Z.TOTALE_SPESA_VARIANTE, 
X.TOTALE_CONTRIBUTO, 
Y.TOTALE_CONTRIBUTO_ISTRUITO, 
Z.TOTALE_CONTRIBUTO_VARIANTE,
D.COD_TIPO,
E.IMPORTO_AMMISSIBILE,
E.IMPORTO_AMMESSO,
E.IMPORTO_SANZIONE,
E.IMPORTO_RECUPERO_ANTICIPO,
E.IMPORTO_LIQUIDATO
FROM 
(
(SELECT
PI.ID_PROGETTO,
ISNULL(SUM(CASE PI.COD_TIPO_INVESTIMENTO WHEN 2 /*PER IL MUTUO SOMMO SOLO L'AMMONTARE*/ THEN ISNULL(COSTO_INVESTIMENTO,0) ELSE ISNULL(COSTO_INVESTIMENTO,0)+ISNULL(SPESE_GENERALI,0) END),0) AS TOTALE_SPESA, 
(CASE WHEN ISNULL(B.IMPORTO_MAX,0) = 0 THEN SUM(ISNULL(PI.CONTRIBUTO_RICHIESTO,0)) ELSE ISNULL(B.IMPORTO_MAX,0) END ) AS TOTALE_CONTRIBUTO
FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON PI.ID_PROGETTO=P.ID_PROGETTO
LEFT JOIN BANDO_TIPO_INVESTIMENTI B ON P.ID_BANDO=B.ID_BANDO AND B.COD_TIPO_INVESTIMENTO=7WHERE PI.ID_VARIANTE IS NULL AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL
GROUP BY PI.ID_PROGETTO, B.IMPORTO_MAX
) AS X LEFT OUTER JOIN
(
SELECT PI.ID_PROGETTO, ISNULL(SUM(CASE PI.COD_TIPO_INVESTIMENTO WHEN 2 /*PER IL MUTUO SOMMO SOLO L'AMMONTARE*/ THEN ISNULL(COSTO_INVESTIMENTO,0) 
		ELSE ISNULL(COSTO_INVESTIMENTO,0)+ISNULL(SPESE_GENERALI,0) END),0) AS TOTALE_SPESA_ISTRUITA,
		(CASE WHEN ISNULL(B.IMPORTO_MAX,0) = 0 THEN SUM(ISNULL(PI.CONTRIBUTO_RICHIESTO,0)) ELSE ISNULL(B.IMPORTO_MAX,0) END ) AS TOTALE_CONTRIBUTO_ISTRUITO
FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON PI.ID_PROGETTO=P.ID_PROGETTO
LEFT JOIN BANDO_TIPO_INVESTIMENTI B ON P.ID_BANDO=B.ID_BANDO AND B.COD_TIPO_INVESTIMENTO=7
WHERE PI.ID_VARIANTE IS NULL AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL
GROUP BY PI.ID_PROGETTO, B.IMPORTO_MAX
) AS Y ON X.ID_PROGETTO = Y.ID_PROGETTO LEFT OUTER JOIN
(
SELECT PI.ID_PROGETTO, ISNULL(SUM(CASE PI.COD_TIPO_INVESTIMENTO WHEN 2 /*PER IL MUTUO SOMMO SOLO L'AMMONTARE*/ THEN ISNULL(COSTO_INVESTIMENTO,0) 
		ELSE ISNULL(COSTO_INVESTIMENTO,0)+ISNULL(SPESE_GENERALI,0) END),0) AS TOTALE_SPESA_VARIANTE,
		(CASE WHEN ISNULL(B.IMPORTO_MAX,0) = 0 THEN SUM(ISNULL(PI.CONTRIBUTO_RICHIESTO,0)) ELSE ISNULL(B.IMPORTO_MAX,0) END ) AS TOTALE_CONTRIBUTO_VARIANTE
FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON PI.ID_PROGETTO=P.ID_PROGETTO
LEFT JOIN BANDO_TIPO_INVESTIMENTI B ON P.ID_BANDO=B.ID_BANDO AND B.COD_TIPO_INVESTIMENTO=7
WHERE PI.ID_VARIANTE IS NOT NULL 
GROUP BY PI.ID_PROGETTO, B.IMPORTO_MAX
) AS Z ON Y.ID_PROGETTO = Z.ID_PROGETTO
) 
LEFT OUTER JOIN DOMANDA_DI_PAGAMENTO_ESPORTAZIONE E ON X.ID_PROGETTO = E.ID_PROGETTO
LEFT OUTER JOIN DOMANDA_DI_PAGAMENTO D ON E.ID_DOMANDA_PAGAMENTO = D.ID_DOMANDA_PAGAMENTO
) AS H
ON X.COD_LOCALE_PROGETTO = H.ID_PROGETTO
LEFT JOIN PAGAMENTI on X.COD_LOCALE_PROGETTO=PAGAMENTI.ID_PROGETTO
WHERE Z.AZIONE NOT LIKE '%DA ELIMINARE%' --AND vB.ID_BANDO IS NOT NULL




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[27] 4[22] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 31
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 74010
         Width = 92265
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vESTRAZIONE_GLOBALE_FESR_PROGETTI_DOMANDE_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vESTRAZIONE_GLOBALE_FESR_PROGETTI_DOMANDE_PAGAMENTO';

