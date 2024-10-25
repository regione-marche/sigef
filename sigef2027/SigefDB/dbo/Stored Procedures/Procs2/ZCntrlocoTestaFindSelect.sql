CREATE PROCEDURE [dbo].[ZCntrlocoTestaFindSelect]
(
	@Idlocoequalthis INT, 
	@Codpsrequalthis VARCHAR(255), 
	@Datainizioequalthis DATETIME, 
	@Datafineequalthis DATETIME, 
	@Noteequalthis VARCHAR(500), 
	@Definitivoequalthis BIT, 
	@Datainserimentoequalthis DATETIME, 
	@Datamodificaequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(255), 
	@Datasegnaturaequalthis DATETIME, 
	@Segnaturaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT IdLoco, CodPsr, DataInizio, DataFine, Note, Definitivo, DataInserimento, DataModifica, Operatore, DataSegnatura, Segnatura FROM CntrLoco_Testa WHERE 1=1';
	IF (@Idlocoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IdLoco = @Idlocoequalthis)'; set @lensql=@lensql+len(@Idlocoequalthis);end;
	IF (@Codpsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CodPsr = @Codpsrequalthis)'; set @lensql=@lensql+len(@Codpsrequalthis);end;
	IF (@Datainizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataInizio = @Datainizioequalthis)'; set @lensql=@lensql+len(@Datainizioequalthis);end;
	IF (@Datafineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataFine = @Datafineequalthis)'; set @lensql=@lensql+len(@Datafineequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Note = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@Definitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Definitivo = @Definitivoequalthis)'; set @lensql=@lensql+len(@Definitivoequalthis);end;
	IF (@Datainserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataInserimento = @Datainserimentoequalthis)'; set @lensql=@lensql+len(@Datainserimentoequalthis);end;
	IF (@Datamodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataModifica = @Datamodificaequalthis)'; set @lensql=@lensql+len(@Datamodificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Operatore = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Datasegnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataSegnatura = @Datasegnaturaequalthis)'; set @lensql=@lensql+len(@Datasegnaturaequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Segnatura = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idlocoequalthis INT, @Codpsrequalthis VARCHAR(255), @Datainizioequalthis DATETIME, @Datafineequalthis DATETIME, @Noteequalthis VARCHAR(500), @Definitivoequalthis BIT, @Datainserimentoequalthis DATETIME, @Datamodificaequalthis DATETIME, @Operatoreequalthis VARCHAR(255), @Datasegnaturaequalthis DATETIME, @Segnaturaequalthis VARCHAR(255)',@Idlocoequalthis , @Codpsrequalthis , @Datainizioequalthis , @Datafineequalthis , @Noteequalthis , @Definitivoequalthis , @Datainserimentoequalthis , @Datamodificaequalthis , @Operatoreequalthis , @Datasegnaturaequalthis , @Segnaturaequalthis ;
	else
		SELECT IdLoco, CodPsr, DataInizio, DataFine, Note, Definitivo, DataInserimento, DataModifica, Operatore, DataSegnatura, Segnatura
		FROM CntrLoco_Testa
		WHERE 
			((@Idlocoequalthis IS NULL) OR IdLoco = @Idlocoequalthis) AND 
			((@Codpsrequalthis IS NULL) OR CodPsr = @Codpsrequalthis) AND 
			((@Datainizioequalthis IS NULL) OR DataInizio = @Datainizioequalthis) AND 
			((@Datafineequalthis IS NULL) OR DataFine = @Datafineequalthis) AND 
			((@Noteequalthis IS NULL) OR Note = @Noteequalthis) AND 
			((@Definitivoequalthis IS NULL) OR Definitivo = @Definitivoequalthis) AND 
			((@Datainserimentoequalthis IS NULL) OR DataInserimento = @Datainserimentoequalthis) AND 
			((@Datamodificaequalthis IS NULL) OR DataModifica = @Datamodificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR Operatore = @Operatoreequalthis) AND 
			((@Datasegnaturaequalthis IS NULL) OR DataSegnatura = @Datasegnaturaequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR Segnatura = @Segnaturaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCntrlocoTestaFindSelect]
(
	@Idlocoequalthis INT, 
	@Codpsrequalthis VARCHAR(255), 
	@Datainizioequalthis DATETIME, 
	@Datafineequalthis DATETIME, 
	@Noteequalthis VARCHAR(500), 
	@Definitivoequalthis BIT, 
	@Datainserimentoequalthis DATETIME, 
	@Datamodificaequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT IdLoco, CodPsr, DataInizio, DataFine, Note, Definitivo, DataInserimento, DataModifica, Operatore FROM CntrLoco_Testa WHERE 1=1'';
	IF (@Idlocoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IdLoco = @Idlocoequalthis)''; set @lensql=@lensql+len(@Idlocoequalthis);end;
	IF (@Codpsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CodPsr = @Codpsrequalthis)''; set @lensql=@lensql+len(@Codpsrequalthis);end;
	IF (@Datainizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DataInizio = @Datainizioequalthis)''; set @lensql=@lensql+len(@Datainizioequalthis);end;
	IF (@Datafineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DataFine = @Datafineequalthis)''; set @lensql=@lensql+len(@Datafineequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Note = @Noteequalthis)''; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@Definitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Definitivo = @Definitivoequalthis)''; set @lensql=@lensql+len(@Definitivoequalthis);end;
	IF (@Datainserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DataInserimento = @Datainserimentoequalthis)''; set @lensql=@lensql+len(@Datainserimentoequalthis);end;
	IF (@Datamodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DataModifica = @Datamodificaequalthis)''; set @lensql=@lensql+len(@Datamodificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (Operatore = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idlocoequalthis INT, @Codpsrequalthis VARCHAR(255), @Datainizioequalthis DATETIME, @Datafineequalthis DATETIME, @Noteequalthis VARCHAR(500), @Definitivoequalthis BIT, @Datainserimentoequalthis DATETIME, @Datamodificaequalthis DATETIME, @Operatoreequalthis VARCHAR(255)'',@Idlocoequalthis , @Codpsrequalthis , @Datainizioequalthis , @Datafineequalthis , @Noteequalthis , @Definitivoequalthis , @Datainserimentoequalthis , @Datamodificaequalthis , @Operatoreequalthis ;
	else
		SELECT IdLoco, CodPsr, DataInizio, DataFine, Note, Definitivo, DataInserimento, DataModifica, Operatore
		FROM CntrLoco_Testa
		WHERE 
			((@Idlocoequalthis IS NULL) OR IdLoco = @Idlocoequalthis) AND 
			((@Codpsrequalthis IS NULL) OR CodPsr = @Codpsrequalthis) AND 
			((@Datainizioequalthis IS NULL) OR DataInizio = @Datainizioequalthis) AND 
			((@Datafineequalthis IS NULL) OR DataFine = @Datafineequalthis) AND 
			((@Noteequalthis IS NULL) OR Note = @Noteequalthis) AND 
			((@Definitivoequalthis IS NULL) OR Definitivo = @Definitivoequalthis) AND 
			((@Datainserimentoequalthis IS NULL) OR DataInserimento = @Datainserimentoequalthis) AND 
			((@Datamodificaequalthis IS NULL) OR DataModifica = @Datamodificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR Operatore = @Operatoreequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCntrlocoTestaFindSelect';

