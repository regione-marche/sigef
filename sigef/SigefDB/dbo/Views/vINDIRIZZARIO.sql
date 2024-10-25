CREATE VIEW [dbo].[vINDIRIZZARIO]
AS
SELECT     dbo.INDIRIZZARIO.ID_INDIRIZZARIO, dbo.INDIRIZZARIO.ID_INDIRIZZO, dbo.INDIRIZZARIO.ID_PERSONA, dbo.INDIRIZZARIO.ID_IMPRESA, 
                      dbo.INDIRIZZARIO.COD_TIPO_SEDE, dbo.INDIRIZZARIO.DATA_INIZIO_VALIDITA, dbo.INDIRIZZARIO.DATA_FINE_VALIDITA, dbo.INDIRIZZARIO.FLAG_ATTIVO, 
                      dbo.TIPO_SEDE.DESCRIZIONE AS TIPO_SEDE, dbo.INDIRIZZO.VIA, dbo.INDIRIZZO.LOCALITA, dbo.INDIRIZZO.ID_COMUNE, dbo.INDIRIZZARIO.TELEFONO, 
                      dbo.INDIRIZZARIO.FAX, dbo.INDIRIZZARIO.EMAIL, dbo.INDIRIZZO.DENOMINAZIONE, dbo.vCOMUNI.DENOMINAZIONE AS COMUNE, dbo.vCOMUNI.CAP, 
                      dbo.vCOMUNI.ISTAT, dbo.vCOMUNI.SIGLA, dbo.vCOMUNI.PROVINCIA, dbo.vCOMUNI.COD_REGIONE, dbo.vCOMUNI.REGIONE, dbo.vCOMUNI.TIPO_AREA, 
                      dbo.INDIRIZZARIO.PEC, dbo.vCOMUNI.COD_PROVINCIA
FROM         dbo.INDIRIZZO INNER JOIN
                      dbo.vCOMUNI ON dbo.INDIRIZZO.ID_COMUNE = dbo.vCOMUNI.ID_COMUNE INNER JOIN
                      dbo.INDIRIZZARIO ON dbo.INDIRIZZO.ID_INDIRIZZO = dbo.INDIRIZZARIO.ID_INDIRIZZO INNER JOIN
                      dbo.TIPO_SEDE ON dbo.INDIRIZZARIO.COD_TIPO_SEDE = dbo.TIPO_SEDE.COD_TIPO_SEDE

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[51] 4[11] 2[21] 3) )"
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
         Begin Table = "INDIRIZZO"
            Begin Extent = 
               Top = 22
               Left = 374
               Bottom = 203
               Right = 547
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vComuni"
            Begin Extent = 
               Top = 10
               Left = 606
               Bottom = 332
               Right = 901
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "INDIRIZZARIO"
            Begin Extent = 
               Top = 46
               Left = 79
               Bottom = 290
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_SEDE"
            Begin Extent = 
               Top = 247
               Left = 373
               Bottom = 332
               Right = 536
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
      Begin ColumnWidths = 28
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
         Widt', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vINDIRIZZARIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'h = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vINDIRIZZARIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vINDIRIZZARIO';

