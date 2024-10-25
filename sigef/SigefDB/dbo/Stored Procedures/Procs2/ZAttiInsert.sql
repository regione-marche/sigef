CREATE PROCEDURE [dbo].[ZAttiInsert]
(
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
	INSERT INTO ATTI
	(
		NUMERO, 
		DATA, 
		DESCRIZIONE, 
		SERVIZIO, 
		REGISTRO, 
		COD_TIPO, 
		COD_DEFINIZIONE, 
		COD_ORGANO_ISTITUZIONALE, 
		DATA_BUR, 
		NUMERO_BUR, 
		AW_DOCNUMBER, 
		AW_DOCNUMBER_NUOVO
	)
	VALUES
	(
		@Numero, 
		@Data, 
		@Descrizione, 
		@Servizio, 
		@Registro, 
		@CodTipo, 
		@CodDefinizione, 
		@CodOrganoIstituzionale, 
		@DataBur, 
		@NumeroBur, 
		@AwDocnumber, 
		@AwDocnumberNuovo
	)
	SELECT SCOPE_IDENTITY() AS ID_ATTO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAttiInsert]
(
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
	INSERT INTO ATTI
	(
		NUMERO_ATTO, 
		DATA_ATTO, 
		ID_TIPO_ATTO, 
		ID_DEFINIZIONE_ATTO, 
		ID_ORGANO_ISTITUZIONALE, 
		DESCRIZIONE, 
		AW_DOCNUMBER, 
		DATA_PUB_BUR, 
		NUMERO_BOLL, 
		SERVIZIO, 
		REGISTRO
	)
	VALUES
	(
		@NumeroAtto, 
		@DataAtto, 
		@IdTipoAtto, 
		@IdDefinizioneAtto, 
		@IdOrganoIstituzionale, 
		@Descrizione, 
		@AwDocnumber, 
		@DataPubBur, 
		@NumeroBoll, 
		@Servizio, 
		@Registro
	)
	SELECT SCOPE_IDENTITY() AS ID_ATTO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAttiInsert';

