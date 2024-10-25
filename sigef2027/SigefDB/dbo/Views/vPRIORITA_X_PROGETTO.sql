﻿
CREATE VIEW [dbo].[vPRIORITA_X_PROGETTO]
AS
SELECT dbo.PRIORITA_X_PROGETTO.ID_PROGETTO, dbo.PRIORITA_X_PROGETTO.ID_PRIORITA, dbo.PRIORITA_X_PROGETTO.VALORE, 
               dbo.PRIORITA_X_PROGETTO.DATA_VALUTAZIONE, dbo.PRIORITA_X_PROGETTO.OPERATORE_VALUTAZIONE, 
               dbo.PRIORITA_X_PROGETTO.MODIFICA_MANUALE, dbo.PRIORITA.DESCRIZIONE AS PRIORITA, dbo.PRIORITA.COD_LIVELLO, dbo.PRIORITA.PLURI_VALORE, 
               dbo.PRIORITA.EVAL, dbo.PRIORITA.FLAG_MANUALE, dbo.VALORI_PRIORITA.DESCRIZIONE AS VALORE_DESC, dbo.PRIORITA_X_PROGETTO.ID_VALORE, 
               dbo.PRIORITA_X_PROGETTO.PUNTEGGIO, dbo.PRIORITA.INPUT_NUMERICO, dbo.PRIORITA.MISURA, dbo.PRIORITA.DATETIME, 
               dbo.PRIORITA.TESTO_SEMPLICE, dbo.PRIORITA.TESTO_AREA, dbo.PRIORITA.PLURI_VALORE_SQL, dbo.PRIORITA.QUERY_PLURIVALORE, 
               dbo.PRIORITA_X_PROGETTO.VAL_DATA, dbo.PRIORITA_X_PROGETTO.VAL_TESTO
FROM  dbo.PRIORITA_X_PROGETTO INNER JOIN
               dbo.PRIORITA ON dbo.PRIORITA_X_PROGETTO.ID_PRIORITA = dbo.PRIORITA.ID_PRIORITA LEFT OUTER JOIN
               dbo.VALORI_PRIORITA ON dbo.PRIORITA_X_PROGETTO.ID_VALORE = dbo.VALORI_PRIORITA.ID_VALORE


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
         Begin Table = "PRIORITA_X_PROGETTO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 147
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PRIORITA"
            Begin Extent = 
               Top = 6
               Left = 292
               Bottom = 211
               Right = 450
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VALORI_PRIORITA"
            Begin Extent = 
               Top = 150
               Left = 38
               Bottom = 258
               Right = 189
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
      Begin ColumnWidths = 12
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPRIORITA_X_PROGETTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPRIORITA_X_PROGETTO';

