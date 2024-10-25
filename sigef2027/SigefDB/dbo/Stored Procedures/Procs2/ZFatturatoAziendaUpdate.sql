CREATE PROCEDURE [dbo].[ZFatturatoAziendaUpdate]
(
	@IdFatturato INT, 
	@IdImpresa INT, 
	@DataModifica DATETIME, 
	@Anno INT, 
	@Aliquota DECIMAL(10,2), 
	@Importo DECIMAL(18,2)
)
AS
	SET @DataModifica=getdate()
	UPDATE FATTURATO_AZIENDA
	SET
		ID_IMPRESA = @IdImpresa, 
		DATA_MODIFICA = @DataModifica, 
		ANNO = @Anno, 
		ALIQUOTA = @Aliquota, 
		IMPORTO = @Importo
	WHERE 
		(ID_FATTURATO = @IdFatturato)
	SELECT @DataModifica;

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFatturatoAziendaUpdate]
(
	@IdFatturato INT, 
	@IdImpresa INT, 
	@IdProdotto INT, 
	@IdUnitaMisura INT, 
	@Anno INT, 
	@MetodoProduzione VARCHAR(50), 
	@QuantitaVenduta DECIMAL(10,2), 
	@PrezzoUnitarioMedio DECIMAL(10,2)
)
AS
	UPDATE FATTURATO_AZIENDA
	SET
		ID_IMPRESA = @IdImpresa, 
		ID_PRODOTTO = @IdProdotto, 
		ID_UNITA_MISURA = @IdUnitaMisura, 
		ANNO = @Anno, 
		METODO_PRODUZIONE = @MetodoProduzione, 
		QUANTITA_VENDUTA = @QuantitaVenduta, 
		PREZZO_UNITARIO_MEDIO = @PrezzoUnitarioMedio
	WHERE 
		(ID_FATTURATO = @IdFatturato)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFatturatoAziendaUpdate';

