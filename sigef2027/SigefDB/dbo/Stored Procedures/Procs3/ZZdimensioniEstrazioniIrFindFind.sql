CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIrFindFind]
(
	@CodicePsrequalthis VARCHAR(255), 
	@Annoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ESTRAZIONE_IR, CODICE_PSR, ID_DIMENSIONE, DATA_INIZIO, DATA_FINE, VALORE_BASE, VALORE_OBBIETTIVO, VALORE_REALIZZATO, UM, CODICE_OBMISURA, DIMENSIONE_CODICE, DIMENSIONE_DESCRIZIONE, DIMENSIONE_ORDINE, ANNO FROM vzDIMENSIONI_ESTRAZIONI_IR WHERE 1=1';
	IF (@CodicePsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_PSR = @CodicePsrequalthis)'; set @lensql=@lensql+len(@CodicePsrequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodicePsrequalthis VARCHAR(255), @Annoequalthis INT',@CodicePsrequalthis , @Annoequalthis ;
	else
		SELECT ID_ESTRAZIONE_IR, CODICE_PSR, ID_DIMENSIONE, DATA_INIZIO, DATA_FINE, VALORE_BASE, VALORE_OBBIETTIVO, VALORE_REALIZZATO, UM, CODICE_OBMISURA, DIMENSIONE_CODICE, DIMENSIONE_DESCRIZIONE, DIMENSIONE_ORDINE, ANNO
		FROM vzDIMENSIONI_ESTRAZIONI_IR
		WHERE 
			((@CodicePsrequalthis IS NULL) OR CODICE_PSR = @CodicePsrequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIrFindFind]
(
	@CodicePsrequalthis VARCHAR(255), 
	@Annoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ESTRAZIONE_IR, CODICE_PSR, ID_DIMENSIONE, DATA_INIZIO, DATA_FINE, VALORE_BASE, VALORE_OBBIETTIVO, VALORE_REALIZZATO, UM, CODICE_OBMISURA, DIMENSIONE_CODICE, DIMENSIONE_DESCRIZIONE, DIMENSIONE_ORDINE, ANNO FROM vzDIMENSIONI_ESTRAZIONI_IR WHERE 1=1'';
	IF (@CodicePsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE_PSR = @CodicePsrequalthis)''; set @lensql=@lensql+len(@CodicePsrequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNO = @Annoequalthis)''; set @lensql=@lensql+len(@Annoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@CodicePsrequalthis VARCHAR(255), @Annoequalthis INT'',@CodicePsrequalthis , @Annoequalthis ;
	else
		SELECT ID_ESTRAZIONE_IR, CODICE_PSR, ID_DIMENSIONE, DATA_INIZIO, DATA_FINE, VALORE_BASE, VALORE_OBBIETTIVO, VALORE_REALIZZATO, UM, CODICE_OBMISURA, DIMENSIONE_CODICE, DIMENSIONE_DESCRIZIONE, DIMENSIONE_ORDINE, ANNO
		FROM vzDIMENSIONI_ESTRAZIONI_IR
		WHERE 
			((@CodicePsrequalthis IS NULL) OR CODICE_PSR = @CodicePsrequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIrFindFind';

