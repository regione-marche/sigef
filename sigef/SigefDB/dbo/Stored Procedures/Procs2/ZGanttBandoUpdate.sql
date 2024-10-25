
CREATE PROCEDURE [dbo].[ZGanttBandoUpdate]
(
       @ID_GANTT_BANDO int,
       @importo decimal(18,2), 
       @IMPORTO_PREVISTO decimal(18,2), 
       @IMPORTO_FINANZIATO decimal(18,2), 
       @IMPORTO_CERTIFICATO decimal(18,2) ,
       @ID_BANDO_BANDI int
)
AS
       UPDATE GANTT_BANDO
       SET
             IMPORTO=@importo, 
             IMPORTO_PREVISTO=@IMPORTO_PREVISTO, 
             IMPORTO_FINANZIATO=@IMPORTO_FINANZIATO, 
             IMPORTO_CERTIFICATO=@IMPORTO_CERTIFICATO,
             ID_BANDO_BANDI=@ID_BANDO_BANDI
       where ID_BANDO_GANTT=@ID_GANTT_BANDO
