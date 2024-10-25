CREATE PROCEDURE [dbo].[ZCaaSportelloFindSelect]
(
	@Codiceequalthis VARCHAR(255), 
	@CodiceCaaequalthis VARCHAR(255), 
	@CodiceProvinciaequalthis VARCHAR(255), 
	@CodiceUfficioequalthis VARCHAR(255), 
	@CodEnteequalthis VARCHAR(255), 
	@IdStoricoUltimoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT CODICE, CODICE_CAA, CODICE_PROVINCIA, CODICE_UFFICIO, COD_ENTE, ID_STORICO_ULTIMO, STATO, DENOMINAZIONE, UFFICIO_PROVINCIALE, UFFICIO_REGIONALE, INDIRIZZO, ID_COMUNE, TELEFONO, FAX, EMAIL, COD_STATO, DATA, OPERATORE, COMUNE, PROVINCIA, CAP FROM vCAA_SPORTELLO WHERE 1=1';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@CodiceCaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_CAA = @CodiceCaaequalthis)'; set @lensql=@lensql+len(@CodiceCaaequalthis);end;
	IF (@CodiceProvinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_PROVINCIA = @CodiceProvinciaequalthis)'; set @lensql=@lensql+len(@CodiceProvinciaequalthis);end;
	IF (@CodiceUfficioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_UFFICIO = @CodiceUfficioequalthis)'; set @lensql=@lensql+len(@CodiceUfficioequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)'; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Codiceequalthis VARCHAR(255), @CodiceCaaequalthis VARCHAR(255), @CodiceProvinciaequalthis VARCHAR(255), @CodiceUfficioequalthis VARCHAR(255), @CodEnteequalthis VARCHAR(255), @IdStoricoUltimoequalthis INT',@Codiceequalthis , @CodiceCaaequalthis , @CodiceProvinciaequalthis , @CodiceUfficioequalthis , @CodEnteequalthis , @IdStoricoUltimoequalthis ;
	else
		SELECT CODICE, CODICE_CAA, CODICE_PROVINCIA, CODICE_UFFICIO, COD_ENTE, ID_STORICO_ULTIMO, STATO, DENOMINAZIONE, UFFICIO_PROVINCIALE, UFFICIO_REGIONALE, INDIRIZZO, ID_COMUNE, TELEFONO, FAX, EMAIL, COD_STATO, DATA, OPERATORE, COMUNE, PROVINCIA, CAP
		FROM vCAA_SPORTELLO
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@CodiceCaaequalthis IS NULL) OR CODICE_CAA = @CodiceCaaequalthis) AND 
			((@CodiceProvinciaequalthis IS NULL) OR CODICE_PROVINCIA = @CodiceProvinciaequalthis) AND 
			((@CodiceUfficioequalthis IS NULL) OR CODICE_UFFICIO = @CodiceUfficioequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@IdStoricoUltimoequalthis IS NULL) OR ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaSportelloFindSelect';

