

CREATE PROCEDURE [dbo].[SpPsrGetDimProgrammazione_ByCodPsr]
(
    @Psr VARCHAR(20),
    @Dim INT
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TDim VARCHAR(2),
            @Liv INT;

    SET @TDim = 'PI';
    SET @Liv = 2;

    SELECT pro.Id                 AS ID_PROGRAMMAZIONE, 
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
         LEFT JOIN
         dbo.zDimensioni_X_Programmazione AS dxp ON pro.Id            = dxp.Id_Programmazione
                                                AND dxp.ID_DIMENSIONE = @Dim
         LEFT JOIN
         dbo.zDimensioni AS dim ON dxp.Id_Dimensione = dim.Id
                               AND dim.Cod_Dim       = @TDim
    WHERE psr.Livello = @Liv
      AND psr.Cod_Psr = @Psr
      AND pro.id NOT IN (SELECT pro2.id
                           FROM dbo.zProgrammazione AS pro2
                                    INNER JOIN
                                    dbo.zPsr_Albero AS psr2 ON pro2.Cod_Tipo = psr2.Codice
                                INNER JOIN
                                dbo.zDimensioni_X_Programmazione AS dxp2 ON pro2.Id = dxp2.Id_Programmazione
                                INNER JOIN
                                dbo.zDimensioni AS dim2 ON dxp2.Id_Dimensione = dim2.Id
                                                       
                         WHERE dxp2.ID_DIMENSIONE <> @Dim
                           AND dim2.Cod_Dim       =  @TDim
                           AND psr.Livello        =  @Liv
                           AND psr.Cod_Psr        =  @Psr
                         )
    ORDER BY pro.Codice
    SET NOCOUNT OFF;
END

