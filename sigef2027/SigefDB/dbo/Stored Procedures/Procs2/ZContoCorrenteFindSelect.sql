CREATE PROCEDURE [dbo].[ZContoCorrenteFindSelect]
(
	@IdContoCorrenteequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdPersonaequalthis INT, 
	@CodPaeseequalthis CHAR(2), 
	@CinEuroequalthis CHAR(2), 
	@Cinequalthis CHAR(1), 
	@Abiequalthis VARCHAR(5), 
	@Cabequalthis VARCHAR(5), 
	@Numeroequalthis VARCHAR(20), 
	@Noteequalthis VARCHAR(500), 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@Istitutoequalthis VARCHAR(255), 
	@Agenziaequalthis VARCHAR(255), 
	@IdComuneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CONTO_CORRENTE, ID_IMPRESA, ID_PERSONA, COD_PAESE, CIN_EURO, CIN, ABI, CAB, NUMERO, NOTE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ISTITUTO, AGENZIA, ID_COMUNE, COD_BELFIORE, COMUNE, SIGLA, CAP FROM vCONTO_CORRENTE WHERE 1=1';
	IF (@IdContoCorrenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTO_CORRENTE = @IdContoCorrenteequalthis)'; set @lensql=@lensql+len(@IdContoCorrenteequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PERSONA = @IdPersonaequalthis)'; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@CodPaeseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PAESE = @CodPaeseequalthis)'; set @lensql=@lensql+len(@CodPaeseequalthis);end;
	IF (@CinEuroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CIN_EURO = @CinEuroequalthis)'; set @lensql=@lensql+len(@CinEuroequalthis);end;
	IF (@Cinequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CIN = @Cinequalthis)'; set @lensql=@lensql+len(@Cinequalthis);end;
	IF (@Abiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ABI = @Abiequalthis)'; set @lensql=@lensql+len(@Abiequalthis);end;
	IF (@Cabequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CAB = @Cabequalthis)'; set @lensql=@lensql+len(@Cabequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)'; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@Istitutoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTITUTO = @Istitutoequalthis)'; set @lensql=@lensql+len(@Istitutoequalthis);end;
	IF (@Agenziaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AGENZIA = @Agenziaequalthis)'; set @lensql=@lensql+len(@Agenziaequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdContoCorrenteequalthis INT, @IdImpresaequalthis INT, @IdPersonaequalthis INT, @CodPaeseequalthis CHAR(2), @CinEuroequalthis CHAR(2), @Cinequalthis CHAR(1), @Abiequalthis VARCHAR(5), @Cabequalthis VARCHAR(5), @Numeroequalthis VARCHAR(20), @Noteequalthis VARCHAR(500), @DataInizioValiditaequalthis DATETIME, @DataFineValiditaequalthis DATETIME, @Istitutoequalthis VARCHAR(255), @Agenziaequalthis VARCHAR(255), @IdComuneequalthis INT',@IdContoCorrenteequalthis , @IdImpresaequalthis , @IdPersonaequalthis , @CodPaeseequalthis , @CinEuroequalthis , @Cinequalthis , @Abiequalthis , @Cabequalthis , @Numeroequalthis , @Noteequalthis , @DataInizioValiditaequalthis , @DataFineValiditaequalthis , @Istitutoequalthis , @Agenziaequalthis , @IdComuneequalthis ;
	else
		SELECT ID_CONTO_CORRENTE, ID_IMPRESA, ID_PERSONA, COD_PAESE, CIN_EURO, CIN, ABI, CAB, NUMERO, NOTE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ISTITUTO, AGENZIA, ID_COMUNE, COD_BELFIORE, COMUNE, SIGLA, CAP
		FROM vCONTO_CORRENTE
		WHERE 
			((@IdContoCorrenteequalthis IS NULL) OR ID_CONTO_CORRENTE = @IdContoCorrenteequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@CodPaeseequalthis IS NULL) OR COD_PAESE = @CodPaeseequalthis) AND 
			((@CinEuroequalthis IS NULL) OR CIN_EURO = @CinEuroequalthis) AND 
			((@Cinequalthis IS NULL) OR CIN = @Cinequalthis) AND 
			((@Abiequalthis IS NULL) OR ABI = @Abiequalthis) AND 
			((@Cabequalthis IS NULL) OR CAB = @Cabequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Noteequalthis IS NULL) OR NOTE = @Noteequalthis) AND 
			((@DataInizioValiditaequalthis IS NULL) OR DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@Istitutoequalthis IS NULL) OR ISTITUTO = @Istitutoequalthis) AND 
			((@Agenziaequalthis IS NULL) OR AGENZIA = @Agenziaequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis)
