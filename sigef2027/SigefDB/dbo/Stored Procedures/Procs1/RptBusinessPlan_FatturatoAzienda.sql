CREATE PROCEDURE [dbo].[RptBusinessPlan_FatturatoAzienda] 
@ID_Impresa int,
@ID_Domanda int
AS
BEGIN
	SET NOCOUNT ON;
    	
	DECLARE @CUAA varchar(16)
    DECLARE @Count int
		
	IF (@ID_Domanda IS NOT NULL)
	 BEGIN
	  SET @ID_Impresa = (SELECT ID_IMPRESA FROM PROGETTO WHERE ID_PROGETTO = @ID_Domanda)
	 END

	SET @Count = (SELECT COUNT(ID_IMPRESA) FROM FATTURATO_AZIENDA WHERE ID_IMPRESA = @ID_Impresa)
	
	IF (@Count > 0)						
		SELECT ANNO, 			   
               ALIQUOTA AS ALIQUOTA,			   			   
			   IMPORTO AS IMPONIBILE,
			   ((IMPORTO*(ALIQUOTA/100)) + IMPORTO) AS TOTALE 

		FROM FATTURATO_AZIENDA 								  
								  
		WHERE ID_IMPRESA = @ID_Impresa

		ORDER BY ANNO DESC
	
	ELSE SELECT NULL AS ANNO,
				NULL AS ALIQUOTA,
				NULL AS IMPONIBILE,
				NULL AS TOTALE					
END
