CREATE PROCEDURE [dbo].[RptLogErroriIGRUE] 
@ID_INVIO INT = NULL
AS
BEGIN	
	
SELECT 
I.ID_INVIO,
I.ID_TICKET,
IV.DATA_INVIO,
logrecord.ref.value('(TipoFile)[1]', 'varchar(30)') AS TipoFile,
logrecord.ref.value('(IdProgetto)[1]', 'varchar(30)') AS IdProgetto,
logrecord.ref.value('(IdBando)[1]', 'varchar(30)') AS IdBando,
logrecord.ref.value('(NumeroRiga)[1]', 'varchar(30)') AS NumeroRiga,
logrecord.ref.value('(CampoTracciato)[1]', 'varchar(30)') AS CampoTracciato,
logrecord.ref.value('(CodiceGruppo)[1]', 'varchar(30)') AS CodiceGruppo,
logrecord.ref.value('(CodiceErrore)[1]', 'varchar(30)') AS CodiceErrore,
logrecord.ref.value('(DescrizioneErrore)[1]', 'varchar(1000)') AS DescrizioneErrore
FROM IGRUE_LOG_ERRORI I
OUTER APPLY I.ISTANZA_ERRORI.nodes('//LogRecord') as logrecord(ref)
INNER JOIN IGRUE_INVIO IV ON
I.ID_INVIO = IV.ID_INVIO
WHERE I.ID_INVIO = @ID_INVIO
		    
END
