CREATE VIEW vINDICATORI_OUTPUT_IN01
AS
--Codifica degli indicatori secondo IGRUE
WITH CODIND AS
(
SELECT
ZDP.ID_DIM_X_PROGRAMMAZIONE,
ZDP.ID_PROGRAMMAZIONE,
ZD.ID ID_DIMENSIONE,
ZD.COD_DIM,
CASE ZD.COD_DIM 
WHEN 'IOC' THEN 'COM'
WHEN 'IOS' THEN 'DPR'
END AS TIPO_INDICATORE_DI_OUTPUT,
ZD.CODICE AS COD_INDICATORE
FROM zDIMENSIONI ZD
INNER JOIN
zDIMENSIONI_X_PROGRAMMAZIONE ZDP ON
ZDP.ID_DIMENSIONE = ZD.ID
WHERE 
ZD.COD_DIM IN ('IOC','IOS')
)

--filtro su progetti da estrarre per BDU
,pfesr as 
(
select 
p.ID_PROGETTO,
p.ID_BANDO,
p.COD_AGEA,
ZP.ID ID_PROGRAMMAZIONE
from vPROGETTO p
INNER JOIN vBANDO B ON
P.ID_BANDO = B.ID_BANDO
INNER JOIN BANDO_PROGRAMMAZIONE BP ON
B.ID_BANDO = BP.ID_BANDO
INNER JOIN zPROGRAMMAZIONE ZP ON
BP.ID_PROGRAMMAZIONE = ZP.ID
INNER JOIN zPSR_ALBERO PA ON
ZP.COD_TIPO = PA.CODICE
INNER JOIN zPSR PSR ON
PA.COD_PSR = PSR.CODICE
WHERE 
P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R') 
AND 
PSR.CODICE = 'POR20142020'
AND ZP.ID NOT IN (17,18,19)
AND
P.COD_AGEA IS NOT NULL
)

--Ultima domanda di pagamento approvata il cui id è presente in progetto_indicatori
,dPag as (select 
vpi.ID_PROGETTO_INDICATORI,
vpi.ID_DIM_X_PROGRAMMAZIONE,
p.id_progetto,
p.id_domanda_pagamento,
p.DATA_APPROVAZIONE,
APPROVATA,
ANNULLATA,
SEGNATURA_APPROVAZIONE
from 
(
	select 
	ID_PROGETTO,
	ID_DOMANDA_PAGAMENTO,
	DATA_APPROVAZIONE,
	SEGNATURA_APPROVAZIONE,
	APPROVATA,
	ANNULLATA,
	row_number() over(partition by id_progetto order by data_approvazione desc) rn
	from DOMANDA_DI_PAGAMENTO 
	where APPROVATA = 1
) as p
inner join 
vPROGETTO_INDICATORI vpi on
vpi.ID_PROGETTO = p.ID_PROGETTO
and
vpi.ID_DOMANDA_PAGAMENTO = p.ID_DOMANDA_PAGAMENTO
where rn=1)

--Ultima variante approvata il cui id è presente in progetto_indicatori
,dVar as (
select 
vpi.ID_PROGETTO_INDICATORI,
vpi.ID_DIM_X_PROGRAMMAZIONE,
v.id_progetto,
v.id_variante,
v.DATA_APPROVAZIONE,
APPROVATA,
ANNULLATA,
SEGNATURA_APPROVAZIONE
from 
(
	select 
	id_progetto,
	id_variante,
	DATA_APPROVAZIONE,
	SEGNATURA_APPROVAZIONE,
	APPROVATA,
	ANNULLATA,
	row_number() over(partition by id_progetto order by data_approvazione desc) rn
	from VARIANTI 
	where APPROVATA = 1
) as v
inner join 
vPROGETTO_INDICATORI vpi on
vpi.ID_PROGETTO = v.ID_PROGETTO
and
vpi.ID_VARIANTE = v.ID_VARIANTE
where rn=1
)

--Ultima domanda di contributo approvata il cui id è presente in progetto_indicatori (per uniformità con dPag e dVar, la domanda di contributo è sempre solo una)
,dProg as (
select 
pin.ID_PROGETTO_INDICATORI,
pin.ID_DIM_X_PROGRAMMAZIONE,
pin.id_progetto
from
progetto_indicatori pin
inner join pfesr p on
pin.id_progetto = p.ID_PROGETTO
where 
pin.COD_TIPO = 'DOMANDA'
)

--CTE che estrae gli ultimi indicatori per il valore programmato da dVar e dProg--CTE che estrae gli ultimi indicatori per il valore programmato da dVar e dProg
,vProgrammati as
(
select 
dvar.id_progetto,
dvar.ID_PROGETTO_INDICATORI,
dvar.ID_DIM_X_PROGRAMMAZIONE
from dVar
where not exists 
(select dProg.id_progetto from dProg where dProg.ID_PROGETTO = dVar.id_progetto)
union
	select 
	dprog.id_progetto,
	dprog.id_progetto_indicatori,
	dprog.ID_DIM_X_PROGRAMMAZIONE
	from 
	dprog
)

--CTE che estrae tutti gli indicatori previsti dalla classificazione per i progetti da inviare in BDU
--e assenti in progetto_indicatori più tutti gli indicatori che invece sono stati compilati e quindi presenti in progetto_indicatori 
,ind as (
select a.* from (
SELECT 
'0' AS PROG,
P.ID_PROGETTO,
P.ID_PROGRAMMAZIONE,
ZDP.ID_DIM_X_PROGRAMMAZIONE,
--NULL AS VALORE_PROGRAMMATO,
--NULL AS VALORE_REALIZZATO,
ZDP.TIPO_INDICATORE_DI_OUTPUT,
ZDP.COD_INDICATORE--,
--NULL AS DATA_REG
FROM pfesr P 
INNER JOIN CODIND ZDP ON 
P.ID_PROGRAMMAZIONE = ZDP.ID_PROGRAMMAZIONE

EXCEPT
select 
'0' AS PROG,
vi.ID_PROGETTO,
vi.Id_Programmazione,
vi.ID_DIM_X_PROGRAMMAZIONE,
CP.TIPO_INDICATORE_DI_OUTPUT,
CP.COD_INDICATORE--,
from 
vPROGETTO_INDICATORI vi
inner join 
CODIND CP ON
vi.ID_DIM_X_PROGRAMMAZIONE = CP.ID_DIM_X_PROGRAMMAZIONE
inner join pfesr P on
vi.ID_PROGETTO = P.ID_PROGETTO


union 

select 
'1' AS PROG,
vi.ID_PROGETTO,
vi.Id_Programmazione,
vi.ID_DIM_X_PROGRAMMAZIONE,
CP.TIPO_INDICATORE_DI_OUTPUT,
CP.COD_INDICATORE--,
from 
vPROGETTO_INDICATORI vi
inner join 
CODIND CP ON
vi.ID_DIM_X_PROGRAMMAZIONE = CP.ID_DIM_X_PROGRAMMAZIONE
inner join pfesr P on
vi.ID_PROGETTO = P.ID_PROGETTO
)
as a
) 

--CTE che restituisce gli indicatori in base a criteri di precedenza sui valori programmati e realizzati
, IOT AS(
select ind.*,
vprog.ID_PROGETTO_INDICATORI id_prog_prog,
dPag.ID_PROGETTO_INDICATORI id_prog_pag,
--coalesce(coalesce(pin_prg.VALORE_PROGRAMMATO_AMMESSO, pin_prg.VALORE_PROGRAMMATO_RICHIESTO),coalesce(pin_pag.VALORE_PROGRAMMATO_AMMESSO, pin_pag.VALORE_PROGRAMMATO_RICHIESTO)) as programmato, --precedenza a progetti-varianti sui programmati
coalesce(coalesce(pin_pag.VALORE_PROGRAMMATO_AMMESSO, pin_pag.VALORE_PROGRAMMATO_RICHIESTO),coalesce(pin_prg.VALORE_PROGRAMMATO_AMMESSO, pin_prg.VALORE_PROGRAMMATO_RICHIESTO)) as VALORE_PROGRAMMATO, --precedenza ai pagamenti sui programmati: al 08/03/2019 sono solo 53 i record con valori diversi dalla versione con precedenza a progeti-varianti -- you win! muahahahahahah
coalesce(coalesce(pin_pag.VALORE_REALIZZATO_AMMESSO, pin_pag.VALORE_PROGRAMMATO_AMMESSO),coalesce(pin_prg.VALORE_REALIZZATO_AMMESSO, pin_prg.VALORE_REALIZZATO_RICHIESTO)) as VALORE_REALIZZATO,
pin_prg.VALORE_PROGRAMMATO_RICHIESTO val_prog_ric_prg, --1
pin_prg.VALORE_PROGRAMMATO_AMMESSO val_prog_amm_prg,   --2
pin_prg.VALORE_REALIZZATO_RICHIESTO val_real_ric_prg,  --3
pin_prg.VALORE_REALIZZATO_AMMESSO val_real_amm_prg,    --4
pin_pag.VALORE_PROGRAMMATO_RICHIESTO val_prog_ric_pag, --5
pin_pag.VALORE_PROGRAMMATO_AMMESSO val_prog_amm_pag,   --6
pin_pag.VALORE_PROGRAMMATO_AMMESSO val_real_ric_pag,   --7
pin_pag.VALORE_REALIZZATO_AMMESSO val_real_amm_pag,--,  --8
DIM.ID as ID_DIMENSIONE
-- precedenza valori: 
--programmato: (6,5) , (2,1) : invertire i coalesce? sì, prima versione (2 - 1) , (6-5)
--realizzato: (8,7) , (4,3)
--(
--select max(v) from (values 
-- (pin_pag.VALORE_PROGRAMMATO_RICHIESTO)
--,(pin_pag.VALORE_PROGRAMMATO_AMMESSO )
--,(pin_pag.VALORE_PROGRAMMATO_AMMESSO) 
--,(pin_pag.VALORE_REALIZZATO_AMMESSO )
--,(pin_prg.VALORE_PROGRAMMATO_RICHIESTO)
--,(pin_prg.VALORE_PROGRAMMATO_AMMESSO )
--,(pin_prg.VALORE_REALIZZATO_RICHIESTO )
--,(pin_prg.VALORE_REALIZZATO_AMMESSO)
--) as value(v))
-- as maxvalue
from ind 
inner join 
zDIMENSIONI_X_PROGRAMMAZIONE DIM_X_PROG on
ind.ID_DIM_X_PROGRAMMAZIONE = DIM_X_PROG.ID_DIM_X_PROGRAMMAZIONE
inner join 
zDIMENSIONI DIM on dim.ID = DIM_X_PROG.ID_DIMENSIONE
left outer join 
dpag on
ind.ID_PROGETTO = dpag.id_progetto
and
ind.ID_DIM_X_PROGRAMMAZIONE = dpag.ID_DIM_X_PROGRAMMAZIONE
left outer join 
PROGETTO_INDICATORI pin_pag on
dpag.ID_PROGETTO_INDICATORI = pin_pag.ID_PROGETTO_INDICATORI
left outer join 
vProgrammati vprog on
ind.ID_PROGETTO = vprog.id_progetto
and
ind.ID_DIM_X_PROGRAMMAZIONE = vprog.ID_DIM_X_PROGRAMMAZIONE
left outer join 
PROGETTO_INDICATORI pin_prg on
vprog.ID_PROGETTO_INDICATORI = pin_prg.ID_PROGETTO_INDICATORI
)

SELECT 
ASSE.CODICE AS ASSE,
AZIONE.CODICE AS AZIONE,
INTERVENTO.CODICE AS INTERVENTO,
P.ID_PROGETTO AS ID_PROGETTO,
T.COD_INDICATORE AS INDICATORE,
DIM.DESCRIZIONE,
DIM.UM AS UNITA_DI_MISURA,
CASE WHEN T.VALORE_PROGRAMMATO = 0 THEN 1 ELSE 
ISNULL(T.VALORE_PROGRAMMATO,1) END AS VALORE_PROGRAMMATO,
ISNULL(T.VALORE_REALIZZATO,0) AS VALORE_REALIZZATO,
TBD.DATA_INIZIO_EFFETTIVA as DATA_DI_AVVIO,
TBD.DATA_FINE_EFFETTIVA as DATA_DI_CONCLUSIONE,
p.STATO AS STATO_PROGETTO
FROM vPROGETTO P 
INNER JOIN vBANDO B ON
P.ID_BANDO = B.ID_BANDO
INNER JOIN BANDO_PROGRAMMAZIONE BP ON
B.ID_BANDO = BP.ID_BANDO
INNER JOIN zPROGRAMMAZIONE PRG ON
BP.ID_PROGRAMMAZIONE = PRG.ID
INNER JOIN zPSR_ALBERO PA ON
PRG.COD_TIPO = PA.CODICE
INNER JOIN zPSR PSR ON
PA.COD_PSR = PSR.CODICE
INNER JOIN IOT T ON
P.ID_PROGETTO = T.ID_PROGETTO 
INNER JOIN vzPROGRAMMAZIONE AS INTERVENTO ON 
INTERVENTO.ID = BP.ID_PROGRAMMAZIONE 
INNER JOIN vzPROGRAMMAZIONE AS AZIONE ON 
INTERVENTO.ID_PADRE=AZIONE.ID 
INNER JOIN vzPROGRAMMAZIONE AS ASSE ON 
AZIONE.ID_PADRE = ASSE.ID
INNER JOIN zDIMENSIONI DIM ON
DIM.ID = T.ID_DIMENSIONE
LEFT JOIN vDATE_PROGETTI TBD ON
TBD.COD_LOCALE_PROGETTO = P.ID_PROGETTO
WHERE 
P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R') 
AND 
PSR.CODICE = 'POR20142020'
AND 
PRG.ID NOT IN (17,18,19)
AND
P.COD_AGEA IS NOT NULL
--26/01/2018
--CLAUSOLA TEMPORANEA PER ESCLUDERE PROGETTO STRUMENTI FINANZIARI ARTIGIANCASSA
AND P.ID_PROGETTO <> 13301

