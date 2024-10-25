CREATE VIEW [dbo].[vDOMANDA_PAGAMENTO_ALLEGATI]
AS
SELECT        dbo.DOMANDA_PAGAMENTO_ALLEGATI.ID_ALLEGATO, dbo.DOMANDA_PAGAMENTO_ALLEGATI.ID_DOMANDA_PAGAMENTO, dbo.DOMANDA_PAGAMENTO_ALLEGATI.COD_TIPO_DOCUMENTO, 
                         dbo.DOMANDA_PAGAMENTO_ALLEGATI.ID_FILE, dbo.DOMANDA_PAGAMENTO_ALLEGATI.DESCRIZIONE, dbo.DOMANDA_PAGAMENTO_ALLEGATI.COD_ENTE_EMETTITORE, 
                         dbo.DOMANDA_PAGAMENTO_ALLEGATI.ID_COMUNE, dbo.DOMANDA_PAGAMENTO_ALLEGATI.NUMERO, dbo.DOMANDA_PAGAMENTO_ALLEGATI.DATA, dbo.DOMANDA_PAGAMENTO_ALLEGATI.COD_ESITO, 
                         dbo.DOMANDA_PAGAMENTO_ALLEGATI.NOTE_ISTRUTTORE, dbo.ESITI_STEP.DESCRIZIONE AS ESITO, dbo.ESITI_STEP.ESITO_POSITIVO, ISNULL(dbo.TIPO_DOCUMENTO.FORMATO, 'C') AS FORMATO, 
                         ISNULL(dbo.TIPO_ALLEGATO.DESCRIZIONE, 'Supporto Cartaceo') AS TIPO_ALLEGATO, dbo.TIPO_DOCUMENTO.DESCRIZIONE AS TIPOLOGIA_DOCUMENTO, CASE WHEN DOMANDA_PAGAMENTO_ALLEGATI.ID_COMUNE IS NULL
                          THEN ENTE.DESCRIZIONE ELSE 'COMUNE DI ' + COMUNI.DENOMINAZIONE + ' (' + COMUNI.SIGLA + ')' END AS ENTE, dbo.ARCHIVIO_FILE.DIMENSIONE / 1024 AS DIMENSIONE_FILE, 
                         dbo.DOMANDA_PAGAMENTO_ALLEGATI.IN_INTEGRAZIONE, dbo.DOMANDA_PAGAMENTO_ALLEGATI.DATA_INSERIMENTO, dbo.DOMANDA_PAGAMENTO_ALLEGATI.CF_INSERIMENTO, 
                         dbo.DOMANDA_PAGAMENTO_ALLEGATI.DATA_MODIFICA, dbo.DOMANDA_PAGAMENTO_ALLEGATI.CF_MODIFICA
FROM            dbo.DOMANDA_PAGAMENTO_ALLEGATI LEFT OUTER JOIN
                         dbo.ARCHIVIO_FILE ON dbo.DOMANDA_PAGAMENTO_ALLEGATI.ID_FILE = dbo.ARCHIVIO_FILE.ID LEFT OUTER JOIN
                         dbo.ENTE ON dbo.DOMANDA_PAGAMENTO_ALLEGATI.COD_ENTE_EMETTITORE = dbo.ENTE.COD_ENTE LEFT OUTER JOIN
                         dbo.COMUNI ON dbo.DOMANDA_PAGAMENTO_ALLEGATI.ID_COMUNE = dbo.COMUNI.ID_COMUNE LEFT OUTER JOIN
                         dbo.TIPO_DOCUMENTO ON dbo.DOMANDA_PAGAMENTO_ALLEGATI.COD_TIPO_DOCUMENTO = dbo.TIPO_DOCUMENTO.CODICE LEFT OUTER JOIN
                         dbo.ESITI_STEP ON dbo.DOMANDA_PAGAMENTO_ALLEGATI.COD_ESITO = dbo.ESITI_STEP.COD_ESITO LEFT OUTER JOIN
                         dbo.TIPO_ALLEGATO ON dbo.TIPO_DOCUMENTO.FORMATO = dbo.TIPO_ALLEGATO.CODICE
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
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
         Begin Table = "DOMANDA_PAGAMENTO_ALLEGATI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 263
            End
            DisplayFlags = 280
            TopColumn = 13
         End
         Begin Table = "ARCHIVIO_FILE"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 246
               Right = 216
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ENTE"
            Begin Extent = 
               Top = 126
               Left = 254
               Bottom = 246
               Right = 435
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COMUNI"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 366
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_DOCUMENTO"
            Begin Extent = 
               Top = 6
               Left = 301
               Bottom = 126
               Right = 461
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ESITI_STEP"
            Begin Extent = 
               Top = 246
               Left = 283
               Bottom = 351
               Right = 456
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_ALLEGATO"
            Begin Extent = 
               Top = 354
               Left = 283
               Bottom = 459
               Right = 443
          ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vDOMANDA_PAGAMENTO_ALLEGATI'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  End
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vDOMANDA_PAGAMENTO_ALLEGATI'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vDOMANDA_PAGAMENTO_ALLEGATI'
GO


