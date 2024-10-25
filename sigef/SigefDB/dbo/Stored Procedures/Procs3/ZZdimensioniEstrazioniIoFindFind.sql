CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoFindFind]
(
	@CodPsrequalthis VARCHAR(255), 
	@Annoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_PSR, ID_DIM_PRIORITA, CodPriorita, DesPriorita, OrdPriorita, ID_DIM_INDICATORE, CodIndicatore, DesIndicatore, OrdIndicatore, VALORE_RTOT, VALORE_PF, DATA_PF, VALORE_F, DATA_F, ID_ESTRAZIONE, DATA_ESTRAZIONE, UM, ID_ESTRAZIONE_IO, BLOCCATO, ANNO FROM vzDIMENSIONI_ESTRAZIONI_IO WHERE 1=1';
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodPsrequalthis VARCHAR(255), @Annoequalthis INT',@CodPsrequalthis , @Annoequalthis ;
	else
		SELECT COD_PSR, ID_DIM_PRIORITA, CodPriorita, DesPriorita, OrdPriorita, ID_DIM_INDICATORE, CodIndicatore, DesIndicatore, OrdIndicatore, VALORE_RTOT, VALORE_PF, DATA_PF, VALORE_F, DATA_F, ID_ESTRAZIONE, DATA_ESTRAZIONE, UM, ID_ESTRAZIONE_IO, BLOCCATO, ANNO
		FROM vzDIMENSIONI_ESTRAZIONI_IO
		WHERE 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIoFindFind';

