CREATE TABLE [dbo].[TIPO_ATECO2007] (
    [COD_TIPO_ATECO2007] CHAR (9)       NOT NULL,
    [Sezione]            VARCHAR (8)    NOT NULL,
    [Divisione]          VARCHAR (8)    NOT NULL,
    [Gruppo]             VARCHAR (8)    NOT NULL,
    [Classe]             VARCHAR (8)    NOT NULL,
    [Categoria]          VARCHAR (8)    NOT NULL,
    [Sottocategoria]     VARCHAR (8)    NOT NULL,
    [Descrizione]        NVARCHAR (255) NOT NULL,
    [ELIMINATO]          BIT            NOT NULL,
    CONSTRAINT [PK_TIPO_ATECO2007] PRIMARY KEY CLUSTERED ([COD_TIPO_ATECO2007] ASC)
);

