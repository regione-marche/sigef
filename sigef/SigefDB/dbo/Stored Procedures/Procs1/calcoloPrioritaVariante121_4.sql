CREATE PROCEDURE [dbo].[calcoloPrioritaVariante121_4]
  @ID_VARIANTE int, @IdProgetto int
AS
BEGIN

-- PRIORITA 86:  121 - investimenti realizzati per i settori prioritari ed in territori preferenziali (zucchero)


 
DECLARE @Punteggio decimal(10,2)
declare @TIPO_AREA_PREVALENTE varchar (2)
DECLARE @ID_FASCICOLO int


  SET @ID_FASCICOLO  =(SELECT ISNULL( ID_FASCICOLO_ENTRANTE, (SELECT   ID_FASCICOLO   FROM  PROGETTO  	 WHERE     (PROGETTO.ID_PROGETTO = @IdProgetto)))
  FROM VARIANTI  WHERE ID_VARIANTE = @ID_VARIANTE)

IF (@ID_FASCICOLO is not null )
BEGIN

SET @TIPO_AREA_PREVALENTE = ( SELECT  top(1)     COMUNI.TIPO_AREA
						FROM   CATASTO_TERRENI INNER JOIN
						COMUNI ON CATASTO_TERRENI.ID_COMUNE = COMUNI.ID_COMUNE
						WHERE     (CATASTO_TERRENI.ID_CATASTO IN
                          (SELECT DISTINCT ID_CATASTO
                            FROM          vTERRITORIO
                            WHERE      (ID_FASCICOLO = @ID_FASCICOLO) and TIPO_AREA is not null))
						GROUP BY COMUNI.TIPO_AREA
						ORDER BY  SUM(CATASTO_TERRENI.SUPERFICIE_CATASTALE) DESC )

-- 1. DETERMINAZIONE DEL TIPO DI AREA CON PIU' INVESTIMENTI
DECLARE @TipoArea varchar(2)
DECLARE @IdSettoreProduttivo int
DECLARE @Costo_Investimento decimal(10,2)
DECLARE @COSTO_INVESTIMENTO_MAX DECIMAL (10,2)
DECLARE @TipoAreaMax varchar(2)
DECLARE @IdSettoreProduttivoMax int

DECLARE TIPO_AREA CURSOR FOR
(
SELECT    PI.ID_SETTORE_PRODUTTIVO, ISNULL(COMUNI.TIPO_AREA, @TIPO_AREA_PREVALENTE)  AS TIPO_AREA, 
	SUM(PI.COSTO_INVESTIMENTO) AS Costo
	FROM  CATASTO_TERRENI INNER JOIN
          LOCALIZZAZIONE_INVESTIMENTO AS LI ON CATASTO_TERRENI.ID_CATASTO = LI.ID_CATASTO INNER JOIN
          COMUNI ON CATASTO_TERRENI.ID_COMUNE = COMUNI.ID_COMUNE RIGHT OUTER JOIN
          PIANO_INVESTIMENTI AS PI ON LI.ID_INVESTIMENTO = PI.ID_INVESTIMENTO  
 WHERE PI.ID_PROGETTO = @IdProgetto  AND PI.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A' 
 and COD_TIPO_INVESTIMENTO =1
 GROUP BY PI.ID_SETTORE_PRODUTTIVO, COMUNI.TIPO_AREA


)

set @COSTO_INVESTIMENTO_MAX=0
OPEN TIPO_AREA
FETCH NEXT FROM TIPO_AREA 
INTO @IdSettoreProduttivo,@TipoArea, @Costo_Investimento
WHILE @@FETCH_STATUS = 0
BEGIN
	
	IF(@Costo_Investimento>(@COSTO_INVESTIMENTO_MAX ))
	BEGIN 
		set @COSTO_INVESTIMENTO_MAX = @Costo_Investimento
		SET @TipoAreaMax = @TipoArea
		SET @IdSettoreProduttivoMaX = @IdSettoreProduttivo
	END
	FETCH NEXT FROM TIPO_AREA
INTO @IdSettoreProduttivo,@TipoArea, @Costo_Investimento
END

CLOSE TIPO_AREA
DEALLOCATE TIPO_AREA 



SET @TipoAreaMax= ISNULL(@TipoAreaMax,@TIPO_AREA_PREVALENTE)
-- 3. ASSEGNAZIONE PUNTEGGIO
IF (@TipoAreaMax IS NULL ) SET @Punteggio = 0
ELSE BEGIN

   -- ORTOFRUTTA Zona A
   IF (@IdSettoreProduttivoMax = 31 AND @TipoAreaMax = 'A') SET @Punteggio = 0.6
   -- ORTOFRUTTA Zona C1
   ELSE IF (@IdSettoreProduttivoMax = 31 AND @TipoAreaMax = 'C1') SET @Punteggio = 1
   -- ORTOFRUTTA Zona C2
   ELSE IF (@IdSettoreProduttivoMax = 31 AND @TipoAreaMax = 'C2') SET @Punteggio = 1
   -- ORTOFRUTTA Zona C3
   ELSE IF (@IdSettoreProduttivoMax = 31 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.6
   -- ORTOFRUTTA Zona D
   ELSE IF (@IdSettoreProduttivoMax = 31 AND @TipoAreaMax = 'D') SET @Punteggio = 0.3

   -- SEMENTIERO Zona A
   ELSE IF (@IdSettoreProduttivoMax = 40 AND @TipoAreaMax = 'A') SET @Punteggio = 0.6
   -- SEMENTIERO Zona C1
   ELSE IF (@IdSettoreProduttivoMax = 40 AND @TipoAreaMax = 'C1') SET @Punteggio = 1
   -- SEMENTIERO Zona C2
   ELSE IF (@IdSettoreProduttivoMax = 40 AND @TipoAreaMax = 'C2') SET @Punteggio = 1
   -- SEMENTIERO Zona C3
   ELSE IF (@IdSettoreProduttivoMax = 40 AND @TipoAreaMax = 'C3') SET @Punteggio = 1
   -- SEMENTIERO Zona D
   ELSE IF (@IdSettoreProduttivoMax = 40 AND @TipoAreaMax = 'D') SET @Punteggio = 0.3

   -- FLOROVIVAISMO Zona A
   ELSE IF (@IdSettoreProduttivoMax = 16 AND @TipoAreaMax = 'A') SET @Punteggio = 1
   -- FLOROVIVAISMO Zona C1
   ELSE IF (@IdSettoreProduttivoMax = 16 AND @TipoAreaMax = 'C1') SET @Punteggio = 1
   -- FLOROVIVAISMO Zona C2
   ELSE IF (@IdSettoreProduttivoMax = 16 AND @TipoAreaMax = 'C2') SET @Punteggio = 1
   -- FLOROVIVAISMO Zona C3
   ELSE IF (@IdSettoreProduttivoMax = 16 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.6
   -- FLOROVIVAISMO Zona D
   ELSE IF (@IdSettoreProduttivoMax = 16 AND @TipoAreaMax = 'D') SET @Punteggio = 0.3

   -- CEREALI Zona A
   ELSE IF (@IdSettoreProduttivoMax = 13 AND @TipoAreaMax = 'A') SET @Punteggio = 0.6
   -- CEREALI Zona C1
   ELSE IF (@IdSettoreProduttivoMax = 13 AND @TipoAreaMax = 'C1') SET @Punteggio = 0.6
   -- CEREALI Zona C2
   ELSE IF (@IdSettoreProduttivoMax = 13 AND @TipoAreaMax = 'C2') SET @Punteggio = 0.6
   -- CEREALI Zona C3
   ELSE IF (@IdSettoreProduttivoMax = 13 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.36
   -- CEREALI Zona D
   ELSE IF (@IdSettoreProduttivoMax = 13 AND @TipoAreaMax = 'D') SET @Punteggio = 0.18

   -- OLEAGINOSE Zona A
   ELSE IF (@IdSettoreProduttivoMax = 24 AND @TipoAreaMax = 'A') SET @Punteggio = 0.6
   -- OLEAGINOSE Zona C1
   ELSE IF (@IdSettoreProduttivoMax = 24 AND @TipoAreaMax = 'C1') SET @Punteggio = 0.6
   -- OLEAGINOSE Zona C2
   ELSE IF (@IdSettoreProduttivoMax = 24 AND @TipoAreaMax = 'C2') SET @Punteggio = 0.6
   -- OLEAGINOSE Zona C3
   ELSE IF (@IdSettoreProduttivoMax = 24 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.36
   -- OLEAGINOSE Zona D
   ELSE IF (@IdSettoreProduttivoMax = 24 AND @TipoAreaMax = 'D') SET @Punteggio = 0.18  

   -- ZOOTECNIA (CARNI BOVINE - CARNI SUINE - AVICOLO - OVINO E CAPRINO) Zona A
   ELSE IF ((@IdSettoreProduttivoMax = 7 OR @IdSettoreProduttivoMax = 11 OR @IdSettoreProduttivoMax = 3 OR @IdSettoreProduttivoMax = 34) AND @TipoAreaMax = 'A') SET @Punteggio = 0.18
   -- ZOOTECNIA (CARNI BOVINE - CARNI SUINE - AVICOLO - OVINO E CAPRINO) Zona C1
   ELSE IF ((@IdSettoreProduttivoMax = 7 OR @IdSettoreProduttivoMax = 11 OR @IdSettoreProduttivoMax = 3 OR @IdSettoreProduttivoMax = 34) AND @TipoAreaMax = 'C1') SET @Punteggio = 0.36
   -- ZOOTECNIA (CARNI BOVINE - CARNI SUINE - AVICOLO - OVINO E CAPRINO) Zona C2
   ELSE IF ((@IdSettoreProduttivoMax = 7 OR @IdSettoreProduttivoMax = 11 OR @IdSettoreProduttivoMax = 3 OR @IdSettoreProduttivoMax = 34) AND @TipoAreaMax = 'C2') SET @Punteggio = 0.36
   -- ZOOTECNIA (CARNI BOVINE - CARNI SUINE - AVICOLO - OVINO E CAPRINO) Zona C3
   ELSE IF ((@IdSettoreProduttivoMax = 7 OR @IdSettoreProduttivoMax = 11 OR @IdSettoreProduttivoMax = 3 OR @IdSettoreProduttivoMax = 34) AND @TipoAreaMax = 'C3') SET @Punteggio = 0.36
   -- ZOOTECNIA (CARNI BOVINE - CARNI SUINE - AVICOLO - OVINO E CAPRINO) Zona D
   ELSE IF ((@IdSettoreProduttivoMax = 7 OR @IdSettoreProduttivoMax = 11 OR @IdSettoreProduttivoMax = 3 OR @IdSettoreProduttivoMax = 34) AND @TipoAreaMax = 'D') SET @Punteggio = 0.60

   -- BIOMASSE Zona A
   ELSE IF (@IdSettoreProduttivoMax = 6 AND @TipoAreaMax = 'A') SET @Punteggio = 0.6
   -- BIOMASSE Zona C1
   ELSE IF (@IdSettoreProduttivoMax = 6 AND @TipoAreaMax = 'C1') SET @Punteggio = 0.6
   -- BIOMASSE Zona C2
   ELSE IF (@IdSettoreProduttivoMax = 6 AND @TipoAreaMax = 'C2') SET @Punteggio = 0.6
   -- BIOMASSE Zona C3
   ELSE IF (@IdSettoreProduttivoMax = 6 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.36
   -- BIOMASSE Zona D
   ELSE IF (@IdSettoreProduttivoMax = 6 AND @TipoAreaMax = 'D') SET @Punteggio = 0.36

   -- PRODUZIONE DI NICCHIA Zona A
   ELSE IF (@IdSettoreProduttivoMax = 37 AND @TipoAreaMax = 'A') SET @Punteggio = 0.36
   -- PRODUZIONE DI NICCHIA Zona C1
   ELSE IF (@IdSettoreProduttivoMax = 37 AND @TipoAreaMax = 'C1') SET @Punteggio = 0.36
   -- PRODUZIONE DI NICCHIA Zona C2
   ELSE IF (@IdSettoreProduttivoMax = 37 AND @TipoAreaMax = 'C2') SET @Punteggio = 0.36
   -- PRODUZIONE DI NICCHIA Zona C3
   ELSE IF (@IdSettoreProduttivoMax = 37 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.36
   -- PRODUZIONE DI NICCHIA Zona D
   ELSE IF (@IdSettoreProduttivoMax = 37 AND @TipoAreaMax = 'D') SET @Punteggio = 0.6

   -- ALTRI SETTORI Zona A
   ELSE IF (@TipoAreaMax = 'A') SET @Punteggio = 0.09
   -- ALTRI SETTORI Zona C1
   ELSE IF (@TipoAreaMax = 'C1') SET @Punteggio = 0.3
   -- ALTRI SETTORI Zona C2
   ELSE IF (@TipoAreaMax = 'C2') SET @Punteggio = 0.3
   -- ALTRI SETTORI Zona C3
   ELSE IF (@TipoAreaMax = 'C3') SET @Punteggio = 0.18
   -- ALTRI SETTORI Zona D
   ELSE IF (@TipoAreaMax = 'D') SET @Punteggio = 0.18

  
   ELSE SET @Punteggio = 0

END
END 
ELSE  SET @Punteggio = 0


SELECT @Punteggio AS PUNTEGGIO
RETURN (@Punteggio * 100)

END
