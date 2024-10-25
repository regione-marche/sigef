CREATE PROCEDURE [dbo].[ZBandoComunicazioniInsert]
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
	INSERT INTO BANDO_COMUNICAZIONI
	(
		COD_TIPO, 
		ID_BANDO, 
		TESTO, 
		MODALITA_ANTICIPO, 
		OBBLIGHI_BENEFICIARIO, 
		ID_ATTO, 
		DATA
	)
	VALUES
	(
		@CodTipo, 
		@IdBando, 
		@Testo, 
		@ModalitaAnticipo, 
		@ObblighiBeneficiario, 
		@IdAtto, 
		@Data
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoComunicazioniInsert';

