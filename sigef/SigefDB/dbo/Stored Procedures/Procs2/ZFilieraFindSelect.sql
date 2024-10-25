create PROCEDURE [dbo].[ZFilieraFindSelect]
(
	@IdFilieraequalthis INT, 
	@CodTipoFilieraequalthis CHAR(3), 
	@Denominazioneequalthis VARCHAR(255), 
	@NumCertificatoequalthis INT, 
	@DataCertificatoequalthis DATETIME, 
	@DataInserimentoequalthis DATETIME, 
	@DataUltimaModificaequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FILIERA, COD_TIPO_FILIERA, DENOMINAZIONE, IDEA_PROGETTUALE, NUM_CERTIFICATO, DATA_CERTIFICATO, DATA_INSERIMENTO, DATA_ULTIMA_MODIFICA, OPERATORE FROM FILIERA WHERE 1=1';
	IF (@IdFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILIERA = @IdFilieraequalthis)'; set @lensql=@lensql+len(@IdFilieraequalthis);end;
	IF (@CodTipoFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_FILIERA = @CodTipoFilieraequalthis)'; set @lensql=@lensql+len(@CodTipoFilieraequalthis);end;
	IF (@Denominazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DENOMINAZIONE = @Denominazioneequalthis)'; set @lensql=@lensql+len(@Denominazioneequalthis);end;
	IF (@NumCertificatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUM_CERTIFICATO = @NumCertificatoequalthis)'; set @lensql=@lensql+len(@NumCertificatoequalthis);end;
	IF (@DataCertificatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CERTIFICATO = @DataCertificatoequalthis)'; set @lensql=@lensql+len(@DataCertificatoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataUltimaModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ULTIMA_MODIFICA = @DataUltimaModificaequalthis)'; set @lensql=@lensql+len(@DataUltimaModificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdFilieraequalthis INT, @CodTipoFilieraequalthis CHAR(3), @Denominazioneequalthis VARCHAR(255), @NumCertificatoequalthis INT, @DataCertificatoequalthis DATETIME, @DataInserimentoequalthis DATETIME, @DataUltimaModificaequalthis DATETIME, @Operatoreequalthis VARCHAR(16)',@IdFilieraequalthis , @CodTipoFilieraequalthis , @Denominazioneequalthis , @NumCertificatoequalthis , @DataCertificatoequalthis , @DataInserimentoequalthis , @DataUltimaModificaequalthis , @Operatoreequalthis ;
	else
		SELECT ID_FILIERA, COD_TIPO_FILIERA, DENOMINAZIONE, IDEA_PROGETTUALE, NUM_CERTIFICATO, DATA_CERTIFICATO, DATA_INSERIMENTO, DATA_ULTIMA_MODIFICA, OPERATORE
		FROM FILIERA
		WHERE 
			((@IdFilieraequalthis IS NULL) OR ID_FILIERA = @IdFilieraequalthis) AND 
			((@CodTipoFilieraequalthis IS NULL) OR COD_TIPO_FILIERA = @CodTipoFilieraequalthis) AND 
			((@Denominazioneequalthis IS NULL) OR DENOMINAZIONE = @Denominazioneequalthis) AND 
			((@NumCertificatoequalthis IS NULL) OR NUM_CERTIFICATO = @NumCertificatoequalthis) AND 
			((@DataCertificatoequalthis IS NULL) OR DATA_CERTIFICATO = @DataCertificatoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataUltimaModificaequalthis IS NULL) OR DATA_ULTIMA_MODIFICA = @DataUltimaModificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)
