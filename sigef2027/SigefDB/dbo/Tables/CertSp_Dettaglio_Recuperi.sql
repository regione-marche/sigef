CREATE TABLE [dbo].[CertSp_Dettaglio_Recuperi](
	[IdCertSp_Dettaglio]            int				NOT NULL,
	[Id_Registro_Recupero]          int				NULL,
	[Importo_da_Recuperare_totale]  decimal(15, 2)	NULL,
	[Importo_preRitiro]             decimal(15, 2)	NULL,
	[Data_Segnatura]                datetime		NULL,
	[Segnatura]                     varchar(100)	NULL,
	[ID_ERRORE]						INT				NULL,
	[CONTRIBUTO_PUBBLICO_ERRORE]	DECIMAL(18, 2)	NULL,
	[Id_CertSp_Dettaglio_Recuperi]	INT				NOT NULL	IDENTITY,
	CONSTRAINT [PK_CertSp_Dettaglio_Recuperi] PRIMARY KEY  ([Id_CertSp_Dettaglio_Recuperi]),
	CONSTRAINT [FK_CertSp_Dettaglio_Recuperi_CertSp_Dettaglio]  FOREIGN KEY([IdCertSp_Dettaglio])   REFERENCES [dbo].[CertSp_Dettaglio] ([IdCertSp_Dettaglio]),
	CONSTRAINT [FK_CertSp_Dettaglio_Recuperi_REGISTRO_RECUPERO] FOREIGN KEY([Id_Registro_Recupero]) REFERENCES [dbo].[REGISTRO_RECUPERO] ([ID_REGISTRO_RECUPERO]),
	CONSTRAINT [FK_CertSp_Dettaglio_Recuperi_ERRORE] FOREIGN KEY([ID_ERRORE]) REFERENCES [dbo].[ERRORE] ([ID_ERRORE])
);