CREATE PROCEDURE [dbo].[ZVcruscottoDomandeRappresentanteLegaleFindFinddomanderappresentantelegale]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdUtenteRappresentanteLegaleequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_ENTE_BANDO, ID_PROGRAMMAZIONE_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, ID_IMPRESA, IMPRESA, ID_UTENTE_RAPPRESENTANTE_LEGALE, RAPPRESENTANTE_LEGALE FROM VCRUSCOTTO_DOMANDE_RAPPRESENTANTE_LEGALE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdUtenteRappresentanteLegaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_RAPPRESENTANTE_LEGALE = @IdUtenteRappresentanteLegaleequalthis)'; set @lensql=@lensql+len(@IdUtenteRappresentanteLegaleequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT, @IdUtenteRappresentanteLegaleequalthis INT',@IdBandoequalthis , @IdProgettoequalthis , @IdImpresaequalthis , @IdUtenteRappresentanteLegaleequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_ENTE_BANDO, ID_PROGRAMMAZIONE_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, ID_IMPRESA, IMPRESA, ID_UTENTE_RAPPRESENTANTE_LEGALE, RAPPRESENTANTE_LEGALE
		FROM VCRUSCOTTO_DOMANDE_RAPPRESENTANTE_LEGALE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdUtenteRappresentanteLegaleequalthis IS NULL) OR ID_UTENTE_RAPPRESENTANTE_LEGALE = @IdUtenteRappresentanteLegaleequalthis)
		

GO