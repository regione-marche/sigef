CREATE TABLE [dbo].[UO] (
    [ID_UO]            INT           NOT NULL,
    [NOME]             VARCHAR (500) NOT NULL,
    [DATA_ATTIVAZIONE] DATE          NULL,
    [DATA_CHIUSURA]    DATE          NULL,
    [TIPO]             VARCHAR (40)  NULL,
    [ID_PADRE]         INT           NULL,
    [MATRICOLA_DIR]    INT           NULL,
    [COD_ENTE_SIGEF]   VARCHAR (15)  NULL,
    CONSTRAINT [PK_UO_REGIONE] PRIMARY KEY CLUSTERED ([ID_UO] ASC)
);

