using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for DomandaDiPagamentoSegnatureCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class DomandaDiPagamentoSegnatureCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DomandaDiPagamentoSegnatureCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((DomandaDiPagamentoSegnature) info.GetValue(i.ToString(),typeof(DomandaDiPagamentoSegnature)));
			}
		}

		//Costruttore
		public DomandaDiPagamentoSegnatureCollection()
		{
			this.ItemType = typeof(DomandaDiPagamentoSegnature);
		}

		//Costruttore con provider
		public DomandaDiPagamentoSegnatureCollection(IDomandaDiPagamentoSegnatureProvider providerObj)
		{
			this.ItemType = typeof(DomandaDiPagamentoSegnature);
			this.Provider = providerObj;
		}

		//Get e Set
		public new DomandaDiPagamentoSegnature this[int index]
		{
			get { return (DomandaDiPagamentoSegnature)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DomandaDiPagamentoSegnatureCollection GetChanges()
		{
			return (DomandaDiPagamentoSegnatureCollection) base.GetChanges();
		}

		[NonSerialized] private IDomandaDiPagamentoSegnatureProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDomandaDiPagamentoSegnatureProvider Provider
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
		public int Add(DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj)
		{
			if (DomandaDiPagamentoSegnatureObj.Provider == null) DomandaDiPagamentoSegnatureObj.Provider = this.Provider;
			return base.Add(DomandaDiPagamentoSegnatureObj);
		}

		//AddCollection
		public void AddCollection(DomandaDiPagamentoSegnatureCollection DomandaDiPagamentoSegnatureCollectionObj)
		{
			foreach (DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj in DomandaDiPagamentoSegnatureCollectionObj)
				this.Add(DomandaDiPagamentoSegnatureObj);
		}

		//Insert
		public void Insert(int index, DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureObj)
		{
			if (DomandaDiPagamentoSegnatureObj.Provider == null) DomandaDiPagamentoSegnatureObj.Provider = this.Provider;
			base.Insert(index, DomandaDiPagamentoSegnatureObj);
		}

		//CollectionGetById
		public DomandaDiPagamentoSegnature CollectionGetById(NullTypes.IntNT IdDomandaPagamentoValue, NullTypes.StringNT CodTipoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDomandaPagamento == IdDomandaPagamentoValue) && (this[i].CodTipo == CodTipoValue))
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
		public DomandaDiPagamentoSegnatureCollection SubSelect(NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.DatetimeNT DataEqualThis, 
NullTypes.StringNT OperatoreEqualThis, NullTypes.StringNT SegnaturaEqualThis, NullTypes.BoolNT RiapriDomandaEqualThis)
		{
			DomandaDiPagamentoSegnatureCollection DomandaDiPagamentoSegnatureCollectionTemp = new DomandaDiPagamentoSegnatureCollection();
			foreach (DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureItem in this)
			{
				if (((IdDomandaPagamentoEqualThis == null) || ((DomandaDiPagamentoSegnatureItem.IdDomandaPagamento != null) && (DomandaDiPagamentoSegnatureItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((DomandaDiPagamentoSegnatureItem.CodTipo != null) && (DomandaDiPagamentoSegnatureItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((DataEqualThis == null) || ((DomandaDiPagamentoSegnatureItem.Data != null) && (DomandaDiPagamentoSegnatureItem.Data.Value == DataEqualThis.Value))) && 
((OperatoreEqualThis == null) || ((DomandaDiPagamentoSegnatureItem.Operatore != null) && (DomandaDiPagamentoSegnatureItem.Operatore.Value == OperatoreEqualThis.Value))) && ((SegnaturaEqualThis == null) || ((DomandaDiPagamentoSegnatureItem.Segnatura != null) && (DomandaDiPagamentoSegnatureItem.Segnatura.Value == SegnaturaEqualThis.Value))) && ((RiapriDomandaEqualThis == null) || ((DomandaDiPagamentoSegnatureItem.RiapriDomanda != null) && (DomandaDiPagamentoSegnatureItem.RiapriDomanda.Value == RiapriDomandaEqualThis.Value))))
				{
					DomandaDiPagamentoSegnatureCollectionTemp.Add(DomandaDiPagamentoSegnatureItem);
				}
			}
			return DomandaDiPagamentoSegnatureCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public DomandaDiPagamentoSegnatureCollection FiltroTipo(NullTypes.StringNT CodTipoEqualThis, NullTypes.BoolNT RiapriDomandaEqualThis)
		{
			DomandaDiPagamentoSegnatureCollection DomandaDiPagamentoSegnatureCollectionTemp = new DomandaDiPagamentoSegnatureCollection();
			foreach (DomandaDiPagamentoSegnature DomandaDiPagamentoSegnatureItem in this)
			{
				if (((CodTipoEqualThis == null) || ((DomandaDiPagamentoSegnatureItem.CodTipo != null) && (DomandaDiPagamentoSegnatureItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((RiapriDomandaEqualThis == null) || ((DomandaDiPagamentoSegnatureItem.RiapriDomanda != null) && (DomandaDiPagamentoSegnatureItem.RiapriDomanda.Value == RiapriDomandaEqualThis.Value))))
				{
					DomandaDiPagamentoSegnatureCollectionTemp.Add(DomandaDiPagamentoSegnatureItem);
				}
			}
			return DomandaDiPagamentoSegnatureCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_DI_PAGAMENTO_SEGNATURE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_DOMANDA>Equal</RIAPRI_DOMANDA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_DOMANDA>Equal</RIAPRI_DOMANDA>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOMANDA_DI_PAGAMENTO_SEGNATURE>
*/