﻿CREATE TABLE [dbo].[zDIMENSIONI_ESTRAZIONI_IO] (
    [ID_ESTRAZIONE_IO]  INT             IDENTITY (1, 1) NOT NULL,
    [DATA_ESTRAZIONE]   DATETIME        NULL,
    [COD_PSR]           VARCHAR (20)    NOT NULL,
    [ID_DIM_PRIORITA]   INT             NULL,
    [ID_DIM_INDICATORE] INT             NULL,
    [VALORE_RTOT]       DECIMAL (18, 2) NULL,
    [VALORE_PF]         DECIMAL (18, 2) NULL,
    [DATA_PF]           DATETIME        NULL,
    [VALORE_F]          DECIMAL (18, 2) NULL,
    [DATA_F]            DATETIME        NULL,
    [ID_ESTRAZIONE]     INT             NULL,
    CONSTRAINT [PK_zDIMENSIONI_ESTRAZIONI_IO] PRIMARY KEY CLUSTERED ([ID_ESTRAZIONE_IO] ASC),
    CONSTRAINT [FK_zDIMENSIONI_ESTRAZIONI_IO_zDIMENSIONI] FOREIGN KEY ([ID_DIM_PRIORITA]) REFERENCES [dbo].[zDIMENSIONI] ([ID]),
    CONSTRAINT [FK_zDIMENSIONI_ESTRAZIONI_IO_zDIMENSIONI_1] FOREIGN KEY ([ID_DIM_INDICATORE]) REFERENCES [dbo].[zDIMENSIONI] ([ID]),
    CONSTRAINT [FK_zDIMENSIONI_ESTRAZIONI_IO_zDIMENSIONI_ESTRAZIONI_T] FOREIGN KEY ([ID_ESTRAZIONE]) REFERENCES [dbo].[zDIMENSIONI_ESTRAZIONI_T] ([ID_ESTRAZIONE]),
    CONSTRAINT [FK_zDIMENSIONI_ESTRAZIONI_IO_zPSR] FOREIGN KEY ([COD_PSR]) REFERENCES [dbo].[zPSR] ([CODICE])
);
