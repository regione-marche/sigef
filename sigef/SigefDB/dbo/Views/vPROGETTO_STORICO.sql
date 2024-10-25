





CREATE VIEW [dbo].[vPROGETTO_STORICO]
AS
SELECT     PROGETTO_STORICO.ID, PROGETTO_STORICO.ID_PROGETTO, PROGETTO_STORICO.COD_STATO, PROGETTO_STORICO.DATA, PROGETTO_STORICO.OPERATORE, 
                      PROGETTO_STORICO.SEGNATURA, PROGETTO_STORICO.REVISIONE, PROGETTO_STORICO.RIESAME, PROGETTO_STORICO.RICORSO, 
                      PROGETTO_STORICO.RIAPERTURA_PROVINCIALE, PROGETTO_STORICO.DATA_RI, PROGETTO_STORICO.OPERATORE_RI, PROGETTO_STORICO.SEGNATURA_RI, 
                      dbo.STATO_PROGETTO.DESCRIZIONE AS STATO, dbo.STATO_PROGETTO.COD_FASE, dbo.STATO_PROGETTO.ORDINE AS ORDINE_STATO, 
                      dbo.FASI_PROCEDURALI.DESCRIZIONE AS FASE, dbo.FASI_PROCEDURALI.ORDINE AS ORDINE_FASE, 
                      dbo.PERSONA_FISICA.COGNOME + ' ' + dbo.PERSONA_FISICA.NOME AS NOMINATIVO, dbo.UTENTI_STORICO.COD_ENTE, dbo.UTENTI_STORICO.PROVINCIA, 
                      dbo.UTENTI_STORICO.ID_PROFILO, dbo.PROFILI.DESCRIZIONE AS PROFILO, dbo.ENTE.DESCRIZIONE AS ENTE, dbo.ENTE.COD_TIPO_ENTE, 
                      PROGETTO_STORICO.ID_ATTO
FROM         (

SELECT     MAX(STO.ID) AS MAXID_STORICO, STO.ID_UTENTE, PS.ID, PS.ID_PROGETTO, PS.COD_STATO, PS.DATA, PS.OPERATORE, PS.SEGNATURA, PS.REVISIONE,
                                               PS.RIESAME, PS.RICORSO, PS.DATA_RI, PS.OPERATORE_RI, PS.SEGNATURA_RI, PS.RIAPERTURA_PROVINCIALE, PS.ID_ATTO
                       FROM          dbo.UTENTI_STORICO AS STO INNER JOIN
                                              dbo.PROGETTO_STORICO AS PS ON PS.OPERATORE = STO.ID_UTENTE --AND STO.DATA < PS.DATA
                       GROUP BY STO.ID_UTENTE, PS.ID, PS.ID_PROGETTO, PS.COD_STATO, PS.DATA, PS.OPERATORE, PS.SEGNATURA, PS.REVISIONE, PS.RIESAME, PS.RICORSO, 
                                              PS.DATA_RI, PS.OPERATORE_RI, PS.SEGNATURA_RI, PS.RIAPERTURA_PROVINCIALE, PS.ID_ATTO) 
                                              
                                              AS PROGETTO_STORICO INNER JOIN
                      dbo.STATO_PROGETTO ON dbo.STATO_PROGETTO.COD_STATO = PROGETTO_STORICO.COD_STATO LEFT OUTER JOIN
                      dbo.FASI_PROCEDURALI ON dbo.STATO_PROGETTO.COD_FASE = dbo.FASI_PROCEDURALI.COD_FASE INNER JOIN
                      dbo.UTENTI_STORICO ON dbo.UTENTI_STORICO.ID = PROGETTO_STORICO.MAXID_STORICO INNER JOIN
                      dbo.UTENTI ON dbo.UTENTI.ID_UTENTE = PROGETTO_STORICO.OPERATORE INNER JOIN
                      dbo.PERSONA_FISICA ON dbo.UTENTI.ID_PERSONA_FISICA = dbo.PERSONA_FISICA.ID_PERSONA LEFT OUTER JOIN
                      dbo.ENTE ON dbo.UTENTI_STORICO.COD_ENTE = dbo.ENTE.COD_ENTE INNER JOIN
                      dbo.PROFILI ON dbo.UTENTI_STORICO.ID_PROFILO = dbo.PROFILI.ID_PROFILO






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
         Begin Table = "PROGETTO_STORICO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 302
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "STATO_PROGETTO"
            Begin Extent = 
               Top = 6
               Left = 243
               Bottom = 150
               Right = 403
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FASI_PROCEDURALI"
            Begin Extent = 
               Top = 6
               Left = 441
               Bottom = 110
               Right = 601
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UTENTI"
            Begin Extent = 
               Top = 6
               Left = 639
               Bottom = 276
               Right = 870
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ENTE"
            Begin Extent = 
               Top = 6
               Left = 908
               Bottom = 160
               Right = 1080
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PROFILI"
            Begin Extent = 
               Top = 173
               Left = 865
               Bottom = 335
               Right = 1110
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
      Begin ColumnWidths = 25
         Width = 284
         Width = 1500
         ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPROGETTO_STORICO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'Width = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPROGETTO_STORICO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPROGETTO_STORICO';

