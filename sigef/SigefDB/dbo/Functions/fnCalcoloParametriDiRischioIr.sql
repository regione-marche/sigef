CREATE FUNCTION [dbo].[fnCalcoloParametriDiRischioIr]
(
	@Id_Domanda_Pagamento   INT
)
RETURNS DECIMAL(5, 2)
AS
BEGIN
    DECLARE @risk DECIMAL(5, 2)
    
    -- Ritorna valore di rischiosita': 0,45 Bassa; 0,65 Media; 1 Alta
    DECLARE @Ir1    INT             = 0,
            @Ir2    INT             = 0,
            @Ir3    INT             = 0,
            @Bassa  DECIMAL(5, 2)   = 0.45,
            @Media  DECIMAL(5, 2)   = 0.65,
            @Alta   DECIMAL(5, 2)   = 1

    -- Ritorna valore di rischiosita': 1 Bassa, 2 Media, 3 Alta
    SELECT @Ir1 = dbo.fnCalcoloParametriDiRischioIR1(@Id_Domanda_Pagamento)
    SELECT @Ir2 = dbo.fnCalcoloParametriDiRischioIR2(@Id_Domanda_Pagamento)
    SELECT @Ir3 = dbo.fnCalcoloParametriDiRischioIR3(@Id_Domanda_Pagamento)

    /* 18/12/17
       Le combinazioni sotto riportate coprono tutte le casistiche
    */

    -- Regione Marche (@Ir1 = 1)
    IF @Ir1 = 1 AND @Ir2 = 1 AND @Ir3 = 1 BEGIN SET @risk = @Bassa END
    IF @Ir1 = 1 AND @Ir2 = 1 AND @Ir3 = 2 BEGIN SET @risk = @Bassa END
    IF @Ir1 = 1 AND @Ir2 = 1 AND @Ir3 = 3 BEGIN SET @risk = @Bassa END
    IF @Ir1 = 1 AND @Ir2 = 2 AND @Ir3 = 1 BEGIN SET @risk = @Bassa END
    IF @Ir1 = 1 AND @Ir2 = 2 AND @Ir3 = 2 BEGIN SET @risk = @Media END
    IF @Ir1 = 1 AND @Ir2 = 2 AND @Ir3 = 3 BEGIN SET @risk = @Media END

    -- Altra amministrazione pubblica (@Ir1 = 2)
    IF @Ir1 = 2 AND @Ir2 = 2 AND @Ir3 = 1 BEGIN SET @risk = @Bassa END
    IF @Ir1 = 2 AND @Ir2 = 2 AND @Ir3 = 2 BEGIN SET @risk = @Media END
    IF @Ir1 = 2 AND @Ir2 = 2 AND @Ir3 = 3 BEGIN SET @risk = @Media END
    IF @Ir1 = 2 AND @Ir2 = 3 AND @Ir3 = 1 BEGIN SET @risk = @Media END
    IF @Ir1 = 2 AND @Ir2 = 3 AND @Ir3 = 2 BEGIN SET @risk = @Media END
    IF @Ir1 = 2 AND @Ir2 = 3 AND @Ir3 = 3 BEGIN SET @risk = @Alta  END

    --  Impresa o altro privato (@Ir1 = 3)
    IF @Ir1 = 3 AND @Ir2 = 3 AND @Ir3 = 1 BEGIN SET @risk = @Media END
    IF @Ir1 = 3 AND @Ir2 = 3 AND @Ir3 = 2 BEGIN SET @risk = @Alta  END
    IF @Ir1 = 3 AND @Ir2 = 3 AND @Ir3 = 3 BEGIN SET @risk = @Alta  END

    RETURN (@risk);
END
