CREATE TABLE [dbo].[CntrLoco_Testa] (
    [IdLoco]          INT           IDENTITY (1, 1) NOT NULL,
    [CodPsr]          VARCHAR (20)  NOT NULL,
    [DataInizio]      DATETIME      NULL,
    [DataFine]        DATETIME      NULL,
    [Note]            VARCHAR (500) NULL,
    [Definitivo]      BIT           NOT NULL,
    [DataInserimento] DATETIME      NOT NULL,
    [DataModifica]    DATETIME      NOT NULL,
    [Operatore]       VARCHAR (16)  NULL,
    [DataSegnatura]   DATETIME      NULL,
    [Segnatura]       VARCHAR (100) NULL,
    CONSTRAINT [PK_CntrLoco_Testa] PRIMARY KEY CLUSTERED ([IdLoco] ASC),
    CONSTRAINT [FK_CntrLoco_Testa_zPSR] FOREIGN KEY ([CodPsr]) REFERENCES [dbo].[zPSR] ([CODICE])
);

