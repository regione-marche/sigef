﻿CREATE PROCEDURE [dbo].[calcoloPrioritaVariante112_121_2]
@ID_VARIANTE int, @ID_PROG_CORRENTE INT --   @ID_PROG_CORRENTE PER LA 121 è L'ID PROGETTO PER IL MULTIMISURA è L'ID PROGETTO INTEGRATO
AS
BEGIN

-- 121 - investimenti realizzati per i settori prioritari ed in territori preferenziali

 
DECLARE @Punteggio decimal(10,2)
declare @TIPO_AREA_PREVALENTE varchar (2)
DECLARE @ID_FASCICOLO int, @IdProgetto INT 

SET @IdProgetto = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE)

  SET @ID_FASCICOLO  =(SELECT ISNULL( ID_FASCICOLO_ENTRANTE, (SELECT   ID_FASCICOLO   FROM  PROGETTO  	 WHERE     (PROGETTO.ID_PROGETTO = @IdProgetto)))
  FROM VARIANTI  WHERE ID_VARIANTE = @ID_VARIANTE)
 

IF (@ID_FASCICOLO is not null )
BEGIN

SET @TIPO_AREA_PREVALENTE = (SELECT  top(1) COMUNI.TIPO_AREA
							FROM CATASTO_TERRENI INNER JOIN
								COMUNI ON CATASTO_TERRENI.ID_COMUNE = COMUNI.ID_COMUNE
							WHERE (CATASTO_TERRENI.ID_CATASTO IN 
									(SELECT DISTINCT ID_CATASTO FROM vTERRITORIO WHERE (ID_FASCICOLO = @ID_FASCICOLO)AND TIPO_AREA is not null))
						GROUP BY COMUNI.TIPO_AREA
						ORDER BY  SUM(CATASTO_TERRENI.SUPERFICIE_CATASTALE) DESC )

-- 1. DETERMINAZIONE DEL TIPO DI AREA CON PIU' INVESTIMENTI
DECLARE @TipoArea varchar(2)
DECLARE @IdSettoreProduttivo int
DECLARE @Costo_Investimento decimal(10,2)
DECLARE @COSTO_INVESTIMENTO_MAX DECIMAL (10,2)
DECLARE @TipoAreaMax varchar(2)
DECLARE @IdSettoreProduttivoMax int

-- Modifica per settore produttivo OVINO - CAPRINO

DECLARE TIPO_AREA CURSOR FOR(
SELECT ID_SETTORE_PRODUTTIVO, TIPO_AREA,  sum(Costo)
FROM(SELECT SUM(PI.COSTO_INVESTIMENTO) AS Costo, ISNULL(vComuni.TIPO_AREA, @TIPO_AREA_PREVALENTE)  AS TIPO_AREA ,   'ID_SETTORE_PRODUTTIVO' = 
		CASE when PI.ID_SETTORE_PRODUTTIVO = 216 THEN 20
			else PI.ID_SETTORE_PRODUTTIVO
		END 
	FROM CATASTO_TERRENI INNER JOIN
		(SELECT ID_LOCALIZZAZIONE, ID_INVESTIMENTO, ID_CATASTO FROM LOCALIZZAZIONE_INVESTIMENTO
         WHERE (ID_LOCALIZZAZIONE IN(	SELECT MAX(LOCALIZZAZIONE_INVESTIMENTO_1.ID_LOCALIZZAZIONE) AS ID_LOCALIZZAZIONE
										FROM PIANO_INVESTIMENTI INNER JOIN
											LOCALIZZAZIONE_INVESTIMENTO AS LOCALIZZAZIONE_INVESTIMENTO_1 ON PIANO_INVESTIMENTI.ID_INVESTIMENTO = LOCALIZZAZIONE_INVESTIMENTO_1.ID_INVESTIMENTO
										WHERE (PIANO_INVESTIMENTI.ID_VARIANTE =@ID_VARIANTE AND ISNULL(COD_VARIAZIONE, 'X')!= 'A' AND PIANO_INVESTIMENTI.ID_PROGETTO= @ID_PROG_CORRENTE  )   
										GROUP BY PIANO_INVESTIMENTI.ID_INVESTIMENTO))) AS LOC ON 
        CATASTO_TERRENI.ID_CATASTO = LOC.ID_CATASTO INNER JOIN
        vComuni ON CATASTO_TERRENI.ID_COMUNE = vComuni.ID_COMUNE RIGHT OUTER JOIN
        PROGETTO AS P INNER JOIN
        PIANO_INVESTIMENTI AS PI ON P.ID_PROGETTO = PI.ID_PROGETTO ON LOC.ID_INVESTIMENTO = PI.ID_INVESTIMENTO
    WHERE PI.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A'  AND PI.ID_PROGETTO= @ID_PROG_CORRENTE
   GROUP BY PI.ID_SETTORE_PRODUTTIVO, vComuni.TIPO_AREA) AS tab
 group by ID_SETTORE_PRODUTTIVO, TIPO_AREA
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
IF (@TipoAreaMax IS NULL OR @IdSettoreProduttivoMaX IS NULL) SET @Punteggio = 0
ELSE BEGIN

   -- CARNI BOVINE Zona A
   IF ((@IdSettoreProduttivoMaX = 7  )AND @TipoAreaMax = 'A') SET @Punteggio = 0.3
   -- CARNI BOVINE Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 7   ) AND @TipoAreaMax = 'C1') SET @Punteggio = 0.6
   -- CARNI BOVINE Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 7   ) AND @TipoAreaMax = 'C2') SET @Punteggio = 0.6
   -- CARNI BOVINE Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 7   ) AND @TipoAreaMax = 'C3') SET @Punteggio = 1
   -- CARNI BOVINE Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 7   ) AND @TipoAreamAX = 'D') SET @Punteggio = 1

   -- CARNI SUINE Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 11   ) AND @TipoAreamAX = 'A') SET @Punteggio = 0.3
   -- CARNI SUINE Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 11   ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.6
   -- CARNI SUINE Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 11   ) AND @TipoAreamAX = 'C2') SET @Punteggio = 1
   -- CARNI SUINE Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 11   ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.6
   -- CARNI SUINE Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 11  ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.6


   -- Oleicolo oppure Olivicolo Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 27 or @IdSettoreProduttivoMaX = 29  )  AND @TipoAreamAX = 'A') SET @Punteggio = 0.6
   -- Oleicolo Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 27 or @IdSettoreProduttivoMaX = 29  ) AND @TipoAreamAX = 'C1') SET @Punteggio = 1
   -- Oleicolo Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 27 or @IdSettoreProduttivoMaX = 29  ) AND @TipoAreamAX = 'C2') SET @Punteggio = 1
   -- Oleicolo Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 27 or @IdSettoreProduttivoMaX = 29  ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.6
   -- Oleicolo Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 27 or @IdSettoreProduttivoMaX = 29  ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.3


   -- Vitivinicolo Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 43  )  AND @TipoAreamAX = 'A') SET @Punteggio = 0.6
   -- Vitivinicolo Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 43  ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.6
   -- Vitivinicolo Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 43  ) AND @TipoAreamAX = 'C2') SET @Punteggio = 1
   -- Vitivinicolo Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 43  ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.6
   -- Vitivinicolo Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 43  ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.3

   -- LATTE E PRODOTTI LATTIERO-CASEARI Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 20  or @IdSettoreProduttivoMaX = 216  ) AND @TipoAreamAX = 'A') SET @Punteggio = 0.3
   -- LATTE E PRODOTTI LATTIERO-CASEARI Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 20  or @IdSettoreProduttivoMaX = 216   )  AND @TipoAreamAX = 'C1') SET @Punteggio = 0.3
   -- LATTE E PRODOTTI LATTIERO-CASEARI Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 20  or @IdSettoreProduttivoMaX = 216   )  AND @TipoAreamAX = 'C2') SET @Punteggio = 0.6
   -- LATTE E PRODOTTI LATTIERO-CASEARI Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 20  or @IdSettoreProduttivoMaX = 216  )  AND @TipoAreamAX = 'C3') SET @Punteggio = 1
   -- LATTE E PRODOTTI LATTIERO-CASEARI Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 20  or @IdSettoreProduttivoMaX = 216   )  AND @TipoAreamAX = 'D') SET @Punteggio = 1

   -- PRODUZIONI DI NICCHIA Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 37  ) AND @TipoAreamAX = 'A') SET @Punteggio = 0.3
   -- PRODUZIONI DI NICCHIA Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 37  )AND @TipoAreamAX = 'C1') SET @Punteggio = 0.3
   -- PRODUZIONI DI NICCHIA Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 37  ) AND @TipoAreamAX = 'C2') SET @Punteggio = 0.6
   -- PRODUZIONI DI NICCHIA Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 37  ) AND @TipoAreamAX = 'C3') SET @Punteggio = 1
   -- PRODUZIONI DI NICCHIA Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 37  ) AND @TipoAreamAX = 'D') SET @Punteggio = 1

   -- OrtoFrutta Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 31  )  AND @TipoAreamAX = 'A') SET @Punteggio = 0.36
   -- OrtoFrutta Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 31  ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.6
   -- OrtoFrutta Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 31  ) AND @TipoAreamAX = 'C2') SET @Punteggio = 0.6
   -- OrtoFrutta Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 31  ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.36
   -- OrtoFrutta Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 31  ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.18

   -- FLOROVIVAISMO Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 16  )  AND @TipoAreamAX = 'A') SET @Punteggio = 0.36
   -- FLOROVIVAISMO Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 16  ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.6
   -- FLOROVIVAISMO Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 16  ) AND @TipoAreamAX = 'C2') SET @Punteggio = 0.36
   -- FLOROVIVAISMO Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 16  ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.18
   -- FLOROVIVAISMO Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 16 ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.18

   -- SEMENTIERO Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 40   ) AND @TipoAreamAX = 'A') SET @Punteggio = 0.18
   -- SEMENTIERO Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 40  ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.6
   -- SEMENTIERO Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 40   ) AND @TipoAreamAX = 'C2') SET @Punteggio = 0.6
   -- SEMENTIERO Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 40   ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.36
   -- SEMENTIERO Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 40   ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.18

   -- AVICOLO (CARNI E UOVA) Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 3  ) AND @TipoAreamAX = 'A') SET @Punteggio = 0.18
   -- AVICOLO (CARNI E UOVA) Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 3  ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.18
   -- AVICOLO (CARNI E UOVA) Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 3  ) AND @TipoAreamAX = 'C2') SET @Punteggio = 0.36
   -- AVICOLO (CARNI E UOVA) Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 3  ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.36
   -- AVICOLO (CARNI E UOVA) Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 3  ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.18

   -- LEGUMINOSE DA GRANELLA Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 23  )  AND @TipoAreamAX = 'A') SET @Punteggio = 0.18
   -- LEGUMINOSE DA GRANELLA Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 23  ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.36
   -- LEGUMINOSE DA GRANELLA Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 23  ) AND @TipoAreamAX = 'C2') SET @Punteggio = 0.36
   -- LEGUMINOSE DA GRANELLA Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 23  ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.6
   -- LEGUMINOSE DA GRANELLA Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 23  ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.36

   -- CARNI OVINE OPPURE OVINO E CAPRINO (PER II SCADENZA ) Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 9 or @IdSettoreProduttivoMaX = 34   ) AND @TipoAreamAX = 'A') SET @Punteggio = 0.18
   -- CARNI OVINE Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 9 or @IdSettoreProduttivoMaX = 34    ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.18
   -- CARNI OVINE Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 9 or @IdSettoreProduttivoMaX = 34   ) AND @TipoAreamAX = 'C2') SET @Punteggio = 0.18
   -- CARNI OVINE Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 9 or @IdSettoreProduttivoMaX = 34   ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.36
   -- CARNI OVINE Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 9 or @IdSettoreProduttivoMaX = 34    ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.6

   -- FORAGGERE Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 19  ) AND @TipoAreamAX = 'A') SET @Punteggio = 0.18
   -- FORAGGERE Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 19  ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.18
   -- FORAGGERE Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 19  ) AND @TipoAreamAX = 'C2') SET @Punteggio = 0.36
   -- FORAGGERE Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 19  ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.6
   -- FORAGGERE Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 19  ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.6

   -- CEREALI Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 13  )AND @TipoAreamAX = 'A') SET @Punteggio = 0.18
   -- CEREALI Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 13  ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.3
   -- CEREALI Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 13  ) AND @TipoAreamAX = 'C2') SET @Punteggio = 0.3
   -- CEREALI Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 13   ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.09
   -- CEREALI Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 13   ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.09   

   -- OLEAGINOSE Zona A
   ELSE IF ((@IdSettoreProduttivoMaX = 24  ) AND @TipoAreamAX = 'A') SET @Punteggio = 0.09
   -- OLEAGINOSE Zona C1
   ELSE IF ((@IdSettoreProduttivoMaX = 24  ) AND @TipoAreamAX = 'C1') SET @Punteggio = 0.18
   -- OLEAGINOSE Zona C2
   ELSE IF ((@IdSettoreProduttivoMaX = 24  ) AND @TipoAreamAX = 'C2') SET @Punteggio = 0.3
   -- OLEAGINOSE Zona C3
   ELSE IF ((@IdSettoreProduttivoMaX = 24  ) AND @TipoAreamAX = 'C3') SET @Punteggio = 0.09
   -- OLEAGINOSE Zona D
   ELSE IF ((@IdSettoreProduttivoMaX = 24  ) AND @TipoAreamAX = 'D') SET @Punteggio = 0.09

   ELSE SET @Punteggio = 0

END
END 
ELSE  SET @Punteggio = 0



SELECT @Punteggio AS PUNTEGGIO
RETURN (@Punteggio * 100)

END