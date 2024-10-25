using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for CatalogoDichiarazioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CatalogoDichiarazioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CatalogoDichiarazioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CatalogoDichiarazioni) info.GetValue(i.ToString(),typeof(CatalogoDichiarazioni)));
			}
		}

		//Costruttore
		public CatalogoDichiarazioniCollection()
		{
			this.ItemType = typeof(CatalogoDichiarazioni);
		}

		//Costruttore con provider
		public CatalogoDichiarazioniCollection(ICatalogoDichiarazioniProvider providerObj)
		{
			this.ItemType = typeof(CatalogoDichiarazioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CatalogoDichiarazioni this[int index]
		{
			get { return (CatalogoDichiarazioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CatalogoDichiarazioniCollection GetChanges()
		{
			return (CatalogoDichiarazioniCollection) base.GetChanges();
		}

		[NonSerialized] private ICatalogoDichiarazioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICatalogoDichiarazioniProvider Provider
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
		public int Add(CatalogoDichiarazioni CatalogoDichiarazioniObj)
		{
			if (CatalogoDichiarazioniObj.Provider == null) CatalogoDichiarazioniObj.Provider = this.Provider;
			return base.Add(CatalogoDichiarazioniObj);
		}

		//AddCollection
		public void AddCollection(CatalogoDichiarazioniCollection CatalogoDichiarazioniCollectionObj)
		{
			foreach (CatalogoDichiarazioni CatalogoDichiarazioniObj in CatalogoDichiarazioniCollectionObj)
				this.Add(CatalogoDichiarazioniObj);
		}

		//Insert
		public void Insert(int index, CatalogoDichiarazioni CatalogoDichiarazioniObj)
		{
			if (CatalogoDichiarazioniObj.Provider == null) CatalogoDichiarazioniObj.Provider = this.Provider;
			base.Insert(index, CatalogoDichiarazioniObj);
		}

		//CollectionGetById
		public CatalogoDichiarazioni CollectionGetById(NullTypes.IntNT IdDichiarazioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDichiarazione == IdDichiarazioneValue))
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
		public CatalogoDichiarazioniCollection SubSelect(NullTypes.IntNT IdDichiarazioneEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.StringNT MisuraEqualThis)
		{
			CatalogoDichiarazioniCollection CatalogoDichiarazioniCollectionTemp = new CatalogoDichiarazioniCollection();
			foreach (CatalogoDichiarazioni CatalogoDichiarazioniItem in this)
			{
				if (((IdDichiarazioneEqualThis == null) || ((CatalogoDichiarazioniItem.IdDichiarazione != null) && (CatalogoDichiarazioniItem.IdDichiarazione.Value == IdDichiarazioneEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((CatalogoDichiarazioniItem.Descrizione != null) && (CatalogoDichiarazioniItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((MisuraEqualThis == null) || ((CatalogoDichiarazioniItem.Misura != null) && (CatalogoDichiarazioniItem.Misura.Value == MisuraEqualThis.Value))))
				{
					CatalogoDichiarazioniCollectionTemp.Add(CatalogoDichiarazioniItem);
				}
			}
			return CatalogoDichiarazioniCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CATALOGO_DICHIARAZIONI>
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
    <Find OrderBy="ORDER BY ID_DICHIARAZIONE">
      <ID_DICHIARAZIONE>Equal</ID_DICHIARAZIONE>
      <MISURA>Like</MISURA>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CATALOGO_DICHIARAZIONI>
*/