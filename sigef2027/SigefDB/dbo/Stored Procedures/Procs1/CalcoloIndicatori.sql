
CREATE PROCEDURE [dbo].[CalcoloIndicatori] (@IdPor varchar(20), @DataFin datetime = NULL)
AS
BEGIN
DECLARE  @tmpValPerProgetto TABLE
(
 ID_PROGETTO int, 
 IdPrioritaI int,
 IdIntervento int,
 IdIndicatore int,
 ValoreR decimal(18,2),
 COD_PSR  varchar(20)
)
DECLARE  @tmpValPerPriorita TABLE
(
 IdPrioritaI int,
 IdIndicatore int,
 ValoreRTot decimal(18,2)
)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Tabella temporanea che associa ad ogni progetto-indicatore un singolo valore, l'ultimo inserito e
	-- ad ogni intervento la Priorità di investimento
	INSERT INTO @tmpValPerProgetto
	SELECT DISTINCT 
                         PIND.ID_PROGETTO, dbo.calcoloIndicatoriGetPrioritaInv(DP.ID_PROGRAMMAZIONE) AS IdPrioritaI, DP.ID_PROGRAMMAZIONE AS IdIntervento, 
                         DP.ID_DIMENSIONE AS IdIndicatore, dbo.calcoloIndicatoriGetUltimoValoreRealizzato(PIND.ID_PROGETTO, PIND.ID_DIM_X_PROGRAMMAZIONE, @DataFin) AS ValoreR, 
                         PR.COD_PSR
	FROM            dbo.PROGETTO_INDICATORI AS PIND INNER JOIN
                         dbo.zDIMENSIONI_X_PROGRAMMAZIONE AS DP ON PIND.ID_DIM_X_PROGRAMMAZIONE = DP.ID_DIM_X_PROGRAMMAZIONE INNER JOIN
                         dbo.vzPROGRAMMAZIONE AS PR ON DP.ID_PROGRAMMAZIONE = PR.ID
						 WHERE PR.COD_PSR = @IdPor

	-- Tabella temporanea che aggrega per Priorità di investimento - Indicatore
	-- Investimenti privati e valori non calcolati -> somme
	INSERT INTO @tmpValPerPriorita
	SELECT        IdPrioritaI, IdIndicatore, SUM(ValoreR) AS ValoreRTot
		FROM      @tmpValPerProgetto
		WHERE     IdIndicatore NOT IN
									 (SELECT  ID
									   FROM   dbo.zDIMENSIONI
									   WHERE  (PROCEDURA_CALCOLO = 'calcoloIndicatoriNumImprese')) 
		GROUP BY IdIndicatore, IdPrioritaI
--	
	-- Numerosità imprese -> conteggio
	INSERT INTO @tmpValPerPriorita
	SELECT        TMPP.IdPrioritaI, TMPP.IdIndicatore, COUNT(DISTINCT CODICE_FISCALE) AS ValoreRTot
		FROM          @tmpValPerProgetto TMPP
			inner join dbo.vCO01GetListPIva PIVA ON (TMPP.ID_PROGETTO = PIVA.ID_PROGETTO AND TMPP.IdPrioritaI = PIVA.PrioritaI)
		WHERE        TMPP.IdIndicatore IN
									 (SELECT   ID
									   FROM     dbo.zDIMENSIONI
									   WHERE  (PROCEDURA_CALCOLO = 'calcoloIndicatoriNumImprese')) 
					AND TMPP.ValoreR > 0
		GROUP BY IdIndicatore, IdPrioritaI

-- recordset contenente la tabella temporanea in join con: 
--		- tabella valori programmati del por
--      - vista dell'elenco completo delle combinazioni Priorità Investimento - Indicatori presenti a sistema

	SELECT null as ID_ESTRAZIONE_IO, null as ID_ESTRAZIONE, GETDATE() AS DATA_ESTRAZIONE , @idPor AS COD_PSR, 
		IP.ID_DIM_PRIORITA as ID_DIM_PRIORITA, IP.CodPriorita, IP.DesPriorita, IP.OrdPriorita, 
		IP.ID_DIM_INDICATORE AS ID_DIM_INDICATORE, IP.CodIndicatore, IP.DesIndicatore, IP.OrdIndicatore, IP.UM,
		VP.VALORE_PF, VP.DATA_PF, VP.VALORE_F, VP.DATA_F, ISNULL (PIT.ValoreRTot, 0) AS VALORE_RTOT, 0 as BLOCCATO, YEAR(@DataFin) AS ANNO
	FROM      dbo.vzDIMENSIONI_INDICATORI_X_PRIORITAI AS IP LEFT OUTER JOIN 
              dbo.vzDIMENSIONI_VALPROGRAMMATO AS VP ON IP.ID_DIM_PRIORITA = VP.ID_DIM_PRIORITA AND IP.ID_DIM_INDICATORE = VP.ID_DIM_INDICATORE LEFT OUTER JOIN
			  @tmpValPerPriorita AS PIT ON PIT.IdPrioritaI = IP.ID_DIM_PRIORITA AND PIT.IdIndicatore = IP.ID_DIM_INDICATORE 
	WHERE IP.COD_PSR = @idPor
	ORDER BY IP.CodPriorita, IP.CodIndicatore

END

