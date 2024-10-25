CREATE VIEW [dbo].[vVISITE_AZIENDALI]
AS
SELECT     dbo.VISITE_AZIENDALI.ID_VISITA, dbo.VISITE_AZIENDALI.ID_DOMANDA_PAGAMENTO, dbo.VISITE_AZIENDALI.ID_IMPRESA, dbo.VISITE_AZIENDALI.COD_TIPO, 
                      dbo.VISITE_AZIENDALI.DATA_APERTURA, dbo.VISITE_AZIENDALI.OPERATORE_APERTURA, dbo.VISITE_AZIENDALI.CONTROLLO_CONCLUSO, 
                      dbo.VISITE_AZIENDALI.DATA_CHIUSURA, dbo.VISITE_AZIENDALI.OPERATORE_CHIUSURA, dbo.VISITE_AZIENDALI.SEGNATURA_VERBALE, 
                      dbo.TIPO_VISITA_AZIENDALE.DESCRIZIONE AS TIPO_VISITA_AZIENDALE, 
                      dbo.PERSONA_FISICA.COGNOME + ' ' + dbo.PERSONA_FISICA.NOME AS NOMINATIVO_OPERATORE_APERTURA, 
                      PF_2.COGNOME + ' ' + PF_2.NOME AS NOMINATIVO_OPERATORE_CHIUSURA, dbo.DOMANDA_DI_PAGAMENTO.ID_PROGETTO, 
                      dbo.TIPO_DOMANDA_PAGAMENTO.DESCRIZIONE AS TIPO_DOMANDA_PAGAMENTO, dbo.VISITE_AZIENDALI.ID_DOMANDA_EROA
FROM         dbo.VISITE_AZIENDALI INNER JOIN
                      dbo.TIPO_VISITA_AZIENDALE ON dbo.VISITE_AZIENDALI.COD_TIPO = dbo.TIPO_VISITA_AZIENDALE.COD_TIPO INNER JOIN
                      dbo.PERSONA_FISICA ON dbo.VISITE_AZIENDALI.OPERATORE_APERTURA = dbo.PERSONA_FISICA.CODICE_FISCALE LEFT OUTER JOIN
                      dbo.DOMANDA_DI_PAGAMENTO ON 
                      dbo.VISITE_AZIENDALI.ID_DOMANDA_PAGAMENTO = dbo.DOMANDA_DI_PAGAMENTO.ID_DOMANDA_PAGAMENTO LEFT OUTER JOIN
                      dbo.TIPO_DOMANDA_PAGAMENTO ON dbo.DOMANDA_DI_PAGAMENTO.COD_TIPO = dbo.TIPO_DOMANDA_PAGAMENTO.COD_TIPO LEFT OUTER JOIN
                      dbo.PERSONA_FISICA AS PF_2 ON dbo.VISITE_AZIENDALI.OPERATORE_CHIUSURA = PF_2.CODICE_FISCALE

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
         Begin Table = "VISITE_AZIENDALI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 263
               Right = 263
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_VISITA_AZIENDALE"
            Begin Extent = 
               Top = 170
               Left = 329
               Bottom = 256
               Right = 489
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UTENTI"
            Begin Extent = 
               Top = 10
               Left = 589
               Bottom = 126
               Right = 820
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UTENTI_1"
            Begin Extent = 
               Top = 155
               Left = 615
               Bottom = 322
               Right = 846
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "DOMANDA_DI_PAGAMENTO"
            Begin Extent = 
               Top = 15
               Left = 895
               Bottom = 131
               Right = 1182
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_DOMANDA_PAGAMENTO"
            Begin Extent = 
               Top = 184
               Left = 969
               Bottom = 285
               Right = 1129
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
      Begin ColumnWidths = 15
         Width = 2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vVISITE_AZIENDALI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'84
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vVISITE_AZIENDALI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vVISITE_AZIENDALI';

