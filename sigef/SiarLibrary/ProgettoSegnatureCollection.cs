using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for ProgettoSegnatureCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ProgettoSegnatureCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProgettoSegnatureCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProgettoSegnature) info.GetValue(i.ToString(),typeof(ProgettoSegnature)));
			}
		}

		//Costruttore
		public ProgettoSegnatureCollection()
		{
			this.ItemType = typeof(ProgettoSegnature);
		}

		//Costruttore con provider
		public ProgettoSegnatureCollection(IProgettoSegnatureProvider providerObj)
		{
			this.ItemType = typeof(ProgettoSegnature);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProgettoSegnature this[int index]
		{
			get { return (ProgettoSegnature)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProgettoSegnatureCollection GetChanges()
		{
			return (ProgettoSegnatureCollection) base.GetChanges();
		}

		[NonSerialized] private IProgettoSegnatureProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProgettoSegnatureProvider Provider
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
		public int Add(ProgettoSegnature ProgettoSegnatureObj)
		{
			if (ProgettoSegnatureObj.Provider == null) ProgettoSegnatureObj.Provider = this.Provider;
			return base.Add(ProgettoSegnatureObj);
		}

		//AddCollection
		public void AddCollection(ProgettoSegnatureCollection ProgettoSegnatureCollectionObj)
		{
			foreach (ProgettoSegnature ProgettoSegnatureObj in ProgettoSegnatureCollectionObj)
				this.Add(ProgettoSegnatureObj);
		}

		//Insert
		public void Insert(int index, ProgettoSegnature ProgettoSegnatureObj)
		{
			if (ProgettoSegnatureObj.Provider == null) ProgettoSegnatureObj.Provider = this.Provider;
			base.Insert(index, ProgettoSegnatureObj);
		}

		//CollectionGetById
		public ProgettoSegnature CollectionGetById(NullTypes.IntNT IdProgettoValue, NullTypes.StringNT CodTipoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdProgetto == IdProgettoValue) && (this[i].CodTipo == CodTipoValue))
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
		public ProgettoSegnatureCollection SubSelect(NullTypes.IntNT IdProgettoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.StringNT OperatoreEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.BoolNT RiapriDomandaEqualThis)
		{
			ProgettoSegnatureCollection ProgettoSegnatureCollectionTemp = new ProgettoSegnatureCollection();
			foreach (ProgettoSegnature ProgettoSegnatureItem in this)
			{
				if (((IdProgettoEqualThis == null) || ((ProgettoSegnatureItem.IdProgetto != null) && (ProgettoSegnatureItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((ProgettoSegnatureItem.CodTipo != null) && (ProgettoSegnatureItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((DataEqualThis == null) || ((ProgettoSegnatureItem.Data != null) && (ProgettoSegnatureItem.Data.Value == DataEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((ProgettoSegnatureItem.Operatore != null) && (ProgettoSegnatureItem.Operatore.Value == OperatoreEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((ProgettoSegnatureItem.Segnatura != null) && (ProgettoSegnatureItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((RiapriDomandaEqualThis == null) || ((ProgettoSegnatureItem.RiapriDomanda != null) && (ProgettoSegnatureItem.RiapriDomanda.Value == RiapriDomandaEqualThis.Value))))
				{
					ProgettoSegnatureCollectionTemp.Add(ProgettoSegnatureItem);
				}
			}
			return ProgettoSegnatureCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ProgettoSegnatureCollection FiltroLikeTipoSegnatura(NullTypes.StringNT CodTipoLike)
		{
			ProgettoSegnatureCollection ProgettoSegnatureCollectionTemp = new ProgettoSegnatureCollection();
			foreach (ProgettoSegnature ProgettoSegnatureItem in this)
			{
				if (((CodTipoLike == null) || ((ProgettoSegnatureItem.CodTipo !=null) &&(ProgettoSegnatureItem.CodTipo.Like(CodTipoLike.Value)))))
				{
					ProgettoSegnatureCollectionTemp.Add(ProgettoSegnatureItem);
				}
			}
			return ProgettoSegnatureCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROGETTO_SEGNATURE>
  <ViewName>vPROGETTO_SEGNATURE</ViewName>
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
    <Find OrderBy="ORDER BY ID_PROGETTO, DATA DESC">
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <OPERATORE>Equal</OPERATORE>
      <SEGNATURA>Equal</SEGNATURA>
      <COD_TIPO>Like</COD_TIPO>
    </Find>
  </Finds>
  <Filters>
    <FiltroLikeTipoSegnatura>
      <COD_TIPO>Like</COD_TIPO>
    </FiltroLikeTipoSegnatura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROGETTO_SEGNATURE>
*/