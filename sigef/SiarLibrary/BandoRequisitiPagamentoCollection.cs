using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for BandoRequisitiPagamentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BandoRequisitiPagamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoRequisitiPagamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoRequisitiPagamento) info.GetValue(i.ToString(),typeof(BandoRequisitiPagamento)));
			}
		}

		//Costruttore
		public BandoRequisitiPagamentoCollection()
		{
			this.ItemType = typeof(BandoRequisitiPagamento);
		}

		//Costruttore con provider
		public BandoRequisitiPagamentoCollection(IBandoRequisitiPagamentoProvider providerObj)
		{
			this.ItemType = typeof(BandoRequisitiPagamento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoRequisitiPagamento this[int index]
		{
			get { return (BandoRequisitiPagamento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoRequisitiPagamentoCollection GetChanges()
		{
			return (BandoRequisitiPagamentoCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoRequisitiPagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoRequisitiPagamentoProvider Provider
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
		public int Add(BandoRequisitiPagamento BandoRequisitiPagamentoObj)
		{
			if (BandoRequisitiPagamentoObj.Provider == null) BandoRequisitiPagamentoObj.Provider = this.Provider;
			return base.Add(BandoRequisitiPagamentoObj);
		}

		//AddCollection
		public void AddCollection(BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionObj)
		{
			foreach (BandoRequisitiPagamento BandoRequisitiPagamentoObj in BandoRequisitiPagamentoCollectionObj)
				this.Add(BandoRequisitiPagamentoObj);
		}

		//Insert
		public void Insert(int index, BandoRequisitiPagamento BandoRequisitiPagamentoObj)
		{
			if (BandoRequisitiPagamentoObj.Provider == null) BandoRequisitiPagamentoObj.Provider = this.Provider;
			base.Insert(index, BandoRequisitiPagamentoObj);
		}

		//CollectionGetById
		public BandoRequisitiPagamento CollectionGetById(NullTypes.IntNT IdBandoValue, NullTypes.StringNT CodTipoValue, NullTypes.IntNT IdRequisitoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBando == IdBandoValue) && (this[i].CodTipo == CodTipoValue) && (this[i].IdRequisito == IdRequisitoValue))
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
		public BandoRequisitiPagamentoCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.IntNT IdRequisitoEqualThis, 
NullTypes.BoolNT ObbligatorioEqualThis, NullTypes.BoolNT RequisitoDiInserimentoEqualThis, NullTypes.BoolNT RequisitoDiControlloEqualThis, 
NullTypes.IntNT OrdineEqualThis)
		{
			BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionTemp = new BandoRequisitiPagamentoCollection();
			foreach (BandoRequisitiPagamento BandoRequisitiPagamentoItem in this)
			{
				if (((IdBandoEqualThis == null) || ((BandoRequisitiPagamentoItem.IdBando != null) && (BandoRequisitiPagamentoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((BandoRequisitiPagamentoItem.CodTipo != null) && (BandoRequisitiPagamentoItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((IdRequisitoEqualThis == null) || ((BandoRequisitiPagamentoItem.IdRequisito != null) && (BandoRequisitiPagamentoItem.IdRequisito.Value == IdRequisitoEqualThis.Value))) && 
((ObbligatorioEqualThis == null) || ((BandoRequisitiPagamentoItem.Obbligatorio != null) && (BandoRequisitiPagamentoItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))) && ((RequisitoDiInserimentoEqualThis == null) || ((BandoRequisitiPagamentoItem.RequisitoDiInserimento != null) && (BandoRequisitiPagamentoItem.RequisitoDiInserimento.Value == RequisitoDiInserimentoEqualThis.Value))) && ((RequisitoDiControlloEqualThis == null) || ((BandoRequisitiPagamentoItem.RequisitoDiControllo != null) && (BandoRequisitiPagamentoItem.RequisitoDiControllo.Value == RequisitoDiControlloEqualThis.Value))) && 
((OrdineEqualThis == null) || ((BandoRequisitiPagamentoItem.Ordine != null) && (BandoRequisitiPagamentoItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					BandoRequisitiPagamentoCollectionTemp.Add(BandoRequisitiPagamentoItem);
				}
			}
			return BandoRequisitiPagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoRequisitiPagamentoCollection FiltroObbligatorio(NullTypes.BoolNT ObbligatorioEqualThis)
		{
			BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionTemp = new BandoRequisitiPagamentoCollection();
			foreach (BandoRequisitiPagamento BandoRequisitiPagamentoItem in this)
			{
				if (((ObbligatorioEqualThis == null) || ((BandoRequisitiPagamentoItem.Obbligatorio != null) && (BandoRequisitiPagamentoItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))))
				{
					BandoRequisitiPagamentoCollectionTemp.Add(BandoRequisitiPagamentoItem);
				}
			}
			return BandoRequisitiPagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoRequisitiPagamentoCollection FiltroDiControllo(NullTypes.BoolNT RequisitoDiControlloEqualThis)
		{
			BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionTemp = new BandoRequisitiPagamentoCollection();
			foreach (BandoRequisitiPagamento BandoRequisitiPagamentoItem in this)
			{
				if (((RequisitoDiControlloEqualThis == null) || ((BandoRequisitiPagamentoItem.RequisitoDiControllo != null) && (BandoRequisitiPagamentoItem.RequisitoDiControllo.Value == RequisitoDiControlloEqualThis.Value))))
				{
					BandoRequisitiPagamentoCollectionTemp.Add(BandoRequisitiPagamentoItem);
				}
			}
			return BandoRequisitiPagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoRequisitiPagamentoCollection FiltroDiInserimento(NullTypes.BoolNT RequisitoDiInserimentoEqualThis)
		{
			BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionTemp = new BandoRequisitiPagamentoCollection();
			foreach (BandoRequisitiPagamento BandoRequisitiPagamentoItem in this)
			{
				if (((RequisitoDiInserimentoEqualThis == null) || ((BandoRequisitiPagamentoItem.RequisitoDiInserimento != null) && (BandoRequisitiPagamentoItem.RequisitoDiInserimento.Value == RequisitoDiInserimentoEqualThis.Value))))
				{
					BandoRequisitiPagamentoCollectionTemp.Add(BandoRequisitiPagamentoItem);
				}
			}
			return BandoRequisitiPagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoRequisitiPagamentoCollection FiltroMisura(NullTypes.StringNT MisuraEqualThis)
		{
			BandoRequisitiPagamentoCollection BandoRequisitiPagamentoCollectionTemp = new BandoRequisitiPagamentoCollection();
			foreach (BandoRequisitiPagamento BandoRequisitiPagamentoItem in this)
			{
				if (((BandoRequisitiPagamentoItem.IdBando != null)||(MisuraEqualThis == null) || ((BandoRequisitiPagamentoItem.Misura != null) && (BandoRequisitiPagamentoItem.Misura.Value.Contains (MisuraEqualThis.Value)))))
				{
					BandoRequisitiPagamentoCollectionTemp.Add(BandoRequisitiPagamentoItem);
				}
			}
			return BandoRequisitiPagamentoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_REQUISITI_PAGAMENTO>
  <ViewName>vBANDO_REQUISITI_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE, ORDINE_FASE">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_REQUISITO>Equal</ID_REQUISITO>
    </Find>
  </Finds>
  <Filters>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
    <FiltroDiControllo>
      <REQUISITO_DI_CONTROLLO>Equal</REQUISITO_DI_CONTROLLO>
    </FiltroDiControllo>
    <FiltroDiInserimento>
      <REQUISITO_DI_INSERIMENTO>Equal</REQUISITO_DI_INSERIMENTO>
    </FiltroDiInserimento>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_REQUISITI_PAGAMENTO>
*/