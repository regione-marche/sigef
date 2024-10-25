CREATE PROCEDURE [dbo].[ZBandoResponsabiliFindFind]
(
	@IdBandoequalthis INT, 
	@IdUtenteequalthis INT, 
	@Provinciaequalthis VARCHAR(255), 
	@Provinciaisnull bit, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, ID_UTENTE, PROVINCIA, ATTIVO, DATA, OPERATORE, DENOMINAZIONE_PROVINCIA, NOMINATIVO, COD_ENTE, ENTE, PROFILO FROM vBANDO_RESPONSABILI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@Provinciaisnull IS NOT NULL) BEGIN SET @sql = @sql + ' AND (((CASE WHEN (PROVINCIA IS NULL) THEN 1 ELSE 0 END) = @Provinciaisnull))'; set @lensql=@lensql+len(@Provinciaisnull);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY PROVINCIA, NOMINATIVO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdUtenteequalthis INT, @Provinciaequalthis VARCHAR(255), @Provinciaisnull bit, @Attivoequalthis BIT',@IdBandoequalthis , @IdUtenteequalthis , @Provinciaequalthis , @Provinciaisnull , @Attivoequalthis ;
	else
		SELECT ID, ID_BANDO, ID_UTENTE, PROVINCIA, ATTIVO, DATA, OPERATORE, DENOMINAZIONE_PROVINCIA, NOMINATIVO, COD_ENTE, ENTE, PROFILO
		FROM vBANDO_RESPONSABILI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@Provinciaisnull IS NULL) OR ((CASE WHEN (PROVINCIA IS NULL) THEN 1 ELSE 0 END) = @Provinciaisnull)) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY PROVINCIA, NOMINATIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoResponsabiliFindFind';

