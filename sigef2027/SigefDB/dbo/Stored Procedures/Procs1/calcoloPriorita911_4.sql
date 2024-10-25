﻿CREATE PROCEDURE [dbo].[calcoloPriorita911_4]
(
	@IdProgetto int,
	@fase_istruttoria bit,
	@IdVariante int =NULL
)
AS
BEGIN

--- DATA DI NASCITA DEL RAPP.LEGALE 
--  PUNTEGGIO SE ETA <40

	DECLARE  @Risultato INT, @ETA  INT
 
SELECT  @ETA= DATEDIFF(MM, PP.DATA_NASCITA ,PS.DATA)/12
FROM PROGETTO P
	INNER JOIN PROGETTO_STORICO PS ON PS.ID_PROGETTO= P.ID_PROGETTO AND COD_STATO='L'
	INNER JOIN VIMPRESA IMP ON P.ID_IMPRESA = IMP.ID_IMPRESA 
	INNER JOIN VPERSONE_X_IMPRESE PP ON PP.ID_PERSONE_X_IMPRESE= IMP.	ID_RAPPRLEGALE_ULTIMO
WHERE P.ID_PROGETTO = @IdProgetto
	 
	IF @ETA <40 SET @Risultato =1
	ELSE SET @Risultato =0 
	 
	 SELECT @Risultato AS PUNTEGGIO
END
