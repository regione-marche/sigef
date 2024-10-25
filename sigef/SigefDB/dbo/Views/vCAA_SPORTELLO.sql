CREATE VIEW [dbo].[vCAA_SPORTELLO]
AS
SELECT     dbo.CAA_SPORTELLO.CODICE, dbo.CAA_SPORTELLO.CODICE_CAA, dbo.CAA_SPORTELLO.CODICE_PROVINCIA, dbo.CAA_SPORTELLO.CODICE_UFFICIO, 
                      dbo.CAA_SPORTELLO.COD_ENTE, dbo.CAA_SPORTELLO.ID_STORICO_ULTIMO, 
                      CASE WHEN dbo.CAA_STORICO_SPORTELLO.COD_STATO = 'R' THEN 'REVOCATO' WHEN dbo.CAA_STORICO_SPORTELLO.COD_STATO = 'P' THEN 'IN ATTESA DI AUTORIZZAZIONE'
                       WHEN dbo.CAA_STORICO_SPORTELLO.COD_STATO = 'A' THEN 'AUTORIZZATO' END AS STATO, dbo.CAA_STORICO_SPORTELLO.DENOMINAZIONE, 
                      dbo.CAA_STORICO_SPORTELLO.UFFICIO_PROVINCIALE, dbo.CAA_STORICO_SPORTELLO.UFFICIO_REGIONALE, dbo.CAA_STORICO_SPORTELLO.INDIRIZZO, 
                      dbo.CAA_STORICO_SPORTELLO.ID_COMUNE, dbo.CAA_STORICO_SPORTELLO.TELEFONO, dbo.CAA_STORICO_SPORTELLO.FAX, 
                      dbo.CAA_STORICO_SPORTELLO.EMAIL, dbo.CAA_STORICO_SPORTELLO.COD_STATO, dbo.CAA_STORICO_SPORTELLO.DATA, 
                      dbo.CAA_STORICO_SPORTELLO.OPERATORE, dbo.COMUNI.DENOMINAZIONE AS COMUNE, dbo.COMUNI.SIGLA AS PROVINCIA, dbo.COMUNI.CAP
FROM         dbo.CAA_SPORTELLO INNER JOIN
                      dbo.CAA_STORICO_SPORTELLO ON dbo.CAA_SPORTELLO.ID_STORICO_ULTIMO = dbo.CAA_STORICO_SPORTELLO.ID LEFT OUTER JOIN
                      dbo.COMUNI ON dbo.CAA_STORICO_SPORTELLO.ID_COMUNE = dbo.COMUNI.ID_COMUNE

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[36] 4[20] 3[22] 2) )"
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
         Begin Table = "CAA_SPORTELLO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 186
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CAA_STORICO_SPORTELLO"
            Begin Extent = 
               Top = 6
               Left = 263
               Bottom = 195
               Right = 458
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "COMUNI"
            Begin Extent = 
               Top = 6
               Left = 496
               Bottom = 195
               Right = 661
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
      Begin ColumnWidths = 28
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
         Width = 2100
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
        ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vCAA_SPORTELLO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' NewValue = 1170
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vCAA_SPORTELLO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vCAA_SPORTELLO';

