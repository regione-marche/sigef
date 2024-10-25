﻿-- DROP TABLE ERRORE_ALLEGATI;
CREATE TABLE ERRORE_ALLEGATI
(
	ID_ERRORE_ALLEGATI INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	ID_ERRORE INT NOT NULL,
	PROTOCOLLATO BIT,
	SEGNATURA_ALLEGATO VARCHAR(100),
	ID_ALLEGATO INT,
	CF_INSERIMENTO VARCHAR(16) NOT NULL,
	DATA_INSERIMENTO DATETIME NOT NULL,
	CF_MODIFICA VARCHAR(16) NOT NULL,
	DATA_MODIFICA DATETIME NOT NULL DEFAULT GETDATE()
);

ALTER TABLE ERRORE_ALLEGATI WITH CHECK ADD CONSTRAINT [FK_ERRORE_ALLEGATI_ERRORE] FOREIGN KEY(ID_ERRORE)
REFERENCES ERRORE (ID_ERRORE)
GO

ALTER TABLE ERRORE_ALLEGATI CHECK CONSTRAINT [FK_ERRORE_ALLEGATI_ERRORE]
GO

ALTER TABLE ERRORE_ALLEGATI WITH CHECK ADD CONSTRAINT [FK_ERRORE_ALLEGATI_ARCHIVIO_FILE] FOREIGN KEY(ID_ALLEGATO)
REFERENCES ARCHIVIO_FILE (ID)
GO

ALTER TABLE ERRORE_ALLEGATI CHECK CONSTRAINT [FK_ERRORE_ALLEGATI_ARCHIVIO_FILE]
GO