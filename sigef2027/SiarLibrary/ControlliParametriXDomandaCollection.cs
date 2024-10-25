using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for ControlliParametriXDomandaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ControlliParametriXDomandaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ControlliParametriXDomandaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ControlliParametriXDomanda) info.GetValue(i.ToString(),typeof(ControlliParametriXDomanda)));
			}
		}

		//Costruttore
		public ControlliParametriXDomandaCollection()
		{
			this.ItemType = typeof(ControlliParametriXDomanda);
		}

		//Costruttore con provider
		public ControlliParametriXDomandaCollection(IControlliParametriXDomandaProvider providerObj)
		{
			this.ItemType = typeof(ControlliParametriXDomanda);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ControlliParametriXDomanda this[int index]
		{
			get { return (ControlliParametriXDomanda)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ControlliParametriXDomandaCollection GetChanges()
		{
			return (ControlliParametriXDomandaCollection) base.GetChanges();
		}

		[NonSerialized] private IControlliParametriXDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliParametriXDomandaProvider Provider
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
		public int Add(ControlliParametriXDomanda ControlliParametriXDomandaObj)
		{
			if (ControlliParametriXDomandaObj.Provider == null) ControlliParametriXDomandaObj.Provider = this.Provider;
			return base.Add(ControlliParametriXDomandaObj);
		}

		//AddCollection
		public void AddCollection(ControlliParametriXDomandaCollection ControlliParametriXDomandaCollectionObj)
		{
			foreach (ControlliParametriXDomanda ControlliParametriXDomandaObj in ControlliParametriXDomandaCollectionObj)
				this.Add(ControlliParametriXDomandaObj);
		}

		//Insert
		public void Insert(int index, ControlliParametriXDomanda ControlliParametriXDomandaObj)
		{
			if (ControlliParametriXDomandaObj.Provider == null) ControlliParametriXDomandaObj.Provider = this.Provider;
			base.Insert(index, ControlliParametriXDomandaObj);
		}

		//CollectionGetById
		public ControlliParametriXDomanda CollectionGetById(NullTypes.IntNT IdDomandaPagamentoValue, NullTypes.IntNT IdParametroValue, NullTypes.IntNT IdLottoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdDomandaPagamento == IdDomandaPagamentoValue) && (this[i].IdParametro == IdParametroValue) && (this[i].IdLotto == IdLottoValue))
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
		public ControlliParametriXDomandaCollection SubSelect(NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdParametroEqualThis, NullTypes.IntNT IdLottoEqualThis, 
NullTypes.IntNT PunteggioEqualThis, NullTypes.DatetimeNT DataValutazioneEqualThis, NullTypes.StringNT OperatoreEqualThis)
		{
			ControlliParametriXDomandaCollection ControlliParametriXDomandaCollectionTemp = new ControlliParametriXDomandaCollection();
			foreach (ControlliParametriXDomanda ControlliParametriXDomandaItem in this)
			{
				if (((IdDomandaPagamentoEqualThis == null) || ((ControlliParametriXDomandaItem.IdDomandaPagamento != null) && (ControlliParametriXDomandaItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdParametroEqualThis == null) || ((ControlliParametriXDomandaItem.IdParametro != null) && (ControlliParametriXDomandaItem.IdParametro.Value == IdParametroEqualThis.Value))) && ((IdLottoEqualThis == null) || ((ControlliParametriXDomandaItem.IdLotto != null) && (ControlliParametriXDomandaItem.IdLotto.Value == IdLottoEqualThis.Value))) && 
((PunteggioEqualThis == null) || ((ControlliParametriXDomandaItem.Punteggio != null) && (ControlliParametriXDomandaItem.Punteggio.Value == PunteggioEqualThis.Value))) && ((DataValutazioneEqualThis == null) || ((ControlliParametriXDomandaItem.DataValutazione != null) && (ControlliParametriXDomandaItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ControlliParametriXDomandaItem.Operatore != null) && (ControlliParametriXDomandaItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					ControlliParametriXDomandaCollectionTemp.Add(ControlliParametriXDomandaItem);
				}
			}
			return ControlliParametriXDomandaCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_PARAMETRI_X_DOMANDA>
  <ViewName>vCONTROLLI_PARAMETRI_X_DOMANDA</ViewName>
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
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <ID_LOTTO>Equal</ID_LOTTO>
      <MANUALE>Equal</MANUALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_X_DOMANDA>
*/