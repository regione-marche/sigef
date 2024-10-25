CREATE VIEW dbo.vREVISIONE_DOMANDA_PAGAMENTO
AS
SELECT  dbo.DOMANDA_DI_PAGAMENTO.ID_DOMANDA_PAGAMENTO, 
        dbo.TIPO_DOMANDA_PAGAMENTO.DESCRIZIONE      AS TIPO_DOMANDA_PAGAMENTO, 
        dbo.TIPO_DOMANDA_PAGAMENTO.COD_FASE, 
        dbo.DOMANDA_DI_PAGAMENTO.DATA_MODIFICA      AS DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO, 
        dbo.DOMANDA_DI_PAGAMENTO.APPROVATA          AS DOMANDA_APPROVATA, 
        dbo.DOMANDA_DI_PAGAMENTO.ID_PROGETTO, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.ID_LOTTO, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.DATA_INSERIMENTO, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.DATA_MODIFICA, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.CF_OPERATORE, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.SELEZIONATA_X_REVISIONE, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.APPROVATA, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.NUMERO_ESTRAZIONE, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.ORDINE, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.SEGNATURA_REVISIONE, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.SEGNATURA_SECONDA_REVISIONE, 
        dbo.REVISIONE_DOMANDA_PAGAMENTO.DATA_VALIDAZIONE,
        dbo.DOMANDA_DI_PAGAMENTO.COD_TIPO, 
        dbo.DOMANDA_DI_PAGAMENTO.DATA_APPROVAZIONE, 
        dbo.PROGETTO.ID_BANDO, 
        dbo.PROGETTO.PROVINCIA_DI_PRESENTAZIONE
FROM dbo.DOMANDA_DI_PAGAMENTO 
     INNER JOIN
     dbo.TIPO_DOMANDA_PAGAMENTO ON dbo.DOMANDA_DI_PAGAMENTO.COD_TIPO = dbo.TIPO_DOMANDA_PAGAMENTO.COD_TIPO 
     INNER JOIN
     dbo.PROGETTO ON dbo.DOMANDA_DI_PAGAMENTO.ID_PROGETTO = dbo.PROGETTO.ID_PROGETTO 
     LEFT OUTER JOIN
     dbo.REVISIONE_DOMANDA_PAGAMENTO ON dbo.DOMANDA_DI_PAGAMENTO.ID_DOMANDA_PAGAMENTO = dbo.REVISIONE_DOMANDA_PAGAMENTO.ID_DOMANDA_PAGAMENTO
WHERE dbo.DOMANDA_DI_PAGAMENTO.SEGNATURA_APPROVAZIONE IS NOT NULL

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
         Top = -176
         Left = 0
      End
      Begin Tables = 
         Begin Table = "DOMANDA_DI_PAGAMENTO"
            Begin Extent = 
               Top = 4
               Left = 73
               Bottom = 319
               Right = 333
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_DOMANDA_PAGAMENTO"
            Begin Extent = 
               Top = 17
               Left = 467
               Bottom = 110
               Right = 618
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PROGETTO"
            Begin Extent = 
               Top = 320
               Left = 38
               Bottom = 428
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "REVISIONE_DOMANDA_PAGAMENTO"
            Begin Extent = 
               Top = 10
               Left = 740
               Bottom = 227
               Right = 960
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
      Begin ColumnWidths = 19
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
         A', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vREVISIONE_DOMANDA_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'lias = 900
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vREVISIONE_DOMANDA_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vREVISIONE_DOMANDA_PAGAMENTO';

