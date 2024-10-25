﻿CREATE PROCEDURE [dbo].[ZImpresaFindFind]
(
	@Cuaaequalthis VARCHAR(255), 
	@CodiceFiscaleequalthis VARCHAR(255), 
	@RagioneSocialelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_IMPRESA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, COD_ENTE, ISCRIZIONE_REGISTRO_IMPRESE, PRESENTAZIONE, DESCRIZIONE, ID_STORICO_IMPRESA, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, RAGIONE_SOCIALE, CODICE_INPS, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, FOGLIA, DATA_INIZIO_ATTIVITA, REGISTRO_IMPRESE_NUMERO, REA_NUMERO, REA_ANNO, ID_STORICO_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_SEDELEGALE_ULTIMO, COD_CLASSIFICAZIONE_UMA, ATTIVA, DATA_CESSAZIONE, SEGNATURA_CESSAZIONE, COD_TIPO_CESSAZIONE, COD_ATECO2007 FROM vIMPRESA WHERE 1=1';
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@CodiceFiscaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_FISCALE = @CodiceFiscaleequalthis)'; set @lensql=@lensql+len(@CodiceFiscaleequalthis);end;
	IF (@RagioneSocialelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)'; set @lensql=@lensql+len(@RagioneSocialelikethis);end;
	set @sql = @sql + 'ORDER BY ATTIVA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Cuaaequalthis VARCHAR(255), @CodiceFiscaleequalthis VARCHAR(255), @RagioneSocialelikethis VARCHAR(255)',@Cuaaequalthis , @CodiceFiscaleequalthis , @RagioneSocialelikethis ;
	else
		SELECT ID_IMPRESA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, COD_ENTE, ISCRIZIONE_REGISTRO_IMPRESE, PRESENTAZIONE, DESCRIZIONE, ID_STORICO_IMPRESA, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, RAGIONE_SOCIALE, CODICE_INPS, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, FOGLIA, DATA_INIZIO_ATTIVITA, REGISTRO_IMPRESE_NUMERO, REA_NUMERO, REA_ANNO, ID_STORICO_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_SEDELEGALE_ULTIMO, COD_CLASSIFICAZIONE_UMA, ATTIVA, DATA_CESSAZIONE, SEGNATURA_CESSAZIONE, COD_TIPO_CESSAZIONE, COD_ATECO2007
		FROM vIMPRESA
		WHERE 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@CodiceFiscaleequalthis IS NULL) OR CODICE_FISCALE = @CodiceFiscaleequalthis) AND 
			((@RagioneSocialelikethis IS NULL) OR RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)
		ORDER BY ATTIVA DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaFindFind]
(
	@Cuaaequalthis VARCHAR(255), 
	@CodiceFiscaleequalthis VARCHAR(255), 
	@RagioneSocialelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_IMPRESA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, COD_ENTE, ISCRIZIONE_REGISTRO_IMPRESE, PRESENTAZIONE, DESCRIZIONE, ID_STORICO_IMPRESA, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, RAGIONE_SOCIALE, CODICE_INPS, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, FOGLIA, DATA_INIZIO_ATTIVITA, REGISTRO_IMPRESE_NUMERO, REA_NUMERO, REA_ANNO, ID_STORICO_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_SEDELEGALE_ULTIMO, COD_CLASSIFICAZIONE_UMA, ATTIVA, DATA_CESSAZIONE, SEGNATURA_CESSAZIONE, COD_TIPO_CESSAZIONE FROM vIMPRESA WHERE 1=1'';
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CUAA = @Cuaaequalthis)''; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@CodiceFiscaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE_FISCALE = @CodiceFiscaleequalthis)''; set @lensql=@lensql+len(@CodiceFiscaleequalthis);end;
	IF (@RagioneSocialelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)''; set @lensql=@lensql+len(@RagioneSocialelikethis);end;
	set @sql = @sql + ''ORDER BY ATTIVA DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Cuaaequalthis VARCHAR(255), @CodiceFiscaleequalthis VARCHAR(255), @RagioneSocialelikethis VARCHAR(255)'',@Cuaaequalthis , @CodiceFiscaleequalthis , @RagioneSocialelikethis ;
	else
		SELECT ID_IMPRESA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, COD_ENTE, ISCRIZIONE_REGISTRO_IMPRESE, PRESENTAZIONE, DESCRIZIONE, ID_STORICO_IMPRESA, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, RAGIONE_SOCIALE, CODICE_INPS, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, FOGLIA, DATA_INIZIO_ATTIVITA, REGISTRO_IMPRESE_NUMERO, REA_NUMERO, REA_ANNO, ID_STORICO_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_SEDELEGALE_ULTIMO, COD_CLASSIFICAZIONE_UMA, ATTIVA, DATA_CESSAZIONE, SEGNATURA_CESSAZIONE, COD_TIPO_CESSAZIONE
		FROM vIMPRESA
		WHERE 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@CodiceFiscaleequalthis IS NULL) OR CODICE_FISCALE = @CodiceFiscaleequalthis) AND 
			((@RagioneSocialelikethis IS NULL) OR RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)
		ORDER BY ATTIVA DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaFindFind';

