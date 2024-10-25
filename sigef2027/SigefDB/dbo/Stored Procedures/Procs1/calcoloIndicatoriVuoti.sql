


CREATE PROCEDURE [dbo].[calcoloIndicatoriVuoti] (@IdPor varchar(20), @DataFin datetime = NULL)
AS
BEGIN
-- Join tra:
--		- tabella valori programmati del por
--      - vista dell'elenco completo delle combinazioni Priorità Investimento - Indicatori presenti a sistema

	SELECT null as ID_ESTRAZIONE_IO, null as ID_ESTRAZIONE, GETDATE() AS DATA_ESTRAZIONE , @idPor AS COD_PSR, 
		IP.ID_DIM_PRIORITA as ID_DIM_PRIORITA, IP.CodPriorita, IP.DesPriorita, IP.OrdPriorita, 
		IP.ID_DIM_INDICATORE AS ID_DIM_INDICATORE, IP.CodIndicatore, IP.DesIndicatore, IP.OrdIndicatore, IP.UM,
		VP.VALORE_PF, VP.DATA_PF, VP.VALORE_F, VP.DATA_F, NULL AS VALORE_RTOT, 0 as BLOCCATO, YEAR(@DataFin) AS ANNO
	FROM      dbo.vzDIMENSIONI_INDICATORI_X_PRIORITAI AS IP LEFT OUTER JOIN 
              dbo.vzDIMENSIONI_VALPROGRAMMATO AS VP ON IP.ID_DIM_PRIORITA = VP.ID_DIM_PRIORITA AND IP.ID_DIM_INDICATORE = VP.ID_DIM_INDICATORE 
	WHERE IP.COD_PSR = @idPor
	ORDER BY IP.CodPriorita, IP.CodIndicatore

END






