CREATE PROCEDURE [dbo].[ZCaaStoricoSportelloFindFind]
(
	@CodiceSportelloequalthis VARCHAR(255), 
	@UfficioProvincialeequalthis BIT, 
	@UfficioRegionaleequalthis BIT, 
	@CodStatoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, CODICE_SPORTELLO, DENOMINAZIONE, UFFICIO_PROVINCIALE, UFFICIO_REGIONALE, INDIRIZZO, ID_COMUNE, TELEFONO, FAX, EMAIL, COD_STATO, DATA, OPERATORE FROM CAA_STORICO_SPORTELLO WHERE 1=1';
	IF (@CodiceSportelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_SPORTELLO = @CodiceSportelloequalthis)'; set @lensql=@lensql+len(@CodiceSportelloequalthis);end;
	IF (@UfficioProvincialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UFFICIO_PROVINCIALE = @UfficioProvincialeequalthis)'; set @lensql=@lensql+len(@UfficioProvincialeequalthis);end;
	IF (@UfficioRegionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UFFICIO_REGIONALE = @UfficioRegionaleequalthis)'; set @lensql=@lensql+len(@UfficioRegionaleequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodiceSportelloequalthis VARCHAR(255), @UfficioProvincialeequalthis BIT, @UfficioRegionaleequalthis BIT, @CodStatoequalthis VARCHAR(255)',@CodiceSportelloequalthis , @UfficioProvincialeequalthis , @UfficioRegionaleequalthis , @CodStatoequalthis ;
	else
		SELECT ID, CODICE_SPORTELLO, DENOMINAZIONE, UFFICIO_PROVINCIALE, UFFICIO_REGIONALE, INDIRIZZO, ID_COMUNE, TELEFONO, FAX, EMAIL, COD_STATO, DATA, OPERATORE
		FROM CAA_STORICO_SPORTELLO
		WHERE 
			((@CodiceSportelloequalthis IS NULL) OR CODICE_SPORTELLO = @CodiceSportelloequalthis) AND 
			((@UfficioProvincialeequalthis IS NULL) OR UFFICIO_PROVINCIALE = @UfficioProvincialeequalthis) AND 
			((@UfficioRegionaleequalthis IS NULL) OR UFFICIO_REGIONALE = @UfficioRegionaleequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaStoricoSportelloFindFind';

