CREATE VIEW [dbo].[vCAA_OPERATORI]
AS
SELECT     dbo.CAA_OPERATORI.ID, dbo.CAA_OPERATORI.CODICE_SPORTELLO, dbo.CAA_OPERATORI.ID_UTENTE, dbo.CAA_OPERATORI.ID_STORICO_ULTIMO, 
                      dbo.CAA_STORICO_OPERATORI.MANDATO_PSR, dbo.CAA_STORICO_OPERATORI.MANDATO_UMA, dbo.CAA_STORICO_OPERATORI.RESPONSABILE, 
                      dbo.CAA_STORICO_OPERATORI.COD_STATO, dbo.CAA_STORICO_OPERATORI.DATA, dbo.CAA_STORICO_OPERATORI.OPERATORE, 
                      dbo.vUTENTI.ID_PERSONA_FISICA, dbo.vUTENTI.CF_UTENTE, dbo.vUTENTI.NOMINATIVO, 
                      CASE WHEN dbo.CAA_STORICO_OPERATORI.COD_STATO = 'R' THEN 'REVOCATO' WHEN dbo.CAA_STORICO_OPERATORI.COD_STATO = 'P' THEN 'IN ATTESA DI AUTORIZZAZIONE'
                       WHEN dbo.CAA_STORICO_OPERATORI.COD_STATO = 'A' THEN 'AUTORIZZATO' END AS STATO, dbo.vUTENTI.COD_ENTE, dbo.vUTENTI.COD_TIPO_ENTE
FROM         dbo.CAA_OPERATORI INNER JOIN
                      dbo.CAA_STORICO_OPERATORI ON dbo.CAA_OPERATORI.ID_STORICO_ULTIMO = dbo.CAA_STORICO_OPERATORI.ID INNER JOIN
                      dbo.vUTENTI ON dbo.CAA_OPERATORI.ID_UTENTE = dbo.vUTENTI.ID_UTENTE

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
         Begin Table = "CAA_STORICO_OPERATORI"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 255
               Right = 432
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vUTENTI"
            Begin Extent = 
               Top = 6
               Left = 470
               Bottom = 261
               Right = 657
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "CAA_OPERATORI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 225
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vCAA_OPERATORI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vCAA_OPERATORI';

