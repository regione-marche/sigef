CREATE PROCEDURE [dbo].[RptBusinessPlan_TerreniConduzione] 
@ID_Impresa int,
@ID_Domanda int
AS
BEGIN

	SET NOCOUNT ON;
	DECLARE @IDFascicolo int
	SET @IDFascicolo = (select isNull (ID_FASCICOLO,( SELECT    MAX(F.ID_FASCICOLO) AS Expr1  
																						FROM PROGETTO P
																						INNER JOIN FASCICOLO_AZIENDALE AS F ON P.ID_IMPRESA = F.ID_IMPRESA
																						WHERE     (P.ID_PROGETTO = @ID_Domanda) ) ) 
								FROM PROGETTO WHERE ID_PROGETTO = @ID_Domanda)

	IF(@IDFascicolo IS NOT NULL)
     BEGIN
			select tipo_conduzione as TIPO_CONDUZIONE,
				dbo.MqAEttari(SUM(ISNULL(SUPERFICIE_CONDOTTA, 0))) as SUPERFICIE_CATASTALE,
				dbo.MqAEttari((SELECT SUM(ISNULL(SUPERFICIE_CONDOTTA,0)) FROM TERRITORIO WHERE  ID_FASCICOLO=@IDFascicolo)) AS TOTALE
			FROM vTERRITORIO WHERE  ID_FASCICOLO=@IDFascicolo AND COD_TIPO_CONDUZIONE <> 2
			group by tipo_conduzione	

	END	    		
	ELSE SELECT NULL AS TIPO_CONDUZIONE,
                NULL AS SUPERFICIE_CATASTALE,                
                NULL AS TOTALE

END
