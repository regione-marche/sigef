using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for BilancioIndustrialeCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BilancioIndustrialeCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BilancioIndustrialeCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BilancioIndustriale) info.GetValue(i.ToString(),typeof(BilancioIndustriale)));
			}
		}

		//Costruttore
		public BilancioIndustrialeCollection()
		{
			this.ItemType = typeof(BilancioIndustriale);
		}

		//Costruttore con provider
		public BilancioIndustrialeCollection(IBilancioIndustrialeProvider providerObj)
		{
			this.ItemType = typeof(BilancioIndustriale);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BilancioIndustriale this[int index]
		{
			get { return (BilancioIndustriale)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BilancioIndustrialeCollection GetChanges()
		{
			return (BilancioIndustrialeCollection) base.GetChanges();
		}

		[NonSerialized] private IBilancioIndustrialeProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBilancioIndustrialeProvider Provider
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
		public int Add(BilancioIndustriale BilancioIndustrialeObj)
		{
			if (BilancioIndustrialeObj.Provider == null) BilancioIndustrialeObj.Provider = this.Provider;
			return base.Add(BilancioIndustrialeObj);
		}

		//AddCollection
		public void AddCollection(BilancioIndustrialeCollection BilancioIndustrialeCollectionObj)
		{
			foreach (BilancioIndustriale BilancioIndustrialeObj in BilancioIndustrialeCollectionObj)
				this.Add(BilancioIndustrialeObj);
		}

		//Insert
		public void Insert(int index, BilancioIndustriale BilancioIndustrialeObj)
		{
			if (BilancioIndustrialeObj.Provider == null) BilancioIndustrialeObj.Provider = this.Provider;
			base.Insert(index, BilancioIndustrialeObj);
		}

		//CollectionGetById
		public BilancioIndustriale CollectionGetById(NullTypes.IntNT IdBilancioIndustrialeValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBilancioIndustriale == IdBilancioIndustrialeValue))
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
		public BilancioIndustrialeCollection SubSelect(NullTypes.IntNT IdBilancioIndustrialeEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.IntNT AnnoEqualThis, NullTypes.DatetimeNT DataBilancioEqualThis, NullTypes.BoolNT PrevisionaleEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.DecimalNT PlvRicaviVenditaEqualThis, NullTypes.DecimalNT PlvAltriRicaviEqualThis, 
NullTypes.DecimalNT CpMateriePrimeEqualThis, NullTypes.DecimalNT CpServiziEqualThis, NullTypes.DecimalNT CpBeniTerziEqualThis, 
NullTypes.DecimalNT CpPersonaleEqualThis, NullTypes.DecimalNT CpAmmSvalutazioniEqualThis, NullTypes.DecimalNT CpVarRimanenzeEqualThis, 
NullTypes.DecimalNT CpOneriEqualThis, NullTypes.DecimalNT PofAltriProventiEqualThis, NullTypes.DecimalNT PofInteressiOneriEqualThis, 
NullTypes.DecimalNT RettValAttFinanziarieEqualThis, NullTypes.DecimalNT PosProventiStraordEqualThis, NullTypes.DecimalNT PosOneriStraordEqualThis, 
NullTypes.DecimalNT TotPrimaImposteEqualThis, NullTypes.DecimalNT ImposteRedditoEqualThis, NullTypes.DecimalNT TaCreditiSociEqualThis, 
NullTypes.DecimalNT TaImmImmaterialiEqualThis, NullTypes.DecimalNT TaImmobMaterialiEqualThis, NullTypes.DecimalNT TaImmPartecipazioniEqualThis, 
NullTypes.DecimalNT TaImmCreditiEqualThis, NullTypes.DecimalNT TaAcRimanenzeEqualThis, NullTypes.DecimalNT TaAcCreditiClientiEqualThis, 
NullTypes.DecimalNT TaAcCreditiAltriEqualThis, NullTypes.DecimalNT TaAcDepPostaliEqualThis, NullTypes.DecimalNT TaAcDispoLiquideEqualThis, 
NullTypes.DecimalNT TaRateiRiscontiEqualThis, NullTypes.DecimalNT TpPnCapitaleEqualThis, NullTypes.DecimalNT TpPnSovrapAzioniEqualThis, 
NullTypes.DecimalNT TpPnRisRivalutazioneEqualThis, NullTypes.DecimalNT TpPnRisLegaleEqualThis, NullTypes.DecimalNT TpPnAzioniProprieEqualThis, 
NullTypes.DecimalNT TpPnRiserva904EqualThis, NullTypes.DecimalNT TpPnRiserveStatutarieEqualThis, NullTypes.DecimalNT TpPnAltreRiserveEqualThis, 
NullTypes.DecimalNT TpPnUtiliPrecedentiEqualThis, NullTypes.DecimalNT TpPnUtiliEsercizioEqualThis, NullTypes.DecimalNT TpFondiRischiOneriEqualThis, 
NullTypes.DecimalNT TpFineRapportoEqualThis, NullTypes.DecimalNT TpDebitiBancheEqualThis, NullTypes.DecimalNT TpDebitiFinanziatoriEqualThis, 
NullTypes.DecimalNT TpDebitiFornitoriEqualThis, NullTypes.DecimalNT TpDebitiIstPrevidEqualThis, NullTypes.DecimalNT TpAltriDebitiEqualThis, 
NullTypes.DecimalNT TpRateiRiscontiEqualThis)
		{
			BilancioIndustrialeCollection BilancioIndustrialeCollectionTemp = new BilancioIndustrialeCollection();
			foreach (BilancioIndustriale BilancioIndustrialeItem in this)
			{
				if (((IdBilancioIndustrialeEqualThis == null) || ((BilancioIndustrialeItem.IdBilancioIndustriale != null) && (BilancioIndustrialeItem.IdBilancioIndustriale.Value == IdBilancioIndustrialeEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((BilancioIndustrialeItem.IdImpresa != null) && (BilancioIndustrialeItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((BilancioIndustrialeItem.IdProgetto != null) && (BilancioIndustrialeItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((AnnoEqualThis == null) || ((BilancioIndustrialeItem.Anno != null) && (BilancioIndustrialeItem.Anno.Value == AnnoEqualThis.Value))) && ((DataBilancioEqualThis == null) || ((BilancioIndustrialeItem.DataBilancio != null) && (BilancioIndustrialeItem.DataBilancio.Value == DataBilancioEqualThis.Value))) && ((PrevisionaleEqualThis == null) || ((BilancioIndustrialeItem.Previsionale != null) && (BilancioIndustrialeItem.Previsionale.Value == PrevisionaleEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((BilancioIndustrialeItem.DataModifica != null) && (BilancioIndustrialeItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((PlvRicaviVenditaEqualThis == null) || ((BilancioIndustrialeItem.PlvRicaviVendita != null) && (BilancioIndustrialeItem.PlvRicaviVendita.Value == PlvRicaviVenditaEqualThis.Value))) && ((PlvAltriRicaviEqualThis == null) || ((BilancioIndustrialeItem.PlvAltriRicavi != null) && (BilancioIndustrialeItem.PlvAltriRicavi.Value == PlvAltriRicaviEqualThis.Value))) && 
((CpMateriePrimeEqualThis == null) || ((BilancioIndustrialeItem.CpMateriePrime != null) && (BilancioIndustrialeItem.CpMateriePrime.Value == CpMateriePrimeEqualThis.Value))) && ((CpServiziEqualThis == null) || ((BilancioIndustrialeItem.CpServizi != null) && (BilancioIndustrialeItem.CpServizi.Value == CpServiziEqualThis.Value))) && ((CpBeniTerziEqualThis == null) || ((BilancioIndustrialeItem.CpBeniTerzi != null) && (BilancioIndustrialeItem.CpBeniTerzi.Value == CpBeniTerziEqualThis.Value))) && 
((CpPersonaleEqualThis == null) || ((BilancioIndustrialeItem.CpPersonale != null) && (BilancioIndustrialeItem.CpPersonale.Value == CpPersonaleEqualThis.Value))) && ((CpAmmSvalutazioniEqualThis == null) || ((BilancioIndustrialeItem.CpAmmSvalutazioni != null) && (BilancioIndustrialeItem.CpAmmSvalutazioni.Value == CpAmmSvalutazioniEqualThis.Value))) && ((CpVarRimanenzeEqualThis == null) || ((BilancioIndustrialeItem.CpVarRimanenze != null) && (BilancioIndustrialeItem.CpVarRimanenze.Value == CpVarRimanenzeEqualThis.Value))) && 
((CpOneriEqualThis == null) || ((BilancioIndustrialeItem.CpOneri != null) && (BilancioIndustrialeItem.CpOneri.Value == CpOneriEqualThis.Value))) && ((PofAltriProventiEqualThis == null) || ((BilancioIndustrialeItem.PofAltriProventi != null) && (BilancioIndustrialeItem.PofAltriProventi.Value == PofAltriProventiEqualThis.Value))) && ((PofInteressiOneriEqualThis == null) || ((BilancioIndustrialeItem.PofInteressiOneri != null) && (BilancioIndustrialeItem.PofInteressiOneri.Value == PofInteressiOneriEqualThis.Value))) && 
((RettValAttFinanziarieEqualThis == null) || ((BilancioIndustrialeItem.RettValAttFinanziarie != null) && (BilancioIndustrialeItem.RettValAttFinanziarie.Value == RettValAttFinanziarieEqualThis.Value))) && ((PosProventiStraordEqualThis == null) || ((BilancioIndustrialeItem.PosProventiStraord != null) && (BilancioIndustrialeItem.PosProventiStraord.Value == PosProventiStraordEqualThis.Value))) && ((PosOneriStraordEqualThis == null) || ((BilancioIndustrialeItem.PosOneriStraord != null) && (BilancioIndustrialeItem.PosOneriStraord.Value == PosOneriStraordEqualThis.Value))) && 
((TotPrimaImposteEqualThis == null) || ((BilancioIndustrialeItem.TotPrimaImposte != null) && (BilancioIndustrialeItem.TotPrimaImposte.Value == TotPrimaImposteEqualThis.Value))) && ((ImposteRedditoEqualThis == null) || ((BilancioIndustrialeItem.ImposteReddito != null) && (BilancioIndustrialeItem.ImposteReddito.Value == ImposteRedditoEqualThis.Value))) && ((TaCreditiSociEqualThis == null) || ((BilancioIndustrialeItem.TaCreditiSoci != null) && (BilancioIndustrialeItem.TaCreditiSoci.Value == TaCreditiSociEqualThis.Value))) && 
((TaImmImmaterialiEqualThis == null) || ((BilancioIndustrialeItem.TaImmImmateriali != null) && (BilancioIndustrialeItem.TaImmImmateriali.Value == TaImmImmaterialiEqualThis.Value))) && ((TaImmobMaterialiEqualThis == null) || ((BilancioIndustrialeItem.TaImmobMateriali != null) && (BilancioIndustrialeItem.TaImmobMateriali.Value == TaImmobMaterialiEqualThis.Value))) && ((TaImmPartecipazioniEqualThis == null) || ((BilancioIndustrialeItem.TaImmPartecipazioni != null) && (BilancioIndustrialeItem.TaImmPartecipazioni.Value == TaImmPartecipazioniEqualThis.Value))) && 
((TaImmCreditiEqualThis == null) || ((BilancioIndustrialeItem.TaImmCrediti != null) && (BilancioIndustrialeItem.TaImmCrediti.Value == TaImmCreditiEqualThis.Value))) && ((TaAcRimanenzeEqualThis == null) || ((BilancioIndustrialeItem.TaAcRimanenze != null) && (BilancioIndustrialeItem.TaAcRimanenze.Value == TaAcRimanenzeEqualThis.Value))) && ((TaAcCreditiClientiEqualThis == null) || ((BilancioIndustrialeItem.TaAcCreditiClienti != null) && (BilancioIndustrialeItem.TaAcCreditiClienti.Value == TaAcCreditiClientiEqualThis.Value))) && 
((TaAcCreditiAltriEqualThis == null) || ((BilancioIndustrialeItem.TaAcCreditiAltri != null) && (BilancioIndustrialeItem.TaAcCreditiAltri.Value == TaAcCreditiAltriEqualThis.Value))) && ((TaAcDepPostaliEqualThis == null) || ((BilancioIndustrialeItem.TaAcDepPostali != null) && (BilancioIndustrialeItem.TaAcDepPostali.Value == TaAcDepPostaliEqualThis.Value))) && ((TaAcDispoLiquideEqualThis == null) || ((BilancioIndustrialeItem.TaAcDispoLiquide != null) && (BilancioIndustrialeItem.TaAcDispoLiquide.Value == TaAcDispoLiquideEqualThis.Value))) && 
((TaRateiRiscontiEqualThis == null) || ((BilancioIndustrialeItem.TaRateiRisconti != null) && (BilancioIndustrialeItem.TaRateiRisconti.Value == TaRateiRiscontiEqualThis.Value))) && ((TpPnCapitaleEqualThis == null) || ((BilancioIndustrialeItem.TpPnCapitale != null) && (BilancioIndustrialeItem.TpPnCapitale.Value == TpPnCapitaleEqualThis.Value))) && ((TpPnSovrapAzioniEqualThis == null) || ((BilancioIndustrialeItem.TpPnSovrapAzioni != null) && (BilancioIndustrialeItem.TpPnSovrapAzioni.Value == TpPnSovrapAzioniEqualThis.Value))) && 
((TpPnRisRivalutazioneEqualThis == null) || ((BilancioIndustrialeItem.TpPnRisRivalutazione != null) && (BilancioIndustrialeItem.TpPnRisRivalutazione.Value == TpPnRisRivalutazioneEqualThis.Value))) && ((TpPnRisLegaleEqualThis == null) || ((BilancioIndustrialeItem.TpPnRisLegale != null) && (BilancioIndustrialeItem.TpPnRisLegale.Value == TpPnRisLegaleEqualThis.Value))) && ((TpPnAzioniProprieEqualThis == null) || ((BilancioIndustrialeItem.TpPnAzioniProprie != null) && (BilancioIndustrialeItem.TpPnAzioniProprie.Value == TpPnAzioniProprieEqualThis.Value))) && 
((TpPnRiserva904EqualThis == null) || ((BilancioIndustrialeItem.TpPnRiserva904 != null) && (BilancioIndustrialeItem.TpPnRiserva904.Value == TpPnRiserva904EqualThis.Value))) && ((TpPnRiserveStatutarieEqualThis == null) || ((BilancioIndustrialeItem.TpPnRiserveStatutarie != null) && (BilancioIndustrialeItem.TpPnRiserveStatutarie.Value == TpPnRiserveStatutarieEqualThis.Value))) && ((TpPnAltreRiserveEqualThis == null) || ((BilancioIndustrialeItem.TpPnAltreRiserve != null) && (BilancioIndustrialeItem.TpPnAltreRiserve.Value == TpPnAltreRiserveEqualThis.Value))) && 
((TpPnUtiliPrecedentiEqualThis == null) || ((BilancioIndustrialeItem.TpPnUtiliPrecedenti != null) && (BilancioIndustrialeItem.TpPnUtiliPrecedenti.Value == TpPnUtiliPrecedentiEqualThis.Value))) && ((TpPnUtiliEsercizioEqualThis == null) || ((BilancioIndustrialeItem.TpPnUtiliEsercizio != null) && (BilancioIndustrialeItem.TpPnUtiliEsercizio.Value == TpPnUtiliEsercizioEqualThis.Value))) && ((TpFondiRischiOneriEqualThis == null) || ((BilancioIndustrialeItem.TpFondiRischiOneri != null) && (BilancioIndustrialeItem.TpFondiRischiOneri.Value == TpFondiRischiOneriEqualThis.Value))) && 
((TpFineRapportoEqualThis == null) || ((BilancioIndustrialeItem.TpFineRapporto != null) && (BilancioIndustrialeItem.TpFineRapporto.Value == TpFineRapportoEqualThis.Value))) && ((TpDebitiBancheEqualThis == null) || ((BilancioIndustrialeItem.TpDebitiBanche != null) && (BilancioIndustrialeItem.TpDebitiBanche.Value == TpDebitiBancheEqualThis.Value))) && ((TpDebitiFinanziatoriEqualThis == null) || ((BilancioIndustrialeItem.TpDebitiFinanziatori != null) && (BilancioIndustrialeItem.TpDebitiFinanziatori.Value == TpDebitiFinanziatoriEqualThis.Value))) && 
((TpDebitiFornitoriEqualThis == null) || ((BilancioIndustrialeItem.TpDebitiFornitori != null) && (BilancioIndustrialeItem.TpDebitiFornitori.Value == TpDebitiFornitoriEqualThis.Value))) && ((TpDebitiIstPrevidEqualThis == null) || ((BilancioIndustrialeItem.TpDebitiIstPrevid != null) && (BilancioIndustrialeItem.TpDebitiIstPrevid.Value == TpDebitiIstPrevidEqualThis.Value))) && ((TpAltriDebitiEqualThis == null) || ((BilancioIndustrialeItem.TpAltriDebiti != null) && (BilancioIndustrialeItem.TpAltriDebiti.Value == TpAltriDebitiEqualThis.Value))) && 
((TpRateiRiscontiEqualThis == null) || ((BilancioIndustrialeItem.TpRateiRisconti != null) && (BilancioIndustrialeItem.TpRateiRisconti.Value == TpRateiRiscontiEqualThis.Value))))
				{
					BilancioIndustrialeCollectionTemp.Add(BilancioIndustrialeItem);
				}
			}
			return BilancioIndustrialeCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BilancioIndustrialeCollection FiltroPrevisionale(NullTypes.BoolNT PrevisionaleEqualThis)
		{
			BilancioIndustrialeCollection BilancioIndustrialeCollectionTemp = new BilancioIndustrialeCollection();
			foreach (BilancioIndustriale BilancioIndustrialeItem in this)
			{
				if (((PrevisionaleEqualThis == null) || ((BilancioIndustrialeItem.Previsionale != null) && (BilancioIndustrialeItem.Previsionale.Value == PrevisionaleEqualThis.Value))))
				{
					BilancioIndustrialeCollectionTemp.Add(BilancioIndustrialeItem);
				}
			}
			return BilancioIndustrialeCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BilancioIndustrialeCollection FiltroDataModifica(NullTypes.DatetimeNT DataModificaEqLessThanThis)
		{
			BilancioIndustrialeCollection BilancioIndustrialeCollectionTemp = new BilancioIndustrialeCollection();
			foreach (BilancioIndustriale BilancioIndustrialeItem in this)
			{
				if (((DataModificaEqLessThanThis == null) || ((BilancioIndustrialeItem.DataModifica != null) && (BilancioIndustrialeItem.DataModifica.Value <= DataModificaEqLessThanThis.Value))))
				{
					BilancioIndustrialeCollectionTemp.Add(BilancioIndustrialeItem);
				}
			}
			return BilancioIndustrialeCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO_INDUSTRIALE>
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
    <Find OrderBy="ORDER BY ANNO DESC">
      <ID_BILANCIO_INDUSTRIALE>Equal</ID_BILANCIO_INDUSTRIALE>
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
</BILANCIO_INDUSTRIALE>
*/