using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for RequisitiPagamentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class RequisitiPagamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private RequisitiPagamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((RequisitiPagamento) info.GetValue(i.ToString(),typeof(RequisitiPagamento)));
			}
		}

		//Costruttore
		public RequisitiPagamentoCollection()
		{
			this.ItemType = typeof(RequisitiPagamento);
		}

		//Costruttore con provider
		public RequisitiPagamentoCollection(IRequisitiPagamentoProvider providerObj)
		{
			this.ItemType = typeof(RequisitiPagamento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new RequisitiPagamento this[int index]
		{
			get { return (RequisitiPagamento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new RequisitiPagamentoCollection GetChanges()
		{
			return (RequisitiPagamentoCollection) base.GetChanges();
		}

		[NonSerialized] private IRequisitiPagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRequisitiPagamentoProvider Provider
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
		public int Add(RequisitiPagamento RequisitiPagamentoObj)
		{
			if (RequisitiPagamentoObj.Provider == null) RequisitiPagamentoObj.Provider = this.Provider;
			return base.Add(RequisitiPagamentoObj);
		}

		//AddCollection
		public void AddCollection(RequisitiPagamentoCollection RequisitiPagamentoCollectionObj)
		{
			foreach (RequisitiPagamento RequisitiPagamentoObj in RequisitiPagamentoCollectionObj)
				this.Add(RequisitiPagamentoObj);
		}

		//Insert
		public void Insert(int index, RequisitiPagamento RequisitiPagamentoObj)
		{
			if (RequisitiPagamentoObj.Provider == null) RequisitiPagamentoObj.Provider = this.Provider;
			base.Insert(index, RequisitiPagamentoObj);
		}

		//CollectionGetById
		public RequisitiPagamento CollectionGetById(NullTypes.IntNT IdRequisitoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdRequisito == IdRequisitoValue))
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
		public RequisitiPagamentoCollection SubSelect(NullTypes.IntNT IdRequisitoEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT PlurivaloreEqualThis, 
NullTypes.BoolNT NumericoEqualThis, NullTypes.BoolNT DatetimeEqualThis, NullTypes.BoolNT TestoSempliceEqualThis, 
NullTypes.BoolNT TestoAreaEqualThis, NullTypes.StringNT UrlEqualThis, NullTypes.StringNT QueryEvalEqualThis, 
NullTypes.StringNT QueryInsertEqualThis, NullTypes.StringNT MisuraEqualThis)
		{
			RequisitiPagamentoCollection RequisitiPagamentoCollectionTemp = new RequisitiPagamentoCollection();
			foreach (RequisitiPagamento RequisitiPagamentoItem in this)
			{
				if (((IdRequisitoEqualThis == null) || ((RequisitiPagamentoItem.IdRequisito != null) && (RequisitiPagamentoItem.IdRequisito.Value == IdRequisitoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((RequisitiPagamentoItem.Descrizione != null) && (RequisitiPagamentoItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((PlurivaloreEqualThis == null) || ((RequisitiPagamentoItem.Plurivalore != null) && (RequisitiPagamentoItem.Plurivalore.Value == PlurivaloreEqualThis.Value))) && 
((NumericoEqualThis == null) || ((RequisitiPagamentoItem.Numerico != null) && (RequisitiPagamentoItem.Numerico.Value == NumericoEqualThis.Value))) && ((DatetimeEqualThis == null) || ((RequisitiPagamentoItem.Datetime != null) && (RequisitiPagamentoItem.Datetime.Value == DatetimeEqualThis.Value))) && ((TestoSempliceEqualThis == null) || ((RequisitiPagamentoItem.TestoSemplice != null) && (RequisitiPagamentoItem.TestoSemplice.Value == TestoSempliceEqualThis.Value))) && 
((TestoAreaEqualThis == null) || ((RequisitiPagamentoItem.TestoArea != null) && (RequisitiPagamentoItem.TestoArea.Value == TestoAreaEqualThis.Value))) && ((UrlEqualThis == null) || ((RequisitiPagamentoItem.Url != null) && (RequisitiPagamentoItem.Url.Value == UrlEqualThis.Value))) && ((QueryEvalEqualThis == null) || ((RequisitiPagamentoItem.QueryEval != null) && (RequisitiPagamentoItem.QueryEval.Value == QueryEvalEqualThis.Value))) && 
((QueryInsertEqualThis == null) || ((RequisitiPagamentoItem.QueryInsert != null) && (RequisitiPagamentoItem.QueryInsert.Value == QueryInsertEqualThis.Value))) && ((MisuraEqualThis == null) || ((RequisitiPagamentoItem.Misura != null) && (RequisitiPagamentoItem.Misura.Value == MisuraEqualThis.Value))))
				{
					RequisitiPagamentoCollectionTemp.Add(RequisitiPagamentoItem);
				}
			}
			return RequisitiPagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public RequisitiPagamentoCollection FiltroTipo(NullTypes.BoolNT PlurivaloreEqualThis, NullTypes.BoolNT NumericoEqualThis, NullTypes.BoolNT DatetimeEqualThis, 
NullTypes.BoolNT TestoSempliceEqualThis, NullTypes.BoolNT TestoAreaEqualThis, NullTypes.BoolNT UrlIsNull)
		{
			RequisitiPagamentoCollection RequisitiPagamentoCollectionTemp = new RequisitiPagamentoCollection();
			foreach (RequisitiPagamento RequisitiPagamentoItem in this)
			{
				if (((PlurivaloreEqualThis == null) || ((RequisitiPagamentoItem.Plurivalore != null) && (RequisitiPagamentoItem.Plurivalore.Value == PlurivaloreEqualThis.Value))) && ((NumericoEqualThis == null) || ((RequisitiPagamentoItem.Numerico != null) && (RequisitiPagamentoItem.Numerico.Value == NumericoEqualThis.Value))) && ((DatetimeEqualThis == null) || ((RequisitiPagamentoItem.Datetime != null) && (RequisitiPagamentoItem.Datetime.Value == DatetimeEqualThis.Value))) && 
((TestoSempliceEqualThis == null) || ((RequisitiPagamentoItem.TestoSemplice != null) && (RequisitiPagamentoItem.TestoSemplice.Value == TestoSempliceEqualThis.Value))) && ((TestoAreaEqualThis == null) || ((RequisitiPagamentoItem.TestoArea != null) && (RequisitiPagamentoItem.TestoArea.Value == TestoAreaEqualThis.Value))) && ((UrlIsNull == null) || ((RequisitiPagamentoItem.Url == null) ==  UrlIsNull.Value)))
				{
					RequisitiPagamentoCollectionTemp.Add(RequisitiPagamentoItem);
				}
			}
			return RequisitiPagamentoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<REQUISITI_PAGAMENTO>
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
</REQUISITI_PAGAMENTO>
*/