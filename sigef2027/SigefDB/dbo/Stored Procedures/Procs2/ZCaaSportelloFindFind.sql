CREATE PROCEDURE [dbo].[ZCaaSportelloFindFind]
(
	@Codiceequalthis VARCHAR(255), 
	@CodEnteequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Provinciaequalthis VARCHAR(255), 
	@CodStatoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT CODICE, CODICE_CAA, CODICE_PROVINCIA, CODICE_UFFICIO, COD_ENTE, ID_STORICO_ULTIMO, STATO, DENOMINAZIONE, UFFICIO_PROVINCIALE, UFFICIO_REGIONALE, INDIRIZZO, ID_COMUNE, TELEFONO, FAX, EMAIL, COD_STATO, DATA, OPERATORE, COMUNE, PROVINCIA, CAP FROM vCAA_SPORTELLO WHERE 1=1';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	set @sql = @sql + 'ORDER BY CODICE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Codiceequalthis VARCHAR(255), @CodEnteequalthis VARCHAR(255), @IdComuneequalthis INT, @Provinciaequalthis VARCHAR(255), @CodStatoequalthis VARCHAR(255)',@Codiceequalthis , @CodEnteequalthis , @IdComuneequalthis , @Provinciaequalthis , @CodStatoequalthis ;
	else
		SELECT CODICE, CODICE_CAA, CODICE_PROVINCIA, CODICE_UFFICIO, COD_ENTE, ID_STORICO_ULTIMO, STATO, DENOMINAZIONE, UFFICIO_PROVINCIALE, UFFICIO_REGIONALE, INDIRIZZO, ID_COMUNE, TELEFONO, FAX, EMAIL, COD_STATO, DATA, OPERATORE, COMUNE, PROVINCIA, CAP
		FROM vCAA_SPORTELLO
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis)
		ORDER BY CODICE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaSportelloFindFind';

