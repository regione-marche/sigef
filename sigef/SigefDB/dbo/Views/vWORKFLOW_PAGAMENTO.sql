﻿CREATE VIEW [dbo].[vWORKFLOW_PAGAMENTO]
AS
SELECT     dbo.WORKFLOW_PAGAMENTO.COD_TIPO, dbo.WORKFLOW_PAGAMENTO.COD_WORKFLOW, dbo.WORKFLOW_PAGAMENTO.ORDINE, 
                      dbo.WORKFLOW_PAGAMENTO.OBBLIGATORIO, dbo.WORKFLOW.DESCRIZIONE, dbo.WORKFLOW.URL, 
                      dbo.TIPO_DOMANDA_PAGAMENTO.DESCRIZIONE AS TIPO_PAGAMENTO, dbo.TIPO_DOMANDA_PAGAMENTO.COD_FASE, 
                      dbo.FASI_PROCEDURALI.DESCRIZIONE AS FASE, dbo.FASI_PROCEDURALI.ORDINE AS ORDINE_FASE
FROM         dbo.WORKFLOW_PAGAMENTO INNER JOIN
                      dbo.WORKFLOW ON dbo.WORKFLOW_PAGAMENTO.COD_WORKFLOW = dbo.WORKFLOW.COD_WORKFLOW INNER JOIN
                      dbo.TIPO_DOMANDA_PAGAMENTO ON dbo.WORKFLOW_PAGAMENTO.COD_TIPO = dbo.TIPO_DOMANDA_PAGAMENTO.COD_TIPO INNER JOIN
                      dbo.FASI_PROCEDURALI ON dbo.TIPO_DOMANDA_PAGAMENTO.COD_FASE = dbo.FASI_PROCEDURALI.COD_FASE

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
         Begin Table = "WORKFLOW_PAGAMENTO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 195
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WORKFLOW"
            Begin Extent = 
               Top = 150
               Left = 358
               Bottom = 243
               Right = 515
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_DOMANDA_PAGAMENTO"
            Begin Extent = 
               Top = 23
               Left = 382
               Bottom = 116
               Right = 533
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FASI_PROCEDURALI"
            Begin Extent = 
               Top = 24
               Left = 668
               Bottom = 132
               Right = 819
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
      Begin ColumnWidths = 11
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
         Filt', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vWORKFLOW_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'er = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vWORKFLOW_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vWORKFLOW_PAGAMENTO';

