﻿CREATE TABLE [dbo].[GANTT_UO_SIGEF] (
    [ID]             INT          IDENTITY (1, 1) NOT NULL,
    [ID_UO]          INT          NULL,
    [COD_ENTE_SIGEF] VARCHAR (10) NULL,
    CONSTRAINT [PK_GANTT_UO_SIGEF] PRIMARY KEY CLUSTERED ([ID] ASC)
);

