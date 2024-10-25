CREATE PROCEDURE [dbo].[ZCertspTestaFindSelect]
(
	@Idcertspequalthis INT, 
	@Codpsrequalthis VARCHAR(255), 
	@Datainizioequalthis DATETIME, 
	@Datafineequalthis DATETIME, 
	@IdFileequalthis INT, 
	@Noteequalthis VARCHAR(500), 
	@Definitivoequalthis BIT, 
	@Tipoequalthis VARCHAR(255), 
	@Datainserimentoequalthis DATETIME, 
	@Datamodificaequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(255), 
	@Datasegnaturaequalthis DATETIME, 
	@Segnaturaequalthis VARCHAR(255), 
	@SegnaturaCertificazioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT IdCertSp, CodPsr, DataInizio, DataFine, Id_File, Note, Definitivo, Tipo, DataInserimento, DataModifica, Operatore, DataSegnatura, Segnatura, Segnatura_Certificazione FROM CertSp_Testa WHERE 1=1';
	IF (@Idcertspequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IdCertSp = @Idcertspequalthis)'; set @lensql=@lensql+len(@Idcertspequalthis);end;
	IF (@Codpsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CodPsr = @Codpsrequalthis)'; set @lensql=@lensql+len(@Codpsrequalthis);end;
	IF (@Datainizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataInizio = @Datainizioequalthis)'; set @lensql=@lensql+len(@Datainizioequalthis);end;
	IF (@Datafineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataFine = @Datafineequalthis)'; set @lensql=@lensql+len(@Datafineequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_File = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Note = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@Definitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Definitivo = @Definitivoequalthis)'; set @lensql=@lensql+len(@Definitivoequalthis);end;
	IF (@Tipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Tipo = @Tipoequalthis)'; set @lensql=@lensql+len(@Tipoequalthis);end;
	IF (@Datainserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataInserimento = @Datainserimentoequalthis)'; set @lensql=@lensql+len(@Datainserimentoequalthis);end;
	IF (@Datamodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataModifica = @Datamodificaequalthis)'; set @lensql=@lensql+len(@Datamodificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Operatore = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Datasegnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataSegnatura = @Datasegnaturaequalthis)'; set @lensql=@lensql+len(@Datasegnaturaequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Segnatura = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@SegnaturaCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Segnatura_Certificazione = @SegnaturaCertificazioneequalthis)'; set @lensql=@lensql+len(@SegnaturaCertificazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idcertspequalthis INT, @Codpsrequalthis VARCHAR(255), @Datainizioequalthis DATETIME, @Datafineequalthis DATETIME, @IdFileequalthis INT, @Noteequalthis VARCHAR(500), @Definitivoequalthis BIT, @Tipoequalthis VARCHAR(255), @Datainserimentoequalthis DATETIME, @Datamodificaequalthis DATETIME, @Operatoreequalthis VARCHAR(255), @Datasegnaturaequalthis DATETIME, @Segnaturaequalthis VARCHAR(255), @SegnaturaCertificazioneequalthis VARCHAR(255)',@Idcertspequalthis , @Codpsrequalthis , @Datainizioequalthis , @Datafineequalthis , @IdFileequalthis , @Noteequalthis , @Definitivoequalthis , @Tipoequalthis , @Datainserimentoequalthis , @Datamodificaequalthis , @Operatoreequalthis , @Datasegnaturaequalthis , @Segnaturaequalthis , @SegnaturaCertificazioneequalthis ;
	else
		SELECT IdCertSp, CodPsr, DataInizio, DataFine, Id_File, Note, Definitivo, Tipo, DataInserimento, DataModifica, Operatore, DataSegnatura, Segnatura, Segnatura_Certificazione
		FROM CertSp_Testa
		WHERE 
			((@Idcertspequalthis IS NULL) OR IdCertSp = @Idcertspequalthis) AND 
			((@Codpsrequalthis IS NULL) OR CodPsr = @Codpsrequalthis) AND 
			((@Datainizioequalthis IS NULL) OR DataInizio = @Datainizioequalthis) AND 
			((@Datafineequalthis IS NULL) OR DataFine = @Datafineequalthis) AND 
			((@IdFileequalthis IS NULL) OR Id_File = @IdFileequalthis) AND 
			((@Noteequalthis IS NULL) OR Note = @Noteequalthis) AND 
			((@Definitivoequalthis IS NULL) OR Definitivo = @Definitivoequalthis) AND 
			((@Tipoequalthis IS NULL) OR Tipo = @Tipoequalthis) AND 
			((@Datainserimentoequalthis IS NULL) OR DataInserimento = @Datainserimentoequalthis) AND 
			((@Datamodificaequalthis IS NULL) OR DataModifica = @Datamodificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR Operatore = @Operatoreequalthis) AND 
			((@Datasegnaturaequalthis IS NULL) OR DataSegnatura = @Datasegnaturaequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR Segnatura = @Segnaturaequalthis) AND 
			((@SegnaturaCertificazioneequalthis IS NULL) OR Segnatura_Certificazione = @SegnaturaCertificazioneequalthis)
		

GO