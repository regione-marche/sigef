
CREATE PROCEDURE [dbo].[zCertRendicontazione]
( 
 @DataDa DATETIME,
 @DataA DATETIME
)
AS
BEGIN

SELECT 
* 
FROM 
vCertRendicontazione vcr
where 
vcr.Data_VerDocum between @DataDa and @DataA



END

