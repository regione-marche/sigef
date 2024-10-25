CREATE PROCEDURE [dbo].[ZVpistaControlloFindFind]
(
	@Idprogettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT IdBando, DescrizioneBando, IdProgetto, AsseCod, AsseDescr, AzioneCod, AzioneDescr, InterventoCod, InterventoDescr, RagioneSociale, PartitaIvaCF, TipoProcedura, CUP_NATURA, CodiceTitolaritaRegia, DataPubblicazioneBando, AttoPubblicazioneBando, AttoPubblicazioneBandoNum, AttoPubblicazioneBandoData, AttoPubblicazioneBandoRegistro, AttoPubblicazioneBandoBur, AttoPubblicazioneBandoBurData, SegnaturaDomanda, DomandaData, SegnaturaValutazioneComitato, DataValutazioneComitato, SegnaturaValutazioneVarianteComitato, DataValutazioneVarianteComitato, AttoDecretoGraduatoria, AttoDecretoGraduatoriaNum, AttoDecretoGraduatoriaData, AttoDecretoGraduatoriaRegistro, AttoDecretoGraduatoriaIndividuale, AttoDecretoGraduatoriaIndividualeNum, AttoDecretoGraduatoriaIndividualeData, AttoDecretoGraduatoriaIndividualeRegistro, SegnaturaGraduatoria, DataGraduatoria FROM vPISTA_CONTROLLO WHERE 1=1';
	IF (@Idprogettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IdProgetto = @Idprogettoequalthis)'; set @lensql=@lensql+len(@Idprogettoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idprogettoequalthis INT',@Idprogettoequalthis ;
	else
		SELECT IdBando, DescrizioneBando, IdProgetto, AsseCod, AsseDescr, AzioneCod, AzioneDescr, InterventoCod, InterventoDescr, RagioneSociale, PartitaIvaCF, TipoProcedura, CUP_NATURA, CodiceTitolaritaRegia, DataPubblicazioneBando, AttoPubblicazioneBando, AttoPubblicazioneBandoNum, AttoPubblicazioneBandoData, AttoPubblicazioneBandoRegistro, AttoPubblicazioneBandoBur, AttoPubblicazioneBandoBurData, SegnaturaDomanda, DomandaData, SegnaturaValutazioneComitato, DataValutazioneComitato, SegnaturaValutazioneVarianteComitato, DataValutazioneVarianteComitato, AttoDecretoGraduatoria, AttoDecretoGraduatoriaNum, AttoDecretoGraduatoriaData, AttoDecretoGraduatoriaRegistro, AttoDecretoGraduatoriaIndividuale, AttoDecretoGraduatoriaIndividualeNum, AttoDecretoGraduatoriaIndividualeData, AttoDecretoGraduatoriaIndividualeRegistro, SegnaturaGraduatoria, DataGraduatoria
		FROM vPISTA_CONTROLLO
		WHERE 
			((@Idprogettoequalthis IS NULL) OR IdProgetto = @Idprogettoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZVpistaControlloFindFind]
(
	@Idprogettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT IdBando, DescrizioneBando, IdProgetto, AsseCod, AsseDescr, AzioneCod, AzioneDescr, InterventoCod, InterventoDescr, RagioneSociale, PartitaIvaCF, TipoProcedura, CUP_NATURA, CodiceTitolaritaRegia, DataPubblicazioneBando, AttoPubblicazioneBando, AttoPubblicazioneBandoNum, AttoPubblicazioneBandoData, AttoPubblicazioneBandoRegistro, SegnaturaDomanda, DomandaData, SegnaturaValutazioneComitato, DataValutazioneComitato, SegnaturaValutazioneVarianteComitato, DataValutazioneVarianteComitato, AttoDecretoGraduatoria, AttoDecretoGraduatoriaNum, AttoDecretoGraduatoriaData, AttoDecretoGraduatoriaRegistro, AttoDecretoGraduatoriaIndividuale, AttoDecretoGraduatoriaIndividualeNum, AttoDecretoGraduatoriaIndividualeData, AttoDecretoGraduatoriaIndividualeRegistro, SegnaturaGraduatoria, DataGraduatoria FROM vPISTA_CONTROLLO WHERE 1=1'';
	IF (@Idprogettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IdProgetto = @Idprogettoequalthis)''; set @lensql=@lensql+len(@Idprogettoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idprogettoequalthis INT'',@Idprogettoequalthis ;
	else
		SELECT IdBando, DescrizioneBando, IdProgetto, AsseCod, AsseDescr, AzioneCod, AzioneDescr, InterventoCod, InterventoDescr, RagioneSociale, PartitaIvaCF, TipoProcedura, CUP_NATURA, CodiceTitolaritaRegia, DataPubblicazioneBando, AttoPubblicazioneBando, AttoPubblicazioneBandoNum, AttoPubblicazioneBandoData, AttoPubblicazioneBandoRegistro, SegnaturaDomanda, DomandaData, SegnaturaValutazioneComitato, DataValutazioneComitato, SegnaturaValutazioneVarianteComitato, DataValutazioneVarianteComitato, AttoDecretoGraduatoria, AttoDecretoGraduatoriaNum, AttoDecretoGraduatoriaData, AttoDecretoGraduatoriaRegistro, AttoDecretoGraduatoriaIndividuale, AttoDecretoGraduatoriaIndividualeNum, AttoDecretoGraduatoriaIndividualeData, AttoDecretoGraduatoriaIndividualeRegistro, SegnaturaGraduatoria, DataGraduatoria
		FROM vPISTA_CONTROLLO
		WHERE 
			((@Idprogettoequalthis IS NULL) OR IdProgetto = @Idprogettoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVpistaControlloFindFind';

