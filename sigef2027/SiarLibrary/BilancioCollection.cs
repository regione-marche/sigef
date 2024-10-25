using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for BilancioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BilancioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BilancioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Bilancio) info.GetValue(i.ToString(),typeof(Bilancio)));
			}
		}

		//Costruttore
		public BilancioCollection()
		{
			this.ItemType = typeof(Bilancio);
		}

		//Costruttore con provider
		public BilancioCollection(IBilancioProvider providerObj)
		{
			this.ItemType = typeof(Bilancio);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Bilancio this[int index]
		{
			get { return (Bilancio)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BilancioCollection GetChanges()
		{
			return (BilancioCollection) base.GetChanges();
		}

		[NonSerialized] private IBilancioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBilancioProvider Provider
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
		public int Add(Bilancio BilancioObj)
		{
			if (BilancioObj.Provider == null) BilancioObj.Provider = this.Provider;
			return base.Add(BilancioObj);
		}

		//AddCollection
		public void AddCollection(BilancioCollection BilancioCollectionObj)
		{
			foreach (Bilancio BilancioObj in BilancioCollectionObj)
				this.Add(BilancioObj);
		}

		//Insert
		public void Insert(int index, Bilancio BilancioObj)
		{
			if (BilancioObj.Provider == null) BilancioObj.Provider = this.Provider;
			base.Insert(index, BilancioObj);
		}

		//CollectionGetById
		public Bilancio CollectionGetById(NullTypes.IntNT IdBilancioValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBilancio == IdBilancioValue))
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
		public BilancioCollection SubSelect(NullTypes.IntNT IdBilancioEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT AnnoEqualThis, 
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
			BilancioCollection BilancioCollectionTemp = new BilancioCollection();
			foreach (Bilancio BilancioItem in this)
			{
				if (((IdBilancioEqualThis == null) || ((BilancioItem.IdBilancio != null) && (BilancioItem.IdBilancio.Value == IdBilancioEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((BilancioItem.IdImpresa != null) && (BilancioItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((AnnoEqualThis == null) || ((BilancioItem.Anno != null) && (BilancioItem.Anno.Value == AnnoEqualThis.Value))) && 
((DataBilancioEqualThis == null) || ((BilancioItem.DataBilancio != null) && (BilancioItem.DataBilancio.Value == DataBilancioEqualThis.Value))) && ((PlvRicaviNettiVenditaEqualThis == null) || ((BilancioItem.PlvRicaviNettiVendita != null) && (BilancioItem.PlvRicaviNettiVendita.Value == PlvRicaviNettiVenditaEqualThis.Value))) && ((PlvAltriRicaviEqualThis == null) || ((BilancioItem.PlvAltriRicavi != null) && (BilancioItem.PlvAltriRicavi.Value == PlvAltriRicaviEqualThis.Value))) && 
((PlvVarRimanenzeEqualThis == null) || ((BilancioItem.PlvVarRimanenze != null) && (BilancioItem.PlvVarRimanenze.Value == PlvVarRimanenzeEqualThis.Value))) && ((PlvVarLavoroEqualThis == null) || ((BilancioItem.PlvVarLavoro != null) && (BilancioItem.PlvVarLavoro.Value == PlvVarLavoroEqualThis.Value))) && ((PlvIncrementiEqualThis == null) || ((BilancioItem.PlvIncrementi != null) && (BilancioItem.PlvIncrementi.Value == PlvIncrementiEqualThis.Value))) && 
((RoCostiProduzioneEqualThis == null) || ((BilancioItem.RoCostiProduzione != null) && (BilancioItem.RoCostiProduzione.Value == RoCostiProduzioneEqualThis.Value))) && ((RpiProventiEqualThis == null) || ((BilancioItem.RpiProventi != null) && (BilancioItem.RpiProventi.Value == RpiProventiEqualThis.Value))) && ((RpiRettificheEqualThis == null) || ((BilancioItem.RpiRettifiche != null) && (BilancioItem.RpiRettifiche.Value == RpiRettificheEqualThis.Value))) && 
((RpiProventiStraordinariEqualThis == null) || ((BilancioItem.RpiProventiStraordinari != null) && (BilancioItem.RpiProventiStraordinari.Value == RpiProventiStraordinariEqualThis.Value))) && ((RnImposteEqualThis == null) || ((BilancioItem.RnImposte != null) && (BilancioItem.RnImposte.Value == RnImposteEqualThis.Value))) && ((TaCreditiEqualThis == null) || ((BilancioItem.TaCrediti != null) && (BilancioItem.TaCrediti.Value == TaCreditiEqualThis.Value))) && 
((TaImmobilizzazioniEqualThis == null) || ((BilancioItem.TaImmobilizzazioni != null) && (BilancioItem.TaImmobilizzazioni.Value == TaImmobilizzazioniEqualThis.Value))) && ((TaAttivoCircolanteEqualThis == null) || ((BilancioItem.TaAttivoCircolante != null) && (BilancioItem.TaAttivoCircolante.Value == TaAttivoCircolanteEqualThis.Value))) && ((TaRateiEqualThis == null) || ((BilancioItem.TaRatei != null) && (BilancioItem.TaRatei.Value == TaRateiEqualThis.Value))) && 
((TpPatrimonioEqualThis == null) || ((BilancioItem.TpPatrimonio != null) && (BilancioItem.TpPatrimonio.Value == TpPatrimonioEqualThis.Value))) && ((TpFondiEqualThis == null) || ((BilancioItem.TpFondi != null) && (BilancioItem.TpFondi.Value == TpFondiEqualThis.Value))) && ((TpLtMutuiOrdinariEqualThis == null) || ((BilancioItem.TpLtMutuiOrdinari != null) && (BilancioItem.TpLtMutuiOrdinari.Value == TpLtMutuiOrdinariEqualThis.Value))) && 
((TpLtMutuiAgevolatiEqualThis == null) || ((BilancioItem.TpLtMutuiAgevolati != null) && (BilancioItem.TpLtMutuiAgevolati.Value == TpLtMutuiAgevolatiEqualThis.Value))) && ((TpLtPrestitiEqualThis == null) || ((BilancioItem.TpLtPrestiti != null) && (BilancioItem.TpLtPrestiti.Value == TpLtPrestitiEqualThis.Value))) && ((TpLtDebitiFornitoriEqualThis == null) || ((BilancioItem.TpLtDebitiFornitori != null) && (BilancioItem.TpLtDebitiFornitori.Value == TpLtDebitiFornitoriEqualThis.Value))) && 
((TpLtDebitiBancheEqualThis == null) || ((BilancioItem.TpLtDebitiBanche != null) && (BilancioItem.TpLtDebitiBanche.Value == TpLtDebitiBancheEqualThis.Value))) && ((TpLtAltreScadenzeEqualThis == null) || ((BilancioItem.TpLtAltreScadenze != null) && (BilancioItem.TpLtAltreScadenze.Value == TpLtAltreScadenzeEqualThis.Value))) && ((TpDebitiFornitoriEqualThis == null) || ((BilancioItem.TpDebitiFornitori != null) && (BilancioItem.TpDebitiFornitori.Value == TpDebitiFornitoriEqualThis.Value))) && 
((TpDebitiBancheEqualThis == null) || ((BilancioItem.TpDebitiBanche != null) && (BilancioItem.TpDebitiBanche.Value == TpDebitiBancheEqualThis.Value))) && ((TpPrestitiSociEqualThis == null) || ((BilancioItem.TpPrestitiSoci != null) && (BilancioItem.TpPrestitiSoci.Value == TpPrestitiSociEqualThis.Value))) && ((TpPrestitiEqualThis == null) || ((BilancioItem.TpPrestiti != null) && (BilancioItem.TpPrestiti.Value == TpPrestitiEqualThis.Value))) && 
((TpAltriDebitiEqualThis == null) || ((BilancioItem.TpAltriDebiti != null) && (BilancioItem.TpAltriDebiti.Value == TpAltriDebitiEqualThis.Value))) && ((TpRateiEqualThis == null) || ((BilancioItem.TpRatei != null) && (BilancioItem.TpRatei.Value == TpRateiEqualThis.Value))))
				{
					BilancioCollectionTemp.Add(BilancioItem);
				}
			}
			return BilancioCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BILANCIO>
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
      <ID_BILANCIO>Equal</ID_BILANCIO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <DATA_BILANCIO>Equal</DATA_BILANCIO>
      <ANNO>Equal</ANNO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BILANCIO>
*/