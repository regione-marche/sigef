using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for PrioritaSpecialeCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PrioritaSpecialeCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PrioritaSpecialeCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PrioritaSpeciale) info.GetValue(i.ToString(),typeof(PrioritaSpeciale)));
			}
		}

		//Costruttore
		public PrioritaSpecialeCollection()
		{
			this.ItemType = typeof(PrioritaSpeciale);
		}

		//Costruttore con provider
		public PrioritaSpecialeCollection(IPrioritaSpecialeProvider providerObj)
		{
			this.ItemType = typeof(PrioritaSpeciale);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PrioritaSpeciale this[int index]
		{
			get { return (PrioritaSpeciale)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PrioritaSpecialeCollection GetChanges()
		{
			return (PrioritaSpecialeCollection) base.GetChanges();
		}

		[NonSerialized] private IPrioritaSpecialeProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaSpecialeProvider Provider
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
		public int Add(PrioritaSpeciale PrioritaSpecialeObj)
		{
			if (PrioritaSpecialeObj.Provider == null) PrioritaSpecialeObj.Provider = this.Provider;
			return base.Add(PrioritaSpecialeObj);
		}

		//AddCollection
		public void AddCollection(PrioritaSpecialeCollection PrioritaSpecialeCollectionObj)
		{
			foreach (PrioritaSpeciale PrioritaSpecialeObj in PrioritaSpecialeCollectionObj)
				this.Add(PrioritaSpecialeObj);
		}

		//Insert
		public void Insert(int index, PrioritaSpeciale PrioritaSpecialeObj)
		{
			if (PrioritaSpecialeObj.Provider == null) PrioritaSpecialeObj.Provider = this.Provider;
			base.Insert(index, PrioritaSpecialeObj);
		}

		//CollectionGetById
		public PrioritaSpeciale CollectionGetById(NullTypes.IntNT IdSchedaValutazioneValue, NullTypes.IntNT IdPrioritaValue, NullTypes.IntNT IdPrioritaSelezionataValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdSchedaValutazione == IdSchedaValutazioneValue) && (this[i].IdPriorita == IdPrioritaValue) && (this[i].IdPrioritaSelezionata == IdPrioritaSelezionataValue))
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
		public PrioritaSpecialeCollection SubSelect(NullTypes.IntNT IdSchedaValutazioneEqualThis, NullTypes.IntNT IdPrioritaEqualThis, NullTypes.IntNT IdPrioritaSelezionataEqualThis, 
NullTypes.BoolNT IsMaxEqualThis)
		{
			PrioritaSpecialeCollection PrioritaSpecialeCollectionTemp = new PrioritaSpecialeCollection();
			foreach (PrioritaSpeciale PrioritaSpecialeItem in this)
			{
				if (((IdSchedaValutazioneEqualThis == null) || ((PrioritaSpecialeItem.IdSchedaValutazione != null) && (PrioritaSpecialeItem.IdSchedaValutazione.Value == IdSchedaValutazioneEqualThis.Value))) && ((IdPrioritaEqualThis == null) || ((PrioritaSpecialeItem.IdPriorita != null) && (PrioritaSpecialeItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((IdPrioritaSelezionataEqualThis == null) || ((PrioritaSpecialeItem.IdPrioritaSelezionata != null) && (PrioritaSpecialeItem.IdPrioritaSelezionata.Value == IdPrioritaSelezionataEqualThis.Value))) && 
((IsMaxEqualThis == null) || ((PrioritaSpecialeItem.IsMax != null) && (PrioritaSpecialeItem.IsMax.Value == IsMaxEqualThis.Value))))
				{
					PrioritaSpecialeCollectionTemp.Add(PrioritaSpecialeItem);
				}
			}
			return PrioritaSpecialeCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA_SPECIALE>
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
    <Find>
      <ID_SCHEDA_VALUTAZIONE>Equal</ID_SCHEDA_VALUTAZIONE>
      <ID_PRIORITA>Equal</ID_PRIORITA>
      <ID_PRIORITA_SELEZIONATA>Equal</ID_PRIORITA_SELEZIONATA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_SPECIALE>
*/