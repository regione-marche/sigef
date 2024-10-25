CREATE PROCEDURE [dbo].[ZZdimensioniFindSelect]
(
	@Idequalthis INT, 
	@Codiceequalthis VARCHAR(255), 
	@CodDimequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(1000), 
	@Metodoequalthis VARCHAR(255), 
	@Valoreequalthis DECIMAL(18,2), 
	@Richiedibileequalthis VARCHAR(255), 
	@Umequalthis VARCHAR(255), 
	@ProceduraCalcoloequalthis VARCHAR(255), 
	@Ordineequalthis INT, 
	@ValoreBaseequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, CODICE, COD_DIM, DESCRIZIONE, METODO, VALORE, RICHIEDIBILE, UM, PROCEDURA_CALCOLO, ORDINE, VALORE_BASE, DES_DIM FROM vzDIMENSIONI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@CodDimequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_DIM = @CodDimequalthis)'; set @lensql=@lensql+len(@CodDimequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Metodoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (METODO = @Metodoequalthis)'; set @lensql=@lensql+len(@Metodoequalthis);end;
	IF (@Valoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE = @Valoreequalthis)'; set @lensql=@lensql+len(@Valoreequalthis);end;
	IF (@Richiedibileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICHIEDIBILE = @Richiedibileequalthis)'; set @lensql=@lensql+len(@Richiedibileequalthis);end;
	IF (@Umequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UM = @Umequalthis)'; set @lensql=@lensql+len(@Umequalthis);end;
	IF (@ProceduraCalcoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROCEDURA_CALCOLO = @ProceduraCalcoloequalthis)'; set @lensql=@lensql+len(@ProceduraCalcoloequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@ValoreBaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_BASE = @ValoreBaseequalthis)'; set @lensql=@lensql+len(@ValoreBaseequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @Codiceequalthis VARCHAR(255), @CodDimequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(1000), @Metodoequalthis VARCHAR(255), @Valoreequalthis DECIMAL(18,2), @Richiedibileequalthis VARCHAR(255), @Umequalthis VARCHAR(255), @ProceduraCalcoloequalthis VARCHAR(255), @Ordineequalthis INT, @ValoreBaseequalthis DECIMAL(18,2)',@Idequalthis , @Codiceequalthis , @CodDimequalthis , @Descrizioneequalthis , @Metodoequalthis , @Valoreequalthis , @Richiedibileequalthis , @Umequalthis , @ProceduraCalcoloequalthis , @Ordineequalthis , @ValoreBaseequalthis ;
	else
		SELECT ID, CODICE, COD_DIM, DESCRIZIONE, METODO, VALORE, RICHIEDIBILE, UM, PROCEDURA_CALCOLO, ORDINE, VALORE_BASE, DES_DIM
		FROM vzDIMENSIONI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@CodDimequalthis IS NULL) OR COD_DIM = @CodDimequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Metodoequalthis IS NULL) OR METODO = @Metodoequalthis) AND 
			((@Valoreequalthis IS NULL) OR VALORE = @Valoreequalthis) AND 
			((@Richiedibileequalthis IS NULL) OR RICHIEDIBILE = @Richiedibileequalthis) AND 
			((@Umequalthis IS NULL) OR UM = @Umequalthis) AND 
			((@ProceduraCalcoloequalthis IS NULL) OR PROCEDURA_CALCOLO = @ProceduraCalcoloequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@ValoreBaseequalthis IS NULL) OR VALORE_BASE = @ValoreBaseequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniFindSelect';

