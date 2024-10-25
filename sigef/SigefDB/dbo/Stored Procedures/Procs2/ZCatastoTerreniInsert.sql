CREATE PROCEDURE [dbo].[ZCatastoTerreniInsert]
(
	@IdComune INT, 
	@FoglioCatastale VARCHAR(255), 
	@Particella VARCHAR(255), 
	@Sezione VARCHAR(255), 
	@Subalterno VARCHAR(255), 
	@SuperficieCatastale INT, 
	@Svantaggio VARCHAR(255)
)
AS
	INSERT INTO CATASTO_TERRENI
	(
		ID_COMUNE, 
		FOGLIO_CATASTALE, 
		PARTICELLA, 
		SEZIONE, 
		SUBALTERNO, 
		SUPERFICIE_CATASTALE, 
		SVANTAGGIO
	)
	VALUES
	(
		@IdComune, 
		@FoglioCatastale, 
		@Particella, 
		@Sezione, 
		@Subalterno, 
		@SuperficieCatastale, 
		@Svantaggio
	)
	SELECT SCOPE_IDENTITY() AS ID_CATASTO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCatastoTerreniInsert]
(
	@IdComune INT, 
	@FoglioCatastale VARCHAR(255), 
	@Particella VARCHAR(255), 
	@Sezione VARCHAR(255), 
	@Subalterno VARCHAR(255), 
	@SuperficieCatastale INT, 
	@Svantaggio VARCHAR(255)
)
AS
	INSERT INTO CATASTO_TERRENI
	(
		ID_COMUNE, 
		FOGLIO_CATASTALE, 
		PARTICELLA, 
		SEZIONE, 
		SUBALTERNO, 
		SUPERFICIE_CATASTALE, 
		SVANTAGGIO
	)
	VALUES
	(
		@IdComune, 
		@FoglioCatastale, 
		@Particella, 
		@Sezione, 
		@Subalterno, 
		@SuperficieCatastale, 
		@Svantaggio
	)
	SELECT SCOPE_IDENTITY() AS ID_CATASTO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCatastoTerreniInsert';

