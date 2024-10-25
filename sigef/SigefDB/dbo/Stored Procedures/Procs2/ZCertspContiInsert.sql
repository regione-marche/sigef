CREATE PROCEDURE [dbo].[ZCertspContiInsert]
(
	@IdProgetto INT, 
	@IdAtto INT, 
	@DataPresContab DATETIME, 
	@DataPresConti DATETIME, 
	@TotRegistrate DECIMAL(18,2), 
	@TotSpesapubRegistrate DECIMAL(18,2), 
	@TotPagamentiRegistrate DECIMAL(18,2), 
	@TotRitirata DECIMAL(18,2), 
	@TotSpesapubRitirata DECIMAL(18,2), 
	@TotRecuperata DECIMAL(18,2), 
	@TotSpesapubRecuperata DECIMAL(18,2), 
	@TotDarecuperare DECIMAL(18,2), 
	@TotSpesapubDarecuperare DECIMAL(18,2), 
	@TotNonrecuperab DECIMAL(18,2), 
	@TotSpesapubNonrecuperab DECIMAL(18,2), 
	@RecuperatoArt71 DECIMAL(18,2), 
	@RecuperatoArt71Pubblica DECIMAL(18,2)
)
AS
	INSERT INTO CERTSP_CONTI
	(
		ID_PROGETTO, 
		ID_ATTO, 
		DATA_PRES_CONTAB, 
		DATA_PRES_CONTI, 
		TOT_REGISTRATE, 
		TOT_SPESAPUB_REGISTRATE, 
		TOT_PAGAMENTI_REGISTRATE, 
		TOT_RITIRATA, 
		TOT_SPESAPUB_RITIRATA, 
		TOT_RECUPERATA, 
		TOT_SPESAPUB_RECUPERATA, 
		TOT_DARECUPERARE, 
		TOT_SPESAPUB_DARECUPERARE, 
		TOT_NONRECUPERAB, 
		TOT_SPESAPUB_NONRECUPERAB, 
		RECUPERATO_ART71, 
		RECUPERATO_ART71_PUBBLICA
	)
	VALUES
	(
		@IdProgetto, 
		@IdAtto, 
		@DataPresContab, 
		@DataPresConti, 
		@TotRegistrate, 
		@TotSpesapubRegistrate, 
		@TotPagamentiRegistrate, 
		@TotRitirata, 
		@TotSpesapubRitirata, 
		@TotRecuperata, 
		@TotSpesapubRecuperata, 
		@TotDarecuperare, 
		@TotSpesapubDarecuperare, 
		@TotNonrecuperab, 
		@TotSpesapubNonrecuperab, 
		@RecuperatoArt71, 
		@RecuperatoArt71Pubblica
	)
	SELECT SCOPE_IDENTITY() AS ID_CONTO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCertspContiInsert]
(
	@IdProgetto INT, 
	@IdAtto INT, 
	@DataPresContab DATETIME, 
	@DataPresConti DATETIME, 
	@TotRegistrate DECIMAL(18,2), 
	@TotSpesapubRegistrate DECIMAL(18,2), 
	@TotPagamentiRegistrate DECIMAL(18,2), 
	@TotRitirata DECIMAL(18,2), 
	@TotSpesapubRitirata DECIMAL(18,2), 
	@TotRecuperata DECIMAL(18,2), 
	@TotSpesapubRecuperata DECIMAL(18,2), 
	@TotDarecuperare DECIMAL(18,2), 
	@TotSpesapubDarecuperare DECIMAL(18,2), 
	@RecuperatoArt71 BIT, 
	@TotNonrecuperab DECIMAL(18,2), 
	@TotSpesapubNonrecuperab DECIMAL(18,2)
)
AS
	INSERT INTO CERTSP_CONTI
	(
		ID_PROGETTO, 
		ID_ATTO, 
		DATA_PRES_CONTAB, 
		DATA_PRES_CONTI, 
		TOT_REGISTRATE, 
		TOT_SPESAPUB_REGISTRATE, 
		TOT_PAGAMENTI_REGISTRATE, 
		TOT_RITIRATA, 
		TOT_SPESAPUB_RITIRATA, 
		TOT_RECUPERATA, 
		TOT_SPESAPUB_RECUPERATA, 
		TOT_DARECUPERARE, 
		TOT_SPESAPUB_DARECUPERARE, 
		RECUPERATO_ART71, 
		TOT_NONRECUPERAB, 
		TOT_SPESAPUB_NONRECUPERAB
	)
	VALUES
	(
		@IdProgetto, 
		@IdAtto, 
		@DataPresContab, 
		@DataPresConti, 
		@TotRegistrate, 
		@TotSpesapubRegistrate, 
		@TotPagamentiRegistrate, 
		@TotRitirata, 
		@TotSpesapubRitirata, 
		@TotRecuperata, 
		@TotSpesapubRecuperata, 
		@TotDarecuperare, 
		@TotSpesapubDarecuperare, 
		@RecuperatoArt71, 
		@TotNonrecuperab, 
		@TotSpesapubNonrecuperab
	)
	SELECT SCOPE_IDENTITY() AS ID_CONTO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspContiInsert';

