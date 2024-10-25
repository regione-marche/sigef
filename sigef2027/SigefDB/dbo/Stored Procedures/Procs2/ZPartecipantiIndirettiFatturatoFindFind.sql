CREATE PROCEDURE [dbo].[ZPartecipantiIndirettiFatturatoFindFind]
(
	@IdImpresaequalthis INT, 
	@Cuaaequalthis VARCHAR(16), 
	@CuaaTrasformatoreequalthis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, CUAA_PROMOTORE, ID_IMPRESA, CUAA, COD_PRODOTTO, COD_VARIETA, PRODUZIONE_TOTALE, PREZZO_MEDIO, FATTURATO, VARIETA, PRODOTTO, CODICE_FISCALE, RAGIONE_SOCIALE, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, ID_CLASSE_ALLEVAMENTO, ID_ATTIVITA_CONNESSA, CUAA_TRASFORMATORE, DESCRIZIONE, PREZZO_UNITARIO, ATTIVITA_CONNESSE, PREZZO_ATTIVITA, PRODUZIONE_IN_FILIERA, NUMERO_CAPI FROM vPARECIPANTI_INDIRETTI_FATTURATO WHERE 1=1';
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@CuaaTrasformatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA_TRASFORMATORE = @CuaaTrasformatoreequalthis)'; set @lensql=@lensql+len(@CuaaTrasformatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdImpresaequalthis INT, @Cuaaequalthis VARCHAR(16), @CuaaTrasformatoreequalthis VARCHAR(16)',@IdImpresaequalthis , @Cuaaequalthis , @CuaaTrasformatoreequalthis ;
	else
		SELECT ID, CUAA_PROMOTORE, ID_IMPRESA, CUAA, COD_PRODOTTO, COD_VARIETA, PRODUZIONE_TOTALE, PREZZO_MEDIO, FATTURATO, VARIETA, PRODOTTO, CODICE_FISCALE, RAGIONE_SOCIALE, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, ID_CLASSE_ALLEVAMENTO, ID_ATTIVITA_CONNESSA, CUAA_TRASFORMATORE, DESCRIZIONE, PREZZO_UNITARIO, ATTIVITA_CONNESSE, PREZZO_ATTIVITA, PRODUZIONE_IN_FILIERA, NUMERO_CAPI
		FROM vPARECIPANTI_INDIRETTI_FATTURATO
		WHERE 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@CuaaTrasformatoreequalthis IS NULL) OR CUAA_TRASFORMATORE = @CuaaTrasformatoreequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPartecipantiIndirettiFatturatoFindFind]
(
	@IdImpresaequalthis INT, 
	@Cuaaequalthis VARCHAR(16), 
	@CuaaTrasformatoreequalthis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, CUAA_PROMOTORE, ID_IMPRESA, CUAA, COD_PRODOTTO, COD_VARIETA, PRODUZIONE_TOTALE, PREZZO_MEDIO, FATTURATO, VARIETA, PRODOTTO, CODICE_FISCALE, RAGIONE_SOCIALE, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, ID_CLASSE_ALLEVAMENTO, ID_ATTIVITA_CONNESSA, CUAA_TRASFORMATORE, DESCRIZIONE, PREZZO_UNITARIO, ATTIVITA_CONNESSE, PREZZO_ATTIVITA, PRODUZIONE_IN_FILIERA, NUMERO_CAPI FROM vPARECIPANTI_INDIRETTI_FATTURATO WHERE 1=1'';
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CUAA = @Cuaaequalthis)''; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@CuaaTrasformatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CUAA_TRASFORMATORE = @CuaaTrasformatoreequalthis)''; set @lensql=@lensql+len(@CuaaTrasformatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdImpresaequalthis INT, @Cuaaequalthis VARCHAR(16), @CuaaTrasformatoreequalthis VARCHAR(16)'',@IdImpresaequalthis , @Cuaaequalthis , @CuaaTrasformatoreequalthis ;
	else
		SELECT ID, CUAA_PROMOTORE, ID_IMPRESA, CUAA, COD_PRODOTTO, COD_VARIETA, PRODUZIONE_TOTALE, PREZZO_MEDIO, FATTURATO, VARIETA, PRODOTTO, CODICE_FISCALE, RAGIONE_SOCIALE, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, ID_CLASSE_ALLEVAMENTO, ID_ATTIVITA_CONNESSA, CUAA_TRASFORMATORE, DESCRIZIONE, PREZZO_UNITARIO, ATTIVITA_CONNESSE, PREZZO_ATTIVITA, PRODUZIONE_IN_FILIERA, NUMERO_CAPI
		FROM vPARECIPANTI_INDIRETTI_FATTURATO
		WHERE 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@CuaaTrasformatoreequalthis IS NULL) OR CUAA_TRASFORMATORE = @CuaaTrasformatoreequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipantiIndirettiFatturatoFindFind';

