



CREATE PROCEDURE [dbo].[_zImportProgettoSigfrido95_Filiere_1]
	
	@id_prog_sigfrido int
	
AS
BEGIN

declare @id_prog_sigef int = null
--declare @id_prog_sigfrido int = 16411--null
declare @id_prog_storico_ultimo int = null
declare @temptable_storico table (id int null, id_progetto int null)
declare @temptable_investimenti table (id_inv int null, id_progetto int null, ammesso bit null, op_var varchar(16) null)
declare @table_ute table(
id_domanda_sigfrido int null, 
id_progetto_sigef int null, 
id_utente_storico int null, 
id_impresa_sigef int null, 
cf_piva_sigef varchar(50)null, 
id_utente_sigef int null, 
data_us datetime null, 
data_stato_progetto datetime null)
--declare @id_op_creazione int = null

begin try

begin transaction [Tran1]



INSERT INTO [PROGETTO]
([ID_BANDO]
,[COD_AGEA]
,[SEGNATURA_ALLEGATI]
,[ID_PROG_INTEGRATO]
,[FLAG_PREADESIONE]
,[FLAG_DEFINITIVO]
,[ID_FASCICOLO]
,[PROVINCIA_DI_PRESENTAZIONE]
,[SELEZIONATA_X_REVISIONE]
,[ID_IMPRESA]
,[ID_STORICO_ULTIMO]
,[DATA_CREAZIONE]
,[OPERATORE_CREAZIONE]
,[FIRMA_PREDISPOSTA])
--VALUES
SELECT 
gs170m.IdBandoSigef, --id_bando
gs170m.CODICE_CUP,	 --cod_agea
null,				 --segnatura_allegati
null,				 --id-prog_integrato
0,					 --flag_preadesione
1,					 --flag_definitivo
null,				 --id_fascicolo
'AN',				 --provincia_di_presentazione
0,					 --selezionata_x_revisione
gs170m.ID_IMPRESA,	 --id_impresa
null,				 --id_storico_ultimo
gs170m.TDataInizio,  --data_creazione
gs170m.ID_UTENTE,	 --operatore_creazione
0					 --firma_predisposta
FROM 
_vGrad95Filiere_1 gs170m
where gs170m.ID_DOMANDA = @id_prog_sigfrido
--[SIGFRIDO.DOMANDA].dbo.Soggetti s
--inner join 
--[SIGFRIDO.DOMANDA].dbo.Domande d on
--d.IdDomanda = s.IdDomanda
--left outer join IMPRESA i on 
--s.partitaiva collate Latin1_General_CI_AS = i.CODICE_FISCALE
--left outer join IMPRESA_STORICO IMS ON
--i.id_impresa = IMs.ID_IMPRESA
--and
--i.ID_STORICO_ULTIMO = ims.ID_STORICO_IMPRESA
--left outer join 
--PERSONE_X_IMPRESE PXI ON
--i.ID_IMPRESA = pxi.ID_IMPRESA
--left outer join 
--PERSONA_FISICA pf on 
--PXI.ID_PERSONA = pf.ID_PERSONA
--left outer join 
--UTENTI U on
--PXI.ID_PERSONA = U.ID_PERSONA_FISICA
--where d.IdDomanda in
--(
--16411)
--and
--s.TCancellato = 0
--and 
--d.IdDomanda = d.IsDomanda
--and 
--s.IdSoggetto = s.IsSoggetto

select @id_prog_sigef = SCOPE_IDENTITY()

update _GraduatoriaSigfrido95Filiere_1 set ID_PROGETTO_SIGEF = @id_prog_sigef where ID_DOMANDA_SIGFRIDO = @id_prog_sigfrido

----select @id_op_creazione = U.ID_UTENTE

INSERT INTO [PROGETTO_STORICO] 
([ID_PROGETTO]
,[COD_STATO]
,[DATA]
,[OPERATORE]
,[SEGNATURA]
,[REVISIONE]
,[RIESAME]
,[RICORSO]
,[DATA_RI]
,[OPERATORE_RI]
,[SEGNATURA_RI]
,[RIAPERTURA_PROVINCIALE]) output INSERTED.ID, inserted.ID_PROGETTO into @temptable_storico(id, id_progetto)
--VALUES
select 
@id_prog_sigef,					--id_progetto
'P',							--cod_stato
--dateadd(day,-1,gs170m.DataValidazione),	--data			
--'20150520',						--data
dateadd(day,-1,gs170m.DATA_RILASCIO),           --data
gs170m.ID_UTENTE,				--operatore
null,							--segnatura
0,								--revisione
0,								--riesame
0,								--ricorso
null,							--data_ri
null,							--operatore_ri
null,							--segnatura_ri
0								--riapertura_provinciale
from _vGrad95Filiere_1 gs170m 
where gs170m.ID_DOMANDA = @id_prog_sigfrido

union all

select 
@id_prog_sigef,					--id_progetto
'L',							--cod_stato
gs170m.DATA_RILASCIO,			--data			
--'20150521',						--data
gs170m.ID_UTENTE,				--operatore
null,							--segnatura
0,								--revisione
0,								--riesame
0,								--ricorso
null,							--data_ri
null,							--operatore_ri
null,							--segnatura_ri
0								--riapertura_provinciale
from _vGrad95Filiere_1 gs170m 
where gs170m.ID_DOMANDA = @id_prog_sigfrido

union all

select 
@id_prog_sigef,					--id_progetto
'I',							--cod_stato
DATEADD(day,1,gs170m.DATA_RICEVIBILITA),	--data			
gs170m.ID_OPERATORE_ISTRUTTORIA,--operatore
null,							--segnatura
0,								--revisione
0,								--riesame
0,								--ricorso
null,							--data_ri
null,							--operatore_ri
null,							--segnatura_ri
0								--riapertura_provinciale
from _vGrad95Filiere_1 gs170m 
where gs170m.ID_DOMANDA = @id_prog_sigfrido

union all

select 
@id_prog_sigef,					--id_progetto
'A',							--cod_stato
gs170m.DATA_AMMISSIBILITA,	--data			
gs170m.ID_OPERATORE_ISTRUTTORIA,--operatore
null,							--segnatura
0,								--revisione
0,								--riesame
0,								--ricorso
null,							--data_ri
null,							--operatore_ri
null,							--segnatura_ri
0								--riapertura_provinciale
from _vGrad95Filiere_1 gs170m 
where gs170m.ID_DOMANDA = @id_prog_sigfrido

union all

select 
@id_prog_sigef,					--id_progetto
'F',							--cod_stato
gs170m.DATA_CONCESSIONE,	--data			
gs170m.ID_OPERATORE_ISTRUTTORIA,--operatore
null,							--segnatura
0,								--revisione
0,								--riesame
0,								--ricorso
null,							--data_ri
null,							--operatore_ri
null,							--segnatura_ri
0								--riapertura_provinciale
from _vGrad95Filiere_1 gs170m 
where gs170m.ID_DOMANDA = @id_prog_sigfrido

select @id_prog_storico_ultimo = max(id) from @temptable_storico  --@SCOPE_IDENTITY()

update PROGETTO set ID_STORICO_ULTIMO = @id_prog_storico_ultimo where ID_PROGETTO = @id_prog_sigef

--INSERIMENTO DEI COLLABORATORI_X_BANDO
INSERT INTO [COLLABORATORI_X_BANDO]
           ([ID_BANDO]
           ,[ID_PROGETTO]
           ,[ID_UTENTE]
           ,[PROVINCIA]
           ,[OPERATORE_INSERIMENTO]
           ,[DATA_INSERIMENTO]
           ,[OPERATORE_FINE_VALIDITA]
           ,[DATA_FINE_VALIDITA]
           ,[ATTIVO])
     --VALUES
SELECT
gs170m.IdBandoSigef,			--(<ID_BANDO, int,>
gs170m.ID_PROGETTO_SIGEF,		--,<ID_PROGETTO, int,>
gs170m.ID_OPERATORE_ISTRUTTORIA,--,<ID_UTENTE, int,>
'AN',							--,<PROVINCIA, char(2),>
gs170m.ID_OPERATORE_ISTRUTTORIA,--,<OPERATORE_INSERIMENTO, int,>
BANDO.DATA_APERTURA,			--,<DATA_INSERIMENTO, datetime,>
NULL,							--,<OPERATORE_FINE_VALIDITA, int,>
NULL,							--,<DATA_FINE_VALIDITA, datetime,>
1								--,<ATTIVO, bit,>)
from _vGrad95Filiere_1 gs170m 
inner join BANDO ON 
gs170m.IdBandoSigef = BANDO.ID_BANDO
where gs170m.ID_DOMANDA = @id_prog_sigfrido




--;with rt as
--(
--select 
--d.ID_DOMANDA IdDomanda,
--I.RAGIONE_SOCIALE + '- Voucher id ' + CONVERT(VARCHAR(10), d.ID_PROGETTO_SIGEF) as Paragrafo, 
--1 as Ordine
--from _vGrad100 d 
--inner join vIMPRESA I on
--d.ID_IMPRESA = I.ID_IMPRESA
--where 
--d.ID_DOMANDA = @id_prog_sigfrido
--union all
--select 
--d.ID_DOMANDA IdDomanda,
--I.RAGIONE_SOCIALE + '- Voucher id ' + CONVERT(VARCHAR(10), d.ID_PROGETTO_SIGEF) as Paragrafo,
--2 as Ordine
--from _vGrad100 d 
--inner join vIMPRESA I on
--d.ID_IMPRESA = I.ID_IMPRESA
--where 
--d.ID_DOMANDA = @id_prog_sigfrido
--)
--insert into PROGETTO_RELAZIONE_TECNICA
--(
--ID_PARAGRAFO, 
--ID_PROGETTO,
--TESTO
--)
--select 
--brt.ID_PARAGRAFO ,
--vg.ID_PROGETTO_SIGEF,
--rt.Paragrafo
--from rt
--inner join 
--BANDO_RELAZIONE_TECNICA brt on
--brt.ORDINE = rt.Ordine
--inner join 
--_vGrad100 vg on
--vg.ID_DOMANDA = rt.IdDomanda
--where brt.ID_BANDO = vg.IdBandoSigef

;with rt as
(
select 
d.IdDomanda,
d.TitoloProgetto as Paragrafo, 
1 as Ordine
from [SIGFRIDO2020.DOMANDA].dbo.IdeaProgettuale d where 
IdIdeaProgettuale = IsIdeaProgettuale 
and 
d.IdDomanda = @id_prog_sigfrido
union all
select 
d.IdDomanda,
d.DescrizioneProgetto as Paragrafo, 
2 as Ordine
from [SIGFRIDO2020.DOMANDA].dbo.IdeaProgettuale d where 
IdIdeaProgettuale = IsIdeaProgettuale 
and 
d.IdDomanda = @id_prog_sigfrido
)
insert into PROGETTO_RELAZIONE_TECNICA
(
	ID_PARAGRAFO, 
	ID_PROGETTO,
	TESTO
)
select 
brt.ID_PARAGRAFO ,
vg.ID_PROGETTO_SIGEF,
rt.Paragrafo
from rt
inner join 
BANDO_RELAZIONE_TECNICA brt on
brt.ORDINE = rt.Ordine
inner join 
_vGrad95Filiere_1 vg on
vg.ID_DOMANDA = rt.IdDomanda
where brt.ID_BANDO = vg.IdBandoSigef


--INSERIMENTO AGGREGAZIONI
declare @d int
declare @id_aggtable table ( id_agg int not null)
declare @imp_agg_table table (id_impresa int not null, p_iva varchar(50) not null)
--controllo aggregazioni
;with ai as(
select 
g.ID_DOMANDA_SIGFRIDO
,COUNT(*) as NR_IMPRESE
from 
_GraduatoriaSigfrido95Filiere_1 g
where g.ID_DOMANDA_SIGFRIDO in (
select distinct ID_DOMANDA_SIGFRIDO from _GraduatoriaSigfrido95Filiere_1 g1 where 
g1.ESITO like '%ammessa e finanziata%')
group by 
g.ID_DOMANDA_SIGFRIDO
having COUNT(ID_DOMANDA_SIGFRIDO) > 1
) 


select @d =  (select ai.ID_DOMANDA_SIGFRIDO from ai where ai.ID_DOMANDA_SIGFRIDO = @id_prog_sigfrido)

if (@d is not null)
begin
INSERT INTO 
[AGGREGAZIONE]
([DENOMINAZIONE]
,[COD_TIPO_AGGREGAZIONE]
,[DATA_INIZIO]
,[OPERATORE_INIZIO]
,[ATTIVO]
,[DATA_FINE]
,[OPERATORE_FINE])
output inserted.ID into @id_aggtable(id_agg)
SELECT
'RTI per progetto sigef' + CONVERT(varchar(10),ISNULL(@id_prog_sigef,'')) + ' (Id Sigfrido: ' + CONVERT(varchar(10),@id_prog_sigfrido) + ')' AS DENOMINAZIONE, --DENOMINAZIONE
'R',													   --COD_TIPO_AGGREGAZIONE
vg.TDataInizio,			--DATA_INIZIO
vg.ID_UTENTE,				--OPERATORE_INIZIO
1,							--ATTIVO
null,						--DATA_FINE
null						--OPERATORE_FINE
from 
_vGrad95Filiere_1 vg
where vg.ID_DOMANDA = @id_prog_sigfrido

declare @id_aggr int
select @id_aggr = (select MAX(id_agg) from @id_aggtable)

INSERT INTO [IMPRESA_AGGREGAZIONE]
([ID_AGGREGAZIONE]
,[COD_RUOLO]
,[ID_IMPRESA]
,[PERCENTUALE]
,[DATA_INIZIO]
,[OPERATORE_INIZIO]
,[ATTIVO]
,[DATA_FINE]
,[OPERATORE_FINE])

--VALUES
select 
@id_aggr,														--ID_AGGREGAZIONE
case when gs.FLAG_CAPOFILA_SIGFRIDO = 1 then 'C' else 'P' end,	--COD_RUOLO
gs.ID_IMPRESA_SIGEF,											--ID_IMPRESA
null,															--PERCENTUALE
gs.DATA_INIZIO_PROGETTO,										--DATA_INIZIO
gs.ID_UTENTE_SIGEF,												--OPERATORE_INIZIO
1,																--ATTIVO
null,															--DATA_FINE
null															--OPERATORE_FINE
from 
--_GraduatoriaSigfrido95Filiere_1 gs
(
select 
s.ID_DOMANDA_SIGFRIDO,
s.DENOMINAZIONE_IMPRESA RAGIONE_SOCIALE_SIGFRIDO,
s.Codice_Fiscale CF_PIVA_SIGFRIDO,
s.P#IVA PIVA_SIGFRIDO,
s.FLAG_CAPOFILA FLAG_CAPOFILA_SIGFRIDO,
s.DATA_INIZIO_PROGETTO,
i.ID_IMPRESA ID_IMPRESA_SIGEF,
i.CODICE_FISCALE CF_PIVA_SIGEF,
ims.RAGIONE_SOCIALE RAGIONE_SOCIALE_SIGEF,
U.ID_UTENTE ID_UTENTE_SIGEF,
pf.COGNOME COGNOME_SIGEF,
pf.NOME NOME_SIGEF,
pf.CODICE_FISCALE AS CF_PERSONA_SIGEF 
from 
_GraduatoriaSigfrido95Filiere_1 s
left outer join IMPRESA i on 
s.P#IVA = i.CODICE_FISCALE
left outer join IMPRESA_STORICO IMS ON
i.id_impresa = IMs.ID_IMPRESA
and
i.ID_STORICO_ULTIMO = ims.ID_STORICO_IMPRESA
--left outer join
inner join 
PERSONE_X_IMPRESE PXI ON
i.ID_IMPRESA = pxi.ID_IMPRESA
and PXI.ATTIVO = 1 
left outer join 
PERSONA_FISICA pf on 
PXI.ID_PERSONA = pf.ID_PERSONA
left outer join 
UTENTI U on
PXI.ID_PERSONA = U.ID_PERSONA_FISICA
) gs
where gs.ID_DOMANDA_SIGFRIDO = @id_prog_sigfrido


--INSERIMENTO PRIORITA' AGGREGAZIONE PER DOMANDA
INSERT INTO [dbo].[PRIORITA_X_PROGETTO]
           ([ID_PROGETTO]
           ,[ID_PRIORITA]
           ,[ID_VALORE]
           ,[VALORE]
           ,[DATA_VALUTAZIONE]
           ,[OPERATORE_VALUTAZIONE]
           ,[MODIFICA_MANUALE]
           ,[PUNTEGGIO]
           ,[VAL_DATA]
           ,[VAL_TESTO])
     --VALUES
SELECT
@id_prog_sigef           --(<ID_PROGETTO, int,>
,333						   --,<ID_PRIORITA, int,>
,NULL						   --,<ID_VALORE, int,>
,NULL						   --,<VALORE, decimal(18,2),>
,NULL						   --,<DATA_VALUTAZIONE, datetime,>
,NULL						   --,<OPERATORE_VALUTAZIONE, varchar(16),>
,NULL						   --,<MODIFICA_MANUALE, bit,>
,NULL						   --,<PUNTEGGIO, decimal(18,6),>
,NULL						   --,<VAL_DATA, datetime,>
,CONVERT(VARCHAR(500), @id_aggr)  --,<VAL_TESTO, varchar(500),>)

union all

SELECT
@id_prog_sigef           --(<ID_PROGETTO, int,>
,435						   --,<ID_PRIORITA, int,>
,NULL						   --,<ID_VALORE, int,>
,NULL						   --,<VALORE, decimal(18,2),>
,NULL						   --,<DATA_VALUTAZIONE, datetime,>
,NULL						   --,<OPERATORE_VALUTAZIONE, varchar(16),>
,NULL						   --,<MODIFICA_MANUALE, bit,>
,NULL						   --,<PUNTEGGIO, decimal(18,6),>
,NULL						   --,<VAL_DATA, datetime,>
,NULL						   --,<VAL_TESTO, varchar(500),>)

union all

SELECT
@id_prog_sigef           --(<ID_PROGETTO, int,>
,400						   --,<ID_PRIORITA, int,>
,NULL						   --,<ID_VALORE, int,>
,NULL						   --,<VALORE, decimal(18,2),>
,NULL						   --,<DATA_VALUTAZIONE, datetime,>
,NULL						   --,<OPERATORE_VALUTAZIONE, varchar(16),>
,NULL						   --,<MODIFICA_MANUALE, bit,>
,NULL						   --,<PUNTEGGIO, decimal(18,6),>
,gs.DATA_INIZIO_PROGETTO	   --,<VAL_DATA, datetime,>
,NULL						   --,<VAL_TESTO, varchar(500),>)
FROM 
_vGrad95Filiere_1 gs where gs.ID_DOMANDA = @id_prog_sigfrido

union all

SELECT
@id_prog_sigef           --(<ID_PROGETTO, int,>
,401						   --,<ID_PRIORITA, int,>
,NULL						   --,<ID_VALORE, int,>
,NULL						   --,<VALORE, decimal(18,2),>
,NULL						   --,<DATA_VALUTAZIONE, datetime,>
,NULL						   --,<OPERATORE_VALUTAZIONE, varchar(16),>
,NULL						   --,<MODIFICA_MANUALE, bit,>
,NULL						   --,<PUNTEGGIO, decimal(18,6),>
,gs.DATA_FINE_PROGETTO	   --,<VAL_DATA, datetime,>
,NULL						   --,<VAL_TESTO, varchar(500),>)
FROM 
_vGrad95Filiere_1 gs  where gs.ID_DOMANDA = @id_prog_sigfrido


end

; with imp_agg as
(
SELECT
gs.ID_DOMANDA_SIGFRIDO,
gs.ID_PROGETTO_SIGEF,
gs.P#IVA AS P_IVA,
IMP_AGG.ID_IMPRESA 
FROM _GraduatoriaSigfrido95Filiere_1 gs
INNER JOIN 
(
  SELECT
  IA.ID_AGGREGAZIONE,
  IA.ID_IMPRESA, 
  I.CUAA,
  I.CODICE_FISCALE
  FROM 
  IMPRESA_AGGREGAZIONE IA
  INNER JOIN vIMPRESA I ON
  IA.ID_IMPRESA = I.ID_IMPRESA
  WHERE IA.ID_AGGREGAZIONE = @id_aggr  
) IMP_AGG ON
gs.P#IVA = IMP_AGG.CODICE_FISCALE
where gs.ID_PROGETTO_SIGEF = @id_prog_sigef
)



INSERT INTO [PIANO_INVESTIMENTI]
([ID_PROGETTO]
,[ID_PROGRAMMAZIONE]
,[DESCRIZIONE]
,[DATA_VARIAZIONE]
,[OPERATORE_VARIAZIONE]
,[COD_TIPO_INVESTIMENTO]
,[COD_STP]
,[ID_UNITA_MISURA]
,[QUANTITA]
,[COSTO_INVESTIMENTO]
,[SPESE_GENERALI]
,[CONTRIBUTO_RICHIESTO]
,[QUOTA_CONTRIBUTO_RICHIESTO]
,[TASSO_ABBUONO]
,[ID_SETTORE_PRODUTTIVO]
,[ID_PRIORITA_SETTORIALE]
,[ID_OBIETTIVO_MISURA]
,[ID_CODIFICA_INVESTIMENTO]
,[ID_DETTAGLIO_INVESTIMENTO]
,[ID_SPECIFICA_INVESTIMENTO]
,[AMMESSO]
,[ISTRUTTORE]
,[ID_INVESTIMENTO_ORIGINALE]
,[DATA_VALUTAZIONE]
,[VALUTAZIONE_INVESTIMENTO]
,[ID_VARIANTE]
,[COD_VARIAZIONE]
,[NON_COFINANZIATO]) output inserted.ID_INVESTIMENTO, inserted.ID_PROGETTO, inserted.AMMESSO, inserted.OPERATORE_VARIAZIONE into @temptable_investimenti(id_inv, id_progetto, ammesso, op_var)
select
@id_prog_sigef					--id_progetto
--,imp_agg.ID_IMPRESA
--,imp_agg.P_IVA
,vbp.ID_PROGRAMMAZIONE			--id_programmazione
,ci.DESCRIZIONE					--descrizione
,null							--DATA_VARIAZIONE
,imp_agg.P_IVA					--OPERATORE_VARIAZIONE
,1								--COD_TIPO_INVESTIMENTO
,'00'							--COD_STP
,8								--ID_UNITA_MISURA
,1								--QUANTITA
--,gs170m.INVESTIMENTO_RICHIESTO	--COSTO_INVESTIMENTO
,gs95.Investimento_proposto
,0								--SPESE_GENERALI
--,gs170m.CONTRIBUTO_RICHIESTO	--CONTRIBUTO_RICHIESTO
,gs95.Contributo_richiesto
--,ci.AIUTO_MINIMO				--QUOTA_CONTRIBUTO_RICHIESTO
,gs95.Percen#					--QUOTA_CONTRIBUTO_RICHIESTO
,null							--TASSO_ABBUONO
,null							--ID_SETTORE_PRODUTTIVO
,null							--ID_PRIORITA_SETTORIALE
,om.ID							--ID_OBIETTIVO_MISURA
,ci.ID_CODIFICA_INVESTIMENTO	--ID_CODIFICA_INVESTIMENTO
,di.ID_DETTAGLIO_INVESTIMENTO	--ID_DETTAGLIO_INVESTIMENTO
,null							--ID_SPECIFICA_INVESTIMENTO
,null							--AMMESSO
,null							--ISTRUTTORE
,null							--ID_INVESTIMENTO_ORIGINALE
,null							--DATA_VALUTAZIONE
,null							--VALUTAZIONE_INVESTIMENTO
,null							--ID_VARIANTE
,null							--COD_VARIAZIONE
,0								--NON_COFINANZIATO
from
_vGrad95Filiere_1 gs170m 
inner join 
_GraduatoriaSigfrido95Filiere_1 gs95 on
gs170m.ID_DOMANDA = gs95.ID_DOMANDA_SIGFRIDO
inner join CODIFICA_INVESTIMENTO ci on 
gs170m.IdBandoSigef = ci.ID_BANDO
inner join vBANDO_PROGRAMMAZIONE vbp on 
gs170m.IdBandoSigef = vbp.ID_BANDO
inner join DETTAGLIO_INVESTIMENTI di on
ci.ID_CODIFICA_INVESTIMENTO = di.ID_CODIFICA_INVESTIMENTO
inner join 
zOB_MISURA om on 
vbp.ID_PADRE = om.ID_PROGRAMMAZIONE
inner join imp_agg on
gs95.P#IVA = imp_agg.P_IVA
where gs170m.ID_DOMANDA = @id_prog_sigfrido

union all

select
@id_prog_sigef					--id_progetto
--,imp_agg.ID_IMPRESA
--,imp_agg.P_IVA
,vbp.ID_PROGRAMMAZIONE			--id_programmazione
,ci.DESCRIZIONE					--descrizione
,null							--DATA_VARIAZIONE
,imp_agg.P_IVA					--OPERATORE_VARIAZIONE
,1								--COD_TIPO_INVESTIMENTO
,'00'							--COD_STP
,8								--ID_UNITA_MISURA
,1								--QUANTITA
,gs95.Investimento_ammesso		--COSTO_INVESTIMENTO
,0								--SPESE_GENERALI
,gs95.Contributo_concesso	  	--CONTRIBUTO_RICHIESTO
--,ci.AIUTO_MINIMO				--QUOTA_CONTRIBUTO_RICHIESTO
,gs95.Percen#					--QUOTA_CONTRIBUTO_RICHIESTO
,null							--TASSO_ABBUONO
,null							--ID_SETTORE_PRODUTTIVO
,null							--ID_PRIORITA_SETTORIALE
,om.ID							--ID_OBIETTIVO_MISURA
,ci.ID_CODIFICA_INVESTIMENTO	--ID_CODIFICA_INVESTIMENTO
,di.ID_DETTAGLIO_INVESTIMENTO	--ID_DETTAGLIO_INVESTIMENTO
,null							--ID_SPECIFICA_INVESTIMENTO
,1								--AMMESSO
,gs170m.CF_OPERATORE_ISTRUTTORIA--ISTRUTTORE
,null							--ID_INVESTIMENTO_ORIGINALE
,null							--DATA_VALUTAZIONE
,null							--VALUTAZIONE_INVESTIMENTO
,null							--ID_VARIANTE
,null							--COD_VARIAZIONE
,0								--NON_COFINANZIATO
from
_vGrad95Filiere_1 gs170m 
inner join 
_GraduatoriaSigfrido95Filiere_1 gs95 on
gs170m.ID_DOMANDA = gs95.ID_DOMANDA_SIGFRIDO
inner join CODIFICA_INVESTIMENTO ci on 
gs170m.IdBandoSigef = ci.ID_BANDO
inner join vBANDO_PROGRAMMAZIONE vbp on 
gs170m.IdBandoSigef = vbp.ID_BANDO
inner join DETTAGLIO_INVESTIMENTI di on
ci.ID_CODIFICA_INVESTIMENTO = di.ID_CODIFICA_INVESTIMENTO
inner join 
zOB_MISURA om on 
vbp.ID_PADRE = om.ID_PROGRAMMAZIONE
inner join imp_agg on
gs95.P#IVA = imp_agg.P_IVA
where gs170m.ID_DOMANDA = @id_prog_sigfrido

declare @temptable_investimenti_ammessi table (id_inv int null, id_progetto int null, ammesso bit null, op_var varchar(16) null, id_inv_orig int null)
insert into @temptable_investimenti_ammessi 
select ti.*, null from @temptable_investimenti ti where ammesso = 1

update @temptable_investimenti_ammessi set id_inv_orig = 
ti.id_inv from @temptable_investimenti ti inner join 
@temptable_investimenti_ammessi ta on 
ti.op_var = ta.op_var 
where
ti.ammesso is null  


update PIANO_INVESTIMENTI set ID_INVESTIMENTO_ORIGINALE = 
t.id_inv_orig from 
@temptable_investimenti_ammessi t 
inner join PIANO_INVESTIMENTI p on
p.ID_INVESTIMENTO = t.id_inv 
--and
--t.op_var = p.OPERATORE_VARIAZIONE 
--and 
--t.ammesso = null
--where 
--p.ammesso = 1   


--update PIANO_INVESTIMENTI set ID_INVESTIMENTO_ORIGINALE = (select MIN(id_inv) from @temptable_investimenti) 
--where ID_INVESTIMENTO = (select MAX(id_inv) from @temptable_investimenti)

--INSERIMENTO PRIORITA_X_INVESTIMENTI IN CASO DI AGGREGAZIONE

if (@d is not null)
begin

INSERT INTO [dbo].[PRIORITA_X_INVESTIMENTI]
           ([ID_PRIORITA]
           ,[ID_INVESTIMENTO]
           ,[ID_VALORE]
           ,[SCELTO]
           ,[VALORE]
           ,[VAL_DATA]
           ,[VAL_TESTO])
     --VALUES
SELECT
334	           --(<ID_PRIORITA, int,>
,id_inv        --,<ID_INVESTIMENTO, int,>
,null          --,<ID_VALORE, int,>
,null          --,<SCELTO, bit,>
,null          --,<VALORE, decimal(18,2),>
,null          --,<VAL_DATA, datetime,>
,op_var		   --,<VAL_TESTO, varchar(500),>)
from 
@temptable_investimenti

--ELIMINO 
UPDATE PIANO_INVESTIMENTI SET OPERATORE_VARIAZIONE = NULL WHERE ID_INVESTIMENTO IN
(
select id_inv from @temptable_investimenti
) 


end



--INSERIMENTO DATI MONITORAGGIO FESR

;with modfesr170 as
(
select 
dm.IdDomanda,
CupNatura.CodiceQsn CodNaturaCup,
CupNatura.Descrizione CodNaturaCupDescSigfrido,
tcn.COD_CUP_NATURA CUP_NATURA_SIGEF,
tcn.Descrizione CUP_NATURA_SIGEF_DESC,
CupCategoria.CodiceQsn CodCategoriaCup,
CupCategoria.Descrizione CodCategoriaCupDescSigfrido,
tc.COD_CUP_CATEGORIE CUP_CAT_SIGEF,
tc.Descrizione CUP_CAT_SIGEF_DESC,
CupSottoCategoriaSoggetti.CodiceQsn CodSottoCategoriaSoggettiCup,
CupSottoCategoriaSoggetti.Descrizione CodSottoCategoriaSoggettiCupDescSigfrido,
tcs.COD_CUP_CATEGORIE_SOGGETTI CUP_CAT_SOGG_SIGEF,
tcs.Descrizione CUP_CAT_SOGG_SIGEF_DESC,
CupTipoOperazionePrev.CodiceQsn CodTipoOpPrev,
CupTipoOperazionePrev.Descrizione CodTipoOpPrevSigfrido,
tcpo.COD_CUP_CATEGORIE_TIPIOPERAZIONI CUP_TIPO_OP_SIGEF,
tcpo.Descrizione CUP_TIPO_OP_SIGEF_DESC,
CupTemaPrioritario.CodiceQsn TemaPrioritarioCup,
CupTemaPrioritario.Descrizione TemaPrioritarioCupDescSigfrido,
ttp.COD_TEMA_PRIORITARIO CUP_TEMA_PRIORITARIO_SIGEF,
ttp.Descrizione CUP_TEMA_PRIORITARIO_SIGEF_DESC,
CptSettore.CodiceQsn IdValoreCptSettoreCup,
CptSettore.Descrizione CptSettoreCupDescSigfrido,
cps.COD_CPT_SETTORE CUP_CPT_SETTORE_SIGEF,
cps.Descrizione CUP_CPT_SETTORE_SIGEF_DESC,
DimTerritoriale.CodiceQsn DimTerritorialeCup,
DimTerritoriale.Descrizione DescDimTerrSigfrido,
cdt.COD_CUP_DIMENSIONE_TERR CUP_DIM_TERR_SIGEF,
cdt.Descrizione CUP_DIM_TERR_SIGEF_DESC,
AttivitaEcon.CodiceQsn AttivitaEconCup,
AttivitaEcon.Descrizione DescAttivitaEconSigfrido,
tae.COD_ATTIVITA_ECON CUP_ATTIVITA_ECON_SIGEF,
tae.DescrizioneSigef CUP_ATTIVITA_ECON_SIGEF_DESC,
Ateco.CodiceQsn CodAteco,
Ateco.Descrizione DescAteco,
ta2007.COD_TIPO_ATECO2007 COD_TIPO_ATECO2007_SIGEF,
ta2007.Descrizione COD_TIPO_ATECO2007_SIGEF_DESC
from 
[SIGFRIDO2020.DOMANDA].dbo.DatiMonitoraggio dm
left outer join 
[SIGFRIDO2020.DOMANDA].dbo.DominiValori CupNatura on
dm.CupIdNatura = CupNatura.IdDominioValore
left outer join 
[SIGFRIDO2020.DOMANDA].dbo.DominiValori CupCategoria on
dm.CupIdCategoria = CupCategoria.IdDominioValore
left outer join 
[SIGFRIDO2020.DOMANDA].dbo.DominiValori CupSottoCategoriaSoggetti on
dm.CupIdSottoCategoriaSoggetti = CupSottoCategoriaSoggetti.IdDominioValore
left outer join 
[SIGFRIDO2020.DOMANDA].dbo.DominiValori CupTipoOperazionePrev on
dm.CupIdTipoOperazionePrevalente = CupTipoOperazionePrev.IdDominioValore
left outer join 
[SIGFRIDO2020.DOMANDA].dbo.DominiValori CupTemaPrioritario on
dm.IdTemaPrioritario = CupTemaPrioritario.IdDominioValore
left outer join 
[SIGFRIDO2020.DOMANDA].dbo.DominiValori CptSettore on
dm.IdSettoreCpt = CptSettore.IdDominioValore
left outer join 
[SIGFRIDO2020.DOMANDA].dbo.DominiValori DimTerritoriale on
dm.IdDimensioneTerritoriale = DimTerritoriale.IdDominioValore
left outer join 
[SIGFRIDO2020.DOMANDA].dbo.DominiValori AttivitaEcon on
dm.IdAttivitaEconomica = AttivitaEcon.IdDominioValore
left outer join 
[SIGFRIDO2020.DOMANDA].dbo.DominiValori Ateco on
dm.IdAtecoProgetto = Ateco.IdDominioValore
left outer join
TIPO_CUP_CATEGORIE tc on
CupCategoria.CodiceQsn collate Latin1_General_CI_AS = tc.COD_CUP_CATEGORIE
left outer join 
TIPO_CUP_NATURA tcn on
CupNatura.CodiceQsn collate Latin1_General_CI_AS = tcn.COD_CUP_NATURA
left outer join 
TIPO_CUP_CATEGORIE_SOGGETTI tcs on
CupSottoCategoriaSoggetti.CodiceQsn collate Latin1_General_CI_AS = tcs.COD_CUP_CATEGORIE_SOGGETTI
left outer join 
TIPO_CUP_CATEGORIE_TIPIOPERAZIONI tcpo on
CupTipoOperazionePrev.CodiceQsn collate Latin1_General_CI_AS = tcpo.COD_CUP_CATEGORIE_TIPIOPERAZIONI
left outer join 
TIPO_TEMA_PRIORITARIO ttp on
CupTemaPrioritario.CodiceQsn collate Latin1_General_CI_AS = ttp.COD_TEMA_PRIORITARIO
left outer join 
TIPO_CPT_SETTORE cps on
CptSettore.CodiceQsn collate Latin1_General_CI_AS = cps.COD_CPT_SETTORE
left outer join 
TIPO_CUP_DIMENSIONE_TERR cdt on
DimTerritoriale.CodiceQsn collate Latin1_General_CI_AS = cdt.COD_CUP_DIMENSIONE_TERR
left outer join
--TIPO_ATTIVITA_ECON tae on
--AttivitaEcon.CodiceQsn collate Latin1_General_CI_AS = tae.COD_ATTIVITA_ECON
_CodificaTipiAttEcon tae on
AttivitaEcon.CodiceQsn collate Latin1_General_CI_AS = tae.Codice
left outer join 
TIPO_ATECO2007 ta2007 on
--replace(Ateco.CodiceQsn,'-','') collate Latin1_General_CI_AS = ta2007.COD_TIPO_ATECO2007
replace(replace(Ateco.CodiceQsn,'-',''),'00.00','XX.XX') collate Latin1_General_CI_AS = ta2007.COD_TIPO_ATECO2007
inner join _vGrad95Filiere_1 g on
dm.IdDomanda = g.ID_DOMANDA
where 
dm.IdDatiMonitoraggio = dm.IsDatiMonitoraggio
and dm.TCancellato = 0
and dm.TDataFine is null
and
dm.IdDomanda =@id_prog_sigfrido
)


INSERT INTO DATI_MONITORAGGIO_FESR
([ID_PROGETTO]
,[CUP_CATEGORIA]
,[CUP_CATEGORIA_SOGGETTO]
,[TEMA_PRIORITARIO]
,[ID_ATECO]
,[ATTIVITA_ECON]
,[CPT_SETTORE]
,[CUP_DIMENSIONE_TERR]
,[CUP_NATURA]
,[CUP_CATEGORIA_TIPOOPER])
--VALUES
select 
@id_prog_sigef,					  --ID_PROGETTO
mf170.CUP_CAT_SIGEF,			  --CUP_CATEGORIA
mf170.CUP_CAT_SOGG_SIGEF,		  --CUP_CATEGORIA_SOGGETTO
mf170.CUP_TEMA_PRIORITARIO_SIGEF, --TEMA_PRIORITARIO
mf170.COD_TIPO_ATECO2007_SIGEF,	  --ID_ATECO
mf170.CUP_ATTIVITA_ECON_SIGEF,	  --ATTIVITA_ECON
mf170.CUP_CPT_SETTORE_SIGEF,	  --CPT_SETTORE
mf170.CUP_DIM_TERR_SIGEF,		  --CUP_DIMENSIONE_TERR
mf170.CUP_NATURA_SIGEF,			  --CUP_NATURA
mf170.CUP_TIPO_OP_SIGEF			  --CUP_CATEGORIA_TIPOOPER
from modfesr170 mf170
where mf170.IdDomanda = @id_prog_sigfrido

--INSERIMENTO LOCALIZZAZIONE PROGETTO
;with lp as
(
select  
li.IdDomanda,
li.IdComune,
li.IdTipoIndirizzo,
li.Indirizzo,
li.NumeroCivico,
--li.Cap,
C.CAP,
cc.codcomune,
cc.codprov,
cc.descComune,
cc.descPro,
C.ID_COMUNE,
C.DENOMINAZIONE,
C.ATTIVO,
li.IdSoggetto,
imp.RAGIONE_SOCIALE_SIGFRIDO,
imp.ID_IMPRESA_SIGEF,
dgt.ID_DUG,
gs.ID_PROGETTO_SIGEF
from [SIGFRIDO2020.DOMANDA].dbo.LocalizzazioniInterventi li 
inner join
--left join 
( select 
dv.IdDominioValore,
dv.Codice codcomune,
prov.Codice codprov,
dv.Descrizione descComune,
prov.Descrizione descPro
from
[SIGFRIDO2020.DOMANDA].dbo.DominiValori dv 
inner join 
[SIGFRIDO2020.DOMANDA].dbo.DominiValori prov on
dv.IdDominioValorePadre = prov.IdDominioValore
and 
prov.IdDominioValore = prov.IsDominioValore
and
prov.TCancellato = 0 
and dv.IdDominio = 5
and 
dv.IdDominioValore = dv.IsDominioValore
--and 
--dv.TCancellato = 0
) cc on
li.IdComune = cc.IdDominioValore
inner join _vGrad95Filiere_1 gs on
li.IdDomanda = gs.ID_DOMANDA
inner join COMUNI C on
cc.codcomune collate Latin1_General_CI_AS = C.ISTAT
and
cc.codprov collate Latin1_General_CI_AS = C.COD_PROVINCIA
and
1 = CASE WHEN C.DENOMINAZIONE IN('RIPE','SALTARA') THEN  1 ELSE C.ATTIVO END
--left outer join 
inner join
(
select 
s.IdSoggetto,
s.IdDomanda ID_DOMANDA_SIGFRIDO,
s.Denominazione RAGIONE_SOCIALE_SIGFRIDO,
s.CodiceFiscale CF_PIVA_SIGFRIDO,
s.PartitaIva PIVA_SIGFRIDO,
s.Capofila FLAG_CAPOFILA_SIGFRIDO,
s.TCancellato,
i.ID_IMPRESA ID_IMPRESA_SIGEF,
--2251 ID_IMPRESA_SIGEF,
i.CODICE_FISCALE CF_PIVA_SIGEF,
ims.RAGIONE_SOCIALE RAGIONE_SOCIALE_SIGEF,
U.ID_UTENTE ID_UTENTE_SIGEF,
pf.COGNOME COGNOME_SIGEF,
pf.NOME NOME_SIGEF,
pf.CODICE_FISCALE AS CF_PERSONA_SIGEF 
from 
[SIGFRIDO2020.DOMANDA].dbo.Soggetti s
left outer join IMPRESA i on 
s.partitaiva collate Latin1_General_CI_AS = i.CODICE_FISCALE
left outer join IMPRESA_STORICO IMS ON
i.id_impresa = IMs.ID_IMPRESA
and
i.ID_STORICO_ULTIMO = ims.ID_STORICO_IMPRESA
--left outer join 
inner join 
PERSONE_X_IMPRESE PXI ON
i.ID_IMPRESA = pxi.ID_IMPRESA
and PXI.ATTIVO = 1
left outer join 
PERSONA_FISICA pf on 
PXI.ID_PERSONA = pf.ID_PERSONA
left outer join 
UTENTI U on
PXI.ID_PERSONA = U.ID_PERSONA_FISICA
inner join _GraduatoriaSigfrido95Filiere_1 gs on
s.IdDomanda = gs.ID_DOMANDA_SIGFRIDO
where gs.ESITO like '%ammessa e finanziata%' 
and IdSoggetto = IsSoggetto
and s.TCancellato = 0
) imp on
li.IdSoggetto = imp.IdSoggetto
and li.IdDomanda = imp.ID_DOMANDA_SIGFRIDO
and imp.TCancellato = 0
left outer join 
(
select 
dug.IdDominioValore idDug,
dug.CodiceQsn,
dug.Descrizione DescSigfrido,
td.ID_DUG,
td.ID_QSN,
td.Descrizione
from [SIGFRIDO2020.DOMANDA].dbo.DominiValori dug
inner join TIPO_DUG td ON
dug.CodiceQsn collate Latin1_General_CI_AS = td.ID_QSN 
and td.ID_DUG in (6,7,8,9,10)
where 
dug.IdDominio = 16
and 
dug.IdDominioValore = dug.IsDominioValore
and
dug.TCancellato = 0 
) dgt on
li.IdTipoIndirizzo = dgt.idDug
where 
li.IdLocalizzazioneIntervento = li.IsLocalizzazioneIntervento
and li.TCancellato = 0
and li.TDataFine is null
--and imp.ID_IMPRESA_SIGEF is null
--and li.IdDomanda = 16912
--and imp.ID_IMPRESA_SIGEF is null
--and li.IdDomanda = 16031
--order by li.IdDomanda
and li.IdDomanda = @id_prog_sigfrido
)
INSERT INTO [LOCALIZZAZIONE_PROGETTO]
           ([ID_PROGETTO]
           ,[ID_IMPRESA]
           ,[ID_COMUNE]
           ,[CAP]
           ,[DUG]
           ,[VIA]
           ,[NUM]
           ,[CATASTO_ID]
           ,[CATASTO_FOGLIO]
           ,[CATASTO_PARTICELLA]
           ,[CATASTO_SEZIONE]
           ,[CATASTO_SUBALTERNO]
           ,[CATASTO_SUPERFICIE]
           ,[QUOTA])
	select      
    @id_prog_sigef,
    lp.ID_IMPRESA_SIGEF,
    lp.ID_COMUNE,
    lp.CAP,
    lp.ID_DUG,
    lp.Indirizzo,
    lp.NumeroCivico,
    null,
    null,
    null,
    null,
    null,
    null,
    100
    from 
    lp


----INSERIMENTO AGGREGAZIONI
--declare @d int
--declare @id_aggtable table ( id_agg int not null)
----controllo aggregazioni
--;with ai as(
--select 
--g.ID_DOMANDA_SIGFRIDO
--,COUNT(*) as NR_IMPRESE
--from 
--_GraduatoriaSigfrido95Filiere_1 g
--where g.ID_DOMANDA_SIGFRIDO in (
--select distinct ID_DOMANDA_SIGFRIDO from _GraduatoriaSigfrido95Filiere_1 g1 where 
--g1.ESITO like '%ammessa e finanziata%')
--group by 
--g.ID_DOMANDA_SIGFRIDO
--having COUNT(ID_DOMANDA_SIGFRIDO) > 1
--) 


--select @d =  (select ai.ID_DOMANDA_SIGFRIDO from ai where ai.ID_DOMANDA_SIGFRIDO = @id_prog_sigfrido)

--if (@d is not null)
--begin
--INSERT INTO 
--[AGGREGAZIONE]
--([DENOMINAZIONE]
--,[COD_TIPO_AGGREGAZIONE]
--,[DATA_INIZIO]
--,[OPERATORE_INIZIO]
--,[ATTIVO]
--,[DATA_FINE]
--,[OPERATORE_FINE])
--output inserted.ID into @id_aggtable(id_agg)
--SELECT
--'RTI per progetto sigef' + CONVERT(varchar(10),ISNULL(@id_prog_sigef,'')) + ' (Id Sigfrido: ' + CONVERT(varchar(10),@id_prog_sigfrido) + ')' AS DENOMINAZIONE, --DENOMINAZIONE
--'R',													   --COD_TIPO_AGGREGAZIONE
--vg.TDataInizio,			--DATA_INIZIO
--vg.ID_UTENTE,				--OPERATORE_INIZIO
--1,							--ATTIVO
--null,						--DATA_FINE
--null						--OPERATORE_FINE
--from 
--_vGrad95Filiere_1 vg
--where vg.ID_DOMANDA = @id_prog_sigfrido

--declare @id_aggr int
--select @id_aggr = (select MAX(id_agg) from @id_aggtable)

--INSERT INTO [IMPRESA_AGGREGAZIONE]
--([ID_AGGREGAZIONE]
--,[COD_RUOLO]
--,[ID_IMPRESA]
--,[PERCENTUALE]
--,[DATA_INIZIO]
--,[OPERATORE_INIZIO]
--,[ATTIVO]
--,[DATA_FINE]
--,[OPERATORE_FINE])
----VALUES
--select 
--@id_aggr,														--ID_AGGREGAZIONE
--case when gs.FLAG_CAPOFILA_SIGFRIDO = 1 then 'C' else 'P' end,	--COD_RUOLO
--gs.ID_IMPRESA_SIGEF,											--ID_IMPRESA
--null,															--PERCENTUALE
--gs.DATA_INIZIO_PROGETTO,												--DATA_INIZIO
--gs.ID_UTENTE_SIGEF,												--OPERATORE_INIZIO
--1,																--ATTIVO
--null,															--DATA_FINE
--null															--OPERATORE_FINE
--from 
----_GraduatoriaSigfrido95Filiere_1 gs
--(
--select 
--s.ID_DOMANDA_SIGFRIDO,
--s.DENOMINAZIONE_IMPRESA RAGIONE_SOCIALE_SIGFRIDO,
--s.Codice_Fiscale CF_PIVA_SIGFRIDO,
--s.P#IVA PIVA_SIGFRIDO,
--s.FLAG_CAPOFILA FLAG_CAPOFILA_SIGFRIDO,
--s.DATA_INIZIO_PROGETTO,
--i.ID_IMPRESA ID_IMPRESA_SIGEF,
--i.CODICE_FISCALE CF_PIVA_SIGEF,
--ims.RAGIONE_SOCIALE RAGIONE_SOCIALE_SIGEF,
--U.ID_UTENTE ID_UTENTE_SIGEF,
--pf.COGNOME COGNOME_SIGEF,
--pf.NOME NOME_SIGEF,
--pf.CODICE_FISCALE AS CF_PERSONA_SIGEF 
--from 
--_GraduatoriaSigfrido95Filiere_1 s
--left outer join IMPRESA i on 
--s.P#IVA = i.CODICE_FISCALE
--left outer join IMPRESA_STORICO IMS ON
--i.id_impresa = IMs.ID_IMPRESA
--and
--i.ID_STORICO_ULTIMO = ims.ID_STORICO_IMPRESA
--left outer join 
--PERSONE_X_IMPRESE PXI ON
--i.ID_IMPRESA = pxi.ID_IMPRESA
--left outer join 
--PERSONA_FISICA pf on 
--PXI.ID_PERSONA = pf.ID_PERSONA
--left outer join 
--UTENTI U on
--PXI.ID_PERSONA = U.ID_PERSONA_FISICA
--) gs
--where gs.ID_DOMANDA_SIGFRIDO = @id_prog_sigfrido

--end

--aggiornamento e backup della data nello storico utente

;with ute as (
select 
gs.ID_DOMANDA_SIGFRIDO,
gs.ID_PROGETTO_SIGEF,
uts.ID_UTENTE_STORICO,
i.ID_IMPRESA ID_IMPRESA_SIGEF,
i.CODICE_FISCALE CF_PIVA_SIGEF,
U.ID_UTENTE ID_UTENTE_SIGEF,
uts.DATA_US,
uts.DATA_STATO_PROGETTO 
from 
--[SIGFRIDO2020.DOMANDA].dbo.Soggetti s
_GraduatoriaSigfrido95Filiere_1 gs
left outer join IMPRESA i on 
gs.P#IVA = i.CODICE_FISCALE
left outer join IMPRESA_STORICO IMS ON
i.id_impresa = IMs.ID_IMPRESA
and
i.ID_STORICO_ULTIMO = ims.ID_STORICO_IMPRESA
left outer join 
PERSONE_X_IMPRESE PXI ON
i.ID_IMPRESA = pxi.ID_IMPRESA
left outer join 
PERSONA_FISICA pf on 
PXI.ID_PERSONA = pf.ID_PERSONA
left outer join 
UTENTI U on
PXI.ID_PERSONA = U.ID_PERSONA_FISICA
--inner join _GraduatoriaSigfrido95Filiere_1 gs on 
--s.IdDomanda = gs.ID_DOMANDA_SIGFRIDO
left outer join 
(
SELECT TOP 1 
P.ID_PROGETTO,
S.OPERATORE,
US.ID ID_UTENTE_STORICO,
S.COD_STATO,
US.DATA DATA_US,
S.DATA DATA_STATO_PROGETTO
FROM PROGETTO P 
INNER JOIN PROGETTO_STORICO S ON 
P.ID_PROGETTO=S.ID_PROGETTO AND COD_STATO IN ('P','L')
INNER JOIN UTENTI_STORICO US ON 
S.OPERATORE=US.ID_UTENTE
WHERE 
P.ID_PROGETTO=@id_prog_sigef
ORDER BY 
S.DATA DESC,
US.DATA DESC
) uts on
u.ID_UTENTE = uts.OPERATORE
where 
--ESITO like '%ammessa e finanziata%' 
--and IdSoggetto = IsSoggetto
--and s.TCancellato = 0
--and 
gs.ID_PROGETTO_SIGEF = @id_prog_sigef
)

insert into @table_ute
select * from ute

update gs 
set BK_DATA_UTENTE_STORICO = utx.data_us FROM 
_GraduatoriaSigfrido95Filiere_1 gs inner join @table_ute utx on
gs.P#IVA = utx.cf_piva_sigef
and utx.data_us > utx.data_stato_progetto

update UTENTI_STORICO 
set DATA =  DATEADD(DAY,-3,utx.DATA_STATO_PROGETTO) from UTENTI_STORICO
inner join  @table_ute utx on 
UTENTI_STORICO.ID = utx.id_utente_storico
and utx.data_us > utx.data_stato_progetto



commit tran [Tran1]

end try
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran1]
  PRINT ERROR_MESSAGE()
END CATCH  

END



