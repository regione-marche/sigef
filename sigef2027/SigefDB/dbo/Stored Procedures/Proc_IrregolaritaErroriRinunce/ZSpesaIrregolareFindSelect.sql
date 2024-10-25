CREATE PROCEDURE [dbo].[ZSpesaIrregolareFindSelect]
(
	@IdSpesaIrregolareequalthis INT, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@IdIrregolaritaequalthis INT, 
	@IdSpesaequalthis INT, 
	@ImportoIrregolareequalthis DECIMAL(15,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SPESA_IRREGOLARE, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, ID_IRREGOLARITA, ID_SPESA, IMPORTO_IRREGOLARE, ID_GIUSTIFICATIVO, COD_TIPO_SPESA, ESTREMI_SPESA, DATA_SPESA, IMPORTO_SPESA, NETTO_SPESA, TIPO_SPESA, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOMANDA, TIPO_DOMANDA, ID_PROGETTO, NUMERO_GIUSTIFICATIVO, COD_TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, NUMERO_DOCTRASPORTO_GIUSTIFICATIVO, IMPONIBILE_GIUSTIFICATIVO, IVA_GIUSTIFICATIVO, IVA_NON_RECUPERABILE_GIUSTIFICATIVO, DESCRIZIONE_GIUSTIFICATIVO, CF_FORNITORE_GIUSTIFICATIVO, DESCRIZIONE_FORNITORE_GIUSTIFICATIVO, TIPO_GIUSTIFICATIVO, ID_LOTTO_CERTIFICAZIONE, COD_PSR_CERTIFICAZIONE, DATA_INIZIO_LOTTO_CERTIFICAZIONE, DATA_FINE_LOTTO_CERTIFICAZIONE FROM VSPESA_IRREGOLARE WHERE 1=1';
	IF (@IdSpesaIrregolareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPESA_IRREGOLARE = @IdSpesaIrregolareequalthis)'; set @lensql=@lensql+len(@IdSpesaIrregolareequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@IdIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IRREGOLARITA = @IdIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdIrregolaritaequalthis);end;
	IF (@IdSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPESA = @IdSpesaequalthis)'; set @lensql=@lensql+len(@IdSpesaequalthis);end;
	IF (@ImportoIrregolareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARE = @ImportoIrregolareequalthis)'; set @lensql=@lensql+len(@ImportoIrregolareequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSpesaIrregolareequalthis INT, @CfInserimentoequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @IdIrregolaritaequalthis INT, @IdSpesaequalthis INT, @ImportoIrregolareequalthis DECIMAL(15,2)',@IdSpesaIrregolareequalthis , @CfInserimentoequalthis , @DataInserimentoequalthis , @CfModificaequalthis , @DataModificaequalthis , @IdIrregolaritaequalthis , @IdSpesaequalthis , @ImportoIrregolareequalthis ;
	else
		SELECT ID_SPESA_IRREGOLARE, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, ID_IRREGOLARITA, ID_SPESA, IMPORTO_IRREGOLARE, ID_GIUSTIFICATIVO, COD_TIPO_SPESA, ESTREMI_SPESA, DATA_SPESA, IMPORTO_SPESA, NETTO_SPESA, TIPO_SPESA, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOMANDA, TIPO_DOMANDA, ID_PROGETTO, NUMERO_GIUSTIFICATIVO, COD_TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, NUMERO_DOCTRASPORTO_GIUSTIFICATIVO, IMPONIBILE_GIUSTIFICATIVO, IVA_GIUSTIFICATIVO, IVA_NON_RECUPERABILE_GIUSTIFICATIVO, DESCRIZIONE_GIUSTIFICATIVO, CF_FORNITORE_GIUSTIFICATIVO, DESCRIZIONE_FORNITORE_GIUSTIFICATIVO, TIPO_GIUSTIFICATIVO, ID_LOTTO_CERTIFICAZIONE, COD_PSR_CERTIFICAZIONE, DATA_INIZIO_LOTTO_CERTIFICAZIONE, DATA_FINE_LOTTO_CERTIFICAZIONE
		FROM VSPESA_IRREGOLARE
		WHERE 
			((@IdSpesaIrregolareequalthis IS NULL) OR ID_SPESA_IRREGOLARE = @IdSpesaIrregolareequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@IdIrregolaritaequalthis IS NULL) OR ID_IRREGOLARITA = @IdIrregolaritaequalthis) AND 
			((@IdSpesaequalthis IS NULL) OR ID_SPESA = @IdSpesaequalthis) AND 
			((@ImportoIrregolareequalthis IS NULL) OR IMPORTO_IRREGOLARE = @ImportoIrregolareequalthis)
		

GO