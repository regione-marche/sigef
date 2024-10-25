









CREATE VIEW [dbo].[vGANTT_CERTIFICABILE_PER_ANNO]
AS
-- Utilizzata dal report GANTT - Certificabile per anno raggruppato per intervento
-- Usa le viste:
--  vGANTT_ESTRAZIONE_COMPLETA: per ottenere elenco assi, interventi, bandi etc...
--  vGANTT_CERTIFICATO_PER_INTERVENTI: per ottenere il valore effettivo del Certificato per ciascun intervento
SELECT        TOP (100) PERCENT 
ASSE, DESCRIZIONE_ASSE, AZIONE, DESCRIZIONE_AZIONE, INTERVENTO, DESCRIZIONE_INTERVENTO, IMPORTO_DOTAZIONE, 
vGANTT_ESTRAZIONE_COMPLETA.IMPORTO_TARGET, 
vGANTT_CERTIFICATO_PER_INTERVENTI.importoCertificato as importoCertificatoSIGEF_20171231,
vGANTT_CERTIFICATO_PER_INTERVENTI.ImportoIntervento as importoInterventoSIGEF,
vGANTT_CERTIFICATO_PER_INTERVENTI.ImportoQuietanzaSigef as QuietanzaSIGEF,
TIPO, ID_UO, UO, OGGETTO, 
CAST(MAX(IMPORTO_FESR) AS float)AS IMPORTO_FESR, 
CAST(MAX(IMPORTO_PREVISTO) AS float) AS IMPORTO_TOT, 
CAST(MAX(IMPORTO_FINANZIATO) AS float) AS IMPORTO_GIA_FINANZIATO_201803, 
CAST(MAX(IMPORTO_CERTIFICATO) AS float)  AS IMPORTO_GIA_CERTIFICATO_201803, 
OPERAZIONE, 
YEAR(DATA_FINE_PREVISTA) AS annoCertificazionePrevisto, 
CAST(SUM(VALORE_PREVISTO) AS float) AS impotoCertificatoPrevisto,
CAST(SUM(VALORE_EFFETTIVO) AS float) AS impotoCertificatoEffettivo
FROM            dbo.vGANTT_ESTRAZIONE_COMPLETA
left join vGANTT_CERTIFICATO_PER_INTERVENTI on vGANTT_CERTIFICATO_PER_INTERVENTI.cod_intervento =vGANTT_ESTRAZIONE_COMPLETA.INTERVENTO
WHERE        (PASSO = 'Certificazione Spesa' or PASSO is null)
GROUP BY ASSE, DESCRIZIONE_ASSE, AZIONE, DESCRIZIONE_AZIONE, INTERVENTO, DESCRIZIONE_INTERVENTO, IMPORTO_DOTAZIONE, IMPORTO_TARGET, vGANTT_CERTIFICATO_PER_INTERVENTI.importoCertificato,vGANTT_CERTIFICATO_PER_INTERVENTI.ImportoIntervento,vGANTT_CERTIFICATO_PER_INTERVENTI.ImportoQuietanzaSigef , TIPO, ID_UO, UO, OGGETTO, OPERAZIONE, YEAR(DATA_FINE_PREVISTA)
ORDER BY ASSE, DESCRIZIONE_ASSE, AZIONE, DESCRIZIONE_AZIONE, INTERVENTO, DESCRIZIONE_INTERVENTO, OGGETTO, annoCertificazionePrevisto











GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "vGANTT_ESTRAZIONE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 290
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vGANTT_CERTIFICABILE_PER_ANNO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vGANTT_CERTIFICABILE_PER_ANNO';

