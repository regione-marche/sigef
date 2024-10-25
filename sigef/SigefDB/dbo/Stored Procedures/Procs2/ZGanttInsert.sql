CREATE PROCEDURE [dbo].[ZGanttInsert]
(
	@IdBando INT, 
	@Data DATETIME, 
	@IdTipoOperazione INT, 
	@Operatore INT ,
	@IdUO INT
)
AS
	INSERT INTO GANTT
	(
		ID_BANDO, 
		ID_UO, 
		ID_TIPOOP,
		ID_STATO
	)
	VALUES
	(
		@IdBando, 
		@IdUO, 
		@IdTipoOperazione,
		0
	)
	SELECT SCOPE_IDENTITY() AS ID
