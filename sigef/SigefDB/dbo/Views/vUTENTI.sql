
CREATE VIEW [dbo].[vUTENTI]
AS
SELECT     dbo.UTENTI.ID_UTENTE, dbo.UTENTI.ID_PERSONA_FISICA, dbo.ENTE.COD_TIPO_ENTE, dbo.UTENTI.ID_STORICO_ULTIMO, dbo.UTENTI.ULTIMO_ACCESSO, 
                      dbo.PERSONA_FISICA.CODICE_FISCALE AS CF_UTENTE, dbo.PROFILI.DESCRIZIONE AS PROFILO, dbo.ENTE.DESCRIZIONE AS ENTE, 
                      dbo.PERSONA_FISICA.COGNOME + ' ' + dbo.PERSONA_FISICA.NOME AS NOMINATIVO, dbo.UTENTI_STORICO.ID_PROFILO, dbo.UTENTI_STORICO.COD_ENTE, 
                      dbo.UTENTI_STORICO.PROVINCIA, dbo.UTENTI_STORICO.EMAIL, dbo.UTENTI_STORICO.ATTIVO, dbo.UTENTI_STORICO.DATA, 
                      dbo.UTENTI_STORICO.OPERATORE
FROM         dbo.UTENTI INNER JOIN
                      dbo.UTENTI_STORICO ON dbo.UTENTI.ID_STORICO_ULTIMO = dbo.UTENTI_STORICO.ID INNER JOIN
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
         Begin Table = "UTENTI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 206
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PROFILI"
            Begin Extent = 
               Top = 7
               Left = 346
               Bottom = 134
               Right = 497
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ENTE"
            Begin Extent = 
               Top = 141
               Left = 491
               Bottom = 272
               Right = 642
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 2235
         Width = 1575
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vUTENTI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vUTENTI';

