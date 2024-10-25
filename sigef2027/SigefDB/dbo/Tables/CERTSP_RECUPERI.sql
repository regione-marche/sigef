CREATE TABLE [dbo].[CERTSP_RECUPERI] (
    [Id_Recupero]     INT             IDENTITY (1, 1) NOT NULL,
    [Id_Progetto]     INT             NOT NULL,
    [Id_Atto]         INT             NOT NULL,
    [Sostegno]        DECIMAL (18, 2) NULL,
    [Spese_Amm]       DECIMAL (18, 2) NULL,
    [Data_Ricev_Rimb] DATETIME        NULL,
    [Rimb_Sostegno]   DECIMAL (18, 2) NULL,
    [Rimb_Spese_Amm]  DECIMAL (18, 2) NULL,
    [NonR_Sostegno]   DECIMAL (18, 2) NULL,
    [NonR_Spese_Amm]  DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_CERTSP_RECUPERI] PRIMARY KEY CLUSTERED ([Id_Recupero] ASC)
);

