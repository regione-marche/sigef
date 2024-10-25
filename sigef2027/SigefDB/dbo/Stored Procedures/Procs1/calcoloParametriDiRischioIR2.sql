CREATE PROCEDURE [dbo].[calcoloParametriDiRischioIR2]
(
    @ID_DOMANDA_PAGAMENTO   INT
)
AS
-- Ritorna valore rischiosita': 1 Bassa, 2 Media, 3 Alta

SELECT dbo.fnCalcoloParametriDiRischioIR2(@ID_DOMANDA_PAGAMENTO);
