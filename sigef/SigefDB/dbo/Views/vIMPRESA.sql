CREATE VIEW dbo.vIMPRESA
AS
SELECT     dbo.IMPRESA.ID_IMPRESA, dbo.IMPRESA.CUAA, dbo.IMPRESA.CODICE_FISCALE, dbo.IMPRESA.ANNO_COSTITUZIONE, dbo.IMPRESA.COD_ENTE, dbo.IMPRESA.ISCRIZIONE_REGISTRO_IMPRESE, 
                      dbo.IMPRESA.PRESENTAZIONE, dbo.IMPRESA.DESCRIZIONE, dbo.IMPRESA_STORICO.ID_STORICO_IMPRESA, dbo.IMPRESA_STORICO.DATA_INIZIO_VALIDITA, 
                      dbo.IMPRESA_STORICO.DATA_FINE_VALIDITA, dbo.IMPRESA_STORICO.RAGIONE_SOCIALE, dbo.IMPRESA_STORICO.CODICE_INPS, dbo.IMPRESA_STORICO.COD_FORMA_GIURIDICA, 
                      dbo.IMPRESA_STORICO.ID_DIMENSIONE, dbo.DIMENSIONE_IMPRESA.DESCRIZIONE AS DIMENSIONE_IMPRESA, dbo.FORMA_GIURIDICA.DESCRIZIONE AS FORMA_GIURIDICA, 
                      dbo.FORMA_GIURIDICA.FOGLIA, dbo.IMPRESA.DATA_INIZIO_ATTIVITA, dbo.IMPRESA_STORICO.REGISTRO_IMPRESE_NUMERO, dbo.IMPRESA_STORICO.REA_NUMERO, 
                      dbo.IMPRESA_STORICO.REA_ANNO, dbo.IMPRESA.ID_STORICO_ULTIMO, dbo.IMPRESA.ID_RAPPRLEGALE_ULTIMO, dbo.IMPRESA.ID_CONTO_CORRENTE_ULTIMO, 
                      dbo.IMPRESA.ID_SEDELEGALE_ULTIMO, dbo.IMPRESA_STORICO.COD_CLASSIFICAZIONE_UMA, dbo.IMPRESA_STORICO.ATTIVA, dbo.IMPRESA_STORICO.DATA_CESSAZIONE, 
                      dbo.IMPRESA_STORICO.SEGNATURA_CESSAZIONE, dbo.IMPRESA_STORICO.COD_TIPO_CESSAZIONE, dbo.IMPRESA_STORICO.COD_ATECO2007
FROM         dbo.IMPRESA INNER JOIN
                      dbo.IMPRESA_STORICO ON dbo.IMPRESA.ID_STORICO_ULTIMO = dbo.IMPRESA_STORICO.ID_STORICO_IMPRESA LEFT OUTER JOIN
                      dbo.DIMENSIONE_IMPRESA ON dbo.IMPRESA_STORICO.ID_DIMENSIONE = dbo.DIMENSIONE_IMPRESA.ID_DIMENSIONE LEFT OUTER JOIN
                      dbo.FORMA_GIURIDICA ON dbo.IMPRESA_STORICO.COD_FORMA_GIURIDICA = dbo.FORMA_GIURIDICA.COD_ISTAT

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[13] 2[32] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[51] 2[24] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1[56] 3) )"
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
      ActivePaneConfig = 2
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "IMPRESA"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 265
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "IMPRESA_STORICO"
            Begin Extent = 
               Top = 56
               Left = 466
               Bottom = 291
               Right = 670
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "DIMENSIONE_IMPRESA"
            Begin Extent = 
               Top = 215
               Left = 814
               Bottom = 293
               Right = 974
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FORMA_GIURIDICA"
            Begin Extent = 
               Top = 42
               Left = 848
               Bottom = 135
               Right = 999
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
      Begin ColumnWidths = 19
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
         Width = 5175
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
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vIMPRESA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'= 900
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vIMPRESA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vIMPRESA';

