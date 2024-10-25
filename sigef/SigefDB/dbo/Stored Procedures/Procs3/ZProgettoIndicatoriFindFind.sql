CREATE PROCEDURE [dbo].[ZProgettoIndicatoriFindFind]
(
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdVarianteequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO_INDICATORI, ID_DIM_X_PROGRAMMAZIONE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, VALORE_PROGRAMMATO_RICHIESTO, VALORE_REALIZZATO_RICHIESTO, DATA_REGISTRAZIONE, OPERATORE, VALORE_PROGRAMMATO_AMMESSO, VALORE_REALIZZATO_AMMESSO, DATA_ISTRUTTORIA, ISTRUTTORE, Dim_Descrizione, Dim_Um, RICHIEDIBILE, PROCEDURA_CALCOLO, Dim_Codice, Id_Programmazione, Programmazione_Codice, Programmazione_Descrizione FROM vPROGETTO_INDICATORI WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	set @sql = @sql + 'ORDER BY DATA_REGISTRAZIONE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdVarianteequalthis INT',@IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdVarianteequalthis ;
	else
		SELECT ID_PROGETTO_INDICATORI, ID_DIM_X_PROGRAMMAZIONE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO, VALORE_PROGRAMMATO_RICHIESTO, VALORE_REALIZZATO_RICHIESTO, DATA_REGISTRAZIONE, OPERATORE, VALORE_PROGRAMMATO_AMMESSO, VALORE_REALIZZATO_AMMESSO, DATA_ISTRUTTORIA, ISTRUTTORE, Dim_Descrizione, Dim_Um, RICHIEDIBILE, PROCEDURA_CALCOLO, Dim_Codice, Id_Programmazione, Programmazione_Codice, Programmazione_Descrizione
		FROM vPROGETTO_INDICATORI
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis)
		ORDER BY DATA_REGISTRAZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoIndicatoriFindFind';

