CREATE VIEW dbo.vzDIMENSIONI_ESTRAZIONI_IR
AS
SELECT  dir.ID_ESTRAZIONE_IR,
        dir.CODICE_PSR,
        dir.ID_DIMENSIONE,
        dir.DATA_INIZIO,
        dir.DATA_FINE,
        dir.VALORE_BASE,
        dir.VALORE_OBBIETTIVO,
        dir.VALORE_REALIZZATO,
        dir.UM,
        dir.CODICE_OBMISURA,
        dim.CODICE              AS DIMENSIONE_CODICE,
        dim.DESCRIZIONE         AS DIMENSIONE_DESCRIZIONE,
        dim.Ordine              AS DIMENSIONE_ORDINE,
        YEAR(dir.Data_Inizio)   AS ANNO
FROM zDimensioni_Estrazioni_Ir dir
     INNER JOIN
     zDimensioni dim ON dir.Id_Dimensione = dim.Id