﻿CREATE VIEW VSFC_POP_COMUNI
AS
SELECT COM.*, POP.COD_TERRITORIO
FROM COMUNI COM
	LEFT JOIN SFC_POP_COMUNI POP ON COM.ID_COMUNE = POP.ID_COMUNE

GO
