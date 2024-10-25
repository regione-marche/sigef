CREATE PROCEDURE [dbo].[ZRevocaOrdinativoIncassoFindSelect]
(
	@IdOrdinativoIncassoequalthis INT, 
	@IdRevocaequalthis INT, 
	@OrdinativoIncassoequalthis VARCHAR(255), 
	@DataOrdinativoequalthis DATETIME, 
	@ImportoOrdinativoequalthis DECIMAL(15,2), 
	@DataInserimentoequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ORDINATIVO_INCASSO, ID_REVOCA, ORDINATIVO_INCASSO, DATA_ORDINATIVO, IMPORTO_ORDINATIVO, DATA_INSERIMENTO FROM REVOCA_ORDINATIVO_INCASSO WHERE 1=1';
	IF (@IdOrdinativoIncassoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ORDINATIVO_INCASSO = @IdOrdinativoIncassoequalthis)'; set @lensql=@lensql+len(@IdOrdinativoIncassoequalthis);end;
	IF (@IdRevocaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REVOCA = @IdRevocaequalthis)'; set @lensql=@lensql+len(@IdRevocaequalthis);end;
	IF (@OrdinativoIncassoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINATIVO_INCASSO = @OrdinativoIncassoequalthis)'; set @lensql=@lensql+len(@OrdinativoIncassoequalthis);end;
	IF (@DataOrdinativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ORDINATIVO = @DataOrdinativoequalthis)'; set @lensql=@lensql+len(@DataOrdinativoequalthis);end;
	IF (@ImportoOrdinativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_ORDINATIVO = @ImportoOrdinativoequalthis)'; set @lensql=@lensql+len(@ImportoOrdinativoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdOrdinativoIncassoequalthis INT, @IdRevocaequalthis INT, @OrdinativoIncassoequalthis VARCHAR(255), @DataOrdinativoequalthis DATETIME, @ImportoOrdinativoequalthis DECIMAL(15,2), @DataInserimentoequalthis DATETIME',@IdOrdinativoIncassoequalthis , @IdRevocaequalthis , @OrdinativoIncassoequalthis , @DataOrdinativoequalthis , @ImportoOrdinativoequalthis , @DataInserimentoequalthis ;
	else
		SELECT ID_ORDINATIVO_INCASSO, ID_REVOCA, ORDINATIVO_INCASSO, DATA_ORDINATIVO, IMPORTO_ORDINATIVO, DATA_INSERIMENTO
		FROM REVOCA_ORDINATIVO_INCASSO
		WHERE 
			((@IdOrdinativoIncassoequalthis IS NULL) OR ID_ORDINATIVO_INCASSO = @IdOrdinativoIncassoequalthis) AND 
			((@IdRevocaequalthis IS NULL) OR ID_REVOCA = @IdRevocaequalthis) AND 
			((@OrdinativoIncassoequalthis IS NULL) OR ORDINATIVO_INCASSO = @OrdinativoIncassoequalthis) AND 
			((@DataOrdinativoequalthis IS NULL) OR DATA_ORDINATIVO = @DataOrdinativoequalthis) AND 
			((@ImportoOrdinativoequalthis IS NULL) OR IMPORTO_ORDINATIVO = @ImportoOrdinativoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis)