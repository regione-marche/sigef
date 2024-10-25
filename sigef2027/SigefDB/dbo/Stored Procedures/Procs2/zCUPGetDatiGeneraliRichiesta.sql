CREATE PROCEDURE [dbo].[zCUPGetDatiGeneraliRichiesta]
( 
	@IdProgetto INT
)
AS
BEGIN

WITH TREE AS 
(
	SELECT 
	PRG.ID,
	PRG.CODICE,
	PRG.DESCRIZIONE,
	PRG.ID_PADRE,
	PRG.ID AS ID_ROOT,
	PSA.LIVELLO,
	NULL AS CHECK_QUOTA_REG
	FROM 
	ZPROGRAMMAZIONE PRG 
	INNER JOIN 
	ZPSR_ALBERO PSA ON 
	PRG.COD_TIPO = PSA.CODICE
	WHERE 
	PSA.COD_PSR = 'POR20142020'
	AND 
	PSA.LIVELLO = 1
	UNION ALL
	SELECT 
	PRGN.ID,
	PRGN.CODICE,
	PRGN.DESCRIZIONE,
	PRGN.ID_PADRE,
	TREE.ID_ROOT,
	PSA.LIVELLO,
	CASE 
	WHEN 
	(ID_ROOT = 217 AND PSA.LIVELLO = 3) OR (PRGN.ID IN(116,289,290,291,292)) THEN 0 ELSE 1 
	END AS CHECK_QUOTA_REG
	FROM 
	ZPROGRAMMAZIONE PRGN
	INNER JOIN 
	ZPSR_ALBERO PSA ON 
	PRGN.COD_TIPO = PSA.CODICE
	INNER JOIN TREE ON 
	PRGN.ID_PADRE = TREE.ID
	WHERE 
	--PRGN.COD_TIPO LIKE 'POR20142020%'
	PSA.COD_PSR = 'POR20142020'
)

SELECT 
P.ID_PROGETTO AS id_progetto,
CONVERT(CHAR(4),DATEPART(yyyy,P.DATA)) AS anno_decisione,
DMF.CUP_NATURA AS natura,
SUBSTRING(DMF.CUP_CATEGORIA_TIPOOPER,3,2) AS tipologia,
TCC.Settore AS settore,
TCC.Sottosettore AS sottosettore,
TCC.Categoria AS categoria,
'5' AS stato,
--'11' AS regione,
C.COD_REGIONE AS regione,
C.COD_PROVINCIA AS provincia,
C.SIGLA sigla,
C.COD_PROVINCIA + C.ISTAT AS comune,
LP.DUG AS tipo_indirizzo,
LP.VIA AS indirizzo,
LP.CAP AS cap,
LP.NUM AS numero,
DMF.ID_ATECO AS codice_ateco,
ATECO.Sezione AS sezione_ateco,
ATECO.Divisione AS divisione_ateco,
ATECO.Gruppo AS gruppo_ateco,
ATECO.Classe AS classe_ateco,
ATECO.Categoria AS categoria_ateco,
ATECO.Sottocategoria AS sottocategoria_ateco,
dbo.calcoloCostoTotaleProgetto(@IdProgetto,1,null) AS costo_progetto,
dbo.calcoloContributoTotaleProgetto(@IdProgetto,1,null) AS finanziamento_progetto,
TREE.CHECK_QUOTA_REG AS check_quota_reg
FROM 
vPROGETTO P
INNER JOIN DATI_MONITORAGGIO_FESR DMF ON
P.ID_PROGETTO = DMF.ID_PROGETTO
INNER JOIN TIPO_CUP_CATEGORIE TCC ON
DMF.CUP_CATEGORIA = TCC.COD_CUP_CATEGORIE
INNER JOIN LOCALIZZAZIONE_PROGETTO LP ON
P.ID_PROGETTO = LP.ID_PROGETTO
AND
P.ID_IMPRESA = LP.ID_IMPRESA
INNER JOIN vCOMUNI C ON
LP.ID_COMUNE = C.ID_COMUNE
LEFT OUTER JOIN 
TIPO_ATECO2007 ATECO ON
DMF.ID_ATECO = ATECO.COD_TIPO_ATECO2007
INNER JOIN 
BANDO_PROGRAMMAZIONE BP ON
P.ID_BANDO = BP.ID_BANDO
INNER JOIN 
TREE ON
BP.ID_PROGRAMMAZIONE = TREE.ID
WHERE 
P.COD_STATO NOT IN ('P','L','A','Q','B','N','I')
AND 
BP.ID_PROGRAMMAZIONE NOT IN (17,18,19)
AND
P.ID_PROGETTO = @IdProgetto

END

--SELECT 
--P.ID_PROGETTO as id_progetto,
--CONVERT(CHAR(4),DATEPART(yyyy,PS.DATA)) AS anno_decisione,
--DMF.CUP_NATURA as natura,
--SUBSTRING(DMF.CUP_CATEGORIA_TIPOOPER,3,2) AS tipologia,
--TCC.Settore AS settore,
--TCC.Sottosettore AS sottosettore,
--TCC.Categoria AS categoria,
--'5' AS stato,
--'11' AS regione,
----P.ID_IMPRESA,
--C.COD_PROVINCIA AS provincia,
--C.SIGLA sigla,
--C.COD_PROVINCIA + C.ISTAT AS comune,
--LP.DUG AS tipo_indirizzo,
--LP.VIA as indirizzo,
--LP.CAP AS cap,
--LP.NUM as numero,
--DMF.ID_ATECO as codice_ateco,
--ATECO.Sezione as sezione_ateco,
--ATECO.Divisione as divisione_ateco,
--ATECO.Gruppo as gruppo_ateco,
--ATECO.Classe as classe_ateco,
--ATECO.Categoria as categoria_ateco,
--ATECO.Sottocategoria as sottocategoria_ateco,
--dbo.calcoloCostoTotaleProgetto(@IdProgetto,1,null) AS costo_progetto,
--dbo.calcoloContributoTotaleProgetto(@IdProgetto,1,null) AS finanziamento_progetto
--FROM 
--PROGETTO P
--INNER JOIN DATI_MONITORAGGIO_FESR DMF ON
--P.ID_PROGETTO = DMF.ID_PROGETTO
--INNER JOIN TIPO_CUP_CATEGORIE TCC ON
--DMF.CUP_CATEGORIA = TCC.COD_CUP_CATEGORIE
--INNER JOIN PROGETTO_STORICO PS ON
--P.ID_PROGETTO = PS.ID_PROGETTO
--INNER JOIN LOCALIZZAZIONE_PROGETTO LP ON
--P.ID_PROGETTO = LP.ID_PROGETTO
----INNER JOIN IMPRESA I ON
----P.ID_IMPRESA = I.ID_IMPRESA
----INNER JOIN INDIRIZZARIO IND ON
----I.ID_IMPRESA = IND.ID_IMPRESA 
----AND IND.COD_TIPO_SEDE = 'S'
----AND IND.DATA_FINE_VALIDITA IS NULL 
----AND FLAG_ATTIVO = 1
----INNER JOIN INDIRIZZO ON
----IND.ID_INDIRIZZO = INDIRIZZO.ID_INDIRIZZO
--INNER JOIN COMUNI C ON
--LP.ID_COMUNE = C.ID_COMUNE
--LEFT OUTER JOIN TIPO_ATECO2007 ATECO ON
--DMF.ID_ATECO = ATECO.COD_TIPO_ATECO2007
--WHERE 
----PS.COD_STATO = 'I' --DA CAMBIARE IN 'F' non appena ci sono domande finanziabili
----AND
--P.ID_PROGETTO = @IdProgetto
--END
