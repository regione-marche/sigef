using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for BandoTipoPagamentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BandoTipoPagamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoTipoPagamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoTipoPagamento) info.GetValue(i.ToString(),typeof(BandoTipoPagamento)));
			}
		}

		//Costruttore
		public BandoTipoPagamentoCollection()
		{
			this.ItemType = typeof(BandoTipoPagamento);
		}

		//Costruttore con provider
		public BandoTipoPagamentoCollection(IBandoTipoPagamentoProvider providerObj)
		{
			this.ItemType = typeof(BandoTipoPagamento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoTipoPagamento this[int index]
		{
			get { return (BandoTipoPagamento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoTipoPagamentoCollection GetChanges()
		{
			return (BandoTipoPagamentoCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoTipoPagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoTipoPagamentoProvider Provider
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
		public int Add(BandoTipoPagamento BandoTipoPagamentoObj)
		{
			if (BandoTipoPagamentoObj.Provider == null) BandoTipoPagamentoObj.Provider = this.Provider;
			return base.Add(BandoTipoPagamentoObj);
		}

		//AddCollection
		public void AddCollection(BandoTipoPagamentoCollection BandoTipoPagamentoCollectionObj)
		{
			foreach (BandoTipoPagamento BandoTipoPagamentoObj in BandoTipoPagamentoCollectionObj)
				this.Add(BandoTipoPagamentoObj);
		}

		//Insert
		public void Insert(int index, BandoTipoPagamento BandoTipoPagamentoObj)
		{
			if (BandoTipoPagamentoObj.Provider == null) BandoTipoPagamentoObj.Provider = this.Provider;
			base.Insert(index, BandoTipoPagamentoObj);
		}

		//CollectionGetById
		public BandoTipoPagamento CollectionGetById(NullTypes.IntNT IdBandoValue, NullTypes.StringNT CodTipoValue)
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
		public BandoTipoPagamentoCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.DecimalNT QuotaMaxEqualThis, 
NullTypes.DecimalNT QuotaMinEqualThis, NullTypes.DecimalNT ImportoMaxEqualThis, NullTypes.DecimalNT ImportoMinEqualThis, 
NullTypes.IntNT NumeroEqualThis, NullTypes.StringNT CodTipoPolizzaEqualThis)
		{
			BandoTipoPagamentoCollection BandoTipoPagamentoCollectionTemp = new BandoTipoPagamentoCollection();
			foreach (BandoTipoPagamento BandoTipoPagamentoItem in this)
			{
				if (((IdBandoEqualThis == null) || ((BandoTipoPagamentoItem.IdBando != null) && (BandoTipoPagamentoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((BandoTipoPagamentoItem.CodTipo != null) && (BandoTipoPagamentoItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((QuotaMaxEqualThis == null) || ((BandoTipoPagamentoItem.QuotaMax != null) && (BandoTipoPagamentoItem.QuotaMax.Value == QuotaMaxEqualThis.Value))) && 
((QuotaMinEqualThis == null) || ((BandoTipoPagamentoItem.QuotaMin != null) && (BandoTipoPagamentoItem.QuotaMin.Value == QuotaMinEqualThis.Value))) && ((ImportoMaxEqualThis == null) || ((BandoTipoPagamentoItem.ImportoMax != null) && (BandoTipoPagamentoItem.ImportoMax.Value == ImportoMaxEqualThis.Value))) && ((ImportoMinEqualThis == null) || ((BandoTipoPagamentoItem.ImportoMin != null) && (BandoTipoPagamentoItem.ImportoMin.Value == ImportoMinEqualThis.Value))) && 
((NumeroEqualThis == null) || ((BandoTipoPagamentoItem.Numero != null) && (BandoTipoPagamentoItem.Numero.Value == NumeroEqualThis.Value))) && ((CodTipoPolizzaEqualThis == null) || ((BandoTipoPagamentoItem.CodTipoPolizza != null) && (BandoTipoPagamentoItem.CodTipoPolizza.Value == CodTipoPolizzaEqualThis.Value))))
				{
					BandoTipoPagamentoCollectionTemp.Add(BandoTipoPagamentoItem);
				}
			}
			return BandoTipoPagamentoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_TIPO_PAGAMENTO>
  <ViewName>vBANDO_TIPO_PAGAMENTO</ViewName>
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
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BANDO_TIPO_PAGAMENTO>
*/