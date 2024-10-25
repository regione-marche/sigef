﻿
CREATE VIEW [dbo].[vzDIMENSIONI_VALPROGRAMMATO]
AS
SELECT        TOP (100) PERCENT ID_DIM_PRIORITA, ID_DIM_INDICATORE, MAX(CASE TIPO WHEN 'F' THEN NULL ELSE VALORE END) AS VALORE_PF, 
                         MAX(CASE TIPO WHEN 'F' THEN VALORE ELSE NULL END) AS VALORE_F, MAX(CASE TIPO WHEN 'F' THEN NULL ELSE DATA_RIF END) AS DATA_PF, 
                         MAX(CASE TIPO WHEN 'F' THEN DATA_RIF ELSE NULL END) AS DATA_F
FROM            dbo.[zDIMENSIONI_VALPROGRAMMATI]
GROUP BY ID_DIM_PRIORITA, ID_DIM_INDICATORE

