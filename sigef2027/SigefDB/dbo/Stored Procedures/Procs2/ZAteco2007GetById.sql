



CREATE PROCEDURE [dbo].ZAteco2007GetById
(
	@IdAteco2007 char(9)
)
AS
	SELECT *
	FROM TIPO_ATECO2007
	WHERE 
		(COD_TIPO_ATECO2007 = @IdAteco2007)




