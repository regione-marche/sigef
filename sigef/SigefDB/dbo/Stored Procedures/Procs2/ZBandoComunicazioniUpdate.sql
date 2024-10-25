CREATE PROCEDURE [dbo].[ZBandoComunicazioniUpdate]
(
	@CodTipo VARCHAR(255), 
	@IdBando INT, 
	@Testo NTEXT, 
	@ModalitaAnticipo NTEXT, 
	@ObblighiBeneficiario NTEXT, 
	@IdAtto INT, 
	@Data DATETIME
)
AS
	UPDATE BANDO_COMUNICAZIONI
	SET
		TESTO = @Testo, 
		MODALITA_ANTICIPO = @ModalitaAnticipo, 
		OBBLIGHI_BENEFICIARIO = @ObblighiBeneficiario, 
		ID_ATTO = @IdAtto, 
		DATA = @Data
	WHERE 
		(COD_TIPO = @CodTipo) AND 
		(ID_BANDO = @IdBando)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoComunicazioniUpdate';

