



CREATE PROCEDURE [dbo].[_zImportAnticipiProgettoSigfrido95Filiere]
	
	@id_prog_sigfrido int
	
AS
BEGIN

declare @id_prog_sigef int = null
declare @id_domanda_pagamento int = null
declare @id_giustificativo int = null
declare @id_spesa int = null
declare @id_pagamento_richiesto int = null
declare @id_pagamento_beneficiario int = null
--declare @id_prog_sigfrido int = 16411--null
declare @id_prog_storico_ultimo int = null
declare @temptable_storico table (id int null, id_progetto int null)
--declare @temptable_investimenti table (id_inv int null, id_progetto int null)
--declare @table_ute table(
--id_domanda_sigfrido int null, 
--id_progetto_sigef int null, 
--id_utente_storico int null, 
--id_impresa_sigef int null, 
--cf_piva_sigef varchar(50)null, 
--id_utente_sigef int null, 
--data_us datetime null, 
--data_stato_progetto datetime null)


begin try

begin transaction [Tran1]



INSERT INTO [DOMANDA_DI_PAGAMENTO]
           ([COD_TIPO]
           ,[ID_PROGETTO]
           ,[DATA_INSERIMENTO]
           ,[CF_OPERATORE]
           ,[DATA_MODIFICA]
           ,[COD_ENTE]
           ,[SEGNATURA]
           ,[SEGNATURA_ALLEGATI]
           ,[ID_FIDEJUSSIONE]
           ,[DATA_CERTIFICAZIONE_ANTIMAFIA]
           ,[APPROVATA]
           ,[SEGNATURA_APPROVAZIONE]
           ,[SEGNATURA_SECONDA_APPROVAZIONE]
           ,[CF_ISTRUTTORE]
           ,[DATA_APPROVAZIONE]
           ,[VALUTAZIONE_ISTRUTTORE]
           ,[ANNULLATA]
           ,[SEGNATURA_ANNULLAMENTO]
           ,[CF_OPERATORE_ANNULLAMENTO]
           ,[DATA_ANNULLAMENTO]
           ,[VALIDITA_VERSIONE_ADC]
           ,[ID_VARIAZIONE_ACCERTATA]
           ,[PREDISPOSTA_A_CONTROLLO]
           ,[DATA_PREDISPOSIZIONE_A_CONTROLLO]
           ,[VISITA_INSITU_ESITO]
           ,[VISITA_INSITU_NOTE]
           ,[CONTROLLO_INLOCO_ESITO]
           ,[CONTROLLO_INLOCO_NOTE]
           ,[VERIFICA_PAGAMENTI_ESITO]
           ,[VERIFICA_PAGAMENTI_MESSAGGIO]
           ,[VERIFICA_PAGAMENTI_DATA])
     --VALUES
     SELECT
       'ANT',						  --(<COD_TIPO, char(3),>
       gs.ID_PROGETTO_SIGEF,		  --,<ID_PROGETTO, int,>
       gs.DATA_ANTICIPO,					  --,<DATA_INSERIMENTO, datetime,>
       gs.CF_OPERATORE_IMPRESA,		  --,<CF_OPERATORE, varchar(16),>
       gs.DATA_ANTICIPO,						  --,<DATA_MODIFICA, datetime,>
       NULL,						  --,<COD_ENTE, varchar(10),>
       'ND',						  --,<SEGNATURA, varchar(100),>
       NULL,						  --,<SEGNATURA_ALLEGATI, varchar(100),>
       NULL,						  --,<ID_FIDEJUSSIONE, int,>
       NULL,						  --,<DATA_CERTIFICAZIONE_ANTIMAFIA, datetime,>
       1,							  --,<APPROVATA, bit,>
       'ND',						  --,<SEGNATURA_APPROVAZIONE, varchar(100),>
       NULL,						  --,<SEGNATURA_SECONDA_APPROVAZIONE, varchar(100),>
       gs.CF_OPERATORE_ISTRUTTORIA,   --,<CF_ISTRUTTORE, varchar(16),>
       GETDATE(),					  --,<DATA_APPROVAZIONE, datetime,>
       NULL,					      --,<VALUTAZIONE_ISTRUTTORE, ntext,>
       0,					          --,<ANNULLATA, bit,>
       NULL,					      --,<SEGNATURA_ANNULLAMENTO, varchar(100),>
       NULL,					      --,<CF_OPERATORE_ANNULLAMENTO, varchar(16),>
       NULL,					      --,<DATA_ANNULLAMENTO, datetime,>
       0,						      --,<VALIDITA_VERSIONE_ADC, bit,>
       NULL,					      --,<ID_VARIAZIONE_ACCERTATA, int,>
       0,						      --,<PREDISPOSTA_A_CONTROLLO, bit,>
       NULL,					      --,<DATA_PREDISPOSIZIONE_A_CONTROLLO, datetime,>
       NULL,					      --,<VISITA_INSITU_ESITO, char(2),>
       NULL,					      --,<VISITA_INSITU_NOTE, ntext,>
       NULL,					      --,<CONTROLLO_INLOCO_ESITO, char(2),>
       NULL,					      --,<CONTROLLO_INLOCO_NOTE, ntext,>
       NULL,					      --,<VERIFICA_PAGAMENTI_ESITO, char(1),>
       NULL,					      --,<VERIFICA_PAGAMENTI_MESSAGGIO, varchar(3000),>
       NULL							  --,<VERIFICA_PAGAMENTI_DATA, datetime,>)
       FROM _vGrad95Filiere_1 gs
       WHERE 
       gs.ID_DOMANDA = @id_prog_sigfrido 
       




select @id_domanda_pagamento = SCOPE_IDENTITY()


INSERT INTO [ANTICIPI_RICHIESTI]
           ([ID_DOMANDA_PAGAMENTO]
           ,[ID_BANDO]
           ,[DATA_RICHIESTA]
           ,[CONTRIBUTO_RICHIESTO]
           ,[CONTRIBUTO_AMMESSO]
           ,[AMMESSO]
           ,[ISTRUTTORE]
           ,[DATA_VALUTAZIONE])
     --VALUES
 SELECT  
 @id_domanda_pagamento,			--(<ID_DOMANDA_PAGAMENTO, int,>
 gs.IdBandoSigef,				--,<ID_BANDO, int,>
 gs.DATA_ANTICIPO,				--,<DATA_RICHIESTA, datetime,>
 gs.IMPORTO_ANTICIPO,			--,<CONTRIBUTO_RICHIESTO, decimal(18,2),>
 gs.IMPORTO_ANTICIPO,			--,<CONTRIBUTO_AMMESSO, decimal(18,2),>
 1,								--,<AMMESSO, bit,>
 gs.CF_OPERATORE_ISTRUTTORIA,   --,<ISTRUTTORE, varchar(16),>
 gs.DATA_ANTICIPO				--,<DATA_VALUTAZIONE, datetime,>)
  FROM _vGrad95Filiere_1 gs
	WHERE 
	gs.ID_DOMANDA = @id_prog_sigfrido 


--update _GraduatoriaSigfrido100 set ID_PROGETTO_SIGEF = @id_prog_sigef where ID_DOMANDA = @id_prog_sigfrido


--INSERT INTO [GIUSTIFICATIVI]
--           ([ID_PROGETTO]
--           ,[NUMERO]
--           ,[COD_TIPO]
--           ,[DATA]
--           ,[NUMERO_DOCTRASPORTO]
--           ,[DATA_DOCTRASPORTO]
--           ,[IMPONIBILE]
--           ,[IVA]
--           ,[ALTRI_ONERI]
--           ,[DESCRIZIONE]
--           ,[CF_FORNITORE]
--           ,[DESCRIZIONE_FORNITORE]
--           ,[IVA_NON_RECUPERABILE]
--           ,[ID_FILE])
--     --VALUES
--     SELECT
--        gs.ID_PROGETTO_SIGEF,   --(<ID_PROGETTO, int,>
--        NULL,					--,<NUMERO, varchar(30),>
--        'FAT',					--,<COD_TIPO, char(3),>
--        GETDATE(),			    --,<DATA, datetime,>
--        NULL,				    --,<NUMERO_DOCTRASPORTO, varchar(30),>
--        NULL,				    --,<DATA_DOCTRASPORTO, datetime,>
--        gs.IMPORTO_LIQUIDATO_TOT,   --,<IMPONIBILE, decimal(18,2),>
--        0,						--,<IVA, decimal(18,2),>
--        NULL,					--,<ALTRI_ONERI, decimal(18,2),>
--        'Fattura autogenerata per progetto importato id ' + CONVERT(varchar(10),gs.ID_PROGETTO_SIGEF),--,<DESCRIZIONE, varchar(255),>
--        VI.CODICE_FISCALE,		--,<CF_FORNITORE, varchar(16),>
--        VI.RAGIONE_SOCIALE,		--,<DESCRIZIONE_FORNITORE, varchar(255),>
--        0,						--,<IVA_NON_RECUPERABILE, bit,>
--        NULL					--,<ID_FILE, int,>)
--      FROM _vGrad100 gs
--      INNER JOIN vIMPRESA VI ON
--      gs.ID_IMPRESA = VI.ID_IMPRESA
--       WHERE 
--       gs.ID_DOMANDA = @id_prog_sigfrido 


--select @id_giustificativo = SCOPE_IDENTITY()

--INSERT INTO [SPESE_SOSTENUTE]
--           ([ID_DOMANDA_PAGAMENTO]
--           ,[ID_GIUSTIFICATIVO]
--           ,[COD_TIPO]
--           ,[ESTREMI]
--           ,[DATA]
--           ,[IMPORTO]
--           ,[NETTO]
--           ,[AMMESSO]
--           ,[DATA_APPROVAZIONE]
--           ,[OPERATORE_APPROVAZIONE]
--           ,[ID_FILE])
--     --VALUES
--SELECT
--@id_domanda_pagamento,		--(<ID_DOMANDA_PAGAMENTO, int,>
--@id_giustificativo,			--,<ID_GIUSTIFICATIVO, int,>
--'BBP',						--,<COD_TIPO, char(3),>
--'',							--,<ESTREMI, varchar(255),>
--GETDATE(),					--,<DATA, datetime,>
--gs.IMPORTO_LIQUIDATO_TOT,   --,<IMPORTO, decimal(18,2),>
--gs.IMPORTO_LIQUIDATO_TOT,   --,<NETTO, decimal(18,2),>
--1,							--,<AMMESSO, bit,>
--GETDATE(),					--,<DATA_APPROVAZIONE, datetime,>
--gs.ID_OPERATORE_ISTRUTTORIA,--,<OPERATORE_APPROVAZIONE, int,>
--NULL						--,<ID_FILE, int,>)
--FROM _vGrad100 gs 
--WHERE
--gs.ID_DOMANDA = @id_prog_sigfrido 

--select @id_spesa = SCOPE_IDENTITY()




--INSERT INTO [PAGAMENTI_RICHIESTI]
--           ([ID_DOMANDA_PAGAMENTO]
--           ,[ID_INVESTIMENTO]
--           ,[DATA_RICHIESTA_PAGAMENTO]
--           ,[IMPORTO_COMPUTO_METRICO]
--           ,[IMPORTO_RICHIESTO]
--           ,[CONTRIBUTO_RICHIESTO]
--           ,[CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO]
--           ,[IMPORTO_COMPUTO_METRICO_AMMESSO]
--           ,[IMPORTO_AMMESSO]
--           ,[CONTRIBUTO_AMMESSO]
--           ,[CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO]
--           ,[AMMESSO]
--           ,[ISTRUTTORE]
--           ,[DATA_VALUTAZIONE]
--           ,[NOTE_ISTRUTTORE]
--           ,[COD_SANZIONE_VARIAZIONE_INVESTIMENTI])
--     --VALUES
--SELECT
--@id_domanda_pagamento,		--(<ID_DOMANDA_PAGAMENTO, int,>
--pinv.ID_INVESTIMENTO,		--,<ID_INVESTIMENTO, int,>
--GETDATE(),					--,<DATA_RICHIESTA_PAGAMENTO, datetime,>
--NULL,						--,<IMPORTO_COMPUTO_METRICO, decimal(18,2),>
--gs.INVESTIMENTO_RICHIESTO,  --,<IMPORTO_RICHIESTO, decimal(18,2),>
--gs.IMPORTO_LIQUIDATO_TOT,   --,<CONTRIBUTO_RICHIESTO, decimal(18,2),>
--NULL,						--,<CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO, decimal(18,2),>
--NULL,						--,<IMPORTO_COMPUTO_METRICO_AMMESSO, decimal(18,2),>
--gs.INV_AMMESSO,				--,<IMPORTO_AMMESSO, decimal(18,2),>
--gs.IMPORTO_LIQUIDATO_TOT,   --,<CONTRIBUTO_AMMESSO, decimal(18,2),>
--gs.IMPORTO_LIQUIDATO_TOT,   --,<CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO, decimal(18,2),>
--1,							--,<AMMESSO, bit,>
--gs.CF_OPERATORE_ISTRUTTORIA,--,<ISTRUTTORE, varchar(16),>
--GETDATE(),						--,<DATA_VALUTAZIONE, datetime,>
--NULL,						--,<NOTE_ISTRUTTORE, ntext,>
--NULL						--,<COD_SANZIONE_VARIAZIONE_INVESTIMENTI, char(3),>)
--FROM _vGrad100 gs 
--INNER JOIN PIANO_INVESTIMENTI pinv ON
--gs.ID_PROGETTO_SIGEF = pinv.ID_PROGETTO 
--WHERE 
--pinv.AMMESSO = 1
--AND pinv.ISTRUTTORE IS NOT NULL
--AND pinv.ID_INVESTIMENTO_ORIGINALE IS NOT NULL 
--AND gs.ID_DOMANDA = @id_prog_sigfrido


--select @id_pagamento_richiesto = SCOPE_IDENTITY()



--INSERT INTO [PAGAMENTI_BENEFICIARIO]
--           ([ID_PAGAMENTO_RICHIESTO]
--           ,[ID_GIUSTIFICATIVO]
--           ,[IMPORTO_RICHIESTO]
--           ,[IMPORTO_AMMESSO]
--           ,[IMPORTO_NONAMM_NONRESP]
--           ,[IMPORTO_AMMESSO_CONTR]
--           ,[IMPORTO_NONAMM_CONTR_NONRESP]
--           ,[SPESA_TECNICA_RICHIESTA]
--           ,[SPESA_TECNICA_AMMESSA]
--           ,[SPESA_TECNICA_AMMESSA_CONTR]
--           ,[COSTITUISCE_VARIANTE]
--           ,[COD_RIDUZIONE]
--           ,[MOTIVAZIONE_RIDUZIONE]
--           ,[COD_RIDUZIONE_CONTR]
--           ,[MOTIVAZIONE_RIDUZIONE_CONTR])
--     --VALUES
--SELECT
--@id_pagamento_richiesto,        --(<ID_PAGAMENTO_RICHIESTO, int,>
--@id_giustificativo,				--,<ID_GIUSTIFICATIVO, int,>
--gs.IMPORTO_LIQUIDATO_TOT,		--,<IMPORTO_RICHIESTO, decimal(18,2),>
--gs.IMPORTO_LIQUIDATO_TOT,       --,<IMPORTO_AMMESSO, decimal(18,2),>
--NULL,							--,<IMPORTO_NONAMM_NONRESP, decimal(18,2),>
--NULL,							--,<IMPORTO_AMMESSO_CONTR, decimal(18,2),>
--NULL,							--,<IMPORTO_NONAMM_CONTR_NONRESP, decimal(18,2),>
--0,								--,<SPESA_TECNICA_RICHIESTA, bit,>
--0,								--,<SPESA_TECNICA_AMMESSA, bit,>
--0,								--,<SPESA_TECNICA_AMMESSA_CONTR, bit,>
--0,								--,<COSTITUISCE_VARIANTE, bit,>
--NULL,							--,<COD_RIDUZIONE, varchar(50),>
--NULL,							--,<MOTIVAZIONE_RIDUZIONE, int,>
--NULL,							--,<COD_RIDUZIONE_CONTR, varchar(50),>
--NULL							--,<MOTIVAZIONE_RIDUZIONE_CONTR, int,>)
--FROM _vGrad100 gs
--WHERE 
--gs.ID_DOMANDA = @id_prog_sigfrido


--select @id_pagamento_beneficiario = SCOPE_IDENTITY()




INSERT INTO [DOMANDA_DI_PAGAMENTO_ESPORTAZIONE]
           ([ID_DOMANDA_PAGAMENTO]
           ,[ID_PROGETTO]
           ,[BARCODE]
           ,[MISURA_PREVALENTE]
           ,[IMPORTO_AMMISSIBILE]
           ,[IMPORTO_SANZIONE]
           ,[IMPORTO_RECUPERO_ANTICIPO]
           ,[IMPORTO_AMMESSO]
           ,[IMPORTO_LIQUIDATO]
           ,[FLAG_LIQUIDATO]
           ,[ID_DECRETO])
     --VALUES
SELECT
@id_domanda_pagamento,          --(<ID_DOMANDA_PAGAMENTO, int,>
gs.ID_PROGETTO_SIGEF,           --,<ID_PROGETTO, int,>
CONVERT(VARCHAR(5),@id_domanda_pagamento) + CONVERT(VARCHAR(6),gs.ID_PROGETTO_SIGEF),  --,<BARCODE, char(11),>
1,								--,<MISURA_PREVALENTE, bit,>
gs.IMPORTO_ANTICIPO,       --,<IMPORTO_AMMISSIBILE, decimal(18,2),>
0,								--,<IMPORTO_SANZIONE, decimal(18,2),>
0,								--,<IMPORTO_RECUPERO_ANTICIPO, decimal(18,2),>
gs.IMPORTO_ANTICIPO,       --,<IMPORTO_AMMESSO, decimal(18,2),>
gs.IMPORTO_ANTICIPO,       --,<IMPORTO_LIQUIDATO, decimal(18,2),>
1,								--,<FLAG_LIQUIDATO, bit,>
NULL							--,<ID_DECRETO, int,>)
FROM _vGrad95Filiere_1 gs
WHERE 
gs.ID_DOMANDA = @id_prog_sigfrido




INSERT INTO [DOMANDA_PAGAMENTO_LIQUIDAZIONE]
           ([ID_DOMANDA_PAGAMENTO]
           ,[ID_PROGETTO]
           ,[ID_IMPRESA_BENEFICIARIA]
           ,[RICHIESTA_MANDATO_IMPORTO]
           ,[RICHIESTA_MANDATO_SEGNATURA]
           ,[RICHIESTA_MANDATO_DATA]
           ,[MANDATO_NUMERO]
           ,[MANDATO_DATA]
           ,[MANDATO_IMPORTO]
           ,[MANDATO_ID_FILE]
           ,[QUIETANZA_DATA]
           ,[QUIETANZA_IMPORTO]
           ,[LIQUIDATO])
     --VALUES
SELECT
@id_domanda_pagamento,          --(<ID_DOMANDA_PAGAMENTO, int,>
gs.ID_PROGETTO_SIGEF,           --,<ID_PROGETTO, int,>
gs.ID_IMPRESA,					--,<ID_IMPRESA_BENEFICIARIA, int,>
gs.IMPORTO_ANTICIPO,       --,<RICHIESTA_MANDATO_IMPORTO, decimal(18,2),>
'nd',							--,<RICHIESTA_MANDATO_SEGNATURA, varchar(100),>
GETDATE(),						--,<RICHIESTA_MANDATO_DATA, datetime,>
NULL,							--,<MANDATO_NUMERO, varchar(10),>
GETDATE(),						--,<MANDATO_DATA, datetime,>
gs.IMPORTO_ANTICIPO,       --,<MANDATO_IMPORTO, decimal(18,2),>
NULL,							--,<MANDATO_ID_FILE, int,>
GETDATE(),						--,<QUIETANZA_DATA, datetime,>
gs.IMPORTO_ANTICIPO,       --,<QUIETANZA_IMPORTO, decimal(18,2),>
1								--,<LIQUIDATO, bit,>)
FROM _vGrad95Filiere_1 gs
WHERE 
gs.ID_DOMANDA = @id_prog_sigfrido








--INSERT INTO [PROGETTO_STORICO] 
--([ID_PROGETTO]
--,[COD_STATO]
--,[DATA]
--,[OPERATORE]
--,[SEGNATURA]
--,[REVISIONE]
--,[RIESAME]
--,[RICORSO]
--,[DATA_RI]
--,[OPERATORE_RI]
--,[SEGNATURA_RI]
--,[RIAPERTURA_PROVINCIALE]) output INSERTED.ID, inserted.ID_PROGETTO into @temptable_storico(id, id_progetto)
----VALUES
--select 
--gs.ID_PROGETTO_SIGEF,			--id_progetto
--'T',							--cod_stato
----METTERE DATA DOMANDA DI PAGAMENTO DEL BENEFICIARIO
--GETDATE(),						--data			
--gs.ID_OPERATORE_ISTRUTTORIA,	--operatore
--null,							--segnatura
--0,								--revisione
--0,								--riesame
--0,								--ricorso
--null,							--data_ri
--null,							--operatore_ri
--null,							--segnatura_ri
--0								--riapertura_provinciale
--from _vGrad95Filiere_1 gs 
--where gs.ID_DOMANDA = @id_prog_sigfrido

--select @id_prog_storico_ultimo = max(id) from @temptable_storico  
--select @id_prog_sigef = id_progetto_sigef from _vgrad100 where id_domanda = @id_prog_sigfrido

--update PROGETTO set ID_STORICO_ULTIMO = @id_prog_storico_ultimo where ID_PROGETTO = @id_prog_sigef








commit tran [Tran1]

end try
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran1]
  PRINT ERROR_MESSAGE()
END CATCH  

END



