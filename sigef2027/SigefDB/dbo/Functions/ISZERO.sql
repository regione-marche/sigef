-- =============================================

CREATE FUNCTION [dbo].[ISZERO] 
(
	@IMPORTO DECIMAL(15,2)
)
RETURNS DECIMAL(15,2)
AS
BEGIN
IF @IMPORTO=0 SET @IMPORTO=NULL
RETURN @IMPORTO
END
