CREATE VIEW dbo.vPAGAMENTI_RICHIESTI
AS
SELECT     dbo.PAGAMENTI_RICHIESTI.ID_PAGAMENTO_RICHIESTO, dbo.PAGAMENTI_RICHIESTI.ID_INVESTIMENTO, dbo.PAGAMENTI_RICHIESTI.DATA_RICHIESTA_PAGAMENTO, 
                      dbo.PAGAMENTI_RICHIESTI.CONTRIBUTO_RICHIESTO, dbo.PAGAMENTI_RICHIESTI.CONTRIBUTO_AMMESSO, dbo.PAGAMENTI_RICHIESTI.AMMESSO, dbo.PAGAMENTI_RICHIESTI.ISTRUTTORE, 
                      dbo.PAGAMENTI_RICHIESTI.DATA_VALUTAZIONE, dbo.PAGAMENTI_RICHIESTI.IMPORTO_COMPUTO_METRICO, dbo.PAGAMENTI_RICHIESTI.IMPORTO_RICHIESTO, 
                      dbo.PAGAMENTI_RICHIESTI.IMPORTO_AMMESSO, ISNULL(dbo.PROGETTO.ID_PROG_INTEGRATO, dbo.PROGETTO.ID_PROGETTO) AS ID_PROGETTO, 
                      dbo.PAGAMENTI_RICHIESTI.ID_DOMANDA_PAGAMENTO, dbo.PIANO_INVESTIMENTI.ID_PROGRAMMAZIONE, dbo.PIANO_INVESTIMENTI.DESCRIZIONE, 
                      dbo.PIANO_INVESTIMENTI.DATA_VARIAZIONE, dbo.PIANO_INVESTIMENTI.OPERATORE_VARIAZIONE, dbo.PIANO_INVESTIMENTI.COD_TIPO_INVESTIMENTO, dbo.PIANO_INVESTIMENTI.COD_STP, 
                      dbo.PIANO_INVESTIMENTI.ID_UNITA_MISURA, dbo.PIANO_INVESTIMENTI.QUANTITA, dbo.PIANO_INVESTIMENTI.COSTO_INVESTIMENTO, dbo.PIANO_INVESTIMENTI.SPESE_GENERALI, 
                      dbo.PIANO_INVESTIMENTI.CONTRIBUTO_RICHIESTO AS CONTRIBUTO_RICHIESTO_INVESTIMENTO, dbo.PIANO_INVESTIMENTI.QUOTA_CONTRIBUTO_RICHIESTO, 
                      dbo.PIANO_INVESTIMENTI.ID_SETTORE_PRODUTTIVO, dbo.PIANO_INVESTIMENTI.ID_PRIORITA_SETTORIALE, dbo.PIANO_INVESTIMENTI.ID_OBIETTIVO_MISURA, 
                      dbo.PIANO_INVESTIMENTI.ID_CODIFICA_INVESTIMENTO, dbo.PIANO_INVESTIMENTI.ID_DETTAGLIO_INVESTIMENTO, dbo.PIANO_INVESTIMENTI.ID_SPECIFICA_INVESTIMENTO, 
                      dbo.PIANO_INVESTIMENTI.AMMESSO AS INVESTIMENTO_AMMESSO, dbo.PIANO_INVESTIMENTI.ISTRUTTORE AS ISTRUTTORE_INVESTIMENTO, 
                      dbo.PIANO_INVESTIMENTI.ID_INVESTIMENTO_ORIGINALE, dbo.PIANO_INVESTIMENTI.DATA_VALUTAZIONE AS DATA_VALUTAZIONE_INVESTIMENTO, 
                      dbo.PIANO_INVESTIMENTI.VALUTAZIONE_INVESTIMENTO, dbo.PIANO_INVESTIMENTI.ID_VARIANTE, dbo.PAGAMENTI_RICHIESTI.IMPORTO_COMPUTO_METRICO_AMMESSO, 
                      dbo.PAGAMENTI_RICHIESTI.CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO, dbo.PAGAMENTI_RICHIESTI.CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO, 
                      dbo.PAGAMENTI_RICHIESTI.NOTE_ISTRUTTORE, dbo.PAGAMENTI_RICHIESTI.COD_SANZIONE_VARIAZIONE_INVESTIMENTI, dbo.PAGAMENTI_RICHIESTI.CONTRIBUTO_RICHIESTO_ALTRE_FONTI, 
                      dbo.PAGAMENTI_RICHIESTI.IMPORTO_DISAVANZO_COSTI_AMMESSI, dbo.PAGAMENTI_RICHIESTI.CONTRIBUTO_DISAVANZO_COSTI_AMMESSI, 
                      dbo.PAGAMENTI_RICHIESTI.CONTRIBUTO_AMMESSO_ALTRE_FONTI
FROM         dbo.PAGAMENTI_RICHIESTI INNER JOIN
                      dbo.PIANO_INVESTIMENTI ON dbo.PAGAMENTI_RICHIESTI.ID_INVESTIMENTO = dbo.PIANO_INVESTIMENTI.ID_INVESTIMENTO INNER JOIN
                      dbo.PROGETTO ON dbo.PIANO_INVESTIMENTI.ID_PROGETTO = dbo.PROGETTO.ID_PROGETTO

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[52] 4[11] 2[27] 3) )"
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
         Begin Table = "PAGAMENTI_RICHIESTI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 256
               Right = 275
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "PIANO_INVESTIMENTI"
            Begin Extent = 
               Top = 11
               Left = 423
               Bottom = 416
               Right = 686
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PROGETTO"
            Begin Extent = 
               Top = 34
               Left = 823
               Bottom = 372
               Right = 1069
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
      Begin ColumnWidths = 41
         Width = 284
         Width = 2550
         Width = 2760
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
        ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPAGAMENTI_RICHIESTI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' Width = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPAGAMENTI_RICHIESTI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPAGAMENTI_RICHIESTI';

