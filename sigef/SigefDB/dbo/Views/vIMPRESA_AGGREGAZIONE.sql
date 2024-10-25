CREATE VIEW dbo.vIMPRESA_AGGREGAZIONE
AS
SELECT     TOP (100) PERCENT dbo.IMPRESA_AGGREGAZIONE.ID, dbo.IMPRESA_AGGREGAZIONE.ID_AGGREGAZIONE, dbo.IMPRESA_AGGREGAZIONE.COD_RUOLO, 
                      dbo.IMPRESA_AGGREGAZIONE.ID_IMPRESA, dbo.IMPRESA_AGGREGAZIONE.PERCENTUALE, dbo.IMPRESA_AGGREGAZIONE.DATA_INIZIO, dbo.IMPRESA_AGGREGAZIONE.OPERATORE_INIZIO, 
                      dbo.IMPRESA_AGGREGAZIONE.ATTIVO, dbo.IMPRESA_AGGREGAZIONE.DATA_FINE, dbo.IMPRESA_AGGREGAZIONE.OPERATORE_FINE, dbo.IMPRESA.CUAA, 
                      dbo.IMPRESA_STORICO.RAGIONE_SOCIALE, dbo.AGGREGAZIONE.DENOMINAZIONE, dbo.TIPO_AGGREGAZIONE_RUOLO.DESCRIZIONE AS RUOLO_AGGREGAZIONE, 
                      dbo.IMPRESA_STORICO.COD_ATECO2007
FROM         dbo.IMPRESA_AGGREGAZIONE INNER JOIN
                      dbo.IMPRESA ON dbo.IMPRESA_AGGREGAZIONE.ID_IMPRESA = dbo.IMPRESA.ID_IMPRESA INNER JOIN
                      dbo.AGGREGAZIONE ON dbo.IMPRESA_AGGREGAZIONE.ID_AGGREGAZIONE = dbo.AGGREGAZIONE.ID INNER JOIN
                      dbo.IMPRESA_STORICO ON dbo.IMPRESA.ID_STORICO_ULTIMO = dbo.IMPRESA_STORICO.ID_STORICO_IMPRESA INNER JOIN
                      dbo.TIPO_AGGREGAZIONE_RUOLO ON dbo.IMPRESA_AGGREGAZIONE.COD_RUOLO = dbo.TIPO_AGGREGAZIONE_RUOLO.CODICE

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
         Top = -288
         Left = 0
      End
      Begin Tables = 
         Begin Table = "IMPRESA_AGGREGAZIONE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "IMPRESA"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 246
               Right = 292
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "AGGREGAZIONE"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 366
               Right = 264
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "IMPRESA_STORICO"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 486
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 13
         End
         Begin Table = "TIPO_AGGREGAZIONE_RUOLO"
            Begin Extent = 
               Top = 6
               Left = 265
               Bottom = 96
               Right = 425
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
         Or = ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vIMPRESA_AGGREGAZIONE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vIMPRESA_AGGREGAZIONE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vIMPRESA_AGGREGAZIONE';

