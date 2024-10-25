CREATE PROCEDURE [dbo].[zIgrueGetCodProcAttivazioneByCodProcAtt]
	(
		@CodProcedura VARCHAR(50)
	)
AS
BEGIN
	SELECT * FROM BANDO_CODICI_ATTIVAZIONE
	WHERE
	COD_PROCEDURA_ATTIVAZIONE = @CodProcedura
	
END
