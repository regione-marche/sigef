CREATE PROCEDURE [dbo].[zIgrueGetTabella]
( 
	@NomeTabella VARCHAR(30),
	@IdInvio INT,
	@CodiceFondo VARCHAR(20)
)
AS
BEGIN
	DECLARE @sql NVARCHAR(1000) 
	set @sql = N'SELECT * FROM IGRUE_MONIT.dbo.IGRUE_' + @NomeTabella+' WHERE ID_INVIO = @IdInvio AND CODICE_FONDO = @CodiceFondo ORDER BY NR_RIGA_INVIO'
	
	exec sp_executesql @sql, N'@NomeTabella VARCHAR(30), @IdInvio INT, @CodiceFondo VARCHAR(20)', @NomeTabella, @IdInvio, @CodiceFondo
END
