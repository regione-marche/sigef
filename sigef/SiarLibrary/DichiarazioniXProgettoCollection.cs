using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for DichiarazioniXProgettoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class DichiarazioniXProgettoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DichiarazioniXProgettoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((DichiarazioniXProgetto) info.GetValue(i.ToString(),typeof(DichiarazioniXProgetto)));
			}
		}

		//Costruttore
		public DichiarazioniXProgettoCollection()
		{
			this.ItemType = typeof(DichiarazioniXProgetto);
		}

		//Costruttore con provider
		public DichiarazioniXProgettoCollection(IDichiarazioniXProgettoProvider providerObj)
		{
			this.ItemType = typeof(DichiarazioniXProgetto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new DichiarazioniXProgetto this[int index]
		{
			get { return (DichiarazioniXProgetto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DichiarazioniXProgettoCollection GetChanges()
		{
			return (DichiarazioniXProgettoCollection) base.GetChanges();
		}

		[NonSerialized] private IDichiarazioniXProgettoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDichiarazioniXProgettoProvider Provider
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
		public int Add(DichiarazioniXProgetto DichiarazioniXProgettoObj)
		{
			if (DichiarazioniXProgettoObj.Provider == null) DichiarazioniXProgettoObj.Provider = this.Provider;
			return base.Add(DichiarazioniXProgettoObj);
		}

		//AddCollection
		public void AddCollection(DichiarazioniXProgettoCollection DichiarazioniXProgettoCollectionObj)
		{
			foreach (DichiarazioniXProgetto DichiarazioniXProgettoObj in DichiarazioniXProgettoCollectionObj)
				this.Add(DichiarazioniXProgettoObj);
		}

		//Insert
		public void Insert(int index, DichiarazioniXProgetto DichiarazioniXProgettoObj)
		{
			if (DichiarazioniXProgettoObj.Provider == null) DichiarazioniXProgettoObj.Provider = this.Provider;
			base.Insert(index, DichiarazioniXProgettoObj);
		}

		//CollectionGetById
		public DichiarazioniXProgetto CollectionGetById(NullTypes.IntNT IdDichiarazioneValue, NullTypes.IntNT IdProgettoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDichiarazione == IdDichiarazioneValue) && (this[i].IdProgetto == IdProgettoValue))
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
		public DichiarazioniXProgettoCollection SubSelect(NullTypes.IntNT IdDichiarazioneEqualThis, NullTypes.IntNT IdProgettoEqualThis)
		{
			DichiarazioniXProgettoCollection DichiarazioniXProgettoCollectionTemp = new DichiarazioniXProgettoCollection();
			foreach (DichiarazioniXProgetto DichiarazioniXProgettoItem in this)
			{
				if (((IdDichiarazioneEqualThis == null) || ((DichiarazioniXProgettoItem.IdDichiarazione != null) && (DichiarazioniXProgettoItem.IdDichiarazione.Value == IdDichiarazioneEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((DichiarazioniXProgettoItem.IdProgetto != null) && (DichiarazioniXProgettoItem.IdProgetto.Value == IdProgettoEqualThis.Value))))
				{
					DichiarazioniXProgettoCollectionTemp.Add(DichiarazioniXProgettoItem);
				}
			}
			return DichiarazioniXProgettoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<DICHIARAZIONI_X_PROGETTO>
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
      <ID_DICHIARAZIONE>Equal</ID_DICHIARAZIONE>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</DICHIARAZIONI_X_PROGETTO>
*/