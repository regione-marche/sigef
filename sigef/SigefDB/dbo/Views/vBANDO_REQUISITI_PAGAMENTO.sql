﻿CREATE VIEW [dbo].[vBANDO_REQUISITI_PAGAMENTO]
AS
SELECT     dbo.BANDO_REQUISITI_PAGAMENTO.ID_BANDO, dbo.BANDO_REQUISITI_PAGAMENTO.COD_TIPO, 
                      dbo.BANDO_REQUISITI_PAGAMENTO.ID_REQUISITO, dbo.BANDO_REQUISITI_PAGAMENTO.OBBLIGATORIO, 
                      dbo.BANDO_REQUISITI_PAGAMENTO.REQUISITO_DI_CONTROLLO, dbo.BANDO_REQUISITI_PAGAMENTO.ORDINE, 
                      dbo.TIPO_DOMANDA_PAGAMENTO.DESCRIZIONE, dbo.TIPO_DOMANDA_PAGAMENTO.COD_FASE, dbo.FASI_PROCEDURALI.DESCRIZIONE AS FASE, 
                      dbo.FASI_PROCEDURALI.ORDINE AS ORDINE_FASE, dbo.REQUISITI_PAGAMENTO.DESCRIZIONE AS REQUISITO, 
                      dbo.REQUISITI_PAGAMENTO.PLURIVALORE, dbo.REQUISITI_PAGAMENTO.NUMERICO, dbo.REQUISITI_PAGAMENTO.DATETIME, 
                      dbo.REQUISITI_PAGAMENTO.TESTO_SEMPLICE, dbo.REQUISITI_PAGAMENTO.TESTO_AREA, dbo.REQUISITI_PAGAMENTO.URL, 
                      dbo.REQUISITI_PAGAMENTO.QUERY_EVAL, dbo.REQUISITI_PAGAMENTO.QUERY_INSERT, dbo.REQUISITI_PAGAMENTO.MISURA, 
                      dbo.BANDO_REQUISITI_PAGAMENTO.REQUISITO_DI_INSERIMENTO
FROM         dbo.BANDO_REQUISITI_PAGAMENTO INNER JOIN
                      dbo.TIPO_DOMANDA_PAGAMENTO ON dbo.BANDO_REQUISITI_PAGAMENTO.COD_TIPO = dbo.TIPO_DOMANDA_PAGAMENTO.COD_TIPO INNER JOIN
                      dbo.REQUISITI_PAGAMENTO ON dbo.BANDO_REQUISITI_PAGAMENTO.ID_REQUISITO = dbo.REQUISITI_PAGAMENTO.ID_REQUISITO INNER JOIN
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
         Begin Table = "BANDO_REQUISITI_PAGAMENTO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 161
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_DOMANDA_PAGAMENTO"
            Begin Extent = 
               Top = 116
               Left = 345
               Bottom = 220
               Right = 496
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "REQUISITI_PAGAMENTO"
            Begin Extent = 
               Top = 15
               Left = 858
               Bottom = 231
               Right = 1024
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FASI_PROCEDURALI"
            Begin Extent = 
               Top = 117
               Left = 586
               Bottom = 210
               Right = 737
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
         GroupBy =', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vBANDO_REQUISITI_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vBANDO_REQUISITI_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vBANDO_REQUISITI_PAGAMENTO';
