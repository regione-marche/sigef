CREATE VIEW [dbo].[vSANZIONI]
AS
SELECT     dbo.SANZIONI.ID_SANZIONE, dbo.SANZIONI.COD_TIPO, dbo.SANZIONI.ID_DOMANDA_PAGAMENTO, dbo.SANZIONI.ID_PROGETTO, 
                      dbo.SANZIONI.DATA_APPLICAZIONE, dbo.SANZIONI.OPERATORE, dbo.SANZIONI.AMMONTARE, dbo.SANZIONI.ID_INVESTIMENTO, dbo.SANZIONI.DURATA, 
                      dbo.SANZIONI.VALORE_DURATA, dbo.SANZIONI.GRAVITA, dbo.SANZIONI.VALORE_GRAVITA, dbo.SANZIONI.ENTITA, dbo.SANZIONI.VALORE_ENTITA, 
                      dbo.TIPO_SANZIONI.TITOLO, dbo.TIPO_SANZIONI.DESCRIZIONE, dbo.TIPO_SANZIONI.QUERY_SQL, dbo.TIPO_SANZIONI.LIVELLO, dbo.TIPO_SANZIONI.ISTRUTTORIA, 
                      dbo.TIPO_SANZIONI.CONTROLLO_IN_LOCO, dbo.TIPO_SANZIONI.EX_POST, ENTITA.DESCRIZIONE AS DESCRIZIONE_ENTITA, 
                      GRAVITA.DESCRIZIONE AS DESCRIZIONE_GRAVITA, DURATA.DESCRIZIONE AS DESCRIZIONE_DURATA, dbo.TIPO_SANZIONI.DURATA_SELEZIONATO, 
                      dbo.TIPO_SANZIONI.DURATA_NUMERICO, dbo.TIPO_SANZIONI.DURATA_TOOLTIP, dbo.TIPO_SANZIONI.GRAVITA_SELEZIONATO, 
                      dbo.TIPO_SANZIONI.GRAVITA_NUMERICO, dbo.TIPO_SANZIONI.GRAVITA_TOOLTIP, dbo.TIPO_SANZIONI.ENTITA_SELEZIONATO, 
                      dbo.TIPO_SANZIONI.ENTITA_NUMERICO, dbo.TIPO_SANZIONI.ENTITA_TOOLTIP, dbo.TIPO_SANZIONI.AUTOMATICO, dbo.SANZIONI.MOTIVAZIONE
FROM         dbo.SANZIONI INNER JOIN
                      dbo.TIPO_SANZIONI ON dbo.SANZIONI.COD_TIPO = dbo.TIPO_SANZIONI.COD_TIPO LEFT OUTER JOIN
                      dbo.TIPO_SANZIONI_PARAMETRI AS DURATA ON dbo.SANZIONI.DURATA = DURATA.CODICE LEFT OUTER JOIN
                      dbo.TIPO_SANZIONI_PARAMETRI AS GRAVITA ON dbo.SANZIONI.GRAVITA = GRAVITA.CODICE LEFT OUTER JOIN
                      dbo.TIPO_SANZIONI_PARAMETRI AS ENTITA ON dbo.SANZIONI.ENTITA = ENTITA.CODICE

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[45] 4[16] 2[20] 3) )"
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
         Begin Table = "SANZIONI"
            Begin Extent = 
               Top = 24
               Left = 411
               Bottom = 315
               Right = 636
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_SANZIONI"
            Begin Extent = 
               Top = 12
               Left = 699
               Bottom = 360
               Right = 907
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DURATA"
            Begin Extent = 
               Top = 30
               Left = 30
               Bottom = 156
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GRAVITA"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 482
               Right = 269
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ENTITA"
            Begin Extent = 
               Top = 486
               Left = 38
               Bottom = 602
               Right = 269
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
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vSANZIONI';


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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vSANZIONI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vSANZIONI';

