

CREATE PROCEDURE [dbo].[SpPsrGetDimProgrammazione_ByIdDimensione]
(
    @Dim INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT dxp.ID_PROGRAMMAZIONE, 
           dxp.ID_DIMENSIONE, 
           dxp.ID_DIM_X_PROGRAMMAZIONE, 
           dim.COD_DIM, 
           pro.CODICE             AS COD_PROGRAMMAZIONE, 
           pro.DESCRIZIONE        AS DES_PROGRAMMAZIONE,
           psr.DESCRIZIONE        AS LIVELLO_PROGRAMMAZIONE,
           dim.CODICE             AS COD_DIMENSIONE, 
           dim.DESCRIZIONE        AS DES_DIMENSIONE, 
           dim.UM
    FROM dbo.zProgrammazione AS pro
             INNER JOIN
             dbo.zPsr_Albero AS psr ON pro.Cod_Tipo = psr.Codice
         INNER JOIN
         dbo.zDimensioni_X_Programmazione AS dxp ON pro.Id = dxp.Id_Programmazione
         INNER JOIN
         dbo.zDimensioni AS dim ON dxp.Id_Dimensione = dim.Id
    WHERE dim.ID = @Dim
    ORDER BY pro.Codice
    
    SET NOCOUNT OFF;
END

