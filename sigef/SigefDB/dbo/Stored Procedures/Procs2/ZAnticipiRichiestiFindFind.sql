CREATE PROCEDURE [dbo].[ZAnticipiRichiestiFindFind]
(
	@IdAnticipoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ANTICIPO, ID_DOMANDA_PAGAMENTO, ID_BANDO, DATA_RICHIESTA, CONTRIBUTO_RICHIESTO, CONTRIBUTO_AMMESSO, AMMESSO, ISTRUTTORE, DATA_VALUTAZIONE FROM ANTICIPI_RICHIESTI WHERE 1=1';
	IF (@IdAnticipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ANTICIPO = @IdAnticipoequalthis)'; set @lensql=@lensql+len(@IdAnticipoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAnticipoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdBandoequalthis INT',@IdAnticipoequalthis , @IdDomandaPagamentoequalthis , @IdBandoequalthis ;
	else
		SELECT ID_ANTICIPO, ID_DOMANDA_PAGAMENTO, ID_BANDO, DATA_RICHIESTA, CONTRIBUTO_RICHIESTO, CONTRIBUTO_AMMESSO, AMMESSO, ISTRUTTORE, DATA_VALUTAZIONE
		FROM ANTICIPI_RICHIESTI
		WHERE 
			((@IdAnticipoequalthis IS NULL) OR ID_ANTICIPO = @IdAnticipoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAnticipiRichiestiFindFind]
(
	@IdAnticipoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ANTICIPO, ID_DOMANDA_PAGAMENTO, ID_BANDO, DATA_RICHIESTA, CONTRIBUTO_RICHIESTO, CONTRIBUTO_AMMESSO, AMMESSO, ISTRUTTORE, DATA_VALUTAZIONE FROM ANTICIPI_RICHIESTI WHERE 1=1'';
	IF (@IdAnticipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ANTICIPO = @IdAnticipoequalthis)''; set @lensql=@lensql+len(@IdAnticipoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdAnticipoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdBandoequalthis INT'',@IdAnticipoequalthis , @IdDomandaPagamentoequalthis , @IdBandoequalthis ;
	else
		SELECT ID_ANTICIPO, ID_DOMANDA_PAGAMENTO, ID_BANDO, DATA_RICHIESTA, CONTRIBUTO_RICHIESTO, CONTRIBUTO_AMMESSO, AMMESSO, ISTRUTTORE, DATA_VALUTAZIONE
		FROM ANTICIPI_RICHIESTI
		WHERE 
			((@IdAnticipoequalthis IS NULL) OR ID_ANTICIPO = @IdAnticipoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAnticipiRichiestiFindFind';

