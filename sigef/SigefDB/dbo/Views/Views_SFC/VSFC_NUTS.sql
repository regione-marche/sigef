﻿CREATE VIEW VSFC_NUTS
AS
SELECT PROV.*, COD.COD_NUTS AS COD_NUTS, NUT.VAL_NUTS 
FROM PROVINCE PROV
	LEFT JOIN SFC_NUTS NUT ON PROV.CODICE = NUT.COD_PROVINCIA 
	LEFT JOIN COD_TIPO_NUTS COD ON NUT.COD_NUTS = COD.ID_COD_NUTS

GO