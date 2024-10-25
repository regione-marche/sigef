--- Rispetto delle tipologie di intervento ammissibile
--- la tipogia di intervento di cui al punto 3) del pg.2
--- del bando è ammissibile esclusivamente in relazione
--- all`attivazione dell`intervento di cui al punto 1)

CREATE PROCEDURE [dbo].[calcoloStep4132_MONF]
@IdProgetto int, 
@FASE_ISTRUTTORIA INT = 0
AS
BEGIN

DECLARE @result int , @I1 int,  @I3 int
SET @result = 0

--SELECT @I1 = (SELECT count(vpi.id_investimento) FROM PROGETTO P INNER JOIN vPIANO_INVESTIMENTI VPI ON (P.ID_PROGETTO=VPI.ID_PROGETTO) WHERE  VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL AND VPI.COD_TIPO_INVESTIMENTO = 1 AND  VPI.CODICE = 'I1' AND (P.ID_PROGETTO=@IdProgetto))

SELECT @I3 = (SELECT count(vpi.id_investimento) FROM PROGETTO P INNER JOIN vPIANO_INVESTIMENTI VPI ON (P.ID_PROGETTO=VPI.ID_PROGETTO) WHERE
	VPI.COD_TIPO_INVESTIMENTO = 1 AND
	VPI.CODICE = 'I3' AND --- da qui parte per presentazione ed ammissibilità
	(
	(@FASE_ISTRUTTORIA=0 AND VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)
		OR
	(@FASE_ISTRUTTORIA=1 AND VPI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)
	) AND 
	(P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto))


if(@I3 > 0) begin
	SELECT @I1 = (SELECT count(vpi.id_investimento) FROM PROGETTO P INNER JOIN vPIANO_INVESTIMENTI VPI ON (P.ID_PROGETTO=VPI.ID_PROGETTO) WHERE
	VPI.COD_TIPO_INVESTIMENTO = 1 AND
	VPI.CODICE = 'I1' AND --- da qui parte per presentazione ed ammissibilità
	(
	(@FASE_ISTRUTTORIA=0 AND VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)
		OR
	(@FASE_ISTRUTTORIA=1 AND VPI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)
	) AND 
	(P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto))

if(@I1 > 0)set @result =1
	else set @result =0
end
	SELECT @result AS RESULT
END
