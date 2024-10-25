CREATE PROCEDURE [dbo].[ZImpresaXFilieraFindFind]
(
	@IdFilieraequalthis INT, 
	@Cuaalikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_IMPRESA_X_FILIERA, ID_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, RUOLO_PARTECIPANTE, QUANTITA, UNITA_MISURA, DESCRIZIONE_UNITA_MISURA, SISTEMA_QUALITA, DESCRIZIONE_SISTEMA_QUALITA, CODIFICA_INTERVENTI, OPERATORE, AMMESSO, ID_PROGRAMMAZIONE, PROGRAMMAZIONE, COD_PROGRAMMAZIONE FROM vIMPRESA_X_FILIERA WHERE 1=1';
	IF (@IdFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILIERA = @IdFilieraequalthis)'; set @lensql=@lensql+len(@IdFilieraequalthis);end;
	IF (@Cuaalikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA LIKE @Cuaalikethis)'; set @lensql=@lensql+len(@Cuaalikethis);end;
	set @sql = @sql + 'ORDER BY AMMESSO, CUAA';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdFilieraequalthis INT, @Cuaalikethis VARCHAR(255)',@IdFilieraequalthis , @Cuaalikethis ;
	else
		SELECT ID_IMPRESA_X_FILIERA, ID_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, RUOLO_PARTECIPANTE, QUANTITA, UNITA_MISURA, DESCRIZIONE_UNITA_MISURA, SISTEMA_QUALITA, DESCRIZIONE_SISTEMA_QUALITA, CODIFICA_INTERVENTI, OPERATORE, AMMESSO, ID_PROGRAMMAZIONE, PROGRAMMAZIONE, COD_PROGRAMMAZIONE
		FROM vIMPRESA_X_FILIERA
		WHERE 
			((@IdFilieraequalthis IS NULL) OR ID_FILIERA = @IdFilieraequalthis) AND 
			((@Cuaalikethis IS NULL) OR CUAA LIKE @Cuaalikethis)
		ORDER BY AMMESSO, CUAA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaXFilieraFindFind]
(
	@IdFilieraequalthis INT, 
	@Cuaalikethis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_IMPRESA_X_FILIERA, ID_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, RUOLO_PARTECIPANTE, QUANTITA, UNITA_MISURA, DESCRIZIONE_UNITA_MISURA, SISTEMA_QUALITA, DESCRIZIONE_SISTEMA_QUALITA, ID_PSR, PSR, COD_MISURA, MISURA, COD_OBIETTIVO, OBIETTIVO, COD_ASSE, ASSE, COD_SUBMISURA, SUBMISURA, CODIFICA_INTERVENTI, OPERATORE, CODICE, AMMESSO FROM vIMPRESA_X_FILIERA WHERE 1=1'';
	IF (@IdFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILIERA = @IdFilieraequalthis)''; set @lensql=@lensql+len(@IdFilieraequalthis);end;
	IF (@Cuaalikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CUAA LIKE @Cuaalikethis)''; set @lensql=@lensql+len(@Cuaalikethis);end;
	set @sql = @sql + ''ORDER BY AMMESSO, CUAA'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdFilieraequalthis INT, @Cuaalikethis VARCHAR(16)'',@IdFilieraequalthis , @Cuaalikethis ;
	else
		SELECT ID_IMPRESA_X_FILIERA, ID_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, RUOLO_PARTECIPANTE, QUANTITA, UNITA_MISURA, DESCRIZIONE_UNITA_MISURA, SISTEMA_QUALITA, DESCRIZIONE_SISTEMA_QUALITA, ID_PSR, PSR, COD_MISURA, MISURA, COD_OBIETTIVO, OBIETTIVO, COD_ASSE, ASSE, COD_SUBMISURA, SUBMISURA, CODIFICA_INTERVENTI, OPERATORE, CODICE, AMMESSO
		FROM vIMPRESA_X_FILIERA
		WHERE 
			((@IdFilieraequalthis IS NULL) OR ID_FILIERA = @IdFilieraequalthis) AND 
			((@Cuaalikethis IS NULL) OR CUAA LIKE @Cuaalikethis) 
		ORDER BY AMMESSO, CUAA
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaXFilieraFindFind';

