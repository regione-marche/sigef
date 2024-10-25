CREATE VIEW [dbo].[vPARECIPANTI_INDIRETTI_FATTURATO]
AS
SELECT     dbo.PARTECIPANTI_INDIRETTI_FATTURATO.ID, dbo.PARTECIPANTI_INDIRETTI_FATTURATO.CUAA_PROMOTORE, 
                      dbo.PARTECIPANTI_INDIRETTI_FATTURATO.ID_IMPRESA, dbo.PARTECIPANTI_INDIRETTI_FATTURATO.CUAA, 
                      dbo.PARTECIPANTI_INDIRETTI_FATTURATO.COD_PRODOTTO, dbo.PARTECIPANTI_INDIRETTI_FATTURATO.COD_VARIETA, 
                      dbo.PARTECIPANTI_INDIRETTI_FATTURATO.PRODUZIONE_TOTALE, dbo.PARTECIPANTI_INDIRETTI_FATTURATO.PREZZO_MEDIO, 
                      dbo.PARTECIPANTI_INDIRETTI_FATTURATO.FATTURATO, dbo.VARIETA.DESCRIZIONE AS VARIETA, dbo.PRODOTTO.DESCRIZIONE AS PRODOTTO, 
                      dbo.vIMPRESA.CODICE_FISCALE, dbo.vIMPRESA.RAGIONE_SOCIALE, dbo.vIMPRESA.COD_FORMA_GIURIDICA, dbo.vIMPRESA.ID_DIMENSIONE, 
                      dbo.vIMPRESA.DIMENSIONE_IMPRESA, dbo.vIMPRESA.FORMA_GIURIDICA, dbo.PARTECIPANTI_INDIRETTI_FATTURATO.ID_CLASSE_ALLEVAMENTO, 
                      dbo.PARTECIPANTI_INDIRETTI_FATTURATO.ID_ATTIVITA_CONNESSA, dbo.PARTECIPANTI_INDIRETTI_FATTURATO.CUAA_TRASFORMATORE, 
                      dbo.CLASSIFICAZIONE_ALLEVAMENTI.DESCRIZIONE, dbo.CLASSIFICAZIONE_ALLEVAMENTI.PREZZO_UNITARIO, 
                      dbo.ATTIVITA_CONNESSE.DESCRIZIONE AS ATTIVITA_CONNESSE, dbo.ATTIVITA_CONNESSE.PREZZO_UNITARIO AS PREZZO_ATTIVITA, 
                      dbo.PARTECIPANTI_INDIRETTI_FATTURATO.PRODUZIONE_IN_FILIERA, dbo.PARTECIPANTI_INDIRETTI_FATTURATO.NUMERO_CAPI
FROM         dbo.vIMPRESA INNER JOIN
                      dbo.PARTECIPANTI_INDIRETTI_FATTURATO ON dbo.vIMPRESA.ID_IMPRESA = dbo.PARTECIPANTI_INDIRETTI_FATTURATO.ID_IMPRESA LEFT OUTER JOIN
                      dbo.CLASSIFICAZIONE_ALLEVAMENTI ON 
                      dbo.PARTECIPANTI_INDIRETTI_FATTURATO.ID_CLASSE_ALLEVAMENTO = dbo.CLASSIFICAZIONE_ALLEVAMENTI.ID_CLASSE LEFT OUTER JOIN
                      dbo.ATTIVITA_CONNESSE ON dbo.PARTECIPANTI_INDIRETTI_FATTURATO.ID_ATTIVITA_CONNESSA = dbo.ATTIVITA_CONNESSE.ID_ATTIVITA LEFT OUTER JOIN
                      dbo.PRODOTTO INNER JOIN
                      dbo.VARIETA ON dbo.PRODOTTO.COD_PRODOTTO = dbo.VARIETA.COD_PRODOTTO ON 
                      dbo.PARTECIPANTI_INDIRETTI_FATTURATO.COD_VARIETA = dbo.VARIETA.COD_VARIETA AND 
                      dbo.PARTECIPANTI_INDIRETTI_FATTURATO.COD_PRODOTTO = dbo.VARIETA.COD_PRODOTTO

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
         Begin Table = "vIMPRESA"
            Begin Extent = 
               Top = 174
               Left = 366
               Bottom = 339
               Right = 611
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "PARTECIPANTI_INDIRETTI_FATTURATO"
            Begin Extent = 
               Top = 13
               Left = 89
               Bottom = 257
               Right = 280
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "CLASSIFICAZIONE_ALLEVAMENTI"
            Begin Extent = 
               Top = 258
               Left = 38
               Bottom = 366
               Right = 290
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ATTIVITA_CONNESSE"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 474
               Right = 278
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PRODOTTO"
            Begin Extent = 
               Top = 24
               Left = 621
               Bottom = 132
               Right = 873
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VARIETA"
            Begin Extent = 
               Top = 25
               Left = 360
               Bottom = 118
               Right = 532
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
         Width', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPARECIPANTI_INDIRETTI_FATTURATO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' = 284
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPARECIPANTI_INDIRETTI_FATTURATO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPARECIPANTI_INDIRETTI_FATTURATO';

