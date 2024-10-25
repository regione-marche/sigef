









/*mfesr.CUP_NATURA_SIGEF
)
order by pos       
mfesr.CUP_NATURA_SIGEF
)
order by pos*/
CREATE VIEW [dbo].[_vGrad170Moda]
AS
select 
tcbss.IdBandoSigef,
gs170.pos,
gs170.PUNTEGGIO,
gs170.ID_DOMANDA, 
MAX(gs170.CUP) AS CODICE_CUP,
pfds.Investimento_richiesto,
ISNULL(INVESTIMENTO_TOTALE_AMMESSO, INVESTIMENTO_AMMESSO) AS INV_AMMESSO,
CONTRIBUTO_CONCEDIBILE,
CONTRIBUTO_CONCESSO,
i.ID_IMPRESA,
U.ID_UTENTE,
gs170.ID_PROGETTO_SIGEF,
ub.ID_UTENTE AS ID_OPERATORE_ISTRUTTORIA,
pfb.CODICE_FISCALE as CF_OPERATORE_ISTRUTTORIA,
d.DataValidazione,
d.TDataInizio,
gs170.DATA_ATTO_CONCESSIONE,
gs170.DATA_RICEVIBILITA,
gs170.DATA_AMMISSIBILITA,
gs.SEGNATURA
--mfesr.CUP_NATURA_SIGEF
from 
_GraduatoriaSigfrido170 gs170
inner join 
[SIGFRIDO.DOMANDA].dbo.Domande d on
d.IdDomanda = gs170.ID_DOMANDA
inner join
[SIGFRIDO.DOMANDA].dbo.Soggetti s
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
inner join 
dbo._TransCodBandiSigefSigfrido tcbss on
d.IdBando = tcbss.IdBandoSigfrido
and tcbss.FlagModa = 1
left outer join 
(
select 
pfd.IdDomanda,
SUM(pfd.ImportoEsposto) as Investimento_richiesto
from 
[SIGFRIDO.DOMANDA].dbo.PianiFinanziariVociDomande pfd
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
left outer join 
_Graduatoria170Moda_Segnature gs on 
gs170.ID_DOMANDA = gs.[ID DOM]
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
and PXI.DATA_FINE IS NULL
--and gs170.ID_DOMANDA = mfesr.IdDomanda
group by 
gs170.id_domanda,
pos,
gs170.PUNTEGGIO,
INVESTIMENTO_TOTALE_AMMESSO, 
INVESTIMENTO_AMMESSO,
CONTRIBUTO_CONCEDIBILE,
CONTRIBUTO_CONCESSO,
d.IdDomanda,
d.IsDomanda,
i.ID_IMPRESA,
u.ID_UTENTE,
tcbss.IdBandoSigef,
pfds.Investimento_richiesto,
gs170.ID_PROGETTO_SIGEF,
ub.ID_UTENTE,
pfb.CODICE_FISCALE,
d.DataValidazione,
d.TDataInizio,
gs170.DATA_ATTO_CONCESSIONE,
gs170.DATA_RICEVIBILITA,
gs170.DATA_AMMISSIBILITA,
gs.SEGNATURA
--mfesr.CUP_NATURA_SIGEF
--)
--order by pos









