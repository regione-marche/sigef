CREATE VIEW [dbo].[vCOLLABORATORI_X_BANDO]
AS
SELECT     dbo.COLLABORATORI_X_BANDO.ID_COLLABORATORE, dbo.COLLABORATORI_X_BANDO.ID_BANDO, dbo.COLLABORATORI_X_BANDO.ID_PROGETTO, 
                      dbo.COLLABORATORI_X_BANDO.PROVINCIA, dbo.COLLABORATORI_X_BANDO.DATA_INSERIMENTO, dbo.COLLABORATORI_X_BANDO.DATA_FINE_VALIDITA, 
                      dbo.vUTENTI.NOMINATIVO, dbo.vUTENTI.COD_ENTE, dbo.vUTENTI.PROVINCIA AS PROVINCIA_UTENTE, dbo.COLLABORATORI_X_BANDO.ID_UTENTE, 
                      dbo.COLLABORATORI_X_BANDO.OPERATORE_INSERIMENTO, dbo.COLLABORATORI_X_BANDO.OPERATORE_FINE_VALIDITA, 
                      dbo.COLLABORATORI_X_BANDO.ATTIVO
FROM         dbo.COLLABORATORI_X_BANDO INNER JOIN
                      dbo.vUTENTI ON dbo.COLLABORATORI_X_BANDO.ID_UTENTE = dbo.vUTENTI.ID_UTENTE

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
         Begin Table = "COLLABORATORI_X_BANDO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UTENTI"
            Begin Extent = 
               Top = 55
               Left = 338
               Bottom = 249
               Right = 634
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "vPROGETTI_ANAG_IMPRESA"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 322
               Right = 285
            End
            DisplayFlags = 280
            TopColumn = 32
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vCOLLABORATORI_X_BANDO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vCOLLABORATORI_X_BANDO';

