﻿

CREATE PROCEDURE [dbo].[SpGetMenuOperatore]
(
	@ID_PROFILO INT
)
AS
	WITH CTE_FUNZIONALITA AS 
	(
		SELECT rootTree.COD_FUNZIONE,CONVERT(VARCHAR(MAX),rootTree.PathSequence) AS PathLabel 
		FROM (
			SELECT F.COD_FUNZIONE,char(64 + ROW_NUMBER() OVER(ORDER BY F.LIVELLO+CAST(ORDINE AS VARCHAR(5)))) AS PathSequence 
			FROM FUNZIONALITA F INNER JOIN PROFILO_X_FUNZIONI P ON F.COD_FUNZIONE=P.COD_FUNZIONE 
			WHERE LIVELLO=0 AND P.ID_PROFILO=@ID_PROFILO) rootTree
		UNION ALL
		SELECT subTree.COD_FUNZIONE,PathLabel = subTree.PathLabel + CONVERT(VARCHAR(MAX),subTree.PathSequence) 
		FROM (
			SELECT F.COD_FUNZIONE,cte.PathLabel,char(64 + ROW_NUMBER() OVER(ORDER BY F.LIVELLO+CAST(ORDINE AS VARCHAR(5)))) AS PathSequence 
			FROM CTE_FUNZIONALITA CTE INNER JOIN FUNZIONALITA F ON CTE.COD_FUNZIONE=F.PADRE
			INNER JOIN PROFILO_X_FUNZIONI P ON F.COD_FUNZIONE=P.COD_FUNZIONE 
			WHERE P.ID_PROFILO=@ID_PROFILO) subTree
	)

	SELECT F.*,'0' AS PathLabel,1 AS APERTO FROM FUNZIONALITA F WHERE DESC_MENU='Area_Pubblica'
	UNION
	SELECT F2.*,'0'+CAST(F2.ORDINE AS VARCHAR(5)) AS PathLabel,1
	FROM FUNZIONALITA F INNER JOIN FUNZIONALITA F2 ON F.COD_FUNZIONE=F2.PADRE WHERE F.DESC_MENU='Area_Pubblica'
	UNION
	SELECT F.*,PathLabel,0 FROM CTE_FUNZIONALITA INNER JOIN FUNZIONALITA F ON CTE_FUNZIONALITA.COD_FUNZIONE=F.COD_FUNZIONE ORDER BY PathLabel