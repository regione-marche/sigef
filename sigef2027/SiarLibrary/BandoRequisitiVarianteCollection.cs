using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for BandoRequisitiVarianteCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BandoRequisitiVarianteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private BandoRequisitiVarianteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((BandoRequisitiVariante) info.GetValue(i.ToString(),typeof(BandoRequisitiVariante)));
			}
		}

		//Costruttore
		public BandoRequisitiVarianteCollection()
		{
			this.ItemType = typeof(BandoRequisitiVariante);
		}

		//Costruttore con provider
		public BandoRequisitiVarianteCollection(IBandoRequisitiVarianteProvider providerObj)
		{
			this.ItemType = typeof(BandoRequisitiVariante);
			this.Provider = providerObj;
		}

		//Get e Set
		public new BandoRequisitiVariante this[int index]
		{
			get { return (BandoRequisitiVariante)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new BandoRequisitiVarianteCollection GetChanges()
		{
			return (BandoRequisitiVarianteCollection) base.GetChanges();
		}

		[NonSerialized] private IBandoRequisitiVarianteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IBandoRequisitiVarianteProvider Provider
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
		public int Add(BandoRequisitiVariante BandoRequisitiVarianteObj)
		{
			if (BandoRequisitiVarianteObj.Provider == null) BandoRequisitiVarianteObj.Provider = this.Provider;
			return base.Add(BandoRequisitiVarianteObj);
		}

		//AddCollection
		public void AddCollection(BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionObj)
		{
			foreach (BandoRequisitiVariante BandoRequisitiVarianteObj in BandoRequisitiVarianteCollectionObj)
				this.Add(BandoRequisitiVarianteObj);
		}

		//Insert
		public void Insert(int index, BandoRequisitiVariante BandoRequisitiVarianteObj)
		{
			if (BandoRequisitiVarianteObj.Provider == null) BandoRequisitiVarianteObj.Provider = this.Provider;
			base.Insert(index, BandoRequisitiVarianteObj);
		}

		//CollectionGetById
		public BandoRequisitiVariante CollectionGetById(NullTypes.IntNT IdBandoValue, NullTypes.StringNT CodTipoValue, NullTypes.IntNT IdRequisitoValue)
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
		public BandoRequisitiVarianteCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.IntNT IdRequisitoEqualThis, 
NullTypes.BoolNT ObbligatorioEqualThis, NullTypes.BoolNT RequisitoDiPresentazioneEqualThis, NullTypes.BoolNT RequisitoDiIstruttoriaEqualThis, 
NullTypes.IntNT OrdineEqualThis)
		{
			BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionTemp = new BandoRequisitiVarianteCollection();
			foreach (BandoRequisitiVariante BandoRequisitiVarianteItem in this)
			{
				if (((IdBandoEqualThis == null) || ((BandoRequisitiVarianteItem.IdBando != null) && (BandoRequisitiVarianteItem.IdBando.Value == IdBandoEqualThis.Value))) && ((CodTipoEqualThis == null) || ((BandoRequisitiVarianteItem.CodTipo != null) && (BandoRequisitiVarianteItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((IdRequisitoEqualThis == null) || ((BandoRequisitiVarianteItem.IdRequisito != null) && (BandoRequisitiVarianteItem.IdRequisito.Value == IdRequisitoEqualThis.Value))) && 
((ObbligatorioEqualThis == null) || ((BandoRequisitiVarianteItem.Obbligatorio != null) && (BandoRequisitiVarianteItem.Obbligatorio.Value == ObbligatorioEqualThis.Value))) && ((RequisitoDiPresentazioneEqualThis == null) || ((BandoRequisitiVarianteItem.RequisitoDiPresentazione != null) && (BandoRequisitiVarianteItem.RequisitoDiPresentazione.Value == RequisitoDiPresentazioneEqualThis.Value))) && ((RequisitoDiIstruttoriaEqualThis == null) || ((BandoRequisitiVarianteItem.RequisitoDiIstruttoria != null) && (BandoRequisitiVarianteItem.RequisitoDiIstruttoria.Value == RequisitoDiIstruttoriaEqualThis.Value))) && 
((OrdineEqualThis == null) || ((BandoRequisitiVarianteItem.Ordine != null) && (BandoRequisitiVarianteItem.Ordine.Value == OrdineEqualThis.Value))))
				{
					BandoRequisitiVarianteCollectionTemp.Add(BandoRequisitiVarianteItem);
				}
			}
			return BandoRequisitiVarianteCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoRequisitiVarianteCollection FiltroProcedura(NullTypes.BoolNT RequisitoDiPresentazioneEqualThis, NullTypes.BoolNT RequisitoDiIstruttoriaEqualThis)
		{
			BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionTemp = new BandoRequisitiVarianteCollection();
			foreach (BandoRequisitiVariante BandoRequisitiVarianteItem in this)
			{
				if (((RequisitoDiPresentazioneEqualThis == null) || ((BandoRequisitiVarianteItem.RequisitoDiPresentazione != null) && (BandoRequisitiVarianteItem.RequisitoDiPresentazione.Value == RequisitoDiPresentazioneEqualThis.Value))) && ((RequisitoDiIstruttoriaEqualThis == null) || ((BandoRequisitiVarianteItem.RequisitoDiIstruttoria != null) && (BandoRequisitiVarianteItem.RequisitoDiIstruttoria.Value == RequisitoDiIstruttoriaEqualThis.Value))))
				{
					BandoRequisitiVarianteCollectionTemp.Add(BandoRequisitiVarianteItem);
				}
			}
			return BandoRequisitiVarianteCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoRequisitiVarianteCollection FiltroAutomatico(NullTypes.BoolNT AutomaticoEqualThis)
		{
			BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionTemp = new BandoRequisitiVarianteCollection();
			foreach (BandoRequisitiVariante BandoRequisitiVarianteItem in this)
			{
				if (((AutomaticoEqualThis == null) || ((BandoRequisitiVarianteItem.Automatico != null) && (BandoRequisitiVarianteItem.Automatico.Value == AutomaticoEqualThis.Value))))
				{
					BandoRequisitiVarianteCollectionTemp.Add(BandoRequisitiVarianteItem);
				}
			}
			return BandoRequisitiVarianteCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public BandoRequisitiVarianteCollection FiltroMisura(NullTypes.StringNT MisuraEqualThis)
		{
			BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionTemp = new BandoRequisitiVarianteCollection();
			foreach (BandoRequisitiVariante BandoRequisitiVarianteItem in this)
			{
				if (((BandoRequisitiVarianteItem.IdBando != null) || (MisuraEqualThis == null) || ((BandoRequisitiVarianteItem.Misura != null) && (BandoRequisitiVarianteItem.Misura.Value.Contains (MisuraEqualThis.Value)))))
				{
					BandoRequisitiVarianteCollectionTemp.Add(BandoRequisitiVarianteItem);
				}
			}
			return BandoRequisitiVarianteCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_REQUISITI_VARIANTE>
  <ViewName>vBANDO_REQUISITI_VARIANTE</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
    </Find>
  </Finds>
  <Filters>
    <FiltroProcedura>
      <REQUISITO_DI_PRESENTAZIONE>Equal</REQUISITO_DI_PRESENTAZIONE>
      <REQUISITO_DI_ISTRUTTORIA>Equal</REQUISITO_DI_ISTRUTTORIA>
    </FiltroProcedura>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_REQUISITI_VARIANTE>
*/