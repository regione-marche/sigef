﻿CREATE VIEW VRECUPERO_CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI AS (
SELECT 
	ID_ACCORPAMENTO_INVESTIMENTI,
	ref.value('ID[1]', 'INT') AS ID,
	ref.value('ID_CORRETTIVA[1]', 'INT') AS ID_CORRETTIVA,
	CASE 
		WHEN ref.value('ID_INVESTIMENTO_DA[1]', 'VARCHAR(MAX)') = ''
		THEN null
		ELSE ref.value('ID_INVESTIMENTO_DA[1]', 'INT')
	END AS ID_INVESTIMENTO_DA,
	CASE 
		WHEN ref.value('ID_INVESTIMENTO_A[1]', 'VARCHAR(MAX)') = ''
		THEN null
		ELSE ref.value('ID_INVESTIMENTO_A[1]', 'INT')
	END AS ID_INVESTIMENTO_A,
	CASE 
		WHEN ref.value('IMPORTO_SPOSTATO[1]', 'VARCHAR(MAX)') = ''
		THEN null
		ELSE ref.value('IMPORTO_SPOSTATO[1]', 'DECIMAL(18,2)')
	END AS IMPORTO_SPOSTATO,
	CASE 
		WHEN ref.value('CONCLUSO[1]', 'VARCHAR(MAX)') = ''
		THEN null
		ELSE ref.value('CONCLUSO[1]', 'BIT')
	END AS CONCLUSO,
	CASE 
		WHEN ref.value('ANNULLATO[1]', 'VARCHAR(MAX)') = ''
		THEN null
		ELSE ref.value('ANNULLATO[1]', 'BIT')
	END AS ANNULLATO,
	CASE 
		WHEN ref.value('ID_UTENTE[1]', 'VARCHAR(MAX)') = ''
		THEN null
		ELSE ref.value('ID_UTENTE[1]', 'INT')
	END AS ID_UTENTE,
	CASE 
		WHEN ref.value('DATA[1]', 'VARCHAR(MAX)') = ''
		THEN null
		ELSE ref.value('DATA[1]', 'DATETIME')
	END AS DATA,
	ref.value('DESCRIZIONE[1]', 'VARCHAR(MAX)') AS DESCRIZIONE,
	CASE 
		WHEN ref.value('ID_JSON_LOG[1]', 'VARCHAR(MAX)') = ''
		THEN null
		ELSE ref.value('ID_JSON_LOG[1]', 'INT')
	END AS ID_JSON_LOG
FROM ACCORPAMENTO_INVESTIMENTI I
	CROSS APPLY
	I.ISTANZA_PIANO_INVESTIMENTI.nodes('//IstanzaPianoInvestimenti/CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI/CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI') AS CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI1(ref)
WHERE 1 = 1);
go