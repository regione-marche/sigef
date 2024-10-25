﻿CREATE PROCEDURE [dbo].[RptIstruttoriaVarianteDatiAzienda]
@IdVariante int	
AS
BEGIN	

	-- Dati generali
	DECLARE @ID_IMPRESA int
	SET @ID_IMPRESA = (SELECT ID_IMPRESA FROM dbo.PROGETTO WHERE ID_PROGETTO = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @IdVariante))

	IF (@ID_IMPRESA IS NOT NULL)
		BEGIN
			-- Dati Generali Azienda
			SELECT I.CUAA, I.RAGIONE_SOCIALE, IND.COD_TIPO_SEDE, IND.VIA, IND.TELEFONO, IND.FAX, 
								  IND.EMAIL, IND.COMUNE, IND.CAP, IND.ISTAT, IND.SIGLA, 
								  IND.COD_PROVINCIA AS ISTAT_PROV
			FROM vIMPRESA AS I INNER JOIN vINDIRIZZARIO IND ON I.ID_SEDELEGALE_ULTIMO = IND.ID_INDIRIZZARIO
			WHERE I.ID_IMPRESA = @ID_IMPRESA
		END
	ELSE 
		BEGIN
			
			 SELECT NULL AS CUAA,
					NULL AS RAGIONE_SOCIALE, 
					NULL AS COD_TIPO_SEDE, 
					NULL AS VIA, 
					NULL AS	TELEFONO, 
					NULL AS FAX,
					NULL AS EMAIL, 
					NULL AS COMUNE, 
					NULL AS CAP, 
					NULL AS ISTAT, 
					NULL AS SIGLA, 
					NULL AS ISTAT_PROV, 
					NULL AS DENOMINAZIONE
		END
END
