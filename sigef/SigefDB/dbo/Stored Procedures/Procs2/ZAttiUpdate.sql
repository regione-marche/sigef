CREATE PROCEDURE [dbo].[ZAttiUpdate]
(
	@IdAtto INT, 
	@Numero INT, 
	@Data DATETIME, 
	@Descrizione VARCHAR(3000), 
	@Servizio VARCHAR(255), 
	@Registro VARCHAR(255), 
	@CodTipo VARCHAR(255), 
	@CodDefinizione VARCHAR(255), 
	@CodOrganoIstituzionale VARCHAR(255), 
	@DataBur DATETIME, 
	@NumeroBur INT, 
	@AwDocnumber VARCHAR(255), 
	@AwDocnumberNuovo INT
)
AS
	UPDATE ATTI
	SET
		NUMERO = @Numero, 
		DATA = @Data, 
		DESCRIZIONE = @Descrizione, 
		SERVIZIO = @Servizio, 
		REGISTRO = @Registro, 
		COD_TIPO = @CodTipo, 
		COD_DEFINIZIONE = @CodDefinizione, 
		COD_ORGANO_ISTITUZIONALE = @CodOrganoIstituzionale, 
		DATA_BUR = @DataBur, 
		NUMERO_BUR = @NumeroBur, 
		AW_DOCNUMBER = @AwDocnumber, 
		AW_DOCNUMBER_NUOVO = @AwDocnumberNuovo
	WHERE 
		(ID_ATTO = @IdAtto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAttiUpdate]
(
	@IdAtto INT, 
	@NumeroAtto VARCHAR(30), 
	@DataAtto DATETIME, 
	@IdTipoAtto INT, 
	@IdDefinizioneAtto INT, 
	@IdOrganoIstituzionale INT, 
	@Descrizione VARCHAR(2000), 
	@AwDocnumber VARCHAR(30), 
	@DataPubBur DATETIME, 
	@NumeroBoll INT, 
	@Servizio VARCHAR(255), 
	@Registro VARCHAR(10)
)
AS
	UPDATE ATTI
	SET
		NUMERO_ATTO = @NumeroAtto, 
		DATA_ATTO = @DataAtto, 
		ID_TIPO_ATTO = @IdTipoAtto, 
		ID_DEFINIZIONE_ATTO = @IdDefinizioneAtto, 
		ID_ORGANO_ISTITUZIONALE = @IdOrganoIstituzionale, 
		DESCRIZIONE = @Descrizione, 
		AW_DOCNUMBER = @AwDocnumber, 
		DATA_PUB_BUR = @DataPubBur, 
		NUMERO_BOLL = @NumeroBoll, 
		SERVIZIO = @Servizio, 
		REGISTRO = @Registro
	WHERE 
		(ID_ATTO = @IdAtto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAttiUpdate';

