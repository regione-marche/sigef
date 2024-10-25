using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VistruttoriaDomandeDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class VistruttoriaDomandeDAL
	{

		//Operazioni

		//getFromDatareader
		public static VistruttoriaDomande GetFromDatareader(DbProvider db)
		{
			VistruttoriaDomande VistruttoriaDomandeObj = new VistruttoriaDomande();
			VistruttoriaDomandeObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VistruttoriaDomandeObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VistruttoriaDomandeObj.IdProgIntegrato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROG_INTEGRATO"]);
			VistruttoriaDomandeObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			VistruttoriaDomandeObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
			VistruttoriaDomandeObj.Cuaa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA"]);
			VistruttoriaDomandeObj.PartitaIva = new SiarLibrary.NullTypes.StringNT(db.DataReader["PARTITA_IVA"]);
			VistruttoriaDomandeObj.RagioneSociale = new SiarLibrary.NullTypes.StringNT(db.DataReader["RAGIONE_SOCIALE"]);
			VistruttoriaDomandeObj.Comune = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMUNE"]);
			VistruttoriaDomandeObj.Sigla = new SiarLibrary.NullTypes.StringNT(db.DataReader["SIGLA"]);
			VistruttoriaDomandeObj.Cap = new SiarLibrary.NullTypes.StringNT(db.DataReader["CAP"]);
			VistruttoriaDomandeObj.Istruttore = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE"]);
			VistruttoriaDomandeObj.ProvinciaAssegnazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_ASSEGNAZIONE"]);
			VistruttoriaDomandeObj.SelezionataXRevisione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["SELEZIONATA_X_REVISIONE"]);
			VistruttoriaDomandeObj.ProvinciaDiPresentazione = new SiarLibrary.NullTypes.StringNT(db.DataReader["PROVINCIA_DI_PRESENTAZIONE"]);
			VistruttoriaDomandeObj.IdIstruttore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTRUTTORE"]);
			VistruttoriaDomandeObj.Via = new SiarLibrary.NullTypes.StringNT(db.DataReader["VIA"]);
			VistruttoriaDomandeObj.SegnaturaRi = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_RI"]);
			VistruttoriaDomandeObj.FiltroStatoIstruttoria = new SiarLibrary.NullTypes.StringNT(db.DataReader["FILTRO_STATO_ISTRUTTORIA"]);
			VistruttoriaDomandeObj.OrdineStato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_STATO"]);
			VistruttoriaDomandeObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VistruttoriaDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VistruttoriaDomandeObj.IsDirty = false;
			VistruttoriaDomandeObj.IsPersistent = true;
			return VistruttoriaDomandeObj;
		}

		//Find Select

		public static VistruttoriaDomandeCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgIntegratoEqualThis, 
SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.StringNT StatoEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, 
SiarLibrary.NullTypes.StringNT PartitaIvaEqualThis, SiarLibrary.NullTypes.StringNT RagioneSocialeEqualThis, SiarLibrary.NullTypes.StringNT ComuneEqualThis, 
SiarLibrary.NullTypes.StringNT SiglaEqualThis, SiarLibrary.NullTypes.StringNT CapEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreEqualThis, 
SiarLibrary.NullTypes.StringNT ProvinciaAssegnazioneEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis, SiarLibrary.NullTypes.StringNT ProvinciaDiPresentazioneEqualThis, 
SiarLibrary.NullTypes.IntNT IdIstruttoreEqualThis, SiarLibrary.NullTypes.StringNT ViaEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaRiEqualThis, 
SiarLibrary.NullTypes.StringNT FiltroStatoIstruttoriaEqualThis, SiarLibrary.NullTypes.IntNT OrdineStatoEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis)

		{

			VistruttoriaDomandeCollection VistruttoriaDomandeCollectionObj = new VistruttoriaDomandeCollection();

			IDbCommand findCmd = db.InitCmd("Zvistruttoriadomandefindselect", new string[] {"IdProgettoequalthis", "IdBandoequalthis", "IdProgIntegratoequalthis", 
"CodStatoequalthis", "Statoequalthis", "Cuaaequalthis", 
"PartitaIvaequalthis", "RagioneSocialeequalthis", "Comuneequalthis", 
"Siglaequalthis", "Capequalthis", "Istruttoreequalthis", 
"ProvinciaAssegnazioneequalthis", "SelezionataXRevisioneequalthis", "ProvinciaDiPresentazioneequalthis", 
"IdIstruttoreequalthis", "Viaequalthis", "SegnaturaRiequalthis", 
"FiltroStatoIstruttoriaequalthis", "OrdineStatoequalthis", "IdImpresaequalthis"}, new string[] {"int", "int", "int", 
"string", "string", "string", 
"string", "string", "string", 
"string", "string", "string", 
"string", "bool", "string", 
"int", "string", "string", 
"string", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgIntegratoequalthis", IdProgIntegratoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "PartitaIvaequalthis", PartitaIvaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialeequalthis", RagioneSocialeEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Comuneequalthis", ComuneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Siglaequalthis", SiglaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Capequalthis", CapEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Istruttoreequalthis", IstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProvinciaAssegnazioneequalthis", ProvinciaAssegnazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SelezionataXRevisioneequalthis", SelezionataXRevisioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProvinciaDiPresentazioneequalthis", ProvinciaDiPresentazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstruttoreequalthis", IdIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Viaequalthis", ViaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaRiequalthis", SegnaturaRiEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FiltroStatoIstruttoriaequalthis", FiltroStatoIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineStatoequalthis", OrdineStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			VistruttoriaDomande VistruttoriaDomandeObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VistruttoriaDomandeObj = GetFromDatareader(db);
				VistruttoriaDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VistruttoriaDomandeObj.IsDirty = false;
				VistruttoriaDomandeObj.IsPersistent = true;
				VistruttoriaDomandeCollectionObj.Add(VistruttoriaDomandeObj);
			}
			db.Close();
			return VistruttoriaDomandeCollectionObj;
		}

		//Find Find

		public static VistruttoriaDomandeCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, SiarLibrary.NullTypes.IntNT IdIstruttoreEqualThis, 
SiarLibrary.NullTypes.StringNT ProvinciaAssegnazioneEqualThis, SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT CuaaEqualThis, 
SiarLibrary.NullTypes.StringNT RagioneSocialeLikeThis, SiarLibrary.NullTypes.StringNT FiltroStatoIstruttoriaEqualThis, SiarLibrary.NullTypes.BoolNT SelezionataXRevisioneEqualThis)

		{

			VistruttoriaDomandeCollection VistruttoriaDomandeCollectionObj = new VistruttoriaDomandeCollection();

			IDbCommand findCmd = db.InitCmd("Zvistruttoriadomandefindfind", new string[] {"IdBandoequalthis", "IdProgettoequalthis", "IdIstruttoreequalthis", 
"ProvinciaAssegnazioneequalthis", "IdImpresaequalthis", "Cuaaequalthis", 
"RagioneSocialelikethis", "FiltroStatoIstruttoriaequalthis", "SelezionataXRevisioneequalthis"}, new string[] {"int", "int", "int", 
"string", "int", "string", 
"string", "string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstruttoreequalthis", IdIstruttoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ProvinciaAssegnazioneequalthis", ProvinciaAssegnazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Cuaaequalthis", CuaaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "RagioneSocialelikethis", RagioneSocialeLikeThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "FiltroStatoIstruttoriaequalthis", FiltroStatoIstruttoriaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SelezionataXRevisioneequalthis", SelezionataXRevisioneEqualThis);
			VistruttoriaDomande VistruttoriaDomandeObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VistruttoriaDomandeObj = GetFromDatareader(db);
				VistruttoriaDomandeObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VistruttoriaDomandeObj.IsDirty = false;
				VistruttoriaDomandeObj.IsPersistent = true;
				VistruttoriaDomandeCollectionObj.Add(VistruttoriaDomandeObj);
			}
			db.Close();
			return VistruttoriaDomandeCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vISTRUTTORIA_DOMANDE>
  <ViewName>vISTRUTTORIA_DOMANDE</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID_PROGETTO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_ISTRUTTORE>Equal</ID_ISTRUTTORE>
      <PROVINCIA_ASSEGNAZIONE>Equal</PROVINCIA_ASSEGNAZIONE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
      <FILTRO_STATO_ISTRUTTORIA>Equal</FILTRO_STATO_ISTRUTTORIA>
      <SELEZIONATA_X_REVISIONE>Equal</SELEZIONATA_X_REVISIONE>
    </Find>
  </Finds>
  <Filters>
    <FiltroIstruttoria>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_ISTRUTTORE>Equal</ID_ISTRUTTORE>
      <PROVINCIA_ASSEGNAZIONE>Equal</PROVINCIA_ASSEGNAZIONE>
      <FILTRO_STATO_ISTRUTTORIA>Equal</FILTRO_STATO_ISTRUTTORIA>
      <CUAA>Equal</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
    </FiltroIstruttoria>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vISTRUTTORIA_DOMANDE>
*/