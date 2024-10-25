CREATE TABLE [dbo].[zDIMENSIONI] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [CODICE]            VARCHAR (50)    NOT NULL,
    [COD_DIM]           VARCHAR (50)    NOT NULL,
    [DESCRIZIONE]       VARCHAR (1000)  NULL,
    [METODO]            VARCHAR (255)   NULL,
    [VALORE]            DECIMAL (18, 2) NULL,
    [RICHIEDIBILE]      CHAR (1)        NULL,
    [UM]                VARCHAR (50)    NULL,
    [VALORE_BASE]       DECIMAL (18, 2) NULL,
    [PROCEDURA_CALCOLO] VARCHAR (255)   NULL,
    [ORDINE]            INT             NULL,
    CONSTRAINT [PK_zDIMENSIONI_1] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_zDIMENSIONI_zTIPO_DIMENSIONE] FOREIGN KEY ([COD_DIM]) REFERENCES [dbo].[zTIPO_DIMENSIONE] ([COD_DIM])
);

