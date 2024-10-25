CREATE VIEW [dbo].[vPROGETTO_INDICATORI]
AS

SELECT  pind.ID_PROGETTO_INDICATORI,
        pind.ID_DIM_X_PROGRAMMAZIONE,
        pind.ID_PROGETTO,
        pind.ID_DOMANDA_PAGAMENTO,
        pind.ID_VARIANTE,
        pind.COD_TIPO,
        pind.VALORE_PROGRAMMATO_RICHIESTO,
        pind.VALORE_REALIZZATO_RICHIESTO,
        pind.DATA_REGISTRAZIONE,
        pind.OPERATORE,
        pind.VALORE_PROGRAMMATO_AMMESSO,
        pind.VALORE_REALIZZATO_AMMESSO,
        pind.DATA_ISTRUTTORIA,
        pind.ISTRUTTORE,
        -- Fine campi della tabella Progetto_Indicatori
        dim.DESCRIZIONE  AS Dim_Descrizione,
        dim.UM           AS Dim_Um,
		dim.RICHIEDIBILE,
		dim.PROCEDURA_CALCOLO,
		dim.Codice       AS Dim_Codice,
        pone.ID          AS Id_Programmazione,
        pone.CODICE      AS Programmazione_Codice,
        pone.DESCRIZIONE AS Programmazione_Descrizione
FROM PROGETTO_INDICATORI pind
     LEFT JOIN
     zDIMENSIONI_X_PROGRAMMAZIONE dxp ON pind.ID_DIM_X_PROGRAMMAZIONE = dxp.ID_DIM_X_PROGRAMMAZIONE
        LEFT JOIN
        zPROGRAMMAZIONE pone ON dxp.ID_PROGRAMMAZIONE = pone.ID
     LEFT JOIN
     zDIMENSIONI dim ON dxp.ID_DIMENSIONE = dim.ID
     

