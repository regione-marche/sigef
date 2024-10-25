CREATE PROCEDURE [dbo].[ZCertspContiUpdate]
(
	@IdConto INT, 
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
	UPDATE CERTSP_CONTI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_ATTO = @IdAtto, 
		DATA_PRES_CONTAB = @DataPresContab, 
		DATA_PRES_CONTI = @DataPresConti, 
		TOT_REGISTRATE = @TotRegistrate, 
		TOT_SPESAPUB_REGISTRATE = @TotSpesapubRegistrate, 
		TOT_PAGAMENTI_REGISTRATE = @TotPagamentiRegistrate, 
		TOT_RITIRATA = @TotRitirata, 
		TOT_SPESAPUB_RITIRATA = @TotSpesapubRitirata, 
		TOT_RECUPERATA = @TotRecuperata, 
		TOT_SPESAPUB_RECUPERATA = @TotSpesapubRecuperata, 
		TOT_DARECUPERARE = @TotDarecuperare, 
		TOT_SPESAPUB_DARECUPERARE = @TotSpesapubDarecuperare, 
		TOT_NONRECUPERAB = @TotNonrecuperab, 
		TOT_SPESAPUB_NONRECUPERAB = @TotSpesapubNonrecuperab, 
		RECUPERATO_ART71 = @RecuperatoArt71, 
		RECUPERATO_ART71_PUBBLICA = @RecuperatoArt71Pubblica
	WHERE 
		(ID_CONTO = @IdConto)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCertspContiUpdate]
(
	@IdConto INT, 
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
	UPDATE CERTSP_CONTI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_ATTO = @IdAtto, 
		DATA_PRES_CONTAB = @DataPresContab, 
		DATA_PRES_CONTI = @DataPresConti, 
		TOT_REGISTRATE = @TotRegistrate, 
		TOT_SPESAPUB_REGISTRATE = @TotSpesapubRegistrate, 
		TOT_PAGAMENTI_REGISTRATE = @TotPagamentiRegistrate, 
		TOT_RITIRATA = @TotRitirata, 
		TOT_SPESAPUB_RITIRATA = @TotSpesapubRitirata, 
		TOT_RECUPERATA = @TotRecuperata, 
		TOT_SPESAPUB_RECUPERATA = @TotSpesapubRecuperata, 
		TOT_DARECUPERARE = @TotDarecuperare, 
		TOT_SPESAPUB_DARECUPERARE = @TotSpesapubDarecuperare, 
		RECUPERATO_ART71 = @RecuperatoArt71, 
		TOT_NONRECUPERAB = @TotNonrecuperab, 
		TOT_SPESAPUB_NONRECUPERAB = @TotSpesapubNonrecuperab
	WHERE 
		(ID_CONTO = @IdConto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspContiUpdate';

