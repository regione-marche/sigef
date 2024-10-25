CREATE PROCEDURE [dbo].[ZCertspRecuperiFindSelect]
(
	@IdRecuperoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdAttoequalthis INT, 
	@Sostegnoequalthis DECIMAL(18,2), 
	@SpeseAmmequalthis DECIMAL(18,2), 
	@DataRicevRimbequalthis DATETIME, 
	@RimbSostegnoequalthis DECIMAL(18,2), 
	@RimbSpeseAmmequalthis DECIMAL(18,2), 
	@NonrSostegnoequalthis DECIMAL(18,2), 
	@NonrSpeseAmmequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT Id_Recupero, Id_Progetto, Id_Atto, Sostegno, Spese_Amm, Data_Ricev_Rimb, Rimb_Sostegno, Rimb_Spese_Amm, NonR_Sostegno, NonR_Spese_Amm FROM CERTSP_RECUPERI WHERE 1=1';
	IF (@IdRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Recupero = @IdRecuperoequalthis)'; set @lensql=@lensql+len(@IdRecuperoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Progetto = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Atto = @IdAttoequalthis)'; set @lensql=@lensql+len(@IdAttoequalthis);end;
	IF (@Sostegnoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Sostegno = @Sostegnoequalthis)'; set @lensql=@lensql+len(@Sostegnoequalthis);end;
	IF (@SpeseAmmequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Spese_Amm = @SpeseAmmequalthis)'; set @lensql=@lensql+len(@SpeseAmmequalthis);end;
	IF (@DataRicevRimbequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Data_Ricev_Rimb = @DataRicevRimbequalthis)'; set @lensql=@lensql+len(@DataRicevRimbequalthis);end;
	IF (@RimbSostegnoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Rimb_Sostegno = @RimbSostegnoequalthis)'; set @lensql=@lensql+len(@RimbSostegnoequalthis);end;
	IF (@RimbSpeseAmmequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Rimb_Spese_Amm = @RimbSpeseAmmequalthis)'; set @lensql=@lensql+len(@RimbSpeseAmmequalthis);end;
	IF (@NonrSostegnoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NonR_Sostegno = @NonrSostegnoequalthis)'; set @lensql=@lensql+len(@NonrSostegnoequalthis);end;
	IF (@NonrSpeseAmmequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NonR_Spese_Amm = @NonrSpeseAmmequalthis)'; set @lensql=@lensql+len(@NonrSpeseAmmequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRecuperoequalthis INT, @IdProgettoequalthis INT, @IdAttoequalthis INT, @Sostegnoequalthis DECIMAL(18,2), @SpeseAmmequalthis DECIMAL(18,2), @DataRicevRimbequalthis DATETIME, @RimbSostegnoequalthis DECIMAL(18,2), @RimbSpeseAmmequalthis DECIMAL(18,2), @NonrSostegnoequalthis DECIMAL(18,2), @NonrSpeseAmmequalthis DECIMAL(18,2)',@IdRecuperoequalthis , @IdProgettoequalthis , @IdAttoequalthis , @Sostegnoequalthis , @SpeseAmmequalthis , @DataRicevRimbequalthis , @RimbSostegnoequalthis , @RimbSpeseAmmequalthis , @NonrSostegnoequalthis , @NonrSpeseAmmequalthis ;
	else
		SELECT Id_Recupero, Id_Progetto, Id_Atto, Sostegno, Spese_Amm, Data_Ricev_Rimb, Rimb_Sostegno, Rimb_Spese_Amm, NonR_Sostegno, NonR_Spese_Amm
		FROM CERTSP_RECUPERI
		WHERE 
			((@IdRecuperoequalthis IS NULL) OR Id_Recupero = @IdRecuperoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR Id_Progetto = @IdProgettoequalthis) AND 
			((@IdAttoequalthis IS NULL) OR Id_Atto = @IdAttoequalthis) AND 
			((@Sostegnoequalthis IS NULL) OR Sostegno = @Sostegnoequalthis) AND 
			((@SpeseAmmequalthis IS NULL) OR Spese_Amm = @SpeseAmmequalthis) AND 
			((@DataRicevRimbequalthis IS NULL) OR Data_Ricev_Rimb = @DataRicevRimbequalthis) AND 
			((@RimbSostegnoequalthis IS NULL) OR Rimb_Sostegno = @RimbSostegnoequalthis) AND 
			((@RimbSpeseAmmequalthis IS NULL) OR Rimb_Spese_Amm = @RimbSpeseAmmequalthis) AND 
			((@NonrSostegnoequalthis IS NULL) OR NonR_Sostegno = @NonrSostegnoequalthis) AND 
			((@NonrSpeseAmmequalthis IS NULL) OR NonR_Spese_Amm = @NonrSpeseAmmequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspRecuperiFindSelect';

