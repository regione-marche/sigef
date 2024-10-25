CREATE VIEW [dbo].[vATTO]
AS
SELECT     dbo.ATTI.ID_ATTO, dbo.ATTI.NUMERO, dbo.ATTI.DATA, dbo.ATTI.DESCRIZIONE, dbo.ATTI.SERVIZIO, dbo.ATTI.REGISTRO, dbo.ATTI.COD_TIPO, 
                      dbo.ATTI.COD_DEFINIZIONE, dbo.ATTI.COD_ORGANO_ISTITUZIONALE, dbo.ATTI.DATA_BUR, dbo.ATTI.NUMERO_BUR, dbo.ATTI.AW_DOCNUMBER, 
                      dbo.ATTI.AW_DOCNUMBER_NUOVO, dbo.TIPO_DEFINIZIONE_ATTO.DESCRIZIONE AS DEFINIZIONE_ATTO, dbo.TIPO_ATTO.DESCRIZIONE AS TIPO_ATTO, 
                      dbo.ORGANO_ISTITUZIONALE.DESCRIZIONE AS ORGANO_ISTITUZIONALE
FROM         dbo.ATTI INNER JOIN
                      dbo.TIPO_DEFINIZIONE_ATTO ON dbo.ATTI.COD_DEFINIZIONE = dbo.TIPO_DEFINIZIONE_ATTO.CODICE INNER JOIN
                      dbo.ORGANO_ISTITUZIONALE ON dbo.ATTI.COD_ORGANO_ISTITUZIONALE = dbo.ORGANO_ISTITUZIONALE.CODICE LEFT OUTER JOIN
                      dbo.TIPO_ATTO ON dbo.ATTI.COD_TIPO = dbo.TIPO_ATTO.CODICE

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
         Begin Table = "ATTI"
            Begin Extent = 
               Top = 7
               Left = 66
               Bottom = 232
               Right = 289
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_ATTO"
            Begin Extent = 
               Top = 6
               Left = 499
               Bottom = 84
               Right = 653
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEFINIZIONE_ATTO"
            Begin Extent = 
               Top = 111
               Left = 491
               Bottom = 189
               Right = 686
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ORGANO_ISTITUZIONALE"
            Begin Extent = 
               Top = 203
               Left = 471
               Bottom = 281
               Right = 694
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
      Begin ColumnWidths = 16
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
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3795
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vATTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'= 1170
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vATTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vATTO';

