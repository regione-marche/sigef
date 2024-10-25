using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for ContoCorrenteCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ContoCorrenteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ContoCorrenteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ContoCorrente) info.GetValue(i.ToString(),typeof(ContoCorrente)));
			}
		}

		//Costruttore
		public ContoCorrenteCollection()
		{
			this.ItemType = typeof(ContoCorrente);
		}

		//Costruttore con provider
		public ContoCorrenteCollection(IContoCorrenteProvider providerObj)
		{
			this.ItemType = typeof(ContoCorrente);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ContoCorrente this[int index]
		{
			get { return (ContoCorrente)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ContoCorrenteCollection GetChanges()
		{
			return (ContoCorrenteCollection) base.GetChanges();
		}

		[NonSerialized] private IContoCorrenteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IContoCorrenteProvider Provider
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
		public int Add(ContoCorrente ContoCorrenteObj)
		{
			if (ContoCorrenteObj.Provider == null) ContoCorrenteObj.Provider = this.Provider;
			return base.Add(ContoCorrenteObj);
		}

		//AddCollection
		public void AddCollection(ContoCorrenteCollection ContoCorrenteCollectionObj)
		{
			foreach (ContoCorrente ContoCorrenteObj in ContoCorrenteCollectionObj)
				this.Add(ContoCorrenteObj);
		}

		//Insert
		public void Insert(int index, ContoCorrente ContoCorrenteObj)
		{
			if (ContoCorrenteObj.Provider == null) ContoCorrenteObj.Provider = this.Provider;
			base.Insert(index, ContoCorrenteObj);
		}

		//CollectionGetById
		public ContoCorrente CollectionGetById(NullTypes.IntNT IdContoCorrenteValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdContoCorrente == IdContoCorrenteValue))
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
		public ContoCorrenteCollection SubSelect(NullTypes.IntNT IdContoCorrenteEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.IntNT IdPersonaEqualThis, 
NullTypes.StringNT CodPaeseEqualThis, NullTypes.StringNT CinEuroEqualThis, NullTypes.StringNT CinEqualThis, 
NullTypes.StringNT AbiEqualThis, NullTypes.StringNT CabEqualThis, NullTypes.StringNT NumeroEqualThis, 
NullTypes.StringNT NoteEqualThis, NullTypes.DatetimeNT DataInizioValiditaEqualThis, NullTypes.DatetimeNT DataFineValiditaEqualThis, 
NullTypes.StringNT IstitutoEqualThis, NullTypes.StringNT AgenziaEqualThis, NullTypes.IntNT IdComuneEqualThis)
		{
			ContoCorrenteCollection ContoCorrenteCollectionTemp = new ContoCorrenteCollection();
			foreach (ContoCorrente ContoCorrenteItem in this)
			{
				if (((IdContoCorrenteEqualThis == null) || ((ContoCorrenteItem.IdContoCorrente != null) && (ContoCorrenteItem.IdContoCorrente.Value == IdContoCorrenteEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((ContoCorrenteItem.IdImpresa != null) && (ContoCorrenteItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((IdPersonaEqualThis == null) || ((ContoCorrenteItem.IdPersona != null) && (ContoCorrenteItem.IdPersona.Value == IdPersonaEqualThis.Value))) && 
((CodPaeseEqualThis == null) || ((ContoCorrenteItem.CodPaese != null) && (ContoCorrenteItem.CodPaese.Value == CodPaeseEqualThis.Value))) && ((CinEuroEqualThis == null) || ((ContoCorrenteItem.CinEuro != null) && (ContoCorrenteItem.CinEuro.Value == CinEuroEqualThis.Value))) && ((CinEqualThis == null) || ((ContoCorrenteItem.Cin != null) && (ContoCorrenteItem.Cin.Value == CinEqualThis.Value))) && 
((AbiEqualThis == null) || ((ContoCorrenteItem.Abi != null) && (ContoCorrenteItem.Abi.Value == AbiEqualThis.Value))) && ((CabEqualThis == null) || ((ContoCorrenteItem.Cab != null) && (ContoCorrenteItem.Cab.Value == CabEqualThis.Value))) && ((NumeroEqualThis == null) || ((ContoCorrenteItem.Numero != null) && (ContoCorrenteItem.Numero.Value == NumeroEqualThis.Value))) && 
((NoteEqualThis == null) || ((ContoCorrenteItem.Note != null) && (ContoCorrenteItem.Note.Value == NoteEqualThis.Value))) && ((DataInizioValiditaEqualThis == null) || ((ContoCorrenteItem.DataInizioValidita != null) && (ContoCorrenteItem.DataInizioValidita.Value == DataInizioValiditaEqualThis.Value))) && ((DataFineValiditaEqualThis == null) || ((ContoCorrenteItem.DataFineValidita != null) && (ContoCorrenteItem.DataFineValidita.Value == DataFineValiditaEqualThis.Value))) && 
((IstitutoEqualThis == null) || ((ContoCorrenteItem.Istituto != null) && (ContoCorrenteItem.Istituto.Value == IstitutoEqualThis.Value))) && ((AgenziaEqualThis == null) || ((ContoCorrenteItem.Agenzia != null) && (ContoCorrenteItem.Agenzia.Value == AgenziaEqualThis.Value))) && ((IdComuneEqualThis == null) || ((ContoCorrenteItem.IdComune != null) && (ContoCorrenteItem.IdComune.Value == IdComuneEqualThis.Value))))
				{
					ContoCorrenteCollectionTemp.Add(ContoCorrenteItem);
				}
			}
			return ContoCorrenteCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTO_CORRENTE>
  <ViewName>vCONTO_CORRENTE</ViewName>
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
    <Find OrderBy="ORDER BY DATA_INIZIO_VALIDITA DESC">
      <ID_CONTO_CORRENTE>Equal</ID_CONTO_CORRENTE>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ID_PERSONA>Equal</ID_PERSONA>
      <DATA_INIZIO_VALIDITA>EqLessThan</DATA_INIZIO_VALIDITA>
      <DATA_FINE_VALIDITA>EqGreaterThan</DATA_FINE_VALIDITA>
      <DATA_FINE_VALIDITA>IsNull</DATA_FINE_VALIDITA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTO_CORRENTE>
*/