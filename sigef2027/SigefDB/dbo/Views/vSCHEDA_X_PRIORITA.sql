﻿
CREATE VIEW [dbo].[vSCHEDA_X_PRIORITA]
AS
SELECT dbo.SCHEDA_VALUTAZIONE.ID_SCHEDA_VALUTAZIONE, dbo.SCHEDA_VALUTAZIONE.DESCRIZIONE, dbo.SCHEDA_VALUTAZIONE.FLAG_TEMPLATE, 
                  dbo.SCHEDA_X_PRIORITA.ID_PRIORITA, dbo.PRIORITA.DESCRIZIONE AS PRIORITA, dbo.PRIORITA.COD_LIVELLO, dbo.SCHEDA_X_PRIORITA.ORDINE, 
                  dbo.SCHEDA_X_PRIORITA.PESO, dbo.SCHEDA_VALUTAZIONE.VALORE_MAX, dbo.SCHEDA_VALUTAZIONE.VALORE_MIN, 
                  dbo.SCHEDA_X_PRIORITA.AIUTO_ADDIZIONALE, dbo.SCHEDA_X_PRIORITA.SELEZIONABILE, dbo.PRIORITA.PLURI_VALORE, dbo.PRIORITA.EVAL, 
                  dbo.PRIORITA.FLAG_MANUALE, dbo.SCHEDA_X_PRIORITA.IS_MAX, dbo.PRIORITA.INPUT_NUMERICO, dbo.PRIORITA.MISURA, dbo.PRIORITA.DATETIME, 
                  dbo.PRIORITA.TESTO_SEMPLICE, dbo.PRIORITA.TESTO_AREA, dbo.PRIORITA.PLURI_VALORE_SQL, dbo.PRIORITA.QUERY_PLURIVALORE
FROM     dbo.SCHEDA_VALUTAZIONE INNER JOIN
                  dbo.SCHEDA_X_PRIORITA ON dbo.SCHEDA_VALUTAZIONE.ID_SCHEDA_VALUTAZIONE = dbo.SCHEDA_X_PRIORITA.ID_SCHEDA_VALUTAZIONE INNER JOIN
                  dbo.PRIORITA ON dbo.SCHEDA_X_PRIORITA.ID_PRIORITA = dbo.PRIORITA.ID_PRIORITA


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
         Begin Table = "SCHEDA_VALUTAZIONE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 150
               Right = 250
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SCHEDA_X_PRIORITA"
            Begin Extent = 
               Top = 6
               Left = 288
               Bottom = 159
               Right = 500
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PRIORITA"
            Begin Extent = 
               Top = 12
               Left = 573
               Bottom = 189
               Right = 724
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
      Begin ColumnWidths = 20
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vSCHEDA_X_PRIORITA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vSCHEDA_X_PRIORITA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vSCHEDA_X_PRIORITA';

