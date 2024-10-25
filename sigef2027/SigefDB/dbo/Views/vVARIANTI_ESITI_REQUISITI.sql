CREATE VIEW [dbo].[vVARIANTI_ESITI_REQUISITI]
AS
SELECT     dbo.VARIANTI_ESITI_REQUISITI.ID_VARIANTE, dbo.VARIANTI_ESITI_REQUISITI.ID_REQUISITO, dbo.VARIANTI_ESITI_REQUISITI.COD_ESITO, 
                      dbo.VARIANTI_ESITI_REQUISITI.DATA, dbo.VARIANTI_ESITI_REQUISITI.CF_OPERATORE, dbo.VARIANTI_ESITI_REQUISITI.COD_ESITO_ISTRUTTORE, 
                      dbo.VARIANTI_ESITI_REQUISITI.DATA_VALUTAZIONE, dbo.VARIANTI_ESITI_REQUISITI.ISTRUTTORE, dbo.VARIANTI_ESITI_REQUISITI.NOTE, 
                      dbo.VARIANTI_ESITI_REQUISITI.ESCLUDI_DA_COMUNICAZIONE, dbo.REQUISITI_VARIANTE.AUTOMATICO, dbo.REQUISITI_VARIANTE.DESCRIZIONE, 
                      dbo.REQUISITI_VARIANTE.QUERY_EVAL, dbo.REQUISITI_VARIANTE.QUERY_INSERT, dbo.REQUISITI_VARIANTE.VAL_MINIMO, 
                      dbo.REQUISITI_VARIANTE.VAL_MASSIMO, dbo.REQUISITI_VARIANTE.MISURA, ESITI_STEP_1.DESCRIZIONE AS ESITO, 
                      ESITI_STEP_1.ESITO_POSITIVO, dbo.ESITI_STEP.DESCRIZIONE AS ESITO_ISTRUTTORE, 
                      dbo.ESITI_STEP.ESITO_POSITIVO AS ESITO_POSITIVO_ISTRUTTORE
FROM         dbo.VARIANTI_ESITI_REQUISITI INNER JOIN
                      dbo.REQUISITI_VARIANTE ON dbo.VARIANTI_ESITI_REQUISITI.ID_REQUISITO = dbo.REQUISITI_VARIANTE.ID_REQUISITO LEFT OUTER JOIN
                      dbo.ESITI_STEP ON dbo.VARIANTI_ESITI_REQUISITI.COD_ESITO_ISTRUTTORE = dbo.ESITI_STEP.COD_ESITO LEFT OUTER JOIN
                      dbo.ESITI_STEP AS ESITI_STEP_1 ON dbo.VARIANTI_ESITI_REQUISITI.COD_ESITO = ESITI_STEP_1.COD_ESITO

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
         Begin Table = "VARIANTI_ESITI_REQUISITI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 232
               Right = 272
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "REQUISITI_VARIANTE"
            Begin Extent = 
               Top = 6
               Left = 310
               Bottom = 226
               Right = 466
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ESITI_STEP_1"
            Begin Extent = 
               Top = 6
               Left = 504
               Bottom = 99
               Right = 668
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ESITI_STEP"
            Begin Extent = 
               Top = 126
               Left = 721
               Bottom = 219
               Right = 885
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
      Begin ColumnWidths = 22
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
      End
   End
   Begin CriteriaPane = 
      Begin Co', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vVARIANTI_ESITI_REQUISITI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'lumnWidths = 11
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vVARIANTI_ESITI_REQUISITI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vVARIANTI_ESITI_REQUISITI';

