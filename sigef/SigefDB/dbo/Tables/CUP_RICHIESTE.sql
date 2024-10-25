CREATE TABLE [dbo].[CUP_RICHIESTE] (
    [ID_CUP_RICHIESTA]                   INT            IDENTITY (1, 1) NOT NULL,
    [ID_RICHIESTA]                       INT            NOT NULL,
    [ID_PROGETTO]                        INT            NOT NULL,
    [CODICE_CUP]                         VARCHAR (30)   NULL,
    [DATA_RICHIESTA_CUP]                 DATETIME       NULL,
    [ISTANZA_RICHIESTA]                  XML            NULL,
    [ISTANZA_RISPOSTA]                   XML            NULL,
    [ID_RICHIESTA_ASSEGNATA_CUP]         INT            NULL,
    [ESITO_ELABORAZIONE_CUP]             VARCHAR (10)   NULL,
    [DESCRIZIONE_ESITO_ELABORAZIONE_CUP] NVARCHAR (MAX) NULL,
    [TIPO_ESITO]                         VARCHAR (100)  NULL,
    [ID_OPERATORE]                       INT            NULL,
    [DATA_INSERIMENTO]                   DATETIME       NULL,
    [DATA_AGGIORNAMENTO]                 DATETIME       NULL,
    CONSTRAINT [PK_RichiesteCup] PRIMARY KEY CLUSTERED ([ID_CUP_RICHIESTA] ASC)
);

