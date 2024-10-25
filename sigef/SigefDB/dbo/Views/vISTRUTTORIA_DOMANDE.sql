CREATE VIEW [dbo].[vISTRUTTORIA_DOMANDE]
AS
SELECT     dbo.PROGETTO.ID_PROGETTO, dbo.PROGETTO.ID_BANDO, dbo.PROGETTO.ID_PROG_INTEGRATO, dbo.PROGETTO_STORICO.COD_STATO, 
                      dbo.STATO_PROGETTO.DESCRIZIONE AS STATO, dbo.vIMPRESA.CUAA, dbo.vIMPRESA.CODICE_FISCALE AS PARTITA_IVA, dbo.vIMPRESA.RAGIONE_SOCIALE, 
                      dbo.vINDIRIZZARIO.COMUNE, dbo.vINDIRIZZARIO.SIGLA, dbo.vINDIRIZZARIO.CAP, 
                      dbo.PERSONA_FISICA.COGNOME + ' ' + dbo.PERSONA_FISICA.NOME AS ISTRUTTORE, dbo.COLLABORATORI_X_BANDO.PROVINCIA AS PROVINCIA_ASSEGNAZIONE, 
                      dbo.PROGETTO.SELEZIONATA_X_REVISIONE, dbo.PROGETTO.PROVINCIA_DI_PRESENTAZIONE, dbo.COLLABORATORI_X_BANDO.ID_UTENTE AS ID_ISTRUTTORE, 
                      dbo.vINDIRIZZARIO.VIA, S.SEGNATURA_RI, S.COD_STATO AS FILTRO_STATO_ISTRUTTORIA, dbo.STATO_PROGETTO.ORDINE AS ORDINE_STATO, 
                      dbo.PROGETTO.ID_IMPRESA
FROM         dbo.PROGETTO INNER JOIN
                      dbo.PROGETTO_STORICO ON dbo.PROGETTO.ID_STORICO_ULTIMO = dbo.PROGETTO_STORICO.ID INNER JOIN
                      dbo.STATO_PROGETTO ON dbo.PROGETTO_STORICO.COD_STATO = dbo.STATO_PROGETTO.COD_STATO INNER JOIN
                      dbo.vIMPRESA ON dbo.PROGETTO.ID_IMPRESA = dbo.vIMPRESA.ID_IMPRESA INNER JOIN
                      dbo.vINDIRIZZARIO ON dbo.vIMPRESA.ID_SEDELEGALE_ULTIMO = dbo.vINDIRIZZARIO.ID_INDIRIZZARIO INNER JOIN
                      dbo.COLLABORATORI_X_BANDO ON dbo.PROGETTO.ID_PROGETTO = dbo.COLLABORATORI_X_BANDO.ID_PROGETTO AND 
                      dbo.COLLABORATORI_X_BANDO.ATTIVO = 1 INNER JOIN
                      dbo.UTENTI ON dbo.COLLABORATORI_X_BANDO.ID_UTENTE = dbo.UTENTI.ID_UTENTE INNER JOIN
                      dbo.PERSONA_FISICA ON dbo.UTENTI.ID_PERSONA_FISICA = dbo.PERSONA_FISICA.ID_PERSONA INNER JOIN
                      dbo.PROGETTO_STORICO AS S ON dbo.PROGETTO.ID_PROGETTO = S.ID_PROGETTO INNER JOIN
                          (SELECT     MAX(PS.ID) AS MAX_ID, PS.ID_PROGETTO, T.COD_FASE
                            FROM          dbo.PROGETTO_STORICO AS PS INNER JOIN
                                                   dbo.STATO_PROGETTO AS T ON PS.COD_STATO = T.COD_STATO
                            GROUP BY PS.ID_PROGETTO, T.COD_FASE) AS S2 ON S.ID = S2.MAX_ID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[38] 4[13] 2[34] 3) )"
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
         Begin Table = "PROGETTO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 122
               Right = 293
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MON_STATO_PROGETTO"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 242
               Right = 266
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "STATO_PROGETTO"
            Begin Extent = 
               Top = 126
               Left = 304
               Bottom = 242
               Right = 464
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vIMPRESA"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 354
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vINDIRIZZARIO"
            Begin Extent = 
               Top = 354
               Left = 38
               Bottom = 462
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COLLABORATORI_X_BANDO"
            Begin Extent = 
               Top = 606
               Left = 38
               Bottom = 722
               Right = 235
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UTENTI"
            Begin Extent = 
               Top = 726
               Left = 38
               Bottom = 842
               Right = 269
          ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vISTRUTTORIA_DOMANDE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'  End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "M2"
            Begin Extent = 
               Top = 6
               Left = 331
               Bottom = 122
               Right = 559
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "M3"
            Begin Extent = 
               Top = 6
               Left = 597
               Bottom = 107
               Right = 852
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
      Begin ColumnWidths = 43
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vISTRUTTORIA_DOMANDE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vISTRUTTORIA_DOMANDE';

