using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VariantiSegnatureCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VariantiSegnatureCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VariantiSegnatureCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VariantiSegnature) info.GetValue(i.ToString(),typeof(VariantiSegnature)));
			}
		}

		//Costruttore
		public VariantiSegnatureCollection()
		{
			this.ItemType = typeof(VariantiSegnature);
		}

		//Costruttore con provider
		public VariantiSegnatureCollection(IVariantiSegnatureProvider providerObj)
		{
			this.ItemType = typeof(VariantiSegnature);
			this.Provider = providerObj;
		}

		//Get e Set
		public new VariantiSegnature this[int index]
		{
			get { return (VariantiSegnature)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VariantiSegnatureCollection GetChanges()
		{
			return (VariantiSegnatureCollection) base.GetChanges();
		}

		[NonSerialized] private IVariantiSegnatureProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVariantiSegnatureProvider Provider
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
		public int Add(VariantiSegnature VariantiSegnatureObj)
		{
			if (VariantiSegnatureObj.Provider == null) VariantiSegnatureObj.Provider = this.Provider;
			return base.Add(VariantiSegnatureObj);
		}

		//AddCollection
		public void AddCollection(VariantiSegnatureCollection VariantiSegnatureCollectionObj)
		{
			foreach (VariantiSegnature VariantiSegnatureObj in VariantiSegnatureCollectionObj)
				this.Add(VariantiSegnatureObj);
		}

		//Insert
		public void Insert(int index, VariantiSegnature VariantiSegnatureObj)
		{
			if (VariantiSegnatureObj.Provider == null) VariantiSegnatureObj.Provider = this.Provider;
			base.Insert(index, VariantiSegnatureObj);
		}

		//CollectionGetById
		public VariantiSegnature CollectionGetById(NullTypes.IntNT IdVarianteValue, NullTypes.StringNT CodTipoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdVariante == IdVarianteValue) && (this[i].CodTipo == CodTipoValue))
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
		public VariantiSegnatureCollection SubSelect(NullTypes.IntNT IdVarianteEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.StringNT SegnaturaEqualThis, 
NullTypes.DatetimeNT DataEqualThis, NullTypes.StringNT OperatoreEqualThis, NullTypes.BoolNT RiapriVarianteEqualThis)
		{
			VariantiSegnatureCollection VariantiSegnatureCollectionTemp = new VariantiSegnatureCollection();
			foreach (VariantiSegnature VariantiSegnatureItem in this)
			{
				if (((IdVarianteEqualThis == null) || ((VariantiSegnatureItem.IdVariante != null) && (VariantiSegnatureItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((CodTipoEqualThis == null) || ((VariantiSegnatureItem.CodTipo != null) && (VariantiSegnatureItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((VariantiSegnatureItem.Segnatura != null) && (VariantiSegnatureItem.Segnatura.Value == SegnaturaEqualThis.Value))) && 
((DataEqualThis == null) || ((VariantiSegnatureItem.Data != null) && (VariantiSegnatureItem.Data.Value == DataEqualThis.Value))) && ((OperatoreEqualThis == null) || ((VariantiSegnatureItem.Operatore != null) && (VariantiSegnatureItem.Operatore.Value == OperatoreEqualThis.Value))) && ((RiapriVarianteEqualThis == null) || ((VariantiSegnatureItem.RiapriVariante != null) && (VariantiSegnatureItem.RiapriVariante.Value == RiapriVarianteEqualThis.Value))))
				{
					VariantiSegnatureCollectionTemp.Add(VariantiSegnatureItem);
				}
			}
			return VariantiSegnatureCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VariantiSegnatureCollection FiltroTipo(NullTypes.StringNT CodTipoEqualThis, NullTypes.BoolNT RiapriVarianteEqualThis)
		{
			VariantiSegnatureCollection VariantiSegnatureCollectionTemp = new VariantiSegnatureCollection();
			foreach (VariantiSegnature VariantiSegnatureItem in this)
			{
				if (((CodTipoEqualThis == null) || ((VariantiSegnatureItem.CodTipo != null) && (VariantiSegnatureItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((RiapriVarianteEqualThis == null) || ((VariantiSegnatureItem.RiapriVariante != null) && (VariantiSegnatureItem.RiapriVariante.Value == RiapriVarianteEqualThis.Value))))
				{
					VariantiSegnatureCollectionTemp.Add(VariantiSegnatureItem);
				}
			}
			return VariantiSegnatureCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_SEGNATURE>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_VARIANTE>Equal</RIAPRI_VARIANTE>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_VARIANTE>Equal</RIAPRI_VARIANTE>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_SEGNATURE>
*/