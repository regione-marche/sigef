using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for GraduatoriaProgettiFinanziabilitaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class GraduatoriaProgettiFinanziabilitaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private GraduatoriaProgettiFinanziabilitaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((GraduatoriaProgettiFinanziabilita) info.GetValue(i.ToString(),typeof(GraduatoriaProgettiFinanziabilita)));
			}
		}

		//Costruttore
		public GraduatoriaProgettiFinanziabilitaCollection()
		{
			this.ItemType = typeof(GraduatoriaProgettiFinanziabilita);
		}

		//Costruttore con provider
		public GraduatoriaProgettiFinanziabilitaCollection(IGraduatoriaProgettiFinanziabilitaProvider providerObj)
		{
			this.ItemType = typeof(GraduatoriaProgettiFinanziabilita);
			this.Provider = providerObj;
		}

		//Get e Set
		public new GraduatoriaProgettiFinanziabilita this[int index]
		{
			get { return (GraduatoriaProgettiFinanziabilita)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new GraduatoriaProgettiFinanziabilitaCollection GetChanges()
		{
			return (GraduatoriaProgettiFinanziabilitaCollection) base.GetChanges();
		}

		[NonSerialized] private IGraduatoriaProgettiFinanziabilitaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IGraduatoriaProgettiFinanziabilitaProvider Provider
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
		public int Add(GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj)
		{
			if (GraduatoriaProgettiFinanziabilitaObj.Provider == null) GraduatoriaProgettiFinanziabilitaObj.Provider = this.Provider;
			return base.Add(GraduatoriaProgettiFinanziabilitaObj);
		}

		//AddCollection
		public void AddCollection(GraduatoriaProgettiFinanziabilitaCollection GraduatoriaProgettiFinanziabilitaCollectionObj)
		{
			foreach (GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj in GraduatoriaProgettiFinanziabilitaCollectionObj)
				this.Add(GraduatoriaProgettiFinanziabilitaObj);
		}

		//Insert
		public void Insert(int index, GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaObj)
		{
			if (GraduatoriaProgettiFinanziabilitaObj.Provider == null) GraduatoriaProgettiFinanziabilitaObj.Provider = this.Provider;
			base.Insert(index, GraduatoriaProgettiFinanziabilitaObj);
		}

		//CollectionGetById
		public GraduatoriaProgettiFinanziabilita CollectionGetById(NullTypes.IntNT IdBandoValue, NullTypes.IntNT IdProgettoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBando == IdBandoValue) && (this[i].IdProgetto == IdProgettoValue))
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
		public GraduatoriaProgettiFinanziabilitaCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdProgettoEqualThis, NullTypes.IntNT IdProgIntegratoEqualThis, 
NullTypes.DecimalNT CostoTotaleEqualThis, NullTypes.DecimalNT ContributoDiMisuraEqualThis, NullTypes.DecimalNT ContributoRimanenteEqualThis, 
NullTypes.StringNT MisuraEqualThis, NullTypes.BoolNT MisuraPrevalenteEqualThis)
		{
			GraduatoriaProgettiFinanziabilitaCollection GraduatoriaProgettiFinanziabilitaCollectionTemp = new GraduatoriaProgettiFinanziabilitaCollection();
			foreach (GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaItem in this)
			{
				if (((IdBandoEqualThis == null) || ((GraduatoriaProgettiFinanziabilitaItem.IdBando != null) && (GraduatoriaProgettiFinanziabilitaItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((GraduatoriaProgettiFinanziabilitaItem.IdProgetto != null) && (GraduatoriaProgettiFinanziabilitaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && ((IdProgIntegratoEqualThis == null) || ((GraduatoriaProgettiFinanziabilitaItem.IdProgIntegrato != null) && (GraduatoriaProgettiFinanziabilitaItem.IdProgIntegrato.Value == IdProgIntegratoEqualThis.Value))) && 
((CostoTotaleEqualThis == null) || ((GraduatoriaProgettiFinanziabilitaItem.CostoTotale != null) && (GraduatoriaProgettiFinanziabilitaItem.CostoTotale.Value == CostoTotaleEqualThis.Value))) && ((ContributoDiMisuraEqualThis == null) || ((GraduatoriaProgettiFinanziabilitaItem.ContributoDiMisura != null) && (GraduatoriaProgettiFinanziabilitaItem.ContributoDiMisura.Value == ContributoDiMisuraEqualThis.Value))) && ((ContributoRimanenteEqualThis == null) || ((GraduatoriaProgettiFinanziabilitaItem.ContributoRimanente != null) && (GraduatoriaProgettiFinanziabilitaItem.ContributoRimanente.Value == ContributoRimanenteEqualThis.Value))) && 
((MisuraEqualThis == null) || ((GraduatoriaProgettiFinanziabilitaItem.Misura != null) && (GraduatoriaProgettiFinanziabilitaItem.Misura.Value == MisuraEqualThis.Value))) && ((MisuraPrevalenteEqualThis == null) || ((GraduatoriaProgettiFinanziabilitaItem.MisuraPrevalente != null) && (GraduatoriaProgettiFinanziabilitaItem.MisuraPrevalente.Value == MisuraPrevalenteEqualThis.Value))))
				{
					GraduatoriaProgettiFinanziabilitaCollectionTemp.Add(GraduatoriaProgettiFinanziabilitaItem);
				}
			}
			return GraduatoriaProgettiFinanziabilitaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public GraduatoriaProgettiFinanziabilitaCollection FiltroMisura(NullTypes.StringNT MisuraEqualThis)
		{
			GraduatoriaProgettiFinanziabilitaCollection GraduatoriaProgettiFinanziabilitaCollectionTemp = new GraduatoriaProgettiFinanziabilitaCollection();
			foreach (GraduatoriaProgettiFinanziabilita GraduatoriaProgettiFinanziabilitaItem in this)
			{
				if (((MisuraEqualThis == null) || ((GraduatoriaProgettiFinanziabilitaItem.Misura != null) && (GraduatoriaProgettiFinanziabilitaItem.Misura.Value == MisuraEqualThis.Value))))
				{
					GraduatoriaProgettiFinanziabilitaCollectionTemp.Add(GraduatoriaProgettiFinanziabilitaItem);
				}
			}
			return GraduatoriaProgettiFinanziabilitaCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<GRADUATORIA_PROGETTI_FINANZIABILITA>
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
    <Find OrderBy="ORDER BY MISURA_PREVALENTE DESC, MISURA">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_PROG_INTEGRATO>Equal</ID_PROG_INTEGRATO>
      <MISURA>Equal</MISURA>
    </Find>
  </Finds>
  <Filters>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</GRADUATORIA_PROGETTI_FINANZIABILITA>
*/