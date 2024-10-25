﻿CREATE TABLE [dbo].[zOB_MISURA_X_PSR] (
    [COD_OB_PSR]   VARCHAR (10) NOT NULL,
    [ID_OB_MISURA] INT          NOT NULL,
    CONSTRAINT [PK_zOB_MISURA_X_PSR] PRIMARY KEY CLUSTERED ([COD_OB_PSR] ASC, [ID_OB_MISURA] ASC) WITH (FILLFACTOR = 80),
    CONSTRAINT [FK_zOB_MISURA_X_PSR_zOB_MISURA] FOREIGN KEY ([ID_OB_MISURA]) REFERENCES [dbo].[zOB_MISURA] ([ID]),
    CONSTRAINT [FK_zOB_MISURA_X_PSR_zOB_PSR] FOREIGN KEY ([COD_OB_PSR]) REFERENCES [dbo].[zOB_PSR] ([CODICE])
);

