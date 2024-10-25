CREATE PROCEDURE ZRnaBandoConfigInsert
(
	@IdBando INT, 
	@CodBandoRna INT, 
	@DataPrevistaConcessione DATETIME, 
	@Cumulabilita VARCHAR(255)
)
AS
	INSERT INTO RNA_BANDO_CONFIG
	(
		ID_BANDO, 
		COD_BANDO_RNA, 
		DATA_PREVISTA_CONCESSIONE, 
		CUMULABILITA
	)
	VALUES
	(
		@IdBando, 
		@CodBandoRna, 
		@DataPrevistaConcessione, 
		@Cumulabilita
	)
	SELECT SCOPE_IDENTITY() AS ID_RNA_BANDO_CONFIG

GO