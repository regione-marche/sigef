﻿CREATE VIEW dbo.vPAGAMENTI_BENEFICIARIO
AS
SELECT     dbo.PAGAMENTI_BENEFICIARIO.ID_PAGAMENTO_BENEFICIARIO, dbo.PAGAMENTI_BENEFICIARIO.ID_PAGAMENTO_RICHIESTO, dbo.PAGAMENTI_BENEFICIARIO.ID_GIUSTIFICATIVO, 
                      dbo.PAGAMENTI_BENEFICIARIO.IMPORTO_RICHIESTO, dbo.PAGAMENTI_BENEFICIARIO.IMPORTO_AMMESSO, dbo.GIUSTIFICATIVI.ID_PROGETTO, dbo.GIUSTIFICATIVI.NUMERO, 
                      dbo.GIUSTIFICATIVI.COD_TIPO, dbo.GIUSTIFICATIVI.DATA, dbo.GIUSTIFICATIVI.NUMERO_DOCTRASPORTO, dbo.GIUSTIFICATIVI.DATA_DOCTRASPORTO, dbo.GIUSTIFICATIVI.IMPONIBILE, 
                      dbo.GIUSTIFICATIVI.IVA, dbo.GIUSTIFICATIVI.ALTRI_ONERI, dbo.GIUSTIFICATIVI.DESCRIZIONE, dbo.GIUSTIFICATIVI.CF_FORNITORE, dbo.GIUSTIFICATIVI.DESCRIZIONE_FORNITORE, 
                      dbo.TIPO_GIUSTIFICATIVO.DESCRIZIONE AS TIPO_GIUSTIFICATIVO, dbo.PAGAMENTI_BENEFICIARIO.SPESA_TECNICA_RICHIESTA, dbo.PAGAMENTI_BENEFICIARIO.SPESA_TECNICA_AMMESSA, 
                      dbo.GIUSTIFICATIVI.IVA_NON_RECUPERABILE, dbo.PAGAMENTI_BENEFICIARIO.IMPORTO_NONAMM_NONRESP, dbo.PAGAMENTI_BENEFICIARIO.IMPORTO_AMMESSO_CONTR, 
                      dbo.PAGAMENTI_BENEFICIARIO.IMPORTO_NONAMM_CONTR_NONRESP, dbo.PAGAMENTI_BENEFICIARIO.SPESA_TECNICA_AMMESSA_CONTR, 
                      dbo.PAGAMENTI_BENEFICIARIO.COSTITUISCE_VARIANTE, dbo.TIPO_GIUSTIFICATIVO.LAVORI_IN_ECONOMIA, dbo.PAGAMENTI_BENEFICIARIO.COD_RIDUZIONE, 
                      dbo.PAGAMENTI_BENEFICIARIO.MOTIVAZIONE_RIDUZIONE, dbo.PAGAMENTI_BENEFICIARIO.COD_RIDUZIONE_CONTR, dbo.PAGAMENTI_BENEFICIARIO.MOTIVAZIONE_RIDUZIONE_CONTR, 
                      dbo.GIUSTIFICATIVI.ID_FILE, dbo.PAGAMENTI_BENEFICIARIO.CONTRIBUTO_AMMESSO, dbo.PAGAMENTI_BENEFICIARIO.QUOTA_CONTRIBUTO_AMMESSO
FROM         dbo.PAGAMENTI_BENEFICIARIO INNER JOIN
                      dbo.GIUSTIFICATIVI ON dbo.PAGAMENTI_BENEFICIARIO.ID_GIUSTIFICATIVO = dbo.GIUSTIFICATIVI.ID_GIUSTIFICATIVO INNER JOIN
                      dbo.TIPO_GIUSTIFICATIVO ON dbo.GIUSTIFICATIVI.COD_TIPO = dbo.TIPO_GIUSTIFICATIVO.COD_TIPO

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
         Begin Table = "PAGAMENTI_BENEFICIARIO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 292
               Right = 275
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "GIUSTIFICATIVI"
            Begin Extent = 
               Top = 6
               Left = 371
               Bottom = 286
               Right = 584
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "TIPO_GIUSTIFICATIVO"
            Begin Extent = 
               Top = 20
               Left = 692
               Bottom = 128
               Right = 851
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPAGAMENTI_BENEFICIARIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPAGAMENTI_BENEFICIARIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPAGAMENTI_BENEFICIARIO';

