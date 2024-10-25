using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for BandoTipoVariantiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BandoTipoVariantiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoTipoVariantiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoTipoVarianti) info.GetValue(i.ToString(),typeof(BandoTipoVarianti)));
			}
		}

		//Costruttore
		public BandoTipoVariantiCollection()
		{
			this.ItemType = typeof(BandoTipoVarianti);
		}

		//Costruttore con provider
		public BandoTipoVariantiCollection(IBandoTipoVariantiProvider providerObj)
		{
			this.ItemType = typeof(BandoTipoVarianti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoTipoVarianti this[int index]
		{
			get { return (BandoTipoVarianti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoTipoVariantiCollection GetChanges()
		{
			return (BandoTipoVariantiCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoTipoVariantiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoTipoVariantiProvider Provider
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
		public int Add(BandoTipoVarianti BandoTipoVariantiObj)
		{
			if (BandoTipoVariantiObj.Provider == null) BandoTipoVariantiObj.Provider = this.Provider;
			return base.Add(BandoTipoVariantiObj);
		}

		//AddCollection
		public void AddCollection(BandoTipoVariantiCollection BandoTipoVariantiCollectionObj)
		{
			foreach (BandoTipoVarianti BandoTipoVariantiObj in BandoTipoVariantiCollectionObj)
				this.Add(BandoTipoVariantiObj);
		}

		//Insert
		public void Insert(int index, BandoTipoVarianti BandoTipoVariantiObj)
		{
			if (BandoTipoVariantiObj.Provider == null) BandoTipoVariantiObj.Provider = this.Provider;
			base.Insert(index, BandoTipoVariantiObj);
		}

		//CollectionGetById
		public BandoTipoVarianti CollectionGetById(NullTypes.IntNT IdBandoValue, NullTypes.StringNT CodTipoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBando == IdBandoValue) && (this[i].CodTipo == CodTipoValue))
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
		public BandoTipoVariantiCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.IntNT NumeroMassimoEqualThis)
		{
			BandoTipoVariantiCollection BandoTipoVariantiCollectionTemp = new BandoTipoVariantiCollection();
			foreach (BandoTipoVarianti BandoTipoVariantiItem in this)
			{
				if (((IdBandoEqualThis == null) || ((BandoTipoVariantiItem.IdBando != null) && (BandoTipoVariantiItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((BandoTipoVariantiItem.CodTipo != null) && (BandoTipoVariantiItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((NumeroMassimoEqualThis == null) || ((BandoTipoVariantiItem.NumeroMassimo != null) && (BandoTipoVariantiItem.NumeroMassimo.Value == NumeroMassimoEqualThis.Value))))
				{
					BandoTipoVariantiCollectionTemp.Add(BandoTipoVariantiItem);
				}
			}
			return BandoTipoVariantiCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_TIPO_VARIANTI>
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
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_TIPO_VARIANTI>
*/