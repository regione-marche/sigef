CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneFindSelect]
(
	@Idequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@Conclusaequalthis BIT, 
	@Annullataequalthis BIT, 
	@IdUtenteequalthis INT, 
	@Dataequalthis DATETIME, 
	@IdNoteequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_DOMANDA_PAGAMENTO, CONCLUSA, ANNULLATA, ID_UTENTE, DATA, ID_NOTE, NOTE, NOMINATIVO, COD_ENTE FROM vCORRETTIVA_RENDICONTAZIONE WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@Conclusaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONCLUSA = @Conclusaequalthis)'; set @lensql=@lensql+len(@Conclusaequalthis);end;
	IF (@Annullataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATA = @Annullataequalthis)'; set @lensql=@lensql+len(@Annullataequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@IdNoteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_NOTE = @IdNoteequalthis)'; set @lensql=@lensql+len(@IdNoteequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdDomandaPagamentoequalthis INT, @Conclusaequalthis BIT, @Annullataequalthis BIT, @IdUtenteequalthis INT, @Dataequalthis DATETIME, @IdNoteequalthis INT',@Idequalthis , @IdDomandaPagamentoequalthis , @Conclusaequalthis , @Annullataequalthis , @IdUtenteequalthis , @Dataequalthis , @IdNoteequalthis ;
	else
		SELECT ID, ID_DOMANDA_PAGAMENTO, CONCLUSA, ANNULLATA, ID_UTENTE, DATA, ID_NOTE, NOTE, NOMINATIVO, COD_ENTE
		FROM vCORRETTIVA_RENDICONTAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@Conclusaequalthis IS NULL) OR CONCLUSA = @Conclusaequalthis) AND 
			((@Annullataequalthis IS NULL) OR ANNULLATA = @Annullataequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@IdNoteequalthis IS NULL) OR ID_NOTE = @IdNoteequalthis)
