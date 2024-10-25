using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for PartecipantiIndirettiFatturatoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PartecipantiIndirettiFatturatoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PartecipantiIndirettiFatturatoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PartecipantiIndirettiFatturato) info.GetValue(i.ToString(),typeof(PartecipantiIndirettiFatturato)));
			}
		}

		//Costruttore
		public PartecipantiIndirettiFatturatoCollection()
		{
			this.ItemType = typeof(PartecipantiIndirettiFatturato);
		}

		//Costruttore con provider
		public PartecipantiIndirettiFatturatoCollection(IPartecipantiIndirettiFatturatoProvider providerObj)
		{
			this.ItemType = typeof(PartecipantiIndirettiFatturato);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PartecipantiIndirettiFatturato this[int index]
		{
			get { return (PartecipantiIndirettiFatturato)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PartecipantiIndirettiFatturatoCollection GetChanges()
		{
			return (PartecipantiIndirettiFatturatoCollection) base.GetChanges();
		}

		[NonSerialized] private IPartecipantiIndirettiFatturatoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPartecipantiIndirettiFatturatoProvider Provider
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
		public int Add(PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj)
		{
			if (PartecipantiIndirettiFatturatoObj.Provider == null) PartecipantiIndirettiFatturatoObj.Provider = this.Provider;
			return base.Add(PartecipantiIndirettiFatturatoObj);
		}

		//AddCollection
		public void AddCollection(PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionObj)
		{
			foreach (PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj in PartecipantiIndirettiFatturatoCollectionObj)
				this.Add(PartecipantiIndirettiFatturatoObj);
		}

		//Insert
		public void Insert(int index, PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoObj)
		{
			if (PartecipantiIndirettiFatturatoObj.Provider == null) PartecipantiIndirettiFatturatoObj.Provider = this.Provider;
			base.Insert(index, PartecipantiIndirettiFatturatoObj);
		}

		//CollectionGetById
		public PartecipantiIndirettiFatturato CollectionGetById(NullTypes.IntNT IdValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].Id == IdValue))
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
		public PartecipantiIndirettiFatturatoCollection SubSelect(NullTypes.IntNT IdEqualThis, NullTypes.StringNT CuaaPromotoreEqualThis, NullTypes.IntNT IdImpresaEqualThis, 
NullTypes.StringNT CuaaEqualThis, NullTypes.StringNT CodProdottoEqualThis, NullTypes.StringNT CodVarietaEqualThis, 
NullTypes.IntNT IdClasseAllevamentoEqualThis, NullTypes.IntNT NumeroCapiEqualThis, NullTypes.IntNT IdAttivitaConnessaEqualThis, 
NullTypes.DecimalNT ProduzioneTotaleEqualThis, NullTypes.DecimalNT ProduzioneInFilieraEqualThis, NullTypes.DecimalNT PrezzoMedioEqualThis, 
NullTypes.DecimalNT FatturatoEqualThis, NullTypes.StringNT CuaaTrasformatoreEqualThis)
		{
			PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionTemp = new PartecipantiIndirettiFatturatoCollection();
			foreach (PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoItem in this)
			{
				if (((IdEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.Id != null) && (PartecipantiIndirettiFatturatoItem.Id.Value == IdEqualThis.Value))) && ((CuaaPromotoreEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.CuaaPromotore != null) && (PartecipantiIndirettiFatturatoItem.CuaaPromotore.Value == CuaaPromotoreEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.IdImpresa != null) && (PartecipantiIndirettiFatturatoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && 
((CuaaEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.Cuaa != null) && (PartecipantiIndirettiFatturatoItem.Cuaa.Value == CuaaEqualThis.Value))) && ((CodProdottoEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.CodProdotto != null) && (PartecipantiIndirettiFatturatoItem.CodProdotto.Value == CodProdottoEqualThis.Value))) && ((CodVarietaEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.CodVarieta != null) && (PartecipantiIndirettiFatturatoItem.CodVarieta.Value == CodVarietaEqualThis.Value))) && 
((IdClasseAllevamentoEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.IdClasseAllevamento != null) && (PartecipantiIndirettiFatturatoItem.IdClasseAllevamento.Value == IdClasseAllevamentoEqualThis.Value))) && ((NumeroCapiEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.NumeroCapi != null) && (PartecipantiIndirettiFatturatoItem.NumeroCapi.Value == NumeroCapiEqualThis.Value))) && ((IdAttivitaConnessaEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.IdAttivitaConnessa != null) && (PartecipantiIndirettiFatturatoItem.IdAttivitaConnessa.Value == IdAttivitaConnessaEqualThis.Value))) && 
((ProduzioneTotaleEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.ProduzioneTotale != null) && (PartecipantiIndirettiFatturatoItem.ProduzioneTotale.Value == ProduzioneTotaleEqualThis.Value))) && ((ProduzioneInFilieraEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.ProduzioneInFiliera != null) && (PartecipantiIndirettiFatturatoItem.ProduzioneInFiliera.Value == ProduzioneInFilieraEqualThis.Value))) && ((PrezzoMedioEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.PrezzoMedio != null) && (PartecipantiIndirettiFatturatoItem.PrezzoMedio.Value == PrezzoMedioEqualThis.Value))) && 
((FatturatoEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.Fatturato != null) && (PartecipantiIndirettiFatturatoItem.Fatturato.Value == FatturatoEqualThis.Value))) && ((CuaaTrasformatoreEqualThis == null) || ((PartecipantiIndirettiFatturatoItem.CuaaTrasformatore != null) && (PartecipantiIndirettiFatturatoItem.CuaaTrasformatore.Value == CuaaTrasformatoreEqualThis.Value))))
				{
					PartecipantiIndirettiFatturatoCollectionTemp.Add(PartecipantiIndirettiFatturatoItem);
				}
			}
			return PartecipantiIndirettiFatturatoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PartecipantiIndirettiFatturatoCollection FiltroProdotto(NullTypes.BoolNT CodProdottoIsNull)
		{
			PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionTemp = new PartecipantiIndirettiFatturatoCollection();
			foreach (PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoItem in this)
			{
				if (((CodProdottoIsNull == null) || ((PartecipantiIndirettiFatturatoItem.CodProdotto == null) ==  CodProdottoIsNull.Value)))
				{
					PartecipantiIndirettiFatturatoCollectionTemp.Add(PartecipantiIndirettiFatturatoItem);
				}
			}
			return PartecipantiIndirettiFatturatoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PartecipantiIndirettiFatturatoCollection FiltroAllevamento(NullTypes.BoolNT IdClasseAllevamentoIsNull)
		{
			PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionTemp = new PartecipantiIndirettiFatturatoCollection();
			foreach (PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoItem in this)
			{
				if (((IdClasseAllevamentoIsNull == null) || ((PartecipantiIndirettiFatturatoItem.IdClasseAllevamento == null) ==  IdClasseAllevamentoIsNull.Value)))
				{
					PartecipantiIndirettiFatturatoCollectionTemp.Add(PartecipantiIndirettiFatturatoItem);
				}
			}
			return PartecipantiIndirettiFatturatoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PartecipantiIndirettiFatturatoCollection FiltroAttivita(NullTypes.BoolNT IdAttivitaConnessaIsNull)
		{
			PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionTemp = new PartecipantiIndirettiFatturatoCollection();
			foreach (PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoItem in this)
			{
				if (((IdAttivitaConnessaIsNull == null) || ((PartecipantiIndirettiFatturatoItem.IdAttivitaConnessa == null) ==  IdAttivitaConnessaIsNull.Value)))
				{
					PartecipantiIndirettiFatturatoCollectionTemp.Add(PartecipantiIndirettiFatturatoItem);
				}
			}
			return PartecipantiIndirettiFatturatoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PARTECIPANTI_INDIRETTI_FATTURATO>
  <ViewName>vPARECIPANTI_INDIRETTI_FATTURATO</ViewName>
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
    <Find OrderBy="ORDER BY ">
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CUAA_TRASFORMATORE>Equal</CUAA_TRASFORMATORE>
    </Find>
  </Finds>
  <Filters>
    <FiltroProdotto>
      <COD_PRODOTTO>IsNull</COD_PRODOTTO>
    </FiltroProdotto>
    <FiltroAllevamento>
      <ID_CLASSE_ALLEVAMENTO>IsNull</ID_CLASSE_ALLEVAMENTO>
    </FiltroAllevamento>
    <FiltroAttivita>
      <ID_ATTIVITA_CONNESSA>IsNull</ID_ATTIVITA_CONNESSA>
    </FiltroAttivita>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PARTECIPANTI_INDIRETTI_FATTURATO>
*/