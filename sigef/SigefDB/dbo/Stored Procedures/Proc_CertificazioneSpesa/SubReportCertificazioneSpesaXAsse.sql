-- DROP PROCEDURE SubReportCertificazioneSpesaXAsse;
CREATE PROCEDURE SubReportCertificazioneSpesaXAsse
(
	@dataLotto		DATETIME,
	@codPsr			VARCHAR(100),
	@soloDefinitivi BIT,
	@complessivi	BIT
)
AS
	/*
	DECLARE @dataFine		DATETIME;
	DECLARE @dataLotto		DATETIME;
	DECLARE @codPsr			VARCHAR(100);
	DECLARE @soloDefinitivi BIT; 
	DECLARE @complessivi	BIT; 

	--SET @dataFine		= '20140101';
	SET @dataLotto		= '20181219';
	SET @codPsr			= 'POR20142020';
	SET @soloDefinitivi = 1;
	SET @complessivi	= 1;
	*/
	DECLARE @dataFine		DATETIME;

	IF (@complessivi IS NOT NULL AND @complessivi = 1)
		SET @dataFine = (SELECT ISNULL(MIN(DataInizio), '20131231')
							 FROM CertSp_Testa 
							WHERE Definitivo = 1);
	ELSE 
		SET @dataFine = ( SELECT TOP 1 DataFine
							FROM CertSp_Testa
							WHERE 1 = 1
								AND Tipo = 'F'
								AND CONVERT(Varchar(8), DataFine, 112) < @DataLotto
							ORDER BY DataFine DESC )

	SELECT  Asse,
		'Pubblico' AS BaseCalcolo,
		SUM(ISNULL(ImportoContributoPubblico_Incrementale, 0))  AS ImportoContributo,
		SUM(ISNULL(SpesaAmmessa, 0))                            AS ImportoRendicontato
	FROM vCertSp_Dettaglio
	WHERE 1 = 1
		AND DataFine    >  @dataFine
		AND DataFine    <= @dataLotto
		AND ((@soloDefinitivi IS NULL OR @soloDefinitivi = 0)
			OR (@soloDefinitivi = 1 AND Definitivo  =  'TRUE'))
		AND Selezionata =  'TRUE'
		AND CodPsr      =  @codPsr
	GROUP BY Asse

-- EXEC SubReportCertificazioneSpesaXAsse '20181219', 'POR20142020', 1, 1
-- EXEC SubReportCertificazioneSpesaXAsse @dataLotto, @codPsr, @soloDefinitivi, @complessivi