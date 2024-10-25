CREATE VIEW [dbo].[vITER_PROGETTO]
AS
SELECT     dbo.ITER_PROGETTO.ID_PROGETTO, dbo.ITER_PROGETTO.ID_STEP, dbo.ITER_PROGETTO.COD_ESITO, dbo.ITER_PROGETTO.DATA, 
                      dbo.ITER_PROGETTO.CF_OPERATORE, dbo.ITER_PROGETTO.NOTE, dbo.ITER_PROGETTO.COD_ESITO_REVISORE, dbo.ITER_PROGETTO.DATA_REVISORE, 
                      dbo.ITER_PROGETTO.REVISORE, dbo.ITER_PROGETTO.NOTE_REVISORE, dbo.ESITI_STEP.DESCRIZIONE AS ESITO_ISTRUTTORE, 
                      dbo.ESITI_STEP.ESITO_POSITIVO AS ESITO_POSITIVO_ISTRUTTORE, ESITI_STEP_1.DESCRIZIONE AS ESITO_REVISORE, 
                      ESITI_STEP_1.ESITO_POSITIVO AS ESITO_POSITIVO_REVISORE, dbo.PROGETTO.ID_BANDO, dbo.PROGETTO.SELEZIONATA_X_REVISIONE, 
                      dbo.STEP_X_BANDO.ID_CHECK_LIST, dbo.STEP_X_BANDO.COD_FASE, dbo.CHECK_LIST_X_STEP.ORDINE, dbo.CHECK_LIST_X_STEP.OBBLIGATORIO, 
                      dbo.STEP.DESCRIZIONE AS STEP, dbo.STEP.AUTOMATICO, dbo.STEP.QUERY_SQL, dbo.STEP.QUERY_SQL_POST, dbo.STEP.CODE_METHOD, dbo.STEP.URL, 
                      dbo.STEP.VAL_MINIMO, dbo.STEP.VAL_MASSIMO, dbo.STEP.MISURA, dbo.ITER_PROGETTO.ESCLUDI_DA_COMUNICAZIONE, 
                      dbo.CHECK_LIST_X_STEP.INCLUDI_VERBALE_VIS
FROM         dbo.PROGETTO INNER JOIN
                      dbo.STEP_X_BANDO ON dbo.PROGETTO.ID_BANDO = dbo.STEP_X_BANDO.ID_BANDO INNER JOIN
                      dbo.CHECK_LIST_X_STEP ON dbo.STEP_X_BANDO.ID_CHECK_LIST = dbo.CHECK_LIST_X_STEP.ID_CHECK_LIST INNER JOIN
                      dbo.STEP ON dbo.CHECK_LIST_X_STEP.ID_STEP = dbo.STEP.ID_STEP LEFT OUTER JOIN
                      dbo.ITER_PROGETTO ON dbo.PROGETTO.ID_PROGETTO = dbo.ITER_PROGETTO.ID_PROGETTO AND 
                      dbo.STEP.ID_STEP = dbo.ITER_PROGETTO.ID_STEP LEFT OUTER JOIN
                      dbo.ESITI_STEP ON dbo.ITER_PROGETTO.COD_ESITO = dbo.ESITI_STEP.COD_ESITO LEFT OUTER JOIN
                      dbo.ESITI_STEP AS ESITI_STEP_1 ON dbo.ITER_PROGETTO.COD_ESITO_REVISORE = ESITI_STEP_1.COD_ESITO

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
               Top = 27
               Left = 310
               Bottom = 135
               Right = 556
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "STEP_X_BANDO"
            Begin Extent = 
               Top = 114
               Left = 38
               Bottom = 207
               Right = 195
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CHECK_LIST_X_STEP"
            Begin Extent = 
               Top = 114
               Left = 233
               Bottom = 222
               Right = 390
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "STEP"
            Begin Extent = 
               Top = 210
               Left = 38
               Bottom = 318
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ITER_PROGETTO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 184
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ESITI_STEP"
            Begin Extent = 
               Top = 102
               Left = 518
               Bottom = 195
               Right = 682
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ESITI_STEP_1"
            Begin Extent = 
               Top = 222
               Left = 247
               Bottom = 315
               Right = 411
            End
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vITER_PROGETTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vITER_PROGETTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vITER_PROGETTO';

