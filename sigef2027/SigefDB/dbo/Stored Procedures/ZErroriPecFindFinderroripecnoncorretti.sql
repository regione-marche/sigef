CREATE PROCEDURE [dbo].[ZErroriPecFindFinderroripecnoncorretti]
(
	@Segnaturaequalthis VARCHAR(max), 
	@IdStatolessthanthis INT, 
	@Destinatarioequalthis VARCHAR(max), 
	@EmailDestinatarioequalthis VARCHAR(max)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, OPERATORE_INSERIMENTO, DATA_INSERIMENTO, OPERATORE_MODIFICA, DATA_MODIFICA, SEGNATURA, ID_STATO, STATO, DESTINATARIO, EMAIL_DESTINATARIO, ID_PROGETTO_STORICO, ID_PROGETTO_COMUNICAZIONE, ID_PROGETTO_COMUNICAZIONI, ID_PROGETTO_SEGNATURE, ID_DOMANDA_INTEGRAZIONI, ID_PROGETTO_DOMANDA, ID_DOMANDA_PAGAMENTO, ID_DOMANDA_PAGAMENTO_SEGNATURE, ID_VARIANTE FROM VERRORI_PEC WHERE 1=1';
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@IdStatolessthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STATO < @IdStatolessthanthis)'; set @lensql=@lensql+len(@IdStatolessthanthis);end;
	IF (@Destinatarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESTINATARIO = @Destinatarioequalthis)'; set @lensql=@lensql+len(@Destinatarioequalthis);end;
	IF (@EmailDestinatarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (EMAIL_DESTINATARIO = @EmailDestinatarioequalthis)'; set @lensql=@lensql+len(@EmailDestinatarioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Segnaturaequalthis VARCHAR(max), @IdStatolessthanthis INT, @Destinatarioequalthis VARCHAR(max), @EmailDestinatarioequalthis VARCHAR(max)',@Segnaturaequalthis , @IdStatolessthanthis , @Destinatarioequalthis , @EmailDestinatarioequalthis ;
	else
		SELECT ID, OPERATORE_INSERIMENTO, DATA_INSERIMENTO, OPERATORE_MODIFICA, DATA_MODIFICA, SEGNATURA, ID_STATO, STATO, DESTINATARIO, EMAIL_DESTINATARIO, ID_PROGETTO_STORICO, ID_PROGETTO_COMUNICAZIONE, ID_PROGETTO_COMUNICAZIONI, ID_PROGETTO_SEGNATURE, ID_DOMANDA_INTEGRAZIONI, ID_PROGETTO_DOMANDA, ID_DOMANDA_PAGAMENTO, ID_DOMANDA_PAGAMENTO_SEGNATURE, ID_VARIANTE
		FROM VERRORI_PEC
		WHERE 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@IdStatolessthanthis IS NULL) OR ID_STATO < @IdStatolessthanthis) AND 
			((@Destinatarioequalthis IS NULL) OR DESTINATARIO = @Destinatarioequalthis) AND 
			((@EmailDestinatarioequalthis IS NULL) OR EMAIL_DESTINATARIO = @EmailDestinatarioequalthis)