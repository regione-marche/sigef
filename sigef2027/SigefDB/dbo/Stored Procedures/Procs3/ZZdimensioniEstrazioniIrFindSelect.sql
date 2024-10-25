CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIrFindSelect]
(
	@IdEstrazioneIrequalthis INT, 
	@CodicePsrequalthis VARCHAR(255), 
	@IdDimensioneequalthis INT, 
	@DataInizioequalthis DATETIME, 
	@DataFineequalthis DATETIME, 
	@ValoreBaseequalthis DECIMAL(18,2), 
	@ValoreObbiettivoequalthis DECIMAL(18,2), 
	@ValoreRealizzatoequalthis DECIMAL(18,2), 
	@Umequalthis VARCHAR(255), 
	@CodiceObmisuraequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ESTRAZIONE_IR, CODICE_PSR, ID_DIMENSIONE, DATA_INIZIO, DATA_FINE, VALORE_BASE, VALORE_OBBIETTIVO, VALORE_REALIZZATO, UM, CODICE_OBMISURA, DIMENSIONE_CODICE, DIMENSIONE_DESCRIZIONE, DIMENSIONE_ORDINE, ANNO FROM vzDIMENSIONI_ESTRAZIONI_IR WHERE 1=1';
	IF (@IdEstrazioneIrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ESTRAZIONE_IR = @IdEstrazioneIrequalthis)'; set @lensql=@lensql+len(@IdEstrazioneIrequalthis);end;
	IF (@CodicePsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_PSR = @CodicePsrequalthis)'; set @lensql=@lensql+len(@CodicePsrequalthis);end;
	IF (@IdDimensioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DIMENSIONE = @IdDimensioneequalthis)'; set @lensql=@lensql+len(@IdDimensioneequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@ValoreBaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_BASE = @ValoreBaseequalthis)'; set @lensql=@lensql+len(@ValoreBaseequalthis);end;
	IF (@ValoreObbiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_OBBIETTIVO = @ValoreObbiettivoequalthis)'; set @lensql=@lensql+len(@ValoreObbiettivoequalthis);end;
	IF (@ValoreRealizzatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_REALIZZATO = @ValoreRealizzatoequalthis)'; set @lensql=@lensql+len(@ValoreRealizzatoequalthis);end;
	IF (@Umequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UM = @Umequalthis)'; set @lensql=@lensql+len(@Umequalthis);end;
	IF (@CodiceObmisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_OBMISURA = @CodiceObmisuraequalthis)'; set @lensql=@lensql+len(@CodiceObmisuraequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdEstrazioneIrequalthis INT, @CodicePsrequalthis VARCHAR(255), @IdDimensioneequalthis INT, @DataInizioequalthis DATETIME, @DataFineequalthis DATETIME, @ValoreBaseequalthis DECIMAL(18,2), @ValoreObbiettivoequalthis DECIMAL(18,2), @ValoreRealizzatoequalthis DECIMAL(18,2), @Umequalthis VARCHAR(255), @CodiceObmisuraequalthis VARCHAR(255)',@IdEstrazioneIrequalthis , @CodicePsrequalthis , @IdDimensioneequalthis , @DataInizioequalthis , @DataFineequalthis , @ValoreBaseequalthis , @ValoreObbiettivoequalthis , @ValoreRealizzatoequalthis , @Umequalthis , @CodiceObmisuraequalthis ;
	else
		SELECT ID_ESTRAZIONE_IR, CODICE_PSR, ID_DIMENSIONE, DATA_INIZIO, DATA_FINE, VALORE_BASE, VALORE_OBBIETTIVO, VALORE_REALIZZATO, UM, CODICE_OBMISURA, DIMENSIONE_CODICE, DIMENSIONE_DESCRIZIONE, DIMENSIONE_ORDINE, ANNO
		FROM vzDIMENSIONI_ESTRAZIONI_IR
		WHERE 
			((@IdEstrazioneIrequalthis IS NULL) OR ID_ESTRAZIONE_IR = @IdEstrazioneIrequalthis) AND 
			((@CodicePsrequalthis IS NULL) OR CODICE_PSR = @CodicePsrequalthis) AND 
			((@IdDimensioneequalthis IS NULL) OR ID_DIMENSIONE = @IdDimensioneequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@ValoreBaseequalthis IS NULL) OR VALORE_BASE = @ValoreBaseequalthis) AND 
			((@ValoreObbiettivoequalthis IS NULL) OR VALORE_OBBIETTIVO = @ValoreObbiettivoequalthis) AND 
			((@ValoreRealizzatoequalthis IS NULL) OR VALORE_REALIZZATO = @ValoreRealizzatoequalthis) AND 
			((@Umequalthis IS NULL) OR UM = @Umequalthis) AND 
			((@CodiceObmisuraequalthis IS NULL) OR CODICE_OBMISURA = @CodiceObmisuraequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIrFindSelect]
(
	@IdEstrazioneIrequalthis INT, 
	@CodicePsrequalthis VARCHAR(255), 
	@IdDimensioneequalthis INT, 
	@DataInizioequalthis DATETIME, 
	@DataFineequalthis DATETIME, 
	@ValoreBaseequalthis DECIMAL(18,2), 
	@ValoreObbiettivoequalthis DECIMAL(18,2), 
	@ValoreRealizzatoequalthis DECIMAL(18,2), 
	@Umequalthis VARCHAR(255), 
	@CodiceObmisuraequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ESTRAZIONE_IR, CODICE_PSR, ID_DIMENSIONE, DATA_INIZIO, DATA_FINE, VALORE_BASE, VALORE_OBBIETTIVO, VALORE_REALIZZATO, UM, CODICE_OBMISURA, DIMENSIONE_CODICE, DIMENSIONE_DESCRIZIONE, DIMENSIONE_ORDINE, ANNO FROM vzDIMENSIONI_ESTRAZIONI_IR WHERE 1=1'';
	IF (@IdEstrazioneIrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ESTRAZIONE_IR = @IdEstrazioneIrequalthis)''; set @lensql=@lensql+len(@IdEstrazioneIrequalthis);end;
	IF (@CodicePsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE_PSR = @CodicePsrequalthis)''; set @lensql=@lensql+len(@CodicePsrequalthis);end;
	IF (@IdDimensioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DIMENSIONE = @IdDimensioneequalthis)''; set @lensql=@lensql+len(@IdDimensioneequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INIZIO = @DataInizioequalthis)''; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE = @DataFineequalthis)''; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@ValoreBaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE_BASE = @ValoreBaseequalthis)''; set @lensql=@lensql+len(@ValoreBaseequalthis);end;
	IF (@ValoreObbiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE_OBBIETTIVO = @ValoreObbiettivoequalthis)''; set @lensql=@lensql+len(@ValoreObbiettivoequalthis);end;
	IF (@ValoreRealizzatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE_REALIZZATO = @ValoreRealizzatoequalthis)''; set @lensql=@lensql+len(@ValoreRealizzatoequalthis);end;
	IF (@Umequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (UM = @Umequalthis)''; set @lensql=@lensql+len(@Umequalthis);end;
	IF (@CodiceObmisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE_OBMISURA = @CodiceObmisuraequalthis)''; set @lensql=@lensql+len(@CodiceObmisuraequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdEstrazioneIrequalthis INT, @CodicePsrequalthis VARCHAR(255), @IdDimensioneequalthis INT, @DataInizioequalthis DATETIME, @DataFineequalthis DATETIME, @ValoreBaseequalthis DECIMAL(18,2), @ValoreObbiettivoequalthis DECIMAL(18,2), @ValoreRealizzatoequalthis DECIMAL(18,2), @Umequalthis VARCHAR(255), @CodiceObmisuraequalthis VARCHAR(255)'',@IdEstrazioneIrequalthis , @CodicePsrequalthis , @IdDimensioneequalthis , @DataInizioequalthis , @DataFineequalthis , @ValoreBaseequalthis , @ValoreObbiettivoequalthis , @ValoreRealizzatoequalthis , @Umequalthis , @CodiceObmisuraequalthis ;
	else
		SELECT ID_ESTRAZIONE_IR, CODICE_PSR, ID_DIMENSIONE, DATA_INIZIO, DATA_FINE, VALORE_BASE, VALORE_OBBIETTIVO, VALORE_REALIZZATO, UM, CODICE_OBMISURA, DIMENSIONE_CODICE, DIMENSIONE_DESCRIZIONE, DIMENSIONE_ORDINE, ANNO
		FROM vzDIMENSIONI_ESTRAZIONI_IR
		WHERE 
			((@IdEstrazioneIrequalthis IS NULL) OR ID_ESTRAZIONE_IR = @IdEstrazioneIrequalthis) AND 
			((@CodicePsrequalthis IS NULL) OR CODICE_PSR = @CodicePsrequalthis) AND 
			((@IdDimensioneequalthis IS NULL) OR ID_DIMENSIONE = @IdDimensioneequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@ValoreBaseequalthis IS NULL) OR VALORE_BASE = @ValoreBaseequalthis) AND 
			((@ValoreObbiettivoequalthis IS NULL) OR VALORE_OBBIETTIVO = @ValoreObbiettivoequalthis) AND 
			((@ValoreRealizzatoequalthis IS NULL) OR VALORE_REALIZ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIrFindSelect';

