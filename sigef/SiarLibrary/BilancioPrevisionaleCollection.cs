using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for BilancioPrevisionaleCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BilancioPrevisionaleCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BilancioPrevisionaleCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BilancioPrevisionale) info.GetValue(i.ToString(),typeof(BilancioPrevisionale)));
			}
		}

		//Costruttore
		public BilancioPrevisionaleCollection()
		{
			this.ItemType = typeof(BilancioPrevisionale);
		}

		//Costruttore con provider
		public BilancioPrevisionaleCollection(IBilancioPrevisionaleProvider providerObj)
		{
			this.ItemType = typeof(BilancioPrevisionale);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BilancioPrevisionale this[int index]
		{
			get { return (BilancioPrevisionale)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BilancioPrevisionaleCollection GetChanges()
		{
			return (BilancioPrevisionaleCollection) base.GetChanges();
		}

		[NonSerialized] private IBilancioPrevisionaleProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBilancioPrevisionaleProvider Provider
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
		public int Add(BilancioPrevisionale BilancioPrevisionaleObj)
		{
			if (BilancioPrevisionaleObj.Provider == null) BilancioPrevisionaleObj.Provider = this.Provider;
			return base.Add(BilancioPrevisionaleObj);
		}

		//AddCollection
		public void AddCollection(BilancioPrevisionaleCollection BilancioPrevisionaleCollectionObj)
		{
			foreach (BilancioPrevisionale BilancioPrevisionaleObj in BilancioPrevisionaleCollectionObj)
				this.Add(BilancioPrevisionaleObj);
		}

		//Insert
		public void Insert(int index, BilancioPrevisionale BilancioPrevisionaleObj)
		{
			if (BilancioPrevisionaleObj.Provider == null) BilancioPrevisionaleObj.Provider = this.Provider;
			base.Insert(index, BilancioPrevisionaleObj);
		}

		//CollectionGetById
		public BilancioPrevisionale CollectionGetById(NullTypes.IntNT IdPrevisionaleValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPrevisionale == IdPrevisionaleValue))
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
		public BilancioPrevisionaleCollection SubSelect(NullTypes.IntNT IdPrevisionaleEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT AnnoEqualThis, 
NullTypes.DatetimeNT DataBilancioEqualThis, NullTypes.DecimalNT PlvRicaviNettiVenditaEqualThis, NullTypes.DecimalNT PlvAltriRicaviEqualThis, 
NullTypes.DecimalNT PlvVarRimanenzeEqualThis, NullTypes.DecimalNT PlvVarLavoroEqualThis, NullTypes.DecimalNT PlvIncrementiEqualThis, 
NullTypes.DecimalNT RoCostiProduzioneEqualThis, NullTypes.DecimalNT RpiProventiEqualThis, NullTypes.DecimalNT RpiRettificheEqualThis, 
NullTypes.DecimalNT RpiProventiStraordinariEqualThis, NullTypes.DecimalNT RnImposteEqualThis, NullTypes.DecimalNT TaCreditiEqualThis, 
NullTypes.DecimalNT TaImmobilizzazioniEqualThis, NullTypes.DecimalNT TaAttivoCircolanteEqualThis, NullTypes.DecimalNT TaRateiEqualThis, 
NullTypes.DecimalNT TpPatrimonioEqualThis, NullTypes.DecimalNT TpFondiEqualThis, NullTypes.DecimalNT TpLtMutuiOrdinariEqualThis, 
NullTypes.DecimalNT TpLtMutuiAgevolatiEqualThis, NullTypes.DecimalNT TpLtPrestitiEqualThis, NullTypes.DecimalNT TpLtDebitiFornitoriEqualThis, 
NullTypes.DecimalNT TpLtDebitiBancheEqualThis, NullTypes.DecimalNT TpLtAltreScadenzeEqualThis, NullTypes.DecimalNT TpDebitiFornitoriEqualThis, 
NullTypes.DecimalNT TpDebitiBancheEqualThis, NullTypes.DecimalNT TpPrestitiSociEqualThis, NullTypes.DecimalNT TpPrestitiEqualThis, 
NullTypes.DecimalNT TpAltriDebitiEqualThis, NullTypes.DecimalNT TpRateiEqualThis)
		{
			BilancioPrevisionaleCollection BilancioPrevisionaleCollectionTemp = new BilancioPrevisionaleCollection();
			foreach (BilancioPrevisionale BilancioPrevisionaleItem in this)
			{
				if (((IdPrevisionaleEqualThis == null) || ((BilancioPrevisionaleItem.IdPrevisionale != null) && (BilancioPrevisionaleItem.IdPrevisionale.Value == IdPrevisionaleEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((BilancioPrevisionaleItem.IdProgetto != null) && (BilancioPrevisionaleItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((AnnoEqualThis == null) || ((BilancioPrevisionaleItem.Anno != null) && (BilancioPrevisionaleItem.Anno.Value == AnnoEqualThis.Value))) && 
((DataBilancioEqualThis == null) || ((BilancioPrevisionaleItem.DataBilancio != null) && (BilancioPrevisionaleItem.DataBilancio.Value == DataBilancioEqualThis.Value))) && ((PlvRicaviNettiVenditaEqualThis == null) || ((BilancioPrevisionaleItem.PlvRicaviNettiVendita != null) && (BilancioPrevisionaleItem.PlvRicaviNettiVendita.Value == PlvRicaviNettiVenditaEqualThis.Value))) && ((PlvAltriRicaviEqualThis == null) || ((BilancioPrevisionaleItem.PlvAltriRicavi != null) && (BilancioPrevisionaleItem.PlvAltriRicavi.Value == PlvAltriRicaviEqualThis.Value))) && 
((PlvVarRimanenzeEqualThis == null) || ((BilancioPrevisionaleItem.PlvVarRimanenze != null) && (BilancioPrevisionaleItem.PlvVarRimanenze.Value == PlvVarRimanenzeEqualThis.Value))) && ((PlvVarLavoroEqualThis == null) || ((BilancioPrevisionaleItem.PlvVarLavoro != null) && (BilancioPrevisionaleItem.PlvVarLavoro.Value == PlvVarLavoroEqualThis.Value))) && ((PlvIncrementiEqualThis == null) || ((BilancioPrevisionaleItem.PlvIncrementi != null) && (BilancioPrevisionaleItem.PlvIncrementi.Value == PlvIncrementiEqualThis.Value))) && 
((RoCostiProduzioneEqualThis == null) || ((BilancioPrevisionaleItem.RoCostiProduzione != null) && (BilancioPrevisionaleItem.RoCostiProduzione.Value == RoCostiProduzioneEqualThis.Value))) && ((RpiProventiEqualThis == null) || ((BilancioPrevisionaleItem.RpiProventi != null) && (BilancioPrevisionaleItem.RpiProventi.Value == RpiProventiEqualThis.Value))) && ((RpiRettificheEqualThis == null) || ((BilancioPrevisionaleItem.RpiRettifiche != null) && (BilancioPrevisionaleItem.RpiRettifiche.Value == RpiRettificheEqualThis.Value))) && 
((RpiProventiStraordinariEqualThis == null) || ((BilancioPrevisionaleItem.RpiProventiStraordinari != null) && (BilancioPrevisionaleItem.RpiProventiStraordinari.Value == RpiProventiStraordinariEqualThis.Value))) && ((RnImposteEqualThis == null) || ((BilancioPrevisionaleItem.RnImposte != null) && (BilancioPrevisionaleItem.RnImposte.Value == RnImposteEqualThis.Value))) && ((TaCreditiEqualThis == null) || ((BilancioPrevisionaleItem.TaCrediti != null) && (BilancioPrevisionaleItem.TaCrediti.Value == TaCreditiEqualThis.Value))) && 
((TaImmobilizzazioniEqualThis == null) || ((BilancioPrevisionaleItem.TaImmobilizzazioni != null) && (BilancioPrevisionaleItem.TaImmobilizzazioni.Value == TaImmobilizzazioniEqualThis.Value))) && ((TaAttivoCircolanteEqualThis == null) || ((BilancioPrevisionaleItem.TaAttivoCircolante != null) && (BilancioPrevisionaleItem.TaAttivoCircolante.Value == TaAttivoCircolanteEqualThis.Value))) && ((TaRateiEqualThis == null) || ((BilancioPrevisionaleItem.TaRatei != null) && (BilancioPrevisionaleItem.TaRatei.Value == TaRateiEqualThis.Value))) && 
((TpPatrimonioEqualThis == null) || ((BilancioPrevisionaleItem.TpPatrimonio != null) && (BilancioPrevisionaleItem.TpPatrimonio.Value == TpPatrimonioEqualThis.Value))) && ((TpFondiEqualThis == null) || ((BilancioPrevisionaleItem.TpFondi != null) && (BilancioPrevisionaleItem.TpFondi.Value == TpFondiEqualThis.Value))) && ((TpLtMutuiOrdinariEqualThis == null) || ((BilancioPrevisionaleItem.TpLtMutuiOrdinari != null) && (BilancioPrevisionaleItem.TpLtMutuiOrdinari.Value == TpLtMutuiOrdinariEqualThis.Value))) && 
((TpLtMutuiAgevolatiEqualThis == null) || ((BilancioPrevisionaleItem.TpLtMutuiAgevolati != null) && (BilancioPrevisionaleItem.TpLtMutuiAgevolati.Value == TpLtMutuiAgevolatiEqualThis.Value))) && ((TpLtPrestitiEqualThis == null) || ((BilancioPrevisionaleItem.TpLtPrestiti != null) && (BilancioPrevisionaleItem.TpLtPrestiti.Value == TpLtPrestitiEqualThis.Value))) && ((TpLtDebitiFornitoriEqualThis == null) || ((BilancioPrevisionaleItem.TpLtDebitiFornitori != null) && (BilancioPrevisionaleItem.TpLtDebitiFornitori.Value == TpLtDebitiFornitoriEqualThis.Value))) && 
((TpLtDebitiBancheEqualThis == null) || ((BilancioPrevisionaleItem.TpLtDebitiBanche != null) && (BilancioPrevisionaleItem.TpLtDebitiBanche.Value == TpLtDebitiBancheEqualThis.Value))) && ((TpLtAltreScadenzeEqualThis == null) || ((BilancioPrevisionaleItem.TpLtAltreScadenze != null) && (BilancioPrevisionaleItem.TpLtAltreScadenze.Value == TpLtAltreScadenzeEqualThis.Value))) && ((TpDebitiFornitoriEqualThis == null) || ((BilancioPrevisionaleItem.TpDebitiFornitori != null) && (BilancioPrevisionaleItem.TpDebitiFornitori.Value == TpDebitiFornitoriEqualThis.Value))) && 
((TpDebitiBancheEqualThis == null) || ((BilancioPrevisionaleItem.TpDebitiBanche != null) && (BilancioPrevisionaleItem.TpDebitiBanche.Value == TpDebitiBancheEqualThis.Value))) && ((TpPrestitiSociEqualThis == null) || ((BilancioPrevisionaleItem.TpPrestitiSoci != null) && (BilancioPrevisionaleItem.TpPrestitiSoci.Value == TpPrestitiSociEqualThis.Value))) && ((TpPrestitiEqualThis == null) || ((BilancioPrevisionaleItem.TpPrestiti != null) && (BilancioPrevisionaleItem.TpPrestiti.Value == TpPrestitiEqualThis.Value))) && 
((TpAltriDebitiEqualThis == null) || ((BilancioPrevisionaleItem.TpAltriDebiti != null) && (BilancioPrevisionaleItem.TpAltriDebiti.Value == TpAltriDebitiEqualThis.Value))) && ((TpRateiEqualThis == null) || ((BilancioPrevisionaleItem.TpRatei != null) && (BilancioPrevisionaleItem.TpRatei.Value == TpRateiEqualThis.Value))))
				{
					BilancioPrevisionaleCollectionTemp.Add(BilancioPrevisionaleItem);
				}
			}
			return BilancioPrevisionaleCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO_PREVISIONALE>
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
      <ID_PREVISIONALE>Equal</ID_PREVISIONALE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <ANNO>Equal</ANNO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BILANCIO_PREVISIONALE>
*/