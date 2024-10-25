CREATE VIEW dbo.VINTEGRAZIONE_SINGOLA_DI_DOMANDA
AS
SELECT     SING.ID_SINGOLA_INTEGRAZIONE, SING.ID_INTEGRAZIONE_DOMANDA, SING.COD_TIPO_INTEGRAZIONE, SING.DATA_INSERIMENTO, SING.DATA_MODIFICA, 
                      SING.CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, SING.NOTE_INTEGRAZIONE_ISTRUTTORE, SING.DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, SING.DATA_CONCLUSIONE_ISTRUTTORE, 
                      SING.SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, SING.CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, SING.NOTE_INTEGRAZIONE_BENEFICIARIO, 
                      SING.DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, SING.DATA_CONCLUSIONE_BENEFICIARIO, SING.SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, 
                      INTEG.ID_DOMANDA_PAGAMENTO, INTEG.DATA_INSERIMENTO AS DATA_INSERIMENTO_INTEGRAZIONE, INTEG.DATA_MODIFICA AS DATA_MODIFICA_INTEGRAZIONE, 
                      INTEG.ISTANZA_DOMANDA_PAGAMENTO, INTEG.INTEGRAZIONE_COMPLETA, INTEG.NOTE_INTEGRAZIONE_DOMANDA, INTEG.CF_ISTRUTTORE, 
                      INTEG.DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, INTEG.SEGNATURA_ISTRUTTORE, INTEG.CF_BENFICIARIO, INTEG.SEGNATURA_BENEFICIARIO, INTEG.DATA_CONCLUSIONE_INTEGRAZIONE, 
                      dbo.TIPO_INTEGRAZIONE_DOMANDA.DESCRIZIONE AS DESCRIZIONE_TIPO_INTEGRAZIONE, SING.ID_SPESA, SING.ID_GIUSTIFICATIVO
FROM         dbo.INTEGRAZIONE_SINGOLA_DI_DOMANDA AS SING INNER JOIN
                      dbo.INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO AS INTEG ON SING.ID_INTEGRAZIONE_DOMANDA = INTEG.ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO INNER JOIN
                      dbo.TIPO_INTEGRAZIONE_DOMANDA ON SING.COD_TIPO_INTEGRAZIONE = dbo.TIPO_INTEGRAZIONE_DOMANDA.COD_TIPO

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
         Begin Table = "SING"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 296
               Right = 402
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "INTEG"
            Begin Extent = 
               Top = 14
               Left = 679
               Bottom = 270
               Right = 1002
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_INTEGRAZIONE_DOMANDA"
            Begin Extent = 
               Top = 154
               Left = 444
               Bottom = 253
               Right = 642
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
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2955
         Alias = 3150
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VINTEGRAZIONE_SINGOLA_DI_DOMANDA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'VINTEGRAZIONE_SINGOLA_DI_DOMANDA';

