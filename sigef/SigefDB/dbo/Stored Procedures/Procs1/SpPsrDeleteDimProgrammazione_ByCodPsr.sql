
CREATE PROCEDURE [dbo].[SpPsrDeleteDimProgrammazione_ByCodPsr]
(
    @Psr              VARCHAR(20),
    @Dim              INT 
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @TDim VARCHAR(2),
            @Liv INT;

    SET @Liv  = 2;

    DELETE dxp
    FROM dbo.zProgrammazione AS pro
             INNER JOIN
             dbo.zPsr_Albero AS psr ON pro.Cod_Tipo = psr.Codice
         INNER JOIN
         dbo.zDimensioni_X_Programmazione AS dxp ON pro.Id = dxp.Id_Programmazione
    WHERE psr.Livello       = @Liv
      AND psr.Cod_Psr       = @Psr
      AND dxp.Id_Dimensione = @Dim

    SET NOCOUNT OFF;
END
