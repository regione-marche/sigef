CREATE PROCEDURE [dbo].[ZImpresaXFilieraFindSelect]
(
	@IdImpresaXFilieraequalthis INT, 
	@IdFilieraequalthis INT, 
	@Cuaaequalthis VARCHAR(255), 
	@FlagPartecipanteequalthis BIT, 
	@CodRuoloSitraequalthis VARCHAR(255), 
	@CodRuoloPartecipanteequalthis VARCHAR(255), 
	@Quantitaequalthis DECIMAL(10,2), 
	@UnitaMisuraequalthis INT, 
	@SistemaQualitaequalthis VARCHAR(255), 
	@Operatoreequalthis VARCHAR(255), 
	@Ammessoequalthis BIT, 
	@IdProgrammazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_IMPRESA_X_FILIERA, ID_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, RUOLO_PARTECIPANTE, QUANTITA, UNITA_MISURA, DESCRIZIONE_UNITA_MISURA, SISTEMA_QUALITA, DESCRIZIONE_SISTEMA_QUALITA, CODIFICA_INTERVENTI, OPERATORE, AMMESSO, ID_PROGRAMMAZIONE, PROGRAMMAZIONE, COD_PROGRAMMAZIONE FROM vIMPRESA_X_FILIERA WHERE 1=1';
	IF (@IdImpresaXFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA_X_FILIERA = @IdImpresaXFilieraequalthis)'; set @lensql=@lensql+len(@IdImpresaXFilieraequalthis);end;
	IF (@IdFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILIERA = @IdFilieraequalthis)'; set @lensql=@lensql+len(@IdFilieraequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@FlagPartecipanteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_PARTECIPANTE = @FlagPartecipanteequalthis)'; set @lensql=@lensql+len(@FlagPartecipanteequalthis);end;
	IF (@CodRuoloSitraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUOLO_SITRA = @CodRuoloSitraequalthis)'; set @lensql=@lensql+len(@CodRuoloSitraequalthis);end;
	IF (@CodRuoloPartecipanteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUOLO_PARTECIPANTE = @CodRuoloPartecipanteequalthis)'; set @lensql=@lensql+len(@CodRuoloPartecipanteequalthis);end;
	IF (@Quantitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUANTITA = @Quantitaequalthis)'; set @lensql=@lensql+len(@Quantitaequalthis);end;
	IF (@UnitaMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UNITA_MISURA = @UnitaMisuraequalthis)'; set @lensql=@lensql+len(@UnitaMisuraequalthis);end;
	IF (@SistemaQualitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SISTEMA_QUALITA = @SistemaQualitaequalthis)'; set @lensql=@lensql+len(@SistemaQualitaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMESSO = @Ammessoequalthis)'; set @lensql=@lensql+len(@Ammessoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdImpresaXFilieraequalthis INT, @IdFilieraequalthis INT, @Cuaaequalthis VARCHAR(255), @FlagPartecipanteequalthis BIT, @CodRuoloSitraequalthis VARCHAR(255), @CodRuoloPartecipanteequalthis VARCHAR(255), @Quantitaequalthis DECIMAL(10,2), @UnitaMisuraequalthis INT, @SistemaQualitaequalthis VARCHAR(255), @Operatoreequalthis VARCHAR(255), @Ammessoequalthis BIT, @IdProgrammazioneequalthis INT',@IdImpresaXFilieraequalthis , @IdFilieraequalthis , @Cuaaequalthis , @FlagPartecipanteequalthis , @CodRuoloSitraequalthis , @CodRuoloPartecipanteequalthis , @Quantitaequalthis , @UnitaMisuraequalthis , @SistemaQualitaequalthis , @Operatoreequalthis , @Ammessoequalthis , @IdProgrammazioneequalthis ;
	else
		SELECT ID_IMPRESA_X_FILIERA, ID_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, RUOLO_PARTECIPANTE, QUANTITA, UNITA_MISURA, DESCRIZIONE_UNITA_MISURA, SISTEMA_QUALITA, DESCRIZIONE_SISTEMA_QUALITA, CODIFICA_INTERVENTI, OPERATORE, AMMESSO, ID_PROGRAMMAZIONE, PROGRAMMAZIONE, COD_PROGRAMMAZIONE
		FROM vIMPRESA_X_FILIERA
		WHERE 
			((@IdImpresaXFilieraequalthis IS NULL) OR ID_IMPRESA_X_FILIERA = @IdImpresaXFilieraequalthis) AND 
			((@IdFilieraequalthis IS NULL) OR ID_FILIERA = @IdFilieraequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@FlagPartecipanteequalthis IS NULL) OR FLAG_PARTECIPANTE = @FlagPartecipanteequalthis) AND 
			((@CodRuoloSitraequalthis IS NULL) OR COD_RUOLO_SITRA = @CodRuoloSitraequalthis) AND 
			((@CodRuoloPartecipanteequalthis IS NULL) OR COD_RUOLO_PARTECIPANTE = @CodRuoloPartecipanteequalthis) AND 
			((@Quantitaequalthis IS NULL) OR QUANTITA = @Quantitaequalthis) AND 
			((@UnitaMisuraequalthis IS NULL) OR UNITA_MISURA = @UnitaMisuraequalthis) AND 
			((@SistemaQualitaequalthis IS NULL) OR SISTEMA_QUALITA = @SistemaQualitaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Ammessoequalthis IS NULL) OR AMMESSO = @Ammessoequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaXFilieraFindSelect]
(
	@IdImpresaXFilieraequalthis INT, 
	@IdFilieraequalthis INT, 
	@Cuaaequalthis VARCHAR(16), 
	@FlagPartecipanteequalthis BIT, 
	@CodRuoloSitraequalthis CHAR(3), 
	@CodRuoloPartecipanteequalthis CHAR(1), 
	@Quantitaequalthis DECIMAL(10,2), 
	@UnitaMisuraequalthis INT, 
	@SistemaQualitaequalthis CHAR(1), 
	@IdPsrequalthis INT, 
	@CodMisuraequalthis INT, 
	@CodObiettivoequalthis INT, 
	@CodAsseequalthis INT, 
	@CodSubmisuraequalthis CHAR(1), 
	@Operatoreequalthis VARCHAR(16), 
	@Ammessoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_IMPRESA_X_FILIERA, ID_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, RUOLO_PARTECIPANTE, QUANTITA, UNITA_MISURA, DESCRIZIONE_UNITA_MISURA, SISTEMA_QUALITA, DESCRIZIONE_SISTEMA_QUALITA, ID_PSR, PSR, COD_MISURA, MISURA, COD_OBIETTIVO, OBIETTIVO, COD_ASSE, ASSE, COD_SUBMISURA, SUBMISURA, CODIFICA_INTERVENTI, OPERATORE, CODICE, AMMESSO FROM vIMPRESA_X_FILIERA WHERE 1=1'';
	IF (@IdImpresaXFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA_X_FILIERA = @IdImpresaXFilieraequalthis)''; set @lensql=@lensql+len(@IdImpresaXFilieraequalthis);end;
	IF (@IdFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILIERA = @IdFilieraequalthis)''; set @lensql=@lensql+len(@IdFilieraequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CUAA = @Cuaaequalthis)''; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@FlagPartecipanteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_PARTECIPANTE = @FlagPartecipanteequalthis)''; set @lensql=@lensql+len(@FlagPartecipanteequalthis);end;
	IF (@CodRuoloSitraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_RUOLO_SITRA = @CodRuoloSitraequalthis)''; set @lensql=@lensql+len(@CodRuoloSitraequalthis);end;
	IF (@CodRuoloPartecipanteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_RUOLO_PARTECIPANTE = @CodRuoloPartecipanteequalthis)''; set @lensql=@lensql+len(@CodRuoloPartecipanteequalthis);end;
	IF (@Quantitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUANTITA = @Quantitaequalthis)''; set @lensql=@lensql+len(@Quantitaequalthis);end;
	IF (@UnitaMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (UNITA_MISURA = @UnitaMisuraequalthis)''; set @lensql=@lensql+len(@UnitaMisuraequalthis);end;
	IF (@SistemaQualitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SISTEMA_QUALITA = @SistemaQualitaequalthis)''; set @lensql=@lensql+len(@SistemaQualitaequalthis);end;
	IF (@IdPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PSR = @IdPsrequalthis)''; set @lensql=@lensql+len(@IdPsrequalthis);end;
	IF (@CodMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_MISURA = @CodMisuraequalthis)''; set @lensql=@lensql+len(@CodMisuraequalthis);end;
	IF (@CodObiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_OBIETTIVO = @CodObiettivoequalthis)''; set @lensql=@lensql+len(@CodObiettivoequalthis);end;
	IF (@CodAsseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ASSE = @CodAsseequalthis)''; set @lensql=@lensql+len(@CodAsseequalthis);end;
	IF (@CodSubmisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_SUBMISURA = @CodSubmisuraequalthis)''; set @lensql=@lensql+len(@CodSubmisuraequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AMMESSO = @Ammessoequalthis)''; set @lensql=@lensql+len(@Ammessoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdImpresaXFilieraequalthis INT, @IdFilieraequalthis INT, @Cuaaequalthis VARCHAR(16), @FlagPartecipanteequalthis BIT, @CodRuoloSitraequalthis CHAR(3), @CodRuoloPartecipanteequalthis CHAR(1), @Quantitaequalthis DECIMAL(10,2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaXFilieraFindSelect';

