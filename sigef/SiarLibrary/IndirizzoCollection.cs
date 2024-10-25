using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for IndirizzoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class IndirizzoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private IndirizzoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Indirizzo) info.GetValue(i.ToString(),typeof(Indirizzo)));
			}
		}

		//Costruttore
		public IndirizzoCollection()
		{
			this.ItemType = typeof(Indirizzo);
		}

		//Costruttore con provider
		public IndirizzoCollection(IIndirizzoProvider providerObj)
		{
			this.ItemType = typeof(Indirizzo);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Indirizzo this[int index]
		{
			get { return (Indirizzo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new IndirizzoCollection GetChanges()
		{
			return (IndirizzoCollection) base.GetChanges();
		}

		[NonSerialized] private IIndirizzoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IIndirizzoProvider Provider
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
		public int Add(Indirizzo IndirizzoObj)
		{
			if (IndirizzoObj.Provider == null) IndirizzoObj.Provider = this.Provider;
			return base.Add(IndirizzoObj);
		}

		//AddCollection
		public void AddCollection(IndirizzoCollection IndirizzoCollectionObj)
		{
			foreach (Indirizzo IndirizzoObj in IndirizzoCollectionObj)
				this.Add(IndirizzoObj);
		}

		//Insert
		public void Insert(int index, Indirizzo IndirizzoObj)
		{
			if (IndirizzoObj.Provider == null) IndirizzoObj.Provider = this.Provider;
			base.Insert(index, IndirizzoObj);
		}

		//CollectionGetById
		public Indirizzo CollectionGetById(NullTypes.IntNT IdIndirizzoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdIndirizzo == IdIndirizzoValue))
					find = true;
				else
					i++;
			}
			if (find)
				return this[i];
			else
				return null;
		}

	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<INDIRIZZO>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find>
      <ID_INDIRIZZO>Equal</ID_INDIRIZZO>
      <ID_COMUNE>Equal</ID_COMUNE>
      <VIA>Like</VIA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</INDIRIZZO>
*/