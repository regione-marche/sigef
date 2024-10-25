using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for ControlliParametriDiRischioCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ControlliParametriDiRischioCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ControlliParametriDiRischioCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ControlliParametriDiRischio) info.GetValue(i.ToString(),typeof(ControlliParametriDiRischio)));
			}
		}

		//Costruttore
		public ControlliParametriDiRischioCollection()
		{
			this.ItemType = typeof(ControlliParametriDiRischio);
		}

		//Costruttore con provider
		public ControlliParametriDiRischioCollection(IControlliParametriDiRischioProvider providerObj)
		{
			this.ItemType = typeof(ControlliParametriDiRischio);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ControlliParametriDiRischio this[int index]
		{
			get { return (ControlliParametriDiRischio)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ControlliParametriDiRischioCollection GetChanges()
		{
			return (ControlliParametriDiRischioCollection) base.GetChanges();
		}

		[NonSerialized] private IControlliParametriDiRischioProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliParametriDiRischioProvider Provider
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
		public int Add(ControlliParametriDiRischio ControlliParametriDiRischioObj)
		{
			if (ControlliParametriDiRischioObj.Provider == null) ControlliParametriDiRischioObj.Provider = this.Provider;
			return base.Add(ControlliParametriDiRischioObj);
		}

		//AddCollection
		public void AddCollection(ControlliParametriDiRischioCollection ControlliParametriDiRischioCollectionObj)
		{
			foreach (ControlliParametriDiRischio ControlliParametriDiRischioObj in ControlliParametriDiRischioCollectionObj)
				this.Add(ControlliParametriDiRischioObj);
		}

		//Insert
		public void Insert(int index, ControlliParametriDiRischio ControlliParametriDiRischioObj)
		{
			if (ControlliParametriDiRischioObj.Provider == null) ControlliParametriDiRischioObj.Provider = this.Provider;
			base.Insert(index, ControlliParametriDiRischioObj);
		}

		//CollectionGetById
		public ControlliParametriDiRischio CollectionGetById(NullTypes.IntNT IdParametroValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdParametro == IdParametroValue))
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
		public ControlliParametriDiRischioCollection SubSelect(NullTypes.IntNT IdParametroEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT ManualeEqualThis, 
NullTypes.StringNT QuerySqlEqualThis, NullTypes.IntNT PesoEqualThis)
		{
			ControlliParametriDiRischioCollection ControlliParametriDiRischioCollectionTemp = new ControlliParametriDiRischioCollection();
			foreach (ControlliParametriDiRischio ControlliParametriDiRischioItem in this)
			{
				if (((IdParametroEqualThis == null) || ((ControlliParametriDiRischioItem.IdParametro != null) && (ControlliParametriDiRischioItem.IdParametro.Value == IdParametroEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((ControlliParametriDiRischioItem.Descrizione != null) && (ControlliParametriDiRischioItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((ManualeEqualThis == null) || ((ControlliParametriDiRischioItem.Manuale != null) && (ControlliParametriDiRischioItem.Manuale.Value == ManualeEqualThis.Value))) && 
((QuerySqlEqualThis == null) || ((ControlliParametriDiRischioItem.QuerySql != null) && (ControlliParametriDiRischioItem.QuerySql.Value == QuerySqlEqualThis.Value))) && ((PesoEqualThis == null) || ((ControlliParametriDiRischioItem.Peso != null) && (ControlliParametriDiRischioItem.Peso.Value == PesoEqualThis.Value))))
				{
					ControlliParametriDiRischioCollectionTemp.Add(ControlliParametriDiRischioItem);
				}
			}
			return ControlliParametriDiRischioCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_PARAMETRI_DI_RISCHIO>
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
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <MANUALE>Equal</MANUALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_DI_RISCHIO>
*/