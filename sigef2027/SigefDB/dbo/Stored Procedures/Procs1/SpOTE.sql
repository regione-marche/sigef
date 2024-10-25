CREATE PROCEDURE [dbo].[SpOTE]
  -- Identificativo fascicolo di riferimento
  @IdFascicolo int
  -- se 1 salva OTE in dbo.FASCICOLO_AZIENDALE.OTE
 , @save bit
AS
BEGIN

DECLARE @Fote varchar(50), @OTE char(4)

SET @Fote = dbo.OTE(@IdFascicolo)

IF len(@Fote) > 4
BEGIN
  -- c'è un errore
  DECLARE @MSG VARCHAR(255)
  SET @MSG = SUBSTRING(@Fote,5,len(@Fote) - 4)
  RAISERROR(@MSG,16,1)
  SET @OTE = ''
END ELSE BEGIN
  SET @OTE = @Fote
  IF @save = 1
    UPDATE FASCICOLO_AZIENDALE 
    SET OTE = @OTE
    WHERE ID_FASCICOLO = @IdFascicolo
END

RETURN ISNULL(@OTE,0)

END
