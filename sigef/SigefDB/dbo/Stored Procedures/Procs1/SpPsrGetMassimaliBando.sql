﻿CREATE PROCEDURE [dbo].[SpPsrGetMassimaliBando]
(
	@ID_BANDO INT
)
AS
	DECLARE @ID_MISURA_BANDO INT	
	SELECT @ID_MISURA_BANDO=ID_PROGRAMMAZIONE FROM BANDO WHERE ID_BANDO=@ID_BANDO

	DECLARE @BPROG TABLE (ID INT,COD_TIPO VARCHAR(30),CODICE VARCHAR(20),DESCRIZIONE VARCHAR(2000),ID_PADRE INT,COD_PSR VARCHAR(20),
		TIPO VARCHAR(50),LIVELLO INT,ATTIVAZIONE_BANDI BIT,ATTIVAZIONE_FA BIT,ATTIVAZIONE_OB_MISURA BIT,ATTIVAZIONE_INVESTIMENTI BIT,
		ATTIVAZIONE_FF BIT,IMPORTO_DOTAZIONE DECIMAL(18,2),PATH_LABEL VARCHAR(20))
	INSERT INTO @BPROG
	exec SpPsrGetProgrammazione NULL,@ID_MISURA_BANDO,0,0,0,1,0

	SELECT M.ID,M.ID_BANDO,P.ID AS ID_PROGRAMMAZIONE,M.QUOTA,M.IMPORTO,P.CODICE,P.DESCRIZIONE
	FROM @BPROG P LEFT JOIN BANDO_PROGRAMMAZIONE BP ON P.ID=BP.ID_PROGRAMMAZIONE
	LEFT JOIN BANDO_MASSIMALI M ON P.ID=M.ID_PROGRAMMAZIONE AND M.ID_BANDO=@ID_BANDO
	WHERE BP.ID_BANDO=@ID_BANDO
