CREATE PROCEDURE [dbo].[calcoloParametriDiRischioIR1]
(
    @ID_DOMANDA_PAGAMENTO   INT
)
AS
-- Ritonra valore rischiosita': 1 Bassa, 2 Media, 3 Alta
SELECT dbo.fnCalcoloParametriDiRischioIR1(@ID_DOMANDA_PAGAMENTO);