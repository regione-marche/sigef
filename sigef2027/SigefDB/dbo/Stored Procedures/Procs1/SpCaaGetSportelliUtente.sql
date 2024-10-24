﻿create PROCEDURE [dbo].[SpCaaGetSportelliUtente]
(
	@ID_UTENTE INT,
	@COD_ENTE VARCHAR(10)=NULL,
	@PROVINCIA CHAR(2)=NULL
)
AS	
	DECLARE @COD_TIPO_ENTE_OPERATORE VARCHAR(10),@COD_ENTE_OPERATORE VARCHAR(10),@PROFILO_OPERATORE VARCHAR(50)
	SELECT @COD_TIPO_ENTE_OPERATORE=U.COD_TIPO_ENTE,@COD_ENTE_OPERATORE=U.COD_ENTE,@PROFILO_OPERATORE=U.PROFILO
	FROM VUTENTI U WHERE U.ID_UTENTE=@ID_UTENTE
	
	IF @COD_TIPO_ENTE_OPERATORE IN ('%','RM','ADC')
		SELECT * FROM vCAA_SPORTELLO WHERE (@COD_ENTE IS NULL OR COD_ENTE=@COD_ENTE) 
		AND (@PROVINCIA IS NULL OR PROVINCIA=@PROVINCIA) ORDER BY CODICE
	ELSE IF @COD_TIPO_ENTE_OPERATORE='CAA' BEGIN
		IF @PROFILO_OPERATORE='Responsabile regionale'
			SELECT * FROM vCAA_SPORTELLO WHERE COD_ENTE=@COD_ENTE_OPERATORE
			AND (@PROVINCIA IS NULL OR PROVINCIA=@PROVINCIA) ORDER BY CODICE
		ELSE 
			SELECT S.* FROM vCAA_SPORTELLO S INNER JOIN VCAA_OPERATORI O ON S.CODICE=O.CODICE_SPORTELLO			
			WHERE S.COD_ENTE=@COD_ENTE_OPERATORE AND O.ID_UTENTE=@ID_UTENTE AND O.COD_STATO='A' 
				AND (@PROVINCIA IS NULL OR S.PROVINCIA=@PROVINCIA) ORDER BY CODICE
	END
