CREATE PROCEDURE [dbo].[ZVpistaControlloFindSelect]
(
	@Idbandoequalthis INT, 
	@Descrizionebandoequalthis VARCHAR(2000), 
	@Idprogettoequalthis INT, 
	@Assecodequalthis VARCHAR(255), 
	@Assedescrequalthis VARCHAR(2000), 
	@Azionecodequalthis VARCHAR(255), 
	@Azionedescrequalthis VARCHAR(2000), 
	@Interventocodequalthis VARCHAR(255), 
	@Interventodescrequalthis VARCHAR(2000), 
	@Ragionesocialeequalthis VARCHAR(255), 
	@Partitaivacfequalthis VARCHAR(255), 
	@Tipoproceduraequalthis VARCHAR(255), 
	@CupNaturaequalthis VARCHAR(255), 
	@Codicetitolaritaregiaequalthis VARCHAR(255), 
	@Datapubblicazionebandoequalthis DATETIME, 
	@Attopubblicazionebandoequalthis INT, 
	@Attopubblicazionebandonumequalthis INT, 
	@Attopubblicazionebandodataequalthis DATETIME, 
	@Attopubblicazionebandoregistroequalthis VARCHAR(255), 
	@Attopubblicazionebandoburequalthis INT, 
	@Attopubblicazionebandoburdataequalthis DATETIME, 
	@Segnaturadomandaequalthis VARCHAR(255), 
	@Domandadataequalthis DATETIME, 
	@Segnaturavalutazionecomitatoequalthis VARCHAR(255), 
	@Datavalutazionecomitatoequalthis DATETIME, 
	@Segnaturavalutazionevariantecomitatoequalthis VARCHAR(255), 
	@Datavalutazionevariantecomitatoequalthis DATETIME, 
	@Attodecretograduatoriaequalthis INT, 
	@Attodecretograduatorianumequalthis INT, 
	@Attodecretograduatoriadataequalthis DATETIME, 
	@Attodecretograduatoriaregistroequalthis VARCHAR(255), 
	@Attodecretograduatoriaindividualeequalthis INT, 
	@Attodecretograduatoriaindividualenumequalthis INT, 
	@Attodecretograduatoriaindividualedataequalthis DATETIME, 
	@Attodecretograduatoriaindividualeregistroequalthis VARCHAR(255), 
	@Segnaturagraduatoriaequalthis VARCHAR(255), 
	@Datagraduatoriaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT IdBando, DescrizioneBando, IdProgetto, AsseCod, AsseDescr, AzioneCod, AzioneDescr, InterventoCod, InterventoDescr, RagioneSociale, PartitaIvaCF, TipoProcedura, CUP_NATURA, CodiceTitolaritaRegia, DataPubblicazioneBando, AttoPubblicazioneBando, AttoPubblicazioneBandoNum, AttoPubblicazioneBandoData, AttoPubblicazioneBandoRegistro, AttoPubblicazioneBandoBur, AttoPubblicazioneBandoBurData, SegnaturaDomanda, DomandaData, SegnaturaValutazioneComitato, DataValutazioneComitato, SegnaturaValutazioneVarianteComitato, DataValutazioneVarianteComitato, AttoDecretoGraduatoria, AttoDecretoGraduatoriaNum, AttoDecretoGraduatoriaData, AttoDecretoGraduatoriaRegistro, AttoDecretoGraduatoriaIndividuale, AttoDecretoGraduatoriaIndividualeNum, AttoDecretoGraduatoriaIndividualeData, AttoDecretoGraduatoriaIndividualeRegistro, SegnaturaGraduatoria, DataGraduatoria FROM vPISTA_CONTROLLO WHERE 1=1';
	IF (@Idbandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IdBando = @Idbandoequalthis)'; set @lensql=@lensql+len(@Idbandoequalthis);end;
	IF (@Descrizionebandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DescrizioneBando = @Descrizionebandoequalthis)'; set @lensql=@lensql+len(@Descrizionebandoequalthis);end;
	IF (@Idprogettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IdProgetto = @Idprogettoequalthis)'; set @lensql=@lensql+len(@Idprogettoequalthis);end;
	IF (@Assecodequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AsseCod = @Assecodequalthis)'; set @lensql=@lensql+len(@Assecodequalthis);end;
	IF (@Assedescrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AsseDescr = @Assedescrequalthis)'; set @lensql=@lensql+len(@Assedescrequalthis);end;
	IF (@Azionecodequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AzioneCod = @Azionecodequalthis)'; set @lensql=@lensql+len(@Azionecodequalthis);end;
	IF (@Azionedescrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AzioneDescr = @Azionedescrequalthis)'; set @lensql=@lensql+len(@Azionedescrequalthis);end;
	IF (@Interventocodequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (InterventoCod = @Interventocodequalthis)'; set @lensql=@lensql+len(@Interventocodequalthis);end;
	IF (@Interventodescrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (InterventoDescr = @Interventodescrequalthis)'; set @lensql=@lensql+len(@Interventodescrequalthis);end;
	IF (@Ragionesocialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RagioneSociale = @Ragionesocialeequalthis)'; set @lensql=@lensql+len(@Ragionesocialeequalthis);end;
	IF (@Partitaivacfequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PartitaIvaCF = @Partitaivacfequalthis)'; set @lensql=@lensql+len(@Partitaivacfequalthis);end;
	IF (@Tipoproceduraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TipoProcedura = @Tipoproceduraequalthis)'; set @lensql=@lensql+len(@Tipoproceduraequalthis);end;
	IF (@CupNaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUP_NATURA = @CupNaturaequalthis)'; set @lensql=@lensql+len(@CupNaturaequalthis);end;
	IF (@Codicetitolaritaregiaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CodiceTitolaritaRegia = @Codicetitolaritaregiaequalthis)'; set @lensql=@lensql+len(@Codicetitolaritaregiaequalthis);end;
	IF (@Datapubblicazionebandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataPubblicazioneBando = @Datapubblicazionebandoequalthis)'; set @lensql=@lensql+len(@Datapubblicazionebandoequalthis);end;
	IF (@Attopubblicazionebandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoPubblicazioneBando = @Attopubblicazionebandoequalthis)'; set @lensql=@lensql+len(@Attopubblicazionebandoequalthis);end;
	IF (@Attopubblicazionebandonumequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoPubblicazioneBandoNum = @Attopubblicazionebandonumequalthis)'; set @lensql=@lensql+len(@Attopubblicazionebandonumequalthis);end;
	IF (@Attopubblicazionebandodataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoPubblicazioneBandoData = @Attopubblicazionebandodataequalthis)'; set @lensql=@lensql+len(@Attopubblicazionebandodataequalthis);end;
	IF (@Attopubblicazionebandoregistroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoPubblicazioneBandoRegistro = @Attopubblicazionebandoregistroequalthis)'; set @lensql=@lensql+len(@Attopubblicazionebandoregistroequalthis);end;
	IF (@Attopubblicazionebandoburequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoPubblicazioneBandoBur = @Attopubblicazionebandoburequalthis)'; set @lensql=@lensql+len(@Attopubblicazionebandoburequalthis);end;
	IF (@Attopubblicazionebandoburdataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoPubblicazioneBandoBurData = @Attopubblicazionebandoburdataequalthis)'; set @lensql=@lensql+len(@Attopubblicazionebandoburdataequalthis);end;
	IF (@Segnaturadomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SegnaturaDomanda = @Segnaturadomandaequalthis)'; set @lensql=@lensql+len(@Segnaturadomandaequalthis);end;
	IF (@Domandadataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DomandaData = @Domandadataequalthis)'; set @lensql=@lensql+len(@Domandadataequalthis);end;
	IF (@Segnaturavalutazionecomitatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SegnaturaValutazioneComitato = @Segnaturavalutazionecomitatoequalthis)'; set @lensql=@lensql+len(@Segnaturavalutazionecomitatoequalthis);end;
	IF (@Datavalutazionecomitatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataValutazioneComitato = @Datavalutazionecomitatoequalthis)'; set @lensql=@lensql+len(@Datavalutazionecomitatoequalthis);end;
	IF (@Segnaturavalutazionevariantecomitatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SegnaturaValutazioneVarianteComitato = @Segnaturavalutazionevariantecomitatoequalthis)'; set @lensql=@lensql+len(@Segnaturavalutazionevariantecomitatoequalthis);end;
	IF (@Datavalutazionevariantecomitatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataValutazioneVarianteComitato = @Datavalutazionevariantecomitatoequalthis)'; set @lensql=@lensql+len(@Datavalutazionevariantecomitatoequalthis);end;
	IF (@Attodecretograduatoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoDecretoGraduatoria = @Attodecretograduatoriaequalthis)'; set @lensql=@lensql+len(@Attodecretograduatoriaequalthis);end;
	IF (@Attodecretograduatorianumequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoDecretoGraduatoriaNum = @Attodecretograduatorianumequalthis)'; set @lensql=@lensql+len(@Attodecretograduatorianumequalthis);end;
	IF (@Attodecretograduatoriadataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoDecretoGraduatoriaData = @Attodecretograduatoriadataequalthis)'; set @lensql=@lensql+len(@Attodecretograduatoriadataequalthis);end;
	IF (@Attodecretograduatoriaregistroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoDecretoGraduatoriaRegistro = @Attodecretograduatoriaregistroequalthis)'; set @lensql=@lensql+len(@Attodecretograduatoriaregistroequalthis);end;
	IF (@Attodecretograduatoriaindividualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoDecretoGraduatoriaIndividuale = @Attodecretograduatoriaindividualeequalthis)'; set @lensql=@lensql+len(@Attodecretograduatoriaindividualeequalthis);end;
	IF (@Attodecretograduatoriaindividualenumequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoDecretoGraduatoriaIndividualeNum = @Attodecretograduatoriaindividualenumequalthis)'; set @lensql=@lensql+len(@Attodecretograduatoriaindividualenumequalthis);end;
	IF (@Attodecretograduatoriaindividualedataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoDecretoGraduatoriaIndividualeData = @Attodecretograduatoriaindividualedataequalthis)'; set @lensql=@lensql+len(@Attodecretograduatoriaindividualedataequalthis);end;
	IF (@Attodecretograduatoriaindividualeregistroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AttoDecretoGraduatoriaIndividualeRegistro = @Attodecretograduatoriaindividualeregistroequalthis)'; set @lensql=@lensql+len(@Attodecretograduatoriaindividualeregistroequalthis);end;
	IF (@Segnaturagraduatoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SegnaturaGraduatoria = @Segnaturagraduatoriaequalthis)'; set @lensql=@lensql+len(@Segnaturagraduatoriaequalthis);end;
	IF (@Datagraduatoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DataGraduatoria = @Datagraduatoriaequalthis)'; set @lensql=@lensql+len(@Datagraduatoriaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idbandoequalthis INT, @Descrizionebandoequalthis VARCHAR(2000), @Idprogettoequalthis INT, @Assecodequalthis VARCHAR(255), @Assedescrequalthis VARCHAR(2000), @Azionecodequalthis VARCHAR(255), @Azionedescrequalthis VARCHAR(2000), @Interventocodequalthis VARCHAR(255), @Interventodescrequalthis VARCHAR(2000), @Ragionesocialeequalthis VARCHAR(255), @Partitaivacfequalthis VARCHAR(255), @Tipoproceduraequalthis VARCHAR(255), @CupNaturaequalthis VARCHAR(255), @Codicetitolaritaregiaequalthis VARCHAR(255), @Datapubblicazionebandoequalthis DATETIME, @Attopubblicazionebandoequalthis INT, @Attopubblicazionebandonumequalthis INT, @Attopubblicazionebandodataequalthis DATETIME, @Attopubblicazionebandoregistroequalthis VARCHAR(255), @Attopubblicazionebandoburequalthis INT, @Attopubblicazionebandoburdataequalthis DATETIME, @Segnaturadomandaequalthis VARCHAR(255), @Domandadataequalthis DATETIME, @Segnaturavalutazionecomitatoequalthis VARCHAR(255), @Datavalutazionecomitatoequalthis DATETIME, @Segnaturavalutazionevariantecomitatoequalthis VARCHAR(255), @Datavalutazionevariantecomitatoequalthis DATETIME, @Attodecretograduatoriaequalthis INT, @Attodecretograduatorianumequalthis INT, @Attodecretograduatoriadataequalthis DATETIME, @Attodecretograduatoriaregistroequalthis VARCHAR(255), @Attodecretograduatoriaindividualeequalthis INT, @Attodecretograduatoriaindividualenumequalthis INT, @Attodecretograduatoriaindividualedataequalthis DATETIME, @Attodecretograduatoriaindividualeregistroequalthis VARCHAR(255), @Segnaturagraduatoriaequalthis VARCHAR(255), @Datagraduatoriaequalthis DATETIME',@Idbandoequalthis , @Descrizionebandoequalthis , @Idprogettoequalthis , @Assecodequalthis , @Assedescrequalthis , @Azionecodequalthis , @Azionedescrequalthis , @Interventocodequalthis , @Interventodescrequalthis , @Ragionesocialeequalthis , @Partitaivacfequalthis , @Tipoproceduraequalthis , @CupNaturaequalthis , @Codicetitolaritaregiaequalthis , @Datapubblicazionebandoequalthis , @Attopubblicazionebandoequalthis , @Attopubblicazionebandonumequalthis , @Attopubblicazionebandodataequalthis , @Attopubblicazionebandoregistroequalthis , @Attopubblicazionebandoburequalthis , @Attopubblicazionebandoburdataequalthis , @Segnaturadomandaequalthis , @Domandadataequalthis , @Segnaturavalutazionecomitatoequalthis , @Datavalutazionecomitatoequalthis , @Segnaturavalutazionevariantecomitatoequalthis , @Datavalutazionevariantecomitatoequalthis , @Attodecretograduatoriaequalthis , @Attodecretograduatorianumequalthis , @Attodecretograduatoriadataequalthis , @Attodecretograduatoriaregistroequalthis , @Attodecretograduatoriaindividualeequalthis , @Attodecretograduatoriaindividualenumequalthis , @Attodecretograduatoriaindividualedataequalthis , @Attodecretograduatoriaindividualeregistroequalthis , @Segnaturagraduatoriaequalthis , @Datagraduatoriaequalthis ;
	else
		SELECT IdBando, DescrizioneBando, IdProgetto, AsseCod, AsseDescr, AzioneCod, AzioneDescr, InterventoCod, InterventoDescr, RagioneSociale, PartitaIvaCF, TipoProcedura, CUP_NATURA, CodiceTitolaritaRegia, DataPubblicazioneBando, AttoPubblicazioneBando, AttoPubblicazioneBandoNum, AttoPubblicazioneBandoData, AttoPubblicazioneBandoRegistro, AttoPubblicazioneBandoBur, AttoPubblicazioneBandoBurData, SegnaturaDomanda, DomandaData, SegnaturaValutazioneComitato, DataValutazioneComitato, SegnaturaValutazioneVarianteComitato, DataValutazioneVarianteComitato, AttoDecretoGraduatoria, AttoDecretoGraduatoriaNum, AttoDecretoGraduatoriaData, AttoDecretoGraduatoriaRegistro, AttoDecretoGraduatoriaIndividuale, AttoDecretoGraduatoriaIndividualeNum, AttoDecretoGraduatoriaIndividualeData, AttoDecretoGraduatoriaIndividualeRegistro, SegnaturaGraduatoria, DataGraduatoria
		FROM vPISTA_CONTROLLO
		WHERE 
			((@Idbandoequalthis IS NULL) OR IdBando = @Idbandoequalthis) AND 
			((@Descrizionebandoequalthis IS NULL) OR DescrizioneBando = @Descrizionebandoequalthis) AND 
			((@Idprogettoequalthis IS NULL) OR IdProgetto = @Idprogettoequalthis) AND 
			((@Assecodequalthis IS NULL) OR AsseCod = @Assecodequalthis) AND 
			((@Assedescrequalthis IS NULL) OR AsseDescr = @Assedescrequalthis) AND 
			((@Azionecodequalthis IS NULL) OR AzioneCod = @Azionecodequalthis) AND 
			((@Azionedescrequalthis IS NULL) OR AzioneDescr = @Azionedescrequalthis) AND 
			((@Interventocodequalthis IS NULL) OR InterventoCod = @Interventocodequalthis) AND 
			((@Interventodescrequalthis IS NULL) OR InterventoDescr = @Interventodescrequalthis) AND 
			((@Ragionesocialeequalthis IS NULL) OR RagioneSociale = @Ragionesocialeequalthis) AND 
			((@Partitaivacfequalthis IS NULL) OR PartitaIvaCF = @Partitaivacfequalthis) AND 
			((@Tipoproceduraequalthis IS NULL) OR TipoProcedura = @Tipoproceduraequalthis) AND 
			((@CupNaturaequalthis IS NULL) OR CUP_NATURA = @CupNaturaequalthis) AND 
			((@Codicetitolaritaregiaequalthis IS NULL) OR CodiceTitolaritaRegia = @Codicetitolaritaregiaequalthis) AND 
			((@Datapubblicazionebandoequalthis IS NULL) OR DataPubblicazioneBando = @Datapubblicazionebandoequalthis) AND 
			((@Attopubblicazionebandoequalthis IS NULL) OR AttoPubblicazioneBando = @Attopubblicazionebandoequalthis) AND 
			((@Attopubblicazionebandonumequalthis IS NULL) OR AttoPubblicazioneBandoNum = @Attopubblicazionebandonumequalthis) AND 
			((@Attopubblicazionebandodataequalthis IS NULL) OR AttoPubblicazioneBandoData = @Attopubblicazionebandodataequalthis) AND 
			((@Attopubblicazionebandoregistroequalthis IS NULL) OR AttoPubblicazioneBandoRegistro = @Attopubblicazionebandoregistroequalthis) AND 
			((@Attopubblicazionebandoburequalthis IS NULL) OR AttoPubblicazioneBandoBur = @Attopubblicazionebandoburequalthis) AND 
			((@Attopubblicazionebandoburdataequalthis IS NULL) OR AttoPubblicazioneBandoBurData = @Attopubblicazionebandoburdataequalthis) AND 
			((@Segnaturadomandaequalthis IS NULL) OR SegnaturaDomanda = @Segnaturadomandaequalthis) AND 
			((@Domandadataequalthis IS NULL) OR DomandaData = @Domandadataequalthis) AND 
			((@Segnaturavalutazionecomitatoequalthis IS NULL) OR SegnaturaValutazioneComitato = @Segnaturavalutazionecomitatoequalthis) AND 
			((@Datavalutazionecomitatoequalthis IS NULL) OR DataValutazioneComitato = @Datavalutazionecomitatoequalthis) AND 
			((@Segnaturavalutazionevariantecomitatoequalthis IS NULL) OR SegnaturaValutazioneVarianteComitato = @Segnaturavalutazionevariantecomitatoequalthis) AND 
			((@Datavalutazionevariantecomitatoequalthis IS NULL) OR DataValutazioneVarianteComitato = @Datavalutazionevariantecomitatoequalthis) AND 
			((@Attodecretograduatoriaequalthis IS NULL) OR AttoDecretoGraduatoria = @Attodecretograduatoriaequalthis) AND 
			((@Attodecretograduatorianumequalthis IS NULL) OR AttoDecretoGraduatoriaNum = @Attodecretograduatorianumequalthis) AND 
			((@Attodecretograduatoriadataequalthis IS NULL) OR AttoDecretoGraduatoriaData = @Attodecretograduatoriadataequalthis) AND 
			((@Attodecretograduatoriaregistroequalthis IS NULL) OR AttoDecretoGraduatoriaRegistro = @Attodecretograduatoriaregistroequalthis) AND 
			((@Attodecretograduatoriaindividualeequalthis IS NULL) OR AttoDecretoGraduatoriaIndividuale = @Attodecretograduatoriaindividualeequalthis) AND 
			((@Attodecretograduatoriaindividualenumequalthis IS NULL) OR AttoDecretoGraduatoriaIndividualeNum = @Attodecretograduatoriaindividualenumequalthis) AND 
			((@Attodecretograduatoriaindividualedataequalthis IS NULL) OR AttoDecretoGraduatoriaIndividualeData = @Attodecretograduatoriaindividualedataequalthis) AND 
			((@Attodecretograduatoriaindividualeregistroequalthis IS NULL) OR AttoDecretoGraduatoriaIndividualeRegistro = @Attodecretograduatoriaindividualeregistroequalthis) AND 
			((@Segnaturagraduatoriaequalthis IS NULL) OR SegnaturaGraduatoria = @Segnaturagraduatoriaequalthis) AND 
			((@Datagraduatoriaequalthis IS NULL) OR DataGraduatoria = @Datagraduatoriaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZVpistaControlloFindSelect]
(
	@Idbandoequalthis INT, 
	@Descrizionebandoequalthis VARCHAR(2000), 
	@Idprogettoequalthis INT, 
	@Assecodequalthis VARCHAR(255), 
	@Assedescrequalthis VARCHAR(2000), 
	@Azionecodequalthis VARCHAR(255), 
	@Azionedescrequalthis VARCHAR(2000), 
	@Interventocodequalthis VARCHAR(255), 
	@Interventodescrequalthis VARCHAR(2000), 
	@Ragionesocialeequalthis VARCHAR(255), 
	@Partitaivacfequalthis VARCHAR(255), 
	@Tipoproceduraequalthis VARCHAR(255), 
	@CupNaturaequalthis VARCHAR(255), 
	@Codicetitolaritaregiaequalthis VARCHAR(255), 
	@Datapubblicazionebandoequalthis DATETIME, 
	@Attopubblicazionebandoequalthis INT, 
	@Attopubblicazionebandonumequalthis INT, 
	@Attopubblicazionebandodataequalthis DATETIME, 
	@Attopubblicazionebandoregistroequalthis VARCHAR(255), 
	@Segnaturadomandaequalthis VARCHAR(255), 
	@Domandadataequalthis DATETIME, 
	@Segnaturavalutazionecomitatoequalthis VARCHAR(255), 
	@Datavalutazionecomitatoequalthis DATETIME, 
	@Segnaturavalutazionevariantecomitatoequalthis VARCHAR(255), 
	@Datavalutazionevariantecomitatoequalthis DATETIME, 
	@Attodecretograduatoriaequalthis INT, 
	@Attodecretograduatorianumequalthis INT, 
	@Attodecretograduatoriadataequalthis DATETIME, 
	@Attodecretograduatoriaregistroequalthis VARCHAR(255), 
	@Attodecretograduatoriaindividualeequalthis INT, 
	@Attodecretograduatoriaindividualenumequalthis INT, 
	@Attodecretograduatoriaindividualedataequalthis DATETIME, 
	@Attodecretograduatoriaindividualeregistroequalthis VARCHAR(255), 
	@Segnaturagraduatoriaequalthis VARCHAR(255), 
	@Datagraduatoriaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT IdBando, DescrizioneBando, IdProgetto, AsseCod, AsseDescr, AzioneCod, AzioneDescr, InterventoCod, InterventoDescr, RagioneSociale, PartitaIvaCF, TipoProcedura, CUP_NATURA, CodiceTitolaritaRegia, DataPubblicazioneBando, AttoPubblicazioneBando, AttoPubblicazioneBandoNum, AttoPubblicazioneBandoData, AttoPubblicazioneBandoRegistro, SegnaturaDomanda, DomandaData, SegnaturaValutazioneComitato, DataValutazioneComitato, SegnaturaValutazioneVarianteComitato, DataValutazioneVarianteComitato, AttoDecretoGraduatoria, AttoDecretoGraduatoriaNum, AttoDecretoGraduatoriaData, AttoDecretoGraduatoriaRegistro, AttoDecretoGraduatoriaIndividuale, AttoDecretoGraduatoriaIndividualeNum, AttoDecretoGraduatoriaIndividualeData, AttoDecretoGraduatoriaIndividualeRegistro, SegnaturaGraduatoria, DataGraduatoria FROM vPISTA_CONTROLLO WHERE 1=1'';
	IF (@Idbandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IdBando = @Idbandoequalthis)''; set @lensql=@lensql+len(@Idbandoequalthis);end;
	IF (@Descrizionebandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DescrizioneBando = @Descrizionebandoequalthis)''; set @lensql=@lensql+len(@Descrizionebandoequalthis);end;
	IF (@Idprogettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IdProgetto = @Idprogettoequalthis)''; set @lensql=@lensql+len(@Idprogettoequalthis);end;
	IF (@Assecodequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AsseCod = @Assecodequalthis)''; set @lensql=@lensql+len(@Assecodequalthis);end;
	IF (@Assedescrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AsseDescr = @Assedescrequalthis)''; set @lensql=@lensql+len(@Assedescrequalthis);end;
	IF (@Azionecodequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AzioneCod = @Azionecodequalthis)''; set @lensql=@lensql+len(@Azionecodequalthis);end;
	IF (@Azionedescrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AzioneDescr = @Azionedescrequalthis)''; set @lensql=@lensql+len(@Azionedescrequalthis);end;
	IF (@Interventocodequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (InterventoCod = @Interventocodequalthis)''; set @lensql=@lensql+len(@Interventocodequalthis);end;
	IF (@Interventodescrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (InterventoDescr = @Interventodescrequalthis)''; set @lensql=@lensql', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVpistaControlloFindSelect';

