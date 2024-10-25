CREATE PROCEDURE [dbo].[ZProgettoAllegatiFindFind]
(
	@IdProgettoequalthis INT, 
	@CodTipoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGETTO, ID_ALLEGATO, ID_FILE, DESCRIZIONE_BREVE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, GIA_PRESENTATO, COD_ESITO_ISTRUTTORIA, NOTE_ISTRUTTORIA, ALLEGATO, MISURA, COD_TIPO_ENTE_EMETTITORE, ESITO, ESITO_POSITIVO, COD_TIPO, TIPO_ALLEGATO, ENTE, DIMENSIONE_FILE FROM vPROGETTO_ALLEGATI WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	set @sql = @sql + 'ORDER BY MISURA, ID';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @CodTipoequalthis VARCHAR(255)',@IdProgettoequalthis , @CodTipoequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_ALLEGATO, ID_FILE, DESCRIZIONE_BREVE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, GIA_PRESENTATO, COD_ESITO_ISTRUTTORIA, NOTE_ISTRUTTORIA, ALLEGATO, MISURA, COD_TIPO_ENTE_EMETTITORE, ESITO, ESITO_POSITIVO, COD_TIPO, TIPO_ALLEGATO, ENTE, DIMENSIONE_FILE
		FROM vPROGETTO_ALLEGATI
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis)
		ORDER BY MISURA, ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoAllegatiFindFind]
(
	@IdProgettoequalthis INT, 
	@CodTipoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGETTO, ID_ALLEGATO, ID_FILE, DESCRIZIONE_BREVE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, GIA_PRESENTATO, COD_ESITO_ISTRUTTORIA, NOTE_ISTRUTTORIA, ALLEGATO, MISURA, COD_TIPO_ENTE_EMETTITORE, ESITO, ESITO_POSITIVO, COD_TIPO, TIPO_ALLEGATO, ENTE FROM vPROGETTO_ALLEGATI WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	set @sql = @sql + ''ORDER BY MISURA, ID'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @CodTipoequalthis VARCHAR(255)'',@IdProgettoequalthis , @CodTipoequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_ALLEGATO, ID_FILE, DESCRIZIONE_BREVE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, GIA_PRESENTATO, COD_ESITO_ISTRUTTORIA, NOTE_ISTRUTTORIA, ALLEGATO, MISURA, COD_TIPO_ENTE_EMETTITORE, ESITO, ESITO_POSITIVO, COD_TIPO, TIPO_ALLEGATO, ENTE
		FROM vPROGETTO_ALLEGATI
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis)
		ORDER BY MISURA, ID

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoAllegatiFindFind';

