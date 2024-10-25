CREATE PROCEDURE [dbo].[ZVcertrendicontazioneFindFind]
(
	@CodPsrequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT Cod_Psr, Id_Domanda_Pagamento, Data_Approvazione, Data_VerDocum, Asse_Codice, Id_Bando, Intervento, Azione, Id_Progetto, Codice_CUP, Tipo_Operazione, Stato, Comune, Costo_Totale, Importo_Ammesso, Importo_Concesso, Operazioni_Beneficiario, Contributo_Richiesto, Beneficiario, Spesa_Ammessa, Contributo_Concesso, Importo_Contributo_Pubblico, Spesa_Ammessa_Incrementale, Importo_Contributo_Pubblico_Incrementale, Importo_Liquidato, Operazione_Esclusa, Motivo_Esclusione, domanda_pagamento_istruita, rdp_approvata, IN_INTEGRAZIONE, Importo_Privato, PercReal, RischioIR, RischioCR, Rischio, Domanda_Tipo FROM vCertRendicontazione WHERE 1=1';
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Cod_Psr = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodPsrequalthis VARCHAR(255)',@CodPsrequalthis ;
	else
		SELECT Cod_Psr, Id_Domanda_Pagamento, Data_Approvazione, Data_VerDocum, Asse_Codice, Id_Bando, Intervento, Azione, Id_Progetto, Codice_CUP, Tipo_Operazione, Stato, Comune, Costo_Totale, Importo_Ammesso, Importo_Concesso, Operazioni_Beneficiario, Contributo_Richiesto, Beneficiario, Spesa_Ammessa, Contributo_Concesso, Importo_Contributo_Pubblico, Spesa_Ammessa_Incrementale, Importo_Contributo_Pubblico_Incrementale, Importo_Liquidato, Operazione_Esclusa, Motivo_Esclusione, domanda_pagamento_istruita, rdp_approvata, IN_INTEGRAZIONE, Importo_Privato, PercReal, RischioIR, RischioCR, Rischio, Domanda_Tipo
		FROM vCertRendicontazione
		WHERE 
			((@CodPsrequalthis IS NULL) OR Cod_Psr = @CodPsrequalthis)