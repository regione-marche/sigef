CREATE PROCEDURE [dbo].[ZRnaObiettiviUpdate]
(
	@IdObiettivo INT, 
	@CodiceRegolamento VARCHAR(255), 
	@Regolamento VARCHAR(max), 
	@CodObiettivo VARCHAR(255), 
	@MacroObiettivo VARCHAR(500), 
	@Obiettivo VARCHAR(500)
)
AS
	UPDATE RNA_OBIETTIVI
	SET
		CODICE_REGOLAMENTO = @CodiceRegolamento, 
		REGOLAMENTO = @Regolamento, 
		COD_OBIETTIVO = @CodObiettivo, 
		MACRO_OBIETTIVO = @MacroObiettivo, 
		OBIETTIVO = @Obiettivo
	WHERE 
		(ID_OBIETTIVO = @IdObiettivo)