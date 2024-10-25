
CREATE VIEW [dbo].[VTESTATA_CONTROLLI_LOCO]
AS
SELECT     dbo.TESTATA_CONTROLLI_LOCO.ID_TESTATA, dbo.TESTATA_CONTROLLI_LOCO.DATA_INSERIMENTO, dbo.TESTATA_CONTROLLI_LOCO.CF_INSERIMENTO, 
                      dbo.TESTATA_CONTROLLI_LOCO.DATA_MODIFICA, dbo.TESTATA_CONTROLLI_LOCO.CF_MODIFICA, dbo.TESTATA_CONTROLLI_LOCO.DATA_SOPRALLUOGO, 
                      dbo.TESTATA_CONTROLLI_LOCO.LUOGO_SOPRALLUOGO, dbo.TESTATA_CONTROLLI_LOCO.ID_ISTANZA_CHECKLIST_GENERICA, dbo.ISTANZA_CHECKLIST_GENERICA.ID_CHECKLIST_GENERICA, 
                      dbo.TESTATA_CONTROLLI_LOCO.IDLOCO_DETTAGLIO, dbo.CntrLoco_Dettaglio.IdLoco, dbo.CntrLoco_Dettaglio.Id_Domanda_Pagamento, dbo.CntrLoco_Dettaglio.Id_Progetto, 
                      dbo.CntrLoco_Dettaglio.Asse, dbo.CntrLoco_Dettaglio.Selezionata, dbo.CntrLoco_Dettaglio.Esito AS ESITO_CONTROLLO, dbo.CntrLoco_Dettaglio.DataEsito AS DATAESITO_CONTROLLO, 
                      dbo.CntrLoco_Dettaglio.CostoTotale, dbo.CntrLoco_Dettaglio.ImportoAmmesso, dbo.CntrLoco_Dettaglio.ImportoConcesso, dbo.CntrLoco_Dettaglio.NrOperazioniB, 
                      dbo.CntrLoco_Dettaglio.Beneficiario, dbo.CntrLoco_Dettaglio.SpesaAmmessa, dbo.CntrLoco_Dettaglio.ImportoContributoPubblico, dbo.CntrLoco_Dettaglio.ImportoContributoPubblico_Incrementale, 
                      dbo.CntrLoco_Dettaglio.SpesaAmmessa_Incrementale, dbo.CntrLoco_Dettaglio.Esclusione, dbo.CntrLoco_Dettaglio.RischioIR, dbo.CntrLoco_Dettaglio.RischioCR, 
                      dbo.CntrLoco_Dettaglio.RischioComp, dbo.CntrLoco_Dettaglio.Azione, dbo.CntrLoco_Dettaglio.Intervento, dbo.TESTATA_CONTROLLI_LOCO.ESITO_TESTATA, 
                      dbo.TESTATA_CONTROLLI_LOCO.ID_FILE_VERBALE, dbo.TESTATA_CONTROLLI_LOCO.ID_FILE_ATTESTAZIONE, dbo.DOMANDA_DI_PAGAMENTO.COD_TIPO AS TIPO_DOMANDA, 
                      dbo.TESTATA_CONTROLLI_LOCO.SEGNATURA_TESTATA, dbo.TESTATA_CONTROLLI_LOCO.DATA_VERBALE, dbo.TESTATA_CONTROLLI_LOCO.DATA_ATTESTAZIONE, 
                      dbo.TESTATA_CONTROLLI_LOCO.DATA_SEGNATURA, dbo.TESTATA_CONTROLLI_LOCO.ID_UTENTE_COMPILATORE, dbo.TESTATA_CONTROLLI_LOCO.ID_UTENTE_VALIDATORE, 
                      VUTENTE_COMPILATORE.ID_PERSONA_FISICA AS ID_PERSONA_FISICA_COMPILATORE, VUTENTE_COMPILATORE.ID_STORICO_ULTIMO AS ID_STORICO_ULTIMO_COMPILATORE, 
                      VUTENTE_COMPILATORE.CF_UTENTE AS CF_UTENTE_COMPILATORE, VUTENTE_COMPILATORE.PROFILO AS PROFILO_COMPILATORE, VUTENTE_COMPILATORE.ENTE AS ENTE_COMPILATORE, 
                      VUTENTE_COMPILATORE.NOMINATIVO AS NOMINATIVO_COMPILATORE, VUTENTE_VALIDATORE.ID_PERSONA_FISICA AS ID_PERSONA_FISICA_VALIDATORE, 
                      VUTENTE_VALIDATORE.ID_STORICO_ULTIMO AS ID_STORICO_ULTIMO_VALIDATORE, VUTENTE_VALIDATORE.CF_UTENTE AS CF_UTENTE_VALIDATORE, 
                      VUTENTE_VALIDATORE.PROFILO AS PROFILO_VALIDATORE, VUTENTE_VALIDATORE.ENTE AS ENTE_VALIDATORE, VUTENTE_VALIDATORE.NOMINATIVO AS NOMINATIVO_VALIDATORE
FROM         dbo.TESTATA_CONTROLLI_LOCO INNER JOIN
                      dbo.ISTANZA_CHECKLIST_GENERICA ON dbo.TESTATA_CONTROLLI_LOCO.ID_ISTANZA_CHECKLIST_GENERICA = dbo.ISTANZA_CHECKLIST_GENERICA.ID_ISTANZA_GENERICA INNER JOIN
                      dbo.CntrLoco_Dettaglio ON dbo.TESTATA_CONTROLLI_LOCO.IDLOCO_DETTAGLIO = dbo.CntrLoco_Dettaglio.IdLoco_Dettaglio INNER JOIN
                      dbo.DOMANDA_DI_PAGAMENTO ON dbo.CntrLoco_Dettaglio.Id_Domanda_Pagamento = dbo.DOMANDA_DI_PAGAMENTO.ID_DOMANDA_PAGAMENTO LEFT OUTER JOIN
                      dbo.vUTENTI AS VUTENTE_COMPILATORE ON dbo.TESTATA_CONTROLLI_LOCO.ID_UTENTE_COMPILATORE = VUTENTE_COMPILATORE.ID_UTENTE LEFT OUTER JOIN
                      dbo.vUTENTI AS VUTENTE_VALIDATORE ON dbo.TESTATA_CONTROLLI_LOCO.ID_UTENTE_VALIDATORE = VUTENTE_VALIDATORE.ID_UTENTE


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[49] 4[19] 2[19] 3) )"
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
         Begin Table = "TESTATA_CONTROLLI_LOCO"
            Begin Extent = 
               Top = 10
               Left = 431
               Bottom = 216
               Right = 697
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "ISTANZA_CHECKLIST_GENERICA"
            Begin Extent = 
               Top = 16
               Left = 980
               Bottom = 187
               Right = 1197
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CntrLoco_Dettaglio"
            Begin Extent = 
               Top = 187
               Left = 15
               Bottom = 389
               Right = 301
            End
            DisplayFlags = 280
            TopColumn = 17
         End
         Begin Table = "DOMANDA_DI_PAGAMENTO"
            Begin Extent = 
               Top = 272
               Left = 426
               Bottom = 392
               Right = 719
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VUTENTE_COMPILATORE"
            Begin Extent = 
               Top = 264
               Left = 764
               Bottom = 410
               Right = 960
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "VUTENTE_VALIDATORE"
            Begin Extent = 
               Top = 214
               Left = 1031
               Bottom = 334
               Right = 1227
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
      Begin C', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VTESTATA_CONTROLLI_LOCO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'olumnWidths = 43
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
         Column = 2655
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VTESTATA_CONTROLLI_LOCO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VTESTATA_CONTROLLI_LOCO';

