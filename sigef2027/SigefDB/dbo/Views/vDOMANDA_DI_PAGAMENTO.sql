CREATE VIEW dbo.vDOMANDA_DI_PAGAMENTO
AS
SELECT     dbo.DOMANDA_DI_PAGAMENTO.ID_DOMANDA_PAGAMENTO, dbo.DOMANDA_DI_PAGAMENTO.COD_TIPO, dbo.DOMANDA_DI_PAGAMENTO.ID_PROGETTO, 
                      dbo.DOMANDA_DI_PAGAMENTO.DATA_INSERIMENTO, dbo.DOMANDA_DI_PAGAMENTO.DATA_MODIFICA, dbo.DOMANDA_DI_PAGAMENTO.COD_ENTE, 
                      dbo.DOMANDA_DI_PAGAMENTO.SEGNATURA, dbo.TIPO_DOMANDA_PAGAMENTO.DESCRIZIONE, dbo.TIPO_DOMANDA_PAGAMENTO.COD_FASE, dbo.FASI_PROCEDURALI.DESCRIZIONE AS FASE, 
                      dbo.FASI_PROCEDURALI.ORDINE, dbo.DOMANDA_DI_PAGAMENTO.ID_FIDEJUSSIONE, dbo.PERSONA_FISICA.COGNOME + ' ' + dbo.PERSONA_FISICA.NOME AS OPERATORE, 
                      dbo.DOMANDA_DI_PAGAMENTO.CF_OPERATORE, dbo.DOMANDA_DI_PAGAMENTO.SEGNATURA_ALLEGATI, dbo.DOMANDA_DI_PAGAMENTO.DATA_CERTIFICAZIONE_ANTIMAFIA, 
                      dbo.DOMANDA_DI_PAGAMENTO.APPROVATA, dbo.DOMANDA_DI_PAGAMENTO.SEGNATURA_APPROVAZIONE, dbo.DOMANDA_DI_PAGAMENTO.CF_ISTRUTTORE, 
                      dbo.DOMANDA_DI_PAGAMENTO.DATA_APPROVAZIONE, dbo.DOMANDA_DI_PAGAMENTO.SEGNATURA_SECONDA_APPROVAZIONE, dbo.DOMANDA_DI_PAGAMENTO.ANNULLATA, 
                      dbo.DOMANDA_DI_PAGAMENTO.SEGNATURA_ANNULLAMENTO, dbo.DOMANDA_DI_PAGAMENTO.CF_OPERATORE_ANNULLAMENTO, dbo.DOMANDA_DI_PAGAMENTO.DATA_ANNULLAMENTO, 
                      dbo.DOMANDA_DI_PAGAMENTO.VALIDITA_VERSIONE_ADC, dbo.DOMANDA_DI_PAGAMENTO.ID_VARIAZIONE_ACCERTATA, dbo.DOMANDA_DI_PAGAMENTO.PREDISPOSTA_A_CONTROLLO, 
                      dbo.DOMANDA_DI_PAGAMENTO.VISITA_INSITU_ESITO, dbo.DOMANDA_DI_PAGAMENTO.VISITA_INSITU_NOTE, dbo.DOMANDA_DI_PAGAMENTO.CONTROLLO_INLOCO_ESITO, 
                      dbo.DOMANDA_DI_PAGAMENTO.CONTROLLO_INLOCO_NOTE, dbo.DOMANDA_DI_PAGAMENTO.VALUTAZIONE_ISTRUTTORE, dbo.DOMANDA_DI_PAGAMENTO.VERIFICA_PAGAMENTI_ESITO, 
                      dbo.DOMANDA_DI_PAGAMENTO.VERIFICA_PAGAMENTI_MESSAGGIO, dbo.DOMANDA_DI_PAGAMENTO.VERIFICA_PAGAMENTI_DATA, 
                      dbo.DOMANDA_DI_PAGAMENTO.DATA_PREDISPOSIZIONE_A_CONTROLLO, PF_2.COGNOME + ' ' + PF_2.NOME AS NOMINATIVO_OPERATORE_ANNULLAMENTO, 
                      PF_3.COGNOME + ' ' + PF_3.NOME AS ISTRUTTORE, dbo.DOMANDA_DI_PAGAMENTO.FIRMA_PREDISPOSTA, dbo.DOMANDA_DI_PAGAMENTO.IN_INTEGRAZIONE, 
                      dbo.DOMANDA_DI_PAGAMENTO.FIRMA_PREDISPOSTA_RUP
FROM         dbo.DOMANDA_DI_PAGAMENTO INNER JOIN
                      dbo.TIPO_DOMANDA_PAGAMENTO ON dbo.DOMANDA_DI_PAGAMENTO.COD_TIPO = dbo.TIPO_DOMANDA_PAGAMENTO.COD_TIPO INNER JOIN
                      dbo.FASI_PROCEDURALI ON dbo.TIPO_DOMANDA_PAGAMENTO.COD_FASE = dbo.FASI_PROCEDURALI.COD_FASE INNER JOIN
                      dbo.PERSONA_FISICA ON dbo.DOMANDA_DI_PAGAMENTO.CF_OPERATORE = dbo.PERSONA_FISICA.CODICE_FISCALE LEFT OUTER JOIN
                      dbo.PERSONA_FISICA AS PF_2 ON dbo.DOMANDA_DI_PAGAMENTO.CF_OPERATORE_ANNULLAMENTO = PF_2.CODICE_FISCALE LEFT OUTER JOIN
                      dbo.PERSONA_FISICA AS PF_3 ON dbo.DOMANDA_DI_PAGAMENTO.CF_ISTRUTTORE = PF_3.CODICE_FISCALE

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
         Top = -96
         Left = 0
      End
      Begin Tables = 
         Begin Table = "DOMANDA_DI_PAGAMENTO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 203
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 26
         End
         Begin Table = "TIPO_DOMANDA_PAGAMENTO"
            Begin Extent = 
               Top = 21
               Left = 301
               Bottom = 123
               Right = 452
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "FASI_PROCEDURALI"
            Begin Extent = 
               Top = 40
               Left = 532
               Bottom = 179
               Right = 683
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PERSONA_FISICA"
            Begin Extent = 
               Top = 204
               Left = 38
               Bottom = 324
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PF_2"
            Begin Extent = 
               Top = 204
               Left = 275
               Bottom = 324
               Right = 474
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "PF_3"
            Begin Extent = 
               Top = 324
               Left = 38
               Bottom = 444
               Right = 237
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
      Begin ColumnWidths = 36
         Width = 284
         W', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vDOMANDA_DI_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'idth = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vDOMANDA_DI_PAGAMENTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vDOMANDA_DI_PAGAMENTO';

