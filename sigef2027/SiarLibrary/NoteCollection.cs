using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for NoteCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class NoteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private NoteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Note) info.GetValue(i.ToString(),typeof(Note)));
			}
		}

		//Costruttore
		public NoteCollection()
		{
			this.ItemType = typeof(Note);
		}

		//Costruttore con provider
		public NoteCollection(INoteProvider providerObj)
		{
			this.ItemType = typeof(Note);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Note this[int index]
		{
			get { return (Note)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new NoteCollection GetChanges()
		{
			return (NoteCollection) base.GetChanges();
		}

		[NonSerialized] private INoteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public INoteProvider Provider
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
		public int Add(Note NoteObj)
		{
			if (NoteObj.Provider == null) NoteObj.Provider = this.Provider;
			return base.Add(NoteObj);
		}

		//AddCollection
		public void AddCollection(NoteCollection NoteCollectionObj)
		{
			foreach (Note NoteObj in NoteCollectionObj)
				this.Add(NoteObj);
		}

		//Insert
		public void Insert(int index, Note NoteObj)
		{
			if (NoteObj.Provider == null) NoteObj.Provider = this.Provider;
			base.Insert(index, NoteObj);
		}

		//CollectionGetById
		public Note CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
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
		public NoteCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT TestoEqualThis)
		{
			NoteCollection NoteCollectionTemp = new NoteCollection();
			foreach (Note NoteItem in this)
			{
				if (((IdEqualThis == null) || ((NoteItem.Id != null) && (NoteItem.Id.Value == IdEqualThis.Value))) && ((TestoEqualThis == null) || ((NoteItem.Testo != null) && (NoteItem.Testo.Value == TestoEqualThis.Value))))
				{
					NoteCollectionTemp.Add(NoteItem);
				}
			}
			return NoteCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<NOTE>
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
      <ID>Equal</ID>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</NOTE>
*/