﻿CREATE PROCEDURE [dbo].[RptDomandaPagamentoDatiAzienda]
@IdDomandaPagamento int	
AS
BEGIN	

-- Dati generali
DECLARE @ID_Impresa int
SET @ID_Impresa = (SELECT ID_IMPRESA FROM dbo.PROGETTO WHERE ID_PROGETTO = (SELECT ID_PROGETTO FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento))

IF (@ID_Impresa IS NOT NULL)
	BEGIN
		SELECT I.CUAA, I.RAGIONE_SOCIALE, IND.COD_TIPO_SEDE, IND.VIA, IND.TELEFONO, IND.FAX, 
							  IND.EMAIL, IND.COMUNE, IND.CAP, IND.ISTAT, IND.SIGLA, 
							  IND.COD_PROVINCIA AS ISTAT_PROV, IND.COMUNE AS DENOMINAZIONE, i.ID_IMPRESA, I.COD_FORMA_GIURIDICA
		FROM  VIMPRESA AS I 
				INNER JOIN vINDIRIZZARIO IND ON I.ID_SEDELEGALE_ULTIMO = IND.ID_INDIRIZZARIO
		WHERE I.ID_IMPRESA = @ID_Impresa
		
	END
ELSE 
	BEGIN
		
		 SELECT NULL AS CUAA,
				NULL AS PIVA_CF,
				NULL AS ISCRIZIONE_REGISTRO_IMPRESE,
				NULL AS CODICE_INPS,
				NULL AS RAGIONE_SOCIALE,
				NULL AS COD_FORMA_GIURIDICA, 
				NULL AS DIMENSIONE_IMPRESA, 
				NULL AS COD_FORMA_GIURIDICA
	END
END