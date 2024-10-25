CREATE PROCEDURE [dbo].[ZVistruttoriaDomandeAiutoFSelect]
(
	@IdBandoE INT, 
	@DescrizioneE VARCHAR(2000), 
	@DataScadenzaE DATETIME, 
	@IdProgettoE INT, 
	@DataE DATETIME, 
	@StatoE VARCHAR(255), 
	@IdImpresaE INT, 
	@CodiceFiscaleE VARCHAR(255), 
	@RagioneSocialeE VARCHAR(255), 
	@IdUtenteE INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE, DATA_SCADENZA, ID_PROGETTO, DATA, STATO, ID_IMPRESA, CODICE_FISCALE, RAGIONE_SOCIALE, ID_UTENTE FROM vIstruttoria_Domande_Aiuto WHERE 1=1';
	IF (@IdBandoE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoE)'; set @lensql=@lensql+len(@IdBandoE);end;
	IF (@DescrizioneE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @DescrizioneE)'; set @lensql=@lensql+len(@DescrizioneE);end;
	IF (@DataScadenzaE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA = @DataScadenzaE)'; set @lensql=@lensql+len(@DataScadenzaE);end;
	IF (@IdProgettoE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoE)'; set @lensql=@lensql+len(@IdProgettoE);end;
	IF (@DataE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @DataE)'; set @lensql=@lensql+len(@DataE);end;
	IF (@StatoE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO = @StatoE)'; set @lensql=@lensql+len(@StatoE);end;
	IF (@IdImpresaE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaE)'; set @lensql=@lensql+len(@IdImpresaE);end;
	IF (@CodiceFiscaleE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_FISCALE = @CodiceFiscaleE)'; set @lensql=@lensql+len(@CodiceFiscaleE);end;
	IF (@RagioneSocialeE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE = @RagioneSocialeE)'; set @lensql=@lensql+len(@RagioneSocialeE);end;
	IF (@IdUtenteE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteE)'; set @lensql=@lensql+len(@IdUtenteE);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoE INT, @DescrizioneE VARCHAR(2000), @DataScadenzaE DATETIME, @IdProgettoE INT, @DataE DATETIME, @StatoE VARCHAR(255), @IdImpresaE INT, @CodiceFiscaleE VARCHAR(255), @RagioneSocialeE VARCHAR(255), @IdUtenteE INT',@IdBandoE , @DescrizioneE , @DataScadenzaE , @IdProgettoE , @DataE , @StatoE , @IdImpresaE , @CodiceFiscaleE , @RagioneSocialeE , @IdUtenteE ;
	else
		SELECT ID_BANDO, DESCRIZIONE, DATA_SCADENZA, ID_PROGETTO, DATA, STATO, ID_IMPRESA, CODICE_FISCALE, RAGIONE_SOCIALE, ID_UTENTE
		FROM vIstruttoria_Domande_Aiuto
		WHERE 
			((@IdBandoE IS NULL) OR ID_BANDO = @IdBandoE) AND 
			((@DescrizioneE IS NULL) OR DESCRIZIONE = @DescrizioneE) AND 
			((@DataScadenzaE IS NULL) OR DATA_SCADENZA = @DataScadenzaE) AND 
			((@IdProgettoE IS NULL) OR ID_PROGETTO = @IdProgettoE) AND 
			((@DataE IS NULL) OR DATA = @DataE) AND 
			((@StatoE IS NULL) OR STATO = @StatoE) AND 
			((@IdImpresaE IS NULL) OR ID_IMPRESA = @IdImpresaE) AND 
			((@CodiceFiscaleE IS NULL) OR CODICE_FISCALE = @CodiceFiscaleE) AND 
			((@RagioneSocialeE IS NULL) OR RAGIONE_SOCIALE = @RagioneSocialeE) AND 
			((@IdUtenteE IS NULL) OR ID_UTENTE = @IdUtenteE)