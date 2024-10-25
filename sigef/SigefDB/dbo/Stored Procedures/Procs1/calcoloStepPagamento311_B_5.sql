﻿--311 b - Progetto con spesa per investimento + spese tecniche > a € 1.300.000,00 e presenza di impianti fotovoltaici

CREATE    PROCEDURE [dbo].[calcoloStepPagamento311_B_5]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN
 
DECLARE @result INT, @COSTO_INVESTIMENTO DECIMAL (18,2), @count int, @IdProgetto int
SET @result =1
SET @IdProgetto = ( SELECT ID_PROGETTO FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO= @ID_DOMANDA_PAGAMENTO )


SET @COSTO_INVESTIMENTO = (SELECT       SUM(ISNULL( PR.IMPORTO_AMMESSO,PR.IMPORTO_RICHIESTO )) AS SPESA  
			FROM         PAGAMENTI_BENEFICIARIO AS PB INNER JOIN
								  PAGAMENTI_RICHIESTI AS PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO INNER JOIN
								  PIANO_INVESTIMENTI ON PR.ID_INVESTIMENTO = PIANO_INVESTIMENTI.ID_INVESTIMENTO
			WHERE     (PR.ID_DOMANDA_PAGAMENTO IN
									  (SELECT     ID_DOMANDA_PAGAMENTO
										FROM          DOMANDA_DI_PAGAMENTO
										WHERE      (APPROVATA = 1) AND (ID_PROGETTO = @IdProgetto) AND (ANNULLATA = 0) OR
															   (ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO)))
			 	 )

 
 
IF(@COSTO_INVESTIMENTO >1300000 )
begin 			 
set @count = (     SELECT       COUNT(*)
								FROM         PAGAMENTI_BENEFICIARIO AS PB INNER JOIN
													  PAGAMENTI_RICHIESTI AS PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO INNER JOIN
													  PIANO_INVESTIMENTI ON PR.ID_INVESTIMENTO = PIANO_INVESTIMENTI.ID_INVESTIMENTO
								WHERE     (PR.ID_DOMANDA_PAGAMENTO IN
														  (SELECT     ID_DOMANDA_PAGAMENTO
															FROM          DOMANDA_DI_PAGAMENTO
										WHERE      (APPROVATA = 1) AND (ID_PROGETTO = @IdProgetto) AND (ANNULLATA = 0) OR
															   (ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO))) AND  (ISNULL( PR.IMPORTO_AMMESSO,PR.IMPORTO_RICHIESTO ) >0 )
								GROUP BY  PIANO_INVESTIMENTI.ID_CODIFICA_INVESTIMENTO
								HAVING  PIANO_INVESTIMENTI.ID_CODIFICA_INVESTIMENTO  =234)
IF(@count>0)
		set @result =0
end 
SELECT @result AS RESULT

END
