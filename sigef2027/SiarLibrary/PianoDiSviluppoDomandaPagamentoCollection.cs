using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for PianoDiSviluppoDomandaPagamentoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PianoDiSviluppoDomandaPagamentoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PianoDiSviluppoDomandaPagamentoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PianoDiSviluppoDomandaPagamento) info.GetValue(i.ToString(),typeof(PianoDiSviluppoDomandaPagamento)));
			}
		}

		//Costruttore
		public PianoDiSviluppoDomandaPagamentoCollection()
		{
			this.ItemType = typeof(PianoDiSviluppoDomandaPagamento);
		}

		//Costruttore con provider
		public PianoDiSviluppoDomandaPagamentoCollection(IPianoDiSviluppoDomandaPagamentoProvider providerObj)
		{
			this.ItemType = typeof(PianoDiSviluppoDomandaPagamento);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PianoDiSviluppoDomandaPagamento this[int index]
		{
			get { return (PianoDiSviluppoDomandaPagamento)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PianoDiSviluppoDomandaPagamentoCollection GetChanges()
		{
			return (PianoDiSviluppoDomandaPagamentoCollection) base.GetChanges();
		}

		[NonSerialized] private IPianoDiSviluppoDomandaPagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPianoDiSviluppoDomandaPagamentoProvider Provider
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
		public int Add(PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj)
		{
			if (PianoDiSviluppoDomandaPagamentoObj.Provider == null) PianoDiSviluppoDomandaPagamentoObj.Provider = this.Provider;
			return base.Add(PianoDiSviluppoDomandaPagamentoObj);
		}

		//AddCollection
		public void AddCollection(PianoDiSviluppoDomandaPagamentoCollection PianoDiSviluppoDomandaPagamentoCollectionObj)
		{
			foreach (PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj in PianoDiSviluppoDomandaPagamentoCollectionObj)
				this.Add(PianoDiSviluppoDomandaPagamentoObj);
		}

		//Insert
		public void Insert(int index, PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoObj)
		{
			if (PianoDiSviluppoDomandaPagamentoObj.Provider == null) PianoDiSviluppoDomandaPagamentoObj.Provider = this.Provider;
			base.Insert(index, PianoDiSviluppoDomandaPagamentoObj);
		}

		//CollectionGetById
		public PianoDiSviluppoDomandaPagamento CollectionGetById(NullTypes.IntNT IdPianoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPiano == IdPianoValue))
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
		public PianoDiSviluppoDomandaPagamentoCollection SubSelect(NullTypes.IntNT IdPianoEqualThis, NullTypes.IntNT AnnoEqualThis, NullTypes.IntNT IdDomandaPagamentoEqualThis, 
NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.DecimalNT CostoInvestimentoEqualThis, 
NullTypes.DecimalNT MezziPropriEqualThis, NullTypes.DecimalNT RisorseTerziEqualThis, NullTypes.DecimalNT ContributiPubbliciEqualThis, 
NullTypes.DecimalNT SpeseGestioneEqualThis, NullTypes.DecimalNT RimborsoDebitoEqualThis, NullTypes.DecimalNT EntrataGestioneEqualThis, 
NullTypes.DecimalNT AltreCopertureEqualThis)
		{
			PianoDiSviluppoDomandaPagamentoCollection PianoDiSviluppoDomandaPagamentoCollectionTemp = new PianoDiSviluppoDomandaPagamentoCollection();
			foreach (PianoDiSviluppoDomandaPagamento PianoDiSviluppoDomandaPagamentoItem in this)
			{
				if (((IdPianoEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.IdPiano != null) && (PianoDiSviluppoDomandaPagamentoItem.IdPiano.Value == IdPianoEqualThis.Value))) && ((AnnoEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.Anno != null) && (PianoDiSviluppoDomandaPagamentoItem.Anno.Value == AnnoEqualThis.Value))) && ((IdDomandaPagamentoEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.IdDomandaPagamento != null) && (PianoDiSviluppoDomandaPagamentoItem.IdDomandaPagamento.Value == IdDomandaPagamentoEqualThis.Value))) && 
((IdImpresaEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.IdImpresa != null) && (PianoDiSviluppoDomandaPagamentoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.IdProgetto != null) && (PianoDiSviluppoDomandaPagamentoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CostoInvestimentoEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.CostoInvestimento != null) && (PianoDiSviluppoDomandaPagamentoItem.CostoInvestimento.Value == CostoInvestimentoEqualThis.Value))) && 
((MezziPropriEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.MezziPropri != null) && (PianoDiSviluppoDomandaPagamentoItem.MezziPropri.Value == MezziPropriEqualThis.Value))) && ((RisorseTerziEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.RisorseTerzi != null) && (PianoDiSviluppoDomandaPagamentoItem.RisorseTerzi.Value == RisorseTerziEqualThis.Value))) && ((ContributiPubbliciEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.ContributiPubblici != null) && (PianoDiSviluppoDomandaPagamentoItem.ContributiPubblici.Value == ContributiPubbliciEqualThis.Value))) && 
((SpeseGestioneEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.SpeseGestione != null) && (PianoDiSviluppoDomandaPagamentoItem.SpeseGestione.Value == SpeseGestioneEqualThis.Value))) && ((RimborsoDebitoEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.RimborsoDebito != null) && (PianoDiSviluppoDomandaPagamentoItem.RimborsoDebito.Value == RimborsoDebitoEqualThis.Value))) && ((EntrataGestioneEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.EntrataGestione != null) && (PianoDiSviluppoDomandaPagamentoItem.EntrataGestione.Value == EntrataGestioneEqualThis.Value))) && 
((AltreCopertureEqualThis == null) || ((PianoDiSviluppoDomandaPagamentoItem.AltreCoperture != null) && (PianoDiSviluppoDomandaPagamentoItem.AltreCoperture.Value == AltreCopertureEqualThis.Value))))
				{
					PianoDiSviluppoDomandaPagamentoCollectionTemp.Add(PianoDiSviluppoDomandaPagamentoItem);
				}
			}
			return PianoDiSviluppoDomandaPagamentoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO>
  <ViewName>
  </ViewName>
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
    <Find OrderBy="ORDER BY ANNO DESC">
      <ANNO>Equal</ANNO>
      <ID_DOMANDA_PAGAMENTO>Equal</ID_DOMANDA_PAGAMENTO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO>
*/