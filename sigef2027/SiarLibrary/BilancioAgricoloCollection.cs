using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for BilancioAgricoloCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BilancioAgricoloCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count",this.Count);
			for(int i=0;i<this.Count;i++)
			{
				info.AddValue(i.ToString(),this[i]);
			}
		}
		private BilancioAgricoloCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BilancioAgricolo) info.GetValue(i.ToString(),typeof(BilancioAgricolo)));
			}
		}

		//Costruttore
		public BilancioAgricoloCollection()
		{
			this.ItemType = typeof(BilancioAgricolo);
		}

		//Costruttore con provider
		public BilancioAgricoloCollection(IBilancioAgricoloProvider providerObj)
		{
			this.ItemType = typeof(BilancioAgricolo);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BilancioAgricolo this[int index]
		{
			get { return (BilancioAgricolo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BilancioAgricoloCollection GetChanges()
		{
			return (BilancioAgricoloCollection) base.GetChanges();
		}

		[NonSerialized] private IBilancioAgricoloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBilancioAgricoloProvider Provider
		{
			get {return _provider;}
			set 
			{ 
				_provider = value;
				for (int i = 0; i < this.Count; i++)
				{
					this[i].Provider = value;
				}
			} 
		}

		public int SaveCollection()
		{
			return _provider.SaveCollection(this);
		}
		public int DeleteCollection()
		{
			return _provider.DeleteCollection(this);
		}
		//Add
		public int Add(BilancioAgricolo BilancioAgricoloObj)
		{
			if (BilancioAgricoloObj.Provider == null) BilancioAgricoloObj.Provider = this.Provider;
			return base.Add(BilancioAgricoloObj);
		}

		//AddCollection
		public void AddCollection(BilancioAgricoloCollection BilancioAgricoloCollectionObj)
		{
			foreach (BilancioAgricolo BilancioAgricoloObj in BilancioAgricoloCollectionObj)
				this.Add(BilancioAgricoloObj);
		}

		//Insert
		public void Insert(int index, BilancioAgricolo BilancioAgricoloObj)
		{
			if (BilancioAgricoloObj.Provider == null) BilancioAgricoloObj.Provider = this.Provider;
			base.Insert(index, BilancioAgricoloObj);
		}

		//CollectionGetById
		public BilancioAgricolo CollectionGetById(NullTypes.IntNT IdBilancioAgricoloValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBilancioAgricolo == IdBilancioAgricoloValue))
					find = true;
				else
					i++;
			}
			if (find)
				return this[i];
			else
				return null;
		}
		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BilancioAgricoloCollection SubSelect(NullTypes.IntNT IdBilancioAgricoloEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.IntNT AnnoEqualThis, NullTypes.DatetimeNT DataBilancioEqualThis, NullTypes.BoolNT PrevisionaleEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.DecimalNT PlvRicaviNettiEqualThis, NullTypes.DecimalNT PlvRicaviAttivitaEqualThis, 
NullTypes.DecimalNT PlvRimanenzeFinaliEqualThis, NullTypes.DecimalNT PlvRimanenzeInizialiEqualThis, NullTypes.DecimalNT VaCostiMatPrimeEqualThis, 
NullTypes.DecimalNT VaCostiAttConnesseEqualThis, NullTypes.DecimalNT VaNoleggiEqualThis, NullTypes.DecimalNT VaManutenzioniEqualThis, 
NullTypes.DecimalNT VaSpeseGeneraliEqualThis, NullTypes.DecimalNT VaAffittiEqualThis, NullTypes.DecimalNT VaAltriCostiEqualThis, 
NullTypes.DecimalNT PnAmmMacchineEqualThis, NullTypes.DecimalNT PnAmmFabbricatiEqualThis, NullTypes.DecimalNT PnAmmPiantagioniEqualThis, 
NullTypes.DecimalNT RoSalariEqualThis, NullTypes.DecimalNT RoOneriEqualThis, NullTypes.DecimalNT RnPacRicaviEqualThis, 
NullTypes.DecimalNT RnPacCostiEqualThis, NullTypes.DecimalNT RnPacProventiEqualThis, NullTypes.DecimalNT RnPacPerditeEqualThis, 
NullTypes.DecimalNT RnPacInteressiAttiviEqualThis, NullTypes.DecimalNT RnPacInteressiPassiviEqualThis, NullTypes.DecimalNT RnPacImposteEqualThis, 
NullTypes.DecimalNT RnPacContributiPacEqualThis, NullTypes.DecimalNT MnlRedditiFamEqualThis, NullTypes.DecimalNT MnlRimborsoEqualThis, 
NullTypes.DecimalNT MnlPrelieviEqualThis, NullTypes.DecimalNT CfCfTerreniEqualThis, NullTypes.DecimalNT CfCfImpiantiEqualThis, 
NullTypes.DecimalNT CfCfPiantagioniEqualThis, NullTypes.DecimalNT CfCfMiglioramentiEqualThis, NullTypes.DecimalNT CfCaMacchineEqualThis, 
NullTypes.DecimalNT CfCaBestiameEqualThis, NullTypes.DecimalNT CfIfPartecipazioniEqualThis, NullTypes.DecimalNT CcDfRimanenzeEqualThis, 
NullTypes.DecimalNT CcDfAnticipazioniEqualThis, NullTypes.DecimalNT CcLdCreditiEqualThis, NullTypes.DecimalNT CcLiBancaEqualThis, 
NullTypes.DecimalNT CcLiCassaEqualThis, NullTypes.DecimalNT FfPcDebitiBreveTermineEqualThis, NullTypes.DecimalNT FfPcFornitoriEqualThis, 
NullTypes.DecimalNT FfPcDebitiEqualThis, NullTypes.DecimalNT FfPcMutuiEqualThis, NullTypes.DecimalNT FfMpCapitaleEqualThis, 
NullTypes.DecimalNT FfMpRiserveEqualThis, NullTypes.DecimalNT FfMpUtileEqualThis)
		{
			BilancioAgricoloCollection BilancioAgricoloCollectionTemp = new BilancioAgricoloCollection();
			foreach (BilancioAgricolo BilancioAgricoloItem in this)
			{
				if (((IdBilancioAgricoloEqualThis == null) || ((BilancioAgricoloItem.IdBilancioAgricolo != null) && (BilancioAgricoloItem.IdBilancioAgricolo.Value == IdBilancioAgricoloEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((BilancioAgricoloItem.IdImpresa != null) && (BilancioAgricoloItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((BilancioAgricoloItem.IdProgetto != null) && (BilancioAgricoloItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((AnnoEqualThis == null) || ((BilancioAgricoloItem.Anno != null) && (BilancioAgricoloItem.Anno.Value == AnnoEqualThis.Value))) && ((DataBilancioEqualThis == null) || ((BilancioAgricoloItem.DataBilancio != null) && (BilancioAgricoloItem.DataBilancio.Value == DataBilancioEqualThis.Value))) && ((PrevisionaleEqualThis == null) || ((BilancioAgricoloItem.Previsionale != null) && (BilancioAgricoloItem.Previsionale.Value == PrevisionaleEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((BilancioAgricoloItem.DataModifica != null) && (BilancioAgricoloItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((PlvRicaviNettiEqualThis == null) || ((BilancioAgricoloItem.PlvRicaviNetti != null) && (BilancioAgricoloItem.PlvRicaviNetti.Value == PlvRicaviNettiEqualThis.Value))) && ((PlvRicaviAttivitaEqualThis == null) || ((BilancioAgricoloItem.PlvRicaviAttivita != null) && (BilancioAgricoloItem.PlvRicaviAttivita.Value == PlvRicaviAttivitaEqualThis.Value))) && 
((PlvRimanenzeFinaliEqualThis == null) || ((BilancioAgricoloItem.PlvRimanenzeFinali != null) && (BilancioAgricoloItem.PlvRimanenzeFinali.Value == PlvRimanenzeFinaliEqualThis.Value))) && ((PlvRimanenzeInizialiEqualThis == null) || ((BilancioAgricoloItem.PlvRimanenzeIniziali != null) && (BilancioAgricoloItem.PlvRimanenzeIniziali.Value == PlvRimanenzeInizialiEqualThis.Value))) && ((VaCostiMatPrimeEqualThis == null) || ((BilancioAgricoloItem.VaCostiMatPrime != null) && (BilancioAgricoloItem.VaCostiMatPrime.Value == VaCostiMatPrimeEqualThis.Value))) && 
((VaCostiAttConnesseEqualThis == null) || ((BilancioAgricoloItem.VaCostiAttConnesse != null) && (BilancioAgricoloItem.VaCostiAttConnesse.Value == VaCostiAttConnesseEqualThis.Value))) && ((VaNoleggiEqualThis == null) || ((BilancioAgricoloItem.VaNoleggi != null) && (BilancioAgricoloItem.VaNoleggi.Value == VaNoleggiEqualThis.Value))) && ((VaManutenzioniEqualThis == null) || ((BilancioAgricoloItem.VaManutenzioni != null) && (BilancioAgricoloItem.VaManutenzioni.Value == VaManutenzioniEqualThis.Value))) && 
((VaSpeseGeneraliEqualThis == null) || ((BilancioAgricoloItem.VaSpeseGenerali != null) && (BilancioAgricoloItem.VaSpeseGenerali.Value == VaSpeseGeneraliEqualThis.Value))) && ((VaAffittiEqualThis == null) || ((BilancioAgricoloItem.VaAffitti != null) && (BilancioAgricoloItem.VaAffitti.Value == VaAffittiEqualThis.Value))) && ((VaAltriCostiEqualThis == null) || ((BilancioAgricoloItem.VaAltriCosti != null) && (BilancioAgricoloItem.VaAltriCosti.Value == VaAltriCostiEqualThis.Value))) && 
((PnAmmMacchineEqualThis == null) || ((BilancioAgricoloItem.PnAmmMacchine != null) && (BilancioAgricoloItem.PnAmmMacchine.Value == PnAmmMacchineEqualThis.Value))) && ((PnAmmFabbricatiEqualThis == null) || ((BilancioAgricoloItem.PnAmmFabbricati != null) && (BilancioAgricoloItem.PnAmmFabbricati.Value == PnAmmFabbricatiEqualThis.Value))) && ((PnAmmPiantagioniEqualThis == null) || ((BilancioAgricoloItem.PnAmmPiantagioni != null) && (BilancioAgricoloItem.PnAmmPiantagioni.Value == PnAmmPiantagioniEqualThis.Value))) && 
((RoSalariEqualThis == null) || ((BilancioAgricoloItem.RoSalari != null) && (BilancioAgricoloItem.RoSalari.Value == RoSalariEqualThis.Value))) && ((RoOneriEqualThis == null) || ((BilancioAgricoloItem.RoOneri != null) && (BilancioAgricoloItem.RoOneri.Value == RoOneriEqualThis.Value))) && ((RnPacRicaviEqualThis == null) || ((BilancioAgricoloItem.RnPacRicavi != null) && (BilancioAgricoloItem.RnPacRicavi.Value == RnPacRicaviEqualThis.Value))) && 
((RnPacCostiEqualThis == null) || ((BilancioAgricoloItem.RnPacCosti != null) && (BilancioAgricoloItem.RnPacCosti.Value == RnPacCostiEqualThis.Value))) && ((RnPacProventiEqualThis == null) || ((BilancioAgricoloItem.RnPacProventi != null) && (BilancioAgricoloItem.RnPacProventi.Value == RnPacProventiEqualThis.Value))) && ((RnPacPerditeEqualThis == null) || ((BilancioAgricoloItem.RnPacPerdite != null) && (BilancioAgricoloItem.RnPacPerdite.Value == RnPacPerditeEqualThis.Value))) && 
((RnPacInteressiAttiviEqualThis == null) || ((BilancioAgricoloItem.RnPacInteressiAttivi != null) && (BilancioAgricoloItem.RnPacInteressiAttivi.Value == RnPacInteressiAttiviEqualThis.Value))) && ((RnPacInteressiPassiviEqualThis == null) || ((BilancioAgricoloItem.RnPacInteressiPassivi != null) && (BilancioAgricoloItem.RnPacInteressiPassivi.Value == RnPacInteressiPassiviEqualThis.Value))) && ((RnPacImposteEqualThis == null) || ((BilancioAgricoloItem.RnPacImposte != null) && (BilancioAgricoloItem.RnPacImposte.Value == RnPacImposteEqualThis.Value))) && 
((RnPacContributiPacEqualThis == null) || ((BilancioAgricoloItem.RnPacContributiPac != null) && (BilancioAgricoloItem.RnPacContributiPac.Value == RnPacContributiPacEqualThis.Value))) && ((MnlRedditiFamEqualThis == null) || ((BilancioAgricoloItem.MnlRedditiFam != null) && (BilancioAgricoloItem.MnlRedditiFam.Value == MnlRedditiFamEqualThis.Value))) && ((MnlRimborsoEqualThis == null) || ((BilancioAgricoloItem.MnlRimborso != null) && (BilancioAgricoloItem.MnlRimborso.Value == MnlRimborsoEqualThis.Value))) && 
((MnlPrelieviEqualThis == null) || ((BilancioAgricoloItem.MnlPrelievi != null) && (BilancioAgricoloItem.MnlPrelievi.Value == MnlPrelieviEqualThis.Value))) && ((CfCfTerreniEqualThis == null) || ((BilancioAgricoloItem.CfCfTerreni != null) && (BilancioAgricoloItem.CfCfTerreni.Value == CfCfTerreniEqualThis.Value))) && ((CfCfImpiantiEqualThis == null) || ((BilancioAgricoloItem.CfCfImpianti != null) && (BilancioAgricoloItem.CfCfImpianti.Value == CfCfImpiantiEqualThis.Value))) && 
((CfCfPiantagioniEqualThis == null) || ((BilancioAgricoloItem.CfCfPiantagioni != null) && (BilancioAgricoloItem.CfCfPiantagioni.Value == CfCfPiantagioniEqualThis.Value))) && ((CfCfMiglioramentiEqualThis == null) || ((BilancioAgricoloItem.CfCfMiglioramenti != null) && (BilancioAgricoloItem.CfCfMiglioramenti.Value == CfCfMiglioramentiEqualThis.Value))) && ((CfCaMacchineEqualThis == null) || ((BilancioAgricoloItem.CfCaMacchine != null) && (BilancioAgricoloItem.CfCaMacchine.Value == CfCaMacchineEqualThis.Value))) && 
((CfCaBestiameEqualThis == null) || ((BilancioAgricoloItem.CfCaBestiame != null) && (BilancioAgricoloItem.CfCaBestiame.Value == CfCaBestiameEqualThis.Value))) && ((CfIfPartecipazioniEqualThis == null) || ((BilancioAgricoloItem.CfIfPartecipazioni != null) && (BilancioAgricoloItem.CfIfPartecipazioni.Value == CfIfPartecipazioniEqualThis.Value))) && ((CcDfRimanenzeEqualThis == null) || ((BilancioAgricoloItem.CcDfRimanenze != null) && (BilancioAgricoloItem.CcDfRimanenze.Value == CcDfRimanenzeEqualThis.Value))) && 
((CcDfAnticipazioniEqualThis == null) || ((BilancioAgricoloItem.CcDfAnticipazioni != null) && (BilancioAgricoloItem.CcDfAnticipazioni.Value == CcDfAnticipazioniEqualThis.Value))) && ((CcLdCreditiEqualThis == null) || ((BilancioAgricoloItem.CcLdCrediti != null) && (BilancioAgricoloItem.CcLdCrediti.Value == CcLdCreditiEqualThis.Value))) && ((CcLiBancaEqualThis == null) || ((BilancioAgricoloItem.CcLiBanca != null) && (BilancioAgricoloItem.CcLiBanca.Value == CcLiBancaEqualThis.Value))) && 
((CcLiCassaEqualThis == null) || ((BilancioAgricoloItem.CcLiCassa != null) && (BilancioAgricoloItem.CcLiCassa.Value == CcLiCassaEqualThis.Value))) && ((FfPcDebitiBreveTermineEqualThis == null) || ((BilancioAgricoloItem.FfPcDebitiBreveTermine != null) && (BilancioAgricoloItem.FfPcDebitiBreveTermine.Value == FfPcDebitiBreveTermineEqualThis.Value))) && ((FfPcFornitoriEqualThis == null) || ((BilancioAgricoloItem.FfPcFornitori != null) && (BilancioAgricoloItem.FfPcFornitori.Value == FfPcFornitoriEqualThis.Value))) && 
((FfPcDebitiEqualThis == null) || ((BilancioAgricoloItem.FfPcDebiti != null) && (BilancioAgricoloItem.FfPcDebiti.Value == FfPcDebitiEqualThis.Value))) && ((FfPcMutuiEqualThis == null) || ((BilancioAgricoloItem.FfPcMutui != null) && (BilancioAgricoloItem.FfPcMutui.Value == FfPcMutuiEqualThis.Value))) && ((FfMpCapitaleEqualThis == null) || ((BilancioAgricoloItem.FfMpCapitale != null) && (BilancioAgricoloItem.FfMpCapitale.Value == FfMpCapitaleEqualThis.Value))) && 
((FfMpRiserveEqualThis == null) || ((BilancioAgricoloItem.FfMpRiserve != null) && (BilancioAgricoloItem.FfMpRiserve.Value == FfMpRiserveEqualThis.Value))) && ((FfMpUtileEqualThis == null) || ((BilancioAgricoloItem.FfMpUtile != null) && (BilancioAgricoloItem.FfMpUtile.Value == FfMpUtileEqualThis.Value))))
				{
					BilancioAgricoloCollectionTemp.Add(BilancioAgricoloItem);
				}
			}
			return BilancioAgricoloCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BilancioAgricoloCollection FiltroPrevisionale(NullTypes.BoolNT PrevisionaleEqualThis)
		{
			BilancioAgricoloCollection BilancioAgricoloCollectionTemp = new BilancioAgricoloCollection();
			foreach (BilancioAgricolo BilancioAgricoloItem in this)
			{
				if (((PrevisionaleEqualThis == null) || ((BilancioAgricoloItem.Previsionale != null) && (BilancioAgricoloItem.Previsionale.Value == PrevisionaleEqualThis.Value))))
				{
					BilancioAgricoloCollectionTemp.Add(BilancioAgricoloItem);
				}
			}
			return BilancioAgricoloCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BilancioAgricoloCollection FiltroDataModifica(NullTypes.DatetimeNT DataModificaEqLessThanThis)
		{
			BilancioAgricoloCollection BilancioAgricoloCollectionTemp = new BilancioAgricoloCollection();
			foreach (BilancioAgricolo BilancioAgricoloItem in this)
			{
				if (((DataModificaEqLessThanThis == null) || ((BilancioAgricoloItem.DataModifica != null) && (BilancioAgricoloItem.DataModifica.Value <= DataModificaEqLessThanThis.Value))))
				{
					BilancioAgricoloCollectionTemp.Add(BilancioAgricoloItem);
				}
			}
			return BilancioAgricoloCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO_AGRICOLO>
  <ViewName>
  </ViewName>
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
    <Find OrderBy="ORDER BY ">
      <ID_BILANCIO_AGRICOLO>Equal</ID_BILANCIO_AGRICOLO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ANNO>Equal</ANNO>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <PREVISIONALE>Equal</PREVISIONALE>
    </Find>
  </Finds>
  <Filters>
    <FiltroPrevisionale>
      <PREVISIONALE>Equal</PREVISIONALE>
    </FiltroPrevisionale>
    <FiltroDataModifica>
      <DATA_MODIFICA>EqLessThan</DATA_MODIFICA>
    </FiltroDataModifica>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BILANCIO_AGRICOLO>
*/