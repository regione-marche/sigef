

CREATE PROCEDURE [dbo].[SpSigefNightScheduledJob]
(
	@NR_TABELLE INT OUTPUT
)
AS	
	SET @NR_TABELLE=0
	DECLARE @NOME_TABELLA VARCHAR(50),@cmd NVARCHAR(600)
	DECLARE TABELLE CURSOR FOR
		SELECT DISTINCT OBJECT_NAME(s.[object_id]) FROM sys.dm_db_index_physical_stats(db_id('sigefproduzione'),null, null, null, null) s
		INNER JOIN sys.indexes i ON s.[object_id] = i.[object_id] AND s.index_id = i.index_id 
		WHERE /*ROUND(avg_fragmentation_in_percent,2)>10 and*/ s.index_type_desc!='heap'
	OPEN TABELLE
	FETCH NEXT FROM TABELLE INTO @NOME_TABELLA
	WHILE @@FETCH_STATUS=0 BEGIN
		SET @cmd = 'ALTER INDEX ALL ON ' + @NOME_TABELLA + ' REBUILD'-- WITH (FILLFACTOR = 80)'
		EXEC (@cmd)
		--PRINT @NOME_TABELLA
		SET @NR_TABELLE=@NR_TABELLE+1
		FETCH NEXT FROM TABELLE INTO @NOME_TABELLA
	END
	CLOSE TABELLE
	DEALLOCATE TABELLE

