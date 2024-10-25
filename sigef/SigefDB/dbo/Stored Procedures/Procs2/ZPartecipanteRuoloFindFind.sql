CREATE PROCEDURE [dbo].[ZPartecipanteRuoloFindFind]
(
	@Cuaaequalthis VARCHAR(16), 
	@IdProgettoPifequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PARTCIPANTE_RUOLO, COD_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, OPERATORE_INSERIMENTO, DATA_MODIFICA, RUOLO_OPERATIVO, RUOLO_SITRA, ID_PROGETTO_PIF, SISTEMA_DI_QUALITA, COD_SISTEMA_QUALITA FROM vPARTECIPANTE_RUOLO WHERE 1=1';
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@IdProgettoPifequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_PIF = @IdProgettoPifequalthis)'; set @lensql=@lensql+len(@IdProgettoPifequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Cuaaequalthis VARCHAR(16), @IdProgettoPifequalthis INT',@Cuaaequalthis , @IdProgettoPifequalthis ;
	else
		SELECT ID_PARTCIPANTE_RUOLO, COD_FILIERA, CUAA, FLAG_PARTECIPANTE, COD_RUOLO_SITRA, COD_RUOLO_PARTECIPANTE, OPERATORE_INSERIMENTO, DATA_MODIFICA, RUOLO_OPERATIVO, RUOLO_SITRA, ID_PROGETTO_PIF, SISTEMA_DI_QUALITA, COD_SISTEMA_QUALITA
		FROM vPARTECIPANTE_RUOLO
		WHERE 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@IdProgettoPifequalthis IS NULL) OR ID_PROGETTO_PIF = @IdProgettoPifequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipanteRuoloFindFind';

