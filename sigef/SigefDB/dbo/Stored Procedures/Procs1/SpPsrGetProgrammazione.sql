﻿CREATE PROCEDURE [dbo].[SpPsrGetProgrammazione]
(
	@COD_PSR VARCHAR(20)=NULL,
	@ID_PADRE INT=0,
	@ATTIVAZIONE_BANDI BIT=NULL,
	@ATTIVAZIONE_FA BIT=NULL,
	@ATTIVAZIONE_OB_MISURA BIT=NULL,
	@ATTIVAZIONE_INVESTIMENTI BIT=NULL,
	@ATTIVAZIONE_FF BIT=NULL
)
AS
	IF @COD_PSR IS NULL AND @ID_PADRE>0 
		SELECT @COD_PSR=COD_PSR FROM vzPROGRAMMAZIONE WHERE ID=@ID_PADRE;
		
	WITH CTE_PROGRAMMAZIONE AS 
	(
		SELECT rootTree.ID,rootTree.COD_TIPO,rootTree.CODICE,rootTree.DESCRIZIONE,rootTree.ID_PADRE,rootTree.COD_PSR,
			rootTree.TIPO,rootTree.LIVELLO,rootTree.ATTIVAZIONE_BANDI,rootTree.ATTIVAZIONE_FA,rootTree.ATTIVAZIONE_OB_MISURA,
			rootTree.ATTIVAZIONE_INVESTIMENTI,rootTree.ATTIVAZIONE_FF,rootTree.IMPORTO_DOTAZIONE,CONVERT(VARCHAR(MAX),rootTree.PathSequence) AS PathLabel
		FROM (
			SELECT ID,COD_TIPO,CODICE,DESCRIZIONE,ID_PADRE,COD_PSR,TIPO,LIVELLO,ATTIVAZIONE_BANDI,
				ATTIVAZIONE_FA,ATTIVAZIONE_OB_MISURA,ATTIVAZIONE_INVESTIMENTI,ATTIVAZIONE_FF,IMPORTO_DOTAZIONE,
				char(64 + ROW_NUMBER() OVER(ORDER BY COD_PSR+CAST(LIVELLO AS VARCHAR(5))+CODICE)) AS PathSequence
			FROM VZPROGRAMMAZIONE WHERE COD_PSR=@COD_PSR AND ID_PADRE=@ID_PADRE) rootTree -- Anchor/root term
		UNION ALL
		SELECT subTree.ID,subTree.COD_TIPO,subTree.CODICE,subTree.DESCRIZIONE,subTree.ID_PADRE,subTree.COD_PSR,
			subTree.TIPO,subTree.LIVELLO,subTree.ATTIVAZIONE_BANDI,subTree.ATTIVAZIONE_FA,subTree.ATTIVAZIONE_OB_MISURA,
			subTree.ATTIVAZIONE_INVESTIMENTI,subTree.ATTIVAZIONE_FF,subTree.IMPORTO_DOTAZIONE,PathLabel = subTree.PathLabel + CONVERT(VARCHAR(MAX),subTree.PathSequence)
		FROM   (
			SELECT P.ID,P.COD_TIPO,P.CODICE,P.DESCRIZIONE,P.ID_PADRE,P.COD_PSR,P.TIPO,P.LIVELLO,P.ATTIVAZIONE_BANDI,
				P.ATTIVAZIONE_FA,P.ATTIVAZIONE_OB_MISURA,P.ATTIVAZIONE_INVESTIMENTI,P.ATTIVAZIONE_FF,P.IMPORTO_DOTAZIONE,cte.PathLabel,
				PathSequence = char(64 + ROW_NUMBER() OVER(ORDER BY P.COD_PSR+CAST(P.LIVELLO AS VARCHAR(5))+P.CODICE))
			FROM CTE_PROGRAMMAZIONE cte INNER JOIN VZPROGRAMMAZIONE P ON CTE.ID = P.ID_PADRE 
			WHERE (@COD_PSR IS NULL OR P.COD_PSR=@COD_PSR)) subTree
	)

	SELECT * FROM CTE_PROGRAMMAZIONE WHERE (@ATTIVAZIONE_BANDI IS NULL OR ATTIVAZIONE_BANDI=@ATTIVAZIONE_BANDI)
		AND (@ATTIVAZIONE_FA IS NULL OR ATTIVAZIONE_FA=@ATTIVAZIONE_FA) 
		AND (@ATTIVAZIONE_OB_MISURA IS NULL OR ATTIVAZIONE_OB_MISURA=@ATTIVAZIONE_OB_MISURA)
		AND (@ATTIVAZIONE_INVESTIMENTI IS NULL OR ATTIVAZIONE_INVESTIMENTI=@ATTIVAZIONE_INVESTIMENTI)
		AND (@ATTIVAZIONE_FF IS NULL OR ATTIVAZIONE_FF=@ATTIVAZIONE_FF)
	ORDER BY PathLabel