using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VisiteAziendaliCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VisiteAziendaliCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VisiteAziendaliCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VisiteAziendali) info.GetValue(i.ToString(),typeof(VisiteAziendali)));
			}
		}

		//Costruttore
		public VisiteAziendaliCollection()
		{
			this.ItemType = typeof(VisiteAziendali);
		}

		//Costruttore con provider
		public VisiteAziendaliCollection(IVisiteAziendaliProvider providerObj)
		{
			this.ItemType = typeof(VisiteAziendali);
			this.Provider = providerObj;
		}

		//Get e Set
		public new VisiteAziendali this[int index]
		{
			get { return (VisiteAziendali)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VisiteAziendaliCollection GetChanges()
		{
			return (VisiteAziendaliCollection) base.GetChanges();
		}

		[NonSerialized] private IVisiteAziendaliProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVisiteAziendaliProvider Provider
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
		public int Add(VisiteAziendali VisiteAziendaliObj)
		{
			if (VisiteAziendaliObj.Provider == null) VisiteAziendaliObj.Provider = this.Provider;
			return base.Add(VisiteAziendaliObj);
		}

		//AddCollection
		public void AddCollection(VisiteAziendaliCollection VisiteAziendaliCollectionObj)
		{
			foreach (VisiteAziendali VisiteAziendaliObj in VisiteAziendaliCollectionObj)
				this.Add(VisiteAziendaliObj);
		}

		//Insert
		public void Insert(int index, VisiteAziendali VisiteAziendaliObj)
		{
			if (VisiteAziendaliObj.Provider == null) VisiteAziendaliObj.Provider = this.Provider;
			base.Insert(index, VisiteAziendaliObj);
		}

		//CollectionGetById
		public VisiteAziendali CollectionGetById(NullTypes.IntNT IdVisitaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdVisita == IdVisitaValue))
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
		public VisiteAziendaliCollection SubSelect(NullTypes.IntNT IdVisitaEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.IntNT IdDomandaEroaEqualThis, 
NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT CodTipoEqualThis, NullTypes.DatetimeNT DataAperturaEqualThis, 
NullTypes.StringNT OperatoreAperturaEqualThis, NullTypes.BoolNT ControlloConclusoEqualThis, NullTypes.DatetimeNT DataChiusuraEqualThis, 
NullTypes.StringNT OperatoreChiusuraEqualThis, NullTypes.StringNT SegnaturaVerbaleEqualThis)
		{
			VisiteAziendaliCollection VisiteAziendaliCollectionTemp = new VisiteAziendaliCollection();
			foreach (VisiteAziendali VisiteAziendaliItem in this)
			{
				if (((IdVisitaEqualThis == null) || ((VisiteAziendaliItem.IdVisita != null) && (VisiteAziendaliItem.IdVisita.Value == IdVisitaEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((VisiteAziendaliItem.IdDomandaPagamento != null) && (VisiteAziendaliItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((IdDomandaEroaEqualThis == null) || ((VisiteAziendaliItem.IdDomandaEroa != null) && (VisiteAziendaliItem.IdDomandaEroa.Value == IdDomandaEroaEqualThis.Value))) && 
((IdImpresaEqualThis == null) || ((VisiteAziendaliItem.IdImpresa != null) && (VisiteAziendaliItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((CodTipoEqualThis == null) || ((VisiteAziendaliItem.CodTipo != null) && (VisiteAziendaliItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((DataAperturaEqualThis == null) || ((VisiteAziendaliItem.DataApertura != null) && (VisiteAziendaliItem.DataApertura.Value == DataAperturaEqualThis.Value))) && 
((OperatoreAperturaEqualThis == null) || ((VisiteAziendaliItem.OperatoreApertura != null) && (VisiteAziendaliItem.OperatoreApertura.Value == OperatoreAperturaEqualThis.Value))) && ((ControlloConclusoEqualThis == null) || ((VisiteAziendaliItem.ControlloConcluso != null) && (VisiteAziendaliItem.ControlloConcluso.Value == ControlloConclusoEqualThis.Value))) && ((DataChiusuraEqualThis == null) || ((VisiteAziendaliItem.DataChiusura != null) && (VisiteAziendaliItem.DataChiusura.Value == DataChiusuraEqualThis.Value))) && 
((OperatoreChiusuraEqualThis == null) || ((VisiteAziendaliItem.OperatoreChiusura != null) && (VisiteAziendaliItem.OperatoreChiusura.Value == OperatoreChiusuraEqualThis.Value))) && ((SegnaturaVerbaleEqualThis == null) || ((VisiteAziendaliItem.SegnaturaVerbale != null) && (VisiteAziendaliItem.SegnaturaVerbale.Value == SegnaturaVerbaleEqualThis.Value))))
				{
					VisiteAziendaliCollectionTemp.Add(VisiteAziendaliItem);
				}
			}
			return VisiteAziendaliCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VisiteAziendaliCollection FiltroControlloConcluso(NullTypes.BoolNT ControlloConclusoEqualThis)
		{
			VisiteAziendaliCollection VisiteAziendaliCollectionTemp = new VisiteAziendaliCollection();
			foreach (VisiteAziendali VisiteAziendaliItem in this)
			{
				if (((ControlloConclusoEqualThis == null) || ((VisiteAziendaliItem.ControlloConcluso != null) && (VisiteAziendaliItem.ControlloConcluso.Value == ControlloConclusoEqualThis.Value))))
				{
					VisiteAziendaliCollectionTemp.Add(VisiteAziendaliItem);
				}
			}
			return VisiteAziendaliCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VisiteAziendaliCollection FiltroTipo(NullTypes.StringNT CodTipoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis)
		{
			VisiteAziendaliCollection VisiteAziendaliCollectionTemp = new VisiteAziendaliCollection();
			foreach (VisiteAziendali VisiteAziendaliItem in this)
			{
				if (((CodTipoEqualThis == null) || ((VisiteAziendaliItem.CodTipo != null) && (VisiteAziendaliItem.CodTipo.Value == CodTipoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((VisiteAziendaliItem.IdDomandaPagamento != null) && (VisiteAziendaliItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))))
				{
					VisiteAziendaliCollectionTemp.Add(VisiteAziendaliItem);
				}
			}
			return VisiteAziendaliCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<VISITE_AZIENDALI>
  <ViewName>vVISITE_AZIENDALI</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ID_VISITA DESC">
      <ID_VISITA>Equal</ID_VISITA>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_DOMANDA_EROA>Equal</ID_DOMANDA_EROA>
    </Find>
  </Finds>
  <Filters>
    <FiltroControlloConcluso>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </FiltroControlloConcluso>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VISITE_AZIENDALI>
*/