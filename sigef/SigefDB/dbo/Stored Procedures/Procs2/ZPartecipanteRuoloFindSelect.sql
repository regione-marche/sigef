CREATE PROCEDURE [dbo].[ZPartecipanteRuoloFindSelect]
(
	@IdPartcipanteRuoloequalthis INT, 
	@IdProgettoPifequalthis INT, 
	@CodFilieraequalthis VARCHAR(10), 
	@Cuaaequalthis VARCHAR(16), 
	@FlagPartecipanteequalthis BIT, 
	@CodRuoloSitraequalthis CHAR(3), 
	@CodRuoloPartecipanteequalthis CHAR(1), 
	@CodSistemaQualitaequalthis CHAR(1), 
	@OperatoreInserimentoequalthis VARCHAR(16), 
	@DataModificaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PARTCIPANTE_RUOLO, COD_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, OPERATORE_INSERIMENTO, DATA_MODIFICA, RUOLO_OPERATIVO, RUOLO_SITRA, ID_PROGETTO_PIF, SISTEMA_DI_QUALITA, COD_SISTEMA_QUALITA FROM vPARTECIPANTE_RUOLO WHERE 1=1';
	IF (@IdPartcipanteRuoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PARTCIPANTE_RUOLO = @IdPartcipanteRuoloequalthis)'; set @lensql=@lensql+len(@IdPartcipanteRuoloequalthis);end;
	IF (@IdProgettoPifequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_PIF = @IdProgettoPifequalthis)'; set @lensql=@lensql+len(@IdProgettoPifequalthis);end;
	IF (@CodFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FILIERA = @CodFilieraequalthis)'; set @lensql=@lensql+len(@CodFilieraequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@FlagPartecipanteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_PARTECIPANTE = @FlagPartecipanteequalthis)'; set @lensql=@lensql+len(@FlagPartecipanteequalthis);end;
	IF (@CodRuoloSitraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUOLO_SITRA = @CodRuoloSitraequalthis)'; set @lensql=@lensql+len(@CodRuoloSitraequalthis);end;
	IF (@CodRuoloPartecipanteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUOLO_PARTECIPANTE = @CodRuoloPartecipanteequalthis)'; set @lensql=@lensql+len(@CodRuoloPartecipanteequalthis);end;
	IF (@CodSistemaQualitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_SISTEMA_QUALITA = @CodSistemaQualitaequalthis)'; set @lensql=@lensql+len(@CodSistemaQualitaequalthis);end;
	IF (@OperatoreInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_INSERIMENTO = @OperatoreInserimentoequalthis)'; set @lensql=@lensql+len(@OperatoreInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPartcipanteRuoloequalthis INT, @IdProgettoPifequalthis INT, @CodFilieraequalthis VARCHAR(10), @Cuaaequalthis VARCHAR(16), @FlagPartecipanteequalthis BIT, @CodRuoloSitraequalthis CHAR(3), @CodRuoloPartecipanteequalthis CHAR(1), @CodSistemaQualitaequalthis CHAR(1), @OperatoreInserimentoequalthis VARCHAR(16), @DataModificaequalthis DATETIME',@IdPartcipanteRuoloequalthis , @IdProgettoPifequalthis , @CodFilieraequalthis , @Cuaaequalthis , @FlagPartecipanteequalthis , @CodRuoloSitraequalthis , @CodRuoloPartecipanteequalthis , @CodSistemaQualitaequalthis , @OperatoreInserimentoequalthis , @DataModificaequalthis ;
	else
		SELECT ID_PARTCIPANTE_RUOLO, COD_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, OPERATORE_INSERIMENTO, DATA_MODIFICA, RUOLO_OPERATIVO, RUOLO_SITRA, ID_PROGETTO_PIF, SISTEMA_DI_QUALITA, COD_SISTEMA_QUALITA
		FROM vPARTECIPANTE_RUOLO
		WHERE 
			((@IdPartcipanteRuoloequalthis IS NULL) OR ID_PARTCIPANTE_RUOLO = @IdPartcipanteRuoloequalthis) AND 
			((@IdProgettoPifequalthis IS NULL) OR ID_PROGETTO_PIF = @IdProgettoPifequalthis) AND 
			((@CodFilieraequalthis IS NULL) OR COD_FILIERA = @CodFilieraequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@FlagPartecipanteequalthis IS NULL) OR FLAG_PARTECIPANTE = @FlagPartecipanteequalthis) AND 
			((@CodRuoloSitraequalthis IS NULL) OR COD_RUOLO_SITRA = @CodRuoloSitraequalthis) AND 
			((@CodRuoloPartecipanteequalthis IS NULL) OR COD_RUOLO_PARTECIPANTE = @CodRuoloPartecipanteequalthis) AND 
			((@CodSistemaQualitaequalthis IS NULL) OR COD_SISTEMA_QUALITA = @CodSistemaQualitaequalthis) AND 
			((@OperatoreInserimentoequalthis IS NULL) OR OPERATORE_INSERIMENTO = @OperatoreInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipanteRuoloFindSelect';

