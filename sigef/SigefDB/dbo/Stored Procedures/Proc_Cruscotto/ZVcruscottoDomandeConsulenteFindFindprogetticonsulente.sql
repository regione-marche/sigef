CREATE PROCEDURE [dbo].[ZVcruscottoDomandeConsulenteFindFindprogetticonsulente]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodStatoProgettoequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@IdUtenteequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_ENTE_BANDO, ID_PROGRAMMAZIONE_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, ID_IMPRESA, RAGIONE_SOCIALE_IMPRESA, ID_UTENTE, NOMINATIVO_UTENTE_IMPRESA, CF_UTENTE_IMPRESA, UTENTE_ATTIVO FROM VCRUSCOTTO_DOMANDE_CONSULENTE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO_PROGETTO = @CodStatoProgettoequalthis)'; set @lensql=@lensql+len(@CodStatoProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	set @sql = @sql + 'ORDER BY DATA_SCADENZA_BANDO ASC, ID_PROGETTO DESC, ID_IMPRESA';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @CodStatoProgettoequalthis VARCHAR(255), @IdImpresaequalthis INT, @IdUtenteequalthis INT',@IdBandoequalthis , @IdProgettoequalthis , @CodStatoProgettoequalthis , @IdImpresaequalthis , @IdUtenteequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_ENTE_BANDO, ID_PROGRAMMAZIONE_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, ID_IMPRESA, RAGIONE_SOCIALE_IMPRESA, ID_UTENTE, NOMINATIVO_UTENTE_IMPRESA, CF_UTENTE_IMPRESA, UTENTE_ATTIVO
		FROM VCRUSCOTTO_DOMANDE_CONSULENTE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodStatoProgettoequalthis IS NULL) OR COD_STATO_PROGETTO = @CodStatoProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis)
		ORDER BY DATA_SCADENZA_BANDO ASC, ID_PROGETTO DESC, ID_IMPRESA
