﻿--
create PROCEDURE [dbo].[calcoloStep321a14_PR_MC]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN

DECLARE @result int

SET @RESULT = 0 --PONGO LO STEP IN STATO NON VERIFICATO

DECLARE @GRUPP_DIC_A  int,
		@GRUPP_DIC_B  int

select @GRUPP_DIC_A = (SELECT COUNT(*) FROM DICHIARAZIONI_X_PROGETTO WHERE ID_PROGETTO=@IdProgetto AND ID_DICHIARAZIONE IN (1120,1130))
						 
select @GRUPP_DIC_B = (SELECT COUNT(*) FROM DICHIARAZIONI_X_PROGETTO WHERE ID_PROGETTO=@IdProgetto AND ID_DICHIARAZIONE IN (1128,1129))


 
IF((ISNULL(@GRUPP_DIC_A ,0) = 1) AND (ISNULL(@GRUPP_DIC_B ,0) = 1))
	SET @result = 1 
	
	SELECT @result AS RESULT
END