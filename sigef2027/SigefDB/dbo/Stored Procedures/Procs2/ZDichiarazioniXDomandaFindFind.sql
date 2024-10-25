CREATE PROCEDURE [dbo].[ZDichiarazioniXDomandaFindFind]
(
	@IdDichiarazioneequalthis INT, 
	@IdDomandaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DICHIARAZIONE, ID_DOMANDA, ORDINE, DESCRIZIONE, MISURA, OBBLIGATORIO FROM vDICHIARAZIONI WHERE 1=1';
	IF (@IdDichiarazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DICHIARAZIONE = @IdDichiarazioneequalthis)'; set @lensql=@lensql+len(@IdDichiarazioneequalthis);end;
	IF (@IdDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA = @IdDomandaequalthis)'; set @lensql=@lensql+len(@IdDomandaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDichiarazioneequalthis INT, @IdDomandaequalthis INT',@IdDichiarazioneequalthis , @IdDomandaequalthis ;
	else
		SELECT ID_DICHIARAZIONE, ID_DOMANDA, ORDINE, DESCRIZIONE, MISURA, OBBLIGATORIO
		FROM vDICHIARAZIONI
		WHERE 
			((@IdDichiarazioneequalthis IS NULL) OR ID_DICHIARAZIONE = @IdDichiarazioneequalthis) AND 
			((@IdDomandaequalthis IS NULL) OR ID_DOMANDA = @IdDomandaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDichiarazioniXDomandaFindFind]
(
	@IdDichiarazioneequalthis INT, 
	@IdDomandaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DICHIARAZIONE, ID_DOMANDA, ORDINE, DESCRIZIONE, MISURA, OBBLIGATORIO FROM vDICHIARAZIONI WHERE 1=1'';
	IF (@IdDichiarazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DICHIARAZIONE = @IdDichiarazioneequalthis)''; set @lensql=@lensql+len(@IdDichiarazioneequalthis);end;
	IF (@IdDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA = @IdDomandaequalthis)''; set @lensql=@lensql+len(@IdDomandaequalthis);end;
	set @sql = @sql + ''ORDER BY ORDINE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDichiarazioneequalthis INT, @IdDomandaequalthis INT'',@IdDichiarazioneequalthis , @IdDomandaequalthis ;
	else
		SELECT ID_DICHIARAZIONE, ID_DOMANDA, ORDINE, DESCRIZIONE, MISURA, OBBLIGATORIO
		FROM vDICHIARAZIONI
		WHERE 
			((@IdDichiarazioneequalthis IS NULL) OR ID_DICHIARAZIONE = @IdDichiarazioneequalthis) AND 
			((@IdDomandaequalthis IS NULL) OR ID_DOMANDA = @IdDomandaequalthis)
		ORDER BY ORDINE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDichiarazioniXDomandaFindFind';

