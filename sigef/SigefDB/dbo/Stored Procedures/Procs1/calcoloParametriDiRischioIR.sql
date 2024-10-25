CREATE PROCEDURE [dbo].[calcoloParametriDiRischioIR]
(
    @Id_Domanda_Pagamento   INT
)
AS	
-- Ritorna valore di rischiosita': 0,45 Bassa; 0,65 Media; 1 Alta
SELECT dbo.fnCalcoloParametriDiRischioIR(@Id_Domanda_Pagamento);