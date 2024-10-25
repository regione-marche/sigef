CREATE PROCEDURE [dbo].[ZFatturatoAziendaInsert]
(
	@IdImpresa INT, 
	@DataModifica DATETIME, 
	@Anno INT, 
	@Aliquota DECIMAL(10,2), 
	@Importo DECIMAL(18,2)
)
AS
	INSERT INTO FATTURATO_AZIENDA
	(
		ID_IMPRESA, 
		DATA_MODIFICA, 
		ANNO, 
		ALIQUOTA, 
		IMPORTO
	)
	VALUES
	(
		@IdImpresa, 
		@DataModifica, 
		@Anno, 
		@Aliquota, 
		@Importo
	)
	SELECT SCOPE_IDENTITY() AS ID_FATTURATO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFatturatoAziendaInsert]
(
	@IdImpresa INT, 
	@IdProdotto INT, 
	@IdUnitaMisura INT, 
	@Anno INT, 
	@MetodoProduzione VARCHAR(50), 
	@QuantitaVenduta DECIMAL(10,2), 
	@PrezzoUnitarioMedio DECIMAL(10,2)
)
AS
	INSERT INTO FATTURATO_AZIENDA
	(
		ID_IMPRESA, 
		ID_PRODOTTO, 
		ID_UNITA_MISURA, 
		ANNO, 
		METODO_PRODUZIONE, 
		QUANTITA_VENDUTA, 
		PREZZO_UNITARIO_MEDIO
	)
	VALUES
	(
		@IdImpresa, 
		@IdProdotto, 
		@IdUnitaMisura, 
		@Anno, 
		@MetodoProduzione, 
		@QuantitaVenduta, 
		@PrezzoUnitarioMedio
	)
	SELECT SCOPE_IDENTITY() AS ID_FATTURATO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFatturatoAziendaInsert';

