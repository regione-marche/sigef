CREATE PROCEDURE [dbo].[calcoloParametriDiRischioIR3]
(
    @ID_DOMANDA_PAGAMENTO   INT
)
AS	
-- Ritorna valore di rischiosita': 1 Bassa, 2 Media, 3 Alta
SELECT dbo.fnCalcoloParametriDiRischioIR3(@ID_DOMANDA_PAGAMENTO);
