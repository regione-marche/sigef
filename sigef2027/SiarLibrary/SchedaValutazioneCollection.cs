using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for SchedaValutazioneCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class SchedaValutazioneCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private SchedaValutazioneCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((SchedaValutazione) info.GetValue(i.ToString(),typeof(SchedaValutazione)));
			}
		}

		//Costruttore
		public SchedaValutazioneCollection()
		{
			this.ItemType = typeof(SchedaValutazione);
		}

		//Costruttore con provider
		public SchedaValutazioneCollection(ISchedaValutazioneProvider providerObj)
		{
			this.ItemType = typeof(SchedaValutazione);
			this.Provider = providerObj;
		}

		//Get e Set
		public new SchedaValutazione this[int index]
		{
			get { return (SchedaValutazione)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new SchedaValutazioneCollection GetChanges()
		{
			return (SchedaValutazioneCollection) base.GetChanges();
		}

		[NonSerialized] private ISchedaValutazioneProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISchedaValutazioneProvider Provider
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
		public int Add(SchedaValutazione SchedaValutazioneObj)
		{
			if (SchedaValutazioneObj.Provider == null) SchedaValutazioneObj.Provider = this.Provider;
			return base.Add(SchedaValutazioneObj);
		}

		//AddCollection
		public void AddCollection(SchedaValutazioneCollection SchedaValutazioneCollectionObj)
		{
			foreach (SchedaValutazione SchedaValutazioneObj in SchedaValutazioneCollectionObj)
				this.Add(SchedaValutazioneObj);
		}

		//Insert
		public void Insert(int index, SchedaValutazione SchedaValutazioneObj)
		{
			if (SchedaValutazioneObj.Provider == null) SchedaValutazioneObj.Provider = this.Provider;
			base.Insert(index, SchedaValutazioneObj);
		}

		//CollectionGetById
		public SchedaValutazione CollectionGetById(NullTypes.IntNT IdSchedaValutazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdSchedaValutazione == IdSchedaValutazioneValue))
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
		public SchedaValutazioneCollection SubSelect(NullTypes.IntNT IdSchedaValutazioneEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT FlagTemplateEqualThis, 
NullTypes.DecimalNT ValoreMaxEqualThis, NullTypes.DecimalNT ValoreMinEqualThis, NullTypes.StringNT ParoleChiaveEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis)
		{
			SchedaValutazioneCollection SchedaValutazioneCollectionTemp = new SchedaValutazioneCollection();
			foreach (SchedaValutazione SchedaValutazioneItem in this)
			{
				if (((IdSchedaValutazioneEqualThis == null) || ((SchedaValutazioneItem.IdSchedaValutazione != null) && (SchedaValutazioneItem.IdSchedaValutazione.Value == IdSchedaValutazioneEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((SchedaValutazioneItem.Descrizione != null) && (SchedaValutazioneItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((FlagTemplateEqualThis == null) || ((SchedaValutazioneItem.FlagTemplate != null) && (SchedaValutazioneItem.FlagTemplate.Value == FlagTemplateEqualThis.Value))) && 
((ValoreMaxEqualThis == null) || ((SchedaValutazioneItem.ValoreMax != null) && (SchedaValutazioneItem.ValoreMax.Value == ValoreMaxEqualThis.Value))) && ((ValoreMinEqualThis == null) || ((SchedaValutazioneItem.ValoreMin != null) && (SchedaValutazioneItem.ValoreMin.Value == ValoreMinEqualThis.Value))) && ((ParoleChiaveEqualThis == null) || ((SchedaValutazioneItem.ParoleChiave != null) && (SchedaValutazioneItem.ParoleChiave.Value == ParoleChiaveEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((SchedaValutazioneItem.DataModifica != null) && (SchedaValutazioneItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					SchedaValutazioneCollectionTemp.Add(SchedaValutazioneItem);
				}
			}
			return SchedaValutazioneCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<SCHEDA_VALUTAZIONE>
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
    <Find OrderBy="ORDER BY DATA_MODIFICA DESC">
      <ID_SCHEDA_VALUTAZIONE>Equal</ID_SCHEDA_VALUTAZIONE>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <PAROLE_CHIAVE>Like</PAROLE_CHIAVE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SCHEDA_VALUTAZIONE>
*/