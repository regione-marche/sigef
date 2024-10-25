CREATE TABLE [dbo].[FASCICOLO_PALEO] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [ANNO]                 INT            NOT NULL,
    [COD_TIPO]             VARCHAR (30)   NOT NULL,
    [FASCICOLO]            VARCHAR (200)  NOT NULL,
    [PROVINCIA]            CHAR (2)       NULL,
    [COD_ENTE]             VARCHAR (10)   NOT NULL,
    [ATTIVO]               BIT            CONSTRAINT [DF_FASCICOLO_PALEO_ATTIVO] DEFAULT ((0)) NOT NULL,
    [DATA_INIZIO_VALIDITA] DATETIME       NOT NULL,
    [DATA_FINE_VALIDITA]   DATETIME       NULL,
    [NOTE]                 VARCHAR (1000) NULL,
    CONSTRAINT [PK_FASCICOLO_PALEO] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 100)
);

