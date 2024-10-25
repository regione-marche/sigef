CREATE VIEW [dbo].[vVARIANTI]
AS
SELECT     dbo.VARIANTI.ID_VARIANTE, dbo.VARIANTI.ID_PROGETTO, dbo.VARIANTI.COD_TIPO, dbo.VARIANTI.DATA_INSERIMENTO, dbo.VARIANTI.COD_ENTE, 
                      dbo.VARIANTI.OPERATORE, dbo.VARIANTI.DATA_MODIFICA, dbo.VARIANTI.SEGNATURA, dbo.VARIANTI.SEGNATURA_ALLEGATI, 
                      dbo.VARIANTI.SEGNATURA_APPROVAZIONE, dbo.VARIANTI.APPROVATA, dbo.VARIANTI.ISTRUTTORE, dbo.VARIANTI.NOTE_ISTRUTTORE, 
                      dbo.TIPO_VARIANTE.DESCRIZIONE AS TIPO_VARIANTE, dbo.vUTENTI.NOMINATIVO, dbo.vUTENTI.PROFILO, dbo.vUTENTI.ENTE, dbo.VARIANTI.DATA_APPROVAZIONE, 
                      dbo.vUTENTI.PROVINCIA, dbo.VARIANTI.DESCRIZIONE, dbo.VARIANTI.ANNULLATA, dbo.VARIANTI.SEGNATURA_ANNULLAMENTO, 
                      dbo.VARIANTI.CF_OPERATORE_ANNULLAMENTO, dbo.VARIANTI.DATA_ANNULLAMENTO, vUTENTI_1.NOMINATIVO AS NOMINATIVO_OPERATORE_ANNULLAMENTO, 
                      UTENTI_1.NOMINATIVO AS NOMINATIVO_ISTRUTTORE, dbo.VARIANTI.CUAA_ENTRANTE, dbo.VARIANTI.ID_FASCICOLO_ENTRANTE, dbo.VARIANTI.CUAA_USCENTE, 
                      dbo.VARIANTI.ID_FASCICOLO_USCENTE, dbo.VARIANTI.RAGSOC_USCENTE, dbo.VARIANTI.ID_ATTO_APPROVAZIONE, dbo.ATTI.AW_DOCNUMBER, 
                      dbo.ATTI.COD_DEFINIZIONE, dbo.ATTI.AW_DOCNUMBER_NUOVO
FROM         dbo.VARIANTI INNER JOIN
                      dbo.TIPO_VARIANTE ON dbo.VARIANTI.COD_TIPO = dbo.TIPO_VARIANTE.COD_TIPO INNER JOIN
                      dbo.vUTENTI ON dbo.VARIANTI.OPERATORE = dbo.vUTENTI.CF_UTENTE LEFT OUTER JOIN
                      dbo.ATTI ON dbo.VARIANTI.ID_ATTO_APPROVAZIONE = dbo.ATTI.ID_ATTO LEFT OUTER JOIN
                      dbo.vUTENTI AS vUTENTI_1 ON dbo.VARIANTI.CF_OPERATORE_ANNULLAMENTO = vUTENTI_1.CF_UTENTE LEFT OUTER JOIN
                      dbo.vUTENTI AS UTENTI_1 ON dbo.VARIANTI.ISTRUTTORE = UTENTI_1.CF_UTENTE

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
         Begin Table = "VARIANTI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 321
               Right = 262
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TIPO_VARIANTE"
            Begin Extent = 
               Top = 6
               Left = 300
               Bottom = 110
               Right = 476
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vUTENTI"
            Begin Extent = 
               Top = 26
               Left = 520
               Bottom = 297
               Right = 756
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ATTI"
            Begin Extent = 
               Top = 324
               Left = 40
               Bottom = 444
               Right = 284
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "vUTENTI_1"
            Begin Extent = 
               Top = 6
               Left = 794
               Bottom = 295
               Right = 1030
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UTENTI_1"
            Begin Extent = 
               Top = 444
               Left = 40
               Bottom = 564
               Right = 237
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
      Begin ColumnWidths = 24
         Width = 284
         Width = 1497
         Width = 1497
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vVARIANTI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
         Width = 1497
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 898
         Table = 1169
         Output = 727
         Append = 1400
         NewValue = 1170
         SortType = 1354
         SortOrder = 1411
         GroupBy = 1350
         Filter = 1354
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vVARIANTI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vVARIANTI';

