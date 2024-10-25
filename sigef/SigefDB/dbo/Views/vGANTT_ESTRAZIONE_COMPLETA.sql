


CREATE VIEW [dbo].[vGANTT_ESTRAZIONE_COMPLETA]
AS
WITH INTERVENTI AS (SELECT     ASSE.ID AS ID_ASSE, ASSE.CODICE AS COD_ASSE, ASSE.DESCRIZIONE AS DESCRIZIONE_ASSE, AZIONE.ID AS ID_AZIONE, AZIONE.CODICE AS COD_AZIONE, 
                                                                        AZIONE.DESCRIZIONE AS DESCRIZIONE_AZIONE, intervento.ID AS ID_INTERVENTO, intervento.CODICE AS COD_INTERVENTO, 
                                                                        intervento.DESCRIZIONE AS DESCRIZIONE_INTERVENTO, intervento.IMPORTO_DOTAZIONE as IMPORTO_DOTAZIONE
                                                 FROM          dbo.zPROGRAMMAZIONE AS intervento INNER JOIN
                                                                        dbo.zPROGRAMMAZIONE AS AZIONE ON AZIONE.ID = intervento.ID_PADRE INNER JOIN
                                                                        dbo.zPROGRAMMAZIONE AS ASSE ON ASSE.ID = AZIONE.ID_PADRE
                                                 WHERE      (1 = 1) AND (intervento.COD_TIPO = 'POR20142020L3') AND (intervento.ID NOT IN (17, 18, 19)))
    SELECT     TOP (100) PERCENT INTERVENTI_1.COD_ASSE AS ASSE, INTERVENTI_1.DESCRIZIONE_ASSE, INTERVENTI_1.COD_AZIONE AS AZIONE, INTERVENTI_1.DESCRIZIONE_AZIONE, 
                            INTERVENTI_1.COD_INTERVENTO AS INTERVENTO, INTERVENTI_1.DESCRIZIONE_INTERVENTO, dbo.UO.TIPO, dbo.UO.ID_UO, dbo.UO.NOME AS UO, dbo.GANTT_BANDO.OGGETTO, 
                            dbo.GANTT_BANDO.IMPORTO AS IMPORTO_FESR, dbo.GANTT_BANDO.IMPORTO_PREVISTO, dbo.GANTT_BANDO.IMPORTO_FINANZIATO, dbo.GANTT_BANDO.IMPORTO_CERTIFICATO, 
                            dbo.TIPO_GANTT_TIPIOPERAZIONE.NOME_TIPOOP AS OPERAZIONE, dbo.TIPO_GANTT_PASSI.DESCRIZIONE AS PASSO, UO_RIFERIMENTO.NOME AS UO_DI_RIFERIMENTO, 
                            dbo.GANTT_STEPS.NUM_GG_STANDARD AS GIORNATE_STANDAR, dbo.GANTT_STEPS.DATA_INIZIO_PREVISTA, dbo.GANTT_STEPS.DATA_INIZIO_EFFETTIVA, 
                            dbo.GANTT_STEPS.DATA_FINE_PREVISTA, dbo.GANTT_STEPS.DATA_FINE_EFFETTIVA, dbo.GANTT_STEPS.VALORE_PREVISTO, dbo.GANTT_STEPS.VALORE_EFFETTIVO, 
                            dbo.GANTT_STEPS.NOTA_PREVISTO, dbo.GANTT_STEPS.NOTA, INTERVENTI_1.IMPORTO_DOTAZIONE, zPROGRAMMAZIONE_TARGET.IMPORTO_TARGET
     FROM
							INTERVENTI AS INTERVENTI_1 inner join 
							zPROGRAMMAZIONE_TARGET on INTERVENTI_1.ID_ASSE=zPROGRAMMAZIONE_TARGET.ID_PROGRAMMAZIONE LEFT OUTER JOIN
                            dbo.GANTT_BANDO ON dbo.GANTT_BANDO.ID_PROGRAMMAZIONE = INTERVENTI_1.ID_INTERVENTO LEFT OUTER JOIN
                            dbo.GANTT ON dbo.GANTT.ID_BANDO = dbo.GANTT_BANDO.ID_BANDO_GANTT LEFT OUTER JOIN
                            dbo.UO ON dbo.UO.ID_UO = dbo.GANTT.ID_UO LEFT OUTER JOIN
                            dbo.GANTT_STEPS ON dbo.GANTT_STEPS.ID_GNATT = dbo.GANTT.ID_GANTT LEFT OUTER JOIN
                            dbo.TIPO_GANTT_TIPIOPERAZIONE ON dbo.TIPO_GANTT_TIPIOPERAZIONE.ID_TIPOOP = dbo.GANTT.ID_TIPOOP LEFT OUTER JOIN
                            dbo.TIPO_GANTT_PASSI ON dbo.GANTT_STEPS.ID_TIPO_PASSO = dbo.TIPO_GANTT_PASSI.ID_PASSO LEFT OUTER JOIN
                            dbo.UO AS UO_RIFERIMENTO ON UO_RIFERIMENTO.ID_UO = dbo.GANTT_STEPS.UO_PASSO LEFT OUTER JOIN
                            dbo.GANTT_UO_PROGRAMMAZIONE ON dbo.GANTT_BANDO.ID_PROGRAMMAZIONE = dbo.GANTT_UO_PROGRAMMAZIONE.ID_PROGRAMMAZIONE 
	where zPROGRAMMAZIONE_TARGET.ANNO = 2018							
     ORDER BY ASSE, AZIONE, INTERVENTO, UO, dbo.GANTT_STEPS.DATA_INIZIO_PREVISTA




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
         Begin Table = "INTERVENTI_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 264
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GANTT_BANDO"
            Begin Extent = 
               Top = 6
               Left = 302
               Bottom = 126
               Right = 512
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GANTT"
            Begin Extent = 
               Top = 6
               Left = 550
               Bottom = 126
               Right = 745
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UO"
            Begin Extent = 
               Top = 6
               Left = 783
               Bottom = 126
               Right = 972
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GANTT_STEPS"
            Begin Extent = 
               Top = 6
               Left = 1010
               Bottom = 126
               Right = 1224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_GANTT_TIPIOPERAZIONE"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 216
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_GANTT_PASSI"
            Begin Extent = 
               Top = 126
               Left = 238
               Bottom = 246
               Right = 442
            End
 ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vGANTT_ESTRAZIONE_COMPLETA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'           DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UO_RIFERIMENTO"
            Begin Extent = 
               Top = 126
               Left = 480
               Bottom = 246
               Right = 669
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GANTT_UO_PROGRAMMAZIONE"
            Begin Extent = 
               Top = 126
               Left = 707
               Bottom = 246
               Right = 969
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vGANTT_ESTRAZIONE_COMPLETA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vGANTT_ESTRAZIONE_COMPLETA';

