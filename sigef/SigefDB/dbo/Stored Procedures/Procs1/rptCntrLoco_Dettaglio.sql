CREATE PROCEDURE [dbo].[rptCntrLoco_Dettaglio]
(
	@ID_LOCO INT, 
	@RISCHIOCOMP VARCHAR(255) = NULL
)
AS
	SELECT 0 AS IdLoco_Dettaglio, d.IdLoco,  0 AS Id_Domanda_Pagamento, d.Id_Progetto, d.Asse, d.Selezionata, d.Esito, d.DataEsito,
 d.CostoTotale, d.ImportoAmmesso, MAX(d.ImportoConcesso) AS ImportoConcesso, d.NrOperazioniB, d.Beneficiario, SUM(d.SpesaAmmessa) AS SpesaAmmessa,
 MAX(d.ImportoContributoPubblico) AS ImportoContributoPubblico, SUM(d.SpesaAmmessa_Incrementale) AS SpesaAmmessa_Incrementale,
 SUM(d.ImportoContributoPubblico_Incrementale) AS ImportoContributoPubblico_Incrementale, d.Esclusione, MAX(d.RischioIR) AS RischioIR,
 MAX(d.RischioCR) AS RischioCR, MAX(d.RischioComp) AS RischioComp, MAX(d.Operatore) AS Operatore, MAX(d.DataInserimento) AS DataInserimento,
 MAX(d.DataModifica) AS DataModifica, d.Azione, d.Intervento, t.CodPsr, t.DataFine, t.Definitivo, cr.Codice_Cup, cn.Cod_Cup_Natura AS Cup_Natura_Codice,
 cn.Descrizione AS Cup_Natura_Descrizione, dbo.fnProgettoTitolo(d.Id_Progetto) AS TitoloProgetto  
 FROM dbo.CntrLoco_Testa t
 INNER JOIN dbo.CntrLoco_Dettaglio d ON t.IdLoco = d.IdLoco 
 LEFT JOIN Cup_Richieste cr ON d.Id_Progetto = cr.Id_Progetto AND cr.Esito_Elaborazione_Cup = 'OK'
 LEFT JOIN Dati_Monitoraggio_Fesr dm ON d.Id_Progetto = dm.Id_Progetto
 LEFT JOIN Tipo_Cup_Natura cn ON dm.Cup_Natura = cn.Cod_Cup_Natura  
 WHERE 1 = 1
		AND ((@ID_LOCO IS NULL) OR t.IdLoco = @ID_LOCO) 
		AND ((@RISCHIOCOMP IS NULL) OR d.RischioComp = @RISCHIOCOMP)
 GROUP BY d.IdLoco, d.Id_Progetto, d.Asse, d.Selezionata, d.Esito, d.DataEsito, d.CostoTotale, d.ImportoAmmesso, d.NrOperazioniB, 
 d.Beneficiario, d.Esclusione, d.Azione, d.Intervento, t.CodPsr, t.DataFine, t.Definitivo, cr.Codice_Cup, cn.Cod_Cup_Natura, 
 cn.Descrizione, dbo.fnProgettoTitolo(d.Id_Progetto);


-- EXEC [rptCntrLoco_Dettaglio] 1, null;
-- EXEC [rptCntrLoco_Dettaglio] @IdLoco, @RischioComp;