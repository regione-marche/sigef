CREATE VIEW dbo.vPIANO_INVESTIMENTI
AS
SELECT     dbo.PIANO_INVESTIMENTI.ID_INVESTIMENTO, dbo.PIANO_INVESTIMENTI.ID_PROGETTO, dbo.PIANO_INVESTIMENTI.ID_PROGRAMMAZIONE, dbo.PIANO_INVESTIMENTI.DESCRIZIONE, 
                      dbo.PIANO_INVESTIMENTI.DATA_VARIAZIONE, dbo.PIANO_INVESTIMENTI.OPERATORE_VARIAZIONE, dbo.PIANO_INVESTIMENTI.COD_STP, dbo.PIANO_INVESTIMENTI.ID_UNITA_MISURA, 
                      dbo.PIANO_INVESTIMENTI.QUANTITA, dbo.PIANO_INVESTIMENTI.COSTO_INVESTIMENTO, dbo.PIANO_INVESTIMENTI.SPESE_GENERALI, dbo.PIANO_INVESTIMENTI.CONTRIBUTO_RICHIESTO, 
                      dbo.PIANO_INVESTIMENTI.QUOTA_CONTRIBUTO_RICHIESTO, dbo.PIANO_INVESTIMENTI.ID_SETTORE_PRODUTTIVO, dbo.PIANO_INVESTIMENTI.ID_PRIORITA_SETTORIALE, 
                      dbo.PIANO_INVESTIMENTI.ID_OBIETTIVO_MISURA, dbo.PIANO_INVESTIMENTI.AMMESSO, dbo.PIANO_INVESTIMENTI.ISTRUTTORE, dbo.PIANO_INVESTIMENTI.ID_INVESTIMENTO_ORIGINALE, 
                      dbo.PIANO_INVESTIMENTI.DATA_VALUTAZIONE, dbo.PIANO_INVESTIMENTI.ID_CODIFICA_INVESTIMENTO, dbo.PIANO_INVESTIMENTI.ID_DETTAGLIO_INVESTIMENTO, 
                      dbo.PIANO_INVESTIMENTI.ID_SPECIFICA_INVESTIMENTO, dbo.CODIFICA_INVESTIMENTO.COD_TP, dbo.CODIFICA_INVESTIMENTO.DESCRIZIONE AS CODIFICA_INVESTIMENTO, 
                      dbo.CODIFICA_INVESTIMENTO.AIUTO_MINIMO, dbo.CODIFICA_INVESTIMENTO.CODICE, dbo.SPECIFICA_INVESTIMENTI.COD_SPECIFICA, 
                      dbo.SPECIFICA_INVESTIMENTI.DESCRIZIONE AS SPECIFICA_INVESTIMENTI, dbo.DETTAGLIO_INVESTIMENTI.DESCRIZIONE AS DETTAGLIO_INVESTIMENTI, 
                      dbo.DETTAGLIO_INVESTIMENTI.MOBILE, dbo.DETTAGLIO_INVESTIMENTI.QUOTA_SPESE_GENERALI, dbo.SETTORI_PRODUTTIVI.DESCRIZIONE AS SETTORE_PRODUTTIVO, 
                      dbo.PIANO_INVESTIMENTI.COD_TIPO_INVESTIMENTO, dbo.DETTAGLIO_INVESTIMENTI.RICHIEDI_PARTICELLA, dbo.PIANO_INVESTIMENTI.VALUTAZIONE_INVESTIMENTO, 
                      dbo.PIANO_INVESTIMENTI.ID_VARIANTE, dbo.PIANO_INVESTIMENTI.COD_VARIAZIONE, dbo.PIANO_INVESTIMENTI.TASSO_ABBUONO, 
                      dbo.zPSR_ALBERO.DESCRIZIONE + ' ' + dbo.zPROGRAMMAZIONE.CODICE AS MISURA, dbo.zPROGRAMMAZIONE.ID AS ID_MISURA, dbo.PIANO_INVESTIMENTI.NON_COFINANZIATO, 
                      dbo.PIANO_INVESTIMENTI.CONTRIBUTO_ALTRE_FONTI, dbo.PIANO_INVESTIMENTI.QUOTA_CONTRIBUTO_ALTRE_FONTI, dbo.CODIFICA_INVESTIMENTO.IS_MAX
FROM         dbo.PIANO_INVESTIMENTI LEFT OUTER JOIN
                      dbo.SPECIFICA_INVESTIMENTI ON dbo.PIANO_INVESTIMENTI.ID_SPECIFICA_INVESTIMENTO = dbo.SPECIFICA_INVESTIMENTI.ID_SPECIFICA_INVESTIMENTO INNER JOIN
                      dbo.PROGETTO ON dbo.PIANO_INVESTIMENTI.ID_PROGETTO = dbo.PROGETTO.ID_PROGETTO INNER JOIN
                      dbo.BANDO ON dbo.PROGETTO.ID_BANDO = dbo.BANDO.ID_BANDO INNER JOIN
                      dbo.zPROGRAMMAZIONE ON dbo.BANDO.ID_PROGRAMMAZIONE = dbo.zPROGRAMMAZIONE.ID INNER JOIN
                      dbo.zPSR_ALBERO ON dbo.zPROGRAMMAZIONE.COD_TIPO = dbo.zPSR_ALBERO.CODICE LEFT OUTER JOIN
                      dbo.CODIFICA_INVESTIMENTO ON dbo.PIANO_INVESTIMENTI.ID_CODIFICA_INVESTIMENTO = dbo.CODIFICA_INVESTIMENTO.ID_CODIFICA_INVESTIMENTO LEFT OUTER JOIN
                      dbo.DETTAGLIO_INVESTIMENTI ON dbo.PIANO_INVESTIMENTI.ID_DETTAGLIO_INVESTIMENTO = dbo.DETTAGLIO_INVESTIMENTI.ID_DETTAGLIO_INVESTIMENTO LEFT OUTER JOIN
                      dbo.SETTORI_PRODUTTIVI ON dbo.PIANO_INVESTIMENTI.ID_SETTORE_PRODUTTIVO = dbo.SETTORI_PRODUTTIVI.ID_SETTORE_PRODUTTIVO

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[51] 4[5] 2[31] 3) )"
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
         Begin Table = "PIANO_INVESTIMENTI"
            Begin Extent = 
               Top = 0
               Left = 34
               Bottom = 431
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "SPECIFICA_INVESTIMENTI"
            Begin Extent = 
               Top = 91
               Left = 628
               Bottom = 225
               Right = 861
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PROGETTO"
            Begin Extent = 
               Top = 432
               Left = 38
               Bottom = 552
               Right = 288
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BANDO"
            Begin Extent = 
               Top = 552
               Left = 38
               Bottom = 672
               Right = 262
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "zPROGRAMMAZIONE"
            Begin Extent = 
               Top = 552
               Left = 300
               Bottom = 672
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "zPSR_ALBERO"
            Begin Extent = 
               Top = 672
               Left = 38
               Bottom = 792
               Right = 270
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CODIFICA_INVESTIMENTO"
            Begin Extent = 
               Top = 15
               Left = 334
               Bottom = 159
               Right = 561', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPIANO_INVESTIMENTI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "DETTAGLIO_INVESTIMENTI"
            Begin Extent = 
               Top = 269
               Left = 620
               Bottom = 423
               Right = 853
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SETTORI_PRODUTTIVI"
            Begin Extent = 
               Top = 385
               Left = 373
               Bottom = 478
               Right = 586
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
      Begin ColumnWidths = 37
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPIANO_INVESTIMENTI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPIANO_INVESTIMENTI';

