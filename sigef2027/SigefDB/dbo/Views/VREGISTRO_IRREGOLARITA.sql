CREATE VIEW dbo.VREGISTRO_IRREGOLARITA
AS
SELECT     dbo.REGISTRO_IRREGOLARITA.SEGNALAZIONE_OLAF, dbo.REGISTRO_IRREGOLARITA.DATA_SEGNALAZIONE, dbo.REGISTRO_IRREGOLARITA.TRIMESTRE_SEGNALAZIONE, 
                      dbo.REGISTRO_IRREGOLARITA.DATA_MODIFICA, dbo.REGISTRO_IRREGOLARITA.CF_MODIFICA, dbo.REGISTRO_IRREGOLARITA.DATA_INSERIMENTO, 
                      dbo.REGISTRO_IRREGOLARITA.CF_INSERIMENTO, dbo.REGISTRO_IRREGOLARITA.ID_PROGETTO, dbo.REGISTRO_IRREGOLARITA.ID_IRREGOLARITA, 
                      dbo.REGISTRO_IRREGOLARITA.NUMERO_RIFERIMENTO_OLAF, dbo.REGISTRO_IRREGOLARITA.SOSPETTO_FRODE, dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARE_CERTIFICATO, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARE_DA_RECUPERARE, dbo.REGISTRO_IRREGOLARITA.ANNO, dbo.REGISTRO_IRREGOLARITA.PERIODO_PROGRAMMAZIONE, 
                      dbo.REGISTRO_IRREGOLARITA.NUMERO_RIFERIMENTO_NAZIONALE, dbo.REGISTRO_IRREGOLARITA.AZIONE_PENALE, dbo.REGISTRO_IRREGOLARITA.DATA_CREAZIONE_IDENTIFICAZIONE, 
                      dbo.REGISTRO_IRREGOLARITA.TRIMESTRE_IDENTIFICAZIONE, dbo.REGISTRO_IRREGOLARITA.PROCEDIMENTO_AMMINISTRATIVO, dbo.REGISTRO_IRREGOLARITA.AZIONE_GIUDIZIARIA, 
                      dbo.REGISTRO_IRREGOLARITA.DATA_PRIMA_INFORMAZIONE_SOSPETTO, dbo.REGISTRO_IRREGOLARITA.FONTE_PRIMA_INFORMAZIONE_SOSPETTO, 
                      dbo.REGISTRO_IRREGOLARITA.DATA_IRREGOLARITA, dbo.REGISTRO_IRREGOLARITA.DATA_IRREGOLARITA_DA, dbo.REGISTRO_IRREGOLARITA.DATA_IRREGOLARITA_A, 
                      dbo.REGISTRO_IRREGOLARITA.COMMESSA_A, dbo.REGISTRO_IRREGOLARITA.ID_CATEGORIA_IRREGOLARITA, dbo.REGISTRO_IRREGOLARITA.ID_TIPO_IRREGOLARITA, 
                      dbo.REGISTRO_IRREGOLARITA.MODUS_OPERANDI, dbo.REGISTRO_IRREGOLARITA.DICHIARAZIONE_OPERATORE, dbo.REGISTRO_IRREGOLARITA.ACCERTAMENTI_AMMINISTRATORE, 
                      dbo.REGISTRO_IRREGOLARITA.ID_CLASSIFICAZIONE_IRREGOLARITA, dbo.REGISTRO_IRREGOLARITA.DATA_PRIMO_ATTO_CONSTATAZIONE_AMMINISTRATIVO, 
                      dbo.REGISTRO_IRREGOLARITA.ID_MOTIVO_ESECUZIONE_CONTROLLO, dbo.REGISTRO_IRREGOLARITA.ID_TIPO_CONTROLLO, 
                      dbo.REGISTRO_IRREGOLARITA.ID_CONTROLLO_PRIMA_DOPO_PAGAMENTO, dbo.REGISTRO_IRREGOLARITA.AUTORITA_CONTROLLO, dbo.REGISTRO_IRREGOLARITA.INDAGINE_OLAF, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_SPESA_UE, dbo.REGISTRO_IRREGOLARITA.IMPORTO_SPESA_NAZIONALE, dbo.REGISTRO_IRREGOLARITA.IMPORTO_SPESA_PUBBLICO, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_SPESA_PRIVATO, dbo.REGISTRO_IRREGOLARITA.IMPORTO_SPESA_TOTALE, dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_UE, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_NAZIONALE, dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_PUBBLICO, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_PRIVATO, dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_TOTALE, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_NON_PAGATO_UE, dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_NON_PAGATO_NAZIONALE, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_NON_PAGATO_PUBBLICO, dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_NON_PAGATO_PRIVATO, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_NON_PAGATO_TOTALE, dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_PAGATO_UE, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_PAGATO_NAZIONALE, dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_PAGATO_PUBBLICO, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_PAGATO_PRIVATO, dbo.REGISTRO_IRREGOLARITA.IMPORTO_IRREGOLARITA_PAGATO_TOTALE, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_DA_RECUPERARE_UE, dbo.REGISTRO_IRREGOLARITA.IMPORTO_DA_RECUPERARE_NAZIONALE, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_DA_RECUPERARE_PUBBLICO, dbo.REGISTRO_IRREGOLARITA.IMPORTO_DA_RECUPERARE_PRIVATO, 
                      dbo.REGISTRO_IRREGOLARITA.IMPORTO_DA_RECUPERARE_TOTALE, dbo.REGISTRO_IRREGOLARITA.SPESA_DECERTIFICATA, 
                      dbo.REGISTRO_IRREGOLARITA.COMMENTI_IMPATTO_FINANZIARIO, dbo.PROGETTO.ID_BANDO, dbo.PROGETTO.COD_AGEA, dbo.PROGETTO.SEGNATURA_ALLEGATI, 
                      dbo.PROGETTO.ID_PROG_INTEGRATO, dbo.PROGETTO.FLAG_PREADESIONE, dbo.PROGETTO.FLAG_DEFINITIVO, dbo.PROGETTO.ID_FASCICOLO, dbo.PROGETTO.PROVINCIA_DI_PRESENTAZIONE,
                       dbo.PROGETTO.SELEZIONATA_X_REVISIONE, dbo.PROGETTO.ID_STORICO_ULTIMO, dbo.PROGETTO.DATA_CREAZIONE, dbo.PROGETTO.OPERATORE_CREAZIONE, 
                      dbo.PROGETTO.FIRMA_PREDISPOSTA, dbo.REGISTRO_IRREGOLARITA.ID_FONDO, dbo.REGISTRO_IRREGOLARITA.ID_CONTROLLO_ORIGINE, 
                      dbo.REGISTRO_IRREGOLARITA.ID_STATO_FINANZIARIO, dbo.REGISTRO_IRREGOLARITA.DESCRIZIONE_CONTROLLO_ESTERNO, dbo.REGISTRO_IRREGOLARITA.ID_IMPRESA_COMMESSA_DA, 
                      dbo.REGISTRO_IRREGOLARITA.NOTE_COMMESSA_DA, dbo.REGISTRO_IRREGOLARITA.STABILITA_OPERAZIONI, dbo.REGISTRO_IRREGOLARITA.ID_DOMANDA_PAGAMENTO, 
                      dbo.PROGETTO.ID_IMPRESA AS ID_IMPRESA_PROGETTO
FROM         dbo.REGISTRO_IRREGOLARITA INNER JOIN
                      dbo.PROGETTO ON dbo.REGISTRO_IRREGOLARITA.ID_PROGETTO = dbo.PROGETTO.ID_PROGETTO

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
         Begin Table = "REGISTRO_IRREGOLARITA"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 341
               Right = 411
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PROGETTO"
            Begin Extent = 
               Top = 6
               Left = 449
               Bottom = 341
               Right = 699
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
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 5385
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VREGISTRO_IRREGOLARITA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VREGISTRO_IRREGOLARITA';

