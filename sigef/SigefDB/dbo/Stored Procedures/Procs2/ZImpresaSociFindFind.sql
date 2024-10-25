CREATE PROCEDURE [dbo].[ZImpresaSociFindFind]
(
	@IdImpresaequalthis INT, 
	@Cuaaequalthis VARCHAR(255), 
	@CodiceFiscaleequalthis VARCHAR(255), 
	@RagioneSocialelikethis VARCHAR(255), 
	@CodTipoSocioequalthis VARCHAR(255), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_IMPRESA, ID_SOCIO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, FORMA_GIURIDICA, COD_TIPO_SOCIO, TIPO_SOCIO FROM vIMPRESA_SOCI WHERE 1=1';
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@CodiceFiscaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_FISCALE = @CodiceFiscaleequalthis)'; set @lensql=@lensql+len(@CodiceFiscaleequalthis);end;
	IF (@RagioneSocialelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)'; set @lensql=@lensql+len(@RagioneSocialelikethis);end;
	IF (@CodTipoSocioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_SOCIO = @CodTipoSocioequalthis)'; set @lensql=@lensql+len(@CodTipoSocioequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY ATTIVO DESC, RAGIONE_SOCIALE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdImpresaequalthis INT, @Cuaaequalthis VARCHAR(255), @CodiceFiscaleequalthis VARCHAR(255), @RagioneSocialelikethis VARCHAR(255), @CodTipoSocioequalthis VARCHAR(255), @Attivoequalthis BIT',@IdImpresaequalthis , @Cuaaequalthis , @CodiceFiscaleequalthis , @RagioneSocialelikethis , @CodTipoSocioequalthis , @Attivoequalthis ;
	else
		SELECT ID, ID_IMPRESA, ID_SOCIO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, FORMA_GIURIDICA, COD_TIPO_SOCIO, TIPO_SOCIO
		FROM vIMPRESA_SOCI
		WHERE 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@CodiceFiscaleequalthis IS NULL) OR CODICE_FISCALE = @CodiceFiscaleequalthis) AND 
			((@RagioneSocialelikethis IS NULL) OR RAGIONE_SOCIALE LIKE @RagioneSocialelikethis) AND 
			((@CodTipoSocioequalthis IS NULL) OR COD_TIPO_SOCIO = @CodTipoSocioequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY ATTIVO DESC, RAGIONE_SOCIALE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaSociFindFind';

