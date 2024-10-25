CREATE TABLE [dbo].[TIPO_CUP_CATEGORIE_SOGGETTI] (
    [COD_CUP_CATEGORIE_SOGGETTI] CHAR (6)       NOT NULL,
    [CodiceCategoria]            CHAR (2)       NOT NULL,
    [CodiceSottocategoria]       CHAR (4)       NULL,
    [Descrizione]                NVARCHAR (500) NOT NULL,
    [ELIMINATO]                  BIT            NOT NULL,
    CONSTRAINT [PK_TIPO_CUP_CATEGORIE_SOGGETTI] PRIMARY KEY CLUSTERED ([COD_CUP_CATEGORIE_SOGGETTI] ASC) WITH (FILLFACTOR = 100)
);

