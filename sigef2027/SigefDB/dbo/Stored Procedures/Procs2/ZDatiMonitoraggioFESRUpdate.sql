


CREATE PROCEDURE [dbo].[ZDatiMonitoraggioFESRUpdate]
(
    @IdDatiMonitoraggioFESR INT,
	@IdProgetto INT, 
	@IdCUPCategoria char(7), 
	@IdCUPCategoriaSoggetto char(6),
	@IdTemaPrioritario char(2), 
	@IdAteco2007 char(9), 
	@IdAttivitaEcon char(2), 
	@IdCPTSettore char(2), 
	@IdDimensioneTerr char(2), 
	@IdCUPNatura char(2),	 
	@IdCUPCategoriaTipoOperazione char(4)	
)
AS
	UPDATE DATI_MONITORAGGIO_FESR
	SET
		ID_PROGETTO = @IdProgetto, 
		CUP_CATEGORIA = @IdCUPCategoria, 
		CUP_CATEGORIA_SOGGETTO = @IdCUPCategoriaSoggetto, 
		TEMA_PRIORITARIO = @IdTemaPrioritario, 
		ID_ATECO = @IdAteco2007, 
		ATTIVITA_ECON = @IdAttivitaEcon, 
		CPT_SETTORE = @IdCPTSettore, 
		CUP_DIMENSIONE_TERR = @IdDimensioneTerr, 
		CUP_NATURA = @IdCUPNatura, 		
		CUP_CATEGORIA_TIPOOPER = @IdCUPCategoriaTipoOperazione
	WHERE 
		(ID_DATI_MONIT = @IdDatiMonitoraggioFESR)



