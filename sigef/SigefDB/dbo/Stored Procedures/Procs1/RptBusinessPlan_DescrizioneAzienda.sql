CREATE PROCEDURE [dbo].[RptBusinessPlan_DescrizioneAzienda] 
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

	SET @Count = (SELECT COUNT(ID_IMPRESA) FROM IMPRESA WHERE ID_IMPRESA = @ID_Impresa)

	IF (@Count > 0)
		
	     SELECT  ISNULL(PRESENTAZIONE,'Presentazione non disponibile') AS PRESENTAZIONE,
                ISNULL(DESCRIZIONE,'Descrizione non disponibile') AS DESCRIZIONE
		 FROM IMPRESA
		 WHERE ID_IMPRESA = @ID_Impresa
		
	ELSE SELECT 'Presentazione non disponibile' AS PRESENTAZIONE,
                'Descrizione non disponibile' AS DESCRIZIONE
				
END
