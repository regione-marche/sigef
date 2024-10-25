CREATE PROCEDURE [dbo].[ZErroriPecFindSelect]
(
	@Idequalthis INT, 
	@OperatoreInserimentoequalthis VARCHAR(max), 
	@DataInserimentoequalthis DATETIME, 
	@OperatoreModificaequalthis VARCHAR(max), 
	@DataModificaequalthis DATETIME, 
	@Segnaturaequalthis VARCHAR(max), 
	@IdStatoequalthis INT, 
	@Statoequalthis VARCHAR(max), 
	@Destinatarioequalthis VARCHAR(max), 
	@EmailDestinatarioequalthis VARCHAR(max)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, OPERATORE_INSERIMENTO, DATA_INSERIMENTO, OPERATORE_MODIFICA, DATA_MODIFICA, SEGNATURA, ID_STATO, STATO, DESTINATARIO, EMAIL_DESTINATARIO, ID_PROGETTO_STORICO, ID_PROGETTO_COMUNICAZIONE, ID_PROGETTO_COMUNICAZIONI, ID_PROGETTO_SEGNATURE, ID_DOMANDA_INTEGRAZIONI, ID_PROGETTO_DOMANDA, ID_DOMANDA_PAGAMENTO, ID_DOMANDA_PAGAMENTO_SEGNATURE, ID_VARIANTE FROM VERRORI_PEC WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@OperatoreInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_INSERIMENTO = @OperatoreInserimentoequalthis)'; set @lensql=@lensql+len(@OperatoreInserimentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@OperatoreModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_MODIFICA = @OperatoreModificaequalthis)'; set @lensql=@lensql+len(@OperatoreModificaequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@IdStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STATO = @IdStatoequalthis)'; set @lensql=@lensql+len(@IdStatoequalthis);end;
	IF (@Statoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO = @Statoequalthis)'; set @lensql=@lensql+len(@Statoequalthis);end;
	IF (@Destinatarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESTINATARIO = @Destinatarioequalthis)'; set @lensql=@lensql+len(@Destinatarioequalthis);end;
	IF (@EmailDestinatarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (EMAIL_DESTINATARIO = @EmailDestinatarioequalthis)'; set @lensql=@lensql+len(@EmailDestinatarioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @OperatoreInserimentoequalthis VARCHAR(max), @DataInserimentoequalthis DATETIME, @OperatoreModificaequalthis VARCHAR(max), @DataModificaequalthis DATETIME, @Segnaturaequalthis VARCHAR(max), @IdStatoequalthis INT, @Statoequalthis VARCHAR(max), @Destinatarioequalthis VARCHAR(max), @EmailDestinatarioequalthis VARCHAR(max)',@Idequalthis , @OperatoreInserimentoequalthis , @DataInserimentoequalthis , @OperatoreModificaequalthis , @DataModificaequalthis , @Segnaturaequalthis , @IdStatoequalthis , @Statoequalthis , @Destinatarioequalthis , @EmailDestinatarioequalthis ;
	else
		SELECT ID, OPERATORE_INSERIMENTO, DATA_INSERIMENTO, OPERATORE_MODIFICA, DATA_MODIFICA, SEGNATURA, ID_STATO, STATO, DESTINATARIO, EMAIL_DESTINATARIO, ID_PROGETTO_STORICO, ID_PROGETTO_COMUNICAZIONE, ID_PROGETTO_COMUNICAZIONI, ID_PROGETTO_SEGNATURE, ID_DOMANDA_INTEGRAZIONI, ID_PROGETTO_DOMANDA, ID_DOMANDA_PAGAMENTO, ID_DOMANDA_PAGAMENTO_SEGNATURE, ID_VARIANTE
		FROM VERRORI_PEC
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@OperatoreInserimentoequalthis IS NULL) OR OPERATORE_INSERIMENTO = @OperatoreInserimentoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@OperatoreModificaequalthis IS NULL) OR OPERATORE_MODIFICA = @OperatoreModificaequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@IdStatoequalthis IS NULL) OR ID_STATO = @IdStatoequalthis) AND 
			((@Statoequalthis IS NULL) OR STATO = @Statoequalthis) AND 
			((@Destinatarioequalthis IS NULL) OR DESTINATARIO = @Destinatarioequalthis) AND 
			((@EmailDestinatarioequalthis IS NULL) OR EMAIL_DESTINATARIO = @EmailDestinatarioequalthis)
		

GO