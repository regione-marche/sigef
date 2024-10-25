using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for TipoSanzioniParametriCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class TipoSanzioniParametriCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private TipoSanzioniParametriCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((TipoSanzioniParametri) info.GetValue(i.ToString(),typeof(TipoSanzioniParametri)));
			}
		}

		//Costruttore
		public TipoSanzioniParametriCollection()
		{
			this.ItemType = typeof(TipoSanzioniParametri);
		}

		//Costruttore con provider
		public TipoSanzioniParametriCollection(ITipoSanzioniParametriProvider providerObj)
		{
			this.ItemType = typeof(TipoSanzioniParametri);
			this.Provider = providerObj;
		}

		//Get e Set
		public new TipoSanzioniParametri this[int index]
		{
			get { return (TipoSanzioniParametri)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new TipoSanzioniParametriCollection GetChanges()
		{
			return (TipoSanzioniParametriCollection) base.GetChanges();
		}

		[NonSerialized] private ITipoSanzioniParametriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ITipoSanzioniParametriProvider Provider
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
		public int Add(TipoSanzioniParametri TipoSanzioniParametriObj)
		{
			if (TipoSanzioniParametriObj.Provider == null) TipoSanzioniParametriObj.Provider = this.Provider;
			return base.Add(TipoSanzioniParametriObj);
		}

		//AddCollection
		public void AddCollection(TipoSanzioniParametriCollection TipoSanzioniParametriCollectionObj)
		{
			foreach (TipoSanzioniParametri TipoSanzioniParametriObj in TipoSanzioniParametriCollectionObj)
				this.Add(TipoSanzioniParametriObj);
		}

		//Insert
		public void Insert(int index, TipoSanzioniParametri TipoSanzioniParametriObj)
		{
			if (TipoSanzioniParametriObj.Provider == null) TipoSanzioniParametriObj.Provider = this.Provider;
			base.Insert(index, TipoSanzioniParametriObj);
		}

		//CollectionGetById
		public TipoSanzioniParametri CollectionGetById(NullTypes.IntNT CodiceValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Codice == CodiceValue))
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
		public TipoSanzioniParametriCollection SubSelect(NullTypes.IntNT CodiceEqualThis, NullTypes.StringNT CodTipoSanzioneEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.BoolNT NonComportaSanzioneEqualThis, NullTypes.BoolNT DurataEqualThis, NullTypes.BoolNT GravitaEqualThis, 
NullTypes.BoolNT EntitaEqualThis, NullTypes.IntNT ClasseViolazioneEqualThis, NullTypes.StringNT TooltipEqualThis)
		{
			TipoSanzioniParametriCollection TipoSanzioniParametriCollectionTemp = new TipoSanzioniParametriCollection();
			foreach (TipoSanzioniParametri TipoSanzioniParametriItem in this)
			{
				if (((CodiceEqualThis == null) || ((TipoSanzioniParametriItem.Codice != null) && (TipoSanzioniParametriItem.Codice.Value == CodiceEqualThis.Value))) && ((CodTipoSanzioneEqualThis == null) || ((TipoSanzioniParametriItem.CodTipoSanzione != null) && (TipoSanzioniParametriItem.CodTipoSanzione.Value == CodTipoSanzioneEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((TipoSanzioniParametriItem.Descrizione != null) && (TipoSanzioniParametriItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((NonComportaSanzioneEqualThis == null) || ((TipoSanzioniParametriItem.NonComportaSanzione != null) && (TipoSanzioniParametriItem.NonComportaSanzione.Value == NonComportaSanzioneEqualThis.Value))) && ((DurataEqualThis == null) || ((TipoSanzioniParametriItem.Durata != null) && (TipoSanzioniParametriItem.Durata.Value == DurataEqualThis.Value))) && ((GravitaEqualThis == null) || ((TipoSanzioniParametriItem.Gravita != null) && (TipoSanzioniParametriItem.Gravita.Value == GravitaEqualThis.Value))) && 
((EntitaEqualThis == null) || ((TipoSanzioniParametriItem.Entita != null) && (TipoSanzioniParametriItem.Entita.Value == EntitaEqualThis.Value))) && ((ClasseViolazioneEqualThis == null) || ((TipoSanzioniParametriItem.ClasseViolazione != null) && (TipoSanzioniParametriItem.ClasseViolazione.Value == ClasseViolazioneEqualThis.Value))) && ((TooltipEqualThis == null) || ((TipoSanzioniParametriItem.Tooltip != null) && (TipoSanzioniParametriItem.Tooltip.Value == TooltipEqualThis.Value))))
				{
					TipoSanzioniParametriCollectionTemp.Add(TipoSanzioniParametriItem);
				}
			}
			return TipoSanzioniParametriCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public TipoSanzioniParametriCollection FiltroTipoParametro(NullTypes.BoolNT DurataEqualThis, NullTypes.BoolNT GravitaEqualThis, NullTypes.BoolNT EntitaEqualThis)
		{
			TipoSanzioniParametriCollection TipoSanzioniParametriCollectionTemp = new TipoSanzioniParametriCollection();
			foreach (TipoSanzioniParametri TipoSanzioniParametriItem in this)
			{
				if (((DurataEqualThis == null) || ((TipoSanzioniParametriItem.Durata != null) && (TipoSanzioniParametriItem.Durata.Value == DurataEqualThis.Value))) && ((GravitaEqualThis == null) || ((TipoSanzioniParametriItem.Gravita != null) && (TipoSanzioniParametriItem.Gravita.Value == GravitaEqualThis.Value))) && ((EntitaEqualThis == null) || ((TipoSanzioniParametriItem.Entita != null) && (TipoSanzioniParametriItem.Entita.Value == EntitaEqualThis.Value))))
				{
					TipoSanzioniParametriCollectionTemp.Add(TipoSanzioniParametriItem);
				}
			}
			return TipoSanzioniParametriCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_SANZIONI_PARAMETRI>
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
    <Find OrderBy="ORDER BY CLASSE_VIOLAZIONE">
      <CODICE>Equal</CODICE>
      <COD_TIPO_SANZIONE>Equal</COD_TIPO_SANZIONE>
      <DURATA>Equal</DURATA>
      <GRAVITA>Equal</GRAVITA>
      <ENTITA>Equal</ENTITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipoParametro>
      <DURATA>Equal</DURATA>
      <GRAVITA>Equal</GRAVITA>
      <ENTITA>Equal</ENTITA>
    </FiltroTipoParametro>
  </Filters>
  <externalFields />
  <AddedFkFields />
</TIPO_SANZIONI_PARAMETRI>
*/