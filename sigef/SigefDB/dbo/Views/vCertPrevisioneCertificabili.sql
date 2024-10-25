CREATE VIEW vCertPrevisioneCertificabili
AS
SELECT  
prt.Id_Progetto,
d.Id_Domanda_Pagamento,
asse.Id										as ASSE_ID,
asse.Codice                                 AS Asse_Codice,
azione.Codice                               AS Azione,
ti.Codice                                   AS Intervento,
prt.Id_Bando,
vu.Nominativo								AS Responsbile_bando,
b.ENTE										AS Struttura,
vut.NOMINATIVO								AS Validatore,   
vuti.NOMINATIVO								AS Istruttore,     
dbo.calcoloCostoTotaleProgetto(d.Id_Progetto, 1, dbo.fnIdVariante(prt.Id_Progetto, rdp.Data_Validazione))
                                            AS Costo_Totale_Progetto,                    -- Calcolato a livello di progetto
dbo.calcoloContributoTotaleProgetto(d.Id_Progetto, 1, dbo.fnIdVariante(prt.Id_Progetto, rdp.Data_Validazione)) + 
ISNULL(dbo.calcoloPremioContoCapitale(d.Id_Progetto, 1, dbo.fnIdVariante(prt.Id_Progetto, rdp.Data_Validazione)), 0) 
                                            AS Importo_Contributo_Ammesso_Progetto,       -- Calcolato a livello di progetto    
ISNULL(pric.ImpRichiesto_tot,0)				AS Importo_Rend_Richiesto_Domanda_Pagamento,
ISNULL(pric.ConRichiesto_tot,0)				AS Importo_Contributo_Richiesto_Domanda_Pagamento,
ISNULL(tblAmm1_rol.ImpAmmesso_rol, 0)       AS Importo_Rend_Ammesso_Domanda_Pagamento,
case when (Intervento='5.1.1') then 1295157.23 else ISNULL(dpe.Importo_Ammesso, 0) end AS Importo_Contributo_Concesso_Domanda_Pagamento,
imp.Ragione_Sociale                         AS Beneficiario,
imp.cod_forma_giuridica						AS Forma_Giuridica,
imp.forma_giuridica							AS Forma_Giuridica_Desc,
CASE 
    WHEN d.Approvata = 1 THEN 'SI' 
    ELSE 'NO' 
END                                         AS domanda_pagamento_istruita,
CASE 
    WHEN rdp.Approvata = 1 THEN 'SI' 
    ELSE 'NO' 
END                                         AS Validazione,
d.In_Integrazione,
ISNULL(dps.Tot_Mandato, 0)                  AS Tot_Importo_Quietanza_Mandato,
d.Cod_Tipo                                  AS Domanda_Tipo,
CASE
    WHEN cnt.Definitivo = 0 THEN 'SI'
    ELSE 'NO'
END                                         AS ControlloInLoco_Provvisorio ,
CASE 
    WHEN 
		rdp.Approvata = 1 and d.APPROVATA=1 and cnt.Definitivo = 0 and 
		(d.COD_TIPO <> 'ANT' or 
			(d.COD_TIPO = 'ANT' and imp.COD_FORMA_GIURIDICA not in 
				('2',
				'2.1',
				'2.2',
				'2.3.',
				'2.4',
				'2.4.10',
				'2.4.20',
				'2.4.30',
				'2.4.40',
				'2.4.50',
				'2.4.60',
				'2.5',
				'2.6.10',
				'2.6.20',
				'2.7',
				'2.7.11',
				'2.7.12',
				'2.7.40',
				'2.7.51',
				'2.7.52',
				'2.7.53',
				'2.7.54',
				'2.7.55',
				'2.7.56',
				'2.7.90') 
			)
		)
    THEN 'SI' 
    ELSE 'NO' 
END											AS CertificabileAdOggi,
CASE 
    WHEN 
		(rdp.Approvata = 0 or rdp.Approvata is null) and d.Approvata = 1 and 
		(d.COD_TIPO <> 'ANT' or 
			(d.COD_TIPO = 'ANT' and imp.COD_FORMA_GIURIDICA not in 
				('2',
				'2.1',
				'2.2',
				'2.3.',
				'2.4',
				'2.4.10',
				'2.4.20',
				'2.4.30',
				'2.4.40',
				'2.4.50',
				'2.4.60',
				'2.5',
				'2.6.10',
				'2.6.20',
				'2.7',
				'2.7.11',
				'2.7.12',
				'2.7.40',
				'2.7.51',
				'2.7.52',
				'2.7.53',
				'2.7.54',
				'2.7.55',
				'2.7.56',
				'2.7.90') 
			)
		)
    THEN 'SI' 
    ELSE 'NO' 
END											AS CertificabileDaFareControlli 

FROM 
vDomanda_di_Pagamento AS d
-- Verifica documentale 1o livello
LEFT JOIN
-- : modificata tabella da Revisione_domanda_pagamento a CTE_TESTATA_VALIDAZIONE 18/05/2021
CTE_TESTATA_VALIDAZIONE AS rdp ON d.Id_Domanda_Pagamento = rdp.Id_Domanda_Pagamento 
-- Verifica in loco 2o livello
LEFT JOIN
CntrLoco_Dettaglio AS cld ON d.Id_Domanda_Pagamento = cld.Id_Domanda_Pagamento  
LEFT JOIN 
CntrLoco_Testa AS cnt ON cnt.IdLoco = cld.IdLoco    
                --: spostato in where 02/05/2019
                  --AND (cnt.Definitivo IS NULL OR cnt.Definitivo = 0) -- Contr. Loco non presente o provvisorio
-- Bando e Programmazione
INNER JOIN
vProgetto AS prt ON d.Id_Progetto = prt.Id_Progetto
LEFT JOIN
vBando_Programmazione AS bprm ON 
prt.Id_Bando = bprm.Id_Bando
AND 
Id_Programmazione NOT IN (17, 18, 19)
INNER JOIN
zProgrammazione AS ti ON 
bprm.Id_Programmazione = ti.id
INNER JOIN
zProgrammazione AS azione ON 
ti.Id_Padre = azione.Id
INNER JOIN
zProgrammazione AS asse ON 
azione.Id_Padre = asse.Id
 -- Beneficiario
 INNER JOIN     
 vImpresa AS imp ON prt.Id_Impresa = imp.Id_Impresa
 -- Importi domanda pagamento per domanda pagamento
 LEFT JOIN
 Domanda_di_Pagamento_Esportazione AS dpe ON d.Id_Domanda_Pagamento = dpe.Id_Domanda_Pagamento
 INNER JOIN 
 vBando AS b ON prt.Id_Bando = b.Id_Bando
 INNER JOIN 
 Bando_Responsabili AS br ON b.Id_Bando = br.Id_Bando
 INNER JOIN 
 vUtenti AS vu ON br.Id_Utente = vu.Id_Utente 
 -- Importo ammesso
 LEFT JOIN
 ( SELECT Id_Domanda_Pagamento,
          SUM(Importo_Ammesso)       AS ImpAmmesso_tot,
          SUM(Importo_Richiesto)     AS ImpRichiesto_tot,
          SUM(Contributo_Richiesto)  AS ConRichiesto_tot
   FROM Pagamenti_Richiesti
   GROUP BY Id_Domanda_Pagamento
  ) AS pric ON d.Id_Domanda_Pagamento = pric.Id_Domanda_Pagamento
  /*LEFT JOIN
  ( SELECT  Id_Progetto,
            SUM(Costo_Investimento) AS CostoInvestimentoRichiesto
    FROM Piano_Investimenti nolock
    WHERE Id_Investimento_Originale IS NULL
    GROUP BY Id_Progetto
  ) AS PrjT ON d.Id_Progetto = PrjT.Id_Progetto*/
  --------------------------------------------------
LEFT OUTER JOIN 
( SELECT  dpl.Id_Domanda_Pagamento,
        SUM(ISNULL(dpl.Quietanza_Importo, 0)) AS Tot_Mandato,
        MAX(dpl.Quietanza_Data)               AS Data_Quietanza
  FROM Domanda_Pagamento_Liquidazione dpl
  GROUP BY dpl.Id_Domanda_Pagamento
) AS dps ON d.Id_Domanda_Pagamento = dps.Id_Domanda_Pagamento
OUTER APPLY
( SELECT SUM(pr1.Importo_Ammesso)     AS ImpAmmesso_rol
FROM dbo.Pagamenti_Richiesti AS pr1 
     INNER JOIN
     dbo.Domanda_di_Pagamento AS ddp1 ON pr1.Id_Domanda_Pagamento = ddp1.Id_Domanda_Pagamento
WHERE ddp1.Id_Progetto          =  d.Id_Progetto
  AND ddp1.Id_Domanda_Pagamento <= d.Id_Domanda_Pagamento
  AND ddp1.Segnatura            IS NOT NULL
  AND ddp1.Annullata            =  'FALSE'
) AS tblAmm1_rol 
LEFT OUTER JOIN 
vUTENTI vut ON
rdp.CF_VALIDATORE = vut.CF_UTENTE
LEFT OUTER JOIN 
vUTENTI vuti ON
d.CF_ISTRUTTORE = vuti.CF_UTENTE
  /*OUTER APPLY
  ( SELECT  SUM(Importo_Ammesso)    AS ImpAmmesso_rol
    FROM dbo.Domanda_di_Pagamento_Esportazione
    WHERE Id_Progetto           =  d.Id_Progetto
      AND Id_Domanda_Pagamento  <= d.Id_Domanda_Pagamento
  ) AS tblAmm2_rol*/
WHERE d.Segnatura   IS NOT NULL         -- Domanda di pagamento approvata
AND d.Annullata   = 'FALSE'
AND bprm.COD_PSR  = 'POR20142020'

--: eliminata condizione 02/05/2019
--AND cld.IdLoco    IS NULL

AND br.Attivo     = 1
AND br.Provincia  IS NULL       

-- : spostato da left join 02/05/2019
AND (cnt.Definitivo IS NULL OR cnt.Definitivo = 0) -- Contr. Loco non presente o provvisorio

GO