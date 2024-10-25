CREATE PROCEDURE [dbo].[zRnaUpdateLogVisura]
(
	@IdRnaLogVisura INT, 
	--@IdImpresa INT, 
	--@IdFiscaleImpresa VARCHAR(16), 
	--@IdRichiesta VARCHAR(50), 
	--@TipoVisura VARCHAR(50), 
	--@CodiceEsito INT,  
	--@DescrizioneEsito NVARCHAR(max), 
	@CodiceStatoRichiesta INT,
	@DescrizioneStatoRichiesta NVARCHAR(max),
	@DataStatoRichiesta DATETIME,
	--@DataRichiesta DATETIME,
	@IdOperatore INT,
	@Payload VARBINARY(MAX)
	
)
AS
UPDATE RNA_LOG_VISURE
    SET
	--CODICE_ESITO = @CodiceEsito,
	--DESCRIZIONE_ESITO = @DescrizioneEsito,
	CODICE_STATO_RICHIESTA = @CodiceStatoRichiesta,
	DESCRIZIONE_STATO_RICHIESTA = @DescrizioneStatoRichiesta,
	DATA_STATO_RICHIESTA = @DataStatoRichiesta,
	ID_OPERATORE = @IdOperatore,
	DATA_AGGIORNAMENTO = GETDATE(),
	PAYLOAD=@Payload
WHERE 
ID_RNA_LOG_VISURA = @IdRnaLogVisura

