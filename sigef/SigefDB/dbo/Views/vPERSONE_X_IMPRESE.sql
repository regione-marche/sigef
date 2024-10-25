

CREATE VIEW [dbo].[vPERSONE_X_IMPRESE]
AS
SELECT     dbo.PERSONE_X_IMPRESE.ID_PERSONA, dbo.PERSONA_FISICA.NOME, dbo.PERSONA_FISICA.COGNOME, dbo.PERSONA_FISICA.CODICE_FISCALE, 
                      dbo.PERSONA_FISICA.SESSO, dbo.PERSONA_FISICA.DATA_NASCITA, dbo.PERSONA_FISICA.ID_COMUNE_NASCITA, dbo.PERSONA_FISICA.ID_CITTADINANZA, 
                      dbo.PERSONE_X_IMPRESE.ID_PERSONE_X_IMPRESE, dbo.PERSONE_X_IMPRESE.ID_IMPRESA, dbo.PERSONE_X_IMPRESE.COD_RUOLO, 
                      dbo.PERSONE_X_IMPRESE.DATA_INIZIO, dbo.PERSONE_X_IMPRESE.DATA_FINE, dbo.RUOLO.DESCRIZIONE AS RUOLO, 
                      dbo.vCOMUNI.DENOMINAZIONE AS COMUNE, dbo.vCOMUNI.SIGLA, dbo.vCOMUNI.CAP, dbo.vCOMUNI.COD_BELFIORE, dbo.PERSONE_X_IMPRESE.AMMESSO, 
                      dbo.RUOLO.POTERE_DI_FIRMA, dbo.PERSONE_X_IMPRESE.ATTIVO
FROM         dbo.PERSONE_X_IMPRESE INNER JOIN
                      dbo.PERSONA_FISICA ON dbo.PERSONE_X_IMPRESE.ID_PERSONA = dbo.PERSONA_FISICA.ID_PERSONA INNER JOIN
                      dbo.RUOLO ON dbo.PERSONE_X_IMPRESE.COD_RUOLO = dbo.RUOLO.COD_RUOLO INNER JOIN
                      dbo.vCOMUNI ON dbo.PERSONA_FISICA.ID_COMUNE_NASCITA = dbo.vCOMUNI.ID_COMUNE



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
         Begin Table = "PERSONA_FISICA"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 229
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PERSONE_X_IMPRESE"
            Begin Extent = 
               Top = 8
               Left = 320
               Bottom = 163
               Right = 524
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RUOLO"
            Begin Extent = 
               Top = 70
               Left = 659
               Bottom = 148
               Right = 810
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vComuni"
            Begin Extent = 
               Top = 6
               Left = 848
               Bottom = 114
               Right = 1004
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
      Begin ColumnWidths = 20
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1845
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
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPERSONE_X_IMPRESE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'      Table = 1170
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPERSONE_X_IMPRESE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPERSONE_X_IMPRESE';

