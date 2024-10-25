using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for DomandaPagamentoRequisitiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class DomandaPagamentoRequisitiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private DomandaPagamentoRequisitiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((DomandaPagamentoRequisiti) info.GetValue(i.ToString(),typeof(DomandaPagamentoRequisiti)));
			}
		}

		//Costruttore
		public DomandaPagamentoRequisitiCollection()
		{
			this.ItemType = typeof(DomandaPagamentoRequisiti);
		}

		//Costruttore con provider
		public DomandaPagamentoRequisitiCollection(IDomandaPagamentoRequisitiProvider providerObj)
		{
			this.ItemType = typeof(DomandaPagamentoRequisiti);
			this.Provider = providerObj;
		}

		//Get e Set
		public new DomandaPagamentoRequisiti this[int index]
		{
			get { return (DomandaPagamentoRequisiti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new DomandaPagamentoRequisitiCollection GetChanges()
		{
			return (DomandaPagamentoRequisitiCollection) base.GetChanges();
		}

		[NonSerialized] private IDomandaPagamentoRequisitiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IDomandaPagamentoRequisitiProvider Provider
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
		public int Add(DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj)
		{
			if (DomandaPagamentoRequisitiObj.Provider == null) DomandaPagamentoRequisitiObj.Provider = this.Provider;
			return base.Add(DomandaPagamentoRequisitiObj);
		}

		//AddCollection
		public void AddCollection(DomandaPagamentoRequisitiCollection DomandaPagamentoRequisitiCollectionObj)
		{
			foreach (DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj in DomandaPagamentoRequisitiCollectionObj)
				this.Add(DomandaPagamentoRequisitiObj);
		}

		//Insert
		public void Insert(int index, DomandaPagamentoRequisiti DomandaPagamentoRequisitiObj)
		{
			if (DomandaPagamentoRequisitiObj.Provider == null) DomandaPagamentoRequisitiObj.Provider = this.Provider;
			base.Insert(index, DomandaPagamentoRequisitiObj);
		}

		//CollectionGetById
		public DomandaPagamentoRequisiti CollectionGetById(NullTypes.IntNT IdDomandaPagamentoValue, NullTypes.IntNT IdRequisitoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDomandaPagamento == IdDomandaPagamentoValue) && (this[i].IdRequisito == IdRequisitoValue))
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
		public DomandaPagamentoRequisitiCollection SubSelect(NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdRequisitoEqualThis, NullTypes.IntNT IdValoreEqualThis, 
NullTypes.DecimalNT ValNumericoEqualThis, NullTypes.DatetimeNT ValDataEqualThis, NullTypes.StringNT ValTestoEqualThis, 
NullTypes.StringNT EsitoEqualThis, NullTypes.DatetimeNT DataEsitoEqualThis, NullTypes.BoolNT SelezionatoEqualThis)
		{
			DomandaPagamentoRequisitiCollection DomandaPagamentoRequisitiCollectionTemp = new DomandaPagamentoRequisitiCollection();
			foreach (DomandaPagamentoRequisiti DomandaPagamentoRequisitiItem in this)
			{
				if (((IdDomandaPagamentoEqualThis == null) || ((DomandaPagamentoRequisitiItem.IdDomandaPagamento != null) && (DomandaPagamentoRequisitiItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdRequisitoEqualThis == null) || ((DomandaPagamentoRequisitiItem.IdRequisito != null) && (DomandaPagamentoRequisitiItem.IdRequisito.Value == IdRequisitoEqualThis.Value))) && ((IdValoreEqualThis == null) || ((DomandaPagamentoRequisitiItem.IdValore != null) && (DomandaPagamentoRequisitiItem.IdValore.Value == IdValoreEqualThis.Value))) && 
((ValNumericoEqualThis == null) || ((DomandaPagamentoRequisitiItem.ValNumerico != null) && (DomandaPagamentoRequisitiItem.ValNumerico.Value == ValNumericoEqualThis.Value))) && ((ValDataEqualThis == null) || ((DomandaPagamentoRequisitiItem.ValData != null) && (DomandaPagamentoRequisitiItem.ValData.Value == ValDataEqualThis.Value))) && ((ValTestoEqualThis == null) || ((DomandaPagamentoRequisitiItem.ValTesto != null) && (DomandaPagamentoRequisitiItem.ValTesto.Value == ValTestoEqualThis.Value))) && 
((EsitoEqualThis == null) || ((DomandaPagamentoRequisitiItem.Esito != null) && (DomandaPagamentoRequisitiItem.Esito.Value == EsitoEqualThis.Value))) && ((DataEsitoEqualThis == null) || ((DomandaPagamentoRequisitiItem.DataEsito != null) && (DomandaPagamentoRequisitiItem.DataEsito.Value == DataEsitoEqualThis.Value))) && ((SelezionatoEqualThis == null) || ((DomandaPagamentoRequisitiItem.Selezionato != null) && (DomandaPagamentoRequisitiItem.Selezionato.Value == SelezionatoEqualThis.Value))))
				{
					DomandaPagamentoRequisitiCollectionTemp.Add(DomandaPagamentoRequisitiItem);
				}
			}
			return DomandaPagamentoRequisitiCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public DomandaPagamentoRequisitiCollection FiltroTipo(NullTypes.BoolNT PlurivaloreEqualThis, NullTypes.BoolNT NumericoEqualThis, NullTypes.BoolNT DatetimeEqualThis, 
NullTypes.BoolNT TestoSempliceEqualThis, NullTypes.BoolNT TestoAreaEqualThis, NullTypes.BoolNT UrlIsNull)
		{
			DomandaPagamentoRequisitiCollection DomandaPagamentoRequisitiCollectionTemp = new DomandaPagamentoRequisitiCollection();
			foreach (DomandaPagamentoRequisiti DomandaPagamentoRequisitiItem in this)
			{
				if (((PlurivaloreEqualThis == null) || ((DomandaPagamentoRequisitiItem.Plurivalore != null) && (DomandaPagamentoRequisitiItem.Plurivalore.Value == PlurivaloreEqualThis.Value))) && ((NumericoEqualThis == null) || ((DomandaPagamentoRequisitiItem.Numerico != null) && (DomandaPagamentoRequisitiItem.Numerico.Value == NumericoEqualThis.Value))) && ((DatetimeEqualThis == null) || ((DomandaPagamentoRequisitiItem.Datetime != null) && (DomandaPagamentoRequisitiItem.Datetime.Value == DatetimeEqualThis.Value))) && 
((TestoSempliceEqualThis == null) || ((DomandaPagamentoRequisitiItem.TestoSemplice != null) && (DomandaPagamentoRequisitiItem.TestoSemplice.Value == TestoSempliceEqualThis.Value))) && ((TestoAreaEqualThis == null) || ((DomandaPagamentoRequisitiItem.TestoArea != null) && (DomandaPagamentoRequisitiItem.TestoArea.Value == TestoAreaEqualThis.Value))) && ((UrlIsNull == null) || ((DomandaPagamentoRequisitiItem.Url == null) ==  UrlIsNull.Value)))
				{
					DomandaPagamentoRequisitiCollectionTemp.Add(DomandaPagamentoRequisitiItem);
				}
			}
			return DomandaPagamentoRequisitiCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOMANDA_PAGAMENTO_REQUISITI>
  <ViewName>vDOMANDA_REQUISITI_PAGAMENTO</ViewName>
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
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <MISURA>Like</MISURA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <PLURIVALORE>Equal</PLURIVALORE>
      <NUMERICO>Equal</NUMERICO>
      <DATETIME>Equal</DATETIME>
      <TESTO_SEMPLICE>Equal</TESTO_SEMPLICE>
      <TESTO_AREA>Equal</TESTO_AREA>
      <URL>IsNull</URL>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOMANDA_PAGAMENTO_REQUISITI>
*/