CREATE PROCEDURE [dbo].[RptRAEAnagrafeAziende]
AS

SELECT   P.ID_PROGETTO AS NUMERO_DOMANDA, B.ID_BANDO, B.DATA_SCADENZA, P.STATO, I.CUAA, I.CODICE_FISCALE AS PARTITA_IVA, I.RAGIONE_SOCIALE, 
                PXP.VALORE_DESC AS FILIERA, I.FORMA_GIURIDICA, I.DIMENSIONE_IMPRESA, PXI.NOME, PXI.COGNOME, PXI.COMUNE AS COMUNE_NASCITA, PXI.SIGLA AS PROV_NASCITA, 
                PXI.CAP AS CAP_NASCITA, PXI.DATA_NASCITA, I.COD_FORMA_GIURIDICA, F.UBA, IND.VIA, IND.COMUNE, IND.CAP, IND.SIGLA, IND.TELEFONO, IND.EMAIL, IND.PEC,
                IND.TIPO_AREA,
                    (SELECT   SUM(vCATASTO.SUPERFICIE_CATASTALE) AS Expr1
                     FROM      (SELECT DISTINCT ID_CATASTO
                                      FROM      TERRITORIO
                                      WHERE   (ID_FASCICOLO = P.ID_FASCICOLO)) AS terr INNER JOIN
                                     vCATASTO ON vCATASTO.ID_CATASTO = terr.ID_CATASTO
                     WHERE   (vCATASTO.ID_CATASTO IS NOT NULL) AND (vCATASTO.SVANTAGGIO IS NULL)) AS vantaggio,
                    (SELECT   SUM(vCATASTO_2.SUPERFICIE_CATASTALE) AS Expr1
                     FROM      (SELECT DISTINCT ID_CATASTO
                                      FROM      TERRITORIO AS TERRITORIO_2
                                      WHERE   (ID_FASCICOLO = P.ID_FASCICOLO)) AS terr_7 INNER JOIN
                                     vCATASTO AS vCATASTO_2 ON vCATASTO_2.ID_CATASTO = terr_7.ID_CATASTO
                     WHERE   (vCATASTO_2.ID_CATASTO IS NOT NULL) AND (vCATASTO_2.SVANTAGGIO = 'MONTAGNA par. 3.3')) AS MONTAGNA,
                    (SELECT   SUM(vCATASTO_1.SUPERFICIE_CATASTALE) AS Expr1
                     FROM      (SELECT DISTINCT ID_CATASTO
                                      FROM      TERRITORIO AS TERRITORIO_1
                                      WHERE   (ID_FASCICOLO = P.ID_FASCICOLO)) AS terr_6 INNER JOIN
                                     vCATASTO AS vCATASTO_1 ON vCATASTO_1.ID_CATASTO = terr_6.ID_CATASTO
                     WHERE   (vCATASTO_1.ID_CATASTO IS NOT NULL) AND (vCATASTO_1.SVANTAGGIO = 'ORDINARIO par. 3.4')) AS ORDINARIO,
                    (SELECT   SUM(SUPERFICIE_CATASTALE) AS Superficie
                     FROM      (SELECT DISTINCT ID_CATASTO, TIPO_AREA, SUPERFICIE_CATASTALE
                                      FROM      vTERRITORIO
                                      WHERE   (ID_FASCICOLO = P.ID_FASCICOLO)) AS Terr_5
                     WHERE   (TIPO_AREA = 'C1')) AS SUP_TIPO_AREA_C1,
                    (SELECT   SUM(SUPERFICIE_CATASTALE) AS Superficie
                     FROM      (SELECT DISTINCT ID_CATASTO, TIPO_AREA, SUPERFICIE_CATASTALE
                                      FROM      vTERRITORIO AS vTERRITORIO_4
                                      WHERE   (ID_FASCICOLO = P.ID_FASCICOLO)) AS Terr_4
                     WHERE   (TIPO_AREA = 'C2')) AS SUP_TIPO_AREA_C2,
                    (SELECT   SUM(SUPERFICIE_CATASTALE) AS Superficie
                     FROM      (SELECT DISTINCT ID_CATASTO, TIPO_AREA, SUPERFICIE_CATASTALE
                                      FROM      vTERRITORIO AS vTERRITORIO_3
                                      WHERE   (ID_FASCICOLO = P.ID_FASCICOLO)) AS Terr_3
                     WHERE   (TIPO_AREA = 'C3')) AS SUP_TIPO_AREA_C3,
                    (SELECT   SUM(SUPERFICIE_CATASTALE) AS Superficie
                     FROM      (SELECT DISTINCT ID_CATASTO, TIPO_AREA, SUPERFICIE_CATASTALE
                                      FROM      vTERRITORIO AS vTERRITORIO_2
                                      WHERE   (ID_FASCICOLO = P.ID_FASCICOLO)) AS Terr_2
                     WHERE   (TIPO_AREA = 'A')) AS SUP_TIPO_AREA_A,
                    (SELECT   SUM(SUPERFICIE_CATASTALE) AS Superficie
                     FROM      (SELECT DISTINCT ID_CATASTO, TIPO_AREA, SUPERFICIE_CATASTALE
                                      FROM      vTERRITORIO AS vTERRITORIO_1
                                      WHERE   (ID_FASCICOLO = P.ID_FASCICOLO)) AS Terr_1
                     WHERE   (TIPO_AREA = 'D')) AS SUP_TIPO_AREA_D,
                    (SELECT   SUM(ISNULL(SUPERFICIE_CONDOTTA, 0)) AS SUP
                     FROM      TERRITORIO AS T
                     WHERE   (COD_TIPO_CONDUZIONE = 1) AND (ID_FASCICOLO = P.ID_FASCICOLO)
                     GROUP BY COD_TIPO_CONDUZIONE) AS SUP_CONDOTTA_PROPRIETA,
                    (SELECT   SUM(ISNULL(SUPERFICIE_CONDOTTA, 0)) AS SUP
                     FROM      TERRITORIO AS T
                     WHERE   (COD_TIPO_CONDUZIONE = 2) AND (ID_FASCICOLO = P.ID_FASCICOLO)
                     GROUP BY COD_TIPO_CONDUZIONE) AS SUP_CONDOTTA_AFFITTO,
                    (SELECT   dbo.OTE_PLV(P.ID_PROGETTO, NULL) AS Expr1) AS OTE, PXI.SESSO
FROM      vPROGETTO AS P INNER JOIN
                VBANDO AS B ON P.ID_BANDO = B.ID_BANDO INNER JOIN
                vIMPRESA AS I ON I.ID_IMPRESA = P.ID_IMPRESA INNER JOIN
                vPERSONE_X_IMPRESE AS PXI ON PXI.ID_PERSONE_X_IMPRESE = I.ID_RAPPRLEGALE_ULTIMO LEFT OUTER JOIN
                vPRIORITA_X_PROGETTO AS PXP ON PXP.ID_PROGETTO = P.ID_PROGETTO AND PXP.ID_PRIORITA IN (374, 406, 798, 1191) INNER JOIN
                FASCICOLO_AZIENDALE AS F ON P.ID_FASCICOLO = F.ID_FASCICOLO INNER JOIN
                vINDIRIZZARIO AS IND ON I.ID_SEDELEGALE_ULTIMO = IND.ID_INDIRIZZARIO
WHERE   (P.SEGNATURA IS NOT NULL) AND P.ID_BANDO = 493
ORDER BY NUMERO_DOMANDA
