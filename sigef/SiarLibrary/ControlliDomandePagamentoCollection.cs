using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for ControlliDomandePagamentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ControlliDomandePagamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ControlliDomandePagamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ControlliDomandePagamento) info.GetValue(i.ToString(),typeof(ControlliDomandePagamento)));
			}
		}

		//Costruttore
		public ControlliDomandePagamentoCollection()
		{
			this.ItemType = typeof(ControlliDomandePagamento);
		}

		//Costruttore con provider
		public ControlliDomandePagamentoCollection(IControlliDomandePagamentoProvider providerObj)
		{
			this.ItemType = typeof(ControlliDomandePagamento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ControlliDomandePagamento this[int index]
		{
			get { return (ControlliDomandePagamento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ControlliDomandePagamentoCollection GetChanges()
		{
			return (ControlliDomandePagamentoCollection) base.GetChanges();
		}

		[NonSerialized] private IControlliDomandePagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliDomandePagamentoProvider Provider
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
		public int Add(ControlliDomandePagamento ControlliDomandePagamentoObj)
		{
			if (ControlliDomandePagamentoObj.Provider == null) ControlliDomandePagamentoObj.Provider = this.Provider;
			return base.Add(ControlliDomandePagamentoObj);
		}

		//AddCollection
		public void AddCollection(ControlliDomandePagamentoCollection ControlliDomandePagamentoCollectionObj)
		{
			foreach (ControlliDomandePagamento ControlliDomandePagamentoObj in ControlliDomandePagamentoCollectionObj)
				this.Add(ControlliDomandePagamentoObj);
		}

		//Insert
		public void Insert(int index, ControlliDomandePagamento ControlliDomandePagamentoObj)
		{
			if (ControlliDomandePagamentoObj.Provider == null) ControlliDomandePagamentoObj.Provider = this.Provider;
			base.Insert(index, ControlliDomandePagamentoObj);
		}

		//CollectionGetById
		public ControlliDomandePagamento CollectionGetById(NullTypes.IntNT IdLottoValue, NullTypes.IntNT IdDomandaPagamentoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdLotto == IdLottoValue) && (this[i].IdDomandaPagamento == IdDomandaPagamentoValue))
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
		public ControlliDomandePagamentoCollection SubSelect(NullTypes.IntNT IdLottoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, NullTypes.StringNT OperatoreAssegnatoEqualThis, 
NullTypes.BoolNT SelezionataXControlloEqualThis, NullTypes.StringNT TipoEstrazioneEqualThis, NullTypes.DecimalNT ValoreDiRischioEqualThis, 
NullTypes.StringNT ClasseDiRischioEqualThis, NullTypes.IntNT OrdineClasseDiRischioEqualThis, NullTypes.DecimalNT ContributoRichiestoEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT OperatoreEqualThis, NullTypes.BoolNT ControlloConclusoEqualThis)
		{
			ControlliDomandePagamentoCollection ControlliDomandePagamentoCollectionTemp = new ControlliDomandePagamentoCollection();
			foreach (ControlliDomandePagamento ControlliDomandePagamentoItem in this)
			{
				if (((IdLottoEqualThis == null) || ((ControlliDomandePagamentoItem.IdLotto != null) && (ControlliDomandePagamentoItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((ControlliDomandePagamentoItem.IdDomandaPagamento != null) && (ControlliDomandePagamentoItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && ((OperatoreAssegnatoEqualThis == null) || ((ControlliDomandePagamentoItem.OperatoreAssegnato != null) && (ControlliDomandePagamentoItem.OperatoreAssegnato.Value == OperatoreAssegnatoEqualThis.Value))) && 
((SelezionataXControlloEqualThis == null) || ((ControlliDomandePagamentoItem.SelezionataXControllo != null) && (ControlliDomandePagamentoItem.SelezionataXControllo.Value == SelezionataXControlloEqualThis.Value))) && ((TipoEstrazioneEqualThis == null) || ((ControlliDomandePagamentoItem.TipoEstrazione != null) && (ControlliDomandePagamentoItem.TipoEstrazione.Value == TipoEstrazioneEqualThis.Value))) && ((ValoreDiRischioEqualThis == null) || ((ControlliDomandePagamentoItem.ValoreDiRischio != null) && (ControlliDomandePagamentoItem.ValoreDiRischio.Value == ValoreDiRischioEqualThis.Value))) && 
((ClasseDiRischioEqualThis == null) || ((ControlliDomandePagamentoItem.ClasseDiRischio != null) && (ControlliDomandePagamentoItem.ClasseDiRischio.Value == ClasseDiRischioEqualThis.Value))) && ((OrdineClasseDiRischioEqualThis == null) || ((ControlliDomandePagamentoItem.OrdineClasseDiRischio != null) && (ControlliDomandePagamentoItem.OrdineClasseDiRischio.Value == OrdineClasseDiRischioEqualThis.Value))) && ((ContributoRichiestoEqualThis == null) || ((ControlliDomandePagamentoItem.ContributoRichiesto != null) && (ControlliDomandePagamentoItem.ContributoRichiesto.Value == ContributoRichiestoEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((ControlliDomandePagamentoItem.DataModifica != null) && (ControlliDomandePagamentoItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((ControlliDomandePagamentoItem.Operatore != null) && (ControlliDomandePagamentoItem.Operatore.Value == OperatoreEqualThis.Value))) && ((ControlloConclusoEqualThis == null) || ((ControlliDomandePagamentoItem.ControlloConcluso != null) && (ControlliDomandePagamentoItem.ControlloConcluso.Value == ControlloConclusoEqualThis.Value))))
				{
					ControlliDomandePagamentoCollectionTemp.Add(ControlliDomandePagamentoItem);
				}
			}
			return ControlliDomandePagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ControlliDomandePagamentoCollection FiltroControlli(NullTypes.BoolNT SelezionataXControlloEqualThis, NullTypes.BoolNT ControlloConclusoEqualThis)
		{
			ControlliDomandePagamentoCollection ControlliDomandePagamentoCollectionTemp = new ControlliDomandePagamentoCollection();
			foreach (ControlliDomandePagamento ControlliDomandePagamentoItem in this)
			{
				if (((SelezionataXControlloEqualThis == null) || ((ControlliDomandePagamentoItem.SelezionataXControllo != null) && (ControlliDomandePagamentoItem.SelezionataXControllo.Value == SelezionataXControlloEqualThis.Value))) && ((ControlloConclusoEqualThis == null) || ((ControlliDomandePagamentoItem.ControlloConcluso != null) && (ControlliDomandePagamentoItem.ControlloConcluso.Value == ControlloConclusoEqualThis.Value))))
				{
					ControlliDomandePagamentoCollectionTemp.Add(ControlliDomandePagamentoItem);
				}
			}
			return ControlliDomandePagamentoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ControlliDomandePagamentoCollection FiltroTipo(NullTypes.StringNT CodTipoEqualThis)
		{
			ControlliDomandePagamentoCollection ControlliDomandePagamentoCollectionTemp = new ControlliDomandePagamentoCollection();
			foreach (ControlliDomandePagamento ControlliDomandePagamentoItem in this)
			{
				if (((CodTipoEqualThis == null) || ((ControlliDomandePagamentoItem.CodTipo != null) && (ControlliDomandePagamentoItem.CodTipo.Value == CodTipoEqualThis.Value))))
				{
					ControlliDomandePagamentoCollectionTemp.Add(ControlliDomandePagamentoItem);
				}
			}
			return ControlliDomandePagamentoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_DOMANDE_PAGAMENTO>
  <ViewName>vCONTROLLI_DOMANDE_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY SELEZIONATA_X_CONTROLLO DESC, TIPO_ESTRAZIONE, COD_TIPO DESC, VALORE_DI_RISCHIO DESC, CONTRIBUTO_RICHIESTO DESC">
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters>
    <FiltroControlli>
      <SELEZIONATA_X_CONTROLLO>Equal</SELEZIONATA_X_CONTROLLO>
      <CONTROLLO_CONCLUSO>Equal</CONTROLLO_CONCLUSO>
    </FiltroControlli>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</CONTROLLI_DOMANDE_PAGAMENTO>
*/