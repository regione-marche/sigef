CREATE PROCEDURE [dbo].[SpVerificaBeneficiarioEntePubblico]
(
	@IdImpresa INT
)

AS

BEGIN

DECLARE @Count INT
DECLARE @Result bit
SELECT @Count = count(*)
from vIMPRESA i 
where i.ID_IMPRESA = @IdImpresa  and 
I.COD_FORMA_GIURIDICA  IN
(
--'1.6',
'2',
'2.1',
'2.2',
'2.3.',
'2.4',
'2.4.10',
'2.4.20',
'2.4.30',
'2.4.40',
'2.4.50',
'2.4.60',
'2.5',
'2.6.10',
'2.6.20',
'2.7',
'2.7.11',
'2.7.12',
'2.7.40',
'2.7.51',
'2.7.52',
'2.7.53',
'2.7.54',
'2.7.55',
'2.7.56',
'2.7.90'
) 

if @Count > 0
	SET @Result = 1
else
	SET @Result = 0

SELECT @Result as RESULT

END


