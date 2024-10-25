CREATE VIEW dbo.vIMPRESA_STORICO
AS
SELECT dbo.IMPRESA_STORICO.ID_STORICO_IMPRESA, dbo.IMPRESA_STORICO.ID_IMPRESA, dbo.IMPRESA_STORICO.DATA_INIZIO_VALIDITA, 
                  dbo.IMPRESA_STORICO.DATA_FINE_VALIDITA, dbo.IMPRESA_STORICO.RAGIONE_SOCIALE, dbo.IMPRESA_STORICO.CODICE_INPS, 
                  dbo.IMPRESA_STORICO.COD_FORMA_GIURIDICA, dbo.IMPRESA_STORICO.ID_DIMENSIONE, dbo.IMPRESA_STORICO.REGISTRO_IMPRESE_NUMERO, 
                  dbo.IMPRESA_STORICO.REA_NUMERO, dbo.IMPRESA_STORICO.REA_ANNO, dbo.DIMENSIONE_IMPRESA.DESCRIZIONE AS DIMENSIONE_IMPRESA, 
                  dbo.FORMA_GIURIDICA.DESCRIZIONE AS FORMA_GIURIDICA, dbo.IMPRESA_STORICO.COD_CLASSIFICAZIONE_UMA, dbo.IMPRESA_STORICO.ATTIVA, 
                  dbo.IMPRESA_STORICO.DATA_CESSAZIONE, dbo.IMPRESA_STORICO.SEGNATURA_CESSAZIONE, dbo.IMPRESA_STORICO.COD_TIPO_CESSAZIONE, 
                  dbo.IMPRESA_STORICO.COD_ATECO2007
FROM     dbo.IMPRESA_STORICO LEFT OUTER JOIN
                  dbo.FORMA_GIURIDICA ON dbo.IMPRESA_STORICO.COD_FORMA_GIURIDICA = dbo.FORMA_GIURIDICA.COD_ISTAT LEFT OUTER JOIN
                  dbo.DIMENSIONE_IMPRESA ON dbo.IMPRESA_STORICO.ID_DIMENSIONE = dbo.DIMENSIONE_IMPRESA.ID_DIMENSIONE

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[54] 4[19] 2[23] 3) )"
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
         Begin Table = "FORMA_GIURIDICA"
            Begin Extent = 
               Top = 6
               Left = 314
               Bottom = 107
               Right = 474
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DIMENSIONE_IMPRESA"
            Begin Extent = 
               Top = 173
               Left = 637
               Bottom = 259
               Right = 806
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "IMPRESA_STORICO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 307
               Right = 366
            End
            DisplayFlags = 280
            TopColumn = 7
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
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vIMPRESA_STORICO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vIMPRESA_STORICO';

