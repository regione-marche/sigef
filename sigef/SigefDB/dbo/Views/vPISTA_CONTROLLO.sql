

CREATE VIEW [dbo].[vPISTA_CONTROLLO]
AS
SELECT     
	b.ID_BANDO AS IdBando,
	b.DESCRIZIONE AS DescrizioneBando, 
	p.ID_PROGETTO AS IdProgetto, 
	ASSE.CODICE AS AsseCod, 
	ASSE.DESCRIZIONE AS AsseDescr, 
	AZIONE.CODICE AS AzioneCod, 
	AZIONE.DESCRIZIONE AS AzioneDescr, 
	INTERVENTO.CODICE AS InterventoCod, 
	INTERVENTO.DESCRIZIONE AS InterventoDescr, 
	i_s.RAGIONE_SOCIALE AS RagioneSociale, 
	i.CODICE_FISCALE AS PartitaIvaCF, 
	b_c_t_p.DESCRIZIONE AS TipoProcedura, 
	d_m_f.CUP_NATURA, zdim.CODICE AS CodiceTitolaritaRegia, 
	pubblicato.DATA AS DataPubblicazioneBando, 
	pubblicatoAtti.ID_ATTO AS AttoPubblicazioneBando, 
	pubblicatoAtti.NUMERO AS AttoPubblicazioneBandoNum, 
	pubblicatoAtti.DATA AS AttoPubblicazioneBandoData, 
	pubblicatoAtti.REGISTRO AS AttoPubblicazioneBandoRegistro, 
	pubblicatoAtti.NUMERO_BUR AS AttoPubblicazioneBandoBur, 
	pubblicatoAtti.DATA_BUR AS AttoPubblicazioneBandoBurData,
	DomandaAiuto.SEGNATURA AS SegnaturaDomanda, 
	DomandaAiuto.DATA AS DomandaData, 
	valutazione.SEGNATURA AS SegnaturaValutazioneComitato, 
	valutazione.DATA_MODIFICA AS DataValutazioneComitato, 
	valutazioneVariante.SEGNATURA AS SegnaturaValutazioneVarianteComitato, 
	valutazioneVariante.DATA_MODIFICA AS DataValutazioneVarianteComitato, 
	bandoDecretoGraduatoria.ID_ATTO AS AttoDecretoGraduatoria, 
	bandoDecretoGraduatoriaAtto.NUMERO AS AttoDecretoGraduatoriaNum, 
	bandoDecretoGraduatoriaAtto.DATA AS AttoDecretoGraduatoriaData, 
	bandoDecretoGraduatoriaAtto.REGISTRO AS AttoDecretoGraduatoriaRegistro, 
	bandoDecretoGraduatoriaIndividuale.ID_ATTO AS AttoDecretoGraduatoriaIndividuale, 
	bandoDecretoGraduatoriaIndividualeAtto.NUMERO AS AttoDecretoGraduatoriaIndividualeNum, 
	bandoDecretoGraduatoriaIndividualeAtto.DATA AS AttoDecretoGraduatoriaIndividualeData, 
	bandoDecretoGraduatoriaIndividualeAtto.REGISTRO AS AttoDecretoGraduatoriaIndividualeRegistro, 
	bandoGraduatoria.SEGNATURA AS SegnaturaGraduatoria, 
	bandoGraduatoria.DATA AS DataGraduatoria
FROM         dbo.BANDO AS b INNER JOIN
                      dbo.PROGETTO AS p ON p.ID_BANDO = b.ID_BANDO INNER JOIN
                      dbo.IMPRESA AS i ON i.ID_IMPRESA = p.ID_IMPRESA INNER JOIN
                      dbo.IMPRESA_STORICO AS i_s ON i.ID_STORICO_ULTIMO = i_s.ID_STORICO_IMPRESA INNER JOIN
                      dbo.BANDO_PROGRAMMAZIONE AS b_prog ON b_prog.ID_BANDO = b.ID_BANDO INNER JOIN
                      dbo.PROGETTO_STORICO AS DomandaAiuto ON DomandaAiuto.ID_PROGETTO = p.ID_PROGETTO AND DomandaAiuto.COD_STATO = 'L' INNER JOIN
                      dbo.zPROGRAMMAZIONE AS INTERVENTO ON b_prog.ID_PROGRAMMAZIONE = INTERVENTO.ID INNER JOIN
                      dbo.zPROGRAMMAZIONE AS AZIONE ON AZIONE.ID = INTERVENTO.ID_PADRE INNER JOIN
                      dbo.zPROGRAMMAZIONE AS ASSE ON ASSE.ID = AZIONE.ID_PADRE LEFT OUTER JOIN
                      dbo.zDIMENSIONI AS zdim ON zdim.COD_DIM = 'RG' AND zdim.ID IN
                          (SELECT     ID_DIMENSIONE
                            FROM          dbo.zDIMENSIONI_X_PROGRAMMAZIONE AS zd_x_p
                            WHERE      (ID_PROGRAMMAZIONE = b_prog.ID_PROGRAMMAZIONE)) LEFT OUTER JOIN
                      dbo.BANDO_CONFIG AS b_c ON b_c.ID_BANDO = b.ID_BANDO AND b_c.ATTIVO = 1 AND b_c.COD_TIPO = 'TPAPPALTO' LEFT OUTER JOIN
                      dbo.BANDO_CONFIG_TIPO_PARAMETRI AS b_c_t_p ON b_c_t_p.COD_TIPO = 'TPAPPALTO' AND b_c.VALORE = b_c_t_p.CODICE LEFT OUTER JOIN
                      dbo.DATI_MONITORAGGIO_FESR AS d_m_f ON d_m_f.ID_PROGETTO = p.ID_PROGETTO LEFT OUTER JOIN
                      dbo.BANDO_STORICO AS pubblicato ON pubblicato.ID_BANDO = b.ID_BANDO AND pubblicato.COD_STATO = 'L' LEFT OUTER JOIN
                      dbo.ATTI AS pubblicatoAtti ON pubblicatoAtti.ID_ATTO = pubblicato.ID_ATTO LEFT OUTER JOIN
                      dbo.PROGETTO_VALUTAZIONE AS valutazione ON valutazione.ID_PROGETTO = p.ID_PROGETTO AND valutazione.ID_VARIANTE IS NULL LEFT OUTER JOIN
                      dbo.PROGETTO_VALUTAZIONE AS valutazioneVariante ON valutazioneVariante.ID_PROGETTO = p.ID_PROGETTO AND valutazione.ID_VARIANTE IS NOT NULL LEFT OUTER JOIN
                      dbo.BANDO_COMUNICAZIONI AS bandoDecretoGraduatoria ON bandoDecretoGraduatoria.ID_BANDO = b.ID_BANDO AND bandoDecretoGraduatoria.COD_TIPO = 'CFI' LEFT OUTER JOIN
                      dbo.PROGETTO_STORICO AS bandoDecretoGraduatoriaIndividuale ON bandoDecretoGraduatoriaIndividuale.ID =
                          (SELECT     TOP (1) ID
                            FROM          dbo.PROGETTO_STORICO AS PS
                            WHERE      (ID_PROGETTO = p.ID_PROGETTO) AND (COD_STATO = 'F')
                            ORDER BY ID DESC) LEFT OUTER JOIN
                      dbo.BANDO_STORICO AS bandoGraduatoria ON bandoGraduatoria.ID =
                          (SELECT     TOP (1) ID
                            FROM          dbo.BANDO_STORICO AS bs
                            WHERE      (ID_BANDO = b.ID_BANDO) AND (COD_STATO = 'G')
                            ORDER BY ID DESC) LEFT OUTER JOIN
                      dbo.ATTI AS bandoDecretoGraduatoriaIndividualeAtto ON bandoDecretoGraduatoriaIndividualeAtto.ID_ATTO = bandoDecretoGraduatoriaIndividuale.ID_ATTO LEFT OUTER JOIN
                      dbo.ATTI AS bandoDecretoGraduatoriaAtto ON bandoDecretoGraduatoriaAtto.ID_ATTO = bandoDecretoGraduatoria.ID_ATTO
WHERE     (INTERVENTO.COD_TIPO LIKE 'POR20142020L%') AND (INTERVENTO.DESCRIZIONE NOT LIKE '%DA ELIMINARE%')



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
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 262
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 300
               Bottom = 126
               Right = 550
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "i"
            Begin Extent = 
               Top = 6
               Left = 588
               Bottom = 126
               Right = 842
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "i_s"
            Begin Extent = 
               Top = 6
               Left = 880
               Bottom = 126
               Right = 1118
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b_prog"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 246
               Right = 275
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DomandaAiuto"
            Begin Extent = 
               Top = 126
               Left = 313
               Bottom = 246
               Right = 539
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "INTERVENTO"
            Begin Extent = 
               Top = 126
               Left = 577
               Bottom = 246
               Right = 737
            End
            DisplayFlags = 280
            TopC', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPISTA_CONTROLLO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'olumn = 0
         End
         Begin Table = "AZIONE"
            Begin Extent = 
               Top = 126
               Left = 775
               Bottom = 246
               Right = 935
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ASSE"
            Begin Extent = 
               Top = 126
               Left = 973
               Bottom = 246
               Right = 1133
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "zdim"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 366
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b_c"
            Begin Extent = 
               Top = 246
               Left = 280
               Bottom = 366
               Right = 469
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b_c_t_p"
            Begin Extent = 
               Top = 246
               Left = 507
               Bottom = 366
               Right = 667
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d_m_f"
            Begin Extent = 
               Top = 246
               Left = 705
               Bottom = 366
               Right = 939
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pubblicato"
            Begin Extent = 
               Top = 246
               Left = 977
               Bottom = 366
               Right = 1137
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pubblicatoAtti"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 486
               Right = 281
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "valutazione"
            Begin Extent = 
               Top = 366
               Left = 319
               Bottom = 486
               Right = 492
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "valutazioneVariante"
            Begin Extent = 
               Top = 366
               Left = 530
               Bottom = 486
               Right = 703
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "bandoDecretoGraduatoria"
            Begin Extent = 
               Top = 366
               Left = 741
               Bottom = 486
               Right = 955
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "bandoDecretoGraduatoriaIndividuale"
            Begin Extent = 
               Top = 486
               Left = 38
               Bottom = 606
               Right = 264
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "bandoGraduatoria"
            Begin Extent = 
               Top = 366
               Left = 993
               Bottom = 486
               Right = 1153
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "bandoDecretoGraduatoriaIndividualeAtto"
            Begin Extent = 
               Top = 486
               Left = 302
               Bottom = 606
               Right = 545
            End
            Display', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPISTA_CONTROLLO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane3', @value = N'Flags = 280
            TopColumn = 0
         End
         Begin Table = "bandoDecretoGraduatoriaAtto"
            Begin Extent = 
               Top = 486
               Left = 583
               Bottom = 606
               Right = 826
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPISTA_CONTROLLO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 3, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vPISTA_CONTROLLO';

