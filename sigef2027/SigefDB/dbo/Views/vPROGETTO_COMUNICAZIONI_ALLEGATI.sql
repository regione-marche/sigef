﻿


CREATE VIEW [dbo].[vPROGETTO_COMUNICAZIONI_ALLEGATI]
AS
SELECT     dbo.PROGETTO_COMUNICAZIONI_ALLEGATI.ID, dbo.PROGETTO_COMUNICAZIONI_ALLEGATI.ID_COMUNICAZIONE, 
                      dbo.PROGETTO_COMUNICAZIONI_ALLEGATI.ID_PROGETTO_ALLEGATI, dbo.PROGETTO_COMUNICAZIONI_ALLEGATI.ID_ALLEGATO, 
                      dbo.PROGETTO_COMUNICAZIONI_ALLEGATI.ID_NOTE, dbo.NOTE.TESTO AS NOTE, dbo.vPROGETTO_ALLEGATI.DESCRIZIONE_BREVE, 
                      dbo.vPROGETTO_ALLEGATI.NUMERO, dbo.vPROGETTO_ALLEGATI.DATA, dbo.vPROGETTO_ALLEGATI.ENTE, dbo.vPROGETTO_ALLEGATI.ID_PROGETTO, 
                      dbo.vPROGETTO_ALLEGATI.ID_COMUNE, dbo.vPROGETTO_ALLEGATI.COD_ENTE_EMETTITORE, ISNULL(dbo.ALLEGATI.DESCRIZIONE, 
                      dbo.vPROGETTO_ALLEGATI.ALLEGATO) AS ALLEGATO, ISNULL(dbo.ALLEGATI.COD_TIPO, dbo.vPROGETTO_ALLEGATI.COD_TIPO) AS COD_TIPO
FROM         dbo.PROGETTO_COMUNICAZIONI_ALLEGATI LEFT OUTER JOIN
                      dbo.ALLEGATI ON dbo.PROGETTO_COMUNICAZIONI_ALLEGATI.ID_ALLEGATO = dbo.ALLEGATI.ID_ALLEGATO LEFT OUTER JOIN
                      dbo.vPROGETTO_ALLEGATI ON dbo.PROGETTO_COMUNICAZIONI_ALLEGATI.ID_PROGETTO_ALLEGATI = dbo.vPROGETTO_ALLEGATI.ID LEFT OUTER JOIN
                      dbo.NOTE ON dbo.PROGETTO_COMUNICAZIONI_ALLEGATI.ID_NOTE = dbo.NOTE.ID


