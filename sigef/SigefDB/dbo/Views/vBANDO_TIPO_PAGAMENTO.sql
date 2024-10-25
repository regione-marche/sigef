CREATE VIEW [dbo].[vBANDO_TIPO_PAGAMENTO]
AS
SELECT     dbo.BANDO_TIPO_PAGAMENTO.ID_BANDO, dbo.BANDO_TIPO_PAGAMENTO.COD_TIPO, dbo.BANDO_TIPO_PAGAMENTO.QUOTA_MAX, 
                      dbo.BANDO_TIPO_PAGAMENTO.QUOTA_MIN, dbo.BANDO_TIPO_PAGAMENTO.IMPORTO_MAX, dbo.BANDO_TIPO_PAGAMENTO.IMPORTO_MIN, 
                      dbo.TIPO_DOMANDA_PAGAMENTO.DESCRIZIONE, dbo.TIPO_DOMANDA_PAGAMENTO.COD_FASE, dbo.FASI_PROCEDURALI.DESCRIZIONE AS FASE, 
                      dbo.FASI_PROCEDURALI.ORDINE, dbo.BANDO_TIPO_PAGAMENTO.NUMERO, dbo.BANDO_TIPO_PAGAMENTO.COD_TIPO_POLIZZA, 
                      dbo.TIPO_POLIZZA.DESCRIZIONE AS TIPO_POLIZZA
FROM         dbo.BANDO_TIPO_PAGAMENTO INNER JOIN
                      dbo.TIPO_DOMANDA_PAGAMENTO ON dbo.BANDO_TIPO_PAGAMENTO.COD_TIPO = dbo.TIPO_DOMANDA_PAGAMENTO.COD_TIPO INNER JOIN
                      dbo.FASI_PROCEDURALI ON dbo.TIPO_DOMANDA_PAGAMENTO.COD_FASE = dbo.FASI_PROCEDURALI.COD_FASE LEFT OUTER JOIN
                      dbo.TIPO_POLIZZA ON dbo.BANDO_TIPO_PAGAMENTO.COD_TIPO_POLIZZA = dbo.TIPO_POLIZZA.COD_TIPO_POLIZZA

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
         Begin Table = "BANDO_TIPO_PAGAMENTO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 194
               Right = 192
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_DOMANDA_PAGAMENTO"
            Begin Extent = 
               Top = 16
               Left = 297
               Bottom = 109
               Right = 448
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FASI_PROCEDURALI"
            Begin Extent = 
               Top = 15
               Left = 577
               Bottom = 108
               Right = 728
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_POLIZZA"
            Begin Extent = 
               Top = 168
               Left = 437
               Bottom = 254
               Right = 626
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
      Begin ColumnWidths = 14
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
         SortTyp', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vBANDO_TIPO_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'e = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vBANDO_TIPO_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vBANDO_TIPO_PAGAMENTO';

