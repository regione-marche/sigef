CREATE PROCEDURE [dbo].[ZContoCorrenteFindFind]
(
	@IdContoCorrenteequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdPersonaequalthis INT, 
	@DataInizioValiditaeqlessthanthis DATETIME, 
	@DataFineValiditaeqgreaterthanthis DATETIME, 
	@DataFineValiditaisnull bit
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CONTO_CORRENTE, ID_IMPRESA, ID_PERSONA, COD_PAESE, CIN_EURO, CIN, ABI, CAB, NUMERO, NOTE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ISTITUTO, AGENZIA, ID_COMUNE, COD_BELFIORE, COMUNE, SIGLA, CAP FROM vCONTO_CORRENTE WHERE 1=1';
	IF (@IdContoCorrenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTO_CORRENTE = @IdContoCorrenteequalthis)'; set @lensql=@lensql+len(@IdContoCorrenteequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PERSONA = @IdPersonaequalthis)'; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@DataInizioValiditaeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA <= @DataInizioValiditaeqlessthanthis)'; set @lensql=@lensql+len(@DataInizioValiditaeqlessthanthis);end;
	IF (@DataFineValiditaeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA >= @DataFineValiditaeqgreaterthanthis)'; set @lensql=@lensql+len(@DataFineValiditaeqgreaterthanthis);end;
	IF (@DataFineValiditaisnull IS NOT NULL) BEGIN SET @sql = @sql + ' AND (((CASE WHEN (DATA_FINE_VALIDITA IS NULL) THEN 1 ELSE 0 END) = @DataFineValiditaisnull))'; set @lensql=@lensql+len(@DataFineValiditaisnull);end;
	set @sql = @sql + 'ORDER BY DATA_INIZIO_VALIDITA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdContoCorrenteequalthis INT, @IdImpresaequalthis INT, @IdPersonaequalthis INT, @DataInizioValiditaeqlessthanthis DATETIME, @DataFineValiditaeqgreaterthanthis DATETIME, @DataFineValiditaisnull bit',@IdContoCorrenteequalthis , @IdImpresaequalthis , @IdPersonaequalthis , @DataInizioValiditaeqlessthanthis , @DataFineValiditaeqgreaterthanthis , @DataFineValiditaisnull ;
	else
		SELECT ID_CONTO_CORRENTE, ID_IMPRESA, ID_PERSONA, COD_PAESE, CIN_EURO, CIN, ABI, CAB, NUMERO, NOTE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ISTITUTO, AGENZIA, ID_COMUNE, COD_BELFIORE, COMUNE, SIGLA, CAP
		FROM vCONTO_CORRENTE
		WHERE 
			((@IdContoCorrenteequalthis IS NULL) OR ID_CONTO_CORRENTE = @IdContoCorrenteequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@DataInizioValiditaeqlessthanthis IS NULL) OR DATA_INIZIO_VALIDITA <= @DataInizioValiditaeqlessthanthis) AND 
			((@DataFineValiditaeqgreaterthanthis IS NULL) OR DATA_FINE_VALIDITA >= @DataFineValiditaeqgreaterthanthis) AND 
			((@DataFineValiditaisnull IS NULL) OR ((CASE WHEN (DATA_FINE_VALIDITA IS NULL) THEN 1 ELSE 0 END) = @DataFineValiditaisnull))
		ORDER BY DATA_INIZIO_VALIDITA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZContoCorrenteFindFind]
(
	@IdContoCorrenteequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdPersonaequalthis INT, 
	@DataFineValiditaeqgreaterthanthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_CONTO_CORRENTE, ID_IMPRESA, ID_PERSONA, COD_PAESE, CIN_EURO, CIN, ABI, CAB, NUMERO, NOTE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ISTITUTO, AGENZIA, ID_COMUNE, COD_BELFIORE, COMUNE, SIGLA, CAP FROM vCONTO_CORRENTE WHERE 1=1'';
	IF (@IdContoCorrenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_CONTO_CORRENTE = @IdContoCorrenteequalthis)''; set @lensql=@lensql+len(@IdContoCorrenteequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PERSONA = @IdPersonaequalthis)''; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@DataFineValiditaeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE_VALIDITA >= @DataFineValiditaeqgreaterthanthis AND DATA_INIZIO_VALIDITA < @DataFineValiditaeqgreaterthanthis)''; set @lensql=@lensql+len(@DataFineValiditaeqgreaterthanthis);end;
	ELSE BEGIN SET @sql = @sql + '' AND (DATA_FINE_VALIDITA IS NULL)''; end;
	set @sql = @sql + ''ORDER BY ID_CONTO_CORRENTE DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdContoCorrenteequalthis INT, @IdImpresaequalthis INT, @IdPersonaequalthis INT, @DataFineValiditaeqgreaterthanthis DATETIME'',@IdContoCorrenteequalthis , @IdImpresaequalthis , @IdPersonaequalthis , @DataFineValiditaeqgreaterthanthis ;
	else
		SELECT ID_CONTO_CORRENTE, ID_IMPRESA, ID_PERSONA, COD_PAESE, CIN_EURO, CIN, ABI, CAB, NUMERO, NOTE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ISTITUTO, AGENZIA, ID_COMUNE, COD_BELFIORE, COMUNE, SIGLA, CAP
		FROM vCONTO_CORRENTE
		WHERE 
			((@IdContoCorrenteequalthis IS NULL) OR ID_CONTO_CORRENTE = @IdContoCorrenteequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@DataFineValiditaeqgreaterthanthis IS NULL AND DATA_FINE_VALIDITA IS NULL) OR (DATA_FINE_VALIDITA >= @DataFineValiditaeqgreaterthanthis AND DATA_INIZIO_VALIDITA < @DataFineValiditaeqgreaterthanthis))
		ORDER BY ID_CONTO_CORRENTE DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZContoCorrenteFindFind';

