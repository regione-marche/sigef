CREATE VIEW dbo.vPIANO_INVESTIMENTI_X_AGGREGAZIONE
AS
SELECT        VPI.ID_INVESTIMENTO, VPI.ID_PROGETTO, VPI.ID_PROGRAMMAZIONE, VPI.DESCRIZIONE, VPI.DATA_VARIAZIONE, VPI.OPERATORE_VARIAZIONE, VPI.COD_STP, VPI.ID_UNITA_MISURA, VPI.QUANTITA, 
                         VPI.COSTO_INVESTIMENTO, VPI.SPESE_GENERALI, VPI.CONTRIBUTO_RICHIESTO, VPI.QUOTA_CONTRIBUTO_RICHIESTO, VPI.ID_SETTORE_PRODUTTIVO, VPI.ID_PRIORITA_SETTORIALE, VPI.ID_OBIETTIVO_MISURA, 
                         VPI.AMMESSO, VPI.ISTRUTTORE, VPI.ID_INVESTIMENTO_ORIGINALE, VPI.DATA_VALUTAZIONE, VPI.ID_CODIFICA_INVESTIMENTO, VPI.ID_DETTAGLIO_INVESTIMENTO, VPI.ID_SPECIFICA_INVESTIMENTO, VPI.COD_TP, 
                         VPI.CODIFICA_INVESTIMENTO, VPI.AIUTO_MINIMO, VPI.CODICE, VPI.COD_SPECIFICA, VPI.SPECIFICA_INVESTIMENTI, VPI.DETTAGLIO_INVESTIMENTI, VPI.MOBILE, VPI.QUOTA_SPESE_GENERALI, VPI.SETTORE_PRODUTTIVO, 
                         VPI.COD_TIPO_INVESTIMENTO, VPI.RICHIEDI_PARTICELLA, VPI.VALUTAZIONE_INVESTIMENTO, VPI.ID_VARIANTE, VPI.COD_VARIAZIONE, VPI.TASSO_ABBUONO, VPI.MISURA, VPI.ID_MISURA, VPI.NON_COFINANZIATO, 
                         PRI.VAL_TESTO
FROM            dbo.vPIANO_INVESTIMENTI AS VPI INNER JOIN
                         dbo.PRIORITA_X_INVESTIMENTI AS PRI ON VPI.ID_INVESTIMENTO = PRI.ID_INVESTIMENTO
WHERE        (PRI.ID_PRIORITA = 334)

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
         Begin Table = "VPI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 310
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PRI"
            Begin Extent = 
               Top = 6
               Left = 348
               Bottom = 136
               Right = 539
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 3165
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPIANO_INVESTIMENTI_X_AGGREGAZIONE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPIANO_INVESTIMENTI_X_AGGREGAZIONE';

