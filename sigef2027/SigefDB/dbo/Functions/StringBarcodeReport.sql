-- Viene utilizzata nel report dell'elenco di pagamento per mettere in un unica stringa i barcode di un progetto 
-- multimisura.
create FUNCTION [dbo].[StringBarcodeReport]
(
    @id_domanda_pagamento int
)
RETURNS varchar(Max)
AS
BEGIN
 
    DECLARE @result varchar(max)
 
    SELECT    @result = coalesce(@result + ' ', '') + barcode
    FROM    domanda_di_pagamento_esportazione
    WHERE    id_domanda_pagamento  = @id_domanda_pagamento
    
    RETURN @Result
END
