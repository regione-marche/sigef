CREATE PROCEDURE [dbo].[ZCatastoTerreniUpdate]
(
	@IdCatasto INT, 
	@IdComune INT, 
	@FoglioCatastale VARCHAR(255), 
	@Particella VARCHAR(255), 
	@Sezione VARCHAR(255), 
	@Subalterno VARCHAR(255), 
	@SuperficieCatastale INT, 
	@Svantaggio VARCHAR(255)
)
AS
	UPDATE CATASTO_TERRENI
	SET
		ID_COMUNE = @IdComune, 
		FOGLIO_CATASTALE = @FoglioCatastale, 
		PARTICELLA = @Particella, 
		SEZIONE = @Sezione, 
		SUBALTERNO = @Subalterno, 
		SUPERFICIE_CATASTALE = @SuperficieCatastale, 
		SVANTAGGIO = @Svantaggio
	WHERE 
		(ID_CATASTO = @IdCatasto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCatastoTerreniUpdate]
(
	@IdCatasto INT, 
	@IdComune INT, 
	@FoglioCatastale VARCHAR(255), 
	@Particella VARCHAR(255), 
	@Sezione VARCHAR(255), 
	@Subalterno VARCHAR(255), 
	@SuperficieCatastale INT, 
	@Svantaggio VARCHAR(255)
)
AS
	UPDATE CATASTO_TERRENI
	SET
		ID_COMUNE = @IdComune, 
		FOGLIO_CATASTALE = @FoglioCatastale, 
		PARTICELLA = @Particella, 
		SEZIONE = @Sezione, 
		SUBALTERNO = @Subalterno, 
		SUPERFICIE_CATASTALE = @SuperficieCatastale, 
		SVANTAGGIO = @Svantaggio
	WHERE 
		(ID_CATASTO = @IdCatasto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCatastoTerreniUpdate';

