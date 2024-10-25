CREATE PROCEDURE [dbo].[CalcolaPercentualiRiassuntiviControlliInLoco]
@IdLoco INT

AS

	IF OBJECT_ID('tempdb..#tmpvCntr') IS NOT NULL
	BEGIN
		DROP TABLE #tmpvCntr
	END
	
	SELECT * INTO #tmpvCntr FROM vCntrLoco_Dettaglio
	WHERE IdLoco=@IdLoco 

	SELECT 
		'5%' descrizione
		,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN SpesaAmmessa ELSE 0 END)*0.05 Teorico --Estraggo il 5%
		,0 Selezionato
		,0 Definitivo
		FROM 
			#tmpvCntr 
	UNION all 
	SELECT 
		'50% del 5%'
		,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN SpesaAmmessa ELSE 0 END)*0.05*0.5 --Estraggo il 50% del 5%
		,SUM(CASE WHEN Selezionata = 'TRUE' AND RischioComp = 'Alta' THEN SpesaAmmessa ELSE 0 END)
		,SUM(CASE WHEN Definitivo = 'TRUE' AND Selezionata = 'TRUE' AND RischioComp = 'Alta' THEN SpesaAmmessa ELSE 0 END)
		FROM 
			#tmpvCntr
	UNION all 
	SELECT 
		'30% del 5%'
		,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN SpesaAmmessa ELSE 0 END)*0.05*0.3 --Estraggo il 30% del 5%
		,SUM(CASE WHEN Selezionata = 'TRUE' AND RischioComp = 'Media' THEN SpesaAmmessa ELSE 0 END) 
		,SUM(CASE WHEN Definitivo = 'TRUE' AND Selezionata = 'TRUE' AND RischioComp = 'Media' THEN SpesaAmmessa ELSE 0 END)
		FROM 
			#tmpvCntr
	UNION all 
	SELECT 
		'20% del 5%'
		,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN SpesaAmmessa ELSE 0 END)*0.05*0.2 --Estraggo il 20% del 5%
		,SUM(CASE WHEN Selezionata = 'TRUE' AND RischioComp = 'Bassa' THEN SpesaAmmessa ELSE 0 END)
		,SUM(CASE WHEN Definitivo = 'TRUE' AND Selezionata = 'TRUE' AND RischioComp = 'Bassa' THEN SpesaAmmessa ELSE 0 END)
		FROM 
			#tmpvCntr