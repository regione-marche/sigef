using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for FormaGiuridicaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class FormaGiuridicaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private FormaGiuridicaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((FormaGiuridica) info.GetValue(i.ToString(),typeof(FormaGiuridica)));
			}
		}

		//Costruttore
		public FormaGiuridicaCollection()
		{
			this.ItemType = typeof(FormaGiuridica);
		}

		//Costruttore con provider
		public FormaGiuridicaCollection(IFormaGiuridicaProvider providerObj)
		{
			this.ItemType = typeof(FormaGiuridica);
			this.Provider = providerObj;
		}

		//Get e Set
		public new FormaGiuridica this[int index]
		{
			get { return (FormaGiuridica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new FormaGiuridicaCollection GetChanges()
		{
			return (FormaGiuridicaCollection) base.GetChanges();
		}

		[NonSerialized] private IFormaGiuridicaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFormaGiuridicaProvider Provider
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
		public int Add(FormaGiuridica FormaGiuridicaObj)
		{
			if (FormaGiuridicaObj.Provider == null) FormaGiuridicaObj.Provider = this.Provider;
			return base.Add(FormaGiuridicaObj);
		}

		//AddCollection
		public void AddCollection(FormaGiuridicaCollection FormaGiuridicaCollectionObj)
		{
			foreach (FormaGiuridica FormaGiuridicaObj in FormaGiuridicaCollectionObj)
				this.Add(FormaGiuridicaObj);
		}

		//Insert
		public void Insert(int index, FormaGiuridica FormaGiuridicaObj)
		{
			if (FormaGiuridicaObj.Provider == null) FormaGiuridicaObj.Provider = this.Provider;
			base.Insert(index, FormaGiuridicaObj);
		}

		//CollectionGetById
		public FormaGiuridica CollectionGetById(NullTypes.StringNT CodIstatValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].CodIstat == CodIstatValue))
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
		public FormaGiuridicaCollection SubSelect(NullTypes.StringNT CodIstatEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT FogliaEqualThis)
		{
			FormaGiuridicaCollection FormaGiuridicaCollectionTemp = new FormaGiuridicaCollection();
			foreach (FormaGiuridica FormaGiuridicaItem in this)
			{
				if (((CodIstatEqualThis == null) || ((FormaGiuridicaItem.CodIstat != null) && (FormaGiuridicaItem.CodIstat.Value == CodIstatEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((FormaGiuridicaItem.Descrizione != null) && (FormaGiuridicaItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((FogliaEqualThis == null) || ((FormaGiuridicaItem.Foglia != null) && (FormaGiuridicaItem.Foglia.Value == FogliaEqualThis.Value))))
				{
					FormaGiuridicaCollectionTemp.Add(FormaGiuridicaItem);
				}
			}
			return FormaGiuridicaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public FormaGiuridicaCollection FiltroFoglia(NullTypes.BoolNT FogliaEqualThis)
		{
			FormaGiuridicaCollection FormaGiuridicaCollectionTemp = new FormaGiuridicaCollection();
			foreach (FormaGiuridica FormaGiuridicaItem in this)
			{
				if (((FogliaEqualThis == null) || ((FormaGiuridicaItem.Foglia != null) && (FormaGiuridicaItem.Foglia.Value == FogliaEqualThis.Value))))
				{
					FormaGiuridicaCollectionTemp.Add(FormaGiuridicaItem);
				}
			}
			return FormaGiuridicaCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<FORMA_GIURIDICA>
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
      <COD_ISTAT>Equal</COD_ISTAT>
    </Find>
  </Finds>
  <Filters>
    <FiltroFoglia>
      <FOGLIA>Equal</FOGLIA>
    </FiltroFoglia>
  </Filters>
  <externalFields />
  <AddedFkFields />
</FORMA_GIURIDICA>
*/