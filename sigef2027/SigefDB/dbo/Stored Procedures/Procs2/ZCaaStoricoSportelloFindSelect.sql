CREATE PROCEDURE [dbo].[ZCaaStoricoSportelloFindSelect]
(
	@Idequalthis INT, 
	@CodiceSportelloequalthis VARCHAR(255), 
	@Denominazioneequalthis VARCHAR(255), 
	@UfficioProvincialeequalthis BIT, 
	@UfficioRegionaleequalthis BIT, 
	@Indirizzoequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Telefonoequalthis VARCHAR(255), 
	@Faxequalthis VARCHAR(255), 
	@Emailequalthis VARCHAR(255), 
	@CodStatoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, CODICE_SPORTELLO, DENOMINAZIONE, UFFICIO_PROVINCIALE, UFFICIO_REGIONALE, INDIRIZZO, ID_COMUNE, TELEFONO, FAX, EMAIL, COD_STATO, DATA, OPERATORE FROM CAA_STORICO_SPORTELLO WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@CodiceSportelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_SPORTELLO = @CodiceSportelloequalthis)'; set @lensql=@lensql+len(@CodiceSportelloequalthis);end;
	IF (@Denominazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DENOMINAZIONE = @Denominazioneequalthis)'; set @lensql=@lensql+len(@Denominazioneequalthis);end;
	IF (@UfficioProvincialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UFFICIO_PROVINCIALE = @UfficioProvincialeequalthis)'; set @lensql=@lensql+len(@UfficioProvincialeequalthis);end;
	IF (@UfficioRegionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UFFICIO_REGIONALE = @UfficioRegionaleequalthis)'; set @lensql=@lensql+len(@UfficioRegionaleequalthis);end;
	IF (@Indirizzoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INDIRIZZO = @Indirizzoequalthis)'; set @lensql=@lensql+len(@Indirizzoequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Telefonoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TELEFONO = @Telefonoequalthis)'; set @lensql=@lensql+len(@Telefonoequalthis);end;
	IF (@Faxequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FAX = @Faxequalthis)'; set @lensql=@lensql+len(@Faxequalthis);end;
	IF (@Emailequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (EMAIL = @Emailequalthis)'; set @lensql=@lensql+len(@Emailequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @CodiceSportelloequalthis VARCHAR(255), @Denominazioneequalthis VARCHAR(255), @UfficioProvincialeequalthis BIT, @UfficioRegionaleequalthis BIT, @Indirizzoequalthis VARCHAR(255), @IdComuneequalthis INT, @Telefonoequalthis VARCHAR(255), @Faxequalthis VARCHAR(255), @Emailequalthis VARCHAR(255), @CodStatoequalthis VARCHAR(255), @Dataequalthis DATETIME, @Operatoreequalthis INT',@Idequalthis , @CodiceSportelloequalthis , @Denominazioneequalthis , @UfficioProvincialeequalthis , @UfficioRegionaleequalthis , @Indirizzoequalthis , @IdComuneequalthis , @Telefonoequalthis , @Faxequalthis , @Emailequalthis , @CodStatoequalthis , @Dataequalthis , @Operatoreequalthis ;
	else
		SELECT ID, CODICE_SPORTELLO, DENOMINAZIONE, UFFICIO_PROVINCIALE, UFFICIO_REGIONALE, INDIRIZZO, ID_COMUNE, TELEFONO, FAX, EMAIL, COD_STATO, DATA, OPERATORE
		FROM CAA_STORICO_SPORTELLO
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@CodiceSportelloequalthis IS NULL) OR CODICE_SPORTELLO = @CodiceSportelloequalthis) AND 
			((@Denominazioneequalthis IS NULL) OR DENOMINAZIONE = @Denominazioneequalthis) AND 
			((@UfficioProvincialeequalthis IS NULL) OR UFFICIO_PROVINCIALE = @UfficioProvincialeequalthis) AND 
			((@UfficioRegionaleequalthis IS NULL) OR UFFICIO_REGIONALE = @UfficioRegionaleequalthis) AND 
			((@Indirizzoequalthis IS NULL) OR INDIRIZZO = @Indirizzoequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Telefonoequalthis IS NULL) OR TELEFONO = @Telefonoequalthis) AND 
			((@Faxequalthis IS NULL) OR FAX = @Faxequalthis) AND 
			((@Emailequalthis IS NULL) OR EMAIL = @Emailequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaStoricoSportelloFindSelect';

