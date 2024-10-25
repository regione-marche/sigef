﻿CREATE PROCEDURE [dbo].[RptBusinessPlan_MonitoraggioFESR]
@ID_Impresa int,
@ID_Domanda int
AS
BEGIN	

	SET NOCOUNT ON;
    	
    DECLARE @Count int
		
	IF (@ID_Domanda IS NOT NULL)
	 BEGIN

	SET @Count = (SELECT COUNT(*) FROM DATI_MONITORAGGIO_FESR WHERE ID_PROGETTO = @ID_Domanda)
	
	IF (@Count > 0)		
	
		select A.Sottocategoria AS CODICE_ATECO, A.Descrizione AS ATECO, 
		AE.Descrizione AS ATTIVITA_ECONOMICA, CUP_CAT.COD_CUP_CATEGORIE as  CUP_CODICE, 
		CUP_CAT.Descrizione AS CUP_SOTTOSETTORE, CUP_TERR.Descrizione AS DIMENSIONE_TERRITORIALE, 
		TEMA.Descrizione AS TEMA_PRIORITARIO, CPT_SET.Descrizione AS CPT_SETTORE, 
		CUp_SOG.COD_CUP_CATEGORIE_SOGGETTI as CUP_COD_CATEGORIA_SOGGETTI, 
		CUP_SOG.Descrizione AS CUP_CATEGORIA_SOGGETTI, 
		 ISNULL( CUP_NATURA.Descrizione , '') + ' - ' +	ISNULL( CUP_OPER.Descrizione, '') 
		as TIPO_OPERAZIONE
		from DATI_MONITORAGGIO_FESR M 
		left join TIPO_ATECO2007 a on M.ID_ATECO = A.COD_TIPO_ATECO2007
		LEFT JOIN TIPO_ATTIVITA_ECON AE ON M.ATTIVITA_ECON = AE.COD_ATTIVITA_ECON
		LEFT JOIN TIPO_CUP_CATEGORIE CUP_CAT ON M.CUP_CATEGORIA = CUP_CAT.COD_CUP_CATEGORIE
		LEFT JOIN TIPO_CUP_DIMENSIONE_TERR CUP_TERR ON M.CUP_DIMENSIONE_TERR = CUP_TERR.COD_CUP_DIMENSIONE_TERR
		LEFT JOIN TIPO_TEMA_PRIORITARIO TEMA ON M.TEMA_PRIORITARIO = TEMA.COD_TEMA_PRIORITARIO
		LEFT JOIN TIPO_CPT_SETTORE CPT_SET ON M.CPT_SETTORE = CPT_SET.COD_CPT_SETTORE
		LEFT JOIN TIPO_CUP_CATEGORIE_TIPIOPERAZIONI CUP_OPER ON M.CUP_CATEGORIA_TIPOOPER = CUP_OPER.COD_CUP_CATEGORIE_TIPIOPERAZIONI
		LEFT JOIN TIPO_CUP_CATEGORIE_SOGGETTI CUP_SOG ON M.CUP_CATEGORIA_SOGGETTO = CUP_SOG.COD_CUP_CATEGORIE_SOGGETTI
		LEFT JOIN TIPO_CUP_NATURA CUP_NATURA ON CUP_OPER.Natura = CUP_NATURA.COD_CUP_NATURA
		where ID_PROGETTO = @ID_Domanda
	
	ELSE 
	
	SELECT  NULL AS ID_LOCALIZZAZIONE, 
	NULL AS ID_PROGETTO, 
	NULL AS ID_IMPRESA, 
	NULL AS ID_COMUNE, 
	NULL AS CAP, 
	NULL AS DUG, 
	NULL AS VIA, 
	NULL AS NUM, 
	NULL AS EFFETTO_SU_CONTRIBUTO, 
	NULL AS COMUNE_BELFIORE, 
	NULL AS COMUNE_DENOMINAZIONE, 
	NULL AS COMUNE_PROV_CODE, 
	NULL AS COMUNE_PROV_SIGLA, 
	NULL AS COMUNE_ISTAT, 
	NULL AS CATASTO_ID, 
	NULL AS CATASTO_FOGLIO, 
	NULL AS CATASTO_PARTICELLA, 
	NULL AS CATASTO_SEZIONE, 
	NULL AS CATASTO_SUBALTERNO, 
	NULL AS CATASTO_SUPERFICIE, 
	NULL AS TIPO_VIA
				
	END		
END
