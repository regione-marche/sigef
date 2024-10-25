CREATE VIEW dbo.VINTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO
AS
SELECT     INTEG.ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO, INTEG.ID_DOMANDA_PAGAMENTO, INTEG.DATA_INSERIMENTO, INTEG.DATA_MODIFICA, INTEG.ISTANZA_DOMANDA_PAGAMENTO, 
                      INTEG.INTEGRAZIONE_COMPLETA, INTEG.NOTE_INTEGRAZIONE_DOMANDA, INTEG.CF_ISTRUTTORE, INTEG.DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, INTEG.SEGNATURA_ISTRUTTORE, 
                      INTEG.CF_BENFICIARIO, INTEG.SEGNATURA_BENEFICIARIO, INTEG.DATA_CONCLUSIONE_INTEGRAZIONE, DOM.COD_TIPO, DOM.ID_PROGETTO, 
                      DOM.DATA_INSERIMENTO AS DATA_INSERIMENTO_DOMANDA, DOM.CF_OPERATORE AS CF_OPERATORE_DOMANDA, DOM.DATA_MODIFICA AS DATA_MODIFICA_DOMANDA, DOM.COD_ENTE, 
                      DOM.SEGNATURA, DOM.SEGNATURA_ALLEGATI, DOM.ID_FIDEJUSSIONE, DOM.DATA_CERTIFICAZIONE_ANTIMAFIA, DOM.APPROVATA, DOM.SEGNATURA_APPROVAZIONE, 
                      DOM.SEGNATURA_SECONDA_APPROVAZIONE, DOM.CF_ISTRUTTORE AS CF_ISTRUTTORE_DOMANDA, DOM.DATA_APPROVAZIONE, DOM.VALUTAZIONE_ISTRUTTORE, DOM.ANNULLATA, 
                      DOM.SEGNATURA_ANNULLAMENTO, DOM.CF_OPERATORE_ANNULLAMENTO, DOM.DATA_ANNULLAMENTO, DOM.VALIDITA_VERSIONE_ADC, DOM.ID_VARIAZIONE_ACCERTATA, 
                      DOM.PREDISPOSTA_A_CONTROLLO, DOM.DATA_PREDISPOSIZIONE_A_CONTROLLO, DOM.VISITA_INSITU_ESITO, DOM.VISITA_INSITU_NOTE, DOM.CONTROLLO_INLOCO_ESITO, 
                      DOM.CONTROLLO_INLOCO_NOTE, DOM.VERIFICA_PAGAMENTI_ESITO, DOM.VERIFICA_PAGAMENTI_MESSAGGIO, DOM.VERIFICA_PAGAMENTI_DATA, DOM.FIRMA_PREDISPOSTA, 
                      DOM.IN_INTEGRAZIONE, DOM.ID_DOMANDA_PAGAMENTO AS ID_DOMANDA_PAGAMENTO_DOMANDA
FROM         dbo.INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO AS INTEG INNER JOIN
                      dbo.DOMANDA_DI_PAGAMENTO AS DOM ON DOM.ID_DOMANDA_PAGAMENTO = INTEG.ID_DOMANDA_PAGAMENTO

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[48] 4[21] 2[19] 3) )"
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
         Begin Table = "INTEG"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 268
               Right = 361
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DOM"
            Begin Extent = 
               Top = 7
               Left = 675
               Bottom = 408
               Right = 968
            End
            DisplayFlags = 280
            TopColumn = 12
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
         Column = 2820
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VINTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VINTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO';

