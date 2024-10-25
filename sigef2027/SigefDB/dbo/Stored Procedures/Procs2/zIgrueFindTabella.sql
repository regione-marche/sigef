CREATE PROCEDURE [dbo].[zIgrueFindTabella]
( 
	@NomeTabella VARCHAR(30),
	@IdInvio INT,
	@RowNumber INT,
	@CodiceFondo VARCHAR(20)
)
AS
BEGIN
	DECLARE @sql NVARCHAR(1000) 
	set @sql = N'SELECT * FROM IGRUE_MONIT.dbo.IGRUE_' + @NomeTabella+' WHERE ID_INVIO = @IdInvio'
	IF(@RowNumber IS NOT NULL) BEGIN SET @sql = @sql + ' AND NR_RIGA_INVIO = ' + CONVERT(VARCHAR(5),@RowNumber) END
	IF(@CodiceFondo IS NOT NULL) BEGIN SET @sql = @sql + ' AND CODICE_FONDO = ''' + @CodiceFondo + '''' END
	exec sp_executesql @sql, N'@NomeTabella VARCHAR(30), @IdInvio INT, @RowNumber INT, @CodiceFondo VARCHAR(20)', @NomeTabella, @IdInvio, @RowNumber, @CodiceFondo
END
