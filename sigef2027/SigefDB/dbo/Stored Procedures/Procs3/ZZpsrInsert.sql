CREATE PROCEDURE [dbo].[ZZpsrInsert]
(
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@AnnoDa INT, 
	@AnnoA INT, 
	@ProfonditaAlbero INT, 
	@Cci VARCHAR(255)
)
AS
	INSERT INTO zPSR
	(
		CODICE, 
		DESCRIZIONE, 
		ANNO_DA, 
		ANNO_A, 
		PROFONDITA_ALBERO, 
		CCI
	)
	VALUES
	(
		@Codice, 
		@Descrizione, 
		@AnnoDa, 
		@AnnoA, 
		@ProfonditaAlbero, 
		@Cci
	)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZpsrInsert]
(
	@Codice VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@AnnoDa INT, 
	@AnnoA INT, 
	@ProfonditaAlbero INT
)
AS
	INSERT INTO zPSR
	(
		CODICE, 
		DESCRIZIONE, 
		ANNO_DA, 
		ANNO_A, 
		PROFONDITA_ALBERO
	)
	VALUES
	(
		@Codice, 
		@Descrizione, 
		@AnnoDa, 
		@AnnoA, 
		@ProfonditaAlbero
	)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZpsrInsert';

