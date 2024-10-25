CREATE TABLE [dbo].[REGISTRO_CONTRIBUTI_ESTERNI_IMPRESA] (
    [ID]                    INT             IDENTITY (1, 1) NOT NULL,
    [REF_ID]                INT             NOT NULL,
    [CUAA]                  VARCHAR (16)    NOT NULL,
    [PARTITA_IVA]           CHAR (11)       NOT NULL,
    [CONTRIBUTO_PERCEPITO]  DECIMAL (18, 2) NOT NULL,
    [CONTRIBUTO_RECUPERATO] DECIMAL (18, 2) NULL,
    [TIPO_RECUPERO]         CHAR (3)        NULL,
    [ID_ATTO]               INT             NULL,
    [DATA_ATTO]             DATETIME        NULL,
    [TIPO_ATTO]             VARCHAR (255)   NULL,
    [NOTE]                  NTEXT           NULL,
    CONSTRAINT [PK_REGISTRO_CONTRIBUTI_ESTERNI_IMPRESA] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 80)
);

