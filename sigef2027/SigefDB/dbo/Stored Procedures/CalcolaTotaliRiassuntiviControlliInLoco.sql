CREATE PROCEDURE [dbo].[CalcolaTotaliRiassuntiviControlliInLoco]
@IdLoco INT

AS

IF OBJECT_ID('tempdb..#tmpvCntr') IS NOT NULL
BEGIN
	DROP TABLE #tmpvCntr
END

SELECT * INTO #tmpvCntr FROM
		vCntrLoco_Dettaglio_Prj WHERE IdLoco=@IdLoco
		

SELECT
	'Costo investimento richiesto' Descrizione
	,SUM(SpesaAmmessa_Incrementale) Tutte
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN SpesaAmmessa_Incrementale ELSE 0 END) Incluse
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN SpesaAmmessa_Incrementale ELSE 0 END) Escluse
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN SpesaAmmessa_Incrementale ELSE 0 END) Alta
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN SpesaAmmessa_Incrementale ELSE 0 END) Media
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN SpesaAmmessa_Incrementale ELSE 0 END) Bassa
	FROM
		#tmpvCntr
UNION all
SELECT
	'Costo investimento ammesso'
	,SUM(CostoTotale)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN CostoTotale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN CostoTotale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN CostoTotale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN CostoTotale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN CostoTotale ELSE 0 END)
	FROM
		#tmpvCntr
UNION all
SELECT
	'Contributo concesso'
	,SUM(ImportoAmmesso)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN ImportoAmmesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN ImportoAmmesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN ImportoAmmesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN ImportoAmmesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN ImportoAmmesso ELSE 0 END)
	FROM
		#tmpvCntr
UNION all
SELECT
	'Importo rendicontato ammesso (totale incrementale)'
	,SUM(ImportoConcesso)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN ImportoConcesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN ImportoConcesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN ImportoConcesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN ImportoConcesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN ImportoConcesso ELSE 0 END)
	FROM
		#tmpvCntr
UNION all
SELECT
	'Contributo rendicontato concesso (totale incrementale)'
	,SUM(ImportoContributoPubblico)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN ImportoContributoPubblico ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN ImportoContributoPubblico ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN ImportoContributoPubblico ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN ImportoContributoPubblico ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN ImportoContributoPubblico ELSE 0 END)
	FROM
		#tmpvCntr
UNION all
SELECT
	'Importo rendicontato ammesso (delta riferito allo specifico lotto)'
	,SUM(SpesaAmmessa)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN SpesaAmmessa ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN SpesaAmmessa ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN SpesaAmmessa ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN SpesaAmmessa ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN SpesaAmmessa ELSE 0 END)
	FROM
		#tmpvCntr
UNION all
SELECT
	'Contributo rendicontato concesso (delta riferito allo specifico lotto)'
	,SUM(ImportoContributoPubblico_Incrementale)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN ImportoContributoPubblico_Incrementale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN ImportoContributoPubblico_Incrementale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN ImportoContributoPubblico_Incrementale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN ImportoContributoPubblico_Incrementale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN ImportoContributoPubblico_Incrementale ELSE 0 END)
	FROM
		#tmpvCntr
UNION all
SELECT
	'Importo rendicontato ammesso - ritiro / recupero(totale incrementale)'
	,SUM(ImportoConcesso)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN ImportoConcesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN ImportoConcesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN ImportoConcesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN ImportoConcesso ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN ImportoConcesso ELSE 0 END)
	FROM
		#tmpvCntr
UNION all
SELECT
	'Contributo rendicontato concesso - ritiro / recupero (totale incrementale)'
	,SUM(ImportoContributoPubblico)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN ImportoContributoPubblico ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN ImportoContributoPubblico ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN ImportoContributoPubblico ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN ImportoContributoPubblico ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN ImportoContributoPubblico ELSE 0 END) 
	FROM
		#tmpvCntr
UNION all
SELECT
	'Importo rendicontato ammesso - ritiro / recupero (delta riferito allo specifico lotto)'
	,SUM(SpesaAmmessa) 
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN SpesaAmmessa ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN SpesaAmmessa ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN SpesaAmmessa ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN SpesaAmmessa ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN SpesaAmmessa ELSE 0 END)
	FROM
		#tmpvCntr
UNION all
SELECT
	'Contributo rendicontato concesso - ritiro / recupero (delta riferito allo specifico lotto)'
	,SUM(ImportoContributoPubblico_Incrementale) 
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' THEN ImportoContributoPubblico_Incrementale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') <> '' THEN ImportoContributoPubblico_Incrementale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Alta' THEN ImportoContributoPubblico_Incrementale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Media' THEN ImportoContributoPubblico_Incrementale ELSE 0 END)
	,SUM(CASE WHEN ISNULL(Esclusione, '') = '' AND RischioComp = 'Bassa' THEN ImportoContributoPubblico_Incrementale ELSE 0 END)
	FROM
		#tmpvCntr