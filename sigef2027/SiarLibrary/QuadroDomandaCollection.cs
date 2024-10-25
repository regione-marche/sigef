using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for QuadroDomandaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class QuadroDomandaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private QuadroDomandaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((QuadroDomanda) info.GetValue(i.ToString(),typeof(QuadroDomanda)));
			}
		}

		//Costruttore
		public QuadroDomandaCollection()
		{
			this.ItemType = typeof(QuadroDomanda);
		}

		//Costruttore con provider
		public QuadroDomandaCollection(IQuadroDomandaProvider providerObj)
		{
			this.ItemType = typeof(QuadroDomanda);
			this.Provider = providerObj;
		}

		//Get e Set
		public new QuadroDomanda this[int index]
		{
			get { return (QuadroDomanda)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new QuadroDomandaCollection GetChanges()
		{
			return (QuadroDomandaCollection) base.GetChanges();
		}

		[NonSerialized] private IQuadroDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IQuadroDomandaProvider Provider
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
		public int Add(QuadroDomanda QuadroDomandaObj)
		{
			if (QuadroDomandaObj.Provider == null) QuadroDomandaObj.Provider = this.Provider;
			return base.Add(QuadroDomandaObj);
		}

		//AddCollection
		public void AddCollection(QuadroDomandaCollection QuadroDomandaCollectionObj)
		{
			foreach (QuadroDomanda QuadroDomandaObj in QuadroDomandaCollectionObj)
				this.Add(QuadroDomandaObj);
		}

		//Insert
		public void Insert(int index, QuadroDomanda QuadroDomandaObj)
		{
			if (QuadroDomandaObj.Provider == null) QuadroDomandaObj.Provider = this.Provider;
			base.Insert(index, QuadroDomandaObj);
		}

		//CollectionGetById
		public QuadroDomanda CollectionGetById(NullTypes.IntNT IdQuadroValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdQuadro == IdQuadroValue))
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
<QUADRO_DOMANDA>
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
      <ID_QUADRO>Equal</ID_QUADRO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</QUADRO_DOMANDA>
*/