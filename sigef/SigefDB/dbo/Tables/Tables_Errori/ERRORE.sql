﻿-- DROP TABLE ERRORE;
CREATE TABLE ERRORE
(
	ID_ERRORE INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	ID_PROGETTO INT,
	ID_DOMANDA_PAGAMENTO INT,
	CF_INSERIMENTO VARCHAR(16) NOT NULL,
	DATA_INSERIMENTO DATETIME NOT NULL,
	CF_MODIFICA VARCHAR(16) NOT NULL,
	DATA_MODIFICA DATETIME NOT NULL DEFAULT GETDATE(),
	DATA_RILEVAZIONE DATETIME NOT NULL,
	--ID_IMPRESA_BENEFICIARIO INT,
	IMPRESE_BENEFICIARI VARCHAR(MAX),
	SOGGETTO_RILEVAZIONE VARCHAR(MAX),
	CERTIFICATO BIT,
	ID_LOTTO_CERTIFICAZIONE INT,
	DATA_INIZIO_CERTIFICAZIONE DATETIME, --DATA_CERTIFICAZIONE DATETIME,
	SPESA_AMMESSA_ERRORE DECIMAL(18,2),
	CONTRIBUTO_PUBBLICO_ERRORE DECIMAL(18,2),
	DA_RECUPERARE BIT,
	RECUPERATO BIT,
	AZIONE_CERTIFICAZIONE VARCHAR(100),
	ID_LOTTO_IMPATTATO INT,
	NOTE VARCHAR(MAX),
	DATA_FINE_CERTIFICAZIONE DATETIME
);

ALTER TABLE ERRORE WITH CHECK ADD CONSTRAINT [FK_ERRORE_PROGETTO] FOREIGN KEY(ID_PROGETTO)
REFERENCES PROGETTO (ID_PROGETTO)
GO

ALTER TABLE ERRORE CHECK CONSTRAINT [FK_ERRORE_PROGETTO]
GO

/*
ALTER TABLE ERRORE WITH CHECK ADD CONSTRAINT [FK_ERRORE_DOMANDA_DI_PAGAMENTO] FOREIGN KEY(ID_DOMANDA_PAGAMENTO)
REFERENCES DOMANDA_DI_PAGAMENTO (ID_DOMANDA_PAGAMENTO)
GO

ALTER TABLE ERRORE CHECK CONSTRAINT [FK_ERRORE_DOMANDA_DI_PAGAMENTO]
GO
*/
