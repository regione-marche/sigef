CREATE VIEW dbo.VIGRUE_INVIO
AS
SELECT     dbo.IGRUE_INVIO.ID_INVIO, dbo.IGRUE_INVIO.ID_TICKET, dbo.IGRUE_INVIO.DATA_INVIO, dbo.IGRUE_INVIO.DATA_DA, dbo.IGRUE_INVIO.DATA_A, dbo.IGRUE_INVIO.FILE_INVIO, 
                      dbo.IGRUE_INVIO.ID_OPERATORE, dbo.IGRUE_INVIO.CODICE_ESITO, dbo.IGRUE_INVIO.DESCRIZIONE_ESITO, dbo.IGRUE_INVIO.DETTAGLIO_ESITO, dbo.IGRUE_INVIO.TIMESTAMP_ESITO, 
                      dbo.IGRUE_INVIO.TIPO_FILE, dbo.IGRUE_LOG_ERRORI.ID_IGRUE_LOG_ERRORI, dbo.IGRUE_LOG_ERRORI.DATA_RICHIESTA, dbo.IGRUE_LOG_ERRORI.FILE_ERRORI, 
                      dbo.IGRUE_LOG_ERRORI.ISTANZA_ERRORI, dbo.IGRUE_LOG_ERRORI.ID_OPERATORE AS ID_OPERATORE_LOG, dbo.IGRUE_LOG_ERRORI.CODICE_ESITO AS CODICE_ESITO_LOG, 
                      dbo.IGRUE_LOG_ERRORI.DESCRIZIONE_ESITO AS DESCRIZIONE_ESITO_LOG, dbo.IGRUE_LOG_ERRORI.DETTAGLIO_ESITO AS DETTAGLIO_ESITO_LOG, 
                      dbo.IGRUE_LOG_ERRORI.TIMESTAMP_ESITO AS TIMESTAMP_ESITO_LOG, dbo.IGRUE_LOG_ERRORI.TIPO_FILE AS TIPO_FILE_LOG
FROM         dbo.IGRUE_INVIO LEFT OUTER JOIN
                      dbo.IGRUE_LOG_ERRORI ON dbo.IGRUE_INVIO.ID_INVIO = dbo.IGRUE_LOG_ERRORI.ID_INVIO

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
         Begin Table = "IGRUE_INVIO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 249
               Right = 231
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "IGRUE_LOG_ERRORI"
            Begin Extent = 
               Top = 6
               Left = 269
               Bottom = 278
               Right = 477
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
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VIGRUE_INVIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VIGRUE_INVIO';

