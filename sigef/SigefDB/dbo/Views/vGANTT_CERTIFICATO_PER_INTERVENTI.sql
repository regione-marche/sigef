

CREATE VIEW [dbo].[vGANTT_CERTIFICATO_PER_INTERVENTI]
AS
WITH INTERVENTI AS
(
SELECT  ASSE.ID ID_ASSE,
        ASSE.CODICE COD_ASSE,
        ASSE.DESCRIZIONE DESC_ASSE,
        AZIONE.ID ID_AZIONE,
        AZIONE.CODICE COD_AZIONE,
        AZIONE.DESCRIZIONE DESC_AZIONE,
        IP.ID ID_INTERVENTO,
        IP.CODICE COD_INTERVENTO,
        IP.DESCRIZIONE DESC_INTERVENTO
FROM    zPROGRAMMAZIONE IP
        INNER JOIN 
        zPROGRAMMAZIONE AZIONE ON AZIONE.ID = IP.ID_PADRE
        INNER JOIN 
        zPROGRAMMAZIONE ASSE ON ASSE.ID = AZIONE.ID_PADRE
WHERE 1 = 1
  AND IP.COD_TIPO = 'POR20142020L3'
  AND IP.ID NOT IN (17,18,19)
--ORDER BY ASSE.CODICE, AZIONE.CODICE, IP.CODICE
)

,CERTIFICAZIONE as (
SELECT ti.id,
       2017                                        AS Anno,
       SUM(valore) AS Concesso
FROM 
    (SELECT  
            Id_progetto,
            SUM(ImportoContributoPubblico_Incrementale) AS valore
    FROM CertSp_Dettaglio
    WHERE IdCertSp IN (2, 3)
      AND Selezionata = 'TRUE'
    GROUP BY Id_Progetto) AS d
     INNER JOIN
     vProgetto prt ON d.Id_Progetto = prt.Id_Progetto
     LEFT JOIN
        vBando_Programmazione bprm ON prt.Id_Bando = bprm.Id_Bando
                                  AND Id_Programmazione NOT IN (17, 18, 19)
        INNER JOIN
        zProgrammazione ti ON bprm.Id_Programmazione = ti.id
        INNER JOIN
        zProgrammazione azione ON ti.Id_Padre = azione.Id
        INNER JOIN
        zProgrammazione asse ON azione.Id_Padre = asse.Id

GROUP BY ti.id) 

,QUIETANZA as (
SELECT ti.id,
       
       SUM(valore) AS IMPORTOQUIETANZA
FROM 
		(SELECT 
			p.ID_BANDO,
			SUM (dpl.QUIETANZA_IMPORTO) as valore
		FROM PROGETTO p
		inner join DOMANDA_DI_PAGAMENTO ddp on ddp.ID_PROGETTO = p.ID_PROGETTO
		inner join DOMANDA_PAGAMENTO_LIQUIDAZIONE dpl on dpl.ID_DOMANDA_PAGAMENTO = ddp.ID_DOMANDA_PAGAMENTO and dpl.QUIETANZA_IMPORTO is not null
		GROUP BY p.ID_BANDO  ) AS d

     LEFT JOIN
        vBando_Programmazione bprm ON d.ID_BANDO = bprm.Id_Bando
                                  AND Id_Programmazione NOT IN (17, 18, 19)
        INNER JOIN
        zProgrammazione ti ON bprm.Id_Programmazione = ti.id
        INNER JOIN
        zProgrammazione azione ON ti.Id_Padre = azione.Id
        INNER JOIN
        zProgrammazione asse ON azione.Id_Padre = asse.Id

GROUP BY ti.id)

select 
i.ID_ASSE,
i.COD_ASSE,
i.DESC_ASSE,
i.ID_AZIONE, 
i.COD_AZIONE,
i.DESC_AZIONE,
i.ID_INTERVENTO ,
i.COD_INTERVENTO,
i.DESC_INTERVENTO, 
SUM(bi.IMPORTO) as ImportoIntervento,
q.IMPORTOQUIETANZA as ImportoQuietanzaSigef,
c.Concesso as importoCertificato


from 
vBANDO  
inner join BANDO_PROGRAMMAZIONE bp on bp.ID_BANDO = vBANDO.ID_BANDO
inner join INTERVENTI i on i.ID_INTERVENTO = bp.ID_PROGRAMMAZIONE
inner join BANDO_INTEGRAZIONI bi on bi.ID = vBANDO.ID_INTEGRAZIONE_ULTIMA
left outer join CERTIFICAZIONE c on i.ID_INTERVENTO = c.ID 
left outer join QUIETANZA q on i.ID_INTERVENTO = q.ID 

where vBANDO.COD_STATO != 'P'
GROUP BY i.ID_ASSE, i.COD_ASSE,i.DESC_ASSE,i.ID_AZIONE, i.COD_AZIONE,i.DESC_AZIONE,i.ID_INTERVENTO ,i.COD_INTERVENTO,i.DESC_INTERVENTO,q.IMPORTOQUIETANZA,c.Concesso



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
         Begin Table = "vBANDO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 278
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "bp"
            Begin Extent = 
               Top = 6
               Left = 316
               Bottom = 126
               Right = 569
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "i"
            Begin Extent = 
               Top = 6
               Left = 607
               Bottom = 126
               Right = 807
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "bi"
            Begin Extent = 
               Top = 6
               Left = 845
               Bottom = 126
               Right = 1059
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 231
               Right = 214
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
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Ou', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vGANTT_CERTIFICATO_PER_INTERVENTI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'tput = 720
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vGANTT_CERTIFICATO_PER_INTERVENTI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vGANTT_CERTIFICATO_PER_INTERVENTI';

