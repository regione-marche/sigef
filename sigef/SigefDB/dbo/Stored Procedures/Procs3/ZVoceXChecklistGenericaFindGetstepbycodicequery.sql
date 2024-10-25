﻿CREATE PROCEDURE [dbo].[ZVoceXChecklistGenericaFindGetstepbycodicequery]
(
	@QuerySqllikethis VARCHAR(8000)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VOCE_X_CHECKLIST_GENERICA, ID_CHECKLIST_GENERICA, ID_VOCE_GENERICA, ORDINE, OBBLIGATORIO, PESO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, MISURA, COD_FASE, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, DESCRIZIONE_CHECKLIST_GENERICA, FLAG_TEMPLATE, VAL_ESITO_NEGATIVO FROM VVOCE_X_CHECKLIST_GENERICA WHERE 1=1';
	IF (@QuerySqllikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_SQL LIKE @QuerySqllikethis)'; set @lensql=@lensql+len(@QuerySqllikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@QuerySqllikethis VARCHAR(8000)',@QuerySqllikethis ;
	else
		SELECT ID_VOCE_X_CHECKLIST_GENERICA, ID_CHECKLIST_GENERICA, ID_VOCE_GENERICA, ORDINE, OBBLIGATORIO, PESO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, MISURA, COD_FASE, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, DESCRIZIONE_CHECKLIST_GENERICA, FLAG_TEMPLATE, VAL_ESITO_NEGATIVO
		FROM VVOCE_X_CHECKLIST_GENERICA
		WHERE 
			((@QuerySqllikethis IS NULL) OR QUERY_SQL LIKE @QuerySqllikethis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceXChecklistGenericaFindGetstepbycodicequery';

