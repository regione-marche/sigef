CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIrInsert]
(
	@CodicePsr VARCHAR(255), 
	@IdDimensione INT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@ValoreBase DECIMAL(18,2), 
	@ValoreObbiettivo DECIMAL(18,2), 
	@ValoreRealizzato DECIMAL(18,2), 
	@Um VARCHAR(255), 
	@CodiceObmisura VARCHAR(255)
)
AS
	INSERT INTO zDIMENSIONI_ESTRAZIONI_IR
	(
		CODICE_PSR, 
		ID_DIMENSIONE, 
		DATA_INIZIO, 
		DATA_FINE, 
		VALORE_BASE, 
		VALORE_OBBIETTIVO, 
		VALORE_REALIZZATO, 
		UM, 
		CODICE_OBMISURA
	)
	VALUES
	(
		@CodicePsr, 
		@IdDimensione, 
		@DataInizio, 
		@DataFine, 
		@ValoreBase, 
		@ValoreObbiettivo, 
		@ValoreRealizzato, 
		@Um, 
		@CodiceObmisura
	)
	SELECT SCOPE_IDENTITY() AS ID_ESTRAZIONE_IR


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIrInsert]
(
	@CodicePsr VARCHAR(255), 
	@IdDimensione INT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@ValoreBase DECIMAL(18,2), 
	@ValoreObbiettivo DECIMAL(18,2), 
	@ValoreRealizzato DECIMAL(18,2), 
	@Um VARCHAR(255), 
	@CodiceObmisura VARCHAR(255)
)
AS
	INSERT INTO zDIMENSIONI_ESTRAZIONI_IR
	(
		CODICE_PSR, 
		ID_DIMENSIONE, 
		DATA_INIZIO, 
		DATA_FINE, 
		VALORE_BASE, 
		VALORE_OBBIETTIVO, 
		VALORE_REALIZZATO, 
		UM, 
		CODICE_OBMISURA
	)
	VALUES
	(
		@CodicePsr, 
		@IdDimensione, 
		@DataInizio, 
		@DataFine, 
		@ValoreBase, 
		@ValoreObbiettivo, 
		@ValoreRealizzato, 
		@Um, 
		@CodiceObmisura
	)
	SELECT SCOPE_IDENTITY() AS ID_ESTRAZIONE_IR

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIrInsert';

