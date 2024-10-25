



CREATE VIEW [dbo].[vPROGETTO]
AS
SELECT     dbo.PROGETTO.ID_PROGETTO, dbo.PROGETTO.ID_BANDO, dbo.PROGETTO.COD_AGEA, dbo.PROGETTO.SEGNATURA_ALLEGATI, 
                      dbo.PROGETTO_STORICO.COD_STATO, dbo.PROGETTO_STORICO.DATA, dbo.PROGETTO_STORICO.OPERATORE, dbo.PROGETTO_STORICO.SEGNATURA, 
                      dbo.PROGETTO_STORICO.REVISIONE, dbo.PROGETTO_STORICO.RIESAME, dbo.PROGETTO_STORICO.RICORSO, dbo.PROGETTO_STORICO.DATA_RI, 
                      dbo.PROGETTO_STORICO.OPERATORE_RI, dbo.PROGETTO_STORICO.SEGNATURA_RI, dbo.STATO_PROGETTO.DESCRIZIONE AS STATO, 
                      dbo.STATO_PROGETTO.COD_FASE, dbo.STATO_PROGETTO.ORDINE AS ORDINE_STATO, dbo.FASI_PROCEDURALI.DESCRIZIONE AS FASE, 
                      dbo.FASI_PROCEDURALI.ORDINE AS ORDINE_FASE, dbo.PROGETTO.ID_PROG_INTEGRATO, dbo.PROGETTO.FLAG_PREADESIONE, 
                      dbo.PROGETTO.FLAG_DEFINITIVO, dbo.PROGETTO.ID_FASCICOLO, dbo.PROGETTO.PROVINCIA_DI_PRESENTAZIONE, dbo.PROGETTO.SELEZIONATA_X_REVISIONE, 
                      dbo.PROGETTO.ID_IMPRESA, dbo.PROGETTO.ID_STORICO_ULTIMO, dbo.PROGETTO.DATA_CREAZIONE, dbo.PROGETTO.OPERATORE_CREAZIONE, 
                      dbo.vUTENTI.NOMINATIVO, dbo.vUTENTI.ENTE, dbo.vUTENTI.COD_ENTE, dbo.vUTENTI.PROVINCIA, dbo.vUTENTI.COD_TIPO_ENTE, 
                      dbo.PROGETTO_STORICO.RIAPERTURA_PROVINCIALE, dbo.PROGETTO.FIRMA_PREDISPOSTA, dbo.PROGETTO_STORICO.ID_ATTO
FROM         dbo.PROGETTO INNER JOIN
                      dbo.PROGETTO_STORICO ON dbo.PROGETTO.ID_STORICO_ULTIMO = dbo.PROGETTO_STORICO.ID INNER JOIN
                      dbo.STATO_PROGETTO ON dbo.PROGETTO_STORICO.COD_STATO = dbo.STATO_PROGETTO.COD_STATO INNER JOIN
                      dbo.vUTENTI ON dbo.PROGETTO_STORICO.OPERATORE = dbo.vUTENTI.ID_UTENTE LEFT OUTER JOIN
                      dbo.FASI_PROCEDURALI ON dbo.STATO_PROGETTO.COD_FASE = dbo.FASI_PROCEDURALI.COD_FASE





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
         Begin Table = "PROGETTO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 328
               Right = 293
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "PROGETTO_STORICO"
            Begin Extent = 
               Top = 6
               Left = 331
               Bottom = 260
               Right = 518
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "STATO_PROGETTO"
            Begin Extent = 
               Top = 6
               Left = 805
               Bottom = 195
               Right = 965
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FASI_PROCEDURALI"
            Begin Extent = 
               Top = 6
               Left = 1003
               Bottom = 107
               Right = 1163
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UTENTI"
            Begin Extent = 
               Top = 6
               Left = 536
               Bottom = 251
               Right = 767
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ENTE"
            Begin Extent = 
               Top = 191
               Left = 933
               Bottom = 307
               Right = 1105
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
      Begin ColumnWidths = 35
         Width = 284
         Width = 1500
       ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPROGETTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'  Width = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPROGETTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPROGETTO';

