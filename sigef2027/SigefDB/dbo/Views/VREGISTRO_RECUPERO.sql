CREATE VIEW dbo.VREGISTRO_RECUPERO
AS
SELECT     dbo.REGISTRO_RECUPERO.ID_REGISTRO_RECUPERO, dbo.REGISTRO_RECUPERO.DATA_INSERIMENTO, dbo.REGISTRO_RECUPERO.CF_INSERIMENTO, 
                      dbo.REGISTRO_RECUPERO.DATA_MODIFICA, dbo.REGISTRO_RECUPERO.CF_MODIFICA, dbo.REGISTRO_RECUPERO.ID_REGISTRO_IRREGOLARITA, dbo.REGISTRO_RECUPERO.DATA_AVVIO, 
                      dbo.REGISTRO_RECUPERO.DATA_PROBABILE_CONCLUSIONE, dbo.REGISTRO_RECUPERO.IMPORTO_DA_RECUPERARE_UE, 
                      dbo.REGISTRO_RECUPERO.IMPORTO_DA_RECUPERARE_NAZIONALE, dbo.REGISTRO_RECUPERO.IMPORTO_DA_RECUPERARE_PUBBLICO, 
                      dbo.REGISTRO_RECUPERO.IMPORTO_DETRATTO_UE, dbo.REGISTRO_RECUPERO.IMPORTO_DETRATTO_NAZIONALE, dbo.REGISTRO_RECUPERO.IMPORTO_DETRATTO_PUBBLICO, 
                      dbo.REGISTRO_RECUPERO.IMPORTO_RECUPERATO_UE, dbo.REGISTRO_RECUPERO.IMPORTO_RECUPERATO_PUBBLICO, dbo.REGISTRO_RECUPERO.IMPORTO_RECUPERATO_NAZIONALE, 
                      dbo.REGISTRO_RECUPERO.SALDO_DA_RECUPERARE_UE, dbo.REGISTRO_RECUPERO.SALDO_DA_RECUPERARE_NAZIONALE, 
                      dbo.REGISTRO_RECUPERO.SALDO_DA_RECUPERARE_PUBBLICO, dbo.REGISTRO_RECUPERO.IMPORTO_VERSATO_UE, dbo.REGISTRO_RECUPERO.IMPORTO_RITENUTO_STATO, 
                      dbo.REGISTRO_RECUPERO.DATA_CONCLUSIONE, dbo.REGISTRO_RECUPERO.ID_PROCEDURE_AVVIATE, dbo.REGISTRO_RECUPERO.ID_TIPO_PROCEDURE_AVVIATE, 
                      dbo.REGISTRO_RECUPERO.DATA_AVVIO_PROCEDURE, dbo.REGISTRO_RECUPERO.DATA_PROBABILE_CONCLUSIONE_PROCEDURE, dbo.REGISTRO_RECUPERO.ID_TIPO_RECUPERO, 
                      dbo.REGISTRO_RECUPERO.ID_ORIGINE_RECUPERO, dbo.REGISTRO_RECUPERO.ID_STORICO_RECUPERO_PRECEDENTE, dbo.REGISTRO_RECUPERO.ID_PROGETTO, 
                      dbo.PROGETTO.ID_BANDO, dbo.PROGETTO.ID_IMPRESA, dbo.PROGETTO.COD_AGEA, dbo.PROGETTO.SEGNATURA_ALLEGATI, dbo.PROGETTO.ID_PROG_INTEGRATO, 
                      dbo.PROGETTO.FLAG_PREADESIONE, dbo.PROGETTO.FLAG_DEFINITIVO, dbo.PROGETTO.ID_FASCICOLO, dbo.PROGETTO.PROVINCIA_DI_PRESENTAZIONE, 
                      dbo.PROGETTO.SELEZIONATA_X_REVISIONE, dbo.PROGETTO.ID_STORICO_ULTIMO, dbo.PROGETTO.DATA_CREAZIONE, dbo.PROGETTO.OPERATORE_CREAZIONE, 
                      dbo.PROGETTO.FIRMA_PREDISPOSTA, dbo.REGISTRO_RECUPERO.STORICO, dbo.REGISTRO_RECUPERO.IMPORTO_INTERESSI_LEGALI, 
                      dbo.REGISTRO_RECUPERO.IMPORTO_INTERESSI_MORA, dbo.REGISTRO_RECUPERO.IMPORTO_GESTIONE_PRATICA, dbo.REGISTRO_RECUPERO.DATA_REGISTRAZIONE_RITIRO, 
                      dbo.REGISTRO_RECUPERO.DATA_CERTIFICAZIONE_RECUPERO, dbo.REGISTRO_RECUPERO.DATA_CERTIFICAZIONE_RITIRO, dbo.REGISTRO_RECUPERO.GESTIONE_RATE, 
                      dbo.REGISTRO_RECUPERO.NUMERO_RATE, dbo.REGISTRO_RECUPERO.DATA_INIZIO_RATE, dbo.REGISTRO_RECUPERO.IMPORTO_RATA, dbo.REGISTRO_RECUPERO.INTERVALLO_RATE_MESI, 
                      dbo.BANDO.ID_PROGRAMMAZIONE, INTERVENTI.PROGRAMMAZIONE, dbo.REGISTRO_RECUPERO.IMPORTO_DA_RECUPERARE_PRIVATO, 
                      dbo.REGISTRO_RECUPERO.IMPORTO_DA_RECUPERARE_TOTALE, dbo.REGISTRO_RECUPERO.IMPORTO_DETRATTO_PRIVATO, dbo.REGISTRO_RECUPERO.IMPORTO_RECUPERATO_PRIVATO, 
                      dbo.REGISTRO_RECUPERO.IMPORTO_RECUPERATO_TOTALE, dbo.REGISTRO_RECUPERO.SALDO_DA_RECUPERARE_PRIVATO, dbo.REGISTRO_RECUPERO.SALDO_DA_RECUPERARE_TOTALE, 
                      dbo.REGISTRO_RECUPERO.SOGGETTO_REVOCA_FINANZIAMENTO, dbo.REGISTRO_RECUPERO.ID_ATTO_RECUPERO, dbo.REGISTRO_RECUPERO.ID_ATTO_RITIRO, 
                      dbo.REGISTRO_RECUPERO.ID_ATTO_NON_RECUPERABILITA, dbo.REGISTRO_RECUPERO.RECUPERABILE, dbo.REGISTRO_RECUPERO.IMPORTO_DETRATTO_TOTALE, 
                      dbo.REGISTRO_RECUPERO.DATA_CERTIFICAZIONE_NON_RECUPERABILITA, dbo.REGISTRO_RECUPERO.DATA_REGISTRAZIONE_NON_RECUPERABILITA, INTERVENTI.COD_ASSE, 
                      INTERVENTI.DESC_AZIONE, dbo.REGISTRO_RECUPERO.DATA_SEGNATURA, dbo.REGISTRO_RECUPERO.SEGNATURA
FROM         dbo.REGISTRO_RECUPERO INNER JOIN
                      dbo.PROGETTO ON dbo.REGISTRO_RECUPERO.ID_PROGETTO = dbo.PROGETTO.ID_PROGETTO INNER JOIN
                      dbo.BANDO ON dbo.PROGETTO.ID_BANDO = dbo.BANDO.ID_BANDO INNER JOIN
                          (SELECT     ID, CODICE AS COD_ASSE, DESCRIZIONE AS DESC_AZIONE, 'AZIONE ' + CODICE + ' - ' + DESCRIZIONE AS PROGRAMMAZIONE
                            FROM          dbo.vzPROGRAMMAZIONE) AS INTERVENTI ON INTERVENTI.ID = dbo.BANDO.ID_PROGRAMMAZIONE

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[36] 4[24] 2[18] 3) )"
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
         Top = -21
         Left = -350
      End
      Begin Tables = 
         Begin Table = "REGISTRO_RECUPERO"
            Begin Extent = 
               Top = 18
               Left = 865
               Bottom = 316
               Right = 1187
            End
            DisplayFlags = 280
            TopColumn = 44
         End
         Begin Table = "PROGETTO"
            Begin Extent = 
               Top = 7
               Left = 558
               Bottom = 325
               Right = 808
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BANDO"
            Begin Extent = 
               Top = 0
               Left = 305
               Bottom = 331
               Right = 529
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "INTERVENTI"
            Begin Extent = 
               Top = 27
               Left = 1225
               Bottom = 147
               Right = 1410
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
         Column = 3420
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
     ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VREGISTRO_RECUPERO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'    Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VREGISTRO_RECUPERO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VREGISTRO_RECUPERO';

