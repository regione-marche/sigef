﻿CREATE TABLE [dbo].[CertSp_Dettaglio] (
    [IdCertSp_Dettaglio]                     INT             IDENTITY (1, 1) NOT NULL,
    [IdCertSp]                               INT             NOT NULL,
    [Id_Domanda_Pagamento]                   INT             NOT NULL,
    [Id_Progetto]                            INT             NOT NULL,
    [Asse]                                   VARCHAR (20)    NOT NULL,
    [Selezionata]                            BIT             NOT NULL,
    [Esito]                                  CHAR (1)        NULL,
    [DataEsito]                              DATETIME        NULL,
    [Id_File]                                INT             NULL,
    [CostoTotale]                            DECIMAL (18, 2) NULL,
    [ImportoAmmesso]                         DECIMAL (18, 2) NULL,
    [ImportoConcesso]                        DECIMAL (18, 2) NULL,
    [Beneficiario]                           VARCHAR (155)   NULL,
    [SpesaAmmessa]                           DECIMAL (18, 2) NULL,
    [ImportoContributoPubblico]              DECIMAL (18, 2) NULL,
    [SpesaAmmessa_Incrementale]              DECIMAL (18, 2) NULL,
    [ImportoContributoPubblico_Incrementale] DECIMAL (18, 2) NULL,
    [Note]                                   VARCHAR (2000)  NULL,
    [Operatore]                              VARCHAR (16)    NULL,
    [DataInserimento]                        DATETIME        NOT NULL,
    [DataModifica]                           DATETIME        NOT NULL,
    [QuotaUe]                                DECIMAL (18, 2) NULL,
    [QuotaStato]                             DECIMAL (18, 2) NULL,
    [QuotaRegione]                           DECIMAL (18, 2) NULL,
    [QuotaPrivato]                           DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_CertSp_Dettaglio] PRIMARY KEY CLUSTERED ([IdCertSp_Dettaglio] ASC),
    CONSTRAINT [FK_CertSp_Dettaglio_CertSp_Testa] FOREIGN KEY ([IdCertSp]) REFERENCES [dbo].[CertSp_Testa] ([IdCertSp]),
    CONSTRAINT [FK_CertSp_Dettaglio_DOMANDA_DI_PAGAMENTO] FOREIGN KEY ([Id_Domanda_Pagamento]) REFERENCES [dbo].[DOMANDA_DI_PAGAMENTO] ([ID_DOMANDA_PAGAMENTO])
);
