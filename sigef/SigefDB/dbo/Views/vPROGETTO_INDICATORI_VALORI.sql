
CREATE VIEW [dbo].[vPROGETTO_INDICATORI_VALORI]
AS
SELECT DISTINCT 
                         PIND.ID_PROGETTO, dbo.calcoloIndicatoriGetPrioritaInv(DP.ID_PROGRAMMAZIONE) AS IdPrioritaI, DP.ID_PROGRAMMAZIONE AS IdIntervento, 
                         DP.ID_DIMENSIONE AS IdIndicatore, dbo.calcoloIndicatoriGetUltimoValoreRealizzato(PIND.ID_PROGETTO, PIND.ID_DIM_X_PROGRAMMAZIONE, NULL) AS ValoreR, 
                         dbo.vzPROGRAMMAZIONE.COD_PSR
FROM            dbo.PROGETTO_INDICATORI AS PIND INNER JOIN
                         dbo.zDIMENSIONI_X_PROGRAMMAZIONE AS DP ON PIND.ID_DIM_X_PROGRAMMAZIONE = DP.ID_DIM_X_PROGRAMMAZIONE INNER JOIN
                         dbo.vzPROGRAMMAZIONE ON DP.ID_PROGRAMMAZIONE = dbo.vzPROGRAMMAZIONE.ID

