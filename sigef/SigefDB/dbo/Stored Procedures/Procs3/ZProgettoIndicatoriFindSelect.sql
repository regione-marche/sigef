CREATE PROCEDURE [dbo].[ZProgettoIndicatoriFindSelect]
(
	@IdProgettoIndicatoriequalthis INT, 
	@IdDimXProgrammazioneequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdVarianteequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@ValoreProgrammatoRichiestoequalthis DECIMAL(18,2), 
	@ValoreRealizzatoRichiestoequalthis DECIMAL(18,2), 
	@DataRegistrazioneequalthis DATETIME, 
	@Operatoreequalthis INT, 
	@ValoreProgrammatoAmmessoequalthis DECIMAL(18,2), 
	@ValoreRealizzatoAmmessoequalthis DECIMAL(18,2), 
	@DataIstruttoriaequalthis DATETIME, 
	@Istruttoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO_INDICATORI, ID_DIM_X_PROGRAMMAZIONE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, VALORE_PROGRAMMATO_RICHIESTO, VALORE_REALIZZATO_RICHIESTO, DATA_REGISTRAZIONE, OPERATORE, VALORE_PROGRAMMATO_AMMESSO, VALORE_REALIZZATO_AMMESSO, DATA_ISTRUTTORIA, ISTRUTTORE, Dim_Descrizione, Dim_Um, RICHIEDIBILE, PROCEDURA_CALCOLO, Dim_Codice, Id_Programmazione, Programmazione_Codice, Programmazione_Descrizione FROM vPROGETTO_INDICATORI WHERE 1=1';
	IF (@IdProgettoIndicatoriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_INDICATORI = @IdProgettoIndicatoriequalthis)'; set @lensql=@lensql+len(@IdProgettoIndicatoriequalthis);end;
	IF (@IdDimXProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DIM_X_PROGRAMMAZIONE = @IdDimXProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdDimXProgrammazioneequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@ValoreProgrammatoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_PROGRAMMATO_RICHIESTO = @ValoreProgrammatoRichiestoequalthis)'; set @lensql=@lensql+len(@ValoreProgrammatoRichiestoequalthis);end;
	IF (@ValoreRealizzatoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_REALIZZATO_RICHIESTO = @ValoreRealizzatoRichiestoequalthis)'; set @lensql=@lensql+len(@ValoreRealizzatoRichiestoequalthis);end;
	IF (@DataRegistrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_REGISTRAZIONE = @DataRegistrazioneequalthis)'; set @lensql=@lensql+len(@DataRegistrazioneequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@ValoreProgrammatoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_PROGRAMMATO_AMMESSO = @ValoreProgrammatoAmmessoequalthis)'; set @lensql=@lensql+len(@ValoreProgrammatoAmmessoequalthis);end;
	IF (@ValoreRealizzatoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_REALIZZATO_AMMESSO = @ValoreRealizzatoAmmessoequalthis)'; set @lensql=@lensql+len(@ValoreRealizzatoAmmessoequalthis);end;
	IF (@DataIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ISTRUTTORIA = @DataIstruttoriaequalthis)'; set @lensql=@lensql+len(@DataIstruttoriaequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE = @Istruttoreequalthis)'; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoIndicatoriequalthis INT, @IdDimXProgrammazioneequalthis INT, @IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdVarianteequalthis INT, @CodTipoequalthis VARCHAR(255), @ValoreProgrammatoRichiestoequalthis DECIMAL(18,2), @ValoreRealizzatoRichiestoequalthis DECIMAL(18,2), @DataRegistrazioneequalthis DATETIME, @Operatoreequalthis INT, @ValoreProgrammatoAmmessoequalthis DECIMAL(18,2), @ValoreRealizzatoAmmessoequalthis DECIMAL(18,2), @DataIstruttoriaequalthis DATETIME, @Istruttoreequalthis INT',@IdProgettoIndicatoriequalthis , @IdDimXProgrammazioneequalthis , @IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdVarianteequalthis , @CodTipoequalthis , @ValoreProgrammatoRichiestoequalthis , @ValoreRealizzatoRichiestoequalthis , @DataRegistrazioneequalthis , @Operatoreequalthis , @ValoreProgrammatoAmmessoequalthis , @ValoreRealizzatoAmmessoequalthis , @DataIstruttoriaequalthis , @Istruttoreequalthis ;
	else
		SELECT ID_PROGETTO_INDICATORI, ID_DIM_X_PROGRAMMAZIONE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, VALORE_PROGRAMMATO_RICHIESTO, VALORE_REALIZZATO_RICHIESTO, DATA_REGISTRAZIONE, OPERATORE, VALORE_PROGRAMMATO_AMMESSO, VALORE_REALIZZATO_AMMESSO, DATA_ISTRUTTORIA, ISTRUTTORE, Dim_Descrizione, Dim_Um, RICHIEDIBILE, PROCEDURA_CALCOLO, Dim_Codice, Id_Programmazione, Programmazione_Codice, Programmazione_Descrizione
		FROM vPROGETTO_INDICATORI
		WHERE 
			((@IdProgettoIndicatoriequalthis IS NULL) OR ID_PROGETTO_INDICATORI = @IdProgettoIndicatoriequalthis) AND 
			((@IdDimXProgrammazioneequalthis IS NULL) OR ID_DIM_X_PROGRAMMAZIONE = @IdDimXProgrammazioneequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@ValoreProgrammatoRichiestoequalthis IS NULL) OR VALORE_PROGRAMMATO_RICHIESTO = @ValoreProgrammatoRichiestoequalthis) AND 
			((@ValoreRealizzatoRichiestoequalthis IS NULL) OR VALORE_REALIZZATO_RICHIESTO = @ValoreRealizzatoRichiestoequalthis) AND 
			((@DataRegistrazioneequalthis IS NULL) OR DATA_REGISTRAZIONE = @DataRegistrazioneequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@ValoreProgrammatoAmmessoequalthis IS NULL) OR VALORE_PROGRAMMATO_AMMESSO = @ValoreProgrammatoAmmessoequalthis) AND 
			((@ValoreRealizzatoAmmessoequalthis IS NULL) OR VALORE_REALIZZATO_AMMESSO = @ValoreRealizzatoAmmessoequalthis) AND 
			((@DataIstruttoriaequalthis IS NULL) OR DATA_ISTRUTTORIA = @DataIstruttoriaequalthis) AND 
			((@Istruttoreequalthis IS NULL) OR ISTRUTTORE = @Istruttoreequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoIndicatoriFindSelect';

