CREATE PROCEDURE [dbo].[RptQuadroRSelect] 	
@ID_Domanda int
AS
BEGIN
--	DECLARE @ID_Domanda INT
--set @ID_Domanda=4871

	DECLARE @IDFascicolo int
	SET @IDFascicolo = (select isNull (ID_FASCICOLO,( SELECT    MAX(F.ID_FASCICOLO) AS Expr1  
								FROM  IMPRESA INNER JOIN PROGETTO ON IMPRESA.ID_IMPRESA = PROGETTO.ID_IMPRESA 
								INNER JOIN FASCICOLO_AZIENDALE AS F ON IMPRESA.ID_IMPRESA = F.ID_IMPRESA
								WHERE     (PROGETTO.ID_PROGETTO = @ID_Domanda) ) ) 
								FROM PROGETTO WHERE ID_PROGETTO = @ID_Domanda )
	
	IF (@IDFascicolo IS NOT NULL) 
	BEGIN

--		DECLARE @Ote varchar(50)
--		DECLARE @Ude int
--		DECLARE @Rls decimal(18,2)
--		DECLARE @Uba decimal(18,2)

			-- Il secondo parametro forza il salvataggio in Fascicolo aziendale
--			EXEC @Ote = SpOTE @IdFascicolo,1 
--			EXEC @Rls = SpRLS @IdFascicolo,1
--			EXEC @Ude = SpUDE @IdFascicolo,1
--			EXEC @Uba = SpUBA @IdFascicolo,1	
--		IF (@Ote IS NOT NULL) SET @Ote = (SELECT DESCRIZIONE FROM OTE_TIPI WHERE OTE = @Ote)

		-- MODIFICA DEL 14 LUGLIO 2010 
		-- ** TOGLIERE OTE RLS UDE E LASCIARE SOLO UBA CHE PRENDO DIRETTAMENTE DAL FASCICOLO
		SELECT UBA FROM FASCICOLO_AZIENDALE WHERE ID_FASCICOLO = @IDFascicolo

--
--		SELECT @Ote AS OTE,
--			   @Ude AS UDE,
--			   @Rls AS RLS,
--			   @Uba AS UBA
--
	END
--	ELSE SELECT NULL AS OTE,
--				NULL AS UDE,
--				NULL AS RLS,
--				NULL AS UBA			
	
END
