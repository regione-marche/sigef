CREATE PROCEDURE [dbo].[zIgrueInsertCodProcAttivazione]

	@IdBando INT,
	@CodProceduraAttivazione VARCHAR(50),
	@DataAssegnazione DATETIME
AS
BEGIN
	INSERT INTO BANDO_CODICI_ATTIVAZIONE
(
   ID_BANDO,
   COD_PROCEDURA_ATTIVAZIONE, 
   DATA_INSERIMENTO,
   DATA_AGGIORNAMENTO,
   DATA_ASSEGNAZIONE
)
VALUES
(
	@IdBando,
	@CodProceduraAttivazione,
	GETDATE(),
	GETDATE(),
	@DataAssegnazione

)
END
