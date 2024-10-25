CREATE PROCEDURE [dbo].[ZVistruttoriaDomandeAiutoFFdomandeistruttoria]
(
	@IdBandoE INT, 
	@IdProgettoE INT, 
	@IdUtenteE INT, 
	@CodStatoE VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE, DATA_SCADENZA, ID_PROGETTO, DATA, STATO, ID_IMPRESA, CODICE_FISCALE, RAGIONE_SOCIALE, ID_UTENTE, COD_STATO FROM vIstruttoria_Domande_Aiuto WHERE 1=1';
	IF (@IdBandoE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoE)'; set @lensql=@lensql+len(@IdBandoE);end;
	IF (@IdProgettoE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoE)'; set @lensql=@lensql+len(@IdProgettoE);end;
	IF (@IdUtenteE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteE)'; set @lensql=@lensql+len(@IdUtenteE);end;
	IF (@CodStatoE IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoE)'; set @lensql=@lensql+len(@CodStatoE);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoE INT, @IdProgettoE INT, @IdUtenteE INT, @CodStatoE VARCHAR(255)',@IdBandoE , @IdProgettoE , @IdUtenteE , @CodStatoE ;
	else
		SELECT ID_BANDO, DESCRIZIONE, DATA_SCADENZA, ID_PROGETTO, DATA, STATO, ID_IMPRESA, CODICE_FISCALE, RAGIONE_SOCIALE, ID_UTENTE, COD_STATO
		FROM vIstruttoria_Domande_Aiuto
		WHERE 
			((@IdBandoE IS NULL) OR ID_BANDO = @IdBandoE) AND 
			((@IdProgettoE IS NULL) OR ID_PROGETTO = @IdProgettoE) AND 
			((@IdUtenteE IS NULL) OR ID_UTENTE = @IdUtenteE) AND 
			((@CodStatoE IS NULL) OR COD_STATO = @CodStatoE)