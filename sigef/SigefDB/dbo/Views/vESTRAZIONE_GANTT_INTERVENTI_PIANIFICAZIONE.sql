
/*order by ID_BANDO_GANTT*/
CREATE VIEW [dbo].[vESTRAZIONE_GANTT_INTERVENTI_PIANIFICAZIONE]
AS
WITH INTERVENTI AS (SELECT     ASSE.ID AS ID_ASSE, ASSE.CODICE AS COD_ASSE, ASSE.DESCRIZIONE AS DESC_ASSE, AZIONE.ID AS ID_AZIONE, AZIONE.CODICE AS COD_AZIONE, 
                                                                        AZIONE.DESCRIZIONE AS DESC_AZIONE, IP.ID AS ID_INTERVENTO, IP.CODICE AS COD_INTERVENTO, IP.DESCRIZIONE AS DESC_INTERVENTO, IP.IMPORTO_DOTAZIONE  as IMPORTO_DOTAZIONE
                                                 FROM          dbo.zPROGRAMMAZIONE AS IP INNER JOIN
                                                                        dbo.zPROGRAMMAZIONE AS AZIONE ON AZIONE.ID = IP.ID_PADRE INNER JOIN
                                                                        dbo.zPROGRAMMAZIONE AS ASSE ON ASSE.ID = AZIONE.ID_PADRE
                                                 WHERE      (IP.COD_TIPO = 'POR20142020L3') AND (IP.ID NOT IN (17, 18, 19)))
    SELECT     G.ID_GANTT, TGT.NOME_TIPOOP AS TIPO_OPERAZIONE, CASE WHEN UO.TIPO = 'Serv' THEN 'Servizio' ELSE UO.TIPO END AS TIPO_UO, dbo.UO.NOME AS DENOMINAZIONE_UO, 
                            GB.ID_BANDO_GANTT, GB.OGGETTO, GB.IMPORTO, GB.IMPORTO_PREVISTO, GB.IMPORTO_FINANZIATO, GB.IMPORTO_CERTIFICATO, INTERVENTI_1.IMPORTO_DOTAZIONE, INTERVENTI_1.COD_ASSE, 
                            INTERVENTI_1.DESC_ASSE, INTERVENTI_1.COD_AZIONE, INTERVENTI_1.DESC_AZIONE, INTERVENTI_1.COD_INTERVENTO, INTERVENTI_1.DESC_INTERVENTO
     FROM         dbo.GANTT_BANDO AS GB INNER JOIN
                            dbo.GANTT_UO_PROGRAMMAZIONE AS GUP ON GB.ID_PROGRAMMAZIONE = GUP.ID_PROGRAMMAZIONE INNER JOIN
                            INTERVENTI AS INTERVENTI_1 ON GUP.ID_PROGRAMMAZIONE = INTERVENTI_1.ID_INTERVENTO INNER JOIN
                            dbo.GANTT AS G ON G.ID_BANDO = GB.ID_BANDO_GANTT INNER JOIN
                            dbo.UO ON G.ID_UO = dbo.UO.ID_UO INNER JOIN
                            dbo.TIPO_GANTT_TIPIOPERAZIONE AS TGT ON G.ID_TIPOOP = TGT.ID_TIPOOP


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
         Begin Table = "GB"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 248
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "GUP"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 246
               Right = 300
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "G"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 366
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "UO"
            Begin Extent = 
               Top = 246
               Left = 236
               Bottom = 366
               Right = 425
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TGT"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 456
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "INTERVENTI_1"
            Begin Extent = 
               Top = 6
               Left = 286
               Bottom = 126
               Right = 470
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
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vESTRAZIONE_GANTT_INTERVENTI_PIANIFICAZIONE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'      Width = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vESTRAZIONE_GANTT_INTERVENTI_PIANIFICAZIONE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vESTRAZIONE_GANTT_INTERVENTI_PIANIFICAZIONE';

