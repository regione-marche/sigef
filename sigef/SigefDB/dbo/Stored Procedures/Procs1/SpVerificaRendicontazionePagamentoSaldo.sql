CREATE PROCEDURE [dbo].[SpVerificaRendicontazionePagamentoSaldo]
(
	@ID_DOMANDA_PAGAMENTO INT
)
AS

-- declare @ID_DOMANDA_PAGAMENTO INT = 5217
DECLARE @ID_BANDO INT,	 @COD_ENTE VARCHAR(10) 

SELECT @ID_BANDO=P.ID_BANDO, @COD_ENTE =  B.COD_ENTE 
FROM DOMANDA_DI_PAGAMENTO D INNER JOIN PROGETTO P ON D.ID_PROGETTO=P.ID_PROGETTO
INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO
WHERE ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO

IF(@COD_ENTE LIKE '%RM%') BEGIN 
 	IF @ID_BANDO=27 EXEC VerificaRendicontazionePagamentoSaldo_M112_B27 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=76 EXEC VerificaRendicontazionePagamentoSaldo_M112_B76 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=107 EXEC VerificaRendicontazionePagamentoSaldo_M112_B107 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (135, 376) EXEC VerificaRendicontazionePagamentoSaldo_M112_B135 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (18,90) EXEC VerificaRendicontazionePagamentoSaldo_M121_B18 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (370) EXEC VerificaRendicontazionePagamentoSaldo_M121_B370 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (434) EXEC VerificaRendicontazionePagamentoSaldo_M121_B434 @ID_DOMANDA_PAGAMENTO
    ELSE IF @ID_BANDO IN (474) EXEC VerificaRendicontazionePagamentoSaldo_M121_B474 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=34 EXEC VerificaRendicontazionePagamentoSaldo_M311_B34 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=41 EXEC VerificaRendicontazionePagamentoSaldo_M111_B41 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=42 EXEC VerificaRendicontazionePagamentoSaldo_M121_B42 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=72 EXEC VerificaRendicontazionePagamentoSaldo_M123_B72 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=88 EXEC VerificaRendicontazionePagamentoSaldo_M111_B88 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (102,385,429) EXEC VerificaRendicontazionePagamentoSaldo_M311_B102 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (115,382,430,128, 459) EXEC VerificaRendicontazionePagamentoSaldo_M311_B115 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=120  EXEC VerificaRendicontazionePagamentoSaldo_M111_B120 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=367 EXEC VerificaRendicontazionePagamentoSaldo_M111_B367 @ID_DOMANDA_PAGAMENTO  
	ELSE IF @ID_BANDO=126 EXEC VerificaRendicontazionePagamentoSaldo_M121_B126 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=131 EXEC VerificaRendicontazionePagamentoSaldo_M132_B131 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (159,194) EXEC VerificaRendicontazionePagamentoSaldo_M132_B159 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (193, 158) EXEC VerificaRendicontazionePagamentoSaldo_M121_B193 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=203 EXEC VerificaRendicontazionePagamentoSaldo_M221_203 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (233,386, 432) EXEC VerificaRendicontazionePagamentoSaldo_M221_233 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=251 EXEC VerificaRendicontazionePagamentoSaldo_M221_251 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=127 EXEC VerificaRendicontazionePagamentoSaldo_M123_B127 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO in(143,269,375,417) EXEC VerificaRendicontazionePagamentoSaldo_B143_269_375 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO in (157,296)  EXEC VerificaRendicontazionePagamentoSaldo_M111_B157 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (372,425,418) EXEC VerificaRendicontazionePagamentoSaldo_M123_B372 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (457,475) EXEC VerificaRendicontazionePagamentoSaldo_M123_B457 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=306 EXEC VerificaRendicontazionePagamentoSaldo_B306 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=243 EXEC VerificaRendicontazionePagamentoSaldo_B243 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=284 EXEC VerificaRendicontazionePagamentoSaldo_B284 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=243 EXEC VerificaRendicontazionePagamentoSaldo_B354 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=150 EXEC VerificaRendicontazionePagamentoSaldo_M111_B150 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=369 EXEC VerificaRendicontazionePagamentoSaldo_M111_B369 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=265 EXEC VerificaRendicontazionePagamentoSaldo_M132_B265 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=478 EXEC VerificaRendicontazionePagamentoSaldo_M111_B478 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (262,347,389) EXEC VerificaRendicontazionePagamentoSaldo_M121_B347 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (451) EXEC VerificaRendicontazionePagamentoSaldo_M311_B451 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (374) EXEC VerificaRendicontazionePagamentoSaldo_M125_B374 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO IN (106) EXEC VerificaRendicontazionePagamentoSaldo_M431_B106 @ID_DOMANDA_PAGAMENTO
	ELSE SELECT 'N' AS TIPO_RISULTATO, 'La verifica non è ancora stata predisposta per questo bando. Impossibile eseguire la richiesta.' AS MESSAGGIO_RISULTATO
END
ELSE BEGIN 
	-- GAL_S
    IF @ID_BANDO=176 EXEC VerificaRendicontazionePagamentoSaldo_M4132C_B176 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=230 EXEC VerificaRendicontazionePagamentoSaldo_B230 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=224 EXEC VerificaRendicontazionePagamentoSaldo_B224 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=201 EXEC VerificaRendicontazionePagamentoSaldo_B201 @ID_DOMANDA_PAGAMENTO
    ELSE IF @ID_BANDO=221 EXEC VerificaRendicontazionePagamentoSaldo_B221 @ID_DOMANDA_PAGAMENTO
    ELSE IF @ID_BANDO=249 EXEC VerificaRendicontazionePagamentoSaldo_B249 @ID_DOMANDA_PAGAMENTO
    ELSE IF @ID_BANDO=255 EXEC VerificaRendicontazionePagamentoSaldo_B255 @ID_DOMANDA_PAGAMENTO
    ELSE IF @ID_BANDO=404 EXEC VerificaRendicontazionePagamentoSaldo_B404 @ID_DOMANDA_PAGAMENTO


   -- GAL_CE
   ELSE IF @ID_BANDO=170 EXEC VerificaRendicontazionePagamentoSaldo_B170 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=172 EXEC VerificaRendicontazionePagamentoSaldo_B172 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=174 EXEC VerificaRendicontazionePagamentoSaldo_B174 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=177 EXEC VerificaRendicontazionePagamentoSaldo_B177 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO in (207,338) EXEC VerificaRendicontazionePagamentoSaldo_B207 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=216 EXEC VerificaRendicontazionePagamentoSaldo_B216 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=220 EXEC VerificaRendicontazionePagamentoSaldo_B220 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=235 EXEC VerificaRendicontazionePagamentoSaldo_B235 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO in (419,399) EXEC VerificaRendicontazionePagamentoSaldo_B419 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=420 EXEC VerificaRendicontazionePagamentoSaldo_B420 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=421 EXEC VerificaRendicontazionePagamentoSaldo_B421 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=252 EXEC VerificaRendicontazionePagamentoSaldo_B252 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=239 EXEC VerificaRendicontazionePagamentoSaldo_B239 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=232 EXEC VerificaRendicontazionePagamentoSaldo_B232 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=357 EXEC VerificaRendicontazionePagamentoSaldo_B357 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=338 EXEC VerificaRendicontazionePagamentoSaldo_B338 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=463 EXEC VerificaRendicontazionePagamentoSaldo_B463 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=421 EXEC VerificaRendicontazionePagamentoSaldo_B421 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=443 EXEC VerificaRendicontazionePagamentoSaldo_B443 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=471 EXEC VerificaRendicontazionePagamentoSaldo_B471 @ID_DOMANDA_PAGAMENTO
   
-- GAL_F
   ELSE IF @ID_BANDO=188 EXEC VerificaRendicontazionePagamentoSaldo_M4131A2_B188 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=199 EXEC VerificaRendicontazionePagamentoSaldo_M4137A_B199 @ID_DOMANDA_PAGAMENTO 
   ELSE IF @ID_BANDO=187 EXEC VerificaRendicontazionePagamentoSaldo_B187 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=214 EXEC VerificaRendicontazionePagamentoSaldo_B214 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=455 EXEC VerificaRendicontazionePagamentoSaldo_B455 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO in (408,433, 453) EXEC VerificaRendicontazionePagamentoSaldo_B408_433 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=359 EXEC VerificaRendicontazionePagamentoSaldo_B359 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=407 EXEC VerificaRendicontazionePagamentoSaldo_B407 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=487 EXEC VerificaRendicontazionePagamentoSaldo_B487 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=355 EXEC VerificaRendicontazionePagamentoSaldo_B355 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=485 EXEC VerificaRendicontazionePagamentoSaldo_B485 @ID_DOMANDA_PAGAMENTO
   
   -- GAL_P
   ELSE IF @ID_BANDO=167 EXEC VerificaRendicontazionePagamentoSaldo_M4131B_B167 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=169 EXEC VerificaRendicontazionePagamentoSaldo_B169 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=175 EXEC VerificaRendicontazionePagamentoSaldo_B175 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=279 EXEC VerificaRendicontazionePagamentoSaldo_B279 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=281 EXEC VerificaRendicontazionePagamentoSaldo_B281 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=285 EXEC VerificaRendicontazionePagamentoSaldo_B285 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=315 EXEC VerificaRendicontazionePagamentoSaldo_B315 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=356 EXEC VerificaRendicontazionePagamentoSaldo_B356 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=488 EXEC VerificaRendicontazionePagamentoSaldo_B488 @ID_DOMANDA_PAGAMENTO

   -- GAL_FL
   ELSE IF @ID_BANDO=185 EXEC VerificaRendicontazionePagamentoSaldo_B185 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO in (218,277,351) EXEC VerificaRendicontazionePagamentoSaldo_B218 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=236 EXEC VerificaRendicontazionePagamentoSaldo_B236 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=244 EXEC VerificaRendicontazionePagamentoSaldo_B244 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=259 EXEC VerificaRendicontazionePagamentoSaldo_B259 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=253 EXEC VerificaRendicontazionePagamentoSaldo_B253 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=254 EXEC VerificaRendicontazionePagamentoSaldo_B254 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=288 EXEC VerificaRendicontazionePagamentoSaldo_B288 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=336 EXEC VerificaRendicontazionePagamentoSaldo_B336 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=337 EXEC VerificaRendicontazionePagamentoSaldo_B337 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=387 EXEC VerificaRendicontazionePagamentoSaldo_B387 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=362 EXEC VerificaRendicontazionePagamentoSaldo_B362 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=363 EXEC VerificaRendicontazionePagamentoSaldo_B363 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO in (411,462) EXEC VerificaRendicontazionePagamentoSaldo_B411 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=413 EXEC VerificaRendicontazionePagamentoSaldo_B413 @ID_DOMANDA_PAGAMENTO	
	
   -- GAL_M
   ELSE IF @ID_BANDO=273 EXEC VerificaRendicontazionePagamentoSaldo_B273 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=231 EXEC VerificaRendicontazionePagamentoSaldo_B231 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=322 EXEC VerificaRendicontazionePagamentoSaldo_B322 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=202 EXEC VerificaRendicontazionePagamentoSaldo_B202 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=212 EXEC VerificaRendicontazionePagamentoSaldo_B212 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=238 EXEC VerificaRendicontazionePagamentoSaldo_B238 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=240 EXEC VerificaRendicontazionePagamentoSaldo_B240 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=304 EXEC VerificaRendicontazionePagamentoSaldo_B304 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=278 EXEC VerificaRendicontazionePagamentoSaldo_B278 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=440 EXEC VerificaRendicontazionePagamentoSaldo_B440 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=441 EXEC VerificaRendicontazionePagamentoSaldo_B441 @ID_DOMANDA_PAGAMENTO  
   ELSE IF @ID_BANDO=442 EXEC VerificaRendicontazionePagamentoSaldo_B442 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=446 EXEC VerificaRendicontazionePagamentoSaldo_B446 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=447 EXEC VerificaRendicontazionePagamentoSaldo_B447 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=448 EXEC VerificaRendicontazionePagamentoSaldo_B448 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=449 EXEC VerificaRendicontazionePagamentoSaldo_B449 @ID_DOMANDA_PAGAMENTO 
         
   -- PR_PU
   ELSE IF @ID_BANDO=223 EXEC VerificaRendicontazionePagamentoSaldo_B223 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=293 EXEC VerificaRendicontazionePagamentoSaldo_B293 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=309 EXEC VerificaRendicontazionePagamentoSaldo_B309 @ID_DOMANDA_PAGAMENTO
   -- PR_AN
   ELSE IF @ID_BANDO=303 EXEC VerificaRendicontazionePagamentoSaldo_B303 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=305 EXEC VerificaRendicontazionePagamentoSaldo_B305 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=313 EXEC VerificaRendicontazionePagamentoSaldo_B313 @ID_DOMANDA_PAGAMENTO
   ELSE IF @ID_BANDO=314 EXEC VerificaRendicontazionePagamentoSaldo_B314 @ID_DOMANDA_PAGAMENTO
-- PR_AP
   ELSE IF @ID_BANDO=312 EXEC VerificaRendicontazionePagamentoSaldo_B312 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=317 EXEC VerificaRendicontazionePagamentoSaldo_B317 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=324 EXEC VerificaRendicontazionePagamentoSaldo_B324 @ID_DOMANDA_PAGAMENTO
-- PR_FM
    ELSE IF @ID_BANDO=325 EXEC VerificaRendicontazionePagamentoSaldo_B325 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=319 EXEC VerificaRendicontazionePagamentoSaldo_B319 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=321 EXEC VerificaRendicontazionePagamentoSaldo_B321 @ID_DOMANDA_PAGAMENTO
	
-- PR_MC	
	ELSE IF @ID_BANDO=326 EXEC VerificaRendicontazionePagamentoSaldo_B326 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=329 EXEC VerificaRendicontazionePagamentoSaldo_B329 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=330 EXEC VerificaRendicontazionePagamentoSaldo_B330 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=331 EXEC VerificaRendicontazionePagamentoSaldo_B331 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=332 EXEC VerificaRendicontazionePagamentoSaldo_B332 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=333 EXEC VerificaRendicontazionePagamentoSaldo_B333 @ID_DOMANDA_PAGAMENTO
	ELSE IF @ID_BANDO=334 EXEC VerificaRendicontazionePagamentoSaldo_B334 @ID_DOMANDA_PAGAMENTO
	ELSE SELECT 'N' AS TIPO_RISULTATO, 'La verifica non è ancora stata predisposta per questo bando. Impossibile eseguire la richiesta.' AS MESSAGGIO_RISULTATO
END
