CREATE VIEW dbo.vSPESE_SOSTENUTE
AS
SELECT     dbo.SPESE_SOSTENUTE.ID_SPESA, dbo.SPESE_SOSTENUTE.ID_GIUSTIFICATIVO, dbo.SPESE_SOSTENUTE.COD_TIPO, dbo.SPESE_SOSTENUTE.ESTREMI, dbo.SPESE_SOSTENUTE.DATA, 
                      dbo.SPESE_SOSTENUTE.IMPORTO, dbo.SPESE_SOSTENUTE.NETTO, TIPO_GIUSTIFICATIVO_1.DESCRIZIONE AS TIPO_PAGAMENTO, dbo.GIUSTIFICATIVI.ID_PROGETTO, 
                      dbo.GIUSTIFICATIVI.NUMERO, dbo.GIUSTIFICATIVI.COD_TIPO AS COD_TIPO_GIUSTIFICATIVO, dbo.GIUSTIFICATIVI.DATA AS DATA_GIUSTIFICATIVO, dbo.GIUSTIFICATIVI.NUMERO_DOCTRASPORTO, 
                      dbo.GIUSTIFICATIVI.DATA_DOCTRASPORTO, dbo.GIUSTIFICATIVI.IMPONIBILE, dbo.GIUSTIFICATIVI.IVA, dbo.GIUSTIFICATIVI.ALTRI_ONERI, dbo.GIUSTIFICATIVI.DESCRIZIONE, 
                      dbo.GIUSTIFICATIVI.CF_FORNITORE, dbo.GIUSTIFICATIVI.DESCRIZIONE_FORNITORE, dbo.TIPO_GIUSTIFICATIVO.DESCRIZIONE AS TIPO_GIUSTIFICATIVO, 
                      dbo.SPESE_SOSTENUTE.ID_DOMANDA_PAGAMENTO, dbo.GIUSTIFICATIVI.IVA_NON_RECUPERABILE, dbo.DOMANDA_DI_PAGAMENTO.ANNULLATA AS DOMANDA_PAGAMENTO_ANNULLATA, 
                      dbo.DOMANDA_DI_PAGAMENTO.APPROVATA AS DOMANDA_PAGAMENTO_APPROVATA, dbo.SPESE_SOSTENUTE.AMMESSO, dbo.SPESE_SOSTENUTE.DATA_APPROVAZIONE, 
                      dbo.SPESE_SOSTENUTE.OPERATORE_APPROVAZIONE, dbo.SPESE_SOSTENUTE.ID_FILE, dbo.GIUSTIFICATIVI.ID_FILE AS ID_FILE_GIUSTIFICATIVO, dbo.SPESE_SOSTENUTE.IN_INTEGRAZIONE, 
                      dbo.SPESE_SOSTENUTE.ID_FILE_MODIFICATO_INTEGRAZIONE
FROM         dbo.SPESE_SOSTENUTE INNER JOIN
                      dbo.TIPO_GIUSTIFICATIVO AS TIPO_GIUSTIFICATIVO_1 ON dbo.SPESE_SOSTENUTE.COD_TIPO = TIPO_GIUSTIFICATIVO_1.COD_TIPO INNER JOIN
                      dbo.GIUSTIFICATIVI ON dbo.SPESE_SOSTENUTE.ID_GIUSTIFICATIVO = dbo.GIUSTIFICATIVI.ID_GIUSTIFICATIVO INNER JOIN
                      dbo.TIPO_GIUSTIFICATIVO ON dbo.GIUSTIFICATIVI.COD_TIPO = dbo.TIPO_GIUSTIFICATIVO.COD_TIPO INNER JOIN
                      dbo.DOMANDA_DI_PAGAMENTO ON dbo.SPESE_SOSTENUTE.ID_DOMANDA_PAGAMENTO = dbo.DOMANDA_DI_PAGAMENTO.ID_DOMANDA_PAGAMENTO

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[39] 4[22] 2[21] 3) )"
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
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SPESE_SOSTENUTE"
            Begin Extent = 
               Top = 25
               Left = 74
               Bottom = 278
               Right = 290
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "TIPO_GIUSTIFICATIVO_1"
            Begin Extent = 
               Top = 175
               Left = 353
               Bottom = 283
               Right = 512
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GIUSTIFICATIVI"
            Begin Extent = 
               Top = 6
               Left = 591
               Bottom = 257
               Right = 804
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "TIPO_GIUSTIFICATIVO"
            Begin Extent = 
               Top = 36
               Left = 914
               Bottom = 144
               Right = 1073
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DOMANDA_DI_PAGAMENTO"
            Begin Extent = 
               Top = 282
               Left = 38
               Bottom = 402
               Right = 331
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
      Begin ColumnWidths = 24
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
  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vSPESE_SOSTENUTE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'       Width = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vSPESE_SOSTENUTE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vSPESE_SOSTENUTE';

