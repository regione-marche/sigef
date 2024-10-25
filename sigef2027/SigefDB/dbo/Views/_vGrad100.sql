






CREATE VIEW [dbo].[_vGrad100]
AS

select 
tcbss.IdBandoSigef,
--gs170.pos,
ROW_NUMBER() OVER(order by gs170.ID_DOMANDA)as pos,
gs170.ID_DOMANDA, 
gs170.ID_PROGETTO,
gs170.CODICE_PROGETTO,
--MAX(gs170.CUP) AS CODICE_CUP,
gs170.CUP AS CODICE_CUP,
--pfds.Investimento_richiesto,
bgp.CostoTotale AS INVESTIMENTO_RICHIESTO,
ISNULL(INVESTIMENTO_TOTALE_AMMESSO, gs170.INVESTIMENTO_AMMESSO) AS INV_AMMESSO,
gsi.INVESTIMENTO_AMMESSO AS INV_AMMESSO_2,
--bgp.CostoAmmessoContributo AS INV_AMMESSO,
--bgp.CostoAmmessoContributoAggiornato,
--coalesce(bgp.CostoAmmessoContributoAggiornato,bgp.CostoAmmessoContributo) as costoammesso,
bgp.ContributoRichiesto AS CONTRIBUTO_RICHIESTO,
CAST(bgp.CostoTotale/2 AS DECIMAL(20,2)) AS CONTRIBUTO_RICHIESTO_2,
CONTRIBUTO_CONCESSO,
gsi.CONTRIBUTO_EROGATO AS CONTRIBUTO_CONCESSO_2,
gs170.IMPORTO_EROGATO_FINALE_A,
gs170.IMPORTO_EROGATO_FINALE_B,
ISNULL(gs170.IMPORTO_EROGATO_FINALE_A,0) + ISNULL(gs170.IMPORTO_EROGATO_FINALE_B,0) AS IMPORTO_LIQUIDATO_TOT,
i.ID_IMPRESA,
U.ID_UTENTE,
IU.CODICE_FISCALE AS CF_OPERATORE_IMPRESA,
gs170.ID_PROGETTO_SIGEF,
ub.ID_UTENTE AS ID_OPERATORE_ISTRUTTORIA,
pfb.CODICE_FISCALE as CF_OPERATORE_ISTRUTTORIA,
d.DataValidazione,
d.TDataInizio,
gs170.DATA_ATTO_CONCESSIONE,
gs170.DATA_RICEVIBILITA,
gs170.DATA_AMMISSIBILITA,
gsi.IMPORTO_FATTURE_TOTALI,
gsi.IMPORTO_PAGAMENTI_TOTALI_BENEFICIARIO,
gsi.protocollo as PROTOCOLLO
--mfesr.CUP_NATURA_SIGEF
from 
_GraduatoriaSigfrido100 gs170
inner join 
[SIGFRIDO2020.DOMANDA].dbo.Domande d on
d.IdDomanda = gs170.ID_DOMANDA
inner join
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
--and tcbss.FlagModa = 1
inner join [RTISIGFRIDO2020].dbo.BandiGraduatorieProgetti bgp on 
gs170.CODICE_PROGETTO = bgp.CodiceOrigine collate Latin1_General_CI_AS
left outer join 
(
select 
pfd.IdDomanda,
SUM(pfd.ImportoEsposto) as Investimento_richiesto
from 
[SIGFRIDO2020.DOMANDA].dbo.PianiFinanziariVociDomande pfd
where 
--pfd.IdDomanda = 16411 
--and
pfd.IdPianoFinanziarioVoceDomande = IsPianoFinanziarioVoceDomande
and 
TCancellato = 0 
group by 
pfd.IdDomanda
) as pfds on
d.IdDomanda = pfds.IdDomanda
left outer join 
BANDO_RESPONSABILI br on 
tcbss.IdBandoSigef = br.ID_BANDO
left outer join UTENTI ub on
br.ID_UTENTE = ub.ID_UTENTE
left outer join PERSONA_FISICA pfb on
ub.ID_PERSONA_FISICA = pfb.ID_PERSONA
--inner join mfesr on
--gs170.ID_DOMANDA = mfesr.IdDomanda
left outer join 
_GraduatoriaSigfrido100Integrazione gsi on 
gs170.ID_DOMANDA = gsi.ID_DOMANDA_SIGFRIDO
where gs170.esito like '%ammessa e finanziata%'
and
s.TCancellato = 0
and 
d.IdDomanda = d.IsDomanda
and 
s.IdSoggetto = s.IsSoggetto
and 
d.TCancellato = 0
and d.IdStato = 4		
and s.Capofila = 1
and br.ATTIVO = 1
--and gs170.ID_DOMANDA = mfesr.IdDomanda
and not
(gs170.IMPORTO_EROGATO_FINALE_A is null
and gs170.IMPORTO_EROGATO_FINALE_B is null)


--select 
--tcbss.IdBandoSigef,
----gs170.pos,
--ROW_NUMBER() OVER(order by gs170.ID_DOMANDA)as pos,
--gs170.ID_DOMANDA, 
--gs170.ID_PROGETTO,
--gs170.CODICE_PROGETTO,
----MAX(gs170.CUP) AS CODICE_CUP,
--gs170.CUP AS CODICE_CUP,
----pfds.Investimento_richiesto,
--bgp.CostoTotale AS INVESTIMENTO_RICHIESTO,
--ISNULL(INVESTIMENTO_TOTALE_AMMESSO, INVESTIMENTO_AMMESSO) AS INV_AMMESSO,
----bgp.CostoAmmessoContributo AS INV_AMMESSO,
----bgp.CostoAmmessoContributoAggiornato,
----coalesce(bgp.CostoAmmessoContributoAggiornato,bgp.CostoAmmessoContributo) as costoammesso,
--bgp.ContributoRichiesto AS CONTRIBUTO_RICHIESTO,
--CONTRIBUTO_CONCESSO,
--gs170.IMPORTO_EROGATO_FINALE_A,
--gs170.IMPORTO_EROGATO_FINALE_B,
--ISNULL(gs170.IMPORTO_EROGATO_FINALE_A,0) + ISNULL(gs170.IMPORTO_EROGATO_FINALE_B,0) AS IMPORTO_LIQUIDATO_TOT,
--i.ID_IMPRESA,
--U.ID_UTENTE,
--IU.CODICE_FISCALE AS CF_OPERATORE_IMPRESA,
--gs170.ID_PROGETTO_SIGEF,
--ub.ID_UTENTE AS ID_OPERATORE_ISTRUTTORIA,
--pfb.CODICE_FISCALE as CF_OPERATORE_ISTRUTTORIA,
--d.DataValidazione,
--d.TDataInizio,
--gs170.DATA_ATTO_CONCESSIONE,
--gs170.DATA_RICEVIBILITA,
--gs170.DATA_AMMISSIBILITA

----mfesr.CUP_NATURA_SIGEF
--from 
--_GraduatoriaSigfrido100 gs170
--inner join 
--[SIGFRIDO2020.DOMANDA].dbo.Domande d on
--d.IdDomanda = gs170.ID_DOMANDA
--inner join
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
--left outer join PERSONA_FISICA IU ON
--U.ID_PERSONA_FISICA = IU.ID_PERSONA
--inner join 
--dbo._TransCodBandiSigefSigfrido tcbss on
--d.IdBando = tcbss.IdBandoSigfrido
----and tcbss.FlagModa = 1
--inner join [RTISIGFRIDO2020].dbo.BandiGraduatorieProgetti bgp on 
--gs170.CODICE_PROGETTO = bgp.CodiceOrigine collate Latin1_General_CI_AS
--left outer join 
--(
--select 
--pfd.IdDomanda,
--SUM(pfd.ImportoEsposto) as Investimento_richiesto
--from 
--[SIGFRIDO2020.DOMANDA].dbo.PianiFinanziariVociDomande pfd
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
--left outer join 
--BANDO_RESPONSABILI br on 
--tcbss.IdBandoSigef = br.ID_BANDO
--left outer join UTENTI ub on
--br.ID_UTENTE = ub.ID_UTENTE
--left outer join PERSONA_FISICA pfb on
--ub.ID_PERSONA_FISICA = pfb.ID_PERSONA
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
--and d.IdStato = 4		
--and s.Capofila = 1
--and br.ATTIVO = 1
----and gs170.ID_DOMANDA = mfesr.IdDomanda
--and not
--(gs170.IMPORTO_EROGATO_FINALE_A is null
--and gs170.IMPORTO_EROGATO_FINALE_B is null)

--select 
--tcbss.IdBandoSigef,
--gs170.pos,
--gs170.ID_DOMANDA, 
--gs170.ID_PROGETTO,
--gs170.CODICE_PROGETTO,
--MAX(gs170.CUP) AS CODICE_CUP,
----pfds.Investimento_richiesto,
--bgp.CostoTotale AS INVESTIMENTO_RICHIESTO,
--ISNULL(INVESTIMENTO_TOTALE_AMMESSO, INVESTIMENTO_AMMESSO) AS INV_AMMESSO,
--bgp.ContributoRichiesto,
--CONTRIBUTO_CONCESSO,
--i.ID_IMPRESA,
--U.ID_UTENTE,
--gs170.ID_PROGETTO_SIGEF,
--ub.ID_UTENTE AS ID_OPERATORE_ISTRUTTORIA,
--pfb.CODICE_FISCALE as CF_OPERATORE_ISTRUTTORIA,
--d.DataValidazione,
--d.TDataInizio,
--gs170.DATA_ATTO_CONCESSIONE,
--gs170.DATA_RICEVIBILITA,
--gs170.DATA_AMMISSIBILITA
----mfesr.CUP_NATURA_SIGEF
--from 
--_GraduatoriaSigfrido100 gs170
--inner join 
--[SIGFRIDO2020.DOMANDA].dbo.Domande d on
--d.IdDomanda = gs170.ID_DOMANDA
--inner join
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
----and tcbss.FlagModa = 1
--inner join [RTISIGFRIDO2020].dbo.BandiGraduatorieProgetti bgp on 
--gs170.CODICE_PROGETTO = bgp.CodiceOrigine collate Latin1_General_CI_AS
--left outer join 
--(
--select 
--pfd.IdDomanda,
--SUM(pfd.ImportoEsposto) as Investimento_richiesto
--from 
--[SIGFRIDO2020.DOMANDA].dbo.PianiFinanziariVociDomande pfd
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
--left outer join 
--BANDO_RESPONSABILI br on 
--tcbss.IdBandoSigef = br.ID_BANDO
--left outer join UTENTI ub on
--br.ID_UTENTE = ub.ID_UTENTE
--left outer join PERSONA_FISICA pfb on
--ub.ID_PERSONA_FISICA = pfb.ID_PERSONA
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
--and d.IdStato = 4		
--and s.Capofila = 1
----and br.ATTIVO = 1
----and gs170.ID_DOMANDA = mfesr.IdDomanda
--and not
--(gs170.IMPORTO_EROGATO_FINALE_A is null
--and gs170.IMPORTO_EROGATO_FINALE_B is null)
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
----pfds.Investimento_richiesto,
--gs170.ID_PROGETTO_SIGEF,
--ub.ID_UTENTE,
--pfb.CODICE_FISCALE,
--d.DataValidazione,
--d.TDataInizio,
--gs170.DATA_ATTO_CONCESSIONE,
--gs170.DATA_RICEVIBILITA,
--gs170.DATA_AMMISSIBILITA,
--bgp.CostoTotale,
--gs170.CODICE_PROGETTO,
--bgp.ContributoRichiesto,
--gs170.ID_PROGETTO
----mfesr.CUP_NATURA_SIGEF
----)
----order by pos
















