CREATE PROCEDURE [dbo].[ZPartecipantiXFilieraFindSelect]
(
	@IdPartecipanteequalthis INT, 
	@CodFilieraequalthis VARCHAR(10), 
	@Cuaaequalthis VARCHAR(16), 
	@IdProgettoValidatoequalthis INT, 
	@CodRuoloSitraequalthis CHAR(3), 
	@Ammessoequalthis BIT, 
	@DataValidazioneequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PARTECIPANTE, COD_FILIERA, CUAA, ID_PROGETTO_VALIDATO, COD_RUOLO_SITRA, AMMESSO, DATA_VALIDAZIONE, CF_OPERATORE FROM PARTECIPANTI_X_FILIERA WHERE 1=1';
	IF (@IdPartecipanteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PARTECIPANTE = @IdPartecipanteequalthis)'; set @lensql=@lensql+len(@IdPartecipanteequalthis);end;
	IF (@CodFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FILIERA = @CodFilieraequalthis)'; set @lensql=@lensql+len(@CodFilieraequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@IdProgettoValidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_VALIDATO = @IdProgettoValidatoequalthis)'; set @lensql=@lensql+len(@IdProgettoValidatoequalthis);end;
	IF (@CodRuoloSitraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUOLO_SITRA = @CodRuoloSitraequalthis)'; set @lensql=@lensql+len(@CodRuoloSitraequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMESSO = @Ammessoequalthis)'; set @lensql=@lensql+len(@Ammessoequalthis);end;
	IF (@DataValidazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALIDAZIONE = @DataValidazioneequalthis)'; set @lensql=@lensql+len(@DataValidazioneequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE = @CfOperatoreequalthis)'; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPartecipanteequalthis INT, @CodFilieraequalthis VARCHAR(10), @Cuaaequalthis VARCHAR(16), @IdProgettoValidatoequalthis INT, @CodRuoloSitraequalthis CHAR(3), @Ammessoequalthis BIT, @DataValidazioneequalthis DATETIME, @CfOperatoreequalthis VARCHAR(16)',@IdPartecipanteequalthis , @CodFilieraequalthis , @Cuaaequalthis , @IdProgettoValidatoequalthis , @CodRuoloSitraequalthis , @Ammessoequalthis , @DataValidazioneequalthis , @CfOperatoreequalthis ;
	else
		SELECT ID_PARTECIPANTE, COD_FILIERA, CUAA, ID_PROGETTO_VALIDATO, COD_RUOLO_SITRA, AMMESSO, DATA_VALIDAZIONE, CF_OPERATORE
		FROM PARTECIPANTI_X_FILIERA
		WHERE 
			((@IdPartecipanteequalthis IS NULL) OR ID_PARTECIPANTE = @IdPartecipanteequalthis) AND 
			((@CodFilieraequalthis IS NULL) OR COD_FILIERA = @CodFilieraequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@IdProgettoValidatoequalthis IS NULL) OR ID_PROGETTO_VALIDATO = @IdProgettoValidatoequalthis) AND 
			((@CodRuoloSitraequalthis IS NULL) OR COD_RUOLO_SITRA = @CodRuoloSitraequalthis) AND 
			((@Ammessoequalthis IS NULL) OR AMMESSO = @Ammessoequalthis) AND 
			((@DataValidazioneequalthis IS NULL) OR DATA_VALIDAZIONE = @DataValidazioneequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPartecipantiXFilieraFindSelect]
(
	@IdPartecipanteequalthis INT, 
	@CodFilieraequalthis VARCHAR(5), 
	@Cuaaequalthis VARCHAR(16), 
	@IdProgettoValidatoequalthis INT, 
	@Ammessoequalthis BIT, 
	@DataValidazioneequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PARTECIPANTE, COD_FILIERA, CUAA, ID_PROGETTO_VALIDATO, AMMESSO, DATA_VALIDAZIONE, CF_OPERATORE FROM PARTECIPANTI_X_FILIERA WHERE 1=1'';
	IF (@IdPartecipanteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PARTECIPANTE = @IdPartecipanteequalthis)''; set @lensql=@lensql+len(@IdPartecipanteequalthis);end;
	IF (@CodFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FILIERA = @CodFilieraequalthis)''; set @lensql=@lensql+len(@CodFilieraequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CUAA = @Cuaaequalthis)''; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@IdProgettoValidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO_VALIDATO = @IdProgettoValidatoequalthis)''; set @lensql=@lensql+len(@IdProgettoValidatoequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AMMESSO = @Ammessoequalthis)''; set @lensql=@lensql+len(@Ammessoequalthis);end;
	IF (@DataValidazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_VALIDAZIONE = @DataValidazioneequalthis)''; set @lensql=@lensql+len(@DataValidazioneequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_OPERATORE = @CfOperatoreequalthis)''; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPartecipanteequalthis INT, @CodFilieraequalthis VARCHAR(5), @Cuaaequalthis VARCHAR(16), @IdProgettoValidatoequalthis INT, @Ammessoequalthis BIT, @DataValidazioneequalthis DATETIME, @CfOperatoreequalthis VARCHAR(16)'',@IdPartecipanteequalthis , @CodFilieraequalthis , @Cuaaequalthis , @IdProgettoValidatoequalthis , @Ammessoequalthis , @DataValidazioneequalthis , @CfOperatoreequalthis ;
	else
		SELECT ID_PARTECIPANTE, COD_FILIERA, CUAA, ID_PROGETTO_VALIDATO, AMMESSO, DATA_VALIDAZIONE, CF_OPERATORE
		FROM PARTECIPANTI_X_FILIERA
		WHERE 
			((@IdPartecipanteequalthis IS NULL) OR ID_PARTECIPANTE = @IdPartecipanteequalthis) AND 
			((@CodFilieraequalthis IS NULL) OR COD_FILIERA = @CodFilieraequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@IdProgettoValidatoequalthis IS NULL) OR ID_PROGETTO_VALIDATO = @IdProgettoValidatoequalthis) AND 
			((@Ammessoequalthis IS NULL) OR AMMESSO = @Ammessoequalthis) AND 
			((@DataValidazioneequalthis IS NULL) OR DATA_VALIDAZIONE = @DataValidazioneequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipantiXFilieraFindSelect';

