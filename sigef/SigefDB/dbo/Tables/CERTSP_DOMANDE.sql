CREATE TABLE [dbo].[CERTSP_DOMANDE] (
    [ID_DOMANDA]        INT             IDENTITY (1, 1) NOT NULL,
    [ID_ATTO]           INT             NOT NULL,
    [DATA_PRES]         DATETIME        NULL,
    [SPESE_AMM]         DECIMAL (18, 2) NULL,
    [SPESA_PUBB]        DECIMAL (18, 2) NULL,
    [SF_TOT]            DECIMAL (18, 2) NULL,
    [SF_SPESA_PUBB]     DECIMAL (18, 2) NULL,
    [SF_SPESE_AMM]      DECIMAL (18, 2) NULL,
    [SF_SPESA_PUBB_AMM] DECIMAL (18, 2) NULL,
    [AS_TOT]            DECIMAL (18, 2) NULL,
    [AS_COPERTO]        DECIMAL (18, 2) NULL,
    [AS_NON_COPERTO]    DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_CERTSP_DOMANDE] PRIMARY KEY CLUSTERED ([ID_DOMANDA] ASC)
);

