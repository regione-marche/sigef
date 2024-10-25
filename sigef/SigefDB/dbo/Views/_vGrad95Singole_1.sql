








CREATE VIEW [dbo].[_vGrad95Singole_1]
AS

select 
tcbss.IdBandoSigef,
gs170.pos,
gs170.ID_DOMANDA_SIGFRIDO ID_DOMANDA, 
gs170.ID_PROGETTO_SIGFRIDO ID_PROGETTO,
gs170.CUP AS CODICE_CUP,
--pfds.Investimento_richiesto,
--gs170.Investimento_proposto,
IMPR.INVESTIMENTO_RICHIESTO,
gs170.INVESTIMENTO_AMMESSO INVESTIMENTO_AMMESSO,
gs170.PUNTEGGIO,
gs170.Percen#,
--ISNULL(INVESTIMENTO_TOTALE_AMMESSO, INVESTIMENTO_AMMESSO) AS INV_AMMESSO,
IMPR.CONTRIBUTO_RICHIESTO,
gs170.CONTRIBUTO_CONCESSO AS CONTRIBUTO_CONCESSO,
--CONTRIBUTO_CONCESSO,
i.ID_IMPRESA,
U.ID_UTENTE,
gs170.ID_PROGETTO_SIGEF,
ub.ID_UTENTE AS ID_OPERATORE_ISTRUTTORIA,
pfb.CODICE_FISCALE as CF_OPERATORE_ISTRUTTORIA,
d.DataValidazione,
d.TDataInizio,
IU.CODICE_FISCALE CF_OPERATORE_IMPRESA,
gs170.FLAG_CAPOFILA,
gs170.DATA_INIZIO_PROGETTO,
gs170.DATA_FINE_PROGETTO,
gs170.DATA_RILASCIO,
gs170.DATA_CONCESSIONE,
gs170.DATA_RICEVIBILITA,
gs170.DATA_AMMISSIBILITA,
gs170.Decreto_anticipo_data DATA_ANTICIPO,
gs170.[INVIO_1_SAL_(365_gg_da_ricezione)] DATA_RILASCIO_DOMANDA_PAGAMENTO,
rend.IMPORTO_ANTICIPO,
rend.IMPORTO_SPESA,
rend.IMPORTO_SPESA_RICHIESTO,
rend.IMPORTO_SPESA_AMMESSO,
rend.CONTRIBUTO_SPESA_RICHIESTO,
rend.CONTRIBUTO_SPESA_CONCESSO
--mfesr.CUP_NATURA_SIGEF
from 
--_GraduatoriaSigfrido170 gs170
_GraduatoriaSigfrido95Singole_1 gs170
inner join 
[SIGFRIDO2020.DOMANDA].dbo.Domande d on
d.IdDomanda = gs170.ID_DOMANDA_SIGFRIDO
left join
[SIGFRIDO2020.DOMANDA].dbo.Soggetti s
on
d.IdDomanda = s.IdDomanda
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
left outer join PERSONA_FISICA IU ON
U.ID_PERSONA_FISICA = IU.ID_PERSONA
inner join 
dbo._TransCodBandiSigefSigfrido tcbss on
d.IdBando = tcbss.IdBandoSigfrido
and tcbss.FlagModa = 0
--left outer join 
--(
--select 
--pfd.IdDomanda,
--SUM(pfd.ImportoEsposto) as Investimento_richiesto
--from 
--[SIGFRIDO.DOMANDA].dbo.PianiFinanziariVociDomande pfd
--where 
----pfd.IdDomanda = 16411 
----and
--pfd.IdPianoFinanziarioVoceDomande = IsPianoFinanziarioVoceDomande
--and 
--TCancellato = 0 
--group by 
--pfd.IdDomanda
--) as pfds on
--d.IdDomanda = pfds.IdDomanda
left outer join 
BANDO_RESPONSABILI br on 
tcbss.IdBandoSigef = br.ID_BANDO
left outer join UTENTI ub on
br.ID_UTENTE = ub.ID_UTENTE
left outer join PERSONA_FISICA pfb on
ub.ID_PERSONA_FISICA = pfb.ID_PERSONA
LEFT JOIN 
(
SELECT 
ID_DOMANDA_SIGFRIDO,
SUM(ISNULL(Investimento_proposto,0)) AS INVESTIMENTO_RICHIESTO,
SUM(ISNULL(Contributo_richiesto,0)) AS CONTRIBUTO_RICHIESTO
FROM 
dbo._GraduatoriaSigfrido95Singole_1 
GROUP BY 
ID_DOMANDA_SIGFRIDO
) IMPR ON
gs170.ID_DOMANDA_SIGFRIDO = IMPR.ID_DOMANDA_SIGFRIDO
INNER JOIN 
(
SELECT 
gs.ID_DOMANDA_SIGFRIDO,
SUM(ISNULL(gs.[A)_ANTICIPAZIONE_LIQUIDATA_], 0)) IMPORTO_ANTICIPO,
SUM(ISNULL(gs.Totale_rendicontato,0)) IMPORTO_SPESA,
SUM(ISNULL(gs.SPESA_RENDICONTATA_1_SAL_,0)) IMPORTO_SPESA_RICHIESTO,
SUM(ISNULL(gs.[_c)_=_(BA)_CONTRIBUTO_1_SAL_DA_LIQUIDARE_],0)) CONTRIBUTO_SPESA_RICHIESTO,
SUM(ISNULL(gs.SPESA_RENDICONTATA_1_SAL_,0)) IMPORTO_SPESA_AMMESSO,
SUM(ISNULL(gs.[_c)_=_(BA)_CONTRIBUTO_1_SAL_DA_LIQUIDARE_],0)) CONTRIBUTO_SPESA_CONCESSO
--gs.[B)_CONTRIBUTO_1_SAL_SPETTANTE__]
FROM _GraduatoriaSigfrido95Singole_1 gs
GROUP BY 
gs.ID_DOMANDA_SIGFRIDO
) rend ON
gs170.ID_DOMANDA_SIGFRIDO = rend.ID_DOMANDA_SIGFRIDO
--inner join mfesr on
--gs170.ID_DOMANDA = mfesr.IdDomanda
where gs170.esito like '%ammessa e finanziata%'
and
s.TCancellato = 0
and 
d.IdDomanda = d.IsDomanda
and 
s.IdSoggetto = s.IsSoggetto
and 
d.TCancellato = 0
and s.Capofila = 1
and br.ATTIVO = 1
--and gs170.ID_DOMANDA = mfesr.IdDomanda
--group by 
--gs170.id_domanda,
--pos,
--INVESTIMENTO_TOTALE_AMMESSO, 
--INVESTIMENTO_AMMESSO,
--CONTRIBUTO_CONCESSO,
--d.IdDomanda,
--d.IsDomanda,
--i.ID_IMPRESA,
--u.ID_UTENTE,
--tcbss.IdBandoSigef,
--pfds.Investimento_richiesto,
--gs170.ID_PROGETTO_SIGEF,
--ub.ID_UTENTE,
--pfb.CODICE_FISCALE,
--d.DataValidazione,
--d.TDataInizio,
--gs170.FLAG_CAPOFILA,
--gs170.DATA_ATTO_CONCESSIONE,
--gs170.DATA_RICEVIBILITA,
--gs170.DATA_AMMISSIBILITA

--select 
--tcbss.IdBandoSigef,
--gs170.pos,
--gs170.ID_DOMANDA_SIGFRIDO ID_DOMANDA, 
--gs170.CUP AS CODICE_CUP,
----pfds.Investimento_richiesto,
----gs170.Investimento_proposto,
--gs170.INVESTIMENTO_PROPOSTO INVESTIMENTO_RICHIESTO,
--gs170.INVESTIMENTO_AMMESSO INVESTIMENTO_AMMESSO,
----ISNULL(INVESTIMENTO_TOTALE_AMMESSO, INVESTIMENTO_AMMESSO) AS INV_AMMESSO,
--gs170.CONTRIBUTO_RICHIESTO,
--gs170.CONTRIBUTO_CONCESSO AS CONTRIBUTO_CONCESSO,
----CONTRIBUTO_CONCESSO,
--i.ID_IMPRESA,
--U.ID_UTENTE,
--gs170.ID_PROGETTO_SIGEF,
--ub.ID_UTENTE AS ID_OPERATORE_ISTRUTTORIA,
--pfb.CODICE_FISCALE as CF_OPERATORE_ISTRUTTORIA,
--d.DataValidazione,
--d.TDataInizio,
--gs170.FLAG_CAPOFILA,
--gs170.DATA_RILASCIO,
--gs170.DATA_CONCESSIONE,
--gs170.DATA_RICEVIBILITA,
--gs170.DATA_AMMISSIBILITA
----mfesr.CUP_NATURA_SIGEF
--from 
----_GraduatoriaSigfrido170 gs170
--_GraduatoriaSigfrido95Singole_1 gs170
--inner join 
--[SIGFRIDO2020.DOMANDA].dbo.Domande d on
--d.IdDomanda = gs170.ID_DOMANDA_SIGFRIDO
--left join
--[SIGFRIDO2020.DOMANDA].dbo.Soggetti s
--on
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
--inner join 
--dbo._TransCodBandiSigefSigfrido tcbss on
--d.IdBando = tcbss.IdBandoSigfrido
--and tcbss.FlagModa = 1
----left outer join 
----(
----select 
----pfd.IdDomanda,
----SUM(pfd.ImportoEsposto) as Investimento_richiesto
----from 
----[SIGFRIDO.DOMANDA].dbo.PianiFinanziariVociDomande pfd
----where 
------pfd.IdDomanda = 16411 
------and
----pfd.IdPianoFinanziarioVoceDomande = IsPianoFinanziarioVoceDomande
----and 
----TCancellato = 0 
----group by 
----pfd.IdDomanda
----) as pfds on
----d.IdDomanda = pfds.IdDomanda
--left outer join 
--BANDO_RESPONSABILI br on 
--tcbss.IdBandoSigef = br.ID_BANDO
--left outer join UTENTI ub on
--br.ID_UTENTE = ub.ID_UTENTE
--left outer join PERSONA_FISICA pfb on
--ub.ID_PERSONA_FISICA = pfb.ID_PERSONA
----LEFT JOIN 
----(
----SELECT 
----ID_DOMANDA_SIGFRIDO,
----SUM(ISNULL(Investimento_proposto,0)) AS INVESTIMENTO_RICHIESTO,
----SUM(ISNULL(Contributo_richiesto,0)) AS CONTRIBUTO_RICHIESTO
----FROM 
----dbo._GraduatoriaSigfrido95Singole_1 
----GROUP BY 
----ID_DOMANDA_SIGFRIDO
----) IMPR ON
----gs170.ID_DOMANDA_SIGFRIDO = IMPR.ID_DOMANDA_SIGFRIDO
----inner join mfesr on
----gs170.ID_DOMANDA = mfesr.IdDomanda
--where gs170.esito like '%ammessa e finanziata%'
--and
--s.TCancellato = 0
--and 
--d.IdDomanda = d.IsDomanda
--and 
--s.IdSoggetto = s.IsSoggetto
--and 
--d.TCancellato = 0
--and s.Capofila = 1
--and br.ATTIVO = 1
----and gs170.ID_DOMANDA = mfesr.IdDomanda
----group by 
----gs170.id_domanda,
----pos,
----INVESTIMENTO_TOTALE_AMMESSO, 
----INVESTIMENTO_AMMESSO,
----CONTRIBUTO_CONCESSO,
----d.IdDomanda,
----d.IsDomanda,
----i.ID_IMPRESA,
----u.ID_UTENTE,
----tcbss.IdBandoSigef,
----pfds.Investimento_richiesto,
----gs170.ID_PROGETTO_SIGEF,
----ub.ID_UTENTE,
----pfb.CODICE_FISCALE,
----d.DataValidazione,
----d.TDataInizio,
----gs170.FLAG_CAPOFILA,
----gs170.DATA_ATTO_CONCESSIONE,
----gs170.DATA_RICEVIBILITA,
----gs170.DATA_AMMISSIBILITA
























