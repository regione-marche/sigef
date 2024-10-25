

CREATE PROCEDURE [dbo].[_zImportProgettoSigfrido170Mobile]
	
	@id_prog_sigfrido int
	
AS
BEGIN

declare @id_prog_sigef int = null
--declare @id_prog_sigfrido int = 16411--null
declare @id_prog_storico_ultimo int = null
declare @temptable_storico table (id int null, id_progetto int null)
declare @temptable_investimenti table (id_inv int null, id_progetto int null)
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
_vGrad170Mobile gs170m
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

update _GraduatoriaSigfrido170Mobile set ID_PROGETTO_SIGEF = @id_prog_sigef where ID_DOMANDA = @id_prog_sigfrido

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
dateadd(day,-1,gs170m.DataValidazione),	--data			
gs170m.ID_UTENTE,				--operatore
null,							--segnatura
0,								--revisione
0,								--riesame
0,								--ricorso
null,							--data_ri
null,							--operatore_ri
null,							--segnatura_ri
0								--riapertura_provinciale
from _vGrad170Mobile gs170m 
where gs170m.ID_DOMANDA = @id_prog_sigfrido

union all

select 
@id_prog_sigef,					--id_progetto
'L',							--cod_stato
gs170m.DataValidazione,			--data			
gs170m.ID_UTENTE,				--operatore
gs170m.SEGNATURA,				--segnatura
0,								--revisione
0,								--riesame
0,								--ricorso
null,							--data_ri
null,							--operatore_ri
null,							--segnatura_ri
0								--riapertura_provinciale
from _vGrad170Mobile gs170m 
where gs170m.ID_DOMANDA = @id_prog_sigfrido

union all

select 
@id_prog_sigef,					--id_progetto
'I',							--cod_stato
DATEADD(day,1,gs170m.DATA_RICEVIBILITA),	--data			
gs170m.ID_OPERATORE_ISTRUTTORIA,	--operatore
null,							--segnatura
0,								--revisione
0,								--riesame
0,								--ricorso
null,							--data_ri
null,							--operatore_ri
null,							--segnatura_ri
0								--riapertura_provinciale
from _vGrad170Mobile gs170m 
where gs170m.ID_DOMANDA = @id_prog_sigfrido

union all

select 
@id_prog_sigef,					--id_progetto
'A',							--cod_stato
gs170m.DATA_AMMISSIBILITA,	--data			
gs170m.ID_OPERATORE_ISTRUTTORIA,	--operatore
null,							--segnatura
0,								--revisione
0,								--riesame
0,								--ricorso
null,							--data_ri
null,							--operatore_ri
null,							--segnatura_ri
0								--riapertura_provinciale
from _vGrad170Mobile gs170m 
where gs170m.ID_DOMANDA = @id_prog_sigfrido

--union all

--select 
--@id_prog_sigef,					--id_progetto
--'F',							--cod_stato
--gs170m.DATA_ATTO_CONCESSIONE,	--data			
--gs170m.ID_OPERATORE_ISTRUTTORIA,--operatore
--null,							--segnatura
--0,								--revisione
--0,								--riesame
--0,								--ricorso
--null,							--data_ri
--null,							--operatore_ri
--null,							--segnatura_ri
--0								--riapertura_provinciale
--from _vGrad170Mobile gs170m 
--where gs170m.ID_DOMANDA = @id_prog_sigfrido

select @id_prog_storico_ultimo = max(id) from @temptable_storico  --@SCOPE_IDENTITY()

update PROGETTO set ID_STORICO_ULTIMO = @id_prog_storico_ultimo where ID_PROGETTO = @id_prog_sigef
PRINT @id_prog_sigef

;with rt as
(
select 
d.IdDomanda,
d.TitoloProgetto as Paragrafo, 
1 as Ordine
from [SIGFRIDO.DOMANDA].dbo.IdeaProgettuale d where 
IdIdeaProgettuale = IsIdeaProgettuale 
and 
d.IdDomanda = @id_prog_sigfrido
union all
select 
d.IdDomanda,
d.DescrizioneProgetto as Paragrafo, 
2 as Ordine
from [SIGFRIDO.DOMANDA].dbo.IdeaProgettuale d where 
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
_vGrad170Mobile vg on
vg.ID_DOMANDA = rt.IdDomanda
where brt.ID_BANDO = vg.IdBandoSigef




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
,[NON_COFINANZIATO]) output inserted.ID_INVESTIMENTO, inserted.ID_PROGETTO into @temptable_investimenti(id_inv, id_progetto)
select
@id_prog_sigef					--id_progetto
,vbp.ID_PROGRAMMAZIONE			--id_programmazione
,ci.DESCRIZIONE					--descrizione
,null							--DATA_VARIAZIONE
,null							--OPERATORE_VARIAZIONE
,1								--COD_TIPO_INVESTIMENTO
,'00'							--COD_STP
,8								--ID_UNITA_MISURA
,1								--QUANTITA
,ISNULL(gs170m.Investimento_richiesto, gs170m.INV_AMMESSO)	--COSTO_INVESTIMENTO
,0								--SPESE_GENERALI
,gs170m.CONTRIBUTO_CONCEDIBILE		--CONTRIBUTO_RICHIESTO
,ci.AIUTO_MINIMO				--QUOTA_CONTRIBUTO_RICHIESTO
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
_vGrad170Mobile gs170m 
inner join CODIFICA_INVESTIMENTO ci on 
gs170m.IdBandoSigef = ci.ID_BANDO
inner join vBANDO_PROGRAMMAZIONE vbp on 
gs170m.IdBandoSigef = vbp.ID_BANDO
inner join DETTAGLIO_INVESTIMENTI di on
ci.ID_CODIFICA_INVESTIMENTO = di.ID_CODIFICA_INVESTIMENTO
inner join 
zOB_MISURA om on 
vbp.ID_PADRE = om.ID_PROGRAMMAZIONE
where gs170m.ID_DOMANDA = @id_prog_sigfrido

union all
select
@id_prog_sigef					--id_progetto
,vbp.ID_PROGRAMMAZIONE			--id_programmazione
,ci.DESCRIZIONE					--descrizione
,null							--DATA_VARIAZIONE
,null							--OPERATORE_VARIAZIONE
,1								--COD_TIPO_INVESTIMENTO
,'00'							--COD_STP
,8								--ID_UNITA_MISURA
,1								--QUANTITA
,gs170m.INV_AMMESSO				--COSTO_INVESTIMENTO
,0								--SPESE_GENERALI
,gs170m.CONTRIBUTO_CONCESSO		--CONTRIBUTO_RICHIESTO
,ci.AIUTO_MINIMO				--QUOTA_CONTRIBUTO_RICHIESTO
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
_vGrad170Mobile gs170m 
inner join CODIFICA_INVESTIMENTO ci on 
gs170m.IdBandoSigef = ci.ID_BANDO
inner join vBANDO_PROGRAMMAZIONE vbp on 
gs170m.IdBandoSigef = vbp.ID_BANDO
inner join DETTAGLIO_INVESTIMENTI di on
ci.ID_CODIFICA_INVESTIMENTO = di.ID_CODIFICA_INVESTIMENTO
inner join 
zOB_MISURA om on 
vbp.ID_PADRE = om.ID_PROGRAMMAZIONE
where gs170m.ID_DOMANDA = @id_prog_sigfrido

--[SIGFRIDO.DOMANDA].dbo.PianiFinanziariVociDomande pfvd
--inner join dbo._TransCodCodificheInvestimentiSigfridoSigef _tcis on
--_tcis.IdCodificaInvestimentoSigfrido = pfvd.IdPianoFinanziarioVoce
--inner join CODIFICA_INVESTIMENTO CI on
--ci.ID_CODIFICA_INVESTIMENTO = _tcis.IdCodificaInvestimentoSigef
--where pfvd.IdDomanda = 16411
--and
--pfvd.IdPianoFinanziarioVoceDomande = pfvd.IsPianoFinanziarioVoceDomande
--and
--pfvd.TCancellato = 0

update PIANO_INVESTIMENTI set ID_INVESTIMENTO_ORIGINALE = (select MIN(id_inv) from @temptable_investimenti) 
where ID_INVESTIMENTO = (select MAX(id_inv) from @temptable_investimenti)


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
[SIGFRIDO.DOMANDA].dbo.DatiMonitoraggio dm
left outer join 
[SIGFRIDO.DOMANDA].dbo.DominiValori CupNatura on
dm.CupIdNatura = CupNatura.IdDominioValore
left outer join 
[SIGFRIDO.DOMANDA].dbo.DominiValori CupCategoria on
dm.CupIdCategoria = CupCategoria.IdDominioValore
left outer join 
[SIGFRIDO.DOMANDA].dbo.DominiValori CupSottoCategoriaSoggetti on
dm.CupIdSottoCategoriaSoggetti = CupSottoCategoriaSoggetti.IdDominioValore
left outer join 
[SIGFRIDO.DOMANDA].dbo.DominiValori CupTipoOperazionePrev on
dm.CupIdTipoOperazionePrevalente = CupTipoOperazionePrev.IdDominioValore
left outer join 
[SIGFRIDO.DOMANDA].dbo.DominiValori CupTemaPrioritario on
dm.IdTemaPrioritario = CupTemaPrioritario.IdDominioValore
left outer join 
[SIGFRIDO.DOMANDA].dbo.DominiValori CptSettore on
dm.IdSettoreCpt = CptSettore.IdDominioValore
left outer join 
[SIGFRIDO.DOMANDA].dbo.DominiValori DimTerritoriale on
dm.IdDimensioneTerritoriale = DimTerritoriale.IdDominioValore
left outer join 
[SIGFRIDO.DOMANDA].dbo.DominiValori AttivitaEcon on
dm.IdAttivitaEconomica = AttivitaEcon.IdDominioValore
left outer join 
[SIGFRIDO.DOMANDA].dbo.DominiValori Ateco on
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
replace(Ateco.CodiceQsn,'-','') collate Latin1_General_CI_AS = ta2007.COD_TIPO_ATECO2007
inner join _vGrad170Mobile g on
dm.IdDomanda = g.ID_DOMANDA
where 
dm.IdDatiMonitoraggio = dm.IsDatiMonitoraggio
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


--Inserimento localizzazione progetto
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
from [SIGFRIDO.DOMANDA].dbo.LocalizzazioniInterventi li 
inner join
--left join 
( select 
dv.IdDominioValore,
case when dv.IdDominioValore = 20471 then '068' else dv.Codice end as  codcomune,
--dv.Codice codcomune,
prov.Codice codprov,
dv.Descrizione descComune,
prov.Descrizione descPro
from
[SIGFRIDO.DOMANDA].dbo.DominiValori dv 
inner join 
[SIGFRIDO.DOMANDA].dbo.DominiValori prov on
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
--inner join _vGrad170Mobile gs on
inner join _GraduatoriaSigfrido170Mobile gs on
li.IdDomanda = gs.ID_DOMANDA
inner join COMUNI C on
cc.codcomune collate Latin1_General_CI_AS = C.ISTAT
and
cc.codprov collate Latin1_General_CI_AS = C.COD_PROVINCIA
and
1 = CASE WHEN C.DENOMINAZIONE IN('RIPE','SALTARA') THEN  1 ELSE C.ATTIVO END
left outer join 
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
ims.RAGIONE_SOCIALE RAGIONE_SOCIALE_SIGEF--,
--U.ID_UTENTE ID_UTENTE_SIGEF,
--pf.COGNOME COGNOME_SIGEF,
--pf.NOME NOME_SIGEF,
--pf.CODICE_FISCALE AS CF_PERSONA_SIGEF 
from 
[SIGFRIDO.DOMANDA].dbo.Soggetti s
left outer join IMPRESA i on 
s.partitaiva collate Latin1_General_CI_AS = i.CODICE_FISCALE
left outer join IMPRESA_STORICO IMS ON
i.id_impresa = IMs.ID_IMPRESA
and
i.ID_STORICO_ULTIMO = ims.ID_STORICO_IMPRESA
--left outer join 
--PERSONE_X_IMPRESE PXI ON
--i.ID_IMPRESA = pxi.ID_IMPRESA
--left outer join 
--PERSONA_FISICA pf on 
--PXI.ID_PERSONA = pf.ID_PERSONA
--left outer join 
--UTENTI U on
--PXI.ID_PERSONA = U.ID_PERSONA_FISICA
inner join _GraduatoriaSigfrido170Mobile gs on
s.IdDomanda = gs.ID_DOMANDA
where 1=1 
and gs.ESITO like '%ammessa e finanziata%' 
and IdSoggetto = IsSoggetto
and s.TCancellato = 0
--and pxi.DATA_FINE IS NULL
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
from [SIGFRIDO.DOMANDA].dbo.DominiValori dug
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





declare @d int
declare @id_aggtable table ( id_agg int not null)
--controllo aggregazioni
;with ai as(
select 
g.ID_DOMANDA
,COUNT(*) as NR_IMPRESE
from 
_GraduatoriaSigfrido170Mobile g
where g.ID_DOMANDA in (
select distinct ID_DOMANDA from _GraduatoriaSigfrido170Mobile g1 where 
g1.ESITO like '%ammessa e finanziata%')
group by 
g.ID_DOMANDA
having COUNT(id_domanda) > 1
) 


select @d =  (select ai.ID_DOMANDA from ai where ai.ID_DOMANDA = @id_prog_sigfrido)

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
'RTI per progetto sigef' + CONVERT(varchar(10),@id_prog_sigef) + ' (Id Sigfrido: ' + CONVERT(varchar(10),@id_prog_sigfrido) + ')', --DENOMINAZIONE
'R',													   --COD_TIPO_AGGREGAZIONE
vg.DataValidazione,			--DATA_INIZIO
vg.ID_UTENTE,				--OPERATORE_INIZIO
1,							--ATTIVO
null,						--DATA_FINE
null						--OPERATORE_FINE
from 
_vGrad170Mobile vg
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
@id_aggr,											--ID_AGGREGAZIONE
case when gs.Capofila = 1 then 'C' else 'P' end,	--COD_RUOLO
gs.ID_IMPRESA,										--ID_IMPRESA
null,												--PERCENTUALE
gs.DataValidazione,									--DATA_INIZIO
gs.ID_UTENTE,										--OPERATORE_INIZIO
1,													--ATTIVO
null,												--DATA_FINE
null												--OPERATORE_FINE
from 
(
select 
s.IdDomanda,
s.Capofila,
i.ID_IMPRESA,
i.CODICE_FISCALE,
i.DESCRIZIONE,
g.DataValidazione,
g.ID_UTENTE 
from 
[SIGFRIDO.DOMANDA].dbo.Soggetti s
left outer join IMPRESA i on 
s.partitaiva collate Latin1_General_CI_AS = i.CODICE_FISCALE
inner join _vGrad170Mobile g on
s.IdDomanda = g.ID_DOMANDA
where 
--and 
IdSoggetto = IsSoggetto
--order by s.IdDomanda
) gs
where gs.IdDomanda = @id_prog_sigfrido

end
--aggiornamento e backup della data nello storico utente

;with ute as (
select 
s.IdDomanda ID_DOMANDA_SIGFRIDO,
gs.ID_PROGETTO_SIGEF,
uts.ID_UTENTE_STORICO,
i.ID_IMPRESA ID_IMPRESA_SIGEF,
i.CODICE_FISCALE CF_PIVA_SIGEF,
U.ID_UTENTE ID_UTENTE_SIGEF,
uts.DATA_US,
uts.DATA_STATO_PROGETTO 
from 
[SIGFRIDO.DOMANDA].dbo.Soggetti s
left outer join IMPRESA i on 
s.partitaiva collate Latin1_General_CI_AS = i.CODICE_FISCALE
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
inner join _GraduatoriaSigfrido170Mobile gs on 
s.IdDomanda = gs.ID_DOMANDA
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
where ESITO like '%ammessa e finanziata%'
and PXI.DATA_FINE IS NULL 
and IdSoggetto = IsSoggetto
and s.TCancellato = 0
and gs.ID_PROGETTO_SIGEF = @id_prog_sigef
)

insert into @table_ute
select * from ute

update gs 
set BK_DATA_UTENTE_STORICO = utx.data_us FROM 
_GraduatoriaSigfrido170Mobile gs inner join @table_ute utx on
gs.PIVA_CF = utx.cf_piva_sigef
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

