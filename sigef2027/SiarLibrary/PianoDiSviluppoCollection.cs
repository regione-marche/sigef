using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for PianoDiSviluppoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PianoDiSviluppoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PianoDiSviluppoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PianoDiSviluppo) info.GetValue(i.ToString(),typeof(PianoDiSviluppo)));
			}
		}

		//Costruttore
		public PianoDiSviluppoCollection()
		{
			this.ItemType = typeof(PianoDiSviluppo);
		}

		//Costruttore con provider
		public PianoDiSviluppoCollection(IPianoDiSviluppoProvider providerObj)
		{
			this.ItemType = typeof(PianoDiSviluppo);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PianoDiSviluppo this[int index]
		{
			get { return (PianoDiSviluppo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PianoDiSviluppoCollection GetChanges()
		{
			return (PianoDiSviluppoCollection) base.GetChanges();
		}

		[NonSerialized] private IPianoDiSviluppoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPianoDiSviluppoProvider Provider
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
		public int Add(PianoDiSviluppo PianoDiSviluppoObj)
		{
			if (PianoDiSviluppoObj.Provider == null) PianoDiSviluppoObj.Provider = this.Provider;
			return base.Add(PianoDiSviluppoObj);
		}

		//AddCollection
		public void AddCollection(PianoDiSviluppoCollection PianoDiSviluppoCollectionObj)
		{
			foreach (PianoDiSviluppo PianoDiSviluppoObj in PianoDiSviluppoCollectionObj)
				this.Add(PianoDiSviluppoObj);
		}

		//Insert
		public void Insert(int index, PianoDiSviluppo PianoDiSviluppoObj)
		{
			if (PianoDiSviluppoObj.Provider == null) PianoDiSviluppoObj.Provider = this.Provider;
			base.Insert(index, PianoDiSviluppoObj);
		}

		//CollectionGetById
		public PianoDiSviluppo CollectionGetById(NullTypes.IntNT IdPianoValue)
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
		public PianoDiSviluppoCollection SubSelect(NullTypes.IntNT IdPianoEqualThis, NullTypes.IntNT AnnoEqualThis, NullTypes.IntNT IdImpresaEqualThis, 
NullTypes.IntNT IdProgettoEqualThis, NullTypes.DecimalNT CostoInvestimentoEqualThis, NullTypes.DecimalNT MezziPropriEqualThis, 
NullTypes.DecimalNT RisorseTerziEqualThis, NullTypes.DecimalNT ContributiPubbliciEqualThis, NullTypes.DecimalNT SpeseGestioneEqualThis, 
NullTypes.DecimalNT RimborsoDebitoEqualThis, NullTypes.DecimalNT EntrataGestioneEqualThis, NullTypes.DecimalNT AltreCopertureEqualThis)
		{
			PianoDiSviluppoCollection PianoDiSviluppoCollectionTemp = new PianoDiSviluppoCollection();
			foreach (PianoDiSviluppo PianoDiSviluppoItem in this)
			{
				if (((IdPianoEqualThis == null) || ((PianoDiSviluppoItem.IdPiano != null) && (PianoDiSviluppoItem.IdPiano.Value == IdPianoEqualThis.Value))) && ((AnnoEqualThis == null) || ((PianoDiSviluppoItem.Anno != null) && (PianoDiSviluppoItem.Anno.Value == AnnoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((PianoDiSviluppoItem.IdImpresa != null) && (PianoDiSviluppoItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && 
((IdProgettoEqualThis == null) || ((PianoDiSviluppoItem.IdProgetto != null) && (PianoDiSviluppoItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((CostoInvestimentoEqualThis == null) || ((PianoDiSviluppoItem.CostoInvestimento != null) && (PianoDiSviluppoItem.CostoInvestimento.Value == CostoInvestimentoEqualThis.Value))) && ((MezziPropriEqualThis == null) || ((PianoDiSviluppoItem.MezziPropri != null) && (PianoDiSviluppoItem.MezziPropri.Value == MezziPropriEqualThis.Value))) && 
((RisorseTerziEqualThis == null) || ((PianoDiSviluppoItem.RisorseTerzi != null) && (PianoDiSviluppoItem.RisorseTerzi.Value == RisorseTerziEqualThis.Value))) && ((ContributiPubbliciEqualThis == null) || ((PianoDiSviluppoItem.ContributiPubblici != null) && (PianoDiSviluppoItem.ContributiPubblici.Value == ContributiPubbliciEqualThis.Value))) && ((SpeseGestioneEqualThis == null) || ((PianoDiSviluppoItem.SpeseGestione != null) && (PianoDiSviluppoItem.SpeseGestione.Value == SpeseGestioneEqualThis.Value))) && 
((RimborsoDebitoEqualThis == null) || ((PianoDiSviluppoItem.RimborsoDebito != null) && (PianoDiSviluppoItem.RimborsoDebito.Value == RimborsoDebitoEqualThis.Value))) && ((EntrataGestioneEqualThis == null) || ((PianoDiSviluppoItem.EntrataGestione != null) && (PianoDiSviluppoItem.EntrataGestione.Value == EntrataGestioneEqualThis.Value))) && ((AltreCopertureEqualThis == null) || ((PianoDiSviluppoItem.AltreCoperture != null) && (PianoDiSviluppoItem.AltreCoperture.Value == AltreCopertureEqualThis.Value))))
				{
					PianoDiSviluppoCollectionTemp.Add(PianoDiSviluppoItem);
				}
			}
			return PianoDiSviluppoCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PianoDiSviluppoCollection FiltroAttuale(NullTypes.BoolNT IdProgettoIsNull)
		{
			PianoDiSviluppoCollection PianoDiSviluppoCollectionTemp = new PianoDiSviluppoCollection();
			foreach (PianoDiSviluppo PianoDiSviluppoItem in this)
			{
				if (((IdProgettoIsNull == null) || ((PianoDiSviluppoItem.IdProgetto == null) ==  IdProgettoIsNull.Value)))
				{
					PianoDiSviluppoCollectionTemp.Add(PianoDiSviluppoItem);
				}
			}
			return PianoDiSviluppoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PIANO_DI_SVILUPPO>
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
      <ID_PIANO>Equal</ID_PIANO>
      <ANNO>Equal</ANNO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
    </Find>
  </Finds>
  <Filters>
    <FiltroAttuale>
      <ID_PROGETTO>IsNull</ID_PROGETTO>
    </FiltroAttuale>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PIANO_DI_SVILUPPO>
*/