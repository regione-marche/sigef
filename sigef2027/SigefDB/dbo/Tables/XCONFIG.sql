CREATE TABLE [dbo].[XCONFIG] (
    [TIPO_CONFIGURAZIONE] VARCHAR (50)  NOT NULL,
    [LOGIN]               VARCHAR (50)  NULL,
    [PWD]                 VARCHAR (50)  NULL,
    [DOMINIO]             VARCHAR (50)  NULL,
    [IP_INTERNO]          VARCHAR (50)  NULL,
    [DEFAULT_DIRECTORY]   VARCHAR (50)  NULL,
    [ATTIVO]              BIT           NOT NULL,
    [NOME]                VARCHAR (50)  NULL,
    [COGNOME]             VARCHAR (50)  NULL,
    [RUOLO]               VARCHAR (50)  NULL,
    [CODICE_UO]           VARCHAR (50)  NULL,
    [WS_BINDING]          VARCHAR (100) NULL,
    [DATA]                DATETIME      NULL,
    CONSTRAINT [PK_XCONFIG] PRIMARY KEY CLUSTERED ([TIPO_CONFIGURAZIONE] ASC) WITH (FILLFACTOR = 100)
);

