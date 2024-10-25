CREATE PROCEDURE [dbo].[ZProfiloXFunzioniFindSelect]
(
	@IdProfiloequalthis INT, 
	@CodFunzioneequalthis INT, 
	@Modificaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, COD_FUNZIONE, MODIFICA, FUNZIONALITA, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE_FUNZIONALITA, ABILITA_INSERIMENTO_UTENTI FROM vPROFILO_X_FUNZIONI WHERE 1=1';
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROFILO = @IdProfiloequalthis)'; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@CodFunzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FUNZIONE = @CodFunzioneequalthis)'; set @lensql=@lensql+len(@CodFunzioneequalthis);end;
	IF (@Modificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MODIFICA = @Modificaequalthis)'; set @lensql=@lensql+len(@Modificaequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProfiloequalthis INT, @CodFunzioneequalthis INT, @Modificaequalthis BIT',@IdProfiloequalthis , @CodFunzioneequalthis , @Modificaequalthis ;
	else
		SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, COD_FUNZIONE, MODIFICA, FUNZIONALITA, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE_FUNZIONALITA, ABILITA_INSERIMENTO_UTENTI
		FROM vPROFILO_X_FUNZIONI
		WHERE 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@CodFunzioneequalthis IS NULL) OR COD_FUNZIONE = @CodFunzioneequalthis) AND 
			((@Modificaequalthis IS NULL) OR MODIFICA = @Modificaequalthis)
		-- order by ecc.ecc.
