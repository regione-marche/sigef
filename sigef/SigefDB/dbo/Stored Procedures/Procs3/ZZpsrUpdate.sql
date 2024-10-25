CREATE PROCEDURE [dbo].[ZZpsrUpdate]
(
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@AnnoDa INT, 
	@AnnoA INT, 
	@ProfonditaAlbero INT, 
	@Cci VARCHAR(255)
)
AS
	UPDATE zPSR
	SET
		DESCRIZIONE = @Descrizione, 
		ANNO_DA = @AnnoDa, 
		ANNO_A = @AnnoA, 
		PROFONDITA_ALBERO = @ProfonditaAlbero, 
		CCI = @Cci
	WHERE 
		(CODICE = @Codice)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZpsrUpdate]
(
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@AnnoDa INT, 
	@AnnoA INT, 
	@ProfonditaAlbero INT
)
AS
	UPDATE zPSR
	SET
		DESCRIZIONE = @Descrizione, 
		ANNO_DA = @AnnoDa, 
		ANNO_A = @AnnoA, 
		PROFONDITA_ALBERO = @ProfonditaAlbero
	WHERE 
		(CODICE = @Codice)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZpsrUpdate';

