


CREATE PROCEDURE [dbo].[ZDatiMonitoraggioFESRInsert]
(
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
	INSERT INTO DATI_MONITORAGGIO_FESR
	(
		ID_PROGETTO, 
		CUP_CATEGORIA, 
		CUP_CATEGORIA_SOGGETTO,
		TEMA_PRIORITARIO, 
		ID_ATECO, 
		ATTIVITA_ECON, 
		CPT_SETTORE, 
		CUP_DIMENSIONE_TERR, 
		CUP_NATURA,
		CUP_CATEGORIA_TIPOOPER
	)
	VALUES
	(
		@IdProgetto, 
		@IdCUPCategoria, 
		@IdCUPCategoriaSoggetto, 
		@IdTemaPrioritario, 
		@IdAteco2007, 
		@IdAttivitaEcon, 
		@IdCPTSettore, 
		@IdDimensioneTerr, 
		@IdCUPNatura, 		
		@IdCUPCategoriaTipoOperazione
	)
	SELECT SCOPE_IDENTITY() AS ID_DATI_MONIT



