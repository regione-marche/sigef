CREATE PROCEDURE [dbo].[ZRnaObiettiviInsert]
(
	@CodiceRegolamento VARCHAR(255), 
	@Regolamento VARCHAR(max), 
	@CodObiettivo VARCHAR(255), 
	@MacroObiettivo VARCHAR(500), 
	@Obiettivo VARCHAR(500)
)
AS
	INSERT INTO RNA_OBIETTIVI
	(
		CODICE_REGOLAMENTO, 
		REGOLAMENTO, 
		COD_OBIETTIVO, 
		MACRO_OBIETTIVO, 
		OBIETTIVO
	)
	VALUES
	(
		@CodiceRegolamento, 
		@Regolamento, 
		@CodObiettivo, 
		@MacroObiettivo, 
		@Obiettivo
	)
	SELECT SCOPE_IDENTITY() AS ID_OBIETTIVO