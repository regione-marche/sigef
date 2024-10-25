﻿CREATE TABLE [dbo].[zPROGRAMMAZIONE_TARGET] (
    [ID_PROGRAMMAZIONE] INT             NOT NULL,
    [ANNO]              INT             NOT NULL,
    [IMPORTO_TARGET]    DECIMAL (18, 2) CONSTRAINT [DF_zPROGRAMMAZIONE_TARGET_IMPORTO_TARGET] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_zPROGRAMMAZIONE_TARGET] PRIMARY KEY CLUSTERED ([ID_PROGRAMMAZIONE] ASC, [ANNO] ASC)
);

