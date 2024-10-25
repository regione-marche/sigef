CREATE TABLE [dbo].[TIPO_CUP_CATEGORIE] (
    [COD_CUP_CATEGORIE] CHAR (7)       NOT NULL,
    [Settore]           CHAR (2)       NOT NULL,
    [Sottosettore]      CHAR (2)       NULL,
    [Categoria]         CHAR (3)       NULL,
    [Descrizione]       NVARCHAR (255) NOT NULL,
    [Eliminato]         BIT            NOT NULL,
    CONSTRAINT [PK_TIPO_CUP_CATEGORIE] PRIMARY KEY CLUSTERED ([COD_CUP_CATEGORIE] ASC) WITH (FILLFACTOR = 100)
);

