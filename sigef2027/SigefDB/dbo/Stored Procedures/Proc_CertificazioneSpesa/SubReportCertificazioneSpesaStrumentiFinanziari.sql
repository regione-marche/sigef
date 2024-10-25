-- DROP PROCEDURE SubReportCertificazioneSpesaStrumentiFinanziari;
CREATE PROCEDURE SubReportCertificazioneSpesaStrumentiFinanziari
(
	@dataLotto		DATETIME,
	@codPsr			VARCHAR(100),
	@soloDefinitivi BIT
)
AS
	/*
DECLARE @dataLotto		DATETIME;
DECLARE @codPsr			VARCHAR(100);
DECLARE @soloDefinitivi BIT; 

SET @dataLotto		= '20181219';
SET @codPsr			= 'POR20142020';
SET @soloDefinitivi = 1;
*/

SELECT fesr.Asse,
        fesr.ImportoComplessivoContributi  AS ImportoComplessivoContributi,
        fesr.ImportoSpesaPubblica1         AS ImportoSpesaPubblica1,
        SUM(ISNULL(fem.ImportoContributiErogati, 0))  AS ImportoContributiErogati,
        SUM(ISNULL(fem.ImportoSpesaPubblica2, 0))     AS ImportoSpesaPubblica2
FROM (  SELECT  vcrt.Asse,
                SUM(ISNULL(vcrt.ImportoContributoPubblico_Incrementale, 0)) AS ImportoComplessivoContributi,
                SUM(ISNULL(vcrt.ImportoContributoPubblico_Incrementale, 0)) AS ImportoSpesaPubblica1
        FROM dbo.vCertSp_Dettaglio AS vcrt
                INNER JOIN 
                dbo.Bando_Config AS bc ON vcrt.Id_Bando = bc.Id_Bando
        WHERE 1 = 1
			AND ((@soloDefinitivi IS NOT NULL AND @soloDefinitivi = 1 AND Definitivo   = 'TRUE')
				OR (@soloDefinitivi IS NULL OR @soloDefinitivi = 0))
            AND vcrt.Selezionata  = 'TRUE'
            AND vcrt.CodPsr       = @codPsr
            AND vcrt.DataFine     <= @DataLotto
            AND bc.Attivo         = 1
            AND bc.Cod_Tipo       = 'TPAPPALTO'
            AND bc.Valore         = '04'
        GROUP BY vcrt.Asse
        ) AS fesr
        LEFT JOIN
        (  SELECT  asse.Codice                 AS Asse,
                cnf.Id_Progetto,
                prg.Cod_Agea                AS Codice_Cup,
                imp.Ragione_Sociale         AS Beneficiario,
                ISNULL(cnf.Importo, 0)      AS ImportoContributiErogati,
                ISNULL(crt.Contributo, 0)   AS ImportoSpesaPubblica2
        FROM (  SELECT cfp.ID_PROGETTO,
                        SUM(ISNULL(cfp.Importo, 0)) AS Importo,
                        cf.ID_PROGETTO_RIF
                FROM dbo.Contratti_Fem cf 
                INNER JOIN 
                dbo.CONTRATTI_FEM_PAGAMENTI cfp ON cf.ID_CONTRATTO_FEM = cfp.ID_CONTRATTO_FEM 
                WHERE cfp.Data <= @DataLotto
                GROUP BY cfp.Id_Progetto, cf.ID_PROGETTO_RIF 
                ) AS cnf
                INNER JOIN
                dbo.vProgetto AS prg ON cnf.ID_PROGETTO_RIF = prg.Id_Progetto
                INNER JOIN
                dbo.vImpresa imp ON prg.Id_Impresa = imp.Id_Impresa
                INNER JOIN
                dbo.vBando_Programmazione bprm ON prg.Id_Bando = bprm.Id_Bando
                                            AND bprm.Id_Programmazione NOT IN (17, 18, 19)
                INNER JOIN
                dbo.zProgrammazione ti ON bprm.Id_Programmazione = ti.id
                INNER JOIN
                dbo.zProgrammazione azione ON ti.Id_Padre = azione.Id
                INNER JOIN
                dbo.zProgrammazione asse ON azione.Id_Padre = asse.Id
                LEFT JOIN
                (  SELECT  Id_Progetto,
                        SUM(ImportoContributoPubblico_Incrementale) AS Contributo
                FROM dbo.vCertSp_Dettaglio
                WHERE 1 = 1
					AND ((@soloDefinitivi IS NOT NULL AND @soloDefinitivi = 1 AND Definitivo   = 'TRUE')
						OR (@soloDefinitivi IS NULL OR @soloDefinitivi = 0))
                    AND Selezionata = 'TRUE'
                    AND CodPsr      = @codPsr
                    AND DataFine    <= @DataLotto
                GROUP BY Id_Progetto
                ) AS crt ON cnf.Id_Progetto = crt.Id_Progetto
        ) AS fem ON fesr.Asse = fem.Asse
GROUP BY fesr.Asse,
            fesr.ImportoComplessivoContributi,
            fesr.ImportoSpesaPubblica1

-- EXEC SubReportCertificazioneSpesaStrumentiFinanziari '20181219', 'POR20142020', 1
-- EXEC SubReportCertificazioneSpesaStrumentiFinanziari @dataLotto, @codPsr, @soloDefinitivi