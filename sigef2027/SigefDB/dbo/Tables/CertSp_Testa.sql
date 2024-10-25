CREATE TABLE [dbo].[CertSp_Testa] (
    [IdCertSp]        INT           IDENTITY (1, 1) NOT NULL,
    [CodPsr]          VARCHAR (20)  NOT NULL,
    [DataInizio]      DATETIME      NULL,
    [DataFine]        DATETIME      NULL,
    [Id_File]         INT           NULL,
    [Note]            VARCHAR (500) NULL,
    [Definitivo]      BIT           NOT NULL,
    [Tipo]            CHAR (1)      NOT NULL,
    [DataInserimento] DATETIME      NOT NULL,
    [DataModifica]    DATETIME      NOT NULL,
    [Operatore]       VARCHAR (16)  NULL,
    [DataSegnatura]   DATETIME      NULL,
    [Segnatura]       VARCHAR (100) NULL,
	[Segnatura_Certificazione]       VARCHAR (100) NULL,
    CONSTRAINT [PK_CertSp_Testa] PRIMARY KEY CLUSTERED ([IdCertSp] ASC),
    CONSTRAINT [FK_CertSp_Testa_zPSR] FOREIGN KEY ([CodPsr]) REFERENCES [dbo].[zPSR] ([CODICE])
);

